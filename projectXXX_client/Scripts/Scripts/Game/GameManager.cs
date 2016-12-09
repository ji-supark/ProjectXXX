using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoSingleTon<GameManager>
{
    private UILoading m_loading;

    public void ChangeScene(string name)
    {
        if (true == string.IsNullOrEmpty(name))
        {
            return;
        }

        AssetManager.Instance.DestroyAll();
        //화면 다 없앰
        UIManager.Instance.ClearUI();
        //UI 관리 레이어 클리어

        #region fade
        UIFade ui = UIManager.Instance.Open("UIFade") as UIFade;
        ui.m_openCallback = () =>
        {
            m_loading = UIManager.Instance.Open("UILoading") as UILoading;
            m_loading.transform.SetAsFirstSibling();
        };
        ui.m_closeCallback = () =>
        {
            StartCoroutine(StartChangeScene(name));
        };
        #endregion
    }

    private IEnumerator StartChangeScene(string name)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name);

        while (false == asyncOperation.isDone)
        {
            m_loading.progress(asyncOperation.progress);
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);

        m_loading.progress(1.0f);

        #region fade
        UIFade ui = UIManager.Instance.Open("UIFade") as UIFade;
        ui.m_openCallback = () =>
        {
            UIManager.Instance.Close("UILoading");
        };
        ui.m_closeCallback = () =>
        {
            GameMain gameMain = GameObject.Find(SceneManager.GetActiveScene().name).GetComponent<GameMain>();
            gameMain.OnFocus();
        };
        #endregion
    }
}