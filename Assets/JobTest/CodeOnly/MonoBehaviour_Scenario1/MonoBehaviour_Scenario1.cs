using UnityEngine;

namespace com.brainplus.jobtest
{
    /// <summary>
    /// Fix the <see cref="System.NullReferenceException"/> that occurs in <see cref="SpawnPlayer"/> without
    /// changing the <see cref="SpawnPlayer"/> function.
    /// </summary>
    
    public class MonoBehaviour_Scenario1 : JobTestMonoBehaviour
    {
        public override string Instructions => "Fix the NullReferenceException that occurs in SpawnPlayer without changing the SpawnPlayer function.";

        public Player playerPrefab;

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void Start()
        {
            SpawnPlayer();
        }

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void SpawnPlayer()
        {
            Player player = Instantiate(playerPrefab); // Hint: It is caused by a call order issue, related to the instantiation of the Player.
            Debug.Log($"Spawned player with items: {player.Inventory.Items}"); // TODO: Fix NullReferenceException from accessing Items on the Inventory
        }
    }
}
