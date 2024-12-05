using TMPro;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f; // Maximum health of the boss (adjustable in the Inspector)
    private float currentHealth; // Current health of the boss

    public TextMeshProUGUI BossHealthTet;  // TextMeshPro component for displaying boss health

    private void Awake()
    {
        if (maxHealth <= 0)
        {
            Debug.LogWarning("Max Health is set to 0 or less. Defaulting to 100.");
            maxHealth = 100f; // Default to 100 if an invalid value is set
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateBossHealthUI();  // Update the health display
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateBossHealthUI();
    }

    // Add ResetHealth method to reset the boss's health
    public void ResetHealth()
    {
        currentHealth = maxHealth; // Reset health to maximum
        UpdateBossHealthUI(); // Update the UI after resetting
    }

    private void UpdateBossHealthUI()
    {
        if (BossHealthTet != null)
        {
            BossHealthTet.text = $"Boss Health: {currentHealth}";
        }
        else
        {
            Debug.LogWarning("Boss Health Text is not assigned! Please assign it in the Inspector.");
        }
    }

    public void SetMaxHealth(float health)
    {
        maxHealth = health;
        currentHealth = maxHealth;
        UpdateBossHealthUI(); // Update UI after setting new max health
    }
}
