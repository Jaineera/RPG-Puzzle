using UnityEngine;
using TMPro; // For Health UI updates
using UnityEngine.SceneManagement; // For scene transitions

public class Hero : MonoBehaviour
{
    public GameObject gameOverPanel; // Game Over panel (Assign in Inspector for GamePlayScene)
    public GameObject gameOptionsPanel; // Game Options panel (Reset/Exit buttons for GamePlayScene)
    public TextMeshProUGUI healthDecayText; // Health UI TextMeshPro object
    public int maxHealth = 100; // Maximum hero health
    public float healthDecaySpeed = 1.0f; // Speed at which health decays

    private int currentHealth; // Current health of the hero
    private float healthTimer; // Timer to control the decay rate

    public ScoreCounter scoreCounter; // Reference to ScoreCounter script
    public Boss boss; // Reference to Boss script

    private string[] validScenes = { "GamePlayScene", "GamePlaySceneE", "GamePlaySceneM", "GamePlaySceneH" };

    void Start()
    {
        // Check if we're in any of the valid "GamePlayScene" types
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (System.Array.Exists(validScenes, scene => scene == currentSceneName))
        {
            gameOverPanel.SetActive(false); // Hide Game Over UI initially
            gameOptionsPanel.SetActive(false); // Hide Game Options panel initially
            currentHealth = maxHealth; // Initialize health to maxHealth
            UpdateHealthUI(); // Update Health UI

            // Find the ScoreCounter and Boss if not assigned
            if (scoreCounter == null)
            {
                scoreCounter = FindObjectOfType<ScoreCounter>();
            }

            if (boss == null)
            {
                boss = FindObjectOfType<Boss>();
            }
        }
    }

    void Update()
    {
        // Decay health only if the current health is greater than 0
        if (currentHealth > 0)
        {
            healthTimer += Time.deltaTime; // Add time elapsed to the timer

            if (healthTimer >= healthDecaySpeed) // Once the timer exceeds the decay speed, decay health
            {
                healthTimer = 0f; // Reset the timer
                DecayHealth(); // Decay health by 1
            }
        }
    }

    public void TriggerGameOver()
    {
        // Show Game Over and Game Options panels, then pause the game
        gameOverPanel.SetActive(true);
        gameOptionsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DecayHealth()
    {
        // Decrease health by 1, but ensure it doesn't go below 0
        currentHealth = Mathf.Max(0, currentHealth - 1); // Use Mathf.Max to ensure health doesn't go below 0
        UpdateHealthUI(); // Update the health UI display

        if (currentHealth <= 0)
        {
            TriggerGameOver(); // Trigger the Game Over screen if health reaches 0
        }
    }

    public void ResetGame()
    {
        if (System.Array.Exists(validScenes, scene => scene == SceneManager.GetActiveScene().name))
        {
            Time.timeScale = 1f; // Unpause the game
            currentHealth = maxHealth; // Reset hero health to maxHealth
            UpdateHealthUI(); // Update health UI
            gameOverPanel.SetActive(false); // Hide Game Over UI
            gameOptionsPanel.SetActive(false); // Hide Game Options panel

            if (scoreCounter != null)
            {
                scoreCounter.ResetGameValues();
            }

            if (boss != null)
            {
                boss.ResetHealth();
            }

            // Reload current scene to reset all objects
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Ensure the game is unpaused
        SceneManager.LoadScene("MainMenuScene"); // Load the Main Menu scene
    }

    private void UpdateHealthUI()
    {
        // Update the health UI TextMeshPro with the current health value
        if (healthDecayText != null)
        {
            healthDecayText.text = $"Health: {currentHealth}"; // Display current health
        }
    }
}
