---
title: OleObject
type: docs
weight: 210
url: /net/examples/elements/leobject
---

Demonstrates embedding a file as an OLE object and updating its data using **Aspose.Slides for .NET**.

## Add an OLE Object

Embed a PDF file into the presentation.

```csharp
static void Add_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);
}
```

## Access an OLE Object

Retrieve the first OLE object frame on a slide.

```csharp
static void Access_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    var firstOle = slide.Shapes.OfType<IOleObjectFrame>().First();
}
```

## Remove an OLE Object

Delete an embedded OLE object from the slide.

```csharp
static void Remove_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    slide.Shapes.Remove(ole);
}
```

## Update OLE Object Data

Replace the data embedded in an existing OLE object.

```csharp
static void Update_Ole_Object_Data()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    var newData = new OleEmbeddedDataInfo(File.ReadAllBytes("Picture.png"), "png");
    ole.SetEmbeddedData(newData);
}
```
