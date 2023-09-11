using UnityEngine;

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
}
