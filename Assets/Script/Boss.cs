using UnityEngine;
using TMPro;  // Import the TextMeshPro namespace

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 10000;  // The max health of the Boss
    private int currentHealth;

    public TextMeshProUGUI healthText;  // Reference to the TextMeshPro UI element for health display

    void Start()
    {
        currentHealth = maxHealth;  // Initialize Boss health to max
        UpdateHealthText();  // Display initial health
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Prevent health from going below 0
        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthText();  // Update the health UI text after taking damage

        if (currentHealth <= 0)
        {
            Debug.Log("Boss defeated!");
            // Additional logic for when the Boss is defeated, e.g., triggering an animation or game event
        }
    }

    // Updates the health text on the UI
    private void UpdateHealthText()
    {
        // Update the HealthText UI element with the current health of the Boss
        healthText.SetText($"Boss Health: {currentHealth}");
    }
}
