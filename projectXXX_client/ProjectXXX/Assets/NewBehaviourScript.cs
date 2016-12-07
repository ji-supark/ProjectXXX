using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {


	public void OnButton()

	{
		UIManager.Instance.Open ("UITest");
	}

	public void OnButtonOption()

	{
		UIManager.Instance.Open ("UIOption");
	}

}