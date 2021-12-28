using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using IJunior.TypedScenes;

public class GameOverScreen : Screen
{
    public event UnityAction ResetButton;

    public override void Close()
    {
        gameObject.SetActive(false);
        SampleScene.Load();
    }

    public override void Open()
    {
        gameObject.SetActive(true);
        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }

    protected override void OnButtonClic()
    {
        ResetButton?.Invoke();
    }
}
