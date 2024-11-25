using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    public Rigidbody2D ballRigidBody;
    public float initialBallForce;
    private bool ballReleased = false;
    public bool isReversed = false;
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        //set to zero on each loop
        Vector2 moveDirection = Vector2.zero;

        //if reversed, move in opposite direction
        if (isReversed)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveDirection = Vector2.right;
                ReleaseBall();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                moveDirection = Vector2.left;
                ReleaseBall();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveDirection = Vector2.left;
                ReleaseBall();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                moveDirection = Vector2.right;
                ReleaseBall();
            }
        }

        playerRigidBody.velocity = moveDirection * movementSpeed;
    }

    private void ReleaseBall()
    {
        if (ballReleased != true)
        {
            //start moving the ball downwards
            ballRigidBody.velocity = new Vector2(0, -initialBallForce);
            //set the ball state to released so the ball doesn't get pushed down every time the player moves
            ballReleased = true;
        }
    }

    public void ResetBallState()
    {
        ballReleased = false;
    }
}
