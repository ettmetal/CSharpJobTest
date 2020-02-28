using System.Collections.Generic;
using UnityEngine;

namespace com.brainplus.jobtest.unityui.dynamicscrollviewlist
{
    /// <summary>
    /// You are not allowed to change this class.
    /// </summary>
    public class DynamicList : MonoBehaviour
    {
        public List<GameObject> prefabs = new List<GameObject>();

        public int instancesToSpawn = 4;

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void Start()
        {
            DeleteAllChildren();
            SpawnRandomPrefabs();
        }

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void DeleteAllChildren()
        {
            foreach(Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void SpawnRandomPrefabs()
        {
            for (int i = 0; i < instancesToSpawn; i++)
            {
                int prefabIndex = i % prefabs.Count;
                GameObject prefab = prefabs[prefabIndex];
                Instantiate(prefab, transform, false);
            }
        }
    }
}
