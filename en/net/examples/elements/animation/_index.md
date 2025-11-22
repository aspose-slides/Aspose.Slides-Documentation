---
title: Animation
type: docs
weight: 100
url: /net/examples/elements/animation/
keywords:
- animation example
- add animation
- access animation
- remove animation
- animation sequence
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Master slide animations in C# with Aspose.Slides: add, edit, and remove effects, timings, and triggers to create dynamic presentations in PPT, PPTX and ODP."
---

Shows how to create simple animations and manage their sequence using **Aspose.Slides for .NET**.

## Add an Animation

Create a rectangle shape and apply a fade-in effect triggered on click.

```csharp
static void Add_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Fade in effect
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```

## Access an Animation

Retrieve the first animation effect from the slide timeline.

```csharp
static void Access_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);

    // Access first animation effect
    var effect = slide.Timeline.MainSequence[0];
}
```

## Remove an Animation

Remove an animation effect from the sequence.

```csharp
static void Remove_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);

    // Remove the effect
    slide.Timeline.MainSequence.Remove(effect);
}
```

## Sequence Animations

Add multiple effects and demonstrate the order in which animations occur.

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
