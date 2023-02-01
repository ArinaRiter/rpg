using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //patrolling

    //public Vector3 walkPoint;//
    //bool walkPointSet;//
    //public float walkPointRange;//

    //attacking vse dela
    //public float timeBetweenAttacks;//
    //bool alreadyAttacked;//

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform; //player NAMEEEE
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsGround);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsGround);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        //if (playerInSightRange && !playerInAttackRange) ChasePlayer();//
        //if (playerInAttackRange && playerInSightRange) AttackPlayer();//

    }

    public Transform[] points;//
    private int destPoint = 0; //

    private void Patrolling()
    {
        //if (!walkPointSet) SearchWalkPoint();//

        //if (walkPointSet)
        //    agent.SetDestination(walkPoint);

        //Vector3 distanceToWalkPoint = transform.position - walkPoint;

        ////walkpoint reached!!!
        //if (distanceToWalkPoint.magnitude < 1f)
        //    walkPointSet = false;
        agent.autoBraking = false;
        GotoNextPoint();
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();

    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }

    //private void SearchWalkPoint()
    //{
    //    //random point in range
    //    float randomZ = Random.Range(-walkPointRange, walkPointRange);
    //    float randomX = Random.Range(-walkPointRange, walkPointRange);

    //    walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

    //    if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
    //        walkPointSet = true;
    //}

    //private void ChasePlayer()
    //{
    //    agent.SetDestination(player.position);
    //}

    //private void AttackPlayer()
    //{
    //    //enemy doesnt move !!!111!!
    //    agent.SetDestination(transform.position);

    //    transform.rotation = Quaternion.LookRotation(transform.position - player.position);

//        if (!alreadyAttacked)
//        {
//            //attacl code here
//            ////
//            ///
//            alreadyAttacked = true;
//            Invoke(nameof(ResetAttack), timeBetweenAttacks);
//}
//    }

//    private void ResetAttack()
//{
//    alreadyAttacked = false;
//}

}
