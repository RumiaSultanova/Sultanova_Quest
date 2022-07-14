using UnityEngine;
using UnityEngine.AI;

namespace Quest.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class FollowingEnemy : Enemy
    {
        private NavMeshAgent agent;
        private Transform player;
        
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            player = FindObjectOfType<Quest.Player.PlayerMovement>().transform;
        }

        private void Update()
        {
            agent.SetDestination(player.position);

            if (NavMesh.SamplePosition(agent.transform.position, out NavMeshHit hit, .2f, NavMesh.AllAreas))
            {
                Debug.Log(NavMesh.GetAreaCost((int)Mathf.Log(hit.mask, 2)));
            }
        }
    }
}
