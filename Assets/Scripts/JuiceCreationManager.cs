using System;
using UnityEngine;

public class JuiceCreationManager : MonoBehaviour
{
    [SerializeField]
    FruitSocket m_FirstSocket;

    [SerializeField]
    FruitSocket m_SecondSocket;

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

    public JuiceTypes CurrentJuice;

    public bool TryCreateJuice()
    {
        if (m_FirstSocket.currentFruit == null || m_SecondSocket.currentFruit == null)
        {
            Debug.Log($"Juice not set in socket");
            return false;
        }

        CurrentJuice = MakeJuice(m_FirstSocket.currentFruit.FruitClassification, m_SecondSocket.currentFruit.FruitClassification);
        FillJuice();
        return true;
    }

    public Color GetCurrentJuiceColor()
    {
        return GetJuiceColor(CurrentJuice);
    }

    void FillJuice()
    {
        // set color and animate juice
        Debug.Assert(m_JuiceMaterial != null, "Material needs to be set");
        m_JuiceMaterial.color = GetJuiceColor(CurrentJuice);
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

    Color GetJuiceColorSwitch(JuiceTypes juice)
    {
        Color retVal = Color.white;

        switch (juice)
        {
            case JuiceTypes.AppleJuice:
                retVal = m_AppleJuiceColor;
                break;
            case JuiceTypes.ApplePeachJuice:
                retVal = m_ApplePeachJuiceColor;
                break;
            case JuiceTypes.AppleOrangeJuice:
                retVal = m_AppleOrangeJuiceColor;
                break;
            case JuiceTypes.PeachJuice:
                retVal = m_PeachJuiceColor;
                break;
            case JuiceTypes.PeachAppleJuice:
                retVal = m_PeachAppleJuiceColor;
                break;
            case JuiceTypes.PeachOrangeJuice:
                retVal = m_PeachOrangeJuiceColor;
                break;
            case JuiceTypes.OrangeJuice:
                retVal = m_OrangeJuiceColor;
                break;
            case JuiceTypes.OrangeAppleJuice:
                retVal = m_OrangeAppleJuiceColor;
                break;
            case JuiceTypes.OrangePeachJuice:
                retVal = m_OrangePeachJuiceColor;
                break;
        }

        return retVal;
        
    }
}
