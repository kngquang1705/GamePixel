using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSaw : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 360 * Time.deltaTime * speed);
    }
}
