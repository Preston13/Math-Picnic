using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public List<Sprite> numberArray = new List<Sprite> {};
    public Image firstNum;
    public Image secondNum;
    public Image operation;
    public Image answer;
    public List<AudioClip> numberClips = new List<AudioClip> { };
    public LoseCondition loseCondition = new LoseCondition();

    private string firstNumber;
    private string secondNumber;
    private string thirdNumber;
    private string fourthNumber;
    private string fifthNumber;
    public Creator1 creator;

    private Creator1 creator1;
    private Creator1 creator2;
    private Creator1 creator3;
    private Creator1 creator4;
    private Creator1 creator5;

    private List<int> indexList = new List<int>();
    private AudioSource numberAudio;
    private int amountCreators;
    private int mode;
    private int type;

    // Start is called before the first frame update
    void Start()
    {
        numberAudio = GetComponent<AudioSource>();
        mode = PlayerPrefs.GetInt("difficulty");
        type = PlayerPrefs.GetInt("operation");
        if (mode == (int)Difficulty.difficulty.hard)
        {
            amountCreators = 5;
            creator1 = Instantiate(creator, new Vector3(0f, 7f, 0f), Quaternion.identity);
            creator2 = Instantiate(creator, new Vector3(1.15f, 7f, 0f), Quaternion.identity);
            creator3 = Instantiate(creator, new Vector3(-1.15f, 7f, 0f), Quaternion.identity);
            creator4 = Instantiate(creator, new Vector3(2.4f, 7f, 0f), Quaternion.identity);
            creator5 = Instantiate(creator, new Vector3(-2.4f, 7f, 0f), Quaternion.identity);
            InvokeRepeating("SetNumbers", 1f, 4f);
        }
        else if (mode == (int)Difficulty.difficulty.medium)
        {
            amountCreators = 4;
            creator1 = Instantiate(creator, new Vector3(.667f, 7f, 0f), Quaternion.identity);
            creator2 = Instantiate(creator, new Vector3(-.667f, 7f, 0f), Quaternion.identity);
            creator3 = Instantiate(creator, new Vector3(2f, 7f, 0f), Quaternion.identity);
            creator4 = Instantiate(creator, new Vector3(-2f, 7f, 0f), Quaternion.identity);
            InvokeRepeating("SetNumbers", 1f, 5f);
        }
        else
        {
            amountCreators = 3;
            creator1 = Instantiate(creator, new Vector3(0f, 7f, 0f), Quaternion.identity);
            creator2 = Instantiate(creator, new Vector3(2f, 7f, 0f), Quaternion.identity);
            creator3 = Instantiate(creator, new Vector3(-2f, 7f, 0f), Quaternion.identity);
            InvokeRepeating("SetNumbers", 1f, 7f);
        }

    }

    void SetNumbers()
    {
        int firstNumber;
        int secondNumber;
        answer.enabled = false;
        int range = 0;
        List<int> numList = new List<int>();
        numList.Add(0);

        // Add number families
        if (PlayerPrefs.GetInt("oneFamily") == 1)
        {
            numList.Add(1);
        }
        if (PlayerPrefs.GetInt("twoFamily") == 1)
        {
            numList.Add(2);
        }
        if (PlayerPrefs.GetInt("threeFamily") == 1)
        {
            numList.Add(3);
        }
        if (PlayerPrefs.GetInt("fourFamily") == 1)
        {
            numList.Add(4);
        }
        if (PlayerPrefs.GetInt("fiveFamily") == 1)
        {
            numList.Add(5);
        }
        if (PlayerPrefs.GetInt("sixFamily") == 1)
        {
            numList.Add(6);
        }
        if (PlayerPrefs.GetInt("sevenFamily") == 1)
        {
            numList.Add(7);
        }
        if (PlayerPrefs.GetInt("eightFamily") == 1)
        {
            numList.Add(8);
        }
        if (PlayerPrefs.GetInt("nineFamily") == 1)
        {
            numList.Add(9);
        }
        if (PlayerPrefs.GetInt("tenFamily") == 1)
        {
            numList.Add(10);
        }
        if (PlayerPrefs.GetInt("elevenFamily") == 1)
        {
            numList.Add(11);
        }
        if (PlayerPrefs.GetInt("twelveFamily") == 1)
        {
            numList.Add(12);
        }

        // Percent chance to re-use a missed question
        int chance = Random.Range(0, 10);
        if (loseCondition.missedNumbers.Count >= 1 && chance <= 5)
        {
            firstNumber = loseCondition.missedNumbers[0][0, 0];
            secondNumber = loseCondition.missedNumbers[0][0, 1];
            loseCondition.missedNumbers.RemoveAt(0);
        } else
        {
            firstNumber = numList[Random.Range(0, numList.Count)];
            secondNumber = Random.Range(0, 12);
        }
        PlayerPrefs.SetInt("firstNumber", firstNumber);
        PlayerPrefs.SetInt("secondNumber", secondNumber);

        // Do the math
        int answerNum = 0;
        if (type == (int)TypeToggle.symbol.addition)
        {
            operation.sprite = numberArray[145];
            answerNum = firstNumber + secondNumber;
            range = 12;
        }
        else if (type == (int)TypeToggle.symbol.multiplication)
        {
            operation.sprite = numberArray[146];
            answerNum = firstNumber * secondNumber;
            range = numberArray.Count - 2;
        }

        StartCoroutine(PlayAudio(firstNumber, secondNumber));
        firstNum.sprite = numberArray[firstNumber];
        secondNum.sprite = numberArray[secondNumber];
        answer.sprite = numberArray[answerNum];

        while (indexList.Count < amountCreators)
        {
            int num = Random.Range(0, range);

            if (!indexList.Contains(num) && num != answerNum)
            {
                indexList.Add(num);
            }
        }

        int correctNumber = Random.Range(0, amountCreators);

        if (correctNumber == 0)
        {
            creator1.CreateWord(numberArray[answerNum], true);
        }
        else
        {
            creator1.CreateWord(numberArray[indexList[0]], false);
        }

        if (correctNumber == 1)
        {
            creator2.CreateWord(numberArray[answerNum], true);
        }
        else
        {
            creator2.CreateWord(numberArray[indexList[1]], false);
        }

        if (correctNumber == 2)
        {
            creator3.CreateWord(numberArray[answerNum], true);
        }
        else
        {
            creator3.CreateWord(numberArray[indexList[2]], false);
        }

        if (correctNumber == 3)
        {
            creator4.CreateWord(numberArray[answerNum], true);
        }
        else if (mode > 0)
        {
            creator4.CreateWord(numberArray[indexList[3]], false);
        }

        if (correctNumber == 4)
        {
            creator5.CreateWord(numberArray[answerNum], true);
        }
        else if (mode == (int)Difficulty.difficulty.hard)
        {
            creator5.CreateWord(numberArray[indexList[4]], false);
        }
        indexList.Clear();
    }

    IEnumerator PlayAudio(int first, int second)
    {
        numberAudio.clip = numberClips[first];
        numberAudio.Play();
        yield return new WaitForSeconds(.5f);
        if (type == (int)TypeToggle.symbol.multiplication)
        {
            // multiply is at index 14
            numberAudio.clip = numberClips[14];
        } else {
            //the plus sign is at index 13
            numberAudio.clip = numberClips[13];
        }
        numberAudio.Play();
        yield return new WaitForSeconds(.5f);
        numberAudio.clip = numberClips[second];
        numberAudio.Play();
        yield return null;
    }
}
