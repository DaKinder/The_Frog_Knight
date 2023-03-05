using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class PatrolEnemy : Enemy
{
    private NavMeshAgent agent;
    [SerializeField] private Transform[] waypoints;
    //private bool delayTime;
    private int index;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[0].position);    
    }

    private void Update()
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            index = (index + 1) % waypoints.Length;
            agent.SetDestination (waypoints[index].position);
        }
    }
}
