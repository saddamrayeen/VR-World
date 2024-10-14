using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using UnityEngine.UI;

public class PassKeyManager : MonoBehaviour
{


    [SerializeField] TMP_Text userInputText;
    [SerializeField] XRButtonInteractable[] comboButtons;
    [SerializeField] TMP_Text infoText;
    private const string startString = "Enter 3 Digit Passkey";
    private const string resetString = "Enter 3 Digits To Reset Passkey";
    [SerializeField] Image lockedPanel;

    [SerializeField] TMP_Text lockedText;
    [SerializeField] bool isResettable;
    bool isLocked;
    bool resetCombo;

    [SerializeField] int[] comboValues = new int[3];
    [SerializeField] int[] inputValues;


    int maxButtonPrasses;
    int buttonPrasses;
    void Start()
    {
        maxButtonPrasses = comboValues.Length;
        ResetUserValues();

        for (int i = 0; i < comboButtons.Length; i++)
        {
            comboButtons[i].selectEntered.AddListener(OnComboButtonPressed);
        }
    }

    private void OnComboButtonPressed(SelectEnterEventArgs arg0)
    {
        if (buttonPrasses >= maxButtonPrasses)
        {
            Debug.Log("Too Many Button Prasses");
        }
        else
        {
            for (int i = 0; i < comboButtons.Length; i++)
            {
                if (arg0.interactableObject.transform.name == comboButtons[i].transform.name)
                {
                    string val = comboButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().text;
                    userInputText.text += val;
                    inputValues[buttonPrasses] = int.Parse(val);
                }
                else
                {

                    comboButtons[i].ResetColor();
                }
            }
            buttonPrasses++;

            if (buttonPrasses == maxButtonPrasses)
            {
                CheckCombo();
            }
        }

    }

    private void CheckCombo()
    {
        if (resetCombo)
        {
            resetCombo = false;
            LockCombo();
            return;
        }
        int matches = 0;
        for (int i = 0; i < maxButtonPrasses; i++)
        {
            if (inputValues[i] == comboValues[i])
            {
                matches++;
            }
        }

        if (matches == maxButtonPrasses)
        {
            UnlockCombo();

        }
        else
        {
            ResetUserValues();
        }
    }

    private void UnlockCombo()
    {
        isLocked = false;
        lockedPanel.color = Color.green;
        lockedText.text = "Unlocked";
        if (isResettable)
        {
            ResetCombo();
        }
    }

    private void LockCombo()
    {
        lockedText.text = "Locked";
        lockedPanel.color = Color.red;
        isLocked = true;
        infoText.text = startString;
        for (int i = 0; i < maxButtonPrasses; i++)
        {
            comboValues[i] = inputValues[i];
        }
        ResetUserValues();
    }

    private void ResetCombo()
    {
        infoText.text = resetString;
        ResetUserValues();
        resetCombo = true;

    }

    private void ResetUserValues()
    {
        inputValues = new int[maxButtonPrasses];
        userInputText.text = "";
        buttonPrasses = 0;
    }
}
