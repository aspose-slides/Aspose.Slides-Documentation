---
title: Gruppenform
type: docs
weight: 170
url: /de/net/examples/elements/group-shape/
keywords:
- Gruppenbeispiel
- Gruppenform hinzufügen
- Gruppenform zugreifen
- Gruppenform entfernen
- Gruppierung aufheben
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Arbeiten Sie mit Gruppenformen in C# mit Aspose.Slides: erstellen und Gruppierung aufheben, untergeordnete Formen umordnen, Transformationen und Begrenzungen für PowerPoint und OpenDocument festlegen."
---

Beispiele zum Erstellen von Gruppen von Formen, zum Zugriff auf diese, zum Aufheben von Gruppierungen und zum Entfernen mit **Aspose.Slides for .NET**.

## Gruppe hinzufügen

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


## Auf eine Gruppe zugreifen

Rufen Sie das erste Gruppen‑Shape von einer Folie ab.
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


## Gruppe entfernen

Löschen Sie ein Gruppen‑Shape von der Folie.
```csharp
static void Remove_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```


## Gruppierung aufheben

Bewegen Sie Formen aus einem Gruppencontainer heraus.
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
