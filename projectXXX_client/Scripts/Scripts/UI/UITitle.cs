using System;
using UnityEngine;

public class UITitle : UIBase
{
    public GameObject m_nextText;

    private bool m_isOpenComplete = false;


    protected override void OpenComplete()
    {
        Debug.Log("UI 열리는 애니메이션 전부가 끝남");
        m_isOpenComplete = true;
        m_nextText.SetActive(true);
    }
    protected override void CloseComplete()
    {

    }

    public void GoLobby()
    {
        if (false == m_isOpenComplete)
        {
            return;
        }
        GameManager.Instance.ChangeScene("Lobby");
    }
}
