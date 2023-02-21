using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    ItemsCollect item;

    private bool isFinish = false;

    [SerializeField] private AudioSource finishSound;
    // Start is called before the first frame update
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isFinish == false && collision.gameObject.name == "Player")
        {
            isFinish = true;
            finishSound.Play();
            Invoke("nextLevel", 3f);
        }
    }

    private void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
