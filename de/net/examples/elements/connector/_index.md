---
title: Verbinder
type: docs
weight: 190
url: /de/net/examples/elements/connector/
keywords:
- Verbinder
- Verbinder hinzufügen
- Verbinder abrufen
- Verbinder entfernen
- Formen neu verbinden
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Verbinder zwischen Formen mit Aspose.Slides für .NET hinzufügen, routen und formatieren, mit C#-Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert, wie man Formen mit Verbinder‑Objekten verbindet und deren Ziele mithilfe von **Aspose.Slides for .NET** ändert.

## **Verbinder hinzufügen**

Fügen Sie ein Verbinder‑Objekt zwischen zwei Punkten auf der Folie ein.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **Zugriff auf einen Verbinder**

Rufen Sie das zuerst zur Folie hinzugefügte Verbinder‑Objekt ab.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **Verbinder entfernen**

Löschen Sie einen Verbinder von der Folie.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **Formen neu verbinden**

Verbinden Sie einen Verbinder mit zwei Formen, indem Sie Start‑ und End‑Ziele zuweisen.

```csharp
static void ReconnectShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    connector.StartShapeConnectedTo = shape1;
    connector.EndShapeConnectedTo = shape2;
}
```