using UnityEngine;

public class Fruit : MonoBehaviour
{
    bool m_IsHeld;

    public bool isHeld
    {
        get => m_IsHeld;
        set => m_IsHeld = value;
    }
    public enum FruitType
    {
        Apple,
        Orange,
        Peach
    }

    public FruitType FruitClassification;
}
