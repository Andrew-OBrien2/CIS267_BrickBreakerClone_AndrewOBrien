using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
