using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Image healthFill;

    [SerializeField] private float currentHealth = 1000000.0f;
    [SerializeField] private float maxHealth = 1000000.0f;
    [SerializeField] private bool useHSVColor = false;

    public void SetCurrentHealth(float val) => currentHealth = val;
    public float GetCurrentHealth() => currentHealth;

    private void FixedUpdate()
    {
        //healthText.text = currentHealth.ToString();
        healthFill.fillAmount = (float)currentHealth / maxHealth;

        if (useHSVColor)
        {
            float value = GetHSV(currentHealth, maxHealth, 0, 125, 0);
            healthFill.color = Color.HSVToRGB(value / 360, 1.0f, 1.0f);
        }

    }

    private static float GetHSV(float value, float fromSource, float toSource, float fromTarget, float toTarget)
    {
        return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
    }
}