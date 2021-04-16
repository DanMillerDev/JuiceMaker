using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juice : MonoBehaviour
{
    [SerializeField]
    MeshRenderer m_JuiceMeshRenderer;
    public void SetJuiceColor(Color juiceColor)
    {
        Material newMat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        newMat.color = juiceColor;

        if (m_JuiceMeshRenderer != null)
        {
            m_JuiceMeshRenderer.material = newMat;
        }
        
    }
}
