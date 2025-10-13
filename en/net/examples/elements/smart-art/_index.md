---
title: SmartArt
type: docs
weight: 140
url: /net/examples/elements/smartart/
keywords:
- code example
- SmartArt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Work with SmartArt in Aspose.Slides for .NET: create, edit, convert, and style diagrams with C# for PowerPoint and OpenDocument presentations."
---

This article demonstrates how to add SmartArt graphics, access them, remove them, and change layouts using **Aspose.Slides for .NET**.

## **Add SmartArt**

Insert a SmartArt graphic using one of the built-in layouts.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **Access SmartArt**

Retrieve the first SmartArt object on a slide.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **Remove SmartArt**

Delete a SmartArt shape from the slide.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **Change SmartArt Layout**

Update the layout type of an existing SmartArt graphic.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```
