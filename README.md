# Juice Maker
Sample project utilizing C# 8.0 syntax to showcase different use cases in a Unity demo

![FruitJuice](https://user-images.githubusercontent.com/2120584/115343688-2b94be00-a161-11eb-9f56-00bb15798aed.JPG)

## [Switch Expression](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#switch-expressions)
Used [here](https://github.com/DanMillerDev/CSharp8_JuiceMaker/blob/main/Assets/Scripts/JuiceCreationManager.cs#L108-L121) in `JuiceCreationManager.cs` to return a color value based on a JuiceType enum input 

```    
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
```

## [Tuple Pattern](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#tuple-patterns)
Used [here](https://github.com/DanMillerDev/CSharp8_JuiceMaker/blob/main/Assets/Scripts/JuiceCreationManager.cs#L93-L106) in `JuiceCreationManager.cs` to return a Juice Type enum based on a tuple of two Fruit Types

```
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
```

## [Nullable reference types](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#nullable-reference-types)
Used in `FruitSocket.cs` for current Fruit and Game Object references. 

```
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
```

## [Null-coalescing assignment](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#null-coalescing-assignment)
Used [here](https://github.com/DanMillerDev/CSharp8_JuiceMaker/blob/main/Assets/Scripts/JuiceStorage.cs#L35) in `JuiceStorage.cs` to initialize a List of game objects if there haven't been any assigned in the inspector
```
m_GlassesInBag ??= new List<GameObject>();
```
