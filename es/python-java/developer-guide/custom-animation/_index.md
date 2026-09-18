---
title: Crear y modificar comportamientos de animación personalizados en Python mediante Java
linktitle: Animación personalizada
type: docs
weight: 151
url: /es/python-java/custom-animation/
keywords:
- animación personalizada
- comportamiento de animación
- ruta de movimiento
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Crear, inspeccionar y modificar comportamientos de animación personalizados y rutas de movimiento editables en presentaciones de PowerPoint con Aspose.Slides para Python mediante Java."
---
## **Visión general**

Los comportamientos de animación personalizados le permiten controlar operaciones individuales dentro de un efecto de animación, como cambiar un color, rotar una forma o seguir una ruta de movimiento editable. Esta guía muestra cómo crear y combinar comportamientos, configurar su sincronización, inspeccionar y modificar animaciones existentes, y verificar que sus propiedades se preserven al guardar y volver a abrir una presentación.

Para efectos predefinidos y activadores de clic, consulte [Animación de formas](/slides/es/python-java/shape-animation/).

## **Comprender el modelo de animación**

Una animación se organiza como **Timeline → Sequence → Effect → Behaviors**:

- El método [getTimeline](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#getTimeline) devuelve la línea de tiempo de la diapositiva, que contiene su secuencia principal y secuencias interactivas.
- Una [Sequence](https://reference.aspose.com/slides/es/python-java/aspose.slides/sequence/) contiene efectos, potencialmente dirigidos a diferentes formas.
- Un [Effect](https://reference.aspose.com/slides/es/python-java/aspose.slides/effect/) identifica una forma objetivo, un preset, un subtipo y el tiempo del efecto.
- La colección devuelta por [Effect.getBehaviors](https://reference.aspose.com/slides/es/python-java/aspose.slides/effect/#getBehaviors) contiene las operaciones que implementan el efecto: cambiar de color, mover, rotar, establecer una propiedad, etc.

## **Crear comportamientos individuales**

Llame a [Sequence.addEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/sequence/#addEffect) para crear un efecto y acceder a la colección [getBehaviors](https://reference.aspose.com/slides/es/python-java/aspose.slides/effect/#getBehaviors). Un preset puede poblar esta colección automáticamente. Mantenga sus operaciones al ampliar el preset, o use [clear](https://reference.aspose.com/slides/es/python-java/aspose.slides/behaviorcollection/#clear) cuando las reemplace deliberadamente.

[BehaviorFactory](https://reference.aspose.com/slides/es/python-java/aspose.slides/behaviorfactory/) crea los ocho tipos de comportamiento ilustrados a continuación. El movimiento se trata en [Crear una ruta de movimiento](#create-a-motion-path). Cada fragmento incluye sus importaciones y arranca la JVM si es necesario. Los objetos y arreglos de puntos Java se crean mediante JPype donde la API los requiere. Los ejemplos posteriores de edición indican qué archivo de salida utilizan.

### **Rotación**

Use [createRotationEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/behaviorfactory/#createRotationEffect) para crear una rotación. [getBy](https://reference.aspose.com/slides/es/python-java/aspose.slides/rotationeffect/#getBy) especifica un ángulo relativo en grados; [getFrom](https://reference.aspose.com/slides/es/python-java/aspose.slides/rotationeffect/#getFrom) y [getTo](https://reference.aspose.com/slides/es/python-java/aspose.slides/rotationeffect/#getTo) especifican los extremos.

El ejemplo comienza con un efecto Spin, reemplaza sus operaciones de preset con un único comportamiento de rotación y asigna a esa operación una duración de dos segundos. Un ángulo relativo de 90 grados representa un cuarto de vuelta respecto a la orientación inicial de la forma, por lo que no se necesita un ángulo inicial explícito.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` contiene una forma y un comportamiento de rotación. La colección, la sincronización y los ejemplos de edición de rotación a continuación usan este archivo.

### **Escala**

Use [createScaleEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/behaviorfactory/#createScaleEffect) con porcentajes X/Y: [getFrom](https://reference.aspose.com/slides/es/python-java/aspose.slides/scaleeffect/#getFrom) y [getTo](https://reference.aspose.com/slides/es/python-java/aspose.slides/scaleeffect/#getTo) describen el tamaño inicial y final, mientras que [getBy](https://reference.aspose.com/slides/es/python-java/aspose.slides/scaleeffect/#getBy) describe un cambio relativo. Aquí, 100 significa el tamaño original.

El ejemplo aumenta ambas dimensiones del 100 % al 125 % durante dos segundos. Usar porcentajes horizontales y verticales iguales conserva las proporciones de la forma; porcentajes diferentes estirarían una dimensión más que la otra.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Color**

Use [createColorEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/behaviorfactory/#createColorEffect) para cambiar el relleno de azul a naranja. [getFrom](https://reference.aspose.com/slides/es/python-java/aspose.slides/coloreffect/#getFrom) y [getTo](https://reference.aspose.com/slides/es/python-java/aspose.slides/coloreffect/#getTo) son colores; [getBy](https://reference.aspose.com/slides/es/python-java/aspose.slides/coloreffect/#getBy) es un desplazamiento de color. [Behavior.getProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/behavior/#getProperties) identifica el atributo que se anima.

El relleno sólido de la forma se inicializa en azul, coincidiendo con el color inicial de la animación. Seleccionar el atributo de color de relleno indica al comportamiento qué parte de la forma cambiar; los extremos de color por sí solos no identifican ese atributo. El efecto guardado describe una transición de dos segundos a naranja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Filtro**

Use [createFilterEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/behaviorfactory/#createFilterEffect) para seleccionar una pasada. [getType](https://reference.aspose.com/slides/es/python-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/es/python-java/aspose.slides/filtereffect/#getSubtype) y [getReveal](https://reference.aspose.com/slides/es/python-java/aspose.slides/filtereffect/#getReveal) especifican el filtro, la dirección y si revelar o ocultar la forma.

Este ejemplo configura una pasada de dos segundos que revela la forma usando el subtipo de dirección derecha. Los ajustes del filtro pertenecen al comportamiento dentro del efecto, por lo que se configuran después de haber eliminado las operaciones originales del preset.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Propiedad**

Use [createPropertyEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) para animar la opacidad. [getFrom](https://reference.aspose.com/slides/es/python-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/es/python-java/aspose.slides/propertyeffect/#getTo) y [getBy](https://reference.aspose.com/slides/es/python-java/aspose.slides/propertyeffect/#getBy) son cadenas interpretadas mediante [getValueType](https://reference.aspose.com/slides/es/python-java/aspose.slides/propertyeffect/#getValueType) y [getCalcMode](https://reference.aspose.com/slides/es/python-java/aspose.slides/propertyeffect/#getCalcMode). Elija extremos o un desplazamiento relativo en lugar de establecer los tres indiscriminadamente.

Aquí, el atributo seleccionado es la opacidad, y las cadenas numéricas representan un cambio del 25 % de opacidad a opacidad total. La interpolación lineal describe un cambio gradual entre esos valores. Al adaptar este ejemplo a otro atributo, elija un tipo de valor y valores extremos apropiados para ese atributo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Establecer**

Use [createSetEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/behaviorfactory/#createSetEffect) para asignar visibilidad mediante [getTo](https://reference.aspose.com/slides/es/python-java/aspose.slides/seteffect/#getTo). Un comportamiento de establecimiento no interpola entre los extremos.

El ejemplo selecciona el atributo de visibilidad y asigna la cadena `visible` cuando se ejecuta el comportamiento. El rectángulo ya es visible en esta presentación mínima, por lo que la asignación puede no producir un cambio visual evidente por sí sola. Esta operación es útil como parte de un efecto mayor que también controla cuándo la forma se oculta o se muestra.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Comando**

Use [createCommandEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/behaviorfactory/#createCommandEffect) y configure [getType](https://reference.aspose.com/slides/es/python-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/es/python-java/aspose.slides/commandeffect/#getCommandString) y [getShapeTarget](https://reference.aspose.com/slides/es/python-java/aspose.slides/commandeffect/#getShapeTarget). Coloque una grabación WAV llamada `sample.wav` en el directorio de trabajo. Este ejemplo la incrusta con [addAudioFrameEmbedded](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) y enlaza un comando de reproducción al marco de audio.

El marco de audio es tanto el objetivo del efecto como el objetivo del comando. Esto conecta la solicitud de reproducción con la grabación incrustada; una cadena de comando por sí sola no identifica qué objeto multimedia controlar. El efecto está configurado para iniciarse con un clic durante la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Guardar almacena el comando en `command.pptx`; no reproduce la grabación. La reproducción requiere un reproductor de diapositivas que admita el comando y su objetivo multimedia.

## **Gestionar la colección de comportamientos**

[BehaviorCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/behaviorcollection/) admite [add](https://reference.aspose.com/slides/es/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/es/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/es/python-java/aspose.slides/behaviorcollection/#remove) y [removeAt](https://reference.aspose.com/slides/es/python-java/aspose.slides/behaviorcollection/#removeAt). Este ejemplo abre `rotation.pptx`, añade una escala, la mueve antes de la rotación y elimina la rotación. Eliminar y volver a insertar el mismo objeto cambia su posición almacenada sin crear una copia.

La secuencia de ediciones cambia la colección de rotación–escala a escala–rotación y, posteriormente, a solo escala. Los índices se refieren a la colección actual, por lo que la eliminación usa el nuevo índice de la rotación tras el reordenamiento. La enumeración final confirma qué comportamiento se guardará.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La salida es `ScaleEffect`: sólo queda la escala. El orden de la colección, por sí mismo, no programa los comportamientos uno tras otro. Vacíe la colección sólo cuando reemplace todas sus operaciones.

## **Configurar la sincronización de los comportamientos**

[Behavior.getTiming](https://reference.aspose.com/slides/es/python-java/aspose.slides/behavior/#getTiming) expone [Timing](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/), de forma independiente de [Effect.getTiming](https://reference.aspose.com/slides/es/python-java/aspose.slides/effect/#getTiming). La sincronización del efecto programa el efecto contenedor; la sincronización del comportamiento describe una operación dentro de él.

### **Establecer duración, retardo, repetición y aceleración**

Abra `rotation.pptx` y establezca la duración ([getDuration](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#getDuration)) y el retardo del activador ([getTriggerDelayTime](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#getTriggerDelayTime)) en segundos, luego configure el recuento de repeticiones mediante [setRepeatCount](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#getAccelerate) y [getDecelerate](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#getDecelerate) son fracciones de la duración; mantenga su suma como máximo 1.

El archivo de entrada es el creado en el ejemplo de rotación, donde se sabe que el primer comportamiento es una rotación. Este ejemplo cambia sólo la sincronización de ese comportamiento; su ángulo de 90 ° permanece intacto. Mantener el ángulo y la sincronización por separado facilita ajustar el ritmo sin reconstruir la animación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El comportamiento usa una duración de dos segundos, un retardo de medio segundo y un recuento de repeticiones de 3. El primer y último 20 % de su duración se usan para aceleración y desaceleración.

Otras políticas de repetición incluyen [getRepeatDuration](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) y [getRepeatUntilNextClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#getRepeatUntilNextClick); elija una política en lugar de habilitarlas todas a la vez. [getAutoReverse](https://reference.aspose.com/slides/es/python-java/aspose.slides/timing/#getAutoReverse) reproduce la animación al revés tras la pasada directa. La aceleración y desaceleración se aplican a cambios continuos, no a asignaciones discretas ni a comandos.

## **Crear una ruta de movimiento**

Use [createMotionEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/behaviorfactory/#createMotionEffect) para crear movimiento. Sus [getFrom](https://reference.aspose.com/slides/es/python-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/es/python-java/aspose.slides/motioneffect/#getTo) y [getBy](https://reference.aspose.com/slides/es/python-java/aspose.slides/motioneffect/#getBy) describen coordenadas o desplazamientos basados en porcentajes. Para una ruta editable, cree una [MotionPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/motionpath/) y asígnela con [MotionEffect.setPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/motionpath/) almacena los comandos de la ruta.

[MotionCommandPathType](https://reference.aspose.com/slides/es/python-java/aspose.slides/motioncommandpathtype/) selecciona la operación:

| Comando | Puntos | Significado |
| --- | --- | --- |
| MoveTo | One | Establece la posición inicial. |
| LineTo | One | Se desplaza a lo largo de un segmento recto hasta su extremo. |
| CurveTo | Three | Sigue una curva cúbica definida por dos puntos de control y un extremo. |
| CloseLoop | None | Vuelve a la posición inicial. |
| End | None | Finaliza la ruta. |

[MotionPathPointsType](https://reference.aspose.com/slides/es/python-java/aspose.slides/motionpathpointstype/) describe características de edición de puntos, como puntos de esquina o suaves. No sustituye al tipo de comando. Use un tipo de punto de curva para el ejemplo de curva más abajo y un tipo de punto de esquina para los segmentos rectos.

Las coordenadas de la ruta se normalizan a las dimensiones de la diapositiva: un desplazamiento X de 0.25 representa una cuarta parte del ancho de la diapositiva, no 0.25 puntos. El eje Y positivo avanza hacia abajo. Los comandos absolutos especifican posiciones en el sistema de coordenadas de la ruta; los comandos relativos especifican desplazamientos desde la posición actual. Esto es independiente de [getOrigin](https://reference.aspose.com/slides/es/python-java/aspose.slides/motioneffect/#getOrigin), que selecciona el marco de referencia de la ruta, y [getPathEditMode](https://reference.aspose.com/slides/es/python-java/aspose.slides/motioneffect/#getPathEditMode), que controla cómo se mueve la ruta cuando se mueve la forma.

### **Crear una ruta recta**

Cree un comportamiento de movimiento con un punto inicial, un segmento recto y un comando de fin. [MotionPath.add](https://reference.aspose.com/slides/es/python-java/aspose.slides/motionpath/#add) recibe el tipo de comando, sus puntos, el tipo de punto y una bandera de coordenadas relativas.

El comando inicial establece (0, 0), y la línea termina en (0.25, 0), proporcionando un desplazamiento horizontal de una cuarta parte del ancho de la diapositiva. El comando de fin no tiene puntos de coordenadas. Una vez asignada la ruta, al añadir el comportamiento de movimiento al efecto se conecta esa ruta al rectángulo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` contiene un comportamiento de movimiento con tres comandos de ruta. Los siguientes ejemplos de edición de archivos usan esta estructura conocida.

### **Comparar coordenadas absolutas y relativas**

Estos dos objetos de ruta describen el mismo recorrido. El comando absoluto termina en (0.3, 0.1); el comando relativo añade (0.1, 0.1) a la posición actual, (0.2, 0).

Ambas rutas comienzan en la misma posición. Para la línea relativa, sume sus desplazamientos X y Y a la posición actual para obtener el extremo; para la línea absoluta, lea directamente el extremo. Cambiar la bandera sin convertir las coordenadas describiría un recorrido distinto.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

Asigne cualquiera de las rutas a un comportamiento de movimiento para usarla en una presentación. El argumento Boolean final selecciona coordenadas relativas para ese comando.

### **Reemplazar una línea con una curva**

Abra `motion.pptx` y reemplace su comando de línea con una curva cúbica. Proporcione primero los dos puntos de control y, a continuación, el punto final.

La posición inicial la suministra el comando precedente. Los dos primeros puntos forman la curva, mientras que el tercero es su destino; no son tres destinos sucesivos. Actualizar conjuntamente el tipo de comando, el tipo de edición de puntos y el arreglo de puntos mantiene el segmento coherente con su nueva geometría.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La ruta en `curve.pptx` sigue teniendo tres comandos; ahora su comando intermedio define una curva.

## **Inspeccionar y editar una ruta guardada**

Cada [MotionCmdPath](https://reference.aspose.com/slides/es/python-java/aspose.slides/motioncmdpath/) expone [getPoints](https://reference.aspose.com/slides/es/python-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/es/python-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/es/python-java/aspose.slides/motioncmdpath/#getPointsType) y [isRelative](https://reference.aspose.com/slides/es/python-java/aspose.slides/motioncmdpath/#isRelative). Los ejemplos siguientes usan la ruta de tres comandos conocida en `motion.pptx`. Para entradas arbitrarias, localice el efecto deseado y verifique los tipos de comando y la cantidad de puntos antes de editarlos por índice.

### **Leer comandos y coordenadas**

Lea la ruta sin modificarla. Los comandos de fin y cierre de bucle no requieren puntos, por lo que debe permitirse un arreglo de puntos nulo.

La salida asocia cada tipo de comando numérico con su bandera de coordenadas relativas antes de enumerar sus puntos. Esto permite distinguir un extremo de un desplazamiento antes de modificar la ruta. Una curva listaría tres puntos, mientras que la línea recta en este archivo lista solo uno.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

El listado contiene un punto inicial, una línea absoluta que termina en (0.25, 0) y un comando de fin.

### **Cambiar un punto final**

Abra `motion.pptx` y reemplace el arreglo de puntos de la línea para mover su extremo.

En el archivo de entrada, el índice 0 es el comando inicial y el índice 1 es la línea. Reemplazar el único punto de la línea cambia su destino sin modificar el tipo de comando, la sincronización o la posición en la colección. Como el comando usa coordenadas absolutas, el nuevo par especifica una posición y no un desplazamiento añadido.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La línea en `motion-endpoint.pptx` termina en (0.4, 0.1); el archivo original permanece sin cambios.

### **Reemplazar un segmento**

Use [insert](https://reference.aspose.com/slides/es/python-java/aspose.slides/motionpath/#insert) y [removeAt](https://reference.aspose.com/slides/es/python-java/aspose.slides/motionpath/#removeAt) para sustituir la línea en `motion.pptx`. La inserción desplaza la línea anterior al índice 2.

Esto demuestra la sustitución de un objeto de comando en lugar de editar sus coordenadas existentes. Tras la inserción, la colección contiene temporalmente el comando inicial, la nueva línea, la línea antigua y el comando de fin. Eliminar el índice 2 descarta la línea antigua y deja la nueva ruta en su lugar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La ruta guardada sigue teniendo tres comandos, con la nueva línea terminando en (0.2, 0.1) y el comando de fin al final.

## **Modificar y verificar un comportamiento existente**

Cuando se desconoce el índice del comportamiento, selecciónelo por tipo. Este ejemplo abre `rotation.pptx`, busca su [RotationEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/rotationeffect/), cambia el ángulo y comprueba el valor guardado tras volver a abrir.

La verificación de tipo permite que el bucle omita los comportamientos que no son rotaciones. La segunda carga lee el archivo guardado en un objeto de presentación separado, de modo que la comparación verifica los datos persistentes y no el valor que aún permanece en memoria. Este ejemplo asume que el efecto conocido es el primero en la secuencia principal; seleccionar un comportamiento por tipo no localiza el efecto correcto en una presentación arbitraria.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

La salida es `Rotation preserved: True`. Aplique el mismo patrón de verificación de tipo a otros comportamientos. Para una comprobación completa de preservación, compare la forma objetivo, el efecto, los tipos y el orden de los comportamientos, la sincronización y los comandos de ruta. Use una tolerancia numérica para valores de punto flotante. Para una presentación con una disposición de animación desconocida, vea [Leer animaciones de formas](/slides/es/python-java/shape-animation/#read-shape-animations) para recorrer las secuencias principales e interactivas.

## **Orden de los comportamientos, presets y reproducción**

El orden en [BehaviorCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/behaviorcollection/) es el orden almacenado de las operaciones de un efecto. No es una lista de reproducción en la que cada comportamiento espere automáticamente al anterior. La sincronización y el efecto contenedor determinan la programación. Los comportamientos pueden solaparse, y las operaciones sobre la misma propiedad pueden interactuar mediante [getAdditive](https://reference.aspose.com/slides/es/python-java/aspose.slides/behavior/#getAdditive) y [getAccumulate](https://reference.aspose.com/slides/es/python-java/aspose.slides/behavior/#getAccumulate). No use el reordenamiento de la colección solo para programar “mover, luego rotar”; emplee sincronización explícita o efectos separados como se describe en [Animación de formas](/slides/es/python-java/shape-animation/).

Los métodos [getType](https://reference.aspose.com/slides/es/python-java/aspose.slides/effect/#getType) y [getSubtype](https://reference.aspose.com/slides/es/python-java/aspose.slides/effect/#getSubtype) del efecto describen su preset. No constituyen una descripción completa del árbol de comportamientos editado. Elija el preset y el subtipo antes de personalizar los comportamientos: cambiar el preset puede reconstruir la colección y descartar sus operaciones personalizadas. Por ejemplo, cambiar un efecto Spin personalizado a Fade puede reemplazar su comportamiento de rotación por comportamientos de set y filter. Inspeccione la colección nuevamente tras cambiar un preset o subtipo. Vaciar los comportamientos del preset también puede eliminar operaciones de visibilidad o inicialización que el preset necesita. Los ejemplos usan deliberadamente formas visibles y reemplazan los comportamientos; no reconstruyen la implementación completa de cada preset.

## **Compatibilidad de formatos**

Una árbol de comportamientos preservado no garantiza una reproducción idéntica en todos los visores o renderizadores de exportación. Verifique los datos guardados y la salida renderizada por separado.

| Formato o salida | Qué verificar |
| --- | --- |
| PPTX | Utilícelo como formato principal para estos ejemplos. Reábalo para confirmar el árbol de comportamientos editable y luego compruebe la reproducción en la versión de PowerPoint prevista. |
| PPT | La representación binaria heredada puede diferir de PPTX. Realice un ciclo independiente de guardar‑reabrir y reproducción; no infiera soporte para todas las combinaciones personalizadas a partir de un éxito en PPTX. |
| PDF, PNG, JPEG y otras imágenes estáticas de diapositivas | Contienen una representación estática de la diapositiva, no una línea de tiempo reproducible ni un fotograma final de animación garantizado. |
| [HTML5](/slides/es/python-java/export-to-html5/) | Puede reproducir animaciones admitidas cuando la animación de formas está activada en las opciones de exportación. Pruebe combinaciones personalizadas en el navegador. |
| [GIF animado](/slides/es/python-java/convert-powerpoint-to-animated-gif/) | Almacena fotogramas renderizados, no comportamientos editables ni interacción activada por clic. Verifique el movimiento renderizado real. |
| [Video](/slides/es/python-java/convert-powerpoint-to-video/) | Renderiza fotogramas de animación y los codifica como video. El soporte está limitado a las [animaciones y efectos compatibles](/slides/es/python-java/convert-powerpoint-to-video/#supported-animations-and-effects); los comandos y eventos interactivos no se convierten en una línea de tiempo editable. |

## **Preguntas frecuentes**

**¿Por qué mi efecto contiene comportamientos antes de que añada alguno?**  
Crear un efecto predefinido puede generar sus operaciones subyacentes. Inspecciónelas antes de decidir si ampliar el preset o reemplazar sus comportamientos.

**¿Mover un comportamiento al principio hace que se reproduzca primero?**  
No necesariamente. El orden de la colección no sustituye a la sincronización. Revise los retardos, duraciones e interacciones entre operaciones sobre la misma propiedad.

**¿Por qué un comando de fin no tiene puntos?**  
Marca el final de la ruta y no necesita coordenadas. Compruebe la presencia de un arreglo de puntos nulo al inspeccionar una ruta leída de un archivo.

**¿Es suficiente un viaje de ida y vuelta exitoso para confirmar la reproducción?**  
No. Volver a abrir confirma la preservación de las propiedades verificadas. Pruebe el reproductor de diapositivas o la exportación animada por separado para confirmar su comportamiento visual.