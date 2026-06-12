---
title: Animatie
type: docs
weight: 100
url: /nl/python-net/examples/elements/animation/
keywords:
- animatie
- animatie toevoegen
- animatie bekijken
- animatie verwijderen
- animatiesequentie
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheers dia-animaties in Python met Aspose.Slides: voeg effecten, timing en triggers toe, bewerk en verwijder ze om dynamische presentaties te maken in PPT, PPTX en ODP."
---
Toont hoe je eenvoudige animaties maakt en hun volgorde beheert met **Aspose.Slides for Python via .NET**.

## **Animatie toevoegen**

Maak een rechthoekvorm en pas een vervageffect toe dat wordt geactiveerd bij een klik.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # Voeg een fade-in effect toe.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **Toegang tot een animatie**

Haal het eerste animatie-effect op uit de tijdlijn van de dia.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Toegang tot het eerste animatie-effect.
        effect = slide.timeline.main_sequence[0]
```

## **Animatie verwijderen**

Verwijder een animatie-effect uit de volgorde.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Aannemende dat de hoofdvolgorde minstens één effect bevat.
        effect = slide.timeline.main_sequence[0]

        # Verwijder het effect.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Animaties rangschikken**

Voeg meerdere effecten toe en toon de volgorde waarin de animaties plaatsvinden.

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