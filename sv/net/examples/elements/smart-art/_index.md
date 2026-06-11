---
title: SmartArt
type: docs
weight: 140
url: /sv/net/examples/elements/smart-art/
keywords:
- SmartArt
- lägga till SmartArt
- åtkomst till SmartArt
- ta bort SmartArt
- SmartArt-layout
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Arbeta med SmartArt i Aspose.Slides för .NET: skapa, redigera, konvertera och formatera diagram med C# för PowerPoint- och OpenDocument-presentationer."
---
Den här artikeln visar hur du lägger till SmartArt-grafik, får åtkomst till dem, tar bort dem och ändrar layouter med **Aspose.Slides for .NET**.

## **Lägg till SmartArt**
```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **Åtkomst till SmartArt**
```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **Ta bort SmartArt**
```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **Ändra SmartArt-layout**
```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```