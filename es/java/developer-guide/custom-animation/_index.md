---
title: Crear y modificar comportamientos de animación personalizados en Java
linktitle: Animación personalizada
type: docs
weight: 151
url: /es/java/custom-animation/
keywords:
- animación personalizada
- comportamiento de animación
- ruta de movimiento
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Crear, inspeccionar y modificar comportamientos de animación personalizados y rutas de movimiento editables en presentaciones de PowerPoint con Aspose.Slides para Java."
---
## **Visión general**

Los comportamientos de animación personalizados le permiten controlar operaciones individuales dentro de un efecto de animación, como cambiar un color, rotar una forma o seguir una ruta de movimiento editable. Esta guía muestra cómo crear y combinar comportamientos, configurar su temporización, inspeccionar y modificar animaciones existentes, y verificar que sus propiedades sobrevivan al guardar y volver a abrir una presentación.

Para efectos predefinidos y disparadores de clic, vea [Animación de forma](/slides/es/java/shape-animation/).

## **Comprender el modelo de animación**

Una animación se organiza como **Línea de tiempo → Secuencia → Efecto → Comportamientos**:

- El método [getTimeline](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibaseslide/#getTimeline--) devuelve la línea de tiempo de la diapositiva, que contiene su secuencia principal y secuencias interactivas.
- Un [ISequence](https://reference.aspose.com/slides/es/java/com.aspose.slides/isequence/) contiene efectos, que pueden dirigirse a diferentes formas.
- Un [IEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/ieffect/) identifica una forma objetivo, preset, subtipo y temporización del efecto.
- La colección devuelta por [IEffect.getBehaviors](https://reference.aspose.com/slides/es/java/com.aspose.slides/ieffect/#getBehaviors--) contiene las operaciones que implementan el efecto: cambiar color, mover, rotar, establecer una propiedad, etc.

## **Crear comportamientos individuales**

Llame a [ISequence.addEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) para crear un efecto y acceder a la colección [getBehaviors](https://reference.aspose.com/slides/es/java/com.aspose.slides/ieffect/#getBehaviors--). Un preset puede rellenar esta colección automáticamente. Mantenga sus operaciones al ampliar el preset, o use [clear](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehaviorcollection/#clear--) cuando reemplace deliberadamente las mismas.

[IBehaviorFactory](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehaviorfactory/) crea los ocho tipos de comportamiento ilustrados a continuación. El movimiento se cubre en [Build a Motion Path](#build-a-motion-path). Cada fragmento incluye sus importaciones; coloque sus sentencias ejecutables dentro de un método. Los ejemplos de edición posterior indican qué archivo de salida utilizan.

### **Rotación**

Utilice [createRotationEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) para crear una rotación. [getBy](https://reference.aspose.com/slides/es/java/com.aspose.slides/irotationeffect/#getBy--) especifica un ángulo relativo en grados; [getFrom](https://reference.aspose.com/slides/es/java/com.aspose.slides/irotationeffect/#getFrom--) y [getTo](https://reference.aspose.com/slides/es/java/com.aspose.slides/irotationeffect/#getTo--) especifican los puntos finales.

El ejemplo comienza con un efecto Spin, reemplaza sus operaciones de preset con un comportamiento de rotación y asigna a esa operación una duración de dos segundos. Un ángulo relativo de 90 grados representa un cuarto de vuelta desde la orientación inicial de la forma, por lo que no se necesita un ángulo inicial explícito.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` contiene una forma y un comportamiento de rotación. La colección, la temporización y los ejemplos de edición de rotación a continuación utilizan este archivo.

### **Escala**

Utilice [createScaleEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) con porcentajes X/Y: [getFrom](https://reference.aspose.com/slides/es/java/com.aspose.slides/iscaleeffect/#getFrom--) y [getTo](https://reference.aspose.com/slides/es/java/com.aspose.slides/iscaleeffect/#getTo--) describen el tamaño inicial y final, mientras que [getBy](https://reference.aspose.com/slides/es/java/com.aspose.slides/iscaleeffect/#getBy--) describe un cambio relativo. Aquí, 100 significa el tamaño original.

El ejemplo incrementa ambas dimensiones del 100 % al 125 % en dos segundos. Usar porcentajes horizontales y verticales iguales mantiene las proporciones de la forma; diferentes porcentajes estirarían una dimensión más que la otra.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new Point2D.Float(100, 100));
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Color**

Utilice [createColorEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) para cambiar el relleno de azul a naranja. [getFrom](https://reference.aspose.com/slides/es/java/com.aspose.slides/icoloreffect/#getFrom--) y [getTo](https://reference.aspose.com/slides/es/java/com.aspose.slides/icoloreffect/#getTo--) son colores; [getBy](https://reference.aspose.com/slides/es/java/com.aspose.slides/icoloreffect/#getBy--) es un desplazamiento de color. [IBehavior.getProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehavior/#getProperties--) identifica el atributo que se anima.

El relleno sólido de la forma se inicializa en azul, coincidiendo con el color inicial de la animación. Seleccionar el atributo de color de relleno indica al comportamiento qué parte de la forma cambiar; los extremos de color por sí solos no identifican ese atributo. El efecto guardado describe una transición de dos segundos a naranja.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    Color orange = new Color(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filtro**

Utilice [createFilterEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) para seleccionar una borradura. [getType](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifiltereffect/#getSubtype--), y [getReveal](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifiltereffect/#getReveal--) especifican el filtro, la dirección y si revelar o ocultar la forma.

Este ejemplo configura una borradura de dos segundos que revela la forma usando el subtipo de dirección derecha. La configuración del filtro pertenece al comportamiento dentro del efecto, por lo que se configura después de haber eliminado las operaciones originales del preset.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Propiedad**

Utilice [createPropertyEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) para animar la opacidad. [getFrom](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipropertyeffect/#getTo--), y [getBy](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipropertyeffect/#getBy--) son cadenas interpretadas mediante [getValueType](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipropertyeffect/#getValueType--) y [getCalcMode](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipropertyeffect/#getCalcMode--). Elija extremos o un desplazamiento relativo en lugar de establecer los tres indiscriminadamente.

Aquí, el atributo seleccionado es opacidad, y las cadenas numéricas representan un cambio del 25 % de opacidad a opacidad completa. La interpolación lineal describe un cambio gradual entre esos valores. Al adaptar este ejemplo a otro atributo, elija un tipo de valor y valores de extremo apropiados para ese atributo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Establecer**

Utilice [createSetEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) para asignar visibilidad mediante [getTo](https://reference.aspose.com/slides/es/java/com.aspose.slides/iseteffect/#getTo--). Un comportamiento de tipo set no interpola entre los extremos.

El ejemplo selecciona el atributo de visibilidad y asigna la cadena `visible` cuando se ejecuta el comportamiento. El rectángulo ya es visible en esta presentación mínima, por lo que la asignación puede no producir un cambio visual evidente por sí sola. Esta operación es útil como parte de un efecto mayor que también controla cuándo la forma se oculta o se muestra.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Comando**

Utilice [createCommandEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) y configure [getType](https://reference.aspose.com/slides/es/java/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/es/java/com.aspose.slides/icommandeffect/#getCommandString--), y [getShapeTarget](https://reference.aspose.com/slides/es/java/com.aspose.slides/icommandeffect/#getShapeTarget--). Coloque una grabación WAV llamada `sample.wav` en el directorio de trabajo. Este ejemplo la incrusta con [addAudioFrameEmbedded](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) y adjunta un comando de reproducción al marco de audio.

El marco de audio es tanto el objetivo del efecto como el objetivo del comando. Esto conecta la solicitud de reproducción con la grabación incrustada; una cadena de comando por sí sola no identifica qué objeto multimedia controlar. El efecto se configura para iniciarse con un clic durante la presentación.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

Guardar almacena el comando en `command.pptx`; no reproduce la grabación. La reproducción requiere un reproductor de presentaciones que admita el comando y su objetivo multimedia.

## **Gestionar la colección de comportamientos**

[IBehaviorCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehaviorcollection/) admite [add](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), y [removeAt](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Este ejemplo abre `rotation.pptx`, agrega una escala, la mueve antes de la rotación y elimina la rotación. Eliminar y volver a insertar el mismo objeto cambia su posición almacenada sin crear una copia.

La secuencia de ediciones cambia la colección de rotación‑escala a escala‑rotación y, después, solo a escala. Los índices se refieren a la colección actual, por lo que la eliminación usa el nuevo índice de la rotación tras el reordenamiento. La enumeración final confirma qué comportamiento se guardará.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La salida es `ScaleEffect`: solo queda la escala. El orden de la colección no programa, por sí mismo, los comportamientos uno tras otro. Vacíe la colección solo cuando reemplace todas sus operaciones.

## **Configurar la temporización del comportamiento**

[IBehavior.getTiming](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehavior/#getTiming--) expone [ITiming](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/), de forma independiente de [IEffect.getTiming](https://reference.aspose.com/slides/es/java/com.aspose.slides/ieffect/#getTiming--). La temporización del efecto programa el efecto contenedor; la temporización del comportamiento describe una operación dentro de él.

### **Establecer duración, retraso, repetición y aceleración**

Abra `rotation.pptx` y establezca la duración ([getDuration](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#getDuration--)) y el retraso del disparador ([getTriggerDelayTime](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#getTriggerDelayTime--)) en segundos, luego configure el recuento de repeticiones mediante [setRepeatCount](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#getAccelerate--) y [getDecelerate](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#getDecelerate--) son fracciones de la duración; mantenga su suma como máximo 1.

El archivo de entrada es el creado en el ejemplo de rotación, donde se sabe que el primer comportamiento es una rotación. Este ejemplo modifica solo la temporización de ese comportamiento; su ángulo de 90 grados permanece intacto. Mantener el ángulo y la temporización separados facilita ajustar el ritmo sin reconstruir la animación.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El comportamiento usa una duración de dos segundos, un retraso de medio segundo y un recuento de repeticiones de 3. El primer y último 20 % de su duración se usan para aceleración y desaceleración.

Otras políticas de repetición incluyen [getRepeatDuration](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), y [getRepeatUntilNextClick](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--); elija una política en lugar de activarlas todas a la vez. [getAutoReverse](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#getAutoReverse--) reproduce la animación al revés después de la pasada directa. La aceleración y desaceleración se aplican a cambios continuos, no a asignaciones discretas ni a comandos.

## **Crear una ruta de movimiento**

Utilice [createMotionEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) para crear un movimiento. Sus [getFrom](https://reference.aspose.com/slides/es/java/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/es/java/com.aspose.slides/imotioneffect/#getTo--), y [getBy](https://reference.aspose.com/slides/es/java/com.aspose.slides/imotioneffect/#getBy--) describen coordenadas o desplazamientos basados en porcentajes. Para una ruta editable, cree un [MotionPath](https://reference.aspose.com/slides/es/java/com.aspose.slides/motionpath/) y asígnelo con [IMotionEffect.setPath](https://reference.aspose.com/slides/es/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/es/java/com.aspose.slides/imotionpath/) almacena los comandos de la ruta.

[MotionCommandPathType](https://reference.aspose.com/slides/es/java/com.aspose.slides/motioncommandpathtype/) selecciona la operación:

| Comando | Puntos | Significado |
| --- | --- | --- |
| MoveTo | One | Establece la posición inicial. |
| LineTo | One | Mueve a lo largo de un segmento recto hasta su punto final. |
| CurveTo | Three | Sigue una curva cúbica definida por dos puntos de control y un punto final. |
| CloseLoop | None | Vuelve a la posición inicial. |
| End | None | Finaliza la ruta. |

[MotionPathPointsType](https://reference.aspose.com/slides/es/java/com.aspose.slides/motionpathpointstype/) describe características de edición de puntos, como esquinas o puntos suaves. No sustituye al tipo de comando. Use un tipo de punto de curva para el ejemplo de curva más abajo, y un tipo de punto de esquina para los segmentos rectos.

Las coordenadas de la ruta se normalizan a las dimensiones de la diapositiva: un desplazamiento X de 0.25 representa una cuarta parte del ancho de la diapositiva, no 0.25 puntos. El eje Y positivo avanza hacia abajo. Los comandos absolutos especifican posiciones en el sistema de coordenadas de la ruta; los comandos relativos especifican desplazamientos desde la posición actual. Esto es independiente de [getOrigin](https://reference.aspose.com/slides/es/java/com.aspose.slides/imotioneffect/#getOrigin--), que selecciona el marco de referencia de la ruta, y de [getPathEditMode](https://reference.aspose.com/slides/es/java/com.aspose.slides/imotioneffect/#getPathEditMode--), que controla cómo se mueve la ruta cuando se desplaza la forma.

### **Crear una ruta recta**

Cree un comportamiento de movimiento con un punto de inicio, un segmento recto y un comando de fin. [IMotionPath.add](https://reference.aspose.com/slides/es/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) recibe el tipo de comando, sus puntos, el tipo de punto y una bandera de coordenada relativa.

El comando de inicio establece (0, 0), y la línea termina en (0.25, 0), dando a la ruta un desplazamiento horizontal de una cuarta parte del ancho de la diapositiva. El comando de fin no tiene puntos de coordenada. Una vez asignada la ruta, agregar el comportamiento de movimiento al efecto conecta esa ruta al rectángulo.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new Point2D.Float[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` contiene un comportamiento de movimiento con tres comandos de ruta. Los siguientes ejemplos de edición de archivo utilizan esta estructura conocida.

### **Comparar coordenadas absolutas y relativas**

Estos dos objetos de ruta describen la misma trayectoria. El comando absoluto termina en (0.3, 0.1); el comando relativo añade (0.1, 0.1) a la posición actual, (0.2, 0).

Ambas rutas comienzan en la misma posición. Para la línea relativa, sume sus desplazamientos X y Y a la posición actual para obtener el punto final; para la línea absoluta, lea directamente el punto final. Cambiar la bandera sin convertir las coordenadas describiría una ruta distinta.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Asigne cualquiera de las rutas a un comportamiento de movimiento para usarla en una presentación. El argumento booleano final selecciona coordenadas relativas para ese comando.

### **Reemplazar una línea con una curva**

Abra `motion.pptx` y reemplace su comando de línea con una curva cúbica. Proporcione primero los dos puntos de control y, a continuación, el punto final.

La posición de inicio está suministrada por el comando precedente. Los dos primeros puntos dan forma a la curva, mientras que el tercero es su destino; no son tres destinos sucesivos. Actualizar simultáneamente el tipo de comando, el tipo de edición de puntos y la matriz de puntos mantiene el segmento coherente con su nueva geometría.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.1f, 0), new Point2D.Float(0.2f, 0.1f), new Point2D.Float(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La ruta en `curve.pptx` sigue teniendo tres comandos; su comando intermedio ahora define una curva.

## **Inspeccionar y editar una ruta guardada**

Cada [IMotionCmdPath](https://reference.aspose.com/slides/es/java/com.aspose.slides/imotioncmdpath/) expone [getPoints](https://reference.aspose.com/slides/es/java/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/es/java/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/es/java/com.aspose.slides/imotioncmdpath/#getPointsType--), y [isRelative](https://reference.aspose.com/slides/es/java/com.aspose.slides/imotioncmdpath/#isRelative--). Los ejemplos siguientes usan la ruta conocida de tres comandos en `motion.pptx`. Para entradas arbitrarias, localice el efecto deseado y verifique los tipos de comando y la cantidad de puntos antes de editar por índice.

### **Leer comandos y coordenadas**

Lea la ruta sin modificarla. Los comandos de fin y cerrar bucle no necesitan puntos, por lo que se debe permitir una matriz de puntos nula.

La salida asocia cada tipo de comando numérico con su bandera de coordenada relativa antes de enumerar sus puntos. Esto permite distinguir un punto final de un desplazamiento antes de modificar la ruta. Una curva listaría tres puntos, mientras que la línea recta en este archivo solo lista uno.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (Point2D.Float point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

El listado contiene un punto de inicio, una línea absoluta que termina en (0.25, 0), y un comando de fin.

### **Cambiar un punto final**

Abra `motion.pptx` y reemplace la matriz de puntos de la línea para mover su punto final.

En el archivo de entrada, el índice 0 es el comando de inicio y el índice 1 es la línea. Reemplazar el único punto de la línea cambia su destino sin alterar el tipo de comando, la temporización o la posición en la colección. Como el comando usa coordenadas absolutas, el nuevo par especifica una posición en lugar de un desplazamiento añadido.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La línea en `motion-endpoint.pptx` termina en (0.4, 0.1); el archivo original permanece sin cambios.

### **Reemplazar un segmento**

Use [insert](https://reference.aspose.com/slides/es/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) y [removeAt](https://reference.aspose.com/slides/es/java/com.aspose.slides/imotionpath/#removeAt-int-) para reemplazar la línea en `motion.pptx`. Insertar desplaza la línea antigua al índice 2.

Esto demuestra cómo reemplazar un objeto de comando en vez de editar sus coordenadas existentes. Después de la inserción, la colección temporalmente contiene el comando de inicio, la nueva línea, la línea antigua y el comando de fin. Eliminar el índice 2 descarta la línea antigua y deja la nueva ruta en su lugar.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La ruta guardada sigue teniendo tres comandos, con la nueva línea terminando en (0.2, 0.1) y el comando de fin al final.

## **Modificar y verificar un comportamiento existente**

Cuando se desconoce el índice del comportamiento, selecciónelo por tipo. Este ejemplo abre `rotation.pptx`, encuentra su [IRotationEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/irotationeffect/), cambia el ángulo y comprueba el valor guardado tras volver a abrirlo.

La verificación de tipo permite que el bucle omita los comportamientos que no son rotaciones. La segunda carga lee el archivo guardado en un objeto de presentación separado, de modo que la comparación verifica los datos persistentes en lugar del valor que aún permanece en memoria. Este ejemplo sigue asumiendo que el efecto conocido es el primero en la secuencia principal; seleccionar un comportamiento por tipo no ubica el efecto correcto en una presentación arbitraria.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

La salida es `Rotation preserved: true`. Aplique el mismo patrón de verificación por tipo a otros comportamientos. Para una comprobación completa de preservación, compare la forma objetivo, el efecto, los tipos y el orden de los comportamientos, la temporización y los comandos de ruta. Use una tolerancia numérica para valores de punto flotante. Para una presentación con una disposición de animación desconocida, vea [Read Shape Animations](/slides/es/java/shape-animation/#read-shape-animations) para recorrer las secuencias principal e interactiva.

## **Orden de comportamiento, presets y reproducción**

El orden en [IBehaviorCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehaviorcollection/) es el orden almacenado de las operaciones de un efecto. No es una lista de reproducción en la que cada comportamiento espere automáticamente al anterior. La temporización y el efecto contenedor determinan la programación. Los comportamientos pueden solaparse, y las operaciones sobre la misma propiedad pueden interactuar mediante [getAdditive](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehavior/#getAdditive--) y [getAccumulate](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibehavior/#getAccumulate--). No utilice solo el reordenamiento de la colección para programar “mover, luego rotar”; use temporización explícita o efectos separados como se describe en [Animación de forma](/slides/es/java/shape-animation/).

El [getType](https://reference.aspose.com/slides/es/java/com.aspose.slides/ieffect/#getType--) y el [getSubtype](https://reference.aspose.com/slides/es/java/com.aspose.slides/ieffect/#getSubtype--) del efecto describen su preset. No son una descripción completa de un árbol de comportamientos editado. Elija el preset y el subtipo antes de personalizar los comportamientos: cambiar el preset puede reconstruir la colección y descartar sus operaciones personalizadas. Por ejemplo, cambiar un efecto Spin personalizado a Fade puede sustituir su comportamiento de rotación por comportamientos de set y filter. Inspeccione la colección nuevamente tras cambiar un preset o subtipo. Vaciar los comportamientos del preset también puede eliminar operaciones de visibilidad o inicialización que el preset necesita. Los ejemplos usan deliberadamente formas visibles y reemplazan los comportamientos; no reconstruyen la implementación de cada preset.

## **Compatibilidad de formatos**

Un árbol de comportamientos preservado no garantiza una reproducción idéntica en todos los visores o motores de exportación. Verifique los datos guardados y la salida renderizada por separado.

| Formato o salida | Qué verificar |
| --- | --- |
| PPTX | Utilizar como formato principal para estos ejemplos. Reabrir para verificar el árbol de comportamientos editable, luego comprobar la reproducción en la versión de PowerPoint deseada. |
| PPT | La representación binaria heredada puede diferir de PPTX. Pruebe un ciclo separado de guardar‑abrir y reproducción; no infiera compatibilidad para cada combinación personalizada a partir de un resultado exitoso en PPTX. |
| PDF, PNG, JPEG y otras imágenes estáticas de diapositivas | Contienen una representación estática de la diapositiva, no una línea de tiempo reproducible ni un cuadro de animación final garantizado. |
| [HTML5](/slides/es/java/export-to-html5/) | Puede reproducir animaciones compatibles cuando la animación de forma está habilitada en las opciones de exportación. Pruebe combinaciones personalizadas en el navegador. |
| [Animated GIF](/slides/es/java/convert-powerpoint-to-animated-gif/) | Almacena fotogramas renderizados, no comportamientos editables ni interacción activada por clic. Verifique el movimiento renderizado real. |
| [Video](/slides/es/java/convert-powerpoint-to-video/) | Renderiza fotogramas de animación y los codifica como vídeo. El soporte está limitado a las [animaciones y efectos compatibles](/slides/es/java/convert-powerpoint-to-video/#supported-animations-and-effects) del renderizador; los comandos y eventos interactivos no se convierten en una línea de tiempo editable. |

## **Preguntas frecuentes**

**¿Por qué mi efecto contiene comportamientos antes de añadir ninguno?**

Crear un efecto predefinido puede crear sus operaciones subyacentes. Inspecciónelas antes de decidir si ampliar el preset o reemplazar sus comportamientos.

**¿Mover un comportamiento al principio hace que se reproduzca primero?**

No necesariamente. El orden de la colección no sustituye a la temporización. Verifique retrasos, duraciones e interacciones entre operaciones sobre la misma propiedad.

**¿Por qué un comando de fin no tiene puntos?**

Marca el final de la ruta y no necesita coordenadas. Al inspeccionar una ruta leída de un archivo, compruebe una matriz de puntos nula.

**¿Es suficiente un viaje de ida y vuelta exitoso para confirmar la reproducción?**

No. Reabrir confirma la preservación de las propiedades que verificó. Pruebe el reproductor de presentaciones o la exportación animada por separado para confirmar su comportamiento visual.