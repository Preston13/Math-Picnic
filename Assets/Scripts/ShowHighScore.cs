using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour
{
    public Text highScoreTxt;

    void Update()
    {
        int type = PlayerPrefs.GetInt("operation");
        if (type == (int)TypeToggle.symbol.addition)
        {
            highScoreTxt.text = "High Score: " + PlayerPrefs.GetInt("additionHighscore", 0).ToString();
        }
        else
        {
            highScoreTxt.text = "High Score: " + PlayerPrefs.GetInt("multiplicationHighscore", 0).ToString();
        }
    }
}
