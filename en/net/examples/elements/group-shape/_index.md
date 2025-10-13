---
title: Group Shape
type: docs
weight: 170
url: /net/examples/elements/groupshape/
keywords:
- code example
- group shape
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Manage grouped shapes in Aspose.Slides for .NET: create, nest, align, reorder, and style group shapes with C# examples in PPT, PPTX, and ODP presentations."
---

Examples for creating groups of shapes, accessing them, ungrouping, and removal using **Aspose.Slides for .NET**.

## **Add a Group Shape**

Create a group containing two basic shapes.

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

## **Access a Group Shape**

Retrieve the first group shape from a slide.

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

## **Remove a Group Shape**

Delete a group shape from the slide.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **Ungroup Shapes**

Move shapes out of a group container.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Move shape out of the group.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```
