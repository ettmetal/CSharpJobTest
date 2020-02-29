using UnityEngine;
using UnityEngine.Serialization;

namespace com.brainplus.jobtest.serialization.scenario1
{
    public class Health : MonoBehaviour
    {
        // I'd normally use [SerializeField] with a private field, but other classes need read access
        // Using [field: SerializeField] is nice and automatic, but the inspector isn't as easy to read and the default can't be applied in code
        [SerializeField, FormerlySerializedAs("maxHealth")] // Add FormerlySerializedAs to prevent breaking current assets
        private int _maxHealth = 100; // Unity strips leading underscores in the inspector - I don't like the convention, but it's handy here.
        public int maxHealth => _maxHealth;
        public int currentHealth {get; private set;}

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void Awake()
        {
            // Start with max health
            currentHealth = maxHealth;
        }

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        public void TakeDamage(int damage)
        {
            // Subtract damage from health, ensuring we cant go below 0
            currentHealth = Mathf.Max(0, currentHealth - damage);
        }

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        public bool IsDead
        {
            get
            {
                return currentHealth <= 0;
            }
        }
    }
}
