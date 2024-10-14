using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;
public class XRButtonInteractable : XRSimpleInteractable
{
    [Header("Button Settings")]
    [SerializeField] Image buttonImage;
    private Color normalColor, highlightedColor, pressedColor, selectedColor;
    private bool isPressed;
    [SerializeField] Color[] buttonColor = new Color[4];
    void Start()
    {
        normalColor = buttonColor[0];
        highlightedColor = buttonColor[1];
        pressedColor = buttonColor[2];
        selectedColor = buttonColor[3];
        ResetColor();
    }

    public void ResetColor()
    {
        buttonImage.color = normalColor;
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        isPressed = false;
        buttonImage.color = highlightedColor;

    }
    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        if (!isPressed)
        {
            buttonImage.color = normalColor;
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        isPressed = true;
        buttonImage.color = pressedColor;

    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        buttonImage.color = selectedColor;
    }


}
