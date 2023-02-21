using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformControll : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;
    private int waypointindex = 0;

    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, waypoints[waypointindex].transform.position) < .1f)
        {
            waypointindex++;
            if(waypointindex >= waypoints.Length)
            {
                waypointindex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointindex].transform.position, Time.deltaTime * speed);
    }
}
