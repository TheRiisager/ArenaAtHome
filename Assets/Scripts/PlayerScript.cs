using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
{

    private float currentHealth = 1000.0f;

    [SerializeField] private HealthDisplay healthDisplay;
    private float maxhealth = 1000.0f;

    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxhealth;
    }


    void Update()
    {
        if (isDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        healthDisplay.SetCurrentHealth(healthDisplay.GetCurrentHealth() - damage);
    }


}