---
title: Transición de diapositiva
type: docs
weight: 110
url: /es/net/examples/elements/slide-transition/
keywords:
- transición de diapositiva
- agregar transición de diapositiva
- acceder a la transición de diapositiva
- eliminar transición de diapositiva
- duración de la transición
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Domina las transiciones de diapositivas en Aspose.Slides para .NET: agrega, personaliza y secuencia efectos y duraciones con ejemplos en C# para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo aplicar efectos y tiempos de transición de diapositivas con **Aspose.Slides for .NET**.

## **Agregar una transición de diapositiva**

Aplicar un efecto de transición de desvanecimiento a la primera diapositiva.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Aplicar una transición de desvanecimiento.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **Acceder a una transición de diapositiva**

Leer el tipo de transición asignado actualmente a una diapositiva.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // Acceder al tipo de transición.
    var type = slide.SlideShowTransition.Type;
}
```

## **Eliminar una transición de diapositiva**

Eliminar cualquier efecto de transición estableciendo el tipo a `None`.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Eliminar la transición estableciendo None.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **Establecer la duración de la transición**

Especificar cuánto tiempo se muestra la diapositiva antes de avanzar automáticamente.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // en milisegundos
}
```