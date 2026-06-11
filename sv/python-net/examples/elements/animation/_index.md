---
title: Animation
type: docs
weight: 100
url: /sv/python-net/examples/elements/animation/
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
- Python
- Aspose.Slides
description: "Behärska bildanimationer i Python med Aspose.Slides: lägg till, redigera och ta bort effekter, tidpunkter och triggrar för att skapa dynamiska presentationer i PPT, PPTX och ODP."
---
Visar hur man skapar enkla animationer och hanterar deras sekvens med **Aspose.Slides for Python via .NET**.

## **Lägg till en animation**

Skapa en rektangulär form och tillämpa en toningseffekt som triggas vid klick.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # Lägg till en toningseffekt.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **Få åtkomst till en animation**

Hämta den första animationseffekten från bildens tidslinje.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Åtkomst till den första animationseffekten.
        effect = slide.timeline.main_sequence[0]
```

## **Ta bort en animation**

Ta bort en animationseffekt från sekvensen.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Antag att huvudsekvensen innehåller minst en effekt.
        effect = slide.timeline.main_sequence[0]

        # Ta bort effekten.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sekvensanimationer**

Lägg till flera effekter och demonstrera i vilken ordning animationerna sker.

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