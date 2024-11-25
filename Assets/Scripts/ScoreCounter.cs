using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private float curScore;
    public TMP_Text guiScore;
    public int score = 0;

    void Start()
    {
        UpdateScoreDisplay();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        guiScore.text = "SCORE: " + score.ToString();
    }

    //Get the score to update the GameOver score
    public float GetCurrentScore()
    {
        return curScore;
    }
}
