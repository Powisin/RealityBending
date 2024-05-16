using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemieMoveRandom : MonoBehaviour
{

    GameObject player;
    NavMeshAgent agent;

    [Header("PATROL")]
    [SerializeField] LayerMask groundLayer, playerLayer;
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float range;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (!walkpointSet) SearchForDest();
        if (walkpointSet) agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 10) walkpointSet = false;
    }

    void SearchForDest()
    {
        float Z = Random.Range(-range,range);
        float X = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + X, 5, transform.position.z + Z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }
}


