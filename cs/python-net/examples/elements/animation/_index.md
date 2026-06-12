---
title: Animace
type: docs
weight: 100
url: /cs/python-net/examples/elements/animation/
keywords:
- animace
- přidat animaci
- přístup k animaci
- odstranit animaci
- sekvence animací
- ukázky kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Ovládněte animace snímků v Pythonu s Aspose.Slides: přidejte, upravte a odstraňte efekty, časování a spouštěče a vytvořte dynamické prezentace ve formátech PPT, PPTX a ODP."
---
Ukazuje, jak vytvořit jednoduché animace a spravovat jejich sekvenci pomocí **Aspose.Slides for Python via .NET**.

## **Přidat animaci**

Vytvořte obdélníkový tvar a aplikujte efekt slábnutí vyvolaný kliknutím.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # Přidejte efekt postupného objevení.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup k animaci**

Získejte první animační efekt ze časové osy snímku.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Přístup k prvnímu animačnímu efektu.
        effect = slide.timeline.main_sequence[0]
```

## **Odstranit animaci**

Odstraňte animační efekt ze sekvence.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládáme, že hlavní sekvence obsahuje alespoň jeden efekt.
        effect = slide.timeline.main_sequence[0]

        # Odstraňte efekt.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sekvence animací**

Přidejte více efektů a ukažte pořadí, ve kterém se animace vykonávají.

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