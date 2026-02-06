---
title: Animation
type: docs
weight: 100
url: /fr/python-net/examples/elements/animation/
keywords:
- animation
- ajouter animation
- accéder animation
- supprimer animation
- séquence d'animation
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Maîtrisez les animations de diapositives en Python avec Aspose.Slides : ajoutez, modifiez et supprimez les effets, les minutages et les déclencheurs pour créer des présentations dynamiques au format PPT, PPTX et ODP."
---
Montre comment créer des animations simples et gérer leur séquence en utilisant **Aspose.Slides for Python via .NET**.

## **Add an Animation**
Créer une forme rectangle et appliquer un effet de fondu déclenché au clic.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # Ajouter un effet de fondu.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **Access an Animation**
Récupérez le premier effet d'animation de la chronologie de la diapositive.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Accéder au premier effet d'animation.
        effect = slide.timeline.main_sequence[0]
```

## **Remove an Animation**
Supprimez un effet d'animation de la séquence.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # En supposant que la séquence principale contient au moins un effet.
        effect = slide.timeline.main_sequence[0]

        # Supprimer l'effet.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sequence Animations**
Ajoutez plusieurs effets et démontrez l'ordre dans lequel les animations se produisent.

```py
def sequence_animations():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 200, 50, 100, 100)

        sequence = slide.timeline.main_sequence
        sequence.add_effect(
            shape1,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)
        sequence.add_effect(
            shape2,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation_sequence.pptx", slides.export.SaveFormat.PPTX)
```