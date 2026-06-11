---
title: OLE-objekt
type: docs
weight: 210
url: /sv/net/examples/elements/ole-object/
keywords:
- OLE-objekt
- lägga till OLE-objekt
- komma åt OLE-objekt
- ta bort OLE-objekt
- uppdatera OLE-objekt
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera OLE-objekt i Aspose.Slides för .NET: infoga, länka, uppdatera och extrahera inbäddat innehåll med C# i PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur man bäddar in en fil som ett OLE-objekt och uppdaterar dess data med **Aspose.Slides for .NET**.

## **Lägg till ett OLE-objekt**

Bädda in en PDF-fil i presentationen.

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

## **Åtkomst till ett OLE-objekt**

Hämta den första OLE-objekt-ramen på en bild.

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

## **Ta bort ett OLE-objekt**

Ta bort ett inbäddat OLE-objekt från bilden.

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

## **Uppdatera OLE-objektdata**

Ersätt den data som är inbäddad i ett befintligt OLE-objekt.

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