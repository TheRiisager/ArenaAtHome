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

    //[SerializeField] private HealthDisplay healthDisplay;

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

         if (isDead) {
             Debug.Log("dead");
            Destroy(this.gameObject);
         } 

        currentHealth = Mathf.Max(currentHealth, 0);

        if (currentHealth <= 0) {
            isDead = true;
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("thats alot of damage");
        currentHealth -= damage;
        //healthDisplay.SetCurrentHealth(healthDisplay.GetCurrentHealth() - damage);
    }
}