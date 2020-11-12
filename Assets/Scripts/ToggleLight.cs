using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleLight : MonoBehaviour
{
    private Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
        if (PlayerPrefs.HasKey(this.gameObject.name))
        {
            if (PlayerPrefs.GetInt(this.gameObject.name) == 1)
            {
                toggle.isOn = true;
                PlayerPrefs.SetInt(this.gameObject.name, 1);
            }
            else
            {
                toggle.isOn = false;
                PlayerPrefs.SetInt(this.gameObject.name, 0);
            }
        }
        else
        {
            PlayerPrefs.SetInt(this.gameObject.name, 1);
            toggle.isOn = true;
        }
    }

    private void OnToggleValueChanged(bool isOn)
    {
        ColorBlock colorBlock = toggle.colors;
        if (toggle.isOn)
        {
            colorBlock.normalColor = new Color(1f, 1f, 0f);
            colorBlock.highlightedColor = new Color(1f, 1f, .2f);
            colorBlock.selectedColor = new Color(1f, 1f, 0f);
        }
        else
        {
            colorBlock.normalColor = new Color(1f, 1f, 1f);
            colorBlock.highlightedColor = new Color(.9f, .9f, .9f);
            colorBlock.selectedColor = new Color(1f, 1f, 1f);
        }
        toggle.colors = colorBlock;
    }
}
