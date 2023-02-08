using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol2Behaviour : StateMachineBehaviour
{
    private float timer;
    List<Transform> Walkpoints = new List<Transform>();
    NavMeshAgent agent;
    Transform player;
    float ChaseRange = 10;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform pointsObjects = GameObject.FindGameObjectWithTag("WalkPoint").transform;
        foreach (Transform t in pointsObjects)
        {
            Walkpoints.Add(t);
        }
        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(Walkpoints[0].position);
        player = GameObject.FindGameObjectWithTag("player").transform;

    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(Walkpoints[Random.Range(0, Walkpoints.Count)].position);
        }
        timer += Time.deltaTime;
        if (timer > 10)
        {
            animator.SetBool("isPatrolling", false);
        }
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < ChaseRange)
        {
            animator.SetBool("isChasing", true);

        }

    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
