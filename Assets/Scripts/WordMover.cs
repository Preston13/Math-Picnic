using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordMover : MonoBehaviour
{
    public float moveSpeed = 100f;
    public bool isCorrect = false;
    public int mode;

    private void Start()
    {
        mode = PlayerPrefs.GetInt("difficulty");
        string numberName = GetComponent<SpriteRenderer>().sprite.name;
        if (mode == (int)Difficulty.difficulty.hard)
        {
            moveSpeed = 6f;
        }
        else if (mode == (int)Difficulty.difficulty.medium)
        {
            moveSpeed = 4f;
        }
        else
        {
            moveSpeed = 2f;
        }
    }

    // Update is called once per frame
    void Update()
    {       
        this.transform.position -= new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;
    }
}
