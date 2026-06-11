---
title: Gruppform
type: docs
weight: 170
url: /sv/net/examples/elements/group-shape/
keywords:
- grupp
- lägg till gruppform
- åtkomst till gruppform
- ta bort gruppform
- avgruppera former
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera grupperade former i Aspose.Slides för .NET: skapa, nästla, justera, omordna och formge gruppformer med C#-exempel i PPT-, PPTX- och ODP-presentationer."
---
Exempel på att skapa grupper av former, komma åt dem, avgruppera och ta bort dem med **Aspose.Slides för .NET**.

## **Lägg till en gruppform**

Skapa en grupp som innehåller två grundläggande former.

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

## **Åtkomst till en gruppform**

Hämta den första gruppformen från en bild.

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

## **Ta bort en gruppform**

Radera en gruppform från bilden.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **Avgruppera former**

Flytta former ur en gruppbehållare.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Flytta formen ur gruppen.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```