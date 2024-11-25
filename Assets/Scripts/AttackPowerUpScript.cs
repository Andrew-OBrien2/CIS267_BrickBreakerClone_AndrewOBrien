using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private BallCollision ballCollision;
    private float powerUpTimer = 0f;
    private bool powerUpActive = false;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        GameObject Ball = GameObject.Find("Ball");
        ballCollision = Ball.GetComponent<BallCollision>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (powerUpActive)
        {
            powerUpTimer -= Time.deltaTime;

            //if timer runs out, reset damage and destroy game object
            if (powerUpTimer <= 0f)
            {
                ballCollision.damage = 1;
                powerUpActive = false;
                Destroy(gameObject);
            }
        }

        //move down
        transform.Translate(Vector2.down * 2 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            ballCollision.damage = 2;
            powerUpTimer = 5f;
            powerUpActive = true;

            //below is a really dumb way of solving a few problems. Didn't want to waste time organizing code.
            //What this does is make sure the player can't see the sprite anymore but the timer keeps going and
            //they won't be able to collide with it again and the power up won't collide with the killbox at the
            //bottom of the screen.

            //make the power up invisible
            spriteRenderer.enabled = false;
            Vector2 newPosition = transform.position;
            newPosition.y = 100f;
            transform.position = newPosition;
        }
        else if (collision.gameObject.CompareTag("KillBox"))
        {
            Destroy(gameObject);
        }
    }
}
