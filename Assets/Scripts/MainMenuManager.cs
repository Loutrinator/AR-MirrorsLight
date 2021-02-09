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
        
    public void Play()
    {
        Debug.Log("Play !");
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
