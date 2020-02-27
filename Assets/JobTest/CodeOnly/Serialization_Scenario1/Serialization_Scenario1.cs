using UnityEngine;

namespace com.brainplus.jobtest.serialization.scenario1
{
    /// <summary>
    /// Change the <see cref="Health"/> class, so that its important internal variables cannot be
    /// changed directly from the outside, but instead must use the <see cref="Health.TakeDamage(int)"/> function.
    /// </summary>
    public class Serialization_Scenario1 : JobTestMonoBehaviour
    {
        public override string Instructions => "Change the Health class, so that its important internal variables cannot be changed directly from the outside, but instead must use the Health.TakeDamage(int) function.";

        public Health health;

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void Start()
        {
            KillPlayer();
        }

        void KillPlayer()
        {
            health.currentHealth = 0; // TODO: Prevent changing currentHealth like this
            health.TakeDamage(health.currentHealth); // TODO: But allow reading currentHealth like this
        }
    }
}
