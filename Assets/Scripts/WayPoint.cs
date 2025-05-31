using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    private int currentWaypointIndex = 0;

    void Start()
    {
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
        }
    }


    void Update()
    {
        if (waypoints.Length == 0) return;

        Transform target = waypoints[currentWaypointIndex];
        Vector3 direction = (target.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(target);

        if (Vector3.Distance(transform.position, target.position) < 0.5f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // o `Destroy(gameObject)` si vols que desaparegui
            }
        }
    }
}


