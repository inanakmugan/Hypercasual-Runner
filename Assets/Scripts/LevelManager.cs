using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int level = 1;

    public void IncreaseLevel()
    {
        level++;
    }

    public int GetLevel()
    {
        return level;
    }

    public void ResetLevel()
    {
        level = 1;
    }

    public void RestartGame()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
