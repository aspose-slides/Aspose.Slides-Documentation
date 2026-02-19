---
title: Animación
type: docs
weight: 100
url: /es/net/examples/elements/animation/
keywords:
- animación
- agregar animación
- acceder animación
- eliminar animación
- secuencia de animación
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Explore ejemplos de animación de Aspose.Slides for .NET: añada, secuencie y personalice efectos y transiciones con C# para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo crear animaciones simples y gestionar su secuencia usando **Aspose.Slides for .NET**.

## **Agregar una animación**

Cree una forma rectangular y aplique un efecto de desvanecimiento activado al hacer clic.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Efecto de desvanecimiento.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **Acceder a una animación**

Recupere el primer efecto de animación de la línea de tiempo de la diapositiva.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Acceder al primer efecto de animación.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **Eliminar una animación**

Elimine un efecto de animación de la secuencia.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Eliminar el efecto.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **Secuenciar animaciones**

Agregue varios efectos y demuestre el orden en que ocurren las animaciones.

```csharp
static void SequenceAnimations()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

    var sequence = slide.Timeline.MainSequence;
    sequence.AddEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
    sequence.AddEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```