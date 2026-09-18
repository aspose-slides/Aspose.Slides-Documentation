---
title: Crear y modificar comportamientos de animación personalizados en JavaScript
linktitle: Animación personalizada
type: docs
weight: 151
url: /es/nodejs-java/custom-animation/
keywords:
- animación personalizada
- comportamiento de animación
- ruta de movimiento
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Crear, inspeccionar y modificar comportamientos de animación personalizados y rutas de movimiento editables en presentaciones de PowerPoint con Aspose.Slides para Node.js mediante Java."
---
## **Descripción general**

Los comportamientos de animación personalizados le permiten controlar operaciones individuales dentro de un efecto de animación, como cambiar un color, rotar una forma o seguir una ruta de movimiento editable. Esta guía muestra cómo crear y combinar comportamientos, configurar su sincronización, inspeccionar y modificar animaciones existentes, y verificar que sus propiedades persistan al guardar y volver a abrir una presentación.

Para efectos predefinidos y disparadores de clic, consulte [Animación de formas](/slides/es/nodejs-java/shape-animation/).

## **Comprender el modelo de animación**

Una animación se organiza como **Timeline → Sequence → Effect → Behaviors**:

- El método [getTimeline](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslide/#getTimeline) devuelve la línea de tiempo de la diapositiva, que contiene su secuencia principal y secuencias interactivas.
- Una [Sequence](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/) contiene efectos, que pueden dirigirse a diferentes formas.
- Un [Effect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/) identifica una forma objetivo, un preset, un subtipo y la sincronización del efecto.
- La colección devuelta por [Effect.getBehaviors](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/#getBehaviors) contiene las operaciones que implementan el efecto: cambiar color, mover, rotar, establecer una propiedad, etc.

## **Crear comportamientos individuales**

Llame a [Sequence.addEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/#addEffect) para crear un efecto y acceder a la colección [getBehaviors](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/#getBehaviors). Un preset puede poblar esta colección automáticamente. Mantenga sus operaciones al ampliar el preset, o use [clear](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behaviorcollection/#clear) cuando reemplace deliberadamente las operaciones.

[BehaviorFactory](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behaviorfactory/) crea los ocho tipos de comportamiento ilustrados a continuación. El movimiento se cubre en [Build a Motion Path](#build-a-motion-path). Cada fragmento incluye sus importaciones de módulo y puede ejecutarse como un script Node.js con los paquetes `aspose.slides.via.java` y `java` instalados. Ejecute los ejemplos de creación de archivos antes de los ejemplos que leen su salida. Los ejemplos de edición posteriores indican qué archivo de salida utilizan.

### **Rotación**

Use [createRotationEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) para crear una rotación. [getBy](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/rotationeffect/#getBy) especifica un ángulo relativo en grados; [getFrom](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/rotationeffect/#getFrom) y [getTo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/rotationeffect/#getTo) especifican puntos finales.

El ejemplo comienza con un efecto Spin, reemplaza sus operaciones de preset con un comportamiento de rotación y asigna a esa operación una duración de dos segundos. Un ángulo relativo de 90 grados representa un cuarto de vuelta desde la orientación inicial de la forma, por lo que no se necesita un ángulo de partida explícito.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` contiene una forma y un comportamiento de rotación. La colección, la sincronización y los ejemplos de edición de rotación a continuación utilizan este archivo.

### **Escala**

Use [createScaleEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) con porcentajes X/Y: [getFrom](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/scaleeffect/#getFrom) y [getTo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/scaleeffect/#getTo) describen el tamaño inicial y final, mientras que [getBy](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/scaleeffect/#getBy) describe un cambio relativo. Aquí, 100 representa el tamaño original.

El ejemplo aumenta ambas dimensiones del 100 % al 125 % en dos segundos. Usar porcentajes horizontales y verticales iguales mantiene las proporciones de la forma; porcentajes diferentes estirarían una dimensión más que la otra.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Color**

Use [createColorEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) para cambiar el relleno de azul a naranja. [getFrom](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/coloreffect/#getFrom) y [getTo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/coloreffect/#getTo) son colores; [getBy](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/coloreffect/#getBy) es un desplazamiento de color. [Behavior.getProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behavior/#getProperties) identifica el atributo que se está animando.

El relleno sólido de la forma se inicializa a azul, coincidiendo con el color inicial de la animación. Seleccionar el atributo de color de relleno indica al comportamiento qué parte de la forma cambiar; los puntos de color por sí solos no identifican ese atributo. El efecto guardado describe una transición de dos segundos a naranja.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filtro**

Use [createFilterEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) para seleccionar un borrado. [getType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/filtereffect/#getSubtype) y [getReveal](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/filtereffect/#getReveal) especifican el filtro, la dirección y si revelar o ocultar la forma.

Este ejemplo configura un borrado de dos segundos que revela la forma usando el subtipo de dirección derecha. La configuración del filtro pertenece al comportamiento dentro del efecto, por lo que se configuran después de eliminar las operaciones originales del preset.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Propiedad**

Use [createPropertyEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) para animar la opacidad. [getFrom](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/propertyeffect/#getTo) y [getBy](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/propertyeffect/#getBy) son cadenas interpretadas mediante [getValueType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/propertyeffect/#getValueType) y [getCalcMode](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/propertyeffect/#getCalcMode). Elija puntos finales o un desplazamiento relativo en lugar de establecer los tres indiscriminadamente.

Aquí, el atributo seleccionado es opacidad, y las cadenas numéricas representan un cambio del 25 % de opacidad a opacidad total. La interpolación lineal describe un cambio gradual entre esos valores. Al adaptar este ejemplo a otro atributo, elija un tipo de valor y valores finales apropiados para ese atributo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Establecer**

Use [createSetEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) para asignar visibilidad mediante [getTo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/seteffect/#getTo). Un comportamiento de establecimiento no interpola entre puntos finales.

El ejemplo selecciona el atributo de visibilidad y asigna la cadena `visible` cuando se ejecuta el comportamiento. El rectángulo ya es visible en esta presentación mínima, por lo que la asignación puede no producir un cambio visual evidente por sí sola. Una operación de este tipo es útil como parte de un efecto mayor que también controla cuándo la forma se oculta o se muestra.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Comando**

Use [createCommandEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) y configure [getType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/commandeffect/#getCommandString) y [getShapeTarget](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/commandeffect/#getShapeTarget). Coloque una grabación WAV llamada `sample.wav` en el directorio de trabajo. Este ejemplo la incrusta con [addAudioFrameEmbedded](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) y adjunta un comando de reproducción al marco de audio.

El marco de audio es tanto el objetivo del efecto como el objetivo del comando. Esto conecta la solicitud de reproducción con la grabación incrustada; una cadena de comando por sí sola no identifica qué objeto multimedia controlar. El efecto está configurado para iniciarse con un clic durante la presentación.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

Guardar almacena el comando en `command.pptx`; no reproduce la grabación. La reproducción requiere un reproductor de presentaciones que admita el comando y su objetivo multimedia.

## **Gestionar la colección de comportamientos**

[BehaviorCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behaviorcollection/) admite [add](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behaviorcollection/#remove) y [removeAt](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behaviorcollection/#removeAt). Este ejemplo abre `rotation.pptx`, añade escalado, lo mueve antes de la rotación y elimina la rotación. Eliminar y volver a insertar el mismo objeto cambia su posición almacenada sin crear una copia.

La secuencia de ediciones cambia la colección de rotación‑escala a escala‑rotación y, finalmente, solo a escala. Los índices se refieren a la colección actual, por lo que la eliminación usa el nuevo índice de la rotación tras el reordenamiento. La enumeración final confirma qué comportamiento se guardará.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La salida es `ScaleEffect`: solo queda el escalado. El orden de la colección, por sí mismo, no programa comportamientos uno después del otro. Vacíe la colección solo cuando reemplace todas sus operaciones.

## **Configurar la sincronización del comportamiento**

[Behavior.getTiming](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behavior/#getTiming) expone [Timing](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/), independientemente de [Effect.getTiming](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/#getTiming). La sincronización del efecto programa el efecto contenedor; la sincronización del comportamiento describe una operación dentro de él.

### **Establecer duración, retraso, repetición y aceleración**

Abra `rotation.pptx` y establezca la duración ([getDuration](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getDuration)) y el retraso de disparo ([getTriggerDelayTime](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)) en segundos, luego configure el número de repeticiones mediante [setRepeatCount](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getAccelerate) y [getDecelerate](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getDecelerate) son fracciones de la duración; mantenga su suma como máximo 1.

El archivo de entrada es el creado en el ejemplo de rotación, donde se sabe que el primer comportamiento es una rotación. Este ejemplo cambia solo la sincronización de ese comportamiento; su ángulo de 90 ° permanece intacto. Mantener el ángulo y la sincronización por separado facilita ajustar el ritmo sin reconstruir la animación.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El comportamiento usa una duración de dos segundos, un retraso de medio segundo y un recuento de repeticiones de 3. El 20 % inicial y final de su duración se usan para aceleración y desaceleración.

Otras políticas de repetición incluyen [getRepeatDuration](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) y [getRepeatUntilNextClick](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick); elija una política en lugar de habilitarlas todas a la vez. [getAutoReverse](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getAutoReverse) reproduce la animación al revés después del paso hacia adelante. La aceleración y desaceleración se aplican a cambios continuos, no a asignaciones discretas ni a comandos.

## **Construir una ruta de movimiento**

Use [createMotionEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) para crear movimiento. Su [getFrom](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motioneffect/#getTo) y [getBy](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motioneffect/#getBy) describen coordenadas o desplazamientos basados en porcentajes. Para una ruta editable, cree una [MotionPath](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motionpath/) y asígnela con [MotionEffect.setPath](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motionpath/) almacena los comandos de la ruta.

[MotionCommandPathType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motioncommandpathtype/) selecciona la operación:

| Comando | Puntos | Significado |
| --- | --- | --- |
| MoveTo | One | Establecer la posición inicial. |
| LineTo | One | Moverse a lo largo de un segmento recto hasta su punto final. |
| CurveTo | Three | Seguir una curva cúbica definida por dos puntos de control y un punto final. |
| CloseLoop | None | Volver a la posición inicial. |
| End | None | Finalizar la ruta. |

[MotionPathPointsType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motionpathpointstype/) describe características de edición de puntos, como puntos de esquina o suaves. No reemplaza el tipo de comando. Use un tipo de punto de curva para el ejemplo de curva más abajo, y un tipo de punto de esquina para los segmentos rectos.

Las coordenadas de la ruta se normalizan a las dimensiones de la diapositiva: un desplazamiento X de 0,25 representa una cuarta parte del ancho de la diapositiva, no 0,25 puntos. El eje Y positivo corre hacia abajo. Los comandos absolutos especifican posiciones en el sistema de coordenadas de la ruta; los comandos relativos especifican desplazamientos desde la posición actual. Esto es independiente de [getOrigin](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motioneffect/#getOrigin), que selecciona el marco de referencia de la ruta, y de [getPathEditMode](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motioneffect/#getPathEditMode), que controla cómo se mueve la ruta cuando se mueve la forma.

### **Crear una ruta recta**

Cree un comportamiento de movimiento con un punto de partida, un segmento recto y un comando de fin. [MotionPath.add](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motionpath/#add) recibe el tipo de comando, sus puntos, el tipo de punto y una bandera de coordenada relativa.

El comando inicial establece (0, 0), y la línea termina en (0,25, 0), dando a la ruta un desplazamiento horizontal de una cuarta parte del ancho de la diapositiva. El comando final no tiene puntos de coordenadas. Una vez asignada la ruta, añadir el comportamiento de movimiento al efecto conecta esa ruta al rectángulo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` contiene un comportamiento de movimiento con tres comandos de ruta. Los siguientes ejemplos de edición de archivos utilizan esta estructura conocida.

### **Comparar coordenadas absolutas y relativas**

Estos dos objetos de ruta describen la misma trayectoria. El comando absoluto termina en (0,3, 0,1); el comando relativo añade (0,1, 0,1) a la posición actual, (0,2, 0).

Ambas rutas comienzan en la misma posición. Para la línea relativa, sume sus desplazamientos X y Y a la posición actual para obtener el punto final; para la línea absoluta, lea directamente el punto final. Cambiar la bandera sin convertir las coordenadas describiría una ruta diferente.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

Asigne cualquiera de las rutas a un comportamiento de movimiento para usarla en una presentación. El argumento booleano final selecciona coordenadas relativas para ese comando.

### **Reemplazar una línea con una curva**

Abra `motion.pptx` y reemplace su comando de línea con una curva cúbica. Proporcione primero los dos puntos de control, seguidos del punto final.

La posición de partida la suministra el comando anterior. Los dos primeros puntos dan forma a la curva, mientras que el tercero es su destino; no son tres destinos sucesivos. Actualizar conjuntamente el tipo de comando, el tipo de edición de puntos y la matriz de puntos mantiene el segmento coherente con su nueva geometría.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La ruta en `curve.pptx` sigue teniendo tres comandos; su comando del medio ahora define una curva.

## **Inspeccionar y editar una ruta guardada**

Cada [MotionCmdPath](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motioncmdpath/) expone [getPoints](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motioncmdpath/#getPointsType) y [isRelative](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motioncmdpath/#isRelative). Los siguientes ejemplos usan la ruta conocida de tres comandos en `motion.pptx`. Para entradas arbitrarias, localice el efecto deseado y compruebe los tipos de comando y el recuento de puntos antes de editar por índice.

### **Leer comandos y coordenadas**

Lea la ruta sin modificarla. Los comandos de fin y de cierre de bucle no necesitan puntos, así que permita una matriz de puntos nula.

La salida empareja cada tipo de comando numérico con su bandera de coordenada relativa antes de listar sus puntos. Esto le permite distinguir un punto final de un desplazamiento antes de modificar la ruta. Una curva listaría tres puntos, mientras que la línea recta en este archivo lista solo uno.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

El listado contiene un punto de partida, una línea absoluta que termina en (0,25, 0) y un comando de fin.

### **Cambiar un punto final**

Abra `motion.pptx` y reemplace la matriz de puntos de la línea para mover su punto final.

En el archivo de entrada, el índice 0 es el comando de inicio y el índice 1 la línea. Reemplazar el único punto de la línea cambia su destino sin cambiar el tipo de comando, la sincronización o la posición en la colección. Como el comando usa coordenadas absolutas, el nuevo par especifica una posición en vez de un desplazamiento añadido.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La línea en `motion-endpoint.pptx` termina en (0,4, 0,1); el archivo original permanece sin cambios.

### **Reemplazar un segmento**

Use [insert](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motionpath/#insert) y [removeAt](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/motionpath/#removeAt) para sustituir la línea en `motion.pptx`. Insertar desplaza la línea antigua al índice 2.

Esto demuestra la sustitución de un objeto de comando en lugar de editar sus coordenadas existentes. Tras la inserción, la colección contiene temporalmente el comando de inicio, la nueva línea, la línea antigua y el comando de fin. Eliminar el índice 2 descarta la línea antigua y deja la nueva ruta en su lugar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La ruta guardada sigue teniendo tres comandos, con la nueva línea terminando en (0,2, 0,1) y el comando de fin al final.

## **Modificar y verificar un comportamiento existente**

Cuando se desconoce el índice del comportamiento, selecciónelo por tipo. Este ejemplo abre `rotation.pptx`, encuentra su [RotationEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/rotationeffect/), cambia el ángulo y comprueba el valor guardado después de volver a abrirlo.

La comprobación de tipo permite que el bucle omita comportamientos que no sean rotaciones. La segunda carga lee el archivo guardado en un objeto de presentación separado, de modo que la comparación verifica los datos persistidos y no el valor que aún está en memoria. Este ejemplo sigue asumiendo que el efecto conocido es el primero en la secuencia principal; seleccionar un comportamiento por tipo no localiza el efecto correcto en una presentación arbitraria.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

La salida es `Rotation preserved: true`. Aplique el mismo patrón de comprobación de tipo a otros comportamientos. Para una verificación completa de preservación, compare la forma objetivo, el efecto, los tipos y el orden de los comportamientos, la sincronización y los comandos de ruta. Use una tolerancia numérica para los valores de coma flotante. Para una presentación con una estructura de animación desconocida, consulte [Read Shape Animations](/slides/es/nodejs-java/shape-animation/#read-shape-animations) para recorrer las secuencias principal e interactiva.

## **Orden de los comportamientos, predefinidos y reproducción**

El orden en [BehaviorCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behaviorcollection/) es el orden almacenado de las operaciones de un efecto. No es una lista de reproducción en la que cada comportamiento espere automáticamente al anterior. La sincronización y el efecto contenedor determinan la programación. Los comportamientos pueden solaparse, y las operaciones sobre la misma propiedad pueden interactuar mediante [getAdditive](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behavior/#getAdditive) y [getAccumulate](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/behavior/#getAccumulate). No use solo el reordenamiento de la colección para programar “mover, luego rotar”; utilice la sincronización explícita o efectos separados como se describe en [Animación de formas](/slides/es/nodejs-java/shape-animation/).

El [getType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/#getType) y [getSubtype](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/#getSubtype) del efecto describen su preset. No son una descripción completa de un árbol de comportamientos editado. Elija el preset y el subtipo antes de personalizar los comportamientos: cambiar el preset puede reconstruir la colección y descartar sus operaciones personalizadas. Por ejemplo, cambiar un efecto Spin personalizado a Fade puede reemplazar su comportamiento de rotación por comportamientos de establecimiento y filtro. Inspeccione la colección nuevamente después de cambiar un preset o subtipo. Vaciar los comportamientos del preset también puede eliminar operaciones de visibilidad o inicialización que el preset necesita. Los ejemplos usan formas visibles y reemplazan los comportamientos; no reconstruyen la implementación de cada preset.

## **Compatibilidad de formatos**

Un árbol de comportamientos preservado no garantiza una reproducción idéntica en todos los visores o renderizadores de exportación. Verifique los datos guardados y la salida renderizada por separado.

| Formato o salida | Qué verificar |
| --- | --- |
| PPTX | Usar como formato principal para estos ejemplos. Reabrirlo para verificar el árbol de comportamientos editable, luego comprobar la reproducción en la versión de PowerPoint deseada. |
| PPT | La representación binaria heredada puede diferir de PPTX. Pruebe un ciclo de guardado‑reapertura separado y la reproducción; no infiera soporte para cada combinación personalizada solo por un resultado exitoso en PPTX. |
| PDF, PNG, JPEG y otras imágenes estáticas de diapositivas | Contienen una representación estática de la diapositiva, no una línea de tiempo reproducible ni un fotograma final garantizado de la animación. |
| [HTML5](/slides/es/nodejs-java/export-to-html5/) | Puede reproducir animaciones compatibles cuando la animación de formas está habilitada en las opciones de exportación. Probar combinaciones personalizadas en el navegador. |
| [Animated GIF](/slides/es/nodejs-java/convert-powerpoint-to-animated-gif/) | Almacena fotogramas renderizados, no comportamientos editables ni interacción activada por clic. Verificar el movimiento realmente renderizado. |
| [Video](/slides/es/nodejs-java/convert-powerpoint-to-video/) | Renderiza fotogramas de animación y los codifica como video. El soporte está limitado a las [animaciones y efectos compatibles](/slides/es/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects); los comandos y eventos interactivos no se convierten en una línea de tiempo editable. |

## **Preguntas frecuentes**

**¿Por qué mi efecto contiene comportamientos antes de que añada alguno?**

Crear un efecto predefinido puede crear sus operaciones subyacentes. Inspéctelas antes de decidir si ampliar el preset o reemplazar sus comportamientos.

**¿Mover un comportamiento al principio hace que se reproduzca primero?**

No necesariamente. El orden de la colección no sustituye a la sincronización. Verifique retrasos, duraciones e interacciones entre operaciones sobre la misma propiedad.

**¿Por qué un comando de fin no tiene puntos?**

Marca el final de la ruta y no necesita coordenadas. Compruebe una matriz de puntos nula al inspeccionar una ruta leída de un archivo.

**¿Un ciclo de ida y vuelta exitoso es suficiente para confirmar la reproducción?**

No. Reabrir confirma la preservación de las propiedades que verificó. Pruebe el reproductor de presentaciones o la exportación animada por separado para confirmar su comportamiento visual.