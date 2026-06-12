---
title: Animace
type: docs
weight: 100
url: /cs/net/examples/elements/animation/
keywords:
- animace
- přidání animace
- přístup k animaci
- odstranění animace
- sekvence animací
- příklad kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte příklady animací Aspose.Slides pro .NET: přidání, sekvenci a přizpůsobení efektů a přechodů pomocí C# pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak vytvořit jednoduché animace a spravovat jejich sekvenci pomocí **Aspose.Slides for .NET**.

## **Přidání animace**

Vytvořte obdélníkový tvar a použijte efekt rozplývání, který se spustí po kliknutí.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Efekt rozplývání.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **Přístup k animaci**

Získejte první animační efekt ze časové osy snímku.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Přístup k prvnímu animačnímu efektu.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **Odstranění animace**

Odstraňte animační efekt ze sekvence.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Odstraňte efekt.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **Sekvence animací**

Přidejte více efektů a ukažte pořadí, ve kterém se animace provádějí.

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