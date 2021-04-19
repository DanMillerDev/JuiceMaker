#nullable enable
using System;
using UnityEngine;

public class FruitSocket : MonoBehaviour
{
    Fruit? m_CurrentFruit;

    public Fruit? currentFruit
    {
        get => m_CurrentFruit;
    }

    GameObject? m_FruitObject;

    public GameObject? fruitObject
    {
        get => m_FruitObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out Fruit fruit))
        {
            if (m_FruitObject == null && !fruit.isHeld)
            {
                m_CurrentFruit = fruit;
                m_FruitObject = other.gameObject;
                m_FruitObject.GetComponent<Rigidbody>().isKinematic = true;
                m_FruitObject.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.TryGetComponent(out Fruit fruit))
        {
            m_FruitObject = null;
            m_CurrentFruit = null;
        }
    }
}
