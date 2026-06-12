---
title: Oggetto OLE
type: docs
weight: 210
url: /it/net/examples/elements/ole-object/
keywords:
- oggetto OLE
- aggiungere oggetto OLE
- accedere oggetto OLE
- rimuovere oggetto OLE
- aggiornare oggetto OLE
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci gli oggetti OLE in Aspose.Slides per .NET: inserisci, collega, aggiorna ed estrai contenuti incorporati con C# nelle presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come incorporare un file come oggetto OLE e aggiornare i suoi dati utilizzando **Aspose.Slides for .NET**.

## **Aggiungere un oggetto OLE**

Incorpora un file PDF nella presentazione.

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

## **Accedere a un oggetto OLE**

Recupera il primo fotogramma dell'oggetto OLE su una diapositiva.

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

## **Rimuovere un oggetto OLE**

Elimina un oggetto OLE incorporato dalla diapositiva.

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

## **Aggiornare i dati dell'oggetto OLE**

Sostituisci i dati incorporati in un oggetto OLE esistente.

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