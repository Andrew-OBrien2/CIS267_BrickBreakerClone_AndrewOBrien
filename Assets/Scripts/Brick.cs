using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public Sprite[] healthSprites;
    private int currentHealth;
    private SpriteRenderer spriteRenderer;
    public int pointsPerBrick = 10;
    private ScoreCounter scoreCounter;
    public GameObject[] powerUpPrefabs;
    //20% chance for power up to spawn
    public float powerUpChance = 0.2f;
    private GameObject gameManager;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        //up to, not including
        currentHealth = Random.Range(1, 4);

        // Set initial sprite based on health
        UpdateSprite();
        gameManager = GameObject.Find("GameManager");
        scoreCounter = gameManager.GetComponent<ScoreCounter>();
        gameManager.GetComponent<GameManager>().IncrementBrickCount();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            //get ball damage ammount
            int ballDamage = collision.gameObject.GetComponent<BallCollision>().damage;

            if (ballDamage == 2)
            {
                pointsPerBrick = 20;
            }
            else if (ballDamage == 1)
            {
                pointsPerBrick = 10;
            }

            currentHealth -= ballDamage;

            if (currentHealth > 0)
            {
                UpdateSprite();

                scoreCounter.AddScore(pointsPerBrick);
            }
            else
            {
                //add points, destroy the brick, and spawn power up
                scoreCounter.AddScore(pointsPerBrick);
                DestroyBrick();
            }
        }
    }

    private void DestroyBrick()
    {
        //randomly spawn power up. Random.value returns a float value between 0 and 1.
        if (Random.value <= powerUpChance)
        {
            SpawnRandomPowerUp();
        }
        gameManager.GetComponent<GameManager>().DecreaseBrickCount();
        Destroy(gameObject);
    }

    private void SpawnRandomPowerUp()
    {
        //randomly pick a power up from the array
        int randomIndex = Random.Range(0, powerUpPrefabs.Length);

        //spawn the selected power-up at the brick's position
        Instantiate(powerUpPrefabs[randomIndex], transform.position, Quaternion.identity);
    }

    private void UpdateSprite()
    {
        //set sprite based on current health
        if (currentHealth > 0 && currentHealth <= healthSprites.Length)
        {
            spriteRenderer.sprite = healthSprites[currentHealth - 1];
        }
    }
}
