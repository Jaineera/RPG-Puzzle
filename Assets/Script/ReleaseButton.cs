using UnityEngine;
using UnityEngine.UI;

public class ReleaseButton : MonoBehaviour
{
    public Button releaseButton; // Reference to the button

    private void Start()
    {
        // Check if the button is assigned
        if (releaseButton == null)
        {
            Debug.LogError("Release Button is not assigned in the Inspector!");
            return;
        }

        // Add listener to handle button clicks
        releaseButton.onClick.AddListener(OnReleaseButtonClick);
    }

    // Handle the button click
    private void OnReleaseButtonClick()
    {
        // Trigger the ReleaseAttack method in ScoreCounter
        if (ScoreCounter.Instance != null)
        {
            ScoreCounter.Instance.ReleaseAttack();
        }
        else
        {
            Debug.LogError("ScoreCounter.Instance is not set. Make sure ScoreCounter is in the scene.");
        }
    }
}
