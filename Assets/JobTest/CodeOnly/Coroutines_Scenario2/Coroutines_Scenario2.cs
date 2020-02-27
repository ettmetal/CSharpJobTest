using System.Collections;
using UnityEngine;

namespace com.brainplus.jobtest.coroutines.scenario2
{
    /// <summary>
    /// Change <see cref="MultipleCoroutinesInSequence"/> so that it starts the 3 
    /// <see cref="RandomDuration"/> coroutines sequentially (only 1 of the 3 runs at any point in time).
    /// </summary>
    public class Coroutines_Scenario2 : JobTestMonoBehaviour
    {
        public override string Instructions => "Change MultipleCoroutinesInSequence so that it starts the 3 RandomDuration coroutines sequentially (only 1 of the 3 runs at any point in time).";

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void Start()
        {
            StartCoroutine(MultipleCoroutinesInSequence());
        }

        IEnumerator MultipleCoroutinesInSequence()
        {
            // TODO: Start the 3 coroutines sequentially
            // You are not allowed to remove the for loop
            for (int i = 0; i < 3; i++)
            {
                StartCoroutine(RandomDuration()); // TODO: Dont start next coroutine until this one ends
            }

            yield break; // REMOVE ME: This line is only here to make the incomplete code compile
        }

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        IEnumerator RandomDuration()
        {
            float duration = Random.Range(0f, 2f);
            yield return new WaitForSeconds(duration);
            Debug.Log($"Waited: {duration} sec in {nameof(RandomDuration)}");
        }
    }
}
