using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeToggle : MonoBehaviour
{
    public enum symbol { addition, multiplication };
    public ToggleGroup toggle;
    public Toggle additionButton;
    public Toggle multiplicationButton;

    public symbol type;

    void Start()
    {
        toggle = GetComponent<ToggleGroup>();
        int number = PlayerPrefs.GetInt("operation");
        type = (TypeToggle.symbol)number;

        if (type == (TypeToggle.symbol)0)
        {
            additionButton.isOn = true;
        }
        else if (type == (TypeToggle.symbol)1)
        {
            additionButton.isOn = false;
            multiplicationButton.isOn = true;
        }
    }

    public void LoadType(string operation = "AdditionButton")
    {
        if (operation == "AdditionButton")
        {
            type = symbol.addition;
        }
        else if (operation == "MultiplicationButton")
        {
            type = symbol.multiplication;
        }
        PlayerPrefs.SetInt("operation", (int)type);
    }
}
