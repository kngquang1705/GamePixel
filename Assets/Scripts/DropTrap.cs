using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTrap : MonoBehaviour
{
    [SerializeField]  private GameObject[] trap;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            
            for (int i = 0; i < trap.Length; i++) {
                trap[i].transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
