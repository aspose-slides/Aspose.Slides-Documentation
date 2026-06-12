---
title: Animatie
type: docs
weight: 100
url: /nl/net/examples/elements/animation/
keywords:
- animatie
- animatie toevoegen
- animatie openen
- animatie verwijderen
- animatievolgorde
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek animatie-voorbeelden van Aspose.Slides for .NET: voeg toe, rangschik en pas effecten en overgangen aan met C# voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel toont hoe je eenvoudige animaties maakt en de volgorde ervan beheert met **Aspose.Slides for .NET**.

## **Animatie toevoegen**

Maak een rechthoekige vorm en pas een vervagingseffect toe dat wordt geactiveerd bij een klik.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Vervaag effect.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **Toegang tot een animatie**

Haal het eerste animatie-effect op uit de tijdlijn van de dia.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Toegang tot het eerste animatie-effect.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **Een animatie verwijderen**

Verwijder een animatie-effect uit de reeks.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Verwijder het effect.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **Animaties in volgorde**

Voeg meerdere effecten toe en toon de volgorde waarin de animaties plaatsvinden.

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