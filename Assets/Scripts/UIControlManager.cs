using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using System;
public class UIControlManager : MonoBehaviour
{
    [SerializeField] XRButtonInteractable startButton;
    [SerializeField] string[] msgStrings;
    [SerializeField] TMP_Text[] msgTexts;

    [Header("Key")]
    [SerializeField] private GameObject keyLight;



    void Start()
    {
        if (startButton != null)
        {
            startButton.selectEntered.AddListener(StartButtonPressed);
        }
    }

    private void StartButtonPressed(SelectEnterEventArgs arg0)
    {
        keyLight.SetActive(true);
        SetText(msgStrings[1]);

    }

    public void SetText(string msg)
    {
       /* for (int i = 0; i < msgStrings.Length; i++)
        {
            msgTexts[i].text = msg;
        }*/
         msgTexts[0].text = msg;
    }


}
