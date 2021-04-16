using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    [SerializeField]
    Animator m_Animator;

    const string k_PressTrigger = "Press";
    public void Press()
    {
        Debug.Assert(m_Animator != null, "Animator needs to be set");
        m_Animator.SetTrigger(k_PressTrigger);
    }
}
