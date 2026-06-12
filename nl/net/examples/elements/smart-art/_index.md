---
title: SmartArt
type: docs
weight: 140
url: /nl/net/examples/elements/smart-art/
keywords:
- SmartArt
- SmartArt toevoegen
- SmartArt openen
- SmartArt verwijderen
- SmartArt-indeling
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Werk met SmartArt in Aspose.Slides voor .NET: maak, bewerk, converteer en styleer diagrammen met C# voor PowerPoint- en OpenDocument-presentaties."
---
Dit artikel laat zien hoe je SmartArt-afbeeldingen kunt toevoegen, er toegang tot kunt krijgen, ze kunt verwijderen en indelingen kunt wijzigen met behulp van **Aspose.Slides for .NET**.

## **SmartArt toevoegen**

Voeg een SmartArt-afbeelding in met een van de meegeleverde indelingen.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **SmartArt openen**

Haal het eerste SmartArt-object op een dia op.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **SmartArt verwijderen**

Verwijder een SmartArt-vorm van de dia.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **SmartArt-indeling wijzigen**

Werk het indelingstype bij van een bestaande SmartArt-afbeelding.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```