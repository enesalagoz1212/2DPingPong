using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        restart();
    }
    public void restart()
    {
        transform.position = Vector3.zero;
        rb.velocity = new Vector2(speed, 0);
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            float yVel = collision.gameObject.GetComponent<Rigidbody2D>().velocity.y;
            if (yVel!=0)
            {
                rb.velocity = new Vector2(rb.velocity.x, yVel);
            }
            Vector2 newVel = rb.velocity;
            newVel.Normalize();
            newVel = newVel * speed;
            rb.velocity = newVel;
        }
        else if (collision.gameObject.tag=="deadZone")
        {
            if (collision.gameObject.name=="BorderR")
            {
                GameManager.main.playerLscore++;
            }
            else if (collision.gameObject.name=="BorderL")
            {
                GameManager.main.playerRscore++;
            }
            print("Game Over");
            GameManager.main.RestartGame();
        }

    }
}
