using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator anima;
    private bool isTouchingPlayer = false;
    private void Start()
    {
        anima = GetComponent<Animator>();  
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            isTouchingPlayer = true;
        }
        anima.SetBool("isTouchingPlayer", isTouchingPlayer);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isTouchingPlayer = false;
        }
        anima.SetBool("isTouchingPlayer", isTouchingPlayer);
    }
}
