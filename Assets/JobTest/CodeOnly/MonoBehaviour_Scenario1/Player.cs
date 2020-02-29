using UnityEngine;

namespace com.brainplus.jobtest.monobehaviour.scenario1
{
    [RequireComponent(typeof(Inventory))]
    public class Player : MonoBehaviour
    {
        /// <summary>
        /// You are not allowed to change this property.
        /// </summary>
        public Inventory Inventory { get; private set; }

        void Awake() // Awake can safely be used for setting up references to components atached to the same GameObject
        {
            CacheComponentReferences();
        }
        // This is preferred to setting script execution order, as it requires less maintenance

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void CacheComponentReferences()
        {
            Inventory = GetComponent<Inventory>();
        }
    }
}
