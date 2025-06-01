using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTrafficRules : MonoBehaviour
{
    private Rigidbody rb;          // Keep for collision
    private WayPoint wayPoint;     // Control movement

    void Start()
    {
        rb = GetComponent<Rigidbody>();     // Still required!
        wayPoint = GetComponent<WayPoint>(); // Needed for stopping
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrafficLight"))
        {
            TrafficLight light = other.GetComponent<TrafficLight>();
            if (light != null)
                StartCoroutine(WaitForGreenLight(light));
        }

        if (other.CompareTag("StopSign"))
        {
            StartCoroutine(StopForSeconds(2f));
        }

        if (other.CompareTag("Pedestrian"))
        {
            StartCoroutine(StopForSeconds(5f));
        }
    }

    private IEnumerator WaitForGreenLight(TrafficLight light)
    {
        if (wayPoint != null)
        {
            wayPoint.canMove = false;

            while (light.CurrentState == TrafficLight.LightState.Red)
                yield return null;

            wayPoint.canMove = true;
        }
    }

    private IEnumerator StopForSeconds(float seconds)
    {
        if (wayPoint != null)
        {
            wayPoint.canMove = false;
            yield return new WaitForSeconds(seconds);
            wayPoint.canMove = true;
        }
    }
}
