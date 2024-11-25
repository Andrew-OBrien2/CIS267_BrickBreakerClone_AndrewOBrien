using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBrickChance : MonoBehaviour
{
    public Sprite metalSprite;
    private SpriteRenderer spriteRenderer;

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
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManager>().IncrementBrickCount();
        }
    }

    private void MakeMetalBrick()
    {
        spriteRenderer.sprite = metalSprite;

        //disable the Brick script so there isn't any issues with spawning power ups or giving points
        Brick brickScript = GetComponent<Brick>();
        if (brickScript != null)
        {
            brickScript.enabled = false;
        }
    }
}
