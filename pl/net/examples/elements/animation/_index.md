---
title: Animacja
type: docs
weight: 100
url: /pl/net/examples/elements/animation/
keywords:
- animacja
- dodaj animację
- uzyskaj dostęp do animacji
- usuń animację
- sekwencja animacji
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Poznaj przykłady animacji w Aspose.Slides for .NET: dodawanie, kolejność i dostosowywanie efektów oraz przejść w C# dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł demonstruje, jak tworzyć proste animacje i zarządzać ich kolejnością przy użyciu **Aspose.Slides for .NET**.

## **Dodaj animację**
Utwórz kształt prostokąta i zastosuj efekt zanikania wyzwalany kliknięciem.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Efekt zanikania.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **Uzyskaj dostęp do animacji**
Pobierz pierwszy efekt animacji z osi czasu slajdu.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Uzyskaj dostęp do pierwszego efektu animacji.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **Usuń animację**
Usuń efekt animacji z kolejności.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Usuń efekt.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **Kolejność animacji**
Dodaj wiele efektów i pokaż kolejność, w jakiej występują animacje.

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