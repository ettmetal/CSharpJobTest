using UnityEditor;

namespace com.brainplus.jobtest.editor
{
    [CustomEditor(typeof(JobTestMonoBehaviour), true)]
    public class JobTestMonoBehaviourEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Job Test Instructions");
            EditorGUILayout.HelpBox(Target.Instructions, MessageType.Info);
            EditorGUILayout.Separator();
            base.OnInspectorGUI();
        }

        JobTestMonoBehaviour Target => target as JobTestMonoBehaviour;
    }
}
