using System;
using UnityEngine;

public class FruitSelectionManager : MonoBehaviour
{
    [SerializeField]
    Camera m_MainCamera;
    
    
    GameObject m_CurrentFruitSelected;
    Vector2 m_CurrentMousePosition;
    RaycastHit m_HitInfo;
    Vector3 m_CurrentFruitPosition;

    const float k_HeldHeight = 2f;

    void Update()
    {
        m_CurrentMousePosition = Input.mousePosition;
        
        if (m_CurrentFruitSelected != null)
        {
            m_CurrentFruitPosition = m_MainCamera.ScreenToWorldPoint(new Vector3(m_CurrentMousePosition.x, m_CurrentMousePosition.y, k_HeldHeight));
            m_CurrentFruitSelected.transform.position = m_CurrentFruitPosition;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Assert(m_MainCamera != null, "Camera can't be null");
            if (Physics.Raycast(m_MainCamera.ScreenPointToRay(m_CurrentMousePosition), out m_HitInfo))
            {
                // check if is fruit
                if (m_HitInfo.transform.TryGetComponent(out Fruit fruit))
                {
                    m_CurrentFruitSelected = m_HitInfo.transform.gameObject;
                    fruit.isHeld = true;
                    m_CurrentFruitSelected.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
        
        if (Input.GetMouseButtonUp(0))
        {       
            // release fruit, do check for socket
            if (m_CurrentFruitSelected != null)
            {
                m_CurrentFruitSelected.GetComponent<Rigidbody>().isKinematic = false;
                m_CurrentFruitSelected.GetComponent<Fruit>().isHeld = false;
            }

            m_CurrentFruitSelected = null;
        }
    }
}
