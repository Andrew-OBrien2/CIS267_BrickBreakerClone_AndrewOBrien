using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoseLife : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public Rigidbody2D ballRigidBody;
    public TMP_Text livesText;
    public Transform paddleStartPosition;
    public Transform ballStartPosition;
    public GameObject gameOverUI;
    public TMP_Text finalScoreText;
    private ScoreCounter scoreCounter;

    private int lives = 3;

    private void Start()
    {
        UpdateLivesText();
        GameObject Player = GameObject.Find("Paddle");
        playerMovement = Player.GetComponent<PlayerMovement>();

        GameObject gameManager = GameObject.Find("GameManager");
        scoreCounter = gameManager.GetComponent<ScoreCounter>();


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            lives--;
            UpdateLivesText();

            if (lives > 0)
            {
                ResetBallAndPaddle();
            }
            else
            {
                //All game over stuff is here
                gameOverUI.SetActive(true);

                //copy the score from ScoreCounter to the Game Over screen
                float finalScore = scoreCounter.GetCurrentScore();
                finalScoreText.text = "FINAL SCORE: " + finalScore.ToString();

                //freeze time
                Time.timeScale = 0;
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    private void ResetBallAndPaddle()
    {
        //reset paddle position
        playerMovement.transform.position = paddleStartPosition.position;

        //reset ball position
        ballRigidBody.position = ballStartPosition.position;
        ballRigidBody.velocity = Vector2.zero;

        //reset the ball's released state so it only moves when the player moves
        playerMovement.ResetBallState();
    }

    private void UpdateLivesText()
    {
        livesText.text = "LIVES: " + lives;
    }
}