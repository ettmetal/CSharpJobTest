using System.Collections;
using UnityEngine;

namespace com.brainplus.jobtest.coroutines.scenario3
{
    /// <summary>
    /// Change <see cref="MultipleCoroutinesInParallel"/> so that it calls <see cref="Finish"/>
    /// after the 3 <see cref="RandomDuration"/> coroutines end.
    /// </summary>
    public class Coroutines_Scenario3 : JobTestMonoBehaviour
    {
        public override string Instructions => "Change MultipleCoroutinesInParallel so that it calls Finish after the 3 RandomDuration coroutines end.";

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void Start()
        {
            StartCoroutine(MultipleCoroutinesInParallel());
        }

        IEnumerator MultipleCoroutinesInParallel()
        {
            int coroutineCount = 3; // Hoist the magic number
            Coroutine[] routines = new Coroutine[coroutineCount];
            // Start the 3 coroutines in parallel simultaneously
            // You are not allowed to remove the for loop
            for (int i = 0; i < coroutineCount; i++)
            {
                routines[i] = StartCoroutine(RandomDuration());
            }
            foreach(Coroutine routine in routines) yield return routine; // Move the yield return of the coroutine so that the all get started in parallel
            Finish();
        }

        // An alternative that uses a callback approach, perhaps more scabalble at the expense of using anonymous functions
        IEnumerator MultipleCoroutinesInParallelAlt(int coroutinesToSpawn) {
            int completeCount = 0;
            System.Action coroutineCompleteAction = () => completeCount++;
            for(int i = 0; i < coroutinesToSpawn; i++) {
                StartCoroutine(CoroutineCompletionWrapper(RandomDuration, coroutineCompleteAction));
            }
            yield return new WaitUntil(() => completeCount == coroutinesToSpawn);
            Finish();
        }

        // Helper function for MultipleCoroutinesInParallelAlt to create a coroutine that will callback when finished
        IEnumerator CoroutineCompletionWrapper(System.Func<IEnumerator> routineCreator, System.Action callback) {
            yield return routineCreator?.Invoke();
            callback?.Invoke();
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
