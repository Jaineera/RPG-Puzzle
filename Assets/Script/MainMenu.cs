using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject levelSelectPanel; // Assign LevelSelectPanel in the Inspector

    public void ShowLevelSelectPanel()
    {
        levelSelectPanel.SetActive(true); // Activate LevelSelectPanel
    }

    public void HideLevelSelectPanel()
    {
        levelSelectPanel.SetActive(false); // Deactivate LevelSelectPanel
    }
}
