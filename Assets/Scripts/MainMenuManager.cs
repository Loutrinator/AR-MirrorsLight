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
    
    public void Play()
    {
        Debug.Log("Play");
        mainLayout.SetActive(false);
        gameLayout.SetActive(true);
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

        int mirrorCount = gm.CurrentLevel.mirrorlimit;
        string plural = "";
        if (mirrorCount > 1)
        {
            plural = "s";
        }
        maxMirrorsCount.text = mirrorCount + " mirror" + plural + " allowed";
    }
}
