using System;
using UnityEngine;

public class UILogo : UIBase
{
    protected override void OpenComplete()
    {
        Debug.Log("UILogo 열림완료");
        UIManager.Instance.Open("UITitle");
    }
    protected override void CloseComplete()
    {
        
    }

}