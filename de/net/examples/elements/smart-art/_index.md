---
title: SmartArt
type: docs
weight: 140
url: /de/net/examples/elements/smartart/
keywords:
- SmartArt-Beispiel
- SmartArt hinzufügen
- SmartArt zugreifen
- SmartArt entfernen
- SmartArt-Layout
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen und bearbeiten Sie SmartArt in C# mit Aspose.Slides: Knoten hinzufügen, Layouts und Stile ändern, präzise in Formen konvertieren und für PPT, PPTX und ODP exportieren."
---

Zeigt, wie man SmartArt‑Grafiken hinzufügt, darauf zugreift, sie entfernt und Layouts ändert, wobei **Aspose.Slides for .NET** verwendet wird.

## Add SmartArt
Fügen Sie eine SmartArt‑Grafik mithilfe eines der integrierten Layouts ein.
```csharp
static void Add_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```


## Access SmartArt
Rufen Sie das erste SmartArt‑Objekt auf einer Folie ab.
```csharp
static void Access_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```


## Remove SmartArt
Löschen Sie eine SmartArt‑Form von der Folie.
```csharp
static void Remove_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smart);
}
```


## Change SmartArt Layout
Aktualisieren Sie den Layouttyp einer vorhandenen SmartArt‑Grafik.
```csharp
static void Change_SmartArt_Layout()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smart.Layout = SmartArtLayoutType.VerticalPictureList;
}
```
