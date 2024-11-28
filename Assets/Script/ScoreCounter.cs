using TMPro;
using UnityEngine;

public sealed class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance { get; private set; }

    private int _score;
    private Hero hero; // Reference to the Hero component

    public int Score
    {
        get => _score;

        set
        {
            if (_score == value) return;

            _score = value;
            scoreText.SetText($"Score = {_score}");

            // Notify the hero of the score change (new addition)
            if (hero != null)
            {
                hero.AttackBoss(_score);
            }
        }
    }

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        Instance = this;

        // Find the Hero component in the scene (new addition)
        GameObject heroObject = GameObject.FindGameObjectWithTag("Hero");
        if (heroObject != null)
        {
            hero = heroObject.GetComponent<Hero>();
        }
        else
        {
            Debug.LogError("Hero object with 'Hero' tag not found in the scene.");
        }
    }
}
