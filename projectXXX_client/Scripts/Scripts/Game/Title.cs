using System;
using UnityEngine;

public class Title : GameMain
{
    public void Awake()
    {
        UIManager.Instance.Open("UILogo");
    }

    public override void OnFocus()
    {
    }
}