using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    public void LoadEasyLevel()
    {
        SceneManager.LoadScene("GamePlaySceneE");
    }

    public void LoadMediumLevel()
    {
        SceneManager.LoadScene("GamePlaySceneM");
    }

    public void LoadHardLevel()
    {
        SceneManager.LoadScene("GamePlaySceneH");
    }
}
