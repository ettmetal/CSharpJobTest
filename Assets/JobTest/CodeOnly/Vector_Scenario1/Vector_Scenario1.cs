using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.brainplus.jobtest
{
    /// <summary>
    /// Optimize the distance check for finding points close to the center in the <see cref="CountPositionsCloseToCenter"/> function.
    /// Hint: A faster operation for calculating distance is available. You likely only need to change line 60.
    /// </summary>
    public class Vector_Scenario1 : JobTestMonoBehaviour
    {
        public override string Instructions => "Optimize the distance check for finding points close to the center in the CountPositionsCloseToCenter function. Hint: A faster operation for calculating distance is available. You likely only need to change line 60.";

        /// <summary>
        /// You are not allowed to change this field.
        /// </summary>
        List<Vector3> positions = new List<Vector3>();

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void Start()
        {
            GenerateRandomPositions();
        }

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void Update()
        {
            CountPositionsCloseToCenter(3f);
        }

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void GenerateRandomPositions()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Vector3 position = new Vector3(
                    Random.Range(-100f, 100f),
                    Random.Range(-100f, 100f),
                    Random.Range(-100f, 100f)
                );
                positions.Add(position);
            }
        }

        void CountPositionsCloseToCenter(float distanceThreshold)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew(); // Necessary to calculate execution time
            Vector3 center = Vector3.zero; // Optimization: Cache to avoid property accessor
            int countTotal = positions.Count; // Optimization: Cache to heap to avoid property accessor

            int countClose = 0;
            for (int i = 0; i < countTotal; i++)
            {
                // Check if close to center
                if (Vector3.Distance(center, positions[i]) <= distanceThreshold) // TODO: Optimize distance check
                {
                    countClose++;
                }
            }
            stopwatch.Stop(); // Necessary to calculate execution time
            Debug.Log($"Found {countClose} positions close to the center out of {countTotal} total in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
