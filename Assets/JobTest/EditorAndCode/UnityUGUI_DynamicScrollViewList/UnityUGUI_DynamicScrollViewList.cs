namespace com.brainplus.jobtest.unityui.dynamicscrollviewlist
{
    /// <summary>
    /// Your task is to ensure that the dynamic list of UI elements works properly at runtime.
    /// This assignment should be solved without writing any code, using only built-in Unity UI components.
    /// 
    /// The intended solution involves changing the gameobject hierarchy in the scene and adding UI components (on or between the Canvas and DynamicList gameobjects).
    /// Note that instances are spawned at runtime, and some instances randomly resize themselves at runtime.
    /// You are not allowed to change the 2 prefabs that get spawned (ConstantSizeListElement and RandomSizeListElement).
    /// 
    /// Success criterea:
    /// The UI works properly for multiple aspect ratios (landscape 16:9 + 4:3 vs portrait 9:16 + 3:4).
    /// The UI works properly for different resolutions (eg. 1920x1080 vs 800x450).
    /// The UI should be scrollable (since the content will go out of the screen on some aspect ratios).
    /// </summary>
    public class UnityUGUI_DynamicScrollViewList : JobTestMonoBehaviour
    {
        public override string Instructions =>
            "Your task is to ensure that the dynamic list of UI elements works properly at runtime.\n" +
            "This assignment should be solved without writing any code, using only built-in Unity UI components.\n" +
            "\n" +
            "The intended solution involves changing the gameobject hierarchy in the scene and adding UI components (on or between the Canvas and DynamicList gameobjects).\n" +
            "Note that instances are spawned at runtime, and some instances randomly resize themselves at runtime.\n" +
            "You are not allowed to change the 2 prefabs that get spawned (ConstantSizeListElement and RandomSizeListElement)..\n" +
            "\n" +
            "Success criterea:\n" +
            "The UI works properly for multiple aspect ratios (landscape 16:9 + 4:3 vs portrait 9:16 + 3:4).\n" +
            "The UI works properly for different resolutions (eg. 1920x1080 vs 800x450).\n" +
            "The UI should be scrollable (since the content will go out of the screen on some aspect ratios).\n";
    }
}
