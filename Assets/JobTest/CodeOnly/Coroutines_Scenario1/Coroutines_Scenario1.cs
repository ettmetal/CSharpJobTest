using System.Collections;
using UnityEngine;

namespace com.brainplus.jobtest.coroutines.scenario1
{
    /// <summary>
    /// Using a coroutine, call <see cref="Finish"/> after 3 seconds using <see cref="WaitForSeconds"/>.
    /// You are not allowed to use the <see cref="Time"/> or <see cref="System.DateTime"/> classes.
    /// </summary>
    public class Coroutines_Scenario1 : JobTestMonoBehaviour
    {
        public override string Instructions => "Using a coroutine, call Finish after 3 seconds using WaitForSeconds. You are not allowed to use the Time or DateTime classes.";

        void Start()
        {
            StartCoroutine(DelayedFinish(3f)); // It'd be cleaner to use a member to avoid magic numbers, it can also make the delay configurable
        }

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void Finish()
        {
            Debug.Log($"Finish: {this.name}");
        }

        // Encapsulate the Finish() call into a coroutine which delays for a given number of seconds.
        IEnumerator DelayedFinish(float delay) {
            yield return new WaitForSeconds(delay); // Could be WaitForSecondsRealtime to avoid scaling, if needed
            Finish();
        }

        // If this was a general need across a project, I'd probably propose somthing like this instead:
        IEnumerator DelayedCall(float delay, System.Action call) {
            yield return new WaitForSeconds(delay); // Again, this parameter could be refactored to be a member, making it configurable
            call?.Invoke();
        }
        // Usage: StartCoroutine(DelayedCall(3f, Finish));
    }
}
