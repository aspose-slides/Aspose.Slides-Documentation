---
title: Animation
type: docs
weight: 100
url: /fr/net/examples/elements/animation/
keywords:
- animation
- ajouter une animation
- accéder à l'animation
- supprimer une animation
- séquence d'animation
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Explorez les exemples d'animation d'Aspose.Slides pour .NET : ajoutez, séquencez et personnalisez les effets et les transitions avec C# pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment créer des animations simples et gérer leur séquence en utilisant **Aspose.Slides for .NET**.

## **Add an Animation**

Créez une forme rectangle et appliquez un effet de fondu déclenché au clic.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Effet de fondu.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **Access an Animation**

Récupérez le premier effet d'animation de la chronologie de la diapositive.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Accéder au premier effet d'animation.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **Remove an Animation**

Supprimez un effet d'animation de la séquence.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Supprimer l'effet.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **Sequence Animations**

Ajoutez plusieurs effets et démontrez l'ordre dans lequel les animations se produisent.

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