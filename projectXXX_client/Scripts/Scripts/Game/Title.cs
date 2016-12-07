using UnityEngine;

public class Title : GameMain
{

    public GameObject myCanvas;

    public void Awake()
    {
        UIManager.Instance.Open("UILogo");


        //    Debug.Log("titlestart");
        //  myCanvas = Create("Canvas");
        //
        //  Create("EventSystem");

        //  GameObject result = Create("UITitle");
        //  result.transform.SetParent(myCanvas.transform);
        //   result.transform.localScale = Vector3.one;
        //     result.transform.localPosition = Vector3.zero;
        //  }

        //  private GameObject Create(string name)
        //  {
        //   GameObject result = Resources.Load(name) as GameObject; ;
        //   result = GameObject.Instantiate(result);
        //   result.name = name;
        //  return result;
        // }

    }
}