---
title: Transición de diapositiva
type: docs
weight: 110
url: /es/python-net/examples/elements/slide-transition/
keywords:
- transición de diapositiva
- agregar transición de diapositiva
- acceder transición de diapositiva
- eliminar transición de diapositiva
- duración de la transición
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Controla las transiciones de diapositiva en Python con Aspose.Slides: elige tipos, velocidad, sonido y temporización para pulir presentaciones en PPT, PPTX y ODP."
---
Demuestra cómo aplicar efectos de transición de diapositiva y tiempos con **Aspose.Slides for Python via .NET**.

## **Agregar una transición de diapositiva**

Aplica un efecto de transición de desvanecimiento a la primera diapositiva.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Aplicar una transición de desvanecimiento.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a una transición de diapositiva**

Lee el tipo de transición asignado actualmente a una diapositiva.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Acceder al tipo de transición.
        transition_type = slide.slide_show_transition.type
```

## **Eliminar una transición de diapositiva**

Elimina cualquier efecto de transición estableciendo el tipo a `NONE`.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Eliminar la transición estableciendo NONE.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer la duración de la transición**

Especifica cuánto tiempo se muestra la diapositiva antes de avanzar automáticamente.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # en milisegundos.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```