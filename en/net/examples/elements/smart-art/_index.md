---
title: SmartArt
type: docs
weight: 140
url: /net/examples/elements/smartart/
keywords:
- SmartArt example
- add SmartArt
- access SmartArt
- remove SmartArt
- SmartArt layout
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Build and edit SmartArt in C# with Aspose.Slides: add nodes, change layouts and styles, convert to shapes with precision, and export for PPT, PPTX and ODP."
---

Shows how to add SmartArt graphics, access them, remove them, and change layouts using **Aspose.Slides for .NET**.

## **Add SmartArt**

Insert a SmartArt graphic using one of the built-in layouts.

```csharp
static void Add_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **Access SmartArt**

Retrieve the first SmartArt object on a slide.

```csharp
static void Access_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **Remove SmartArt**

Delete a SmartArt shape from the slide.

```csharp
static void Remove_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smart);
}
```

## **Change SmartArt Layout**

Update the layout type of an existing SmartArt graphic.

```csharp
static void Change_SmartArt_Layout()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smart.Layout = SmartArtLayoutType.VerticalPictureList;
}
```
