---
title: Texto Animado
type: docs
weight: 60
url: /python-net/animated-text/
keywords: "Texto animado, Efectos de animación, Presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Agrega texto animado y efectos a la presentación de PowerPoint en Python"
---

## Agregando Efectos de Animación a Párrafos

Agregamos el [**add_effect()**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) método a las clases [**Sequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) y [**ISequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/isequence/). Este método te permite agregar efectos de animación a un solo párrafo. Este código de ejemplo te muestra cómo agregar un efecto de animación a un solo párrafo:

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as presentation:
    # seleccionar párrafo para agregar efecto
    autoShape = presentation.slides[0].shapes[0]
    paragraph = autoShape.text_frame.paragraphs[0]

    # agregar efecto de animación Fly al párrafo seleccionado
    effect = presentation.slides[0].timeline.main_sequence.add_effect(paragraph, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.LEFT, slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("AnimationEffectinParagraph.pptx", slides.export.SaveFormat.PPTX)
```



## Obteniendo los Efectos de Animación en Párrafos

Puedes decidir descubrir los efectos de animación agregados a un párrafo; por ejemplo, en un escenario, deseas obtener los efectos de animación en un párrafo porque planeas aplicar esos efectos a otro párrafo o forma.

Aspose.Slides para Python a través de .NET te permite obtener todos los efectos de animación aplicados a los párrafos contenidos en un marco de texto (forma). Este código de ejemplo te muestra cómo obtener los efectos de animación en un párrafo:

```py
import aspose.slides as slides

with slides.Presentation("AnimationEffectinParagraph.pptx") as pres:
    sequence = pres.slides[0].timeline.main_sequence
    autoShape = pres.slides[0].shapes[0]
    for paragraph in autoShape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print("El párrafo \"" + paragraph.text + "\" tiene efecto de tipo " + str(effects[0].type) + ".")
```