using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected Button Button;

    private void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClic);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClic);
    }

    protected abstract void OnButtonClic();

    public abstract void Open();

    public abstract void Close();
}
