using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerScript : MonoBehaviour
{

    private float currentHealth = 1000.0f;

    [SerializeField] private HealthDisplay healthDisplay;
    private int maxhealth = 100;

    private bool isDead = false;


    void Update()
    {
        if (isDead)
        {
            Debug.Log("dead");
            Destroy(this.gameObject);
        }

        currentHealth = Mathf.Max(currentHealth, 0);

        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        healthDisplay.SetCurrentHealth(healthDisplay.GetCurrentHealth() - damage);
    }


}