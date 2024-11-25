using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public float velocityBoost;
    private Rigidbody2D ballRigidBody;
    public int damage = 1;
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if the collision is with the paddle
        if (collision.gameObject.CompareTag("Paddle"))
        {
            //paddle's x position is the center of the paddle.
            float paddleX = collision.gameObject.transform.position.x;

            //get ball's x position on collision to compare how far from the center it was when it hit.
            float ballX = transform.position.x;

            float offset = ballX - paddleX;

            if (offset >= 0.5f)
            {
                // Ball hit the right side of the paddle
                ballRigidBody.velocity += new Vector2(velocityBoost, 0);
            }
            else if (offset <= -0.5f)
            {
                // Ball hit the left side of the paddle
                ballRigidBody.velocity += new Vector2(-velocityBoost, 0);
            }
            //if the offset is between -0.5 and 0.5, do nothing because the ball is near the center.

            //call this function to make sure the ball doesn't speed up as the player keeps bouncing it
            MaintainConsistentSpeed();
        }
    }

    private void MaintainConsistentSpeed()
    {
        Vector2 currentVelocity = ballRigidBody.velocity;

        //normalize the velocity to give it consistent speed
        ballRigidBody.velocity = currentVelocity.normalized * 5;
    }
}
