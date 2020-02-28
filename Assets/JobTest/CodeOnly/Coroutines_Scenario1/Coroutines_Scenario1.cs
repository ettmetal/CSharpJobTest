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
            Finish(); // TODO: Call after 3 second delay
        }

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void Finish()
        {
            Debug.Log($"Finish: {this.name}");
        }
    }
}
