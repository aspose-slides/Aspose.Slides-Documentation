---
title: Animar texto de PowerPoint en Python
linktitle: Texto animado
type: docs
weight: 60
url: /es/python-net/animated-text/
keywords:
- texto animado
- animación de texto
- párrafo animado
- animación de párrafo
- efecto de animación
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Cree texto animado dinámico en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para Python a través de .NET, con ejemplos de código optimizados y fáciles de seguir."
---

## **Visión general**

Este artículo muestra cómo animar texto en presentaciones de PowerPoint usando Aspose.Slides para Python. Aprenderás a agregar efectos a párrafos individuales, ajustar disparadores y leer de nuevo secuencias de animación existentes. Al final, podrás crear flujos de trabajo reutilizables de animación de texto que se exportan a PPTX estándar y se reproducen correctamente en PowerPoint.

## **Agregar efectos de animación a párrafos**

El método [add_effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/add_effect/) de la clase [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) le permite aplicar un efecto de animación a un solo párrafo. El código de ejemplo a continuación muestra cómo hacerlo:
```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # Seleccione el párrafo al que se añadirá el efecto.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Añada un efecto de animación Fly al párrafo seleccionado.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```


## **Obtener efectos de animación de párrafos**

Puede que necesite determinar qué efectos de animación se aplican a un párrafo, por ejemplo, si planea copiar esos efectos a otro párrafo o forma.

Aspose.Slides para Python le permite recuperar todos los efectos de animación aplicados a los párrafos en un marco de texto (shape). El código de ejemplo a continuación muestra cómo obtener los efectos de animación de un párrafo:
```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```


## **Preguntas frecuentes**

**¿En qué se diferencian las animaciones de texto de las transiciones de diapositiva y se pueden combinar?**

Las animaciones de texto controlan el comportamiento de los objetos a lo largo del tiempo en una diapositiva, mientras que [transitions](/slides/es/python-net/slide-transition/) controlan cómo cambian las diapositivas. Son independientes y pueden usarse juntas; el orden de reproducción lo gobierna la línea de tiempo de la animación y la configuración de la transición.

**¿Se conservan las animaciones de texto al exportar a PDF o imágenes?**

No. PDF e imágenes rasterizadas son estáticas, por lo que verá un único estado de la diapositiva sin movimiento. Para mantener el movimiento, use la exportación a [video](/slides/es/python-net/convert-powerpoint-to-video/) o a [HTML](/slides/es/python-net/export-to-html5/).

**¿Funcionan las animaciones de texto en los diseños y en la diapositiva maestra?**

Los efectos aplicados a objetos de diseño/maestro se heredan en las diapositivas, pero su sincronización e interacción con las animaciones a nivel de diapositiva dependen de la secuencia final en la diapositiva.