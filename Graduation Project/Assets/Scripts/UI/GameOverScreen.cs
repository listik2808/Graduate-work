using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverScreen : Screen
{
    public event UnityAction ResetButton;

    public override void Close()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("SampleScene");
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
