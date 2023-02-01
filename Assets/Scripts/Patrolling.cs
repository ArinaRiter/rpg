using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;

    private bool alreadyAttacked;

    [SerializeField]
    private float health;
    private float damage;

    public PlayerStats playerStats;

    public Transform player;

    //private float distance;
    //distance = Vector3.Distance(Enemy.transform.position, player.transform.position);

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        //4 continuous movement

        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // returns if no points have been set up
        if (points.Length == 0)
            return;

        //agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // choose the next point in the array as the destinatio
        //cycle to the start if net pointov
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        // choose the next destination point
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();

        //if (distance < 10f && distance>2f)
        //{
        //    agent.SetDestination(player.position);
        //    transform.rotation = Quaternion.LookRotation(transform.position - player.position);
        //}
        //if (distance<2f)
        //{
        //    AttackPlayer();
        //}
    }

    //[SerializeField]
    //private float timeBetweenAttacks;
    //private void AttackPlayer()
    //{
    //    agent.SetDestination(player.position);
    //    transform.rotation = Quaternion.LookRotation(transform.position - player.position);
    //    if (!alreadyAttacked)
    //    {
    //        playerStats.curHP -= 1;
    //        alreadyAttacked = true;
    //        Invoke(nameof(ResetAttack), timeBetweenAttacks);
    //    }
    //}

    //private void ResetAttack()
    //{
    //    alreadyAttacked = false;
    //}

    //private void TakeDamage()
    //{
    //    health -= damage;
    //}
}
