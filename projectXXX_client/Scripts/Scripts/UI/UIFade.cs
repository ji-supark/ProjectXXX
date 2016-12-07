using System;

public class UIFade : UIBase
{
    //화면이 다 어두워졌을떄 불러지는 콜백
    public Action m_openCallback;
    //화면이 다 밝아졌을떄 불러지는 콜백
    public Action m_closeCallback;

    protected override void OpenComplete()
    {
        Restore();
        if (null != m_openCallback)
        {
            m_openCallback();
        }

        Restore();
     // 로딩창을 열어준다
    }
    protected override void CloseComplete()
    {
        if (null != m_closeCallback)
        {
            m_closeCallback();
        }

        m_openCallback = null;
        m_closeCallback = null;

    }

}
