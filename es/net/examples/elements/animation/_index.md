---
title: Animación
type: docs
weight: 100
url: /es/net/examples/elements/animation/
keywords:
- ejemplo de animación
- añadir animación
- acceder a animación
- eliminar animación
- secuencia de animación
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Domina las animaciones de diapositivas en C# con Aspose.Slides: agrega, edita y elimina efectos, tiempos y disparadores para crear presentaciones dinámicas en PPT, PPTX y ODP."
---

Muestra cómo crear animaciones simples y gestionar su secuencia usando **Aspose.Slides for .NET**.

## Añadir una animación

Cree una forma rectangular y aplique un efecto de desvanecimiento activado al hacer clic.
```csharp
static void Add_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Efecto de desvanecimiento
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```


## Acceder a una animación

Recupere el primer efecto de animación de la línea de tiempo de la diapositiva.
```csharp
static void Access_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);

    // Acceder al primer efecto de animación
    var effect = slide.Timeline.MainSequence[0];
}
```


## Eliminar una animación

Elimine un efecto de animación de la secuencia.
```csharp
static void Remove_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);

    // Eliminar el efecto
    slide.Timeline.MainSequence.Remove(effect);
}
```


## Secuenciar animaciones

Añada varios efectos y demuestre el orden en que ocurren las animaciones.
```csharp
static void Sequence_Animations()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

    var seq = slide.Timeline.MainSequence;
    seq.AddEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
    seq.AddEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```
