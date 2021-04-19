using System;
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
    const string k_EmptyAnimTrigger = "Empty";
    Quaternion m_GlassRotation = new Quaternion(0, 0, 0.2f, 1);
    
    [SerializeField]
    List<GameObject> m_GlassesInBag;

    void OnEnable()
    {
        m_GlassesInBag ??= new List<GameObject>();
    }

    void Update()
    {
        m_EndIndexDropdown.gameObject.SetActive(m_GlassesInBag.Count > 1);
    }

    public void SpawnJuice(Color juiceColor)
    {
        Vector3 offset = new Vector3((m_GlassesInBag.Count + 1) * k_GlassSpacing, 0, 0);
        GameObject newJuice = Instantiate(m_GlassPrefab, m_StartingTransform.position - offset, m_GlassRotation);
        m_GlassesInBag.Add(newJuice);
        UpdateDropdownIndices();

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

    void UpdateDropdownIndices()
    {
        m_StartIndexDropdown.options.Add(new TMP_Dropdown.OptionData(m_GlassesInBag.Count.ToString()));
        m_EndIndexDropdown.options.Add(new TMP_Dropdown.OptionData(m_GlassesInBag.Count.ToString()));
    }

    void DrinkJuice()
    {

        GameObject[] glassesTest = new [] { this.gameObject, this.gameObject, this.gameObject, this.gameObject, this.gameObject };
        
        //Debug.Log(glassesTest[^2]);
        
        // values are the same, drink one juice
        if (m_StartIndexDropdown.value == m_EndIndexDropdown.value)
        {
            Destroy(m_GlassesInBag[m_StartIndexDropdown.value]);
            m_GlassesInBag.RemoveAt(m_StartIndexDropdown.value);
        }
        // drink juices in range
        else
        {
            //var allGlasses = m_GlassesInBag[..];
            //var lastGlass = m_GlassesInBag[^1];
        }
        
        
    }

    void ReorderJuiceGlasses()
    {
        
    }
}
