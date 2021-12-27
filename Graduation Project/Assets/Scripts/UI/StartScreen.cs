using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartScreen : Screen
{
    public event UnityAction PlayerButtonClick;

    public override void Close()
    {
        gameObject.SetActive(false);
    }

    public override void Open()
    {
        gameObject.SetActive(true);
        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }

    protected override void OnButtonClic()
    {
        PlayerButtonClick?.Invoke();
    }
}
