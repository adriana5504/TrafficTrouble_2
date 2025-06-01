using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveRoad : MonoBehaviour
{
    public bool offRoad;

    public Marcador marcador;

    public AudioSource crashAudioSource;  // Audio del choque con offroad
    public AudioSource hornAudioSource;   // Audio del claxon al chocar con enemigo

    private bool inStopZone = false;
    private float stopTimer = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (inStopZone)
        {
            if (rb.velocity.magnitude < 0.1f)  // Car is "stopped"
            {
                stopTimer += Time.deltaTime;
            }
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OffRoad"))
        {
            offRoad = true;

            if (crashAudioSource != null && !crashAudioSource.isPlaying)
            {
                crashAudioSource.Play();
            }

            if (marcador != null)
            {
                marcador.SubtractPoint(); // Resta 1 por offroad
            }
        }

        if (other.CompareTag("EnemyCar"))
        {
            if (marcador != null)
            {
                marcador.SubtractPoints(3); // Resta 3 por colisión
            }

            if (hornAudioSource != null && !hornAudioSource.isPlaying)
            {
                hornAudioSource.Play(); // Reproduce el claxon
            }
        }
        
        if (other.CompareTag("TrafficLight"))
        {
            TrafficLight light = other.GetComponent<TrafficLight>();
            if (light != null && light.CurrentState == TrafficLight.LightState.Red)
            {
                if (marcador != null)
                {
                    marcador.SubtractPoints(10); // Penalize only if red
                }
            }
        }

        if (other.CompareTag("StopSign"))
        {
            inStopZone = true;
            stopTimer = 0f;
        }

        if (other.CompareTag("Pedestrian"))
        {
            Debug.Log("Player collided with pedestrian");

            if (marcador != null)
                {
                    Debug.Log("Subtracting 20 points for not stopping.");
                    marcador.SubtractPoints(20);
                }
        }

    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OffRoad"))
        {
            offRoad = false;
        }

        if (other.CompareTag("StopSign"))
        {
            StopSign stopSign = other.GetComponent<StopSign>();
            inStopZone = false;

            if (stopSign != null)
            {
                if (stopTimer < stopSign.requiredStopTime)
                {
                    if (marcador != null)
                    {
                        marcador.SubtractPoints(5); // Didn't stop long enough
                    }
                }
            }

            stopTimer = 0f;
        }

    }
}
