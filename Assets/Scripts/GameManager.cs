using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int brickCount = 0;

    public void IncrementBrickCount()
    {
        brickCount++;
    }

    public void DecreaseBrickCount()
    {
        brickCount--;

        if (brickCount <= 0)
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        string currentLevel = SceneManager.GetActiveScene().name;

        string nextLevel;
        if (currentLevel == "Level01")
        {
            nextLevel = "Level02";
        }
        else
        {
            nextLevel = "Level01";
        }

        SceneManager.LoadScene(nextLevel);
    }
}
