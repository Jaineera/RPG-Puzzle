using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Hero hero;            // Assign the Hero object
    public ScoreCounter scoreCounter;  // Assign the ScoreCounter object

    private void Start()
    {
        // Initialize any components or variables here if needed
        if (scoreCounter != null && hero != null)
        {
            // Add an initial score if needed (0 in this case)
            scoreCounter.AddScore(0); // Correct method
        }
    }
}
