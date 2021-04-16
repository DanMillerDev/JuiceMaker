using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juice : MonoBehaviour
{
    [SerializeField]
    MeshRenderer m_JuiceMeshRenderer;

    const string k_URPListShader = "Universal Render Pipeline/Lit";
    public void SetJuiceColor(Color juiceColor)
    {
        Material newMat = new Material(Shader.Find(k_URPListShader));
        newMat.color = juiceColor;

        if (m_JuiceMeshRenderer != null)
        {
            m_JuiceMeshRenderer.material = newMat;
        }
        
    }
}
