---
title: Animation
type: docs
weight: 100
url: /de/python-net/examples/elements/animation/
keywords:
- animation
- animation hinzufügen
- animation abrufen
- animation entfernen
- animationssequenz
- codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Meistern Sie Folienanimationen in Python mit Aspose.Slides: hinzufügen, bearbeiten und entfernen von Effekten, Zeitsteuerungen und Auslösern, um dynamische Präsentationen in PPT, PPTX und ODP zu erstellen."
---
Zeigt, wie man einfache Animationen erstellt und deren Reihenfolge verwaltet, indem man **Aspose.Slides for Python via .NET** verwendet.

## **Animation hinzufügen**

Erstelle eine Rechteckform und wende einen Einblendeeffekt an, der bei einem Klick ausgelöst wird.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # Füge einen Einblendeffekt hinzu.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugriff auf eine Animation**

Rufe den ersten Animationseffekt aus der Zeitleiste der Folie ab.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Greifen Sie auf den ersten Animationseffekt zu.
        effect = slide.timeline.main_sequence[0]
```

## **Animation entfernen**

Entferne einen Animationseffekt aus der Sequenz.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Angenommen, die Hauptsequenz enthält mindestens einen Effekt.
        effect = slide.timeline.main_sequence[0]

        # Entferne den Effekt.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Animationen sequenzieren**

Füge mehrere Effekte hinzu und zeige die Reihenfolge, in der die Animationen ablaufen.

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