using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameManager gm;
    public TextMeshProUGUI debugText;
    public string targetNotFoundText = "Please scan the main target.";
    public string targetFoundText = "Ready !";

    public GameObject mainLayout;
    
    public void Play()
    {
        Debug.Log("Play");
        mainLayout.SetActive(false);
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
    }
}
