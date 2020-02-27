using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.brainplus
{
    public class RandomCounter : MonoBehaviour
    {
        float waitDuration = 1f;
        float lastTime = 0f;

        public int Count { get; private set; } = 0;

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void Awake()
        {
            waitDuration = Random.Range(1f, 10f);
        }

        void Update()
        {
            TickCounter();
        }

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        public void TickCounter()
        {
            float timeNow = Time.timeSinceLevelLoad;
            float delta = timeNow - lastTime;
            if (delta >= waitDuration)
            {
                while (delta >= waitDuration)
                {
                    Count++;
                    delta -= waitDuration;
                }
                lastTime = timeNow;
            }
        }
    }
}
