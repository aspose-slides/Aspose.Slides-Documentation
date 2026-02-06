---
title: Animación
type: docs
weight: 100
url: /es/python-net/examples/elements/animation/
keywords:
- animación
- añadir animación
- acceder animación
- eliminar animación
- secuencia de animación
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Domina las animaciones de diapositivas en Python con Aspose.Slides: añade, edita y elimina efectos, tiempos y disparadores para crear presentaciones dinámicas en PPT, PPTX y ODP."
---
Muestra cómo crear animaciones simples y gestionar su secuencia usando **Aspose.Slides for Python via .NET**.

## **Añadir una animación**
Crea una forma rectangular y aplica un efecto de desvanecimiento activado al hacer clic.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # Añadir un efecto de desvanecimiento.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a una animación**
Recupera el primer efecto de animación de la línea de tiempo de la diapositiva.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Acceder al primer efecto de animación.
        effect = slide.timeline.main_sequence[0]
```

## **Eliminar una animación**
Elimina un efecto de animación de la secuencia.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la secuencia principal contiene al menos un efecto.
        effect = slide.timeline.main_sequence[0]

        # Eliminar el efecto.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Secuenciar animaciones**
Añade varios efectos y muestra el orden en que se producen las animaciones.

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