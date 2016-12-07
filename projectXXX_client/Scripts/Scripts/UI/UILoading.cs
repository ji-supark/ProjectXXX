using System;
using UnityEngine.UI;

public class UILoading : UIBase
{
    public Slider m_silder;
    protected override void OpenComplete()
    {
    }

    protected override void CloseComplete()
    {
    }

    internal void progress(float value)
    {
        m_silder.value = value;
    }
}