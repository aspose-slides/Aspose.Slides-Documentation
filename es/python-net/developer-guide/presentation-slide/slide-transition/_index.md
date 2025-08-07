---
title: Administrar transiciones de diapositivas en presentaciones usando Python
linktitle: Transición de diapositivas
type: docs
weight: 90
url: /es/python-net/slide-transition/
keywords:
- transición de diapositivas
- agregar transición de diapositivas
- aplicar transición de diapositivas
- transición de diapositivas avanzada
- transición Morph
- tipo de transición
- efecto de transición
- Python
- Aspose.Slides
description: "Descubre cómo personalizar las transiciones de diapositivas en Aspose.Slides for Python via .NET, con una guía paso a paso para presentaciones de PowerPoint y OpenDocument."
---

## **Agregar Transición de Diapositivas**
Para facilitar la comprensión, hemos demostrado el uso de Aspose.Slides para Python a través de .NET para gestionar transiciones de diapositivas simples. Los desarrolladores no solo pueden aplicar diferentes efectos de transición de diapositivas en las diapositivas, sino también personalizar el comportamiento de estos efectos de transición. Para crear un efecto de transición de diapositivas simple, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Aplique un Tipo de Transición de Diapositiva en la diapositiva desde uno de los efectos de transición ofrecidos por Aspose.Slides para Python a través de .NET mediante el enum TransitionType
1. Escriba el archivo de presentación modificado.

```py
import aspose.slides as slides

# Instanciar la clase Presentation para cargar el archivo de presentación fuente
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Aplicar transición de tipo círculo en la diapositiva 1
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Aplicar transición de tipo combinación en la diapositiva 2
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Escribir la presentación en disco
    presentation.save("SampleTransition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Agregar Transición de Diapositivas Avanzada**
En la sección anterior, solo aplicamos un efecto de transición simple en la diapositiva. Ahora, para mejorar y controlar aún más ese efecto de transición simple, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Aplique un Tipo de Transición de Diapositiva en la diapositiva desde uno de los efectos de transición ofrecidos por Aspose.Slides para Python a través de .NET
1. También puede establecer la transición para Avanzar al Hacer clic, después de un período de tiempo específico o ambos.
1. Si la transición de diapositivas está habilitada para Avanzar al Hacer clic, la transición solo avanzará cuando alguien haga clic con el mouse. Además, si se establece la propiedad Avanzar Después de Tiempo, la transición avanzará automáticamente después de que haya pasado el tiempo de avance especificado.
1. Escriba la presentación modificada como un archivo de presentación.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación
with slides.Presentation(path + "BetterSlideTransitions.pptx") as pres:
    # Aplicar transición de tipo círculo en la diapositiva 1
    pres.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE


    # Establecer el tiempo de transición de 3 segundos
    pres.slides[0].slide_show_transition.advance_on_click = True
    pres.slides[0].slide_show_transition.advance_after_time = 3000

    # Aplicar transición de tipo combinación en la diapositiva 2
    pres.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB


    # Establecer el tiempo de transición de 5 segundos
    pres.slides[1].slide_show_transition.advance_on_click = True
    pres.slides[1].slide_show_transition.advance_after_time = 5000

    # Aplicar transición de tipo zoom en la diapositiva 3
    pres.slides[2].slide_show_transition.type = slides.slideshow.TransitionType.ZOOM


    # Establecer el tiempo de transición de 7 segundos
    pres.slides[2].slide_show_transition.advance_on_click = True
    pres.slides[2].slide_show_transition.advance_after_time = 7000

    # Escribir la presentación en disco
    pres.save("SampleTransition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Transición Morf**
Aspose.Slides para Python a través de .NET ahora soporta la [Morph Transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/imorphtransition/). Representan una nueva transición morf introducida en PowerPoint 2019. La transición morf permite animar un movimiento suave de una diapositiva a la siguiente. Este artículo describe el concepto y cómo usar la transición morf. Para usar la transición morf de manera efectiva, necesitará tener dos diapositivas con al menos un objeto en común. La forma más fácil es duplicar la diapositiva y luego mover el objeto en la segunda diapositiva a un lugar diferente.

El siguiente fragmento de código le muestra cómo agregar una copia de la diapositiva con algún texto a la presentación y establecer una transición de [morf](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/imorphtransition/) en la segunda diapositiva.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    autoshape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    autoshape.text_frame.text = "Transición Morf en Presentaciones de PowerPoint"

    presentation.slides.add_clone(presentation.slides[0])

    presentation.slides[1].shapes[0].x += 100
    presentation.slides[1].shapes[0].y += 50
    presentation.slides[1].shapes[0].width -= 200
    presentation.slides[1].shapes[0].height -= 10

    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **Tipos de Transición Morf**
Se ha añadido un nuevo enum [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) que representa diferentes tipos de transición de diaposa morf.

El enum TransitionMorphType tiene tres miembros:

- ByObject: La transición morf se realizará considerando las formas como objetos indivisibles.
- ByWord: La transición morf se realizará transfiriendo texto por palabras donde sea posible.
- ByChar: La transición morf se realizará transfiriendo texto por caracteres donde sea posible.

El siguiente fragmento de código le muestra cómo establecer la transición morf en la diapositiva y cambiar el tipo de morf:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    presentation.slides[0].slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer Efectos de Transición**
Aspose.Slides para Python a través de .NET soporta establecer efectos de transición como, de negro, de izquierda, de derecha, etc. Para establecer el Efecto de Transición. Siga los pasos a continuación:

- Cree una instancia de [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class.
- Obtenga la referencia de la diapositiva.
- Establezca el efecto de transición.
- Escriba la presentación como un [PPTX ](https://docs.fileformat.com/presentation/pptx/)archivo.

En el ejemplo dado a continuación, hemos establecido los efectos de transición.

```py
import aspose.slides as slides

# Crear una instancia de la clase Presentation
with slides.Presentation(path + "AccessSlides.pptx") as presentation:

    # Establecer efecto
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CUT
    presentation.slides[0].slide_show_transition.value.from_black = True

    # Escribir la presentación en disco
    presentation.save("SetTransitionEffects_out.pptx", slides.export.SaveFormat.PPTX)
```