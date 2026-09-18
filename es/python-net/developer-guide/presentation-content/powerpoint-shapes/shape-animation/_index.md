---
title: Aplicar animaciones de forma en presentaciones con Python
linktitle: Animación de forma
type: docs
weight: 60
url: /es/python-net/shape-animation/
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
- Aspose.Slides
description: "Aprenda a añadir, inspeccionar y personalizar animaciones de forma, temporización, sonidos, comportamiento después de la animación y texto animado con Aspose.Slides for Python via .NET."
---
## **Visión general**

Para trabajar con los comportamientos individuales dentro de un efecto o editar segmentos de ruta de movimiento, consulte [Animación personalizada](/slides/es/python-net/custom-animation/).

Aspose.Slides for Python via .NET representa las animaciones de diapositiva como efectos en la línea de tiempo de una diapositiva. Un efecto tiene una forma objetivo, un tipo y subtipo de animación, un disparador, ajustes de temporización y propiedades opcionales como sonido o comportamiento después de la animación.

La línea de tiempo contiene dos tipos de secuencias:

- La **secuencia principal** se reproduce a medida que avanza la diapositiva.
- Una **secuencia interactiva** se inicia cuando se hace clic en su forma disparadora.

Dado que los cuadros de texto, imágenes, gráficos, tablas y otros objetos de diapositiva implementan [IShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/ishape/), se utiliza el mismo método [Sequence.add_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/sequence/add_effect/) para la mayor parte del contenido de la diapositiva. Los efectos disponibles se enumeran en la enumeración [EffectType](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effecttype/).

## **Añadir animaciones a formas**

Para añadir una animación, obtenga la secuencia principal de la diapositiva y llame a [Sequence.add_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/sequence/add_effect/) con la forma objetivo, el tipo de efecto, el subtipo y el disparador. Para un efecto que comience cuando se haga clic en otra forma, cree una secuencia interactiva cuyo disparador sea esa otra forma.

El siguiente ejemplo crea ambos tipos de animación y guarda el resultado en `shape-animations.pptx`.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Click to animate this shape"

    main_sequence = slide.timeline.main_sequence
    entrance_effect = main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    entrance_effect.timing.duration = 1.5

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    presentation.save("shape-animations.pptx", slides.export.SaveFormat.PPTX)
```

El disparador controla cuándo comienza un efecto:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effecttriggertype/) espera un clic en la secuencia principal, o un clic en la forma disparadora en una secuencia interactiva.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effecttriggertype/) inicia con el efecto anterior.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effecttriggertype/) inicia cuando finaliza el efecto anterior.

Para animar una imagen, gráfico u otro tipo de forma, pase ese objeto a [Sequence.add_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/sequence/add_effect/) en lugar de `target_shape`. Para opciones de agrupación específicas de gráficos, consulte [Gráficos animados](/slides/es/python-net/animated-charts/).

## **Leer animaciones de formas**

Utilice [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) cuando conozca la forma objetivo. Para inspeccionar cada efecto, recorra la secuencia principal y cada secuencia interactiva. La iteración evita suponer que una secuencia contiene un efecto en el índice `0`.

El siguiente ejemplo crea una forma con efectos en la secuencia principal e interactiva, obtiene los efectos que apuntan a la forma y luego recorre todas las secuencias de la diapositiva.

```python
import aspose.slides as slides


def print_sequence(label, sequence):
    print(f"  {label}: {sequence.count} effect(s)")

    for effect in sequence:
        target_name = "unknown" if effect.target_shape is None else effect.target_shape.name
        effect_description = f"{effect.type.name} {effect.subtype.name}; target: {target_name}; trigger: {effect.timing.trigger_type.name}"
        print(f"    {effect_description}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Animated shape"

    main_sequence = slide.timeline.main_sequence
    main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    target_effects = main_sequence.get_effects_by_shape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.name}.")

    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.timeline.interactive_sequences, start=1):
        trigger_name = "unknown" if sequence.trigger_shape is None else sequence.trigger_shape.name
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
```

Si solo necesita los efectos para una forma, primero identifique la forma por nombre, tipo de marcador de posición u otra propiedad estable; después llame a [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/sequence/get_effects_by_shape/). No asuma que la forma en el índice `0` sea siempre el objeto deseado.

## **Trabajar con efectos heredados de marcadores de posición**

Un marcador de posición en una diapositiva normal puede heredar el comportamiento de animación del marcador de posición correspondiente en su diapositiva de diseño y en la diapositiva maestra. [Shape.get_base_placeholder](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/get_base_placeholder/) devuelve ese marcador de posición padre, o `None` cuando no existe padre.

En la siguiente presentación de ejemplo, el pie de página tiene **Barras aleatorias** en la diapositiva normal, **División** en la diapositiva de diseño y **Entrada voladora** en la diapositiva maestra.

![Animación de pie de página en la diapositiva normal](slide-shape-animation.png)

![Animación de marcador de posición de pie de página en la diapositiva de diseño](layout-shape-animation.png)

![Animación de marcador de posición de pie de página en la diapositiva maestra](master-shape-animation.png)

El siguiente ejemplo construye la jerarquía de marcadores de posición. Añade efectos a un marcador de posición maestro, a un marcador de posición de diseño y al marcador de posición correspondiente en una diapositiva normal. Cada llamada a [Shape.get_base_placeholder](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/get_base_placeholder/) se verifica antes de utilizar la forma devuelta.

```python
import aspose.slides as slides


def find_placeholder_with_base(slide):
    for shape in slide.shapes:
        if shape.get_base_placeholder() is not None:
            return shape

    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")

    for effect in effects:
        print(f"  {effect.type.name} {effect.subtype.name}")


with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_placeholder = layout_slide.placeholder_manager.add_text_placeholder(100, 100, 400, 80)
    layout_slide.timeline.main_sequence.add_effect(layout_placeholder, slides.animation.EffectType.SPLIT, slides.animation.EffectSubtype.VERTICAL_IN, slides.animation.EffectTriggerType.ON_CLICK)

    master_placeholder = layout_placeholder.get_base_placeholder()
    if master_placeholder is not None:
        master_sequence = layout_slide.master_slide.timeline.main_sequence
        master_sequence.add_effect(master_placeholder, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM, slides.animation.EffectTriggerType.ON_CLICK)

    slide = presentation.slides.add_empty_slide(layout_slide)
    slide_placeholder = find_placeholder_with_base(slide)

    if slide_placeholder is None:
        raise RuntimeError("The slide does not contain a placeholder linked to its layout slide.")

    slide.timeline.main_sequence.add_effect(slide_placeholder, slides.animation.EffectType.RANDOM_BARS, slides.animation.EffectSubtype.HORIZONTAL, slides.animation.EffectTriggerType.ON_CLICK)
    print_effects("Normal slide", slide.timeline.main_sequence.get_effects_by_shape(slide_placeholder))

    base_layout_placeholder = slide_placeholder.get_base_placeholder()
    if base_layout_placeholder is not None:
        print_effects("Layout slide", layout_slide.timeline.main_sequence.get_effects_by_shape(base_layout_placeholder))

        base_master_placeholder = base_layout_placeholder.get_base_placeholder()
        if base_master_placeholder is not None:
            print_effects("Master slide", layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(base_master_placeholder))

    presentation.save("placeholder-animations.pptx", slides.export.SaveFormat.PPTX)
```

## **Cambiar la temporización de la animación**

El cuadro de diálogo **Temporización** de PowerPoint se corresponde con las propiedades de [Timing](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/).

![Cuadro de diálogo de temporización de PowerPoint para un efecto de animación](shape-animation.png)

- **Inicio** se corresponde con [Timing.trigger_type](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/trigger_type/).
- **Duración** se corresponde con [Timing.duration](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/duration/), en segundos.
- **Retraso** se corresponde con [Timing.trigger_delay_time](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/trigger_delay_time/), en segundos.
- **Repetir** se corresponde con [Timing.repeat_count](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/repeat_until_next_click/), o [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/repeat_until_end_slide/).
- **Rebobinar al terminar la reproducción** se corresponde con [Timing.rewind](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/rewind/).

Este ejemplo independiente añade un efecto, cambia su temporización a través del objeto devuelto por [Sequence.add_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/sequence/add_effect/) y guarda el resultado. Mantener la referencia al [Effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effect/) devuelto evita un índice de colección innecesario.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Timed animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK
    effect.timing.duration = 2.0
    effect.timing.trigger_delay_time = 0.5
    effect.timing.repeat_until_next_click = False
    effect.timing.repeat_until_end_slide = False
    effect.timing.repeat_count = 2.0
    effect.timing.rewind = True

    presentation.save("shape-animation-timing.pptx", slides.export.SaveFormat.PPTX)
```

Utilice un modo de repetición intencionalmente. Combinar un recuento de repeticiones con una bandera «hasta» puede producir resultados confusos en diferentes visores. Cuando cambie los modos de repetición, establezca [Timing.repeat_until_next_click](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/repeat_until_next_click/) y [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) antes de [Timing.repeat_count](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/repeat_count/), ya que establecer cualquiera de las banderas también cambia el modo de repetición activo.

## **Añadir y extraer sonidos de animación**

Un efecto de animación puede referenciar audio incrustado a través de [Effect.sound](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effect/sound/). [Effect.stop_previous_sound](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effect/stop_previous_sound/) indica a un efecto que detenga el audio iniciado por un efecto anterior.

### **Añadir un sonido a un efecto**

El siguiente ejemplo requiere un archivo de audio local llamado `animation-sound.wav`. Crea dos efectos, incrusta ese archivo como sonido del primer efecto y configura el segundo efecto para detener el sonido. Utiliza los objetos devueltos por [Sequence.add_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/sequence/add_effect/), por lo que no se necesita un índice de secuencia.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 100, 240, 80)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 400, 100, 240, 80)
    first_shape.text_frame.text = "Starts sound"
    second_shape.text_frame.text = "Stops sound"

    sequence = slide.timeline.main_sequence
    first_effect = sequence.add_effect(first_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    second_effect = sequence.add_effect(second_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    with open("animation-sound.wav", "rb") as audio_file:
        effect_sound = presentation.audios.add_audio(audio_file.read())

    first_effect.sound = effect_sound
    second_effect.stop_previous_sound = True

    presentation.save("shape-animation-sound.pptx", slides.export.SaveFormat.PPTX)
```

### **Extraer sonidos de efecto incrustados**

El siguiente ejemplo requiere una presentación local llamada `presentation-with-animation-sounds.pptx`. Examina tanto la secuencia principal como la interactiva y escribe cada sonido de efecto incrustado en el directorio `extracted-animation-sounds`. La extensión se selecciona a partir del tipo MIME de audio expuesto por [Audio.content_type](https://reference.aspose.com/slides/es/python-net/aspose.slides/audio/content_type/).

```python
import os

import aspose.slides as slides


def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else content_type.lower()

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
        if effect.sound is None:
            continue

        extension = get_audio_extension(effect.sound.content_type)
        output_path = os.path.join(output_directory, f"effect-sound-{sound_index}{extension}")
        with open(output_path, "wb") as output_file:
            output_file.write(bytes(effect.sound.binary_data))
        sound_index += 1

    return sound_index


input_path = "presentation-with-animation-sounds.pptx"
output_directory = "extracted-animation-sounds"

os.makedirs(output_directory, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    sound_index = 1

    for slide in presentation.slides:
        sound_index = save_sounds(slide.timeline.main_sequence, output_directory, sound_index)

        for sequence in slide.timeline.interactive_sequences:
            sound_index = save_sounds(sequence, output_directory, sound_index)

print(f"Extracted {sound_index - 1} sound file(s) to {os.path.abspath(output_directory)}.")
```

Para objetos de audio grandes, utilice [Audio.get_stream](https://reference.aspose.com/slides/es/python-net/aspose.slides/audio/get_stream/) y copie el flujo a un archivo en lugar de cargar todo el objeto en una matriz de bytes.

## **Establecer el comportamiento después de la animación**

La opción **Después de la animación** controla qué ocurre con una forma después de que su efecto finaliza.

![Cuadro de diálogo de opciones de efecto de PowerPoint que muestra la configuración «Después de la animación»](shape-after-animation.png)

La enumeración [AfterAnimationType](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/afteranimationtype/) permite dejar la forma sin cambios, cambiar su color, ocultarla después de la animación o ocultarla en el siguiente clic. Cuando el tipo es [AfterAnimationType.COLOR](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/afteranimationtype/), establezca también [Effect.after_animation_color](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effect/after_animation_color/).

Este ejemplo independiente crea un efecto, establece su comportamiento después de la animación mediante el objeto de efecto devuelto y guarda el resultado.

```python
import aspose.pydrawing as draw
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Dim after animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.after_animation_type = slides.animation.AfterAnimationType.COLOR
    effect.after_animation_color.color = draw.Color.light_gray

    presentation.save("shape-animation-after-effect.pptx", slides.export.SaveFormat.PPTX)
```

Cambiar el tipo fuera de [AfterAnimationType.COLOR](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/afteranimationtype/) borra la configuración de color después de la animación.

## **Animar texto**

La animación de texto tiene dos controles relacionados:

- [TextAnimation.build_type](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/textanimation/build_type/) controla si los párrafos aparecen juntos o por nivel de párrafo.
- [Effect.animate_text_type](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effect/animate_text_type/) controla si el texto aparece de una sola vez, por palabra o por letra. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effect/delay_between_text_parts/) establece el retardo entre palabras o letras. Un valor positivo es un porcentaje de la duración del efecto; un valor negativo es un retardo en segundos.

El siguiente ejemplo independiente anima las palabras de un cuadro de texto. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/buildtype/) desactiva la construcción párrafo a párrafo para que la configuración de palabra se aplique a todo el marco de texto.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 560, 100)
    text_box.text_frame.text = "Aspose.Slides animates this sentence word by word."

    effect = slide.timeline.main_sequence.add_effect(text_box, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT
    effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD
    effect.delay_between_text_parts = 20.0

    presentation.save("animated-text.pptx", slides.export.SaveFormat.PPTX)
```

Para construir un cuadro de texto por párrafo, establezca [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/buildtype/) (u otro nivel de párrafo). Para dirigir un solo párrafo con su propio efecto, use la sobrecarga de [Sequence.add_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/sequence/add_effect/) que acepta un [IParagraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/iparagraph/). Consulte [Texto animado](/slides/es/python-net/animated-text/) para ejemplos a nivel de párrafo.

## **Exportación y notas de compatibilidad**

- Guardar en PPT o PPTX preserva el modelo de animación, pero la reproducción final depende del visor de la presentación.
- PDF e imágenes estáticas no reproducen animaciones. Utilice [exportación a HTML5](/slides/es/python-net/export-to-html5/), GIF animado o [conversión a video](/slides/es/python-net/convert-powerpoint-to-video/) cuando la salida deba mostrar movimiento.
- Para HTML5, habilite [Html5Options.animate_shapes](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/html5options/animate_shapes/) y, cuando sea necesario, [Html5Options.animate_transitions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/html5options/animate_transitions/).
- La renderización de video admite muchos efectos de entrada, énfasis, salida y rutas de movimiento, pero no todos los efectos de PowerPoint están soportados. Revise la lista actual de [animaciones y efectos compatibles](/slides/es/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) y pruebe presentaciones críticas con la versión de Aspose.Slides que vaya a usar.
- Los efectos personalizados avanzados y los efectos importados de otros formatos de presentación pueden preservarse en el archivo pero renderizarse de forma distinta en PowerPoint, HTML5 o video. Valide el resultado exportado en lugar de confiar solo en el nombre del efecto.

## **Preguntas frecuentes**

**¿Por qué una animación aparece en PowerPoint pero no en un PDF?**

PDF es un formato estático, por lo que las animaciones y transiciones de diapositiva no se reproducen. Exporte a HTML5, GIF animado o video cuando el movimiento deba preservarse.

**¿Por qué un efecto se reproduce de manera diferente en un video?**

La exportación a video renderiza las animaciones en lugar de almacenar el comportamiento original de PowerPoint. Algunos efectos avanzados no son compatibles o se aproximan. Revise la tabla de efectos compatibles y pruebe la presentación real antes de su uso en producción.

**¿Mover una forma hacia adelante o hacia atrás cambia su orden de animación?**

No. El orden Z de la forma controla la superposición, mientras que el orden de la secuencia y los disparadores controlan la reproducción de la animación. Cambie la línea de tiempo si necesita un orden de reproducción diferente.