using UnityEngine;
using UnityEngine.UI; // Required for UI Button
using TMPro; // Required for TextMeshPro

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance; // Singleton instance for global access
    public Boss boss; // Reference to the Boss script
    private int score; // Current score accumulated

    public Button releaseButton; // Reference to the UI Button that triggers the attack
    public TextMeshProUGUI chargedAttackText; // Reference to the UI TextMeshPro for charged attack display

    private const int chargeThreshold = 250; // Score threshold to enable the button

    private void Awake()
    {
        // Singleton pattern setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Ensure the Boss reference is assigned
        if (boss == null)
        {
            boss = FindObjectOfType<Boss>();
        }

        // Add listener to handle the button click if it's assigned
        if (releaseButton != null)
        {
            releaseButton.onClick.AddListener(OnReleaseButtonClicked);
        }
        else
        {
            Debug.LogWarning("Release Button is not assigned in ScoreCounter!");
        }

        // Ensure that the release button is disabled initially
        if (releaseButton != null)
        {
            releaseButton.interactable = false; // Disable the button at the start
        }
    }

    // Method to increment the score
    public void AddScore(int amount)
    {
        score += amount; // Increase the score by the given amount
        UpdateScoreUI(); // Update the score display (if you have a UI element for the score)

        // Update the Charged Attack UI text
        if (chargedAttackText != null)
        {
            chargedAttackText.text = $"Charged Attack: {score}/{chargeThreshold}";
        }

        // Enable or disable the release button based on score
        if (score >= chargeThreshold)
        {
            if (releaseButton != null)
            {
                releaseButton.interactable = true; // Enable the button if score is above 250
            }
        }
        else
        {
            if (releaseButton != null)
            {
                releaseButton.interactable = false; // Disable the button if score is below 250
            }
        }
    }

    // Method triggered when the release button is clicked
    private void OnReleaseButtonClicked()
    {
        ReleaseAttack(); // Trigger the attack when the button is pressed
        DisableButton(); // Disable the button until score reaches 250 again
        ResetChargeText(); // Reset the charge display to 0/250
    }

    // Method triggered by the release button to apply score damage to the boss
    public void ReleaseAttack()
    {
        if (boss != null)
        {
            boss.TakeDamage(score); // Transfer the score as damage to the boss
            ResetScore(); // Reset the score after transferring
        }
        else
        {
            Debug.LogWarning("Boss reference is not assigned in ScoreCounter!");
        }
    }

    // Method to reset the score to zero
    private void ResetScore()
    {
        score = 0; // Reset the score to 0
        UpdateScoreUI(); // Update the UI display for score (if needed)
    }

    // Disable the button after it is pressed
    private void DisableButton()
    {
        if (releaseButton != null)
        {
            releaseButton.interactable = false; // Disable the button until score reaches 250 again
        }
    }

    // Reset the charge display text to 0/250
    private void ResetChargeText()
    {
        if (chargedAttackText != null)
        {
            chargedAttackText.text = $"Charged Attack: 0/{chargeThreshold}"; // Reset to 0/250
        }
    }

    // Optionally, update score UI (you can implement this based on your UI system)
    private void UpdateScoreUI()
    {
        // Example: If you have a UI Text for the score, you can update it here
        // scoreText.text = $"Score: {score}";
    }

    // Method to reset all game values (score, boss health, etc.)
    public void ResetGameValues()
    {
        ResetScore(); // Reset the score
        if (boss != null)
        {
            boss.ResetHealth(); // Reset boss health if the boss is assigned
        }
        // You can add other game reset logic here if necessary
    }
}
