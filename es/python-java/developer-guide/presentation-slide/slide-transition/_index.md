---
title: Gestionar transiciones de diapositivas en presentaciones usando Python vía Java
linktitle: Transición de diapositiva
type: docs
weight: 80
url: /es/python-java/slide-transition/
keywords:
- transición de diapositiva
- agregar transición de diapositiva
- aplicar transición de diapositiva
- transición de diapositiva avanzada
- transición Morph
- tipo de transición
- efecto de transición
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Aplicar transiciones de diapositivas, configurar el avance automático de diapositivas y personalizar Morph y otros efectos de transición con Aspose.Slides para Python vía Java."
---
## **Descripción general**

Las transiciones de diapositiva controlan cómo aparecen las diapositivas durante una presentación. Con Aspose.Slides for Python via Java, puedes elegir un efecto de transición para cada diapositiva, configurar el avance mediante clic del ratón o temporizador, y ajustar opciones específicas de un efecto. Este artículo utiliza ejemplos en Python para aplicar transiciones, establecer duraciones exactas de transición, gestionar el tiempo de la diapositiva y crear una transición Morph entre dos diapositivas. Los ejemplos también muestran cómo guardar la configuración en un archivo PPTX.

## **Agregar transición de diapositiva**

Para aplicar una transición, carga una presentación con la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y accede a la configuración de transición de la diapositiva mediante [getSlideShowTransition](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#getSlideShowTransition). Utiliza [setType](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setType) con un valor de la enumeración [TransitionType](https://reference.aspose.com/slides/es/python-java/aspose.slides/transitiontype/), luego guarda la presentación.

El siguiente ejemplo aplica una transición Circle a la primera diapositiva y una transición Comb a la segunda. Usa un archivo `input.pptx` con al menos dos diapositivas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Agregar transición de diapositiva avanzada**

Puedes configurar cuánto tiempo permanece una diapositiva en pantalla y si un clic del ratón avanza la presentación. Los siguientes métodos controlan este comportamiento:

- [setAdvanceOnClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) permite al espectador avanzar haciendo clic con el ratón.
- [setAdvanceAfter](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) habilita el avance automático.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) especifica el retraso antes del avance automático, en milisegundos.

Activa tanto el avance por clic como el cronometrado para que el espectador pueda pasar a la siguiente diapositiva con un clic o esperando al temporizador. Para usar solo el temporizador, pasa `False` a [setAdvanceOnClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). El retraso controla cuándo avanza la presentación; no establece la duración del efecto visual de transición.

Este ejemplo asigna diferentes efectos a las tres primeras diapositivas y habilita el avance automático después de 3, 5 y 7 segundos, respectivamente. Los clics del ratón también pueden avanzar estas diapositivas. Usa un archivo `input.pptx` con al menos tres diapositivas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

Para comprobar si el avance cronometrado está habilitado, llama a [getAdvanceAfter](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Un retraso almacenado por sí solo no indica que el temporizador esté activo.

El siguiente ejemplo abre el archivo guardado arriba, informa de cada temporizador habilitado y deshabilita el avance automático para las diapositivas con un retraso superior a dos segundos. Habilita los clics del ratón para esas diapositivas y guarda la configuración actualizada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controlar el tiempo de transición con precisión**

Utiliza [setDuration](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setDuration) para especificar la longitud exacta de un efecto de transición en milisegundos. El método [getSlideShowTransition](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositiva expone estas configuraciones a través de [SlideShowTransition](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/):

| Método | Propósito |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setDuration) | Establece la duración del propio efecto de transición, en milisegundos. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Establece el retraso antes de que la diapositiva avance automáticamente, en milisegundos. Pase `True` a [setAdvanceAfter](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) para activar este temporizador. |
| [setSpeed](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setSpeed) | Selecciona una categoría de velocidad predefinida de [TransitionSpeed](https://reference.aspose.com/slides/es/python-java/aspose.slides/transitionspeed/): Slow, Medium o Fast. Se utiliza cuando no se especifica una duración exacta. |

[setDuration](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setDuration) controla solo el efecto de transición; no determina cuánto tiempo permanece visible la diapositiva. Configura el retraso de avance automático por separado. Cuando no se establece una duración explícita, Aspose.Slides determina la duración del efecto a partir del tipo de transición y del valor de [getSpeed](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#getSpeed).

### **Aplicar la misma duración a cada diapositiva**

Para lograr un ritmo constante, aplica el mismo efecto y la misma duración exacta a todas las diapositivas. Este ejemplo carga `input.pptx`, selecciona Fade de [TransitionType](https://reference.aspose.com/slides/es/python-java/aspose.slides/transitiontype/), y asigna a cada transición una duración de 750 milisegundos. Por separado habilita el avance automático después de 5 000 milisegundos y deshabilita el avance mediante clic del ratón, luego guarda el resultado como PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # Configurar el avance automático independientemente de la duración del efecto.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Establecer diferentes duraciones para diapositivas individuales**

Diferentes diapositivas pueden usar distintas duraciones de efecto. Por ejemplo, usar una transición breve para una diapositiva de título y una más larga para la introducción de una sección. Este ejemplo establece 500 milisegundos para la primera diapositiva y 1 200 milisegundos para la segunda. Usa un archivo `input.pptx` con al menos dos diapositivas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **Coordinar transiciones con salida animada**

Al preparar un [GIF animado](/slides/es/python-java/convert-powerpoint-to-animated-gif/), una [presentación HTML5](/slides/es/python-java/export-to-html5/) o un [video](/slides/es/python-java/convert-powerpoint-to-video/), establece duraciones exactas de transición antes de la exportación para que coincidan con el ritmo deseado. Por ejemplo, usa un fundido de 600 ms entre escenas y ajusta cada retraso de avance de diapositiva por separado para permitir tiempo a la narración o al contenido.

Para GIF y video, coordina la frecuencia de fotogramas de salida con la duración del efecto: 600 ms corresponden a 18 fotogramas a 30 fps. En HTML5, habilita transiciones animadas en la configuración de exportación. Comprueba los efectos y opciones de tiempo compatibles con el formato de exportación elegido y previsualiza el resultado para confirmar la sincronización.

### **Leer la duración de una transición existente**

Llama a [getDuration](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#getDuration) antes de modificar la transición para determinar si existe un valor explícito almacenado. Un valor de `-1` significa que no se ha establecido una duración explícita; un valor no negativo especifica la duración almacenada en milisegundos. El valor no establecido no es la duración de reproducción calculada: Aspose.Slides utiliza el tipo de transición y el valor de [getSpeed](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#getSpeed) para determinar esa duración. Establecer un tipo de transición puede inicializar una duración, así que inspecciona primero la configuración original.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Transición Morph**

La transición Morph anima los cambios entre objetos en diapositivas consecutivas. Para crear un efecto Morph sencillo, clona una diapositiva, mueve o cambia el tamaño de un objeto en el clon y aplica la transición Morph a la segunda diapositiva. Esto da a la transición los objetos correspondientes para animar entre sus estados original y modificado.

El siguiente ejemplo crea una diapositiva con un rectángulo de texto, clona la diapositiva y cambia la posición y el tamaño del rectángulo en el clon. Luego selecciona Morph de la enumeración [TransitionType](https://reference.aspose.com/slides/es/python-java/aspose.slides/transitiontype/) para la segunda diapositiva. Abre el archivo guardado en un visor de presentaciones que admita Morph para ver el efecto durante la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tipos de transición Morph**

La enumeración [TransitionMorphType](https://reference.aspose.com/slides/es/python-java/aspose.slides/transitionmorphtype/) controla cómo Morph empareja y anima el contenido:

- [ByObject](https://reference.aspose.com/slides/es/python-java/aspose.slides/transitionmorphtype/#ByObject) trata cada forma como un objeto completo.
- [ByWord](https://reference.aspose.com/slides/es/python-java/aspose.slides/transitionmorphtype/#ByWord) anima el texto emparejando palabras cuando es posible.
- [ByChar](https://reference.aspose.com/slides/es/python-java/aspose.slides/transitionmorphtype/#ByChar) anima el texto emparejando caracteres cuando es posible.

Utiliza [setType](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setType) para seleccionar Morph antes de acceder a [getValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#getValue). El valor es entonces una instancia de la clase [MorphTransition](https://reference.aspose.com/slides/es/python-java/aspose.slides/morphtransition/), cuyo método [setMorphType](https://reference.aspose.com/slides/es/python-java/aspose.slides/morphtransition/#setMorphType) selecciona el modo de emparejamiento.

Este ejemplo abre la presentación creada en la sección anterior y configura la segunda diapositiva para que utilice animación Morph basada en palabras.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Establecer efectos de transición**

Algunas transiciones exponen opciones adicionales, como dirección o si el efecto comienza desde una pantalla negra. Las opciones disponibles dependen de la transición seleccionada con [setType](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setType). Establece primero el tipo y luego utiliza la clase apropiada obtenida mediante [getValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#getValue).

El siguiente ejemplo aplica una transición Cut a la primera diapositiva de `input.pptx`. Llama a [setFromBlack](https://reference.aspose.com/slides/es/python-java/aspose.slides/optionalblacktransition/#setFromBlack) a través de [OptionalBlackTransition](https://reference.aspose.com/slides/es/python-java/aspose.slides/optionalblacktransition/) para que la transición comience desde una pantalla negra.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo controlar la velocidad de reproducción de una transición de diapositiva?**

Sí. Prefiere [setDuration](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setDuration) cuando necesites una duración exacta del efecto en milisegundos. Utiliza [setSpeed](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setSpeed) cuando sea suficiente una categoría predefinida de [TransitionSpeed](https://reference.aspose.com/slides/es/python-java/aspose.slides/transitionspeed/): Slow, Medium o Fast, y no se establezca una duración explícita. Estas configuraciones controlan el efecto de transición independientemente del retraso de avance automático.

**¿Puedo adjuntar audio a una transición y hacer que se reproduzca en bucle?**

Sí. Asigna audio incrustado con [setSound](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setSound), pasa StartSound de la enumeración [TransitionSoundMode](https://reference.aspose.com/slides/es/python-java/aspose.slides/transitionsoundmode/) a [setSoundMode](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setSoundMode), y habilita [setSoundLoop](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setSoundLoop) con `True`. El audio se reproducirá en bucle hasta el próximo evento de sonido en la presentación.

**¿Cuál es la manera más rápida de aplicar la misma transición a todas las diapositivas?**

Recorre la colección [getSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSlides) de la presentación y llama a [setType](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#setType) con el mismo valor para la transición de cada diapositiva. Establece cualquier opción de tiempo y efecto dentro del mismo bucle para mantener el comportamiento coherente en todas las diapositivas.

**¿Cómo puedo comprobar qué transición está establecida actualmente en una diapositiva?**

Llama a [getType](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowtransition/#getType) sobre el resultado de [getSlideShowTransition](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositiva. Devuelve un valor de la enumeración [TransitionType](https://reference.aspose.com/slides/es/python-java/aspose.slides/transitiontype/); `None_` indica que no se ha aplicado ningún efecto de transición.