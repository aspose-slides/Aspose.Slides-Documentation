---
title: Aplicar animaciones de forma en presentaciones usando Python mediante Java
linktitle: Animación de forma
type: docs
weight: 60
url: /es/python-java/shape-animation/
keywords:
- forma
- animación
- efecto
- forma animada
- texto animado
- añadir animación
- obtener animación
- extraer animación
- añadir efecto
- obtener efecto
- extraer efecto
- sonido del efecto
- aplicar animación
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda a añadir, inspeccionar y personalizar animaciones de formas, sincronización, sonidos, comportamiento posterior a la animación y texto animado con Aspose.Slides para Python mediante Java."
---
## **Resumen**

Aspose.Slides for Python via Java representa las animaciones de diapositiva como efectos en una línea de tiempo de la diapositiva. Un efecto tiene una forma objetivo, un tipo y subtipo de animación, un desencadenador, configuraciones de tiempo y propiedades opcionales como sonido o comportamiento posterior a la animación.

La línea de tiempo contiene dos tipos de secuencias:

- La **secuencia principal** se reproduce a medida que avanza la diapositiva.
- Una **secuencia interactiva** comienza cuando se hace clic en su forma desencadenante.

Porque los cuadros de texto, imágenes, gráficos, tablas y otros objetos de diapositiva derivan de [Forma](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/), usa el mismo método [Sequence.addEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/sequence/#addEffect) para la mayor parte del contenido de la diapositiva. Los efectos disponibles se enumeran en la clase [EffectType](https://reference.aspose.com/slides/es/python-java/aspose.slides/effecttype/).

## **Añadir animaciones a formas**

Para añadir una animación, obtenga la secuencia principal de la diapositiva y llame a [Sequence.addEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/sequence/#addEffect) con la forma objetivo, el tipo de efecto, el subtipo y el desencadenador. Para un efecto que comience cuando se haga clic en otra forma, cree una secuencia interactiva cuyo desencadenador sea esa otra forma.

El siguiente ejemplo crea ambos tipos de animación y guarda el resultado en `shape-animations.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El desencadenador controla cuándo comienza un efecto:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/effecttriggertype/#OnClick) espera a que se haga clic en la secuencia principal, o a que se haga clic en la forma desencadenante en una secuencia interactiva.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/es/python-java/aspose.slides/effecttriggertype/#WithPrevious) comienza con el efecto anterior.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/es/python-java/aspose.slides/effecttriggertype/#AfterPrevious) comienza cuando termina el efecto anterior.

Para animar una imagen, un gráfico u otro tipo de forma, pase ese objeto a [Sequence.addEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/sequence/#addEffect) en lugar de `target_shape`. Para opciones de agrupamiento específicas de gráficos, consulte [Gráficos animados](/slides/es/python-java/animated-charts/).

## **Leer animaciones de formas**

Utilice [Sequence.getEffectsByShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/sequence/#getEffectsByShape) cuando conozca la forma objetivo. Para inspeccionar cada efecto, enumere la secuencia principal y cada secuencia interactiva. La enumeración evita suponer que una secuencia contiene un efecto en el índice `0`.

El siguiente ejemplo crea una forma con efectos en la secuencia principal e interactiva, obtiene los efectos que apuntan a la forma y luego enumera todas las secuencias de la diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

Si solo necesita los efectos de una forma, primero identifique la forma por nombre, tipo de marcador de posición u otra propiedad estable; luego llame a [Sequence.getEffectsByShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/sequence/#getEffectsByShape). No asuma que [ShapeCollection.get_Item](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#get_Item) en el índice `0` sea siempre el objeto deseado.

## **Trabajar con efectos heredados de marcadores de posición**

Un marcador de posición en una diapositiva normal puede heredar el comportamiento de animación del marcador de posición correspondiente en su diapositiva de diseño y en la diapositiva maestra. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getBasePlaceholder) devuelve ese marcador de posición padre, o `None` cuando no existe padre.

En la presentación de ejemplo siguiente, el pie de página tiene **Random Bars** en la diapositiva normal, **Split** en la diapositiva de diseño y **Fly In** en la diapositiva maestra.

![Efecto de animación del pie de página en la diapositiva normal](slide-shape-animation.png)

![Efecto de animación del marcador de posición del pie de página en la diapositiva de diseño](layout-shape-animation.png)

![Efecto de animación del marcador de posición del pie de página en la diapositiva maestra](master-shape-animation.png)

El siguiente ejemplo utiliza una jerarquía de marcadores de posición de una presentación nueva. Añade efectos a un marcador de posición maestro, a un marcador de posición de diseño y al marcador de posición correspondiente en una diapositiva normal. Cada llamada a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getBasePlaceholder) se verifica antes de usar la forma devuelta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Cambiar la sincronización de la animación**

El cuadro de diálogo **Timing** de PowerPoint se corresponde con las propiedades de [Timing](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/).

![Cuadro de diálogo Timing de PowerPoint para un efecto de animación](shape-animation.png)

- **Start** se corresponde con [Timing.getTriggerType](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#getTriggerType).
- **Duration** se corresponde con [Timing.getDuration](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#getDuration), en segundos.
- **Delay** se corresponde con [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#getTriggerDelayTime), en segundos.
- **Repeat** se corresponde con [Timing.getRepeatCount](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#getRepeatUntilNextClick) o [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** se corresponde con [Timing.getRewind](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#getRewind).

Este ejemplo independiente añade un efecto, cambia su sincronización mediante el objeto devuelto por [Sequence.addEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/sequence/#addEffect) y guarda el resultado. Mantener la referencia al [Effect](https://reference.aspose.com/slides/es/python-java/aspose.slides/effect/) devuelta evita un índice de colección innecesario.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Utilice un modo de repetición de forma intencionada. Combinar un recuento de repeticiones con una bandera "until" puede producir resultados confusos en distintos visores. Al cambiar los modos de repetición, establezca [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#setRepeatUntilNextClick) y [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) antes de [Timing.setRepeatCount](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#setRepeatCount), porque establecer cualquiera de las banderas también cambia el modo de repetición activo.

## **Añadir y extraer sonidos de animación**

Un efecto de animación puede hacer referencia a audio incrustado a través de [Effect.getSound](https://reference.aspose.com/slides/es/python-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/es/python-java/aspose.slides/effect/#setStopPreviousSound) indica a un efecto que detenga el audio iniciado por un efecto anterior.

### **Añadir un sonido a un efecto**

El siguiente ejemplo espera un archivo de audio local llamado `animation-sound.wav`. Crea dos efectos, incrusta ese archivo como sonido del primer efecto y configura el segundo efecto para detener el sonido. Utiliza los objetos devueltos por [Sequence.addEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/sequence/#addEffect), por lo que no se requiere un índice de secuencia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Extraer sonidos incrustados de efectos**

El siguiente ejemplo espera una presentación local llamada `presentation-with-animation-sounds.pptx`. Analiza tanto las secuencias principales como las interactivas y escribe cada sonido incrustado de efecto en el directorio `extracted-animation-sounds`. La extensión se selecciona a partir del tipo MIME de audio expuesto por [Audio.getContentType](https://reference.aspose.com/slides/es/python-java/aspose.slides/audio/#getContentType).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"
    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

Para objetos de audio grandes, utilice [Audio.getStream](https://reference.aspose.com/slides/es/python-java/aspose.slides/audio/#getStream) y copie la secuencia a un archivo en lugar de cargar todo el objeto en una matriz de bytes.

## **Establecer comportamiento posterior a la animación**

La opción **After animation** controla lo que ocurre con una forma después de que finalice su efecto.

![Cuadro de diálogo de opciones de efecto de PowerPoint que muestra la configuración After animation](shape-after-animation.png)

La clase [AfterAnimationType](https://reference.aspose.com/slides/es/python-java/aspose.slides/afteranimationtype/) permite dejar la forma sin cambios, cambiar su color, ocultarla después de la animación o ocultarla al siguiente clic. Cuando el tipo es [AfterAnimationType.Color](https://reference.aspose.com/slides/es/python-java/aspose.slides/afteranimationtype/#Color), también establezca [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/effect/#getAfterAnimationColor).

Este ejemplo independiente crea un efecto, establece su comportamiento posterior a la animación mediante el objeto efecto devuelto y guarda el resultado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Cambiar el tipo de [AfterAnimationType.Color] a otro elimina la configuración de color posterior a la animación.

## **Animar texto**

La animación de texto tiene dos controles relacionados:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/es/python-java/aspose.slides/textanimation/#getBuildType) controla si los párrafos aparecen juntos o por nivel de párrafo.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/es/python-java/aspose.slides/effect/#getAnimateTextType) controla si el texto aparece todo de una vez, por palabra o por letra. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/es/python-java/aspose.slides/effect/#getDelayBetweenTextParts) establece el retraso entre palabras o letras. Un valor positivo es un porcentaje de la duración del efecto; un valor negativo es un retraso en segundos.

El siguiente ejemplo independiente anima las palabras en un cuadro de texto. [BuildType.AsOneObject](https://reference.aspose.com/slides/es/python-java/aspose.slides/buildtype/#AsOneObject) desactiva la generación párrafo a párrafo para que la configuración de palabras se aplique a todo el marco de texto.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para construir un cuadro de texto por párrafo, establezca [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/es/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (u otro nivel de párrafo). Para dirigir un único párrafo con su propio efecto, use la sobrecarga de [Sequence.addEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/sequence/#addEffect) que acepta un [Paragraph](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/). Consulte [Texto animado](/slides/es/python-java/animated-text/) para ejemplos a nivel de párrafo.

## **Notas de exportación y compatibilidad**

- Guardar en PPT o PPTX conserva el modelo de animación, pero la reproducción final está controlada por el visor de presentaciones.
- PDF e imágenes estáticas no reproducen animaciones. Utilice [exportación a HTML5](/slides/es/python-java/export-to-html5/), GIF animado o [conversión a video](/slides/es/python-java/convert-powerpoint-to-video/) cuando la salida deba mostrar movimiento.
- Para HTML5, active [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/es/python-java/aspose.slides/html5options/#setAnimateShapes) y, cuando sea necesario, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/es/python-java/aspose.slides/html5options/#setAnimateTransitions).
- La renderización de video admite muchos efectos comunes de entrada, énfasis, salida y ruta de movimiento, pero no todos los efectos de PowerPoint están soportados. Consulte la tabla actual de [animaciones y efectos compatibles](/slides/es/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) y pruebe presentaciones críticas con la versión de Aspose.Slides que vaya a usar.
- Los efectos personalizados avanzados y los efectos importados de otros formatos de presentación pueden conservarse en el archivo pero renderizarse de forma distinta en PowerPoint, HTML5 o video. Valide el resultado exportado en lugar de confiar únicamente en el nombre del efecto.

## **Preguntas frecuentes**

**¿Por qué una animación aparece en PowerPoint pero no en un PDF?**

El PDF es un formato estático, por lo que las animaciones y transiciones de diapositiva no se reproducen. Exporte a HTML5, GIF animado o video cuando sea necesario conservar el movimiento.

**¿Por qué un efecto se reproduce de forma diferente en un video?**

La exportación a video renderiza las animaciones en lugar de almacenar el comportamiento original de PowerPoint. Algunos efectos avanzados no son compatibles o se aproximan. Revise la tabla de efectos compatibles y pruebe la presentación real antes de usarla en producción.

**¿Mover una forma hacia adelante o hacia atrás cambia su orden de animación?**

No. El orden Z de la forma controla la superposición, mientras que el orden de la secuencia y los desencadenadores controlan la reproducción de la animación. Cambie la línea de tiempo si necesita un orden de reproducción diferente.