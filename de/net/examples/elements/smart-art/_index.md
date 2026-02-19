---
title: SmartArt
type: docs
weight: 140
url: /de/net/examples/elements/smart-art/
keywords:
- SmartArt
- SmartArt hinzufügen
- SmartArt abrufen
- SmartArt entfernen
- SmartArt-Layout
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Arbeiten Sie mit SmartArt in Aspose.Slides für .NET: Erstellen, bearbeiten, konvertieren und formatieren Sie Diagramme mit C# für PowerPoint‑ und OpenDocument‑Präsentationen."
---
Dieser Artikel zeigt, wie man SmartArt-Grafiken hinzufügt, darauf zugreift, sie entfernt und Layouts ändert, wobei **Aspose.Slides for .NET** verwendet wird.

## **SmartArt hinzufügen**

Fügen Sie eine SmartArt-Grafik ein, indem Sie eines der integrierten Layouts verwenden.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **Zugriff auf SmartArt**

Rufen Sie das erste SmartArt-Objekt auf einer Folie ab.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **SmartArt entfernen**

Löschen Sie eine SmartArt-Form von der Folie.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **SmartArt-Layout ändern**

Aktualisieren Sie den Layouttyp einer vorhandenen SmartArt-Grafik.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```