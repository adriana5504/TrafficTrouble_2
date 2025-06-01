using UnityEngine;
using TMPro;  // Muy importante para textos TextMeshPro
using UnityEngine.SceneManagement;
using System.Collections;


public class GameTimer : MonoBehaviour
{
    public float gameDuration = 120f;    // Duración del juego en segundos
    private float currentTime;

    public TextMeshPro timerText3D;      // Referencia al texto 3D del cronómetro
    public TextMeshPro resultText3D;     // Referencia al texto 3D del resultado

    public Marcador marcador1;           // Referencia al marcador jugador 1
    public Marcador marcador2;           // Referencia al marcador jugador 2

    private bool gameEnded = false;

    void Start()
    {
        currentTime = gameDuration;
        UpdateTimerUI();
    }

    void Update()
    {
        if (gameEnded) return;

        currentTime -= Time.deltaTime;
        UpdateTimerUI();

        if (currentTime <= 0)
        {
            EndGame();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        if (timerText3D != null)
            timerText3D.text = $"Time: {minutes:00}:{seconds:00}";
    }
    
    IEnumerator WaitAndLoadScene(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }


    void EndGame()
    {
        gameEnded = true;
        currentTime = 0;
        UpdateTimerUI();

        int score1 = marcador1.score;
        int score2 = marcador2.score;

        if (resultText3D != null)
        {
            if (score1 > score2)
                resultText3D.text = "Player 1 Wins!";
            else if (score2 > score1)
                resultText3D.text = "Player 2 Wins!";
            else
                resultText3D.text = "It's a Draw!";
        }

        // Wait 10 seconds, then go to menu
        StartCoroutine(WaitAndLoadScene("Menu", 10f));

    }

}


