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

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void Start()
        {
            SpawnRandomCounters();
        }

        void SpawnRandomCounters()
        {
            for (int i = 0; i < 100000; i++) // You are not allowed to spawn fewer instances of RandomCounter
            {
                GameObject go = new GameObject(nameof(RandomCounter));
                go.AddComponent<RandomCounter>();
            }
        }
    }
}
