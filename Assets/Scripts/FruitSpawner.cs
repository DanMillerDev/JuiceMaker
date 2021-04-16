using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject m_FruitPrefabToSpawn;

    [SerializeField]
    GameObject m_CurrentFruit;

    void OnEnable()
    {
        SpawnFruit();
    }

    void Update()
    {
        if (m_CurrentFruit != null)
        {
            // fruit moved, spawn new one
            if (m_CurrentFruit.transform.position != transform.position)
            {
                SpawnFruit();
            }
        }
    }

    void SpawnFruit()
    {
        m_CurrentFruit = Instantiate(m_FruitPrefabToSpawn, transform.position, Quaternion.identity);
    }
}
