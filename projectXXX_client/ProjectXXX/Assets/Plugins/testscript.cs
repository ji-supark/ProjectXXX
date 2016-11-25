using UnityEngine;
using System.Collections;

public class testscript : MonoBehaviour
{
    private EasingAnimator m_easingAnimator;

    public void Awake()
    {

        m_easingAnimator = GetComponent<EasingAnimator>();

        m_easingAnimator.Play();
    }

}
