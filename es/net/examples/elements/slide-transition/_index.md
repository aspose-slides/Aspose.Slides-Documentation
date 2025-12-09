---
title: TransiciónDeDiapositiva
type: docs
weight: 110
url: /es/net/examples/elements/slide-transition/
keywords:
- ejemplo de transición de diapositiva
- agregar transición de diapositiva
- acceder a transición de diapositiva
- eliminar transición de diapositiva
- duración de la transición
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Controla las transiciones de diapositivas en C# con Aspose.Slides: elige tipos, velocidad, sonido y temporización para perfeccionar presentaciones en PPT, PPTX y ODP."
---

Demuestra cómo aplicar efectos de transición de diapositivas y sincronizaciones con **Aspose.Slides for .NET**.

## Añadir una transición de diapositiva
Aplica un efecto de transición de desvanecimiento a la primera diapositiva.
```csharp
static void Add_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Aplicar una transición de desvanecimiento
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```


## Acceder a una transición de diapositiva
Lee el tipo de transición asignado actualmente a una diapositiva.
```csharp
static void Access_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Push;

    // Acceder al tipo de transición
    var type = slide.SlideShowTransition.Type;
}
```


## Eliminar una transición de diapositiva
Elimina cualquier efecto de transición estableciendo el tipo a `None`.
```csharp
static void Remove_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Eliminar la transición estableciendo none
    slide.SlideShowTransition.Type = TransitionType.None;
}
```


## Establecer duración de la transición
Especifica cuánto tiempo se muestra la diapositiva antes de avanzar automáticamente.
```csharp
static void Set_Transition_Duration()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // en milisegundos
}
```
