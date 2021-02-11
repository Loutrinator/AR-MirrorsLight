using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameManager gm;
    public TextMeshProUGUI debugText;
    public TextMeshProUGUI maxMirrorsCount;
    public string targetNotFoundText = "Please scan the main target.";
    public string targetFoundText = "Ready !";

    public GameObject mainLayout;
    public GameObject gameLayout;
    public GameObject winLayout;
    
    public void Play()
    {
        Debug.Log("Play");
        mainLayout.SetActive(false);
        gameLayout.SetActive(true);
        gm.Play();
    }
    public void ShowWin()
    {
        Debug.Log("ShowWin");
        gameLayout.SetActive(false);
        winLayout.SetActive(true);
    }
    public void NextLevel()
    {
        Debug.Log("NextLevel");
        winLayout.SetActive(false);
        gameLayout.SetActive(true);
        gm.LoadNextLevel();
    }

    private void Update()
    {
        if (gm.MainTargetFound)
        {
            debugText.text = targetFoundText;
        }
        else
        {
            debugText.text = targetNotFoundText;    
        }

        if (gm.CurrentLevel != null)
        {
            int mirrorCount = gm.CurrentLevel.mirrorlimit;
            string plural = "";
            if (mirrorCount > 1)
            {
                plural = "s";
            }
            maxMirrorsCount.text = mirrorCount + " mirror" + plural + " allowed";
        }
    }
}
