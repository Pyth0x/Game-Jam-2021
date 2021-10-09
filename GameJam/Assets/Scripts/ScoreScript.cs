using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    void Start()
    {
        score = 0;
    }

   
    public void UpdateScore()
    {
        score += 10;
        scoreText.text = score.ToString();
    }
}
