---
title: OLE-Objekt
type: docs
weight: 210
url: /de/net/examples/elements/ole-object/
keywords:
- Beispiel für OLE-Objekt
- OLE-Objekt hinzufügen
- Zugriff auf OLE-Objekt
- OLE-Objekt entfernen
- OLE-Objekt aktualisieren
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Arbeiten Sie mit OLE-Objekten in C# mithilfe von Aspose.Slides: Einbetten oder Aktualisieren von Dateien, Festlegen von Symbolen oder Links, Extrahieren von Inhalten, Steuern des Verhaltens für PPT, PPTX und ODP."
---

Demonstriert das Einbetten einer Datei als OLE-Objekt und das Aktualisieren ihrer Daten mit **Aspose.Slides for .NET**.

## **OLE-Objekt hinzufügen**

Betten Sie eine PDF-Datei in die Präsentation ein.
```csharp
static void Add_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);
}
```


## **OLE-Objekt zugreifen**

Rufen Sie den ersten OLE-Objektrahmen in einer Folie ab.
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


## **OLE-Objekt entfernen**

Löschen Sie ein eingebettetes OLE-Objekt von der Folie.
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


## **OLE-Objektdaten aktualisieren**

Ersetzen Sie die in einem vorhandenen OLE-Objekt eingebetteten Daten.
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
