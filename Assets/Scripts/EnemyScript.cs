using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    NavMeshAgent navMeshAgent;

    //Animator animator;

    GameObject player;

    Vector3 targetPos;



    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = player.transform.position;
        navMeshAgent.SetDestination(targetPos);
        navMeshAgent.transform.position += transform.forward * Time.deltaTime;
    }
}