---
title: Gruppenform
type: docs
weight: 170
url: /de/net/examples/elements/group-shape/
keywords:
- Gruppe
- Gruppenform hinzufügen
- Zugriff auf Gruppenform
- Gruppenform entfernen
- Formen entgruppieren
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie gruppierte Formen in Aspose.Slides für .NET: Erstellen, verschachteln, ausrichten, neu anordnen und formatieren Sie Gruppenformen mit C#-Beispielen in PPT-, PPTX- und ODP-Präsentationen."
---
Beispiele zum Erstellen von Gruppen von Formen, zum Zugriff darauf, zum Aufheben von Gruppierungen und zum Entfernen mit **Aspose.Slides for .NET**.

## **Gruppenform hinzufügen**

Erstellen Sie eine Gruppe, die zwei Grundformen enthält.

```csharp
static void AddGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
}
```

## **Zugriff auf eine Gruppenform**

Rufen Sie die erste Gruppenform von einer Folie ab.

```csharp
static void AccessGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
}
```

## **Entfernen einer Gruppenform**

Löschen Sie eine Gruppenform von der Folie.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **Formen entgruppieren**

Verschieben Sie Formen aus einem Gruppencontainer heraus.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Form aus der Gruppe verschieben.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```