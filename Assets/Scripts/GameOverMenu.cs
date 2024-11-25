using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        //unfreeze time for playing again
        Time.timeScale = 1;
        int randomLevel = Random.Range(1, 3);

        if (randomLevel == 1)
        {
            SceneManager.LoadScene("Level01");
        }
        else
        {
            SceneManager.LoadScene("Level02");
        }
    }

    public void ExitToMenu()
    {
        //unfreeze time for playing again
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu Screen");
    }
}
