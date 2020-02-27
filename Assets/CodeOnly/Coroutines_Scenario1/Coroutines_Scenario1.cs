using System.Collections;
using UnityEngine;

namespace com.brainplus.jobtest
{
    /// <summary>
    /// Using a coroutine, call <see cref="Finish"/> after 3 seconds using <see cref="WaitForSeconds"/>.
    /// You are not allowed to use the <see cref="Time"/> or <see cref="System.DateTime"/>.
    /// </summary>
    public class Coroutines_Scenario1 : MonoBehaviour
    {
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
