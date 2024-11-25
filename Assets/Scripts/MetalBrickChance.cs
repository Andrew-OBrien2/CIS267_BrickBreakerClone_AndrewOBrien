using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBrickChance : MonoBehaviour
{
    public Sprite[] healthSprites;
    public Sprite metalSprite;
    private int currentHealth;
    private SpriteRenderer spriteRenderer;
    public int pointsPerBrick = 10;
    private ScoreCounter scoreCounter;
    public GameObject[] powerUpPrefabs;
    //20% chance to spawn power up
    public float powerUpChance = 0.2f;
    private GameObject gameManager;
    private bool isMetalBrick = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        //50% chance to be a metal brick
        if (Random.value <= 0.5f)
        {
            MakeMetalBrick();
        }
        else
        {
            currentHealth = Random.Range(1, 4);
            UpdateSprite();
            gameManager = GameObject.Find("GameManager");
            scoreCounter = gameManager.GetComponent<ScoreCounter>();
            gameManager.GetComponent<GameManager>().IncrementBrickCount();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
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
                scoreCounter.AddScore(pointsPerBrick);
                DestroyBrick();
            }
        }
    }

    private void DestroyBrick()
    {
        if (!isMetalBrick && Random.value <= powerUpChance)
        {
            SpawnRandomPowerUp();
        }

        if (!isMetalBrick)
        {
            gameManager.GetComponent<GameManager>().DecreaseBrickCount();
            Destroy(gameObject);
        }
    }

    private void SpawnRandomPowerUp()
    {
        int randomIndex = Random.Range(0, powerUpPrefabs.Length);
        Instantiate(powerUpPrefabs[randomIndex], transform.position, Quaternion.identity);
    }

    private void UpdateSprite()
    {
        // Set sprite based on current health for normal bricks
        if (!isMetalBrick && currentHealth > 0 && currentHealth <= healthSprites.Length)
        {
            spriteRenderer.sprite = healthSprites[currentHealth - 1];
        }
    }

    private void MakeMetalBrick()
    {
        isMetalBrick = true;
        spriteRenderer.sprite = metalSprite;
        //disable the whole script to make sure nothing happens with this brick anymore
        this.enabled = false;
    }
}
