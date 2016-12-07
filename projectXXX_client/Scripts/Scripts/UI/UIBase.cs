using System.Collections.Generic;

public class UIBase : CachedAsset
{
    private List<UIElement> m_elementList = new List<UIElement>();

    public void Awake()
    {
        m_elementList.AddRange(transform.GetComponentsInChildren<UIElement>());
    }

    protected override void OnUse()
    {
        //float openTime = 0.0f;

        for(int i = 0; i < m_elementList.Count; ++i)
        {
            // float playTime = m_elementList[i].OpenAnimation();
            m_elementList[i].OpenAnimation();
            //openTime = openTime < playTime ? playTime : openTime;
        }
    }

    protected override void OnRestore()
    {

        for (int i = 0; i < m_elementList.Count; ++i)
        {
            m_elementList[i].CloseAnimation();
        }
        
    }


    internal override void Initialize(object[] parameters)
    {
    }

    internal override void OnInitialize(params object[] parameters)
    {
    }

}