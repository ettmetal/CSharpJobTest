using System.Collections.Generic;
using UnityEngine;

namespace com.brainplus.jobtest.monobehaviour.scenario2
{
    /// <summary>
    /// Optimize the way we are calling <see cref="RandomCounter.TickCounter"/>. Note that we spawn a lot of instances on purpose
    /// to provoke the performance problem.
    /// Hint: There is a more optimal way to call the <see cref="RandomCounter.TickCounter"/> function this many times each frame.
    /// </summary>
    public class MonoBehaviour_Scenario2 : JobTestMonoBehaviour
    {
        public override string Instructions => "Optimize the way we are calling RandomCounter.TickCounter(). Note that we spawn a lot of instances on purpose to provoke the performance problem. Hint: There is a more optimal way to call the TickCounter function this many times each frame.";

        RandomCounter[] counters = new RandomCounter[100000];

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void Start()
        {
            SpawnRandomCounters();
        }

        // Essentially an 'update manager' - improves call performance but at the expense of checks
        // Unlike magic methods, wont account for inactive, or destroyed instances.
        // Also won't tick RandomCounters created elsewhere.
        // Issues can be improved by having RadomCounter register/deregister itself, but requires a collection like List<T>, removing optimisation of using Arrays
        void Update() {
            for(int i = 0; i < 100000; i++) {
                counters[i].TickCounter(); // if(counters[i].isActiveAndEnabled)  could be used here to make it a bit safer, +~10ms increase in method time / frame
            }
        }

        void SpawnRandomCounters()
        {
            for (int i = 0; i < 100000; i++) // You are not allowed to spawn fewer instances of RandomCounter
            {
                GameObject go = new GameObject(nameof(RandomCounter));
                counters[i] = go.AddComponent<RandomCounter>();
            }
        }
    }
}
