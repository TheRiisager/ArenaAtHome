using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerScript : MonoBehaviour
{

    private float currentHealth = 1000000.0f;
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
        //healthDisplay.SetCurrentHealth(healthDisplay.GetCurrentHealth() - damage);
    }


}