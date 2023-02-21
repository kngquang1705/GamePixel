using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] private float distanceBetweenPlayerAndEnemy;

    private Rigidbody2D rb;

    [SerializeField] private int speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 vector2 = new Vector2(player.transform.position.x - rb.transform.position.x, player.transform.position.y - rb.transform.position.y);
        if(vector2.x > 0 && Vector2.Distance(rb.transform.position, player.transform.position) <= distanceBetweenPlayerAndEnemy)
        {
            rb.velocity = Vector2.right * speed;
        }
        else if(vector2.x < 0 && Vector2.Distance(rb.transform.position, player.transform.position) <= distanceBetweenPlayerAndEnemy)
        {
            rb.velocity = Vector2.left * speed;
            //Flip();
        }
    }

    void Flip()
    {
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
