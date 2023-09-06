using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int level = 1;

    private void Awake()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();

        if (levelManager == null)
        {
            levelManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
