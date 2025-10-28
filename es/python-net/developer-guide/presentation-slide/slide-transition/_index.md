---
title: Gestionar transiciones de diapositivas en presentaciones usando Python
linktitle: Transición de diapositiva
type: docs
weight: 90
url: /es/python-net/slide-transition/
keywords:
- transición de diapositiva
- añadir transición de diapositiva
- aplicar transición de diapositiva
- transición de diapositiva avanzada
- transición morph
- tipo de transición
- efecto de transición
- Python
- Aspose.Slides
description: "Descubra cómo personalizar las transiciones de diapositivas en Aspose.Slides para Python a través de .NET, con una guía paso a paso para presentaciones PowerPoint y OpenDocument."
---

## **Resumen**

Aspose.Slides para Python brinda control total sobre las transiciones de diapositivas, desde la selección del tipo de transición hasta la configuración del tiempo y los disparadores como parte de flujos de trabajo automatizados de presentaciones. Puede configurar las diapositivas para que avancen al hacer clic y/o después de un retraso especificado y refinar el comportamiento visual con efectos como cortes desde negro o entradas direccionales. La biblioteca también admite la transición Morph introducida en PowerPoint 2019, incluidos los modos que morph por objeto, palabra o carácter para crear un movimiento suave y coherente entre diapositivas.

## **Añadir transiciones de diapositiva**

Para facilitar la comprensión, este ejemplo muestra cómo usar Aspose.Slides para Python para gestionar transiciones de diapositiva simples. Los desarrolladores pueden aplicar diferentes efectos de transición a las diapositivas y personalizar su comportamiento. Para crear una transición de diapositiva simple, siga estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Aplicar una transición de diapositiva usando uno de los efectos del enumerado [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
3. Guardar el archivo de presentación modificado.

```py
import aspose.slides as slides

# Instantiate the Presentation class to load a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Apply a circle transition to slide 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Apply a comb transition to slide 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Save the presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Añadir transiciones de diapositiva avanzadas**

En esta sección aplicamos un efecto de transición simple a una diapositiva. Para que ese efecto sea más controlado y pulido, siga estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Aplicar una transición de diapositiva usando uno de los efectos del enumerado [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/).
3. Configurar la transición para avanzar al hacer clic, después de un tiempo específico, o ambos.
4. Guardar el archivo de presentación modificado.

Si **Advance On Click** está habilitado, la diapositiva avanza solo cuando el usuario hace clic. Si la propiedad **Advance After Time** está establecida, la diapositiva avanza automáticamente después del intervalo especificado.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Apply a circle transition to slide 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Enable advance on click and set a 3-second auto-advance.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Apply a comb transition to slide 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Enable advance on click and set a 5-second auto-advance.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Apply a zoom transition to slide 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Enable advance on click and set a 7-second auto-advance.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Save the presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Transición Morph**

Aspose.Slides para Python admite la [Morph transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), que anima el movimiento fluido de una diapositiva a la siguiente. Esta sección explica cómo usar la transición Morph. Para utilizarla eficazmente, necesita dos diapositivas con al menos un objeto en común. El enfoque más sencillo es duplicar una diapositiva y luego mover el objeto a una posición diferente en la segunda diapositiva.

El siguiente fragmento de código muestra cómo clonar una diapositiva que contiene texto y aplicar una transición Morph a la segunda diapositiva.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Clone the first slide to create a second slide with the same shapes for Morph continuity.
    slide1 = presentation.slides.add_clone(slide0)

    # Select the same rectangle on the second slide and change its position and size.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Enable the Morph transition on the second slide to animate the shape changes smoothly.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Tipos de transición Morph**

El enumerado [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) representa los diferentes tipos de transiciones Morph de diapositivas.

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

Aspose.Slides para Python le permite establecer efectos de transición como **From Black**, **From Left**, **From Right**, etc. Para configurar un efecto de transición, siga estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener una referencia a la diapositiva.
3. Establecer el efecto de transición deseado.
4. Guardar la presentación como archivo PPTX.

En el ejemplo a continuación, establecemos varios efectos de transición.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Apply a Cut transition and enable From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Save the presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Puedo controlar la velocidad de reproducción de una transición de diapositiva?**

Sí. Establezca la [velocidad](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) de la transición usando la configuración [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) (p. ej., lenta/media/rápida).

**¿Puedo adjuntar audio a una transición y hacer que se repita?**

Sí. Puede incrustar un sonido para la transición y controlar su comportamiento mediante configuraciones como modo de sonido y bucle (p. ej., [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), además de metadatos como [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) y [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**¿Cuál es la forma más rápida de aplicar la misma transición a todas las diapositivas?**

Configure el tipo de transición deseado en la configuración de transición de cada diapositiva; las transiciones se almacenan por diapositiva, por lo que aplicar el mismo tipo a todas las diapositivas brinda un resultado consistente.

**¿Cómo puedo verificar qué transición está establecida actualmente en una diapositiva?**

Inspeccione la [configuración de transición](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) de la diapositiva y lea su [tipo de transición](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/); ese valor le indica exactamente qué efecto se ha aplicado.