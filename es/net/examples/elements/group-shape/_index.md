---
title: Forma de grupo
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
description: "Trabaja con grupos de formas en C# usando Aspose.Slides: crea y desagrupa, reordena las formas hijas, establece transformaciones y límites en PowerPoint y OpenDocument."
---

Ejemplos de creación de grupos de formas, acceso a ellos, desagrupación y eliminación usando **Aspose.Slides for .NET**.

## Agregar una forma de grupo

Crear un grupo que contiene dos formas básicas.
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


## Acceder a una forma de grupo

Recuperar la primera forma de grupo de una diapositiva.
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


## Eliminar una forma de grupo

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


## Desagrupar formas

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
