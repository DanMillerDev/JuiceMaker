using System;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    Animator m_Animator;

    [SerializeField]
    JuiceCreationManager m_JuiceCreationManager;

    const string k_PressTrigger = "Press";
    public void Press()
    {
        Debug.Assert(m_JuiceCreationManager != null, "Juice creation manager needs to be set");
        if (m_JuiceCreationManager.TryCreateJuice())
        {
            Debug.Assert(m_Animator != null, "Animator needs to be set");
            m_Animator.SetTrigger(k_PressTrigger);
        }
    }
}
