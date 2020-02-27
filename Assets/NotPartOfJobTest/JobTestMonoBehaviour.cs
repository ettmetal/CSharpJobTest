using UnityEngine;

namespace com.brainplus
{
    /// <summary>
    /// Allows for writing job test instructions in the inspector.
    /// </summary>
    public abstract class JobTestMonoBehaviour : MonoBehaviour
    {
        public abstract string Instructions { get; }
    }
}
