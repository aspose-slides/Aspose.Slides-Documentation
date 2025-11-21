---
title: Diapositiva
type: docs
weight: 10
url: /es/net/examples/elements/slide/
keywords:
- ejemplo de diapositiva
- agregar diapositiva
- acceder a la diapositiva
- índice de diapositiva
- clonar diapositiva
- reordenar diapositivas
- eliminar diapositiva
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Administrar diapositivas en C# con Aspose.Slides: crear, clonar, reordenar, ocultar, establecer fondos y tamaño, aplicar transiciones y exportar para PowerPoint y OpenDocument."
---

Este artículo ofrece una serie de ejemplos que demuestran cómo trabajar con diapositivas usando **Aspose.Slides for .NET**. Aprenderá cómo agregar, acceder, clonar, reordenar y eliminar diapositivas usando la clase `Presentation`.

Cada ejemplo a continuación incluye una breve explicación seguida de un fragmento de código en C#.

## Añadir una diapositiva

Para agregar una nueva diapositiva, primero debe seleccionar un diseño. En este ejemplo, usamos el diseño `Blank` y añadimos una diapositiva en blanco a la presentación.
```csharp
static void Add_Slide()
{
    using var pres = new Presentation();

    // Cada diapositiva se basa en un diseño, que a su vez se basa en una diapositiva maestra.
    // Utilice el diseño Blank para crear una nueva diapositiva.
    var blankLayout = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Añadir una nueva diapositiva vacía usando el diseño seleccionado
    pres.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Tip:** Each slide layout is derived from a master slide, which defines the overall design and placeholder structure. The image below illustrates how master slides and their associated layouts are organized in PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## Access Slides by Index

You can access slides using their index, or find a slide’s index based on a reference. This is useful for iterating through or modifying specific slides.

```csharp
static void Access_Slide()
{
    // Por defecto, una presentación se crea con una diapositiva vacía
    using var pres = new Presentation();

    // Añadir otra diapositiva vacía
    pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // Acceder a las diapositivas por índice
    var firstSlide = pres.Slides[0];
    var secondSlide = pres.Slides[1];

    // Obtener el índice de la diapositiva a partir de una referencia, luego acceder a ella por índice
    var secondSlideIndex = pres.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = pres.Slides[secondSlideIndex];
}
```

## Clone a Slide

This example demonstrates how to clone an existing slide. The cloned slide is automatically added to the end of the slide collection.

```csharp
static void Clone_Slide()
{
    // Por defecto, la presentación contiene una diapositiva vacía
    using var pres = new Presentation();

    // Clonar la primera diapositiva; se añadirá al final de la presentación
    var clonedSlide = pres.Slides.AddClone(sourceSlide: pres.Slides[0]);

    // El índice de la diapositiva clonada es 1 (segunda diapositiva en la presentación)
    var clonedSlideIndex = pres.Slides.IndexOf(clonedSlide);
}
```

## Reorder Slides

You can change the order of slides by moving one to a new index. In this case, we move a cloned slide to the first position.

```csharp
static void ReOrder_Slide()
{
    using var pres = new Presentation();

    // Añadir un clon de la primera diapositiva (creada por defecto)
    var clonedSlide = pres.Slides.AddClone(pres.Slides[0]);

    // Mover el clon de la diapositiva a la primera posición (las demás se desplazan hacia abajo)
    pres.Slides.Reorder(index: 0, clonedSlide);
}
```

## Remove a Slide

To remove a slide, simply reference it and call `Remove`. This example adds a second slide and then removes the original, leaving only the new one.

```csharp
static void Remove_Slide()
{
    using var pres = new Presentation();

    // Añadir una nueva diapositiva vacía además de la primera diapositiva predeterminada
    var secondSlide = pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // Eliminar la primera diapositiva; solo quedará la diapositiva recién añadida
    var firstSlide = pres.Slides[0];
    pres.Slides.Remove(firstSlide);
}
```
