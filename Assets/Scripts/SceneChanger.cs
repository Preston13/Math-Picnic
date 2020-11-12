using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class SceneChanger : MonoBehaviour
{
    string GooglePlayID = "3857261";
    string AppleStoreID = "3857260";
    bool testMode = true;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Advertisement.Initialize(GooglePlayID, testMode);
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Advertisement.Initialize(AppleStoreID, testMode);
        }
    }
    public void ChangeScene(string name)
    {
        if (Advertisement.IsReady() && name != "OptionsScene" && name != "MainMenu" && name != "TutorialScene")
        {
            Advertisement.Show("video");
        }

        if (!Advertisement.isShowing)
        {
            SceneManager.LoadScene(name);
        }
    }

    public void PauseScene()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
