---
title: Animation
type: docs
weight: 100
url: /python-net/examples/elements/animation/
keywords:
- animation
- add animation
- access animation
- remove animation
- animation sequence
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Master slide animations in Python with Aspose.Slides: add, edit, and remove effects, timings, and triggers to create dynamic presentations in PPT, PPTX and ODP."
---

Shows how to create simple animations and manage their sequence using **Aspose.Slides for Python via .NET**.

## **Add an Animation**

Create a rectangle shape and apply a fade effect triggered on click.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # Add a fade in effect.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **Access an Animation**

Retrieve the first animation effect from the slide timeline.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Access the first animation effect.
        effect = slide.timeline.main_sequence[0]
```

## **Remove an Animation**

Remove an animation effect from the sequence.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the main sequence contains at least one effect.
        effect = slide.timeline.main_sequence[0]

        # Remove the effect.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sequence Animations**

Add multiple effects and demonstrate the order in which animations occur.

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
