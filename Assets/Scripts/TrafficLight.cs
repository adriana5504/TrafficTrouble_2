using System.Collections;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public Renderer greenRenderer;
    public Renderer yellowRenderer;
    public Renderer redRenderer;

    public float changeSpeed = 5f;

    private Color greenOriginal;
    private Color yellowOriginal;
    private Color redOriginal;
    private Color offColor = Color.gray;

    private void Start()
    {
        // Store the original colors of each bulb
        greenOriginal = greenRenderer.material.color;
        yellowOriginal = yellowRenderer.material.color;
        redOriginal = redRenderer.material.color;

        StartCoroutine(CycleLights());
    }

    private IEnumerator CycleLights()
    {
        while (true)
        {
            // Green on
            SetLights(greenOriginal, offColor, offColor);
            yield return new WaitForSeconds(changeSpeed);

            // Yellow on
            SetLights(offColor, yellowOriginal, offColor);
            yield return new WaitForSeconds(changeSpeed);

            // Red on
            SetLights(offColor, offColor, redOriginal);
            yield return new WaitForSeconds(changeSpeed);
        }
    }

    private void SetLights(Color green, Color yellow, Color red)
    {
        greenRenderer.material.color = green;
        yellowRenderer.material.color = yellow;
        redRenderer.material.color = red;
    }
}
