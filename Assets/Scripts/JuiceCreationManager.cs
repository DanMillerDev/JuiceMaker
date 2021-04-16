using System;
using UnityEngine;

public class JuiceCreationManager : MonoBehaviour
{

    [SerializeField]
    Camera m_MainCamera;

    [SerializeField]
    FruitSocket m_FirstSocket;

    [SerializeField]
    FruitSocket m_SecondSocket;

    [SerializeField]
    UIJuiceManager m_UIJuiceManager;

    [SerializeField]
    Color m_AppleJuiceColor;

    [SerializeField]
    Color m_PeachJuiceColor;

    [SerializeField]
    Color m_OrangeJuiceColor;
    
    [SerializeField]
    Color m_ApplePeachJuiceColor;
    
    [SerializeField]
    Color m_AppleOrangeJuiceColor;
    
    [SerializeField]
    Color m_PeachAppleJuiceColor;
    
    [SerializeField]
    Color m_PeachOrangeJuiceColor;
    
    [SerializeField]
    Color m_OrangeAppleJuiceColor;
    
    [SerializeField]
    Color m_OrangePeachJuiceColor;

    [SerializeField]
    Material m_JuiceMaterial;

    [SerializeField]
    Animator m_JuiceAnimator;
    
    RaycastHit m_HitInfo;

    const string k_FillAnimTrigger = "Fill";
    const string k_EmptyAnimTrigger = "Empty";

    public enum JuiceTypes
    {
        AppleJuice,
        PeachJuice,
        OrangeJuice,
        ApplePeachJuice,
        AppleOrangeJuice,
        PeachAppleJuice,
        PeachOrangeJuice,
        OrangeAppleJuice,
        OrangePeachJuice
    }

    public JuiceTypes m_CurrentJuice;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Assert(m_MainCamera != null, "Camera can't be null");
            if (Physics.Raycast(m_MainCamera.ScreenPointToRay(Input.mousePosition), out m_HitInfo))
            {
                if (m_HitInfo.transform.TryGetComponent(out ButtonManager button))
                {
                    button.Press();
                    if (m_FirstSocket.currentFruit != null && m_SecondSocket.currentFruit != null)
                    {
                        m_CurrentJuice = MakeJuice(m_FirstSocket.currentFruit.FruitClassification, m_SecondSocket.currentFruit.FruitClassification);
                        FillJuice();
                    }
                }

                if (m_HitInfo.transform.TryGetComponent(out JuiceSelection juice))
                {
                    m_UIJuiceManager.SpawnJuice(GetJuiceColor(m_CurrentJuice));
                    m_JuiceAnimator.SetTrigger(k_EmptyAnimTrigger);
                }
            }
        }
    }

    void FillJuice()
    {
        // set color and animate juice
        Debug.Assert(m_JuiceMaterial != null, "Material needs to be set");
        m_JuiceMaterial.color = GetJuiceColor(m_CurrentJuice);
        m_JuiceAnimator.SetTrigger(k_FillAnimTrigger);
        
        Destroy(m_FirstSocket.fruitObject);
        Destroy(m_SecondSocket.fruitObject);
    }

    JuiceTypes MakeJuice(Fruit.FruitType firstFruit, Fruit.FruitType secondFruit)
        => (firstFruit, secondFruit) switch
        {
            (Fruit.FruitType.Apple, Fruit.FruitType.Apple) => JuiceTypes.AppleJuice,
            (Fruit.FruitType.Apple, Fruit.FruitType.Peach) => JuiceTypes.ApplePeachJuice,
            (Fruit.FruitType.Apple, Fruit.FruitType.Orange) => JuiceTypes.AppleOrangeJuice,
            (Fruit.FruitType.Peach, Fruit.FruitType.Peach) => JuiceTypes.PeachJuice,
            (Fruit.FruitType.Peach, Fruit.FruitType.Apple) => JuiceTypes.PeachAppleJuice,
            (Fruit.FruitType.Peach, Fruit.FruitType.Orange) => JuiceTypes.PeachOrangeJuice,
            (Fruit.FruitType.Orange, Fruit.FruitType.Orange) => JuiceTypes.OrangeJuice,
            (Fruit.FruitType.Orange, Fruit.FruitType.Apple) => JuiceTypes.OrangeAppleJuice,
            (Fruit.FruitType.Orange, Fruit.FruitType.Peach) => JuiceTypes.OrangePeachJuice,
            (_, _) => throw new ArgumentException("invalid juice formula")
        };

    Color GetJuiceColor(JuiceTypes juice) 
        => (juice) switch
        {
            JuiceTypes.AppleJuice => m_AppleJuiceColor,
            JuiceTypes.ApplePeachJuice => m_ApplePeachJuiceColor,
            JuiceTypes.AppleOrangeJuice => m_AppleOrangeJuiceColor,
            JuiceTypes.PeachJuice => m_PeachJuiceColor,
            JuiceTypes.PeachAppleJuice => m_PeachAppleJuiceColor,
            JuiceTypes.PeachOrangeJuice => m_PeachOrangeJuiceColor,
            JuiceTypes.OrangeJuice => m_OrangeJuiceColor,
            JuiceTypes.OrangeAppleJuice => m_OrangeAppleJuiceColor,
            JuiceTypes.OrangePeachJuice => m_OrangePeachJuiceColor,
            _ => Color.white
        };
}