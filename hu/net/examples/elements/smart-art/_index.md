---
title: SmartArt
type: docs
weight: 140
url: /hu/net/examples/elements/smart-art/
keywords:
- SmartArt
- SmartArt hozzáadása
- SmartArt elérése
- SmartArt eltávolítása
- SmartArt elrendezés
- kódrészlet
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Munká SmartArt használatával az Aspose.Slides for .NET-ben: diagramok létrehozása, szerkesztése, konvertálása és stílusozása C#-ban PowerPoint és OpenDocument prezentációkhoz."
---
Ez a cikk bemutatja, hogyan lehet SmartArt grafikákat hozzáadni, elérni, eltávolítani és módosítani az elrendezéseket a **Aspose.Slides for .NET** segítségével.

## **SmartArt hozzáadása**

Szúrjon be egy SmartArt grafikát az egyik beépített elrendezés használatával.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **SmartArt elérése**

Hozza meg a dián lévő első SmartArt objektumot.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **SmartArt eltávolítása**

Törölje a SmartArt alakzatot a diáról.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **SmartArt elrendezés módosítása**

Frissítse egy létező SmartArt grafika elrendezés típusát.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```