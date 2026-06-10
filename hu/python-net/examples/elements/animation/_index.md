---
title: Animáció
type: docs
weight: 100
url: /hu/python-net/examples/elements/animation/
keywords:
- animáció
- animáció hozzáadása
- animáció elérése
- animáció eltávolítása
- animációs sorozat
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Mesteri diaanimációk Pythonban az Aspose.Slides segítségével: hatások, időzítések és indítók hozzáadása, szerkesztése és eltávolítása a dinamikus prezentációk létrehozásához PPT, PPTX és ODP formátumban."
---
Bemutatja, hogyan hozhatók létre egyszerű animációk, és kezelhetők azok sorozata a **Aspose.Slides for Python via .NET** használatával.

## **Animáció hozzáadása**

Hozzon létre egy téglalap alakzatot, és alkalmazzon egy kattintásra aktiválódó halványulási hatást.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # Adj hozzá egy halványuló effektust.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **Animáció elérése**

Hozza vissza az első animációs hatást a dia idővonalából.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Hozzáférés az első animációs hatáshoz.
        effect = slide.timeline.main_sequence[0]
```

## **Animáció eltávolítása**

Távolítson el egy animációs hatást a sorozatból.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy a fő sorozat legalább egy hatást tartalmaz.
        effect = slide.timeline.main_sequence[0]

        # A hatás eltávolítása.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Animációk sorozata**

Adjon hozzá több hatást, és mutassa be, milyen sorrendben történnek az animációk.

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