using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marcador : MonoBehaviour

{
    public int score = 100;
    public Text scoreText;
    void Start()
    {
        UpdateScoreText();
    }

    public void SubtractPoint()
    {
        score = Mathf.Max(0, score - 1);  //Resta 1 punt
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
