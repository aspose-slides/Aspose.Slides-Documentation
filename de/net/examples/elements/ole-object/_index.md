---
title: OLE-Objekt
type: docs
weight: 210
url: /de/net/examples/elements/ole-object/
keywords:
- OLE-Objekt
- OLE-Objekt hinzufügen
- OLE-Objekt abrufen
- OLE-Objekt entfernen
- OLE-Objekt aktualisieren
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie OLE-Objekte in Aspose.Slides für .NET: Einfügen, Verknüpfen, Aktualisieren und Extrahieren eingebetteter Inhalte mit C# in PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert das Einbetten einer Datei als OLE-Objekt und das Aktualisieren ihrer Daten mit **Aspose.Slides for .NET**.

## **OLE-Objekt hinzufügen**

Betten Sie eine PDF-Datei in die Präsentation ein.

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

## **Zugriff auf ein OLE-Objekt**

Rufen Sie den ersten OLE-Objektrahmen auf einer Folie ab.

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

## **Ein OLE-Objekt entfernen**

Löschen Sie ein eingebettetes OLE-Objekt von der Folie.

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

## **OLE-Objektdaten aktualisieren**

Ersetzen Sie die in einem vorhandenen OLE-Objekt eingebetteten Daten.

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