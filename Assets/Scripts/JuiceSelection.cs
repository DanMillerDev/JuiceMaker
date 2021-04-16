using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceSelection : MonoBehaviour
{
    [SerializeField]
    JuiceStorage m_JuiceStorage;

    public void AddJuice()
    {
        Debug.Assert(m_JuiceStorage != null, "Juice Storage must be assigned");
        m_JuiceStorage.AddJuice();
    }
}
