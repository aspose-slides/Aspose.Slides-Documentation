---
title: OLE-object
type: docs
weight: 210
url: /nl/net/examples/elements/ole-object/
keywords:
- OLE-object
- OLE-object toevoegen
- toegang tot OLE-object
- OLE-object verwijderen
- OLE-object bijwerken
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer OLE-objecten in Aspose.Slides for .NET: voeg in, koppel, werk bij en extraheer ingesloten inhoud met C# in PPT-, PPTX- en ODP-presentaties."
---
Dit artikel toont hoe u een bestand kunt insluiten als OLE-object en de gegevens kunt bijwerken met **Aspose.Slides for .NET**.

## **OLE-object toevoegen**

Een PDF-bestand invoegen in de presentatie.

```csharp
static void AddOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
}
```

## **Toegang tot een OLE-object**

Haal het eerste OLE-objectframe op een dia op.

```csharp
static void AccessOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var firstOleFrame = slide.Shapes.OfType<IOleObjectFrame>().First();
}
```

## **Verwijder een OLE-object**

Verwijder een ingesloten OLE-object van de dia.

```csharp
static void RemoveOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    slide.Shapes.Remove(oleFrame);
}
```

## **OLE-objectgegevens bijwerken**

Vervang de gegevens die in een bestaand OLE-object zijn ingesloten.

```csharp
static void UpdateOleObjectData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var newData = File.ReadAllBytes("Picture.png");
    var newDataInfo = new OleEmbeddedDataInfo(newData, "png");
    oleFrame.SetEmbeddedData(newDataInfo);
}
```