using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JuiceStorage : MonoBehaviour
{
    [SerializeField]
    JuiceCreationManager m_JuiceCreationManager;

    [SerializeField]
    Animator m_JuiceAnimator;
    
    [SerializeField]
    GameObject m_GlassPrefab;

    [SerializeField]
    Transform m_StartingTransform;

    [SerializeField]
    TMP_Dropdown m_StartIndexDropdown;

    [SerializeField]
    TMP_Dropdown m_EndIndexDropdown;

    const float k_GlassSpacing = 1.0f;
    Quaternion m_GlassRotation = new Quaternion(0, 0, 0.2f, 1);

    List<GameObject> m_GlassesInBag;

    const string k_EmptyAnimTrigger = "Empty";

    void OnEnable()
    {
        m_GlassesInBag ??= new List<GameObject>();
        
        
        //m_StartIndexDropdown.options.Add(new TMP_Dropdown.OptionData(2.ToString()));
    }

    public void SpawnJuice(Color juiceColor)
    {
        Vector3 offset = new Vector3((m_GlassesInBag.Count + 1) * k_GlassSpacing, 0, 0);
        GameObject newJuice = Instantiate(m_GlassPrefab, m_StartingTransform.position - offset, m_GlassRotation);
        m_GlassesInBag.Add(newJuice);

        if (newJuice.TryGetComponent(out Juice juice))
        {
            juice.SetJuiceColor(juiceColor);
        }
    }
    
    public void AddJuice()
    {
        Debug.Assert(m_JuiceCreationManager != null, "Juice creation manager needs to be set");
        SpawnJuice(m_JuiceCreationManager.GetCurrentJuiceColor());
        Debug.Assert(m_JuiceAnimator != null, "Juice animator needs to be set");
        m_JuiceAnimator.SetTrigger(k_EmptyAnimTrigger);
    }
}
