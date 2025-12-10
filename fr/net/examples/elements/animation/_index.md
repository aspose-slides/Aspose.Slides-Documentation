---
title: Animation
type: docs
weight: 100
url: /fr/net/examples/elements/animation/
keywords:
- exemple d'animation
- ajouter une animation
- accéder à une animation
- supprimer une animation
- séquence d'animation
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Maîtrisez les animations des diapositives principales en C# avec Aspose.Slides : ajoutez, modifiez et supprimez des effets, des minuteries et des déclencheurs pour créer des présentations dynamiques en PPT, PPTX et ODP."
---

Montre comment créer des animations simples et gérer leur séquence en utilisant **Aspose.Slides for .NET**.

## **Ajouter une animation**

Créez une forme rectangulaire et appliquez un effet de fondu à l'apparition déclenché au clic.
```csharp
static void Add_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Effet de fondu
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```


## **Accéder à une animation**

Récupérez le premier effet d'animation de la chronologie de la diapositive.
```csharp
static void Access_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);

    // Accéder au premier effet d'animation
    var effect = slide.Timeline.MainSequence[0];
}
```


## **Supprimer une animation**

Supprimez un effet d'animation de la séquence.
```csharp
static void Remove_Animation()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.Bottom, EffectTriggerType.OnClick);

    // Supprimer l'effet
    slide.Timeline.MainSequence.Remove(effect);
}
```


## **Séquence d'animations**

Ajoutez plusieurs effets et démontrez l'ordre dans lequel les animations se produisent.
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
