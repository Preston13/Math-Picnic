using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public int score;
    public Text scoreTxt;
    public int highscore;

    private int type;

    public void Start()
    {
        type = PlayerPrefs.GetInt("operation");
        scoreTxt.text = "Score: " + score;
        if (type == 0)
        {
            highscore = PlayerPrefs.GetInt("additionHighscore");
        } else
        {
            highscore = PlayerPrefs.GetInt("multiplicationHighscore");
        }
        PlayerPrefs.SetInt("lastScore", 0);
    }

    private void Update()
    {
        if (score > highscore)
        {
            highscore = score;
            if (type == (int)TypeToggle.symbol.addition)
            {
                PlayerPrefs.SetInt("additionHighscore", score);
            }
            else
            {
                PlayerPrefs.SetInt("multiplicationHighscore", score);
            }
        }
    }

    public void UpdateScore()
    {
        score += 10;
        scoreTxt.text = "Score: " + score;
    }

    public void UpdatePenalty()
    {
        if (score < 0)
        {
            score = 0;
        }
        scoreTxt.text = "Score: " + score;
    }
}
