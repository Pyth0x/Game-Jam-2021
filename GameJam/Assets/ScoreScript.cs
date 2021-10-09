using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private int score;
    
    
    private void Start()
    {
        score = 0;
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }


    public void UpdateScore()
    {
        score += 10;
        scoreText.text = score.ToString();
    }
    /*
    public void CheckForHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
        } 
    }*/
}
