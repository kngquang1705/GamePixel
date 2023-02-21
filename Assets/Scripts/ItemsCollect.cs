using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCollect : MonoBehaviour
{
    public int points = 0;
    [SerializeField] private Text cherrietext;
    [SerializeField] private AudioSource cherriCollectSound;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cherrie") || collision.gameObject.CompareTag("Fruits"))
        {
            Destroy(collision.gameObject);
            points++;
            cherriCollectSound.Play();
        }
        if (collision.gameObject.CompareTag("Gold"))
        {
            Destroy(collision.gameObject);
            points++;
           
            cherriCollectSound.Play();
        }
        cherrietext.text = "Point: " + points;
    }
}
