---
title: Administrar transiciones de diapositivas en presentaciones usando Python
linktitle: Transición de diapositiva
type: docs
weight: 90
url: /es/python-net/slide-transition/
keywords:
- transición de diapositiva
- agregar transición de diapositiva
- aplicar transición de diapositiva
- transición de diapositiva avanzada
- transición Morph
- tipo de transición
- efecto de transición
- Python
- Aspose.Slides
description: "Descubra cómo personalizar las transiciones de diapositivas en Aspose.Slides para Python a través de .NET, con una guía paso a paso para presentaciones de PowerPoint y OpenDocument."
---

## **Descripción general**

Aspose.Slides for Python ofrece control total sobre las transiciones de diapositivas, desde la selección del tipo de transición hasta la configuración del tiempo y los disparadores como parte de flujos de trabajo automatizados de presentación. Puede establecer que las diapositivas avancen al hacer clic y/o después de un retraso especificado y refinar el comportamiento visual con efectos como cortes desde negro o entradas direccionales. La biblioteca también admite la transición Morph introducida en PowerPoint 2019, incluidos los modos que morph por objeto, palabra o carácter para crear un movimiento fluido y cohesivo entre diapositivas.

## **Agregar transiciones de diapositivas**

Para facilitar la comprensión, este ejemplo muestra cómo usar Aspose.Slides for Python para gestionar transiciones de diapositivas simples. Los desarrolladores pueden aplicar diferentes efectos de transición a las diapositivas y personalizar su comportamiento. Para crear una transición de diapositiva simple, siga estos pasos:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
1. Aplique una transición de diapositiva usando uno de los efectos del enumerado [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
1. Guarde el archivo de presentación modificado.
```py
import aspose.slides as slides

# Instanciar la clase Presentation para cargar un archivo de presentación.
with slides.Presentation("sample.pptx") as presentation:
    # Aplicar una transición circular a la diapositiva 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Aplicar una transición de peine a la diapositiva 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Guardar la presentación en el disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Agregar transiciones de diapositivas avanzadas**

En esta sección, aplicamos un efecto de transición simple a una diapositiva. Para que ese efecto sea más controlado y pulido, siga estos pasos:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
1. Aplique una transición de diapositiva usando uno de los efectos del enumerado [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
1. Configure la transición para Avanzar al hacer clic, después de un período de tiempo específico, o ambos.
1. Guarde el archivo de presentación modificado.

Si **Advance On Click** está habilitado, la diapositiva avanza solo cuando el usuario hace clic. Si la propiedad **Advance After Time** está establecida, la diapositiva avanza automáticamente después del intervalo especificado.
```py
import aspose.slides as slides

# Instanciar la clase Presentation para abrir un archivo de presentación.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Aplicar una transición circular a la diapositiva 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Habilitar avance al hacer clic y establecer un avance automático de 3 segundos.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Aplicar una transición de peine a la diapositiva 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Habilitar avance al hacer clic y establecer un avance automático de 5 segundos.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Aplicar una transición de zoom a la diapositiva 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Habilitar avance al hacer clic y establecer un avance automático de 7 segundos.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Guardar la presentación en el disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Transición Morph**

Aspose.Slides for Python admite la [Morph transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), que anima el movimiento suave de una diapositiva a la siguiente. Esta sección explica cómo usar la transición Morph. Para usarla eficazmente, necesita dos diapositivas con al menos un objeto en común. El enfoque más sencillo es duplicar una diapositiva y luego mover el objeto a una posición diferente en la segunda diapositiva.

El siguiente fragmento de código muestra cómo clonar una diapositiva que contiene texto y aplicar una transición Morph a la segunda diapositiva.
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Clonar la primera diapositiva para crear una segunda diapositiva con las mismas formas para la continuidad del Morph.
    slide1 = presentation.slides.add_clone(slide0)

    # Seleccionar el mismo rectángulo en la segunda diapositiva y cambiar su posición y tamaño.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Habilitar la transición Morph en la segunda diapositiva para animar los cambios de forma suavemente.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Tipos de transición Morph**

El enumerado [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) representa los diferentes tipos de transiciones de diapositivas Morph.

El siguiente fragmento de código muestra cómo aplicar una transición Morph a una diapositiva y cambiar el tipo de morph:
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer efectos de transición**

Aspose.Slides for Python le permite establecer efectos de transición como **From Black**, **From Left**, **From Right**, etc. Para configurar un efecto de transición, siga estos pasos:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
1. Obtenga una referencia a la diapositiva.
1. Establezca el efecto de transición deseado.
1. Guarde la presentación como un archivo PPTX.

En el ejemplo a continuación, establecemos varios efectos de transición.
```py
import aspose.slides as slides

# Instanciar la clase Presentation para abrir un archivo de presentación.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Aplicar una transición Cut y habilitar From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Guardar la presentación en el disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Preguntas frecuentes**

**¿Puedo controlar la velocidad de reproducción de una transición de diapositiva?**

Sí. Establezca la [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) de la transición usando la configuración [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) (por ejemplo, slow/medium/fast).

**¿Puedo adjuntar audio a una transición y hacer que se repita?**

Sí. Puede incrustar un sonido para la transición y controlar el comportamiento mediante configuraciones como modo de sonido y bucle (por ejemplo, [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), además de metadatos como [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) y [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**¿Cuál es la forma más rápida de aplicar la misma transición a todas las diapositivas?**

Configure el tipo de transición deseado en la configuración de transición de cada diapositiva; las transiciones se almacenan por diapositiva, por lo que aplicar el mismo tipo en todas las diapositivas produce un resultado consistente.

**¿Cómo puedo verificar qué transición está configurada actualmente en una diapositiva?**

Inspeccione la [transition settings](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) de la diapositiva y lea su [transition type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/); ese valor le indica exactamente qué efecto está aplicado.
