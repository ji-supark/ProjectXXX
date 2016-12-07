using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleTon<GameManager>
{
    private string m_sceneName;
    private UILoading m_loading;
    public void ChangeScene(string name)
    {
        if (true == string.IsNullOrEmpty(name))
        {
            return;
        }

        m_sceneName = name;

        AssetManager.Instance.DestroyAll();
        UIManager.Instance.ClearUI();

        UIFade ui = UIManager.Instance.Open("UIFade") as UIFade;
        ui.m_openCallback = () => // 화면이 완전히 까메졌을때
        {
            m_loading = UIManager.Instance.Open("UILoading") as UILoading;
            m_loading.transform.SetAsFirstSibling();
        };
        ui.m_closeCallback = () =>
        {
            StartCoroutine(StartChangeScene(name));
        };
    }


    private IEnumerator StartChangeScene(string name)
    {
        Debug.Log("진짜씬변경을시작하자");
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name);

        while (false == asyncOperation.isDone)
        {
            m_loading.progress(asyncOperation.progress);
            yield return null;
          
     
            //asyncOperation.progress
            // 이 퍼센트를 UI로딩의 게이지에 적용시켜라
            // Debug.Log(string.Format("씬로딩퍼센트 : {0} {1} {2}", asyncOperation.progress));
        }
        yield return new WaitForSeconds(1.0f);

        m_loading.progress(1.0f); 

        //UI의 게이지바를 100%로 강제로 변경해라
        UIFade ui = UIManager.Instance.Open("UIFade") as UIFade;
        ui.m_openCallback = () =>
        {
            UIManager.Instance.Close("UILoading");
        };
    }
}