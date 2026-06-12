---
title: Groepvorm
type: docs
weight: 170
url: /nl/net/examples/elements/group-shape/
keywords:
- groep
- groepvorm toevoegen
- groepvorm benaderen
- groepvorm verwijderen
- groepvormen losmaken
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer gegroepeerde vormen in Aspose.Slides voor .NET: maak, nest, uitlijn, herschik en styleer groepsvormen met C#-voorbeelden in PPT-, PPTX- en ODP-presentaties."
---
Voorbeelden voor het maken van groepen van vormen, het benaderen ervan, het opheffen van de groepsstructuur en het verwijderen met **Aspose.Slides for .NET**.

## **Groepvorm toevoegen**

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

## **Groepvorm benaderen**

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

## **Groepvorm verwijderen**

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **Groepvormen losmaken**

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Verplaats vorm uit de groep.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```