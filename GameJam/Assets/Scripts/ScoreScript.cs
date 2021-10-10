using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI highScoretext;
    public static int score;
    public static int highscore;
    private float deltaTime;


    void Start()
    {
        highscore = 0;
        score = 0;

        highscore = PlayerPrefs.GetInt("highscore", highscore);
        highScoretext.text = highscore.ToString();
    }
   
    public void UpdateScore()
    {
        score += 10;
        scoretext.text = score.ToString();
    }

    void Update()
    {
        if (score > highscore)
        {
            highscore = score;
            scoretext.text = "" + score;

            PlayerPrefs.SetInt("highscore", highscore);
        }
    }
}
