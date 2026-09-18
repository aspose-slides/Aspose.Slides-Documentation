---
title: Crear y modificar comportamientos de animación personalizados en Python
linktitle: Animación personalizada
type: docs
weight: 151
url: /es/python-net/custom-animation/
keywords:
- animación personalizada
- comportamiento de animación
- ruta de movimiento
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Crear, inspeccionar y modificar comportamientos de animación personalizados y rutas de movimiento editables en presentaciones de PowerPoint con Aspose.Slides para Python mediante .NET."
---
## **Descripción general**

Los comportamientos de animación personalizados le permiten controlar operaciones individuales dentro de un efecto de animación, como cambiar un color, rotar una forma o seguir una ruta de movimiento editable. Esta guía muestra cómo crear y combinar comportamientos, configurar su sincronización, inspeccionar y modificar animaciones existentes, y verificar que sus propiedades sobrevivan al guardar y volver a abrir una presentación.

Para efectos predefinidos y disparadores con clic, consulte [Animación de forma](/slides/es/python-net/shape-animation/).

## **Comprender el modelo de animación**

Una animación está organizada como **Timeline → Sequence → Effect → Behaviors**:

- La [timeline](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslide/timeline/) de la diapositiva contiene su secuencia principal y secuencias interactivas.
- Una [Sequence](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/sequence/) contiene efectos, que pueden dirigirse a distintas formas.
- Un [Effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effect/) identifica una forma objetivo, una preconfiguración, un subtipo y la sincronización del efecto.
- [Effect.behaviors](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effect/behaviors/) contiene las operaciones que implementan el efecto: cambiar color, mover, rotar, establecer una propiedad, etc.

## **Crear comportamientos individuales**

Llame a [Sequence.add_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/sequence/add_effect/) para crear un efecto y acceder a su colección de [behaviors](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effect/behaviors/). Un preset puede rellenar esta colección automáticamente. Conserve sus operaciones al ampliar el preset, o use [clear](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behaviorcollection/clear/) cuando sustituya deliberadamente.

BehaviorFactory crea los ocho tipos de comportamiento ilustrados a continuación. El movimiento se trata en [Crear una ruta de movimiento](#build-a-motion-path). Cada ejemplo de creación es un programa completo; los ejemplos de edición posteriores indican qué archivo de salida utilizan.

### **Rotación**

Utilice [create_rotation_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) para crear una rotación. [by](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/rotationeffect/by/) especifica un ángulo relativo en grados; [from_address](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/rotationeffect/from_address/) y [to](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/rotationeffect/to/) especifican los puntos finales.

El ejemplo comienza con un efecto Spin, sustituye sus operaciones predefinidas por un único comportamiento de rotación y asigna a esa operación una duración de dos segundos. Un ángulo relativo de 90 grados representa un cuarto de vuelta respecto a la orientación inicial de la forma, por lo que no se necesita un ángulo inicial explícito.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` contiene una forma y un comportamiento de rotación. La colección, la sincronización y los ejemplos de edición de rotación a continuación utilizan este archivo.

### **Escala**

Utilice [create_scale_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) con porcentajes X/Y: [from_address](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/scaleeffect/from_address/) y [to](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/scaleeffect/to/) describen el tamaño inicial y final, mientras que [by](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/scaleeffect/by/) describe un cambio relativo. Aquí, 100 representa el tamaño original.

El ejemplo aumenta ambas dimensiones del 100 % al 125 % durante dos segundos. Usar porcentajes horizontales y verticales iguales mantiene las proporciones de la forma; porcentajes diferentes estirarían una dimensión más que la otra.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **Color**

Utilice [create_color_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) para cambiar el relleno de azul a naranja. [from_address](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/coloreffect/from_address/) y [to](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/coloreffect/to/) son colores; [by](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/coloreffect/by/) es un desplazamiento de color. [Behavior.properties](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behavior/properties/) identifica el atributo que se anima.

El relleno sólido de la forma se inicializa en azul, coincidiendo con el color inicial de la animación. Seleccionar el atributo de color de relleno indica al comportamiento qué parte de la forma cambiar; los puntos finales de color por sí solos no identifican ese atributo. El efecto guardado describe una transición de dos segundos a naranja.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **Filtro**

Utilice [create_filter_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) para seleccionar un barrido. [type](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/filtereffect/type/), [subtype](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/filtereffect/subtype/), y [reveal](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/filtereffect/reveal/) especifican el filtro, la dirección y si se revela u oculta la forma.

Este ejemplo configura un barrido de dos segundos que revela la forma usando el subtipo de dirección derecha. La configuración del filtro pertenece al comportamiento dentro del efecto, por lo que se configura después de haber eliminado las operaciones originales del preset.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **Propiedad**

Utilice [create_property_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) para animar la opacidad. [from_address](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/propertyeffect/from_address/), [to](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/propertyeffect/to/), y [by](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/propertyeffect/by/) son cadenas interpretadas mediante [value_type](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/propertyeffect/value_type/) y [calc_mode](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/propertyeffect/calc_mode/). Elija puntos finales o un desplazamiento relativo en lugar de establecer los tres indiscriminadamente.

Aquí, el atributo seleccionado es la opacidad, y las cadenas numéricas representan un cambio del 25 % de opacidad a opacidad total. La interpolación lineal describe un cambio gradual entre esos valores. Al adaptar este ejemplo a otro atributo, elija un tipo de valor y valores de punto final apropiados para ese atributo.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **Set**

Utilice [create_set_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) para asignar visibilidad mediante [to]. Un comportamiento de tipo set no interpola entre los puntos finales.

El ejemplo selecciona el atributo de visibilidad y asigna la cadena `visible` cuando se ejecuta el comportamiento. El rectángulo ya es visible en esta presentación mínima, por lo que la asignación puede no producir un cambio visual evidente por sí sola. Esta operación es útil como parte de un efecto mayor que también controla cuándo la forma se oculta o se muestra.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **Comando**

Utilice [create_command_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) y configure [type](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/commandeffect/type/), [command_string](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/commandeffect/command_string/), y [shape_target](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/commandeffect/shape_target/). Coloque una grabación WAV llamada `sample.wav` en el directorio de trabajo. Este ejemplo la incrusta con [add_audio_frame_embedded](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) y adjunta un comando de reproducción al marco de audio.

El marco de audio es tanto el objetivo del efecto como el objetivo del comando. Esto conecta la solicitud de reproducción con la grabación incrustada; una cadena de comando por sí sola no identifica qué objeto multimedia controlar. El efecto está configurado para iniciar con un clic durante la presentación.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

Al guardar, el comando se almacena en `command.pptx`; no reproduce la grabación. La reproducción requiere un reproductor de presentaciones que admita el comando y su objetivo multimedia.

## **Gestionar la colección de comportamientos**

[BehaviorCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behaviorcollection/) admite [add](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behaviorcollection/remove/), y [remove_at](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behaviorcollection/remove_at/). Este ejemplo abre `rotation.pptx`, agrega escalado, lo mueve antes de la rotación y elimina la rotación. Eliminar y volver a insertar el mismo objeto cambia su posición almacenada sin crear una copia.

La secuencia de ediciones cambia la colección de rotación‑escala a escala‑rotación, y luego a solo escala. Los índices se refieren a la colección actual, por lo que la eliminación usa el nuevo índice de la rotación tras el reordenamiento. La enumeración final confirma qué comportamiento se guardará.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

La salida es `ScaleEffect`: solo queda el escalado. El orden de la colección, por sí solo, no programa los comportamientos uno tras otro. Vacíe la colección solo cuando reemplace todas sus operaciones.

## **Configurar la sincronización de comportamientos**

[Behavior.timing](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behavior/timing/) expone [Timing](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/), de forma independiente de [Effect.timing](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effect/timing/). La sincronización del efecto programa el efecto contenedor; la sincronización del comportamiento describe una operación dentro de él.

### **Establecer duración, retardo, repetición y aceleración**

Abra `rotation.pptx` y establezca [duration](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/duration/) y [trigger_delay_time](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/trigger_delay_time/) en segundos, luego configure [repeat_count](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/repeat_count/). [accelerate](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/accelerate/) y [decelerate](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/decelerate/) son fracciones de la duración; mantenga su suma como máximo 1.

El archivo de entrada es el creado en el ejemplo de rotación, donde se conoce que el primer comportamiento es una rotación. Este ejemplo solo cambia la sincronización de ese comportamiento; su ángulo de 90 grados permanece intacto. Mantener el ángulo y la sincronización separados facilita ajustar el ritmo sin reconstruir la animación.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

El comportamiento usa una duración de dos segundos, un retardo de medio segundo y un recuento de repeticiones de 3. El primer y último 20 % de su duración se utilizan para aceleración y desaceleración.

Otras políticas de repetición incluyen [repeat_duration](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/repeat_duration/), [repeat_until_end_slide](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), y [repeat_until_next_click](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/repeat_until_next_click/); elija una política en lugar de habilitarlas todas simultáneamente. [auto_reverse](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/timing/auto_reverse/) reproduce la animación al revés después de la pasada hacia adelante. La aceleración y desaceleración se aplican a cambios continuos, no a asignaciones discretas o comandos.

## **Crear una ruta de movimiento**

Utilice [create_motion_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) para crear movimiento. Sus [from_address](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motioneffect/from_address/), [to](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motioneffect/to/), y [by](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motioneffect/by/) describen coordenadas o desplazamientos basados en porcentajes. Para una ruta editable, cree un [MotionPath](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motionpath/) y asígnelo a [MotionEffect.path](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motioneffect/path/). [MotionPath](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motionpath/) almacena los comandos de la ruta.

[MotionCommandPathType](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motioncommandpathtype/) selecciona la operación:

| Command | Points | Meaning |
| --- | --- | --- |
| MOVE_TO | One | Establece la posición inicial. |
| LINE_TO | One | Mueve a lo largo de un segmento recto hasta su punto final. |
| CURVE_TO | Three | Sigue una curva cúbica definida por dos puntos de control y un punto final. |
| CLOSE_LOOP | None | Vuelve a la posición inicial. |
| END | None | Finaliza la ruta. |

[MotionPathPointsType](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motionpathpointstype/) describe las características de edición de puntos, como puntos de esquina o suaves. No sustituye al tipo de comando. Use un tipo de punto de curva para el ejemplo de curva a continuación, y un tipo de punto de esquina para los segmentos rectos.

Las coordenadas de la ruta están normalizadas a las dimensiones de la diapositiva: un desplazamiento X de 0.25 representa una cuarta parte del ancho de la diapositiva, no 0.25 puntos. Y positivo avanza hacia abajo. Los comandos absolutos especifican posiciones en el sistema de coordenadas de la ruta; los comandos relativos especifican desplazamientos desde la posición actual. Esto es independiente de [origin](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motioneffect/origin/), que selecciona el marco de referencia de la ruta, y de [path_edit_mode](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motioneffect/path_edit_mode/), que controla cómo se mueve la ruta cuando se mueve la forma.

### **Crear una ruta recta**

Cree un comportamiento de movimiento con un punto de inicio, un segmento recto y un comando de fin. [MotionPath.add](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motionpath/add/) recibe el tipo de comando, sus puntos, el tipo de punto y una bandera de coordenadas relativas.

El comando de inicio establece (0, 0), y la línea termina en (0.25, 0), dando a la ruta un desplazamiento horizontal de una cuarta parte del ancho de la diapositiva. El comando de fin no tiene puntos de coordenadas. Una vez asignada la ruta, agregar el comportamiento de movimiento al efecto conecta esa ruta al rectángulo.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` contiene un comportamiento de movimiento con tres comandos de ruta. Los siguientes ejemplos de edición de archivo utilizan esta estructura conocida.

### **Comparar coordenadas absolutas y relativas**

Estos dos objetos de ruta describen la misma trayectoria. El comando absoluto termina en (0.3, 0.1); el comando relativo agrega (0.1, 0.1) a la posición actual, (0.2, 0).

Ambas rutas comienzan en la misma posición. Para la línea relativa, sume sus desplazamientos X e Y a la posición actual para obtener el punto final; para la línea absoluta, lea directamente el punto final. Cambiar la bandera sin convertir las coordenadas describiría una ruta diferente.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

Asigne cualquiera de las rutas a un comportamiento de movimiento para usarla en una presentación. El argumento booleano final selecciona coordenadas relativas para ese comando.

### **Reemplazar una línea por una curva**

Abra `motion.pptx` y reemplace su comando de línea por una curva cúbica. Proporcione primero los dos puntos de control, seguidos del punto final.

La posición inicial la proporciona el comando anterior. Los dos primeros puntos forman la curva, mientras que el tercero es su destino; no son tres destinos sucesivos. Actualizar simultáneamente el tipo de comando, el tipo de edición de puntos y la matriz de puntos mantiene el segmento coherente con su nueva geometría.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

La ruta en `curve.pptx` sigue teniendo tres comandos; su comando central ahora define una curva.

## **Inspeccionar y editar una ruta guardada**

Cada [MotionCmdPath](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motioncmdpath/) expone [points](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motioncmdpath/points/), [command_type](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motioncmdpath/command_type/), [points_type](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motioncmdpath/points_type/), e [is_relative](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motioncmdpath/is_relative/). Los siguientes ejemplos utilizan la ruta conocida de tres comandos en `motion.pptx`. Para una entrada arbitraria, localice el efecto deseado y compruebe los tipos de comando y la cantidad de puntos antes de editar por índice.

### **Leer comandos y coordenadas**

Lea la ruta sin modificarla. Los comandos end y close-loop no requieren puntos, por lo que se debe permitir una matriz de puntos `None`.

La salida asocia cada comando con su bandera de coordenada relativa antes de listar sus puntos. Esto le permite distinguir un punto final de un desplazamiento antes de modificar la ruta. Una curva enumeraría tres puntos, mientras que la línea recta en este archivo enumera solo uno.

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

La lista contiene un punto de inicio, una línea absoluta que termina en (0.25, 0), y un comando de fin.

### **Cambiar un punto final**

Abra `motion.pptx` y reemplace la matriz de puntos de la línea para mover su punto final.

En el archivo de entrada, el índice 0 es el comando de inicio y el índice 1 es la línea. Reemplazar el único punto de la línea cambia su destino sin modificar su tipo de comando, sincronización o posición en la colección. Como el comando usa coordenadas absolutas, el nuevo par especifica una posición en lugar de un desplazamiento añadido.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

La línea en `motion-endpoint.pptx` termina en (0.4, 0.1); el archivo original permanece sin cambios.

### **Reemplazar un segmento**

Utilice [insert](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motionpath/insert/) y [remove_at](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/motionpath/remove_at/) para reemplazar la línea en `motion.pptx`. La inserción desplaza la línea antigua al índice 2.

Esto demuestra la sustitución de un objeto de comando en lugar de editar sus coordenadas existentes. Después de la inserción, la colección contiene temporalmente el comando de inicio, la nueva línea, la línea antigua y el comando de fin. Eliminar el índice 2 descarta la línea antigua y deja la nueva ruta en su lugar.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

La ruta guardada sigue teniendo tres comandos, con la nueva línea terminando en (0.2, 0.1) y el comando de fin al final.

## **Modificar y verificar un comportamiento existente**

Cuando el índice del comportamiento es desconocido, selecciónelo por tipo. Este ejemplo abre `rotation.pptx`, encuentra su [RotationEffect](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/rotationeffect/), cambia el ángulo y verifica el valor guardado tras volver a abrirlo.

La comprobación de tipo permite que el bucle omita los comportamientos que no son rotaciones. La segunda carga lee el archivo guardado en un objeto de presentación separado, por lo que la comparación verifica los datos persistidos en lugar del valor que aún está en memoria. Este ejemplo sigue asumiendo que el efecto conocido es el primero en la secuencia principal; seleccionar un comportamiento por tipo no localiza el efecto correcto en una presentación arbitraria.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

La salida es `Rotation preserved: True`. Aplique el mismo patrón de verificación de tipo a otros comportamientos. Para una comprobación completa de preservación, compare la forma objetivo, el efecto, los tipos y orden de los comportamientos, la sincronización y los comandos de la ruta. Use una tolerancia numérica para valores de punto flotante. Para una presentación con una disposición de animación desconocida, consulte [Read Shape Animations](/slides/es/python-net/shape-animation/#read-shape-animations) para recorrer las secuencias principales e interactivas.

## **Orden de los comportamientos, preajustes y reproducción**

El orden en [BehaviorCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behaviorcollection/) es el orden almacenado de las operaciones de un efecto. No es una lista de reproducción en la que cada comportamiento espera automáticamente al anterior. La sincronización y el efecto contenedor determinan la programación. Los comportamientos pueden superponerse, y las operaciones sobre la misma propiedad pueden interactuar mediante [additive](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behavior/additive/) y [accumulate](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/behavior/accumulate/). No utilice solo el reordenamiento de la colección para programar “mover, luego rotar”; use sincronización explícita o efectos separados como se describe en [Shape Animation](/slides/es/python-net/shape-animation/).

El [type](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effect/type/) y [subtype](https://reference.aspose.com/slides/es/python-net/aspose.slides.animation/effect/subtype/) del efecto describen su preconfiguración. No son una descripción completa de un árbol de comportamientos editado. Elija la preconfiguración y el subtipo antes de personalizar los comportamientos: cambiar la preconfiguración puede reconstruir la colección y descartar sus operaciones personalizadas. Por ejemplo, cambiar un efecto Spin personalizado a Fade puede sustituir su comportamiento de rotación por comportamientos set y filter. Inspeccione la colección nuevamente después de cambiar una preconfiguración o subtipo. Vaciar los comportamientos de la preconfiguración también puede eliminar operaciones de visibilidad o inicialización que la preconfiguración necesita. Los ejemplos usan deliberadamente formas visibles y sustituyen los comportamientos; no reconstruyen la implementación de cada preconfiguración.

## **Compatibilidad de formatos**

Un árbol de comportamientos preservado no garantiza una reproducción idéntica en todos los visores o renderizadores de exportación. Verifique los datos guardados y la salida renderizada por separado.

| Format or output | What to verify |
| --- | --- |
| PPTX | Utilizar como el formato principal para estos ejemplos. Reabrirlo para verificar el árbol de comportamientos editable, luego comprobar la reproducción en la versión de PowerPoint deseada. |
| PPT | La representación binaria heredada puede diferir de PPTX. Pruebe un ciclo de guardar y volver a abrir por separado y la reproducción; no infiera soporte para cada combinación personalizada a partir de una salida PPTX exitosa. |
| PDF, PNG, JPEG, and other static slide images | Contienen una representación estática de la diapositiva, no una línea de tiempo de comportamiento reproducible ni un marco de animación final garantizado. |
| [HTML5](/slides/es/python-net/export-to-html5/) | Puede reproducir animaciones compatibles cuando la animación de forma está habilitada en las opciones de exportación. Pruebe combinaciones personalizadas en el navegador. |
| [Animated GIF](/slides/es/python-net/convert-powerpoint-to-animated-gif/) | Almacena los fotogramas renderizados, no comportamientos editables ni interacción activada por clic. Verifique el movimiento renderizado real. |
| [Video](/slides/es/python-net/convert-powerpoint-to-video/) | Renderiza los fotogramas de animación y los codifica como vídeo. El soporte está limitado a las [animaciones y efectos admitidos](/slides/es/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) del renderizador; los comandos y eventos interactivos no se convierten en una línea de tiempo editable. |

## **Preguntas frecuentes**

**¿Por qué mi efecto contiene comportamientos antes de que añada alguno?**

La creación de un efecto predefinido puede generar sus operaciones subyacentes. Inspecciónelas antes de decidir si ampliar la preconfiguración o sustituir sus comportamientos.

**¿Mover un comportamiento al principio hace que se reproduzca primero?**

No necesariamente. El orden de la colección no sustituye a la sincronización. Verifique los retardos, duraciones e interacciones entre operaciones sobre la misma propiedad.

**¿Por qué un comando end no tiene puntos?**

Marca el final de la ruta y no necesita coordenadas. Compruebe una matriz de puntos `None` al inspeccionar una ruta leída de un archivo.

**¿Es suficiente un ciclo completo exitoso para confirmar la reproducción?**

No. Reabrir confirma la preservación de las propiedades que verificó. Pruebe el reproductor de presentaciones o la exportación animada por separado para confirmar su comportamiento visual.