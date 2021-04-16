using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIJuiceManager : MonoBehaviour
{
    [SerializeField]
    GameObject m_GlassPrefab;

    [SerializeField]
    Transform m_StartingTransform;

    const float k_GlassSpacing = 1.0f;
    Quaternion m_GlassRotation = new Quaternion(0, 0, 0.2f, 1);

    List<GameObject> m_GlassesInBag;

    void OnEnable()
    {
        m_GlassesInBag ??= new List<GameObject>();
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
}
