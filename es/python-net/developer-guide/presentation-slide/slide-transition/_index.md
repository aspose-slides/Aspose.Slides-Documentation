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
- transición Morph
- tipo de transición
- efecto de transición
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aplicar transiciones de diapositivas, configurar el avance automático de diapositivas y personalizar Morph y otros efectos de transición con Aspose.Slides para Python a través de .NET."
---
## **Visión general**

Las transiciones de diapositivas controlan cómo aparecen las diapositivas durante una presentación. Con Aspose.Slides for Python via .NET, puede elegir un efecto de transición para cada diapositiva, configurar el avance mediante clic del ratón o temporizador, y ajustar opciones específicas de un efecto. Este artículo utiliza ejemplos en Python para aplicar transiciones, establecer duraciones exactas de transición, gestionar el tiempo de las diapositivas y crear una transición Morph entre dos diapositivas. Los ejemplos también muestran cómo guardar la configuración en un archivo PPTX.

## **Agregar transición de diapositiva**

Para aplicar una transición, cargue una presentación con la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) y acceda a la propiedad [slide_show_transition](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/slide_show_transition/) de la diapositiva. Establezca su [type](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/type/) a un valor de la enumeración [TransitionType](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/transitiontype/), y luego guarde la presentación.

El siguiente ejemplo aplica una transición Circle a la primera diapositiva y una transición Comb a la segunda. Use un archivo `input.pptx` con al menos dos diapositivas.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **Agregar transición avanzada de diapositiva**

Puede configurar cuánto tiempo permanece una diapositiva en pantalla y si un clic del ratón avanza la presentación. Las siguientes propiedades controlan este comportamiento:

- [advance_on_click](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) permite al espectador avanzar haciendo clic con el ratón.
- [advance_after](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) activa el avance automático.
- [advance_after_time](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) especifica el retraso antes del avance automático, en milisegundos.

Active tanto el avance por clic como el temporizado para que el espectador pueda pasar a la siguiente diapositiva con un clic o esperar al temporizador. Para usar solo el temporizador, establezca [advance_on_click](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) en `False`. El retraso controla cuándo avanza la presentación; no establece la duración del efecto visual de transición.

Este ejemplo asigna efectos diferentes a las tres primeras diapositivas y habilita el avance automático después de 3, 5 y 7 segundos, respectivamente. Los clics del ratón también pueden avanzar estas diapositivas. Use un archivo `input.pptx` con al menos tres diapositivas.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

Para comprobar si el avance temporizado está habilitado, lea [advance_after](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Un retraso almacenado por sí solo no indica que el temporizador esté activo.

El siguiente ejemplo abre el archivo guardado arriba, informa de cada temporizador habilitado y deshabilita el avance automático para las diapositivas con un retraso superior a dos segundos. Habilita los clics del ratón para esas diapositivas y guarda la configuración actualizada.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **Controlar el tiempo de transición con precisión**

Utilice [duration](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/duration/) para especificar la longitud exacta de un efecto de transición en milisegundos. La propiedad [slide_show_transition](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/slide_show_transition/) de la diapositiva expone estas configuraciones a través de [SlideShowTransition](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/):

| Propiedad | Propósito |
| --- | --- |
| [duration](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Establece la duración del efecto de transición en sí, en milisegundos. |
| [advance_after_time](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Establece el retraso antes de que la diapositiva avance automáticamente, en milisegundos. Habilite [advance_after](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) para activar este temporizador. |
| [speed](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Selecciona una categoría de velocidad predefinida de [TransitionSpeed](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM o FAST. Se usa cuando no se especifica una duración exacta. |

[duration](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/duration/) controla solo el efecto de transición; no determina cuánto tiempo permanece visible la diapositiva. Configure el retraso de avance automático por separado. Cuando no se establece una duración explícita, Aspose.Slides determina la duración del efecto a partir del tipo de transición y el valor de [speed](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Aplicar la misma duración a cada diapositiva**

Para mantener un ritmo constante, aplique el mismo efecto y la misma duración exacta a cada diapositiva. Este ejemplo carga `input.pptx`, selecciona Fade de [TransitionType](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/transitiontype/), y asigna a cada transición una duración de 750 milisegundos. Además, habilita el avance automático después de 5 000 milisegundos y desactiva el avance mediante clic del ratón, guardando el resultado como PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Configurar el avance automático independientemente de la duración del efecto.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Establecer duraciones diferentes para diapositivas individuales**

Las distintas diapositivas pueden usar duraciones de efecto diferentes. Por ejemplo, use una transición breve para una diapositiva de título y una más larga para la introducción de una sección. Este ejemplo establece 500 milisegundos para la primera diapositiva y 1 200 milisegundos para la segunda. Use un archivo `input.pptx` con al menos dos diapositivas.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **Coordinar transiciones con salida animada**

Al preparar un [animated GIF](/slides/es/python-net/convert-powerpoint-to-animated-gif/), una [HTML5 presentation](/slides/es/python-net/export-to-html5/) o un [video](/slides/es/python-net/convert-powerpoint-to-video/), establezca duraciones exactas de transición antes de la exportación para que coincidan con el ritmo previsto. Por ejemplo, use un fundido de 600 milisegundos entre escenas y ajuste cada retraso de avance de diapositiva por separado para permitir tiempo a su narración o contenido.

Para GIF y video, coordine la frecuencia de fotogramas de salida con la duración del efecto: 600 milisegundos corresponde a 18 fotogramas a 30 fotogramas por segundo. En HTML5, active las transiciones animadas en la configuración de exportación. Consulte los efectos y opciones de temporización compatibles con el formato de exportación elegido y previsualice el resultado para confirmar la sincronización.

### **Leer la duración de una transición existente**

Lea [duration](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/duration/) antes de modificar la transición para determinar si se almacena un valor explícito. Un valor de `-1` indica que no se ha fijado una duración explícita; un valor no negativo especifica la duración almacenada en milisegundos. El valor no establecido no es la duración calculada de reproducción: Aspose.Slides utiliza el tipo de transición y [speed](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/speed/) para determinar esa duración. Establecer un tipo de transición puede inicializar una duración, así que inspeccione primero la configuración original.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Transición Morph**

La transición Morph anima los cambios entre objetos en diapositivas consecutivas. Para crear un efecto Morph sencillo, clone una diapositiva, mueva o cambie el tamaño de un objeto en el clon y aplique la transición Morph a la segunda diapositiva. Esto proporciona a la transición los objetos correspondientes para animar entre sus estados original y modificado.

El siguiente ejemplo crea una diapositiva con un rectángulo de texto, clona la diapositiva y cambia la posición y el tamaño del rectángulo en el clon. Luego selecciona Morph de la enumeración [TransitionType](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/transitiontype/) para la segunda diapositiva. Abra el archivo guardado en un visor de presentaciones que admita Morph para ver el efecto durante la presentación.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Tipos de transición Morph**

La enumeración [TransitionMorphType](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/transitionmorphtype/) controla cómo Morph empareja y anima el contenido:

- [BY_OBJECT](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/transitionmorphtype/) trata cada forma como un objeto completo.
- [BY_WORD](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/transitionmorphtype/) anima el texto emparejando palabras cuando sea posible.
- [BY_CHAR](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/transitionmorphtype/) anima el texto emparejando caracteres cuando sea posible.

Establezca el [type](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/type/) de la transición a Morph antes de acceder a su [value](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/value/). El valor proporciona entonces el objeto [MorphTransition](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/morphtransition/), cuya propiedad [morph_type](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/morphtransition/morph_type/) selecciona el modo de emparejamiento.

Este ejemplo abre la presentación creada en la sección anterior y configura la segunda diapositiva para que utilice la animación Morph basada en palabras.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **Establecer efectos de transición**

Algunas transiciones exponen opciones adicionales, como la dirección o si el efecto comienza desde una pantalla negra. Las opciones disponibles dependen del [type](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/type/) de transición seleccionado. Establezca primero el tipo y luego use el objeto de transición apropiado obtenido a través de su [value](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/value/).

El siguiente ejemplo aplica una transición Cut a la primera diapositiva de `input.pptx`. Configura [from_black](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) mediante [OptionalBlackTransition](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/optionalblacktransition/) para que la transición comience desde una pantalla negra.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **Preguntas frecuentes**

**¿Puedo controlar la velocidad de reproducción de una transición de diapositiva?**

Sí. Prefiera [duration](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/duration/) cuando necesite una duración exacta del efecto en milisegundos. Use [speed](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/speed/) cuando una categoría predefinida de [TransitionSpeed](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/transitionspeed/) —SLOW, MEDIUM o FAST— sea suficiente y no haya una duración explícita establecida. Estas configuraciones controlan el efecto de transición independientemente del retraso de avance automático.

**¿Puedo adjuntar audio a una transición y hacer que se repita?**

Sí. Asigne audio incrustado a [sound](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/sound/), establezca [sound_mode](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) en START_SOUND de la enumeración [TransitionSoundMode](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/transitionsoundmode/), y habilite [sound_loop](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). El audio se repite hasta el siguiente evento de sonido en la presentación.

**¿Cuál es la forma más rápida de aplicar la misma transición a todas las diapositivas?**

Recorra la colección [slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/slides/es/) de la presentación y establezca el [type](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/type/) de transición de cada diapositiva al mismo valor. Configure cualquier opción de temporización y de efecto dentro del mismo bucle para mantener el comportamiento coherente en todas las diapositivas.

**¿Cómo puedo comprobar qué transición está establecida actualmente en una diapositiva?**

Lea la propiedad [type](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/slideshowtransition/type/) de la [slide_show_transition](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/slide_show_transition/) de la diapositiva. Devuelve un valor de la enumeración [TransitionType](https://reference.aspose.com/slides/es/python-net/aspose.slides.slideshow/transitiontype/); NONE indica que no se ha aplicado ningún efecto de transición.