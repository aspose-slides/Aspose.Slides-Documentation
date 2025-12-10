---
title: Gruppenform
type: docs
weight: 170
url: /de/net/examples/elements/group-shape/
keywords:
- Gruppenbeispiel
- Gruppe hinzufügen
- Zugriff auf Gruppenform
- Gruppe entfernen
- Gruppen aufheben
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Arbeiten Sie mit Gruppenformen in C# mit Aspose.Slides: Erstellen und Aufheben von Gruppen, Neuordnen von untergeordneten Formen, Festlegen von Transformationen und Begrenzungen in PowerPoint und OpenDocument."
---

Beispiele für das Erstellen von Gruppen von Formen, den Zugriff darauf, das Aufheben von Gruppen und das Entfernen mit **Aspose.Slides for .NET**.

## **Gruppenform hinzufügen**

Erstellen Sie eine Gruppe, die zwei Grundformen enthält.
```csharp
static void Add_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
}
```


## **Zugriff auf eine Gruppenform**

Rufen Sie die erste Gruppenform aus einer Folie ab.
```csharp
static void Access_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
}
```


## **Entfernen einer Gruppenform**

Löschen Sie eine Gruppenform von der Folie.
```csharp
static void Remove_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```


## **Gruppen aufheben**

Verschieben Sie Formen aus einem Gruppencontainer heraus.
```csharp
static void Ungroup_Shapes()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Form aus der Gruppe verschieben
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```
