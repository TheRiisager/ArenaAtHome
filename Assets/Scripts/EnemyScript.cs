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

    private int currentHealth = 100;
    private int maxhealth = 100;

    private bool isDead = false;

    // States
    public float sightRange;
    public bool playerInSightRange;

    // Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //[SerializeField] private HealthDisplay healthDisplay;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        currentHealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange);

        if (!playerInSightRange)
        {
            Patroling();
        }

        if (playerInSightRange)
        {
            ChaseAndAttackPlayer();
        }

        if (isDead)
        {
            Destroy(this.gameObject);
        }

        currentHealth = Mathf.Max(currentHealth, 0);

        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }

    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            navMeshAgent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        // Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f))
        {
            walkPointSet = true;
        }
    }

    public void ChaseAndAttackPlayer()
    {
        targetPos = player.transform.position;
        navMeshAgent.SetDestination(targetPos);
        navMeshAgent.transform.position += transform.forward * Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //healthDisplay.SetCurrentHealth(healthDisplay.GetCurrentHealth() - damage);
    }
}