using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberFamilies : MonoBehaviour
{
    private Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    public void ActivateFamily(string family)
    {
        if (PlayerPrefs.GetInt(family) == 0)
        {
            PlayerPrefs.SetInt(family, 1);
        }
        else
        {
            PlayerPrefs.SetInt(family, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
