using UnityEngine;

namespace com.brainplus.jobtest
{
    [RequireComponent(typeof(Inventory))]
    public class Player : MonoBehaviour
    {
        /// <summary>
        /// You are not allowed to change this property.
        /// </summary>
        public Inventory Inventory { get; private set; }

        void Start()
        {
            CacheComponentReferences();
        }

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void CacheComponentReferences()
        {
            Inventory = GetComponent<Inventory>();
        }
    }
}
