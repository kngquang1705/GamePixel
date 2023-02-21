using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeControll : MonoBehaviour
{
    private Animator anima;

    private Rigidbody2D rb;
    [SerializeField] private AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //Debug.Log(SceneManager.GetActiveScene().name);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Strike") || collision.gameObject.CompareTag("Saw") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Fallen"))
        {
            deathSound.Play();
            Die();
        }
    }

    void Die()
    {
        anima.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
