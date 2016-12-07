using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingleTon<UIManager>
{
    private List<UIBase> m_uis = new List<UIBase>();
    private Canvas m_canvas;
    private Object eventSystem;

    private UIManager()
    {
        m_canvas = Resources.Load<Canvas>("UICanvas");
        m_canvas = GameObject.Instantiate(m_canvas);
        GameObject.DontDestroyOnLoad(m_canvas);

        eventSystem = Resources.Load("EventSystem") as GameObject;
        eventSystem = GameObject.Instantiate(eventSystem);
        GameObject.DontDestroyOnLoad(eventSystem);
    }

    public UIBase Open(string uiName, params object[] parameters)
    {
        UIBase result = m_uis.Find(rhs => rhs.name == uiName);

        if (result == null)
        {
            result = AssetManager.Instance.UI.Retrieve(uiName);
            m_uis.Add(result);
            result.transform.SetParent(m_canvas.transform,false);
            return result;
        }

        if (AssetState.Waiting == result.AssetState)
        {
            return AssetManager.Instance.UI.Retrieve(uiName);
            
        }
        else
        {
            Debug.Log("(UIManager.Open) {0} 이미열려있습니다.");
            return result;
        }
    }

    public void Close(string uiName)
    {
        UIBase result = m_uis.Find(rhs => rhs.name == uiName);

        if(null == result)
        {
            Debug.Log(string.Format("(UIManager.Close) 닫으려는 {0}, 존재하지 않습니다.", uiName));
            return;
        }
        result.Restore();
    }
   
}