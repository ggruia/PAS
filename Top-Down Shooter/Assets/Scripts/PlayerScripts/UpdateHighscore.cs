using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateHighscore : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;

    private void Start()
    {
        score = PlayerPrefs.GetInt("waveHighscore");
        ShowText(score);
    }

    public void ShowText(int score)
    {
        scoreText.text = $"Highscore: {score}";
    }
}
