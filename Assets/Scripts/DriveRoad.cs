using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveRoad : MonoBehaviour
{
    public bool offRoad;

    public Marcador marcador;

    public AudioSource crashAudioSource;  // Audio del choque con offroad
    public AudioSource hornAudioSource;   // Audio del claxon al chocar con enemigo

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
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OffRoad"))
        {
            offRoad = false;
        }
    }
}
