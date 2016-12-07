
using UnityEngine;
using System.Collections;

public class EasingAnimationPlay : MonoBehaviour
{
	private EasingAnimator m_easingAnimator;

	public void Awake()
	{

		m_easingAnimator = GetComponent<EasingAnimator>();

		m_easingAnimator.Play();
	}

}