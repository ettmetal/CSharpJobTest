using System.Collections;
using UnityEngine;

namespace com.brainplus.jobtest
{
    /// <summary>
    /// Change <see cref="MultipleCoroutinesInParallel"/> so that it calls <see cref="Finish"/>
    /// after the 3 <see cref="RandomDuration"/> coroutines end.
    /// </summary>
    public class Coroutines_Scenario3 : MonoBehaviour
    {
        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void Start()
        {
            StartCoroutine(MultipleCoroutinesInParallel());
        }

        IEnumerator MultipleCoroutinesInParallel()
        {
            // Start the 3 coroutines in parallel simultaneously
            // You are not allowed to remove the for loop
            for (int i = 0; i < 3; i++)
            {
                StartCoroutine(RandomDuration());
            }

            Finish(); // TODO: Call when all 3 coroutines have ended

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

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void Finish()
        {
            Debug.Log($"Finish: {this.name}");
        }
    }
}
