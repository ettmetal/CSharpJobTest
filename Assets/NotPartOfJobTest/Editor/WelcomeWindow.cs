using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace com.brainplus.jobtest.editor
{
    public class WelcomeWindow : EditorWindow
    {
        const string MENU_ITEM = "Brain+ Job Test/Welcome";
        static readonly string header = "Welcome to the Brain+ C# Job Test.";

        static readonly string[] instructions = new[]
        {
            "We have prepared some small assignments for you, to help us get a sense of your knowledge of Unity.",
            "Do as many of the assignments as you can - simply edit the files directly.",
            "We recommend that you use Git so that you can track your own changes compared to the original code of the assignments.",
            "Here are some shortcuts to the scenes with the assignments:",
        };

        [InitializeOnLoadMethod]
        static void EngineInitialized()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {
                return;
            }

            if (PlayerPrefs_OpenAutomatically)
            {
                EditorApplication.delayCall += OpenWindow;
            }
        }

        static readonly string PlayerPrefs_Seen_Key = typeof(WelcomeWindow).AssemblyQualifiedName + ".OpenAutomatically";

        static bool PlayerPrefs_OpenAutomatically
        {
            get
            {
                return EditorPrefs.GetBool(PlayerPrefs_Seen_Key, true);
            }
            set
            {
                EditorPrefs.SetBool(PlayerPrefs_Seen_Key, value);
            }
        }

        [MenuItem(MENU_ITEM)]
        public static void OpenWindow()
        {
            WelcomeWindow instance = GetWindow<WelcomeWindow>(true, "Welcome", true);
            instance.minSize = new Vector2(400f, 600f);
        }

        Vector2 scrollPosition = Vector2.zero;

        void OnGUI()
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);

            // Header
            GUILayout.Label(header, EditorStyles.boldLabel);
            EditorGUILayout.Separator();

            // Checkbox
            PlayerPrefs_OpenAutomatically = GUILayout.Toggle(PlayerPrefs_OpenAutomatically, " Automatically open this window on domain reload");
            EditorGUILayout.Separator();

            // Instructions
            foreach (string instruction in instructions)
            {
                GUILayout.Label(instruction, EditorStyles.wordWrappedLabel);
                EditorGUILayout.Separator();
            }

            // Scene shortcuts
            IEnumerable<SceneAsset> scenes = AssetDatabase.FindAssets("t:scene")
                .Select(guid => AssetDatabase.GUIDToAssetPath(guid))
                .OrderBy(path => path)
                .Select(path => AssetDatabase.LoadAssetAtPath<SceneAsset>(path));
            foreach (SceneAsset scene in scenes)
            {
                if (GUILayout.Button(scene.name, GUILayout.ExpandWidth(false)))
                {
                    SelectAsset(AssetDatabase.GetAssetPath(scene));
                }
                EditorGUILayout.Separator();
            }

            // Additional instructions
            GUILayout.Label($"This window can also be opened via the menu in the top:\n{MENU_ITEM}", EditorStyles.wordWrappedLabel);
            EditorGUILayout.Separator();
            GUILayout.EndScrollView();
        }

        void SelectAsset(string path)
        {
            if (path[path.Length - 1] == '/')
            {
                path = path.Substring(0, path.Length - 1);
            }

            // Load object
            UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);

            // Select the asset in the project folder
            Selection.activeObject = asset;

            // Also flash the asset yellow to highlight it
            EditorGUIUtility.PingObject(asset);
        }
    }
}
