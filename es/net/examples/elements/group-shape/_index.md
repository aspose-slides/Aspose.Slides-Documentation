---
title: Forma de grupo
type: docs
weight: 170
url: /es/net/examples/elements/group-shape/
keywords:
- grupo
- agregar forma de grupo
- acceder forma de grupo
- eliminar forma de grupo
- desagrupar formas
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Administrar formas agrupadas en Aspose.Slides for .NET: crear, anidar, alinear, reordenar y dar estilo a los grupos de formas con ejemplos en C# en presentaciones PPT, PPTX y ODP."
---
Ejemplos de creación de grupos de formas, acceso a los mismos, desagrupación y eliminación utilizando **Aspose.Slides for .NET**.

## **Agregar un grupo de formas**

Crea un grupo que contiene dos formas básicas.

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

## **Acceder a un grupo de formas**

Obtén el primer grupo de formas de una diapositiva.

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

## **Eliminar un grupo de formas**

Elimina un grupo de formas de la diapositiva.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **Desagrupar formas**

Mueve las formas fuera de un contenedor de grupo.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Mover la forma fuera del grupo.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```