using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //pratroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public Vector3 target;

    //states
    public float sightRange;
    public bool playerInSightRange;

    private void Awake()
    {
        player = GameObject.Find("Player (1)").transform;
        agent = GetComponent<NavMeshAgent>();
        target = new Vector3(player.position.x, transform.position.y, player.position.z);
    }

    private void Patroling()
    {
        if (!walkPointSet) { SearchWalkPoint(); }
        if (walkPointSet) { agent.SetDestination(walkPoint); }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f) { walkPointSet = false; }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

        transform.LookAt(target);
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if (!playerInSightRange) Patroling();
        if (playerInSightRange) ChasePlayer();
    }
}
