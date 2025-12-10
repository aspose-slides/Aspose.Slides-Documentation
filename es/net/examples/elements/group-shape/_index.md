---
title: GroupShape
type: docs
weight: 170
url: /es/net/examples/elements/group-shape/
keywords:
- ejemplo de grupo
- agregar forma de grupo
- acceder a forma de grupo
- eliminar forma de grupo
- desagrupar formas
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Trabajar con formas de grupo en C# usando Aspose.Slides: crear y desagrupar, reordenar formas hijas, establecer transformaciones y límites en PowerPoint y OpenDocument."
---

Ejemplos de creación de grupos de formas, acceso a ellos, desagrupar y eliminar usando **Aspose.Slides for .NET**.

## **Agregar una Forma de Grupo**

Crear un grupo que contenga dos formas básicas.
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


## **Acceder a una Forma de Grupo**

Obtener la primera forma de grupo de una diapositiva.
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


## **Eliminar una Forma de Grupo**

Eliminar una forma de grupo de la diapositiva.
```csharp
static void Remove_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```


## **Desagrupar Formas**

Mover las formas fuera de un contenedor de grupo.
```csharp
static void Ungroup_Shapes()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Mover la forma fuera del grupo
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```
