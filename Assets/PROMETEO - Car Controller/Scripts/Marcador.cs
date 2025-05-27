using System.Collections;
using UnityEngine;
using TMPro;

public class Marcador : MonoBehaviour
{
    public int score = 100;

    public TextMeshPro scoreText;
    public string playerName = "Player 1";

    public Color normalColor = Color.black;
    public Color hitColor = Color.red;
    public float flashDuration = 0.2f;

    void Start()
    {
        UpdateScoreText();
    }

    public void SubtractPoint()
    {
        score = Mathf.Max(0, score - 1);
        UpdateScoreText();
        if (scoreText != null)
            StartCoroutine(FlashScoreColor());
    }

    public void SubtractPoints(int amount)
    {
        score = Mathf.Max(0, score - amount);
        UpdateScoreText();
        if (scoreText != null)
            StartCoroutine(FlashScoreColor());
    }


    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score " + playerName + ": " + score;
    }

    IEnumerator FlashScoreColor()
    {
        scoreText.color = hitColor;
        yield return new WaitForSeconds(flashDuration);
        scoreText.color = normalColor;
    }
}







