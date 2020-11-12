using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Catcher : MonoBehaviour
{
    public ScoreKeeper scoreKeep;
    public Image answer;

    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<WordMover>().isCorrect)
        {
            scoreKeep.UpdateScore();
            Invoke("PlayYum", .5f);
        }
        else
        {
            scoreKeep.UpdatePenalty();   
        }

        answer.enabled = true;
        
        Destroy(collision.gameObject);
    }    

    private void PlayYum()
    {
        audio.Play();
    }
}
