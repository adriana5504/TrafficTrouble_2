using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveRoad : MonoBehaviour
{

    public bool offRoad;
    void Start()
    {
 
    }

    void Update()
    {

    }

    // This will be triggered when the car enters the off-road (e.g., wall or off-limits area)
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OffRoad")) // Assuming you've tagged off-road zones as "OffRoad"
        {
            offRoad = true;
        }
    }

    // This will be triggered when the car exits the off-road (e.g., car returns to the road)
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OffRoad"))
        {
            offRoad = false;
        }
    }
}
