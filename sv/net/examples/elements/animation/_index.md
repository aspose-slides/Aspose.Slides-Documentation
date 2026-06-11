---
title: Animation
type: docs
weight: 100
url: /sv/net/examples/elements/animation/
keywords:
- animation
- lägga till animation
- åtkomst till animation
- ta bort animation
- animationssekvens
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Utforska Aspose.Slides för .NET animationsexempel: lägg till, sekvens och anpassa effekter och övergångar med C# för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur du skapar enkla animationer och hanterar deras sekvens med hjälp av **Aspose.Slides for .NET**.

## **Lägg till en animation**

Skapa en rektangelform och applicera en toningseffekt som triggas vid klick.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Toningseffekt.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **Åtkomst till en animation**

Hämta den första animationseffekten från bildens tidslinje.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Åtkomst till den första animationseffekten.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **Ta bort en animation**

Ta bort en animationseffekt från sekvensen.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Ta bort effekten.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **Sekvens av animationer**

Lägg till flera effekter och visa i vilken ordning animationerna sker.

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