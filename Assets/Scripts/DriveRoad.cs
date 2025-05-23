using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveRoad : MonoBehaviour
{
    public bool offRoad;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OffRoad"))
        {
            offRoad = true;

            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OffRoad"))
        {
            offRoad = false;
        }
    }
}

