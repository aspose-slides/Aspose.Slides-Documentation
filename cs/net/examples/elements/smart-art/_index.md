---
title: SmartArt
type: docs
weight: 140
url: /cs/net/examples/elements/smart-art/
keywords:
- SmartArt
- přidat SmartArt
- přístup SmartArt
- odstranit SmartArt
- rozvržení SmartArt
- ukázkový kód
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Práce se SmartArt v Aspose.Slides pro .NET: vytváření, úprava, konverze a stylování diagramů pomocí C# pro prezentace PowerPoint a OpenDocument."
---
Tento článek demonstruje, jak přidávat grafické objekty SmartArt, přistupovat k nim, odstraňovat je a měnit rozvržení pomocí **Aspose.Slides for .NET**.

## **Přidat SmartArt**

Vložte grafiku SmartArt pomocí jednoho ze zabudovaných rozvržení.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **Přístup k SmartArt**

Získejte první objekt SmartArt na snímku.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **Odstranit SmartArt**

Odstraňte tvar SmartArt ze snímku.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **Změnit rozvržení SmartArt**

Aktualizujte typ rozvržení existující grafiky SmartArt.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```