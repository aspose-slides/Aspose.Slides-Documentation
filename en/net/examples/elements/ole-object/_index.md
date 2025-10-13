---
title: OLE Object
type: docs
weight: 210
url: /net/examples/elements/oleobject/
keywords:
- code example
- OLE object
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Handle OLE objects in Aspose.Slides for .NET: insert, link, update, and extract embedded content with C# in PPT, PPTX, and ODP presentations."
---

This article demonstrates embedding a file as an OLE object and updating its data using **Aspose.Slides for .NET**.

## **Add an OLE Object**

Embed a PDF file into the presentation.

```csharp
static void AddOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);
}
```

## **Access an OLE Object**

Retrieve the first OLE object frame on a slide.

```csharp
static void AccessOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    var firstOleFrame = slide.Shapes.OfType<IOleObjectFrame>().First();
}
```

## **Remove an OLE Object**

Delete an embedded OLE object from the slide.

```csharp
static void RemoveOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    slide.Shapes.Remove(oleFrame);
}
```

## **Update OLE Object Data**

Replace the data embedded in an existing OLE object.

```csharp
static void UpdateOleObjectData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    var newData = new OleEmbeddedDataInfo(File.ReadAllBytes("Picture.png"), "png");
    oleFrame.SetEmbeddedData(newData);
}
```
