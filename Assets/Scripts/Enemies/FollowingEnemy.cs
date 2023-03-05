using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class FollowingEnemy : Enemy
{
    private NavMeshAgent agent;
    public Transform enemy;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemy = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        agent.SetDestination(enemy.position);
    }
}
