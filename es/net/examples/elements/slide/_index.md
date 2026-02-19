---
title: Diapositiva
type: docs
weight: 10
url: /es/net/examples/elements/slide/
keywords:
- diapositiva
- agregar diapositiva
- acceder a diapositiva
- índice de diapositiva
- clonar diapositiva
- reordenar diapositivas
- eliminar diapositiva
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Controla diapositivas en Aspose.Slides para .NET: crea, clona, reordena, cambia el tamaño, establece fondos y aplica transiciones con C# para presentaciones PPT, PPTX y ODP."
---
Este artículo ofrece una serie de ejemplos que demuestran cómo trabajar con diapositivas usando **Aspose.Slides for .NET**. Aprenderás cómo agregar, acceder, clonar, reordenar y eliminar diapositivas mediante la clase `Presentation`.

Cada ejemplo a continuación incluye una breve explicación seguida de un fragmento de código en C#.

## **Agregar una diapositiva**

Para agregar una nueva diapositiva, primero debes seleccionar un diseño. En este ejemplo, usamos el diseño `Blank` y añadimos una diapositiva vacía a la presentación.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // Cada diapositiva se basa en un diseño, que a su vez se basa en una diapositiva maestra.
    // Usa el diseño Blank para crear una nueva diapositiva.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Añade una nueva diapositiva vacía usando el diseño seleccionado.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Nota:** Cada diseño de diapositiva se deriva de una diapositiva maestra, que define el diseño general y la estructura de los marcadores de posición. La imagen a continuación ilustra cómo se organizan las diapositivas maestras y sus diseños asociados en PowerPoint.

![Relación entre maestro y diseño](master-layout-slide.png)

## **Acceder a diapositivas por índice**

Puedes acceder a las diapositivas usando su índice, o encontrar el índice de una diapositiva a partir de una referencia. Esto es útil para iterar o modificar diapositivas específicas.

```csharp
static void AccessSlide()
{
    // Por defecto, una presentación se crea con una diapositiva vacía.
    using var presentation = new Presentation();

    // Añade otra diapositiva vacía.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Accede a las diapositivas por índice.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // Obtén el índice de la diapositiva a partir de una referencia y luego accede a ella por índice.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **Clonar una diapositiva**

Este ejemplo muestra cómo clonar una diapositiva existente. La diapositiva clonada se añade automáticamente al final de la colección de diapositivas.

```csharp
static void CloneSlide()
{
    // Por defecto, la presentación contiene una diapositiva vacía.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Clona la primera diapositiva; se añadirá al final de la presentación.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // El índice de la diapositiva clonada es 1 (segunda diapositiva en la presentación).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **Reordenar diapositivas**

Puedes cambiar el orden de las diapositivas moviendo una a un nuevo índice. En este caso, movemos una diapositiva clonada a la primera posición.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Añade una copia de la primera diapositiva (creada por defecto).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // Mueve la diapositiva clonada a la primera posición (las demás se desplazan hacia abajo).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Eliminar una diapositiva**

Para eliminar una diapositiva, simplemente haz referencia a ella y llama a `Remove`. Este ejemplo añade una segunda diapositiva y luego elimina la original, quedando solo la nueva.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // Añade una nueva diapositiva vacía además de la primera diapositiva predeterminada.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Elimina la primera diapositiva; solo quedará la diapositiva recién añadida.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```