﻿using System;
using UnityEngine;

public class UILogo : UIBase
{
    protected override void OpenComplete()
    {
        UIManager.Instance.Open("UITitle");
    }

    protected override void CloseComplete()
    {
    }
}