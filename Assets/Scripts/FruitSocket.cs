#nullable enable
using System;
using UnityEngine;
using UnityEngine.Serialization;

public class FruitSocket : MonoBehaviour
{
    bool m_HasFruit = false;
    
    Fruit m_CurrentFruit;

    public Fruit currentFruit
    {
        get => m_CurrentFruit;
    }

    GameObject? m_FruitObject;

    public GameObject fruitObject
    {
        get => m_FruitObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out Fruit fruit))
        {
            if (!m_HasFruit && !fruit.isHeld)
            {
                m_HasFruit = true;
                m_CurrentFruit = fruit;
                m_FruitObject = other.gameObject;
                m_FruitObject.GetComponent<Rigidbody>().isKinematic = true;
                m_FruitObject.transform.position = transform.position;
                m_FruitObject.transform.rotation = Quaternion.identity;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.TryGetComponent(out Fruit fruit))
        {
            m_HasFruit = false;
            m_CurrentFruit = null;
        }
    }
}
