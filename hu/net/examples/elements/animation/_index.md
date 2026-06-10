---
title: Animáció
type: docs
weight: 100
url: /hu/net/examples/elements/animation/
keywords:
- animáció
- animáció hozzáadása
- animáció elérése
- animáció eltávolítása
- animációs sorozat
- kódpélda
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for .NET animációs példákat: animációk hozzáadása, sorozata, valamint az effektusok és átmenetek testreszabása C# nyelven PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja, hogyan lehet egyszerű animációkat létrehozni és kezelni azok sorozatát az **Aspose.Slides for .NET** használatával.

## **Animáció hozzáadása**

Hozzon létre egy téglalap alakzatot, és alkalmazzon egy kattintásra aktiválódó halványulási effektust.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Halványulás effektus.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **Animáció elérése**

Szerezze meg az első animációs hatást a dia idővonalából.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Az első animációs effektus elérése.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **Animáció eltávolítása**

Távolítsa el az animációs hatást a sorozatból.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Az effektus eltávolítása.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **Animációk sorozata**

Adjon hozzá több hatást, és mutassa be az animációk előfordulási sorrendjét.

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