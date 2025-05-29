using System.Collections;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public enum LightState { Green, Yellow, Red }

    public Renderer greenRenderer;
    public Renderer yellowRenderer;
    public Renderer redRenderer;

    public float changeSpeed = 10f;

    private Color greenOriginal;
    private Color yellowOriginal;
    private Color redOriginal;
    private Color offColor = Color.gray;

    public LightState CurrentState { get; private set; }

    private void Start()
    {
        greenOriginal = greenRenderer.material.color;
        yellowOriginal = yellowRenderer.material.color;
        redOriginal = redRenderer.material.color;

        StartCoroutine(CycleLights());
    }

    private IEnumerator CycleLights()
    {
        while (true)
        {
            SetLights(greenOriginal, offColor, offColor);
            CurrentState = LightState.Green;
            yield return new WaitForSeconds(changeSpeed);

            SetLights(offColor, yellowOriginal, offColor);
            CurrentState = LightState.Yellow;
            yield return new WaitForSeconds(changeSpeed);

            SetLights(offColor, offColor, redOriginal);
            CurrentState = LightState.Red;
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
