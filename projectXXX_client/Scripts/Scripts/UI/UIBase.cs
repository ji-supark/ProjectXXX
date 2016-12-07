using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBase : CachedAsset
{
    protected abstract void OpenComplete();
    protected abstract void CloseComplete();

    private List<UIElement> m_elementList = new List<UIElement>();

    public void Awake()
    {
        m_elementList.AddRange(transform.GetComponentsInChildren<UIElement>());
    }

    internal override void OnInitialize(params object[] parameters)
    {
    }

    protected override void OnUse()
    {
        float openTime = 0.0f;
 
        for(int i = 0; i < m_elementList.Count; ++i)
        {
            //각UI Element에서 OpenAnimation 이라는 함수를 실행하고 그 애니메이션 플레이타임을 리턴해준다
            Debug.Log(2);
            float animationTime = m_elementList[i].OpenAnimation();

            openTime = openTime < animationTime ? animationTime : openTime;
        }
        Debug.Log(3);
        StartCoroutine(Open(openTime));
    }


    protected override void OnRestore()
    {
        float closeTime = 0.0f;

        for (int i = 0; i < m_elementList.Count; ++i)
        {
 
            float animationTime = m_elementList[i].CloseAnimation();

            closeTime = closeTime < animationTime ? animationTime : closeTime;
        }

        StartCoroutine(Close(closeTime));
    }

    private IEnumerator Open(float openTime)
    {
        yield return new WaitForSeconds(openTime);
        OpenComplete();
    }
    
    private IEnumerator Close(float closeTime)
    {
        yield return new WaitForSeconds(closeTime);
        CloseComplete();
        gameObject.SetActive(false);
    }

}