---
title: Crear y modificar comportamientos de animación personalizados en PHP
linktitle: Animación personalizada
type: docs
weight: 151
url: /es/php-java/custom-animation/
keywords:
- animación personalizada
- comportamiento de animación
- ruta de movimiento
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Crear, inspeccionar y modificar comportamientos de animación personalizados y rutas de movimiento editables en presentaciones de PowerPoint con Aspose.Slides para PHP mediante Java."
---
## **Visión general**

Los comportamientos de animación personalizados le permiten controlar operaciones individuales dentro de un efecto de animación, como cambiar un color, girar una forma o seguir una ruta de movimiento editable. Esta guía muestra cómo crear y combinar comportamientos, configurar su temporización, inspeccionar y modificar animaciones existentes, y verificar que sus propiedades sobrevivan al guardar y volver a abrir una presentación.

Para efectos predefinidos y desencadenadores de clic, vea [Animación de formas](/slides/es/php-java/shape-animation/).

## **Comprender el modelo de animación**

Una animación se organiza como **Timeline → Sequence → Effect → Behaviors**:

- Cada diapositiva tiene una línea de tiempo que contiene su secuencia principal y secuencias interactivas.
- Una [Sequence](https://reference.aspose.com/slides/es/php-java/aspose.slides/sequence/) contiene efectos, que pueden dirigirse a diferentes formas.
- Un [Effect](https://reference.aspose.com/slides/es/php-java/aspose.slides/effect/) identifica una forma objetivo, un ajuste preestablecido, un subtipo y la temporización del efecto.
- La colección devuelta por [Effect::getBehaviors](https://reference.aspose.com/slides/es/php-java/aspose.slides/effect/getbehaviors/) contiene las operaciones que implementan el efecto: cambiar color, mover, girar, establecer una propiedad, etc.

## **Crear comportamientos individuales**

Llame a [Sequence::addEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/sequence/addeffect/) para crear un efecto y acceder a la colección [getBehaviors](https://reference.aspose.com/slides/es/php-java/aspose.slides/effect/getbehaviors/). Un ajuste preestablecido puede rellenar esta colección automáticamente. Mantenga sus operaciones al ampliar el ajuste preestablecido, o use [clear](https://reference.aspose.com/slides/es/php-java/aspose.slides/behaviorcollection/clear/) cuando las reemplace deliberadamente.

[BehaviorFactory](https://reference.aspose.com/slides/es/php-java/aspose.slides/behaviorfactory/) crea los ocho tipos de comportamiento ilustrados a continuación. El movimiento se trata en [Crear una ruta de movimiento](#build-a-motion-path). Cada fragmento incluye sus importaciones y supone que el puente PHP/Java y la biblioteca Aspose.Slides PHP ya se han cargado. Los ejemplos de edición posteriores indican qué archivo de salida utilizan.

### **Rotación**

Utilice [createRotationEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/behaviorfactory/createrotationeffect/) para crear una rotación. [getBy](https://reference.aspose.com/slides/es/php-java/aspose.slides/rotationeffect/getby/) especifica un ángulo relativo en grados; [getFrom](https://reference.aspose.com/slides/es/php-java/aspose.slides/rotationeffect/getfrom/) y [getTo](https://reference.aspose.com/slides/es/php-java/aspose.slides/rotationeffect/getto/) especifican los extremos.

El ejemplo comienza con un efecto Spin, sustituye sus operaciones preestablecidas por un comportamiento de rotación y asigna a esa operación una duración de dos segundos. Un ángulo relativo de 90 grados representa un cuarto de vuelta desde la orientación inicial de la forma, por lo que no se necesita un ángulo inicial explícito.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $rotation = $factory->createRotationEffect();
    $rotation->setBy(90);
    $rotation->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($rotation);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`rotation.pptx` contiene una forma y un comportamiento de rotación. La colección, la temporización y los ejemplos de edición de rotación a continuación usan este archivo.

### **Escala**

Utilice [createScaleEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/behaviorfactory/createscaleeffect/) con porcentajes X/Y: [getFrom](https://reference.aspose.com/slides/es/php-java/aspose.slides/scaleeffect/getfrom/) y [getTo](https://reference.aspose.com/slides/es/php-java/aspose.slides/scaleeffect/getto/) describen el tamaño inicial y final, mientras que [getBy](https://reference.aspose.com/slides/es/php-java/aspose.slides/scaleeffect/getby/) describe un cambio relativo. Aquí, 100 significa el tamaño original.

El ejemplo aumenta ambas dimensiones del 100 % al 125 % en dos segundos. Usar porcentajes horizontales y verticales iguales mantiene las proporciones de la forma; porcentajes diferentes estirarían una dimensión más que la otra.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $initialSize = new Point2DFloat(100, 100);
    $scale->setFrom($initialSize);
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($scale);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Color**

Utilice [createColorEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/behaviorfactory/createcoloreffect/) para cambiar el relleno de azul a naranja. [getFrom](https://reference.aspose.com/slides/es/php-java/aspose.slides/coloreffect/getfrom/) y [getTo](https://reference.aspose.com/slides/es/php-java/aspose.slides/coloreffect/getto/) son colores; [getBy](https://reference.aspose.com/slides/es/php-java/aspose.slides/coloreffect/getby/) es un desplazamiento de color. La [BehaviorPropertyCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/behaviorpropertycollection/) del comportamiento identifica el atributo que se anima.

El relleno sólido de la forma se inicializa en azul, coincidiendo con el color inicial de la animación. Seleccionar el atributo de color de relleno indica al comportamiento qué parte de la forma cambiar; los colores finales por sí solos no identifican ese atributo. El efecto guardado describe una transición de dos segundos a naranja.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$blue = new Java("java.awt.Color", 0, 0, 255);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor($blue);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $color = $factory->createColorEffect();
    $color->getProperties()->add(BehaviorProperty::getFillColor()->getValue());
    $color->getFrom()->setColor($blue);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $color->getTo()->setColor($orange);
    $color->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($color);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Filtro**

Utilice [createFilterEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/behaviorfactory/createfiltereffect/) para seleccionar un borrado. [getType](https://reference.aspose.com/slides/es/php-java/aspose.slides/filtereffect/gettype/), [getSubtype](https://reference.aspose.com/slides/es/php-java/aspose.slides/filtereffect/getsubtype/), y [getReveal](https://reference.aspose.com/slides/es/php-java/aspose.slides/filtereffect/getreveal/) especifican el filtro, la dirección y si revelar o ocultar la forma.

Este ejemplo configura un borrado de dos segundos que revela la forma usando el subtipo de dirección derecha. Los ajustes del filtro pertenecen al comportamiento dentro del efecto, por lo que se configuran después de eliminar las operaciones originales del preestablecido.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FilterEffectRevealType;
use aspose\slides\FilterEffectSubtype;
use aspose\slides\FilterEffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $filter = $factory->createFilterEffect();
    $filter->setType(FilterEffectType::Wipe);
    $filter->setSubtype(FilterEffectSubtype::Right);
    $filter->setReveal(FilterEffectRevealType::In);
    $filter->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($filter);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "filter.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Propiedad**

Utilice [createPropertyEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) para animar la opacidad. [getFrom](https://reference.aspose.com/slides/es/php-java/aspose.slides/propertyeffect/getfrom/), [getTo](https://reference.aspose.com/slides/es/php-java/aspose.slides/propertyeffect/getto/), y [getBy](https://reference.aspose.com/slides/es/php-java/aspose.slides/propertyeffect/getby/) son cadenas interpretadas mediante [getValueType](https://reference.aspose.com/slides/es/php-java/aspose.slides/propertyeffect/getvaluetype/) y [getCalcMode](https://reference.aspose.com/slides/es/php-java/aspose.slides/propertyeffect/getcalcmode/). Elija puntos finales o un desplazamiento relativo en lugar de establecer los tres indiscriminadamente.

En este caso, el atributo seleccionado es la opacidad, y las cadenas numéricas representan un cambio del 25 % de opacidad a opacidad total. La interpolación lineal describe un cambio gradual entre esos valores. Al adaptar este ejemplo a otro atributo, elija un tipo de valor y valores finales adecuados para ese atributo.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\PropertyCalcModeType;
use aspose\slides\PropertyValueType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $property = $factory->createPropertyEffect();
    $property->getProperties()->add(BehaviorProperty::getStyleOpacity()->getValue());
    $property->setValueType(PropertyValueType::Number);
    $property->setCalcMode(PropertyCalcModeType::Linear);
    $property->setFrom("0.25");
    $property->setTo("1");
    $property->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($property);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "property.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Establecer**

Utilice [createSetEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/behaviorfactory/createseteffect/) para asignar visibilidad mediante [getTo](https://reference.aspose.com/slides/es/php-java/aspose.slides/seteffect/getto/). Un comportamiento de tipo set no interpola entre los extremos.

El ejemplo selecciona el atributo de visibilidad y asigna la cadena `visible` cuando se ejecuta el comportamiento. El rectángulo ya es visible en esta presentación mínima, por lo que la asignación puede no producir un cambio visual evidente por sí sola. Esta operación es útil como parte de un efecto mayor que también controla cuándo la forma se oculta o se muestra.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $set = $factory->createSetEffect();
    $set->getProperties()->add(BehaviorProperty::getStyleVisibility()->getValue());
    $set->setTo("visible");

    $effect->getBehaviors()->add($set);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "set.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Comando**

Utilice [createCommandEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/behaviorfactory/createcommandeffect/) y configure [getType](https://reference.aspose.com/slides/es/php-java/aspose.slides/commandeffect/gettype/), [getCommandString](https://reference.aspose.com/slides/es/php-java/aspose.slides/commandeffect/getcommandstring/), y [getShapeTarget](https://reference.aspose.com/slides/es/php-java/aspose.slides/commandeffect/getshapetarget/). Coloque una grabación WAV llamada `sample.wav` en el directorio de trabajo. Este ejemplo la incrusta con [addAudioFrameEmbedded](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/addaudioframeembedded/) y adjunta un comando de reproducción al marco de audio.

El marco de audio es tanto el objetivo del efecto como el objetivo del comando. Esto conecta la solicitud de reproducción con la grabación incrustada; una cadena de comando por sí sola no identifica qué objeto multimedia controlar. El efecto se configura para iniciarse con un clic durante la presentación.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\CommandEffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioPath = $baseDirectory . DIRECTORY_SEPARATOR . "sample.wav";
    $audioStream = new Java("java.io.FileInputStream", $audioPath);
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(100, 100, 40, 40, $audioStream);

        $effect = $slide->getTimeline()->getMainSequence()->addEffect($audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
        $effect->getBehaviors()->clear();

        $factory = new BehaviorFactory();
        $command = $factory->createCommandEffect();
        $command->setType(CommandEffectType::Call);
        $command->setCommandString("play");
        $command->setShapeTarget($audioFrame);

        $effect->getBehaviors()->add($command);

        $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "command.pptx", SaveFormat::Pptx);
    } finally {
        $audioStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Guardar almacena el comando en `command.pptx`; no reproduce la grabación. La reproducción requiere un reproductor de presentaciones que admita el comando y su objetivo multimedia.

## **Gestionar la colección de comportamientos**

[BehaviorCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/behaviorcollection/) soporta [add](https://reference.aspose.com/slides/es/php-java/aspose.slides/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/es/php-java/aspose.slides/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/es/php-java/aspose.slides/behaviorcollection/remove/), y [removeAt](https://reference.aspose.com/slides/es/php-java/aspose.slides/behaviorcollection/removeat/). Este ejemplo abre `rotation.pptx`, añade una escala, la mueve antes de la rotación y elimina la rotación. Eliminar y volver a insertar el mismo objeto cambia su posición almacenada sin crear una copia.

La secuencia de ediciones cambia la colección de rotación‑escala a escala‑rotación y, finalmente, a solo escala. Los índices se refieren a la colección actual, por lo que la eliminación usa el nuevo índice de la rotación después del reordenamiento. La enumeración final confirma qué comportamiento se guardará.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $behaviors = $effect->getBehaviors();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $behaviors->add($scale);

    $behaviors->remove($scale);
    $behaviors->insert(0, $scale);
    $behaviors->removeAt(1);

    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        echo java_values($behavior->getClass()->getSimpleName()) . PHP_EOL;
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "collection-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La salida es `ScaleEffect`: solo queda la escala. El orden de la colección no programa, por sí mismo, los comportamientos uno tras otro. Vacíe la colección solo cuando reemplace todas sus operaciones.

## **Configurar la temporización del comportamiento**

Un comportamiento tiene su propio [Timing](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/), independiente de la temporización devuelta por [Effect::getTiming](https://reference.aspose.com/slides/es/php-java/aspose.slides/effect/gettiming/). La temporización del efecto programa el efecto contenedor; la temporización del comportamiento describe una operación dentro de él.

### **Establecer duración, retraso, repetición y aceleración**

Abra `rotation.pptx` y establezca la duración ([getDuration](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/getduration/)) y el retraso de activación ([getTriggerDelayTime](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/gettriggerdelaytime/)) en segundos, luego configure el recuento de repeticiones mediante [setRepeatCount](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/setrepeatcount/). [getAccelerate](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/getaccelerate/) y [getDecelerate](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/getdecelerate/) son fracciones de la duración; mantenga su suma como máximo 1.

El archivo de entrada es el creado en el ejemplo de rotación, donde se sabe que el primer comportamiento es una rotación. Este ejemplo solo cambia la temporización de ese comportamiento; su ángulo de 90 ° permanece intacto. Mantener ángulo y temporización separados facilita ajustar el ritmo sin reconstruir la animación.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $rotation = $effect->getBehaviors()->get_Item(0);
    $rotation->getTiming()->setDuration(2);
    $rotation->getTiming()->setTriggerDelayTime(0.5);
    $rotation->getTiming()->setRepeatCount(3);
    $rotation->getTiming()->setAccelerate(0.2);
    $rotation->getTiming()->setDecelerate(0.2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El comportamiento usa una duración de dos segundos, un retraso de medio segundo y un recuento de repeticiones de 3. El 20 % inicial y el 20 % final de su duración se usan para aceleración y desaceleración.

Otras políticas de repetición incluyen [getRepeatDuration](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/getrepeatduration/), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/getrepeatuntilendslide/), y [getRepeatUntilNextClick](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/getrepeatuntilnextclick/); elija una política en lugar de habilitarlas todas a la vez. [getAutoReverse](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/getautoreverse/) reproduce la animación al revés después del paso hacia adelante. La aceleración y desaceleración se aplican a cambios continuos, no a asignaciones discretas o comandos.

## **Crear una ruta de movimiento**

Utilice [createMotionEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/behaviorfactory/createmotioneffect/) para crear movimiento. Sus [getFrom](https://reference.aspose.com/slides/es/php-java/aspose.slides/motioneffect/getfrom/), [getTo](https://reference.aspose.com/slides/es/php-java/aspose.slides/motioneffect/getto/), y [getBy](https://reference.aspose.com/slides/es/php-java/aspose.slides/motioneffect/getby/) describen coordenadas o desplazamientos basados en porcentajes. Para una ruta editable, cree un [MotionPath](https://reference.aspose.com/slides/es/php-java/aspose.slides/motionpath/) y asígnelo con [MotionEffect::setPath](https://reference.aspose.com/slides/es/php-java/aspose.slides/motioneffect/setpath/). [MotionPath](https://reference.aspose.com/slides/es/php-java/aspose.slides/motionpath/) almacena los comandos de la ruta.

[MotionCommandPathType](https://reference.aspose.com/slides/es/php-java/aspose.slides/motioncommandpathtype/) selecciona la operación:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Set the starting position. |
| LineTo | One | Move along a straight segment to its endpoint. |
| CurveTo | Three | Follow a cubic curve defined by two control points and an endpoint. |
| CloseLoop | None | Return to the starting position. |
| End | None | Finish the path. |

[MotionPathPointsType](https://reference.aspose.com/slides/es/php-java/aspose.slides/motionpathpointstype/) describe características de edición de puntos, como puntos de esquina o suaves. No sustituye al tipo de comando. Use un tipo de punto de curva para el ejemplo de curva a continuación, y un tipo de punto de esquina para los segmentos rectos.

Las coordenadas de la ruta están normalizadas respecto a las dimensiones de la diapositiva: un desplazamiento X de 0,25 representa una cuarta parte del ancho de la diapositiva, no 0,25 puntos. El eje Y positivo desciende. Los comandos absolutos especifican posiciones en el sistema de coordenadas de la ruta; los comandos relativos especifican desplazamientos desde la posición actual. Esto es independiente de [getOrigin](https://reference.aspose.com/slides/es/php-java/aspose.slides/motioneffect/getorigin/), que selecciona el marco de referencia de la ruta, y de [getPathEditMode](https://reference.aspose.com/slides/es/php-java/aspose.slides/motioneffect/getpatheditmode/), que controla cómo se mueve la ruta cuando se mueve la forma.

### **Crear una ruta recta**

Cree un comportamiento de movimiento con un punto inicial, un segmento recto y un comando de fin. [MotionPath::add](https://reference.aspose.com/slides/es/php-java/aspose.slides/motionpath/add/) recibe el tipo de comando, sus puntos, el tipo de punto y una bandera de coordenada relativa.

El comando inicial establece (0, 0) y la línea termina en (0.25, 0), dando a la ruta un desplazamiento horizontal de una cuarta parte del ancho de la diapositiva. El comando final no tiene puntos de coordenadas. Una vez asignada la ruta, añadir el comportamiento de movimiento al efecto conecta esa ruta al rectángulo.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionOriginType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $motion = $factory->createMotionEffect();
    $motion->setOrigin(MotionOriginType::Layout);
    $motion->getTiming()->setDuration(2);

    $path = new MotionPath();
    $startPoints = [new Point2DFloat(0, 0)];
    $path->add(MotionCommandPathType::MoveTo, $startPoints, MotionPathPointsType::Auto, false);
    $endPoints = [new Point2DFloat(0.25, 0)];
    $path->add(MotionCommandPathType::LineTo, $endPoints, MotionPathPointsType::Corner, false);
    $path->add(MotionCommandPathType::End, [], MotionPathPointsType::None, false);

    $motion->setPath($path);
    $effect->getBehaviors()->add($motion);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion.pptx` contiene un comportamiento de movimiento con tres comandos de ruta. Los siguientes ejemplos de edición de archivos usan esta estructura conocida.

### **Comparar coordenadas absolutas y relativas**

Estos dos objetos de ruta describen el mismo trayecto. El comando absoluto termina en (0.3, 0.1); el comando relativo añade (0.1, 0.1) a la posición actual, (0.2, 0).

Ambas rutas empiezan en la misma posición. Para la línea relativa, sume sus desplazamientos X e Y a la posición actual para obtener el punto final; para la línea absoluta, lea directamente el punto final. Cambiar la bandera sin convertir las coordenadas describiría una ruta diferente.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;

$absolutePath = new MotionPath();
$absoluteStart = [new Point2DFloat(0.2, 0)];
$absolutePath->add(MotionCommandPathType::MoveTo, $absoluteStart, MotionPathPointsType::Auto, false);
$absoluteEnd = [new Point2DFloat(0.3, 0.1)];
$absolutePath->add(MotionCommandPathType::LineTo, $absoluteEnd, MotionPathPointsType::Corner, false);

$relativePath = new MotionPath();
$relativeStart = [new Point2DFloat(0.2, 0)];
$relativePath->add(MotionCommandPathType::MoveTo, $relativeStart, MotionPathPointsType::Auto, false);
$relativeOffset = [new Point2DFloat(0.1, 0.1)];
$relativePath->add(MotionCommandPathType::LineTo, $relativeOffset, MotionPathPointsType::Corner, true);
```

Asigne cualquiera de las rutas a un comportamiento de movimiento para usarla en una presentación. El último argumento booleano selecciona coordenadas relativas para ese comando.

### **Reemplazar una línea por una curva**

Abra `motion.pptx` y reemplace su comando de línea por una curva cúbica. Proporcione primero los dos puntos de control y, a continuación, el punto final.

La posición inicial la aporta el comando precedente. Los dos primeros puntos dan forma a la curva, mientras que el tercero es su destino; no son tres destinos sucesivos. Actualizar simultáneamente el tipo de comando, el tipo de edición de puntos y el arreglo de puntos mantiene el segmento coherente con su nueva geometría.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $path->get_Item(1)->setCommandType(MotionCommandPathType::CurveTo);
    $path->get_Item(1)->setPointsType(MotionPathPointsType::CurveSmooth);
    $curvePoints = [new Point2DFloat(0.1, 0), new Point2DFloat(0.2, 0.1), new Point2DFloat(0.3, 0.1)];
    $path->get_Item(1)->setPoints($curvePoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "curve.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La ruta en `curve.pptx` sigue teniendo tres comandos; su comando intermedio ahora define una curva.

## **Inspeccionar y editar una ruta guardada**

Cada [MotionCmdPath](https://reference.aspose.com/slides/es/php-java/aspose.slides/motioncmdpath/) expone [getPoints](https://reference.aspose.com/slides/es/php-java/aspose.slides/motioncmdpath/getpoints/), [getCommandType](https://reference.aspose.com/slides/es/php-java/aspose.slides/motioncmdpath/getcommandtype/), [getPointsType](https://reference.aspose.com/slides/es/php-java/aspose.slides/motioncmdpath/getpointstype/), y [isRelative](https://reference.aspose.com/slides/es/php-java/aspose.slides/motioncmdpath/isrelative/). Los siguientes ejemplos usan la ruta conocida de tres comandos en `motion.pptx`. Para entradas arbitrarias, localice el efecto deseado y compruebe los tipos de comando y la cantidad de puntos antes de editar por índice.

### **Leer comandos y coordenadas**

Lea la ruta sin modificarla. Los comandos de fin y de cierre de bucle no requieren puntos, así que permita un arreglo de puntos nulo.

La salida empareja cada tipo numérico de comando con su bandera de coordenada relativa antes de enumerar sus puntos. Esto le permite distinguir un punto final de un desplazamiento antes de modificar la ruta. Una curva listaría tres puntos, mientras que la línea recta en este archivo solo lista uno.

```php
use aspose\slides\Presentation;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $commandCount = java_values($path->getCount());
    for ($i = 0; $i < $commandCount; $i++) {
        $segment = $path->get_Item($i);
        $commandType = java_values($segment->getCommandType());
        $relative = java_values($segment->isRelative()) ? "true" : "false";
        echo $commandType . ", relative: " . $relative . PHP_EOL;
        $points = $segment->getPoints();
        if (!java_is_null($points)) {
            foreach ($points as $point) {
                echo "X=" . java_values($point->getX()) . ", Y=" . java_values($point->getY()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

El listado contiene un punto inicial, una línea absoluta que termina en (0.25, 0), y un comando de fin.

### **Cambiar un punto final**

Abra `motion.pptx` y reemplace el arreglo de puntos de la línea para mover su punto final.

En el archivo de entrada, el índice 0 es el comando inicial y el índice 1 es la línea. Reemplazar el único punto de la línea cambia su destino sin alterar su tipo de comando, temporización o posición en la colección. Como el comando usa coordenadas absolutas, el nuevo par especifica una posición en lugar de un desplazamiento añadido.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $motion = $effect->getBehaviors()->get_Item(0);
    $endPoints = [new Point2DFloat(0.4, 0.1)];
    $motion->getPath()->get_Item(1)->setPoints($endPoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-endpoint.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La línea en `motion-endpoint.pptx` termina en (0.4, 0.1); el archivo original permanece sin cambios.

### **Reemplazar un segmento**

Utilice [insert](https://reference.aspose.com/slides/es/php-java/aspose.slides/motionpath/insert/) y [removeAt](https://reference.aspose.com/slides/es/php-java/aspose.slides/motionpath/removeat/) para sustituir la línea en `motion.pptx`. La inserción desplaza la línea antigua al índice 2.

Esto demuestra cómo reemplazar un objeto de comando en lugar de editar sus coordenadas existentes. Después de la inserción, la colección contiene temporalmente el comando inicial, la nueva línea, la línea antigua y el comando de fin. Eliminar el índice 2 descarta la línea antigua y deja la nueva ruta en su lugar.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $replacementPoints = [new Point2DFloat(0.2, 0.1)];
    $path->insert(1, MotionCommandPathType::LineTo, $replacementPoints, MotionPathPointsType::Corner, false);
    $path->removeAt(2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La ruta guardada sigue teniendo tres comandos, con la nueva línea terminando en (0.2, 0.1) y el comando de fin al final.

## **Modificar y verificar un comportamiento existente**

Cuando se desconoce el índice del comportamiento, selecciónelo por tipo. Este ejemplo abre `rotation.pptx`, encuentra su [RotationEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/rotationeffect/), cambia el ángulo y comprueba el valor guardado después de volver a abrir.

La comprobación de tipo permite que el bucle omita los comportamientos que no son rotaciones. La segunda carga lee el archivo guardado en un objeto de presentación separado, de modo que la comparación verifica los datos persistentes y no el valor aún en memoria. Este ejemplo supone que el efecto conocido es el primero en la secuencia principal; seleccionar un comportamiento por tipo no localiza el efecto correcto en una presentación arbitraria.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$rotationClass = new JavaClass("com.aspose.slides.IRotationEffect");

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $behaviors = $effect->getBehaviors();
    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        if (java_instanceof($behavior, $rotationClass)) {
            $rotation = $behavior;
            $rotation->setBy(180);
        }
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx", SaveFormat::Pptx);

    $reopened = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx");
    try {
        $savedEffect = $reopened->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

        $savedBehaviors = $savedEffect->getBehaviors();
        $savedBehaviorCount = java_values($savedBehaviors->getCount());
        for ($i = 0; $i < $savedBehaviorCount; $i++) {
            $behavior = $savedBehaviors->get_Item($i);
            if (java_instanceof($behavior, $rotationClass)) {
                $rotation = $behavior;
                $preserved = abs(java_values($rotation->getBy()) - 180) < 0.001;
                echo "Rotation preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
            }
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

La salida es `Rotation preserved: true`. Aplique el mismo patrón de comprobación de tipo a otros comportamientos. Para una verificación completa de preservación, compare la forma objetivo, el efecto, los tipos y el orden de los comportamientos, la temporización y los comandos de ruta. Use una tolerancia numérica para valores de punto flotante. Para una presentación con una disposición de animación desconocida, consulte [Read Shape Animations](/slides/es/php-java/shape-animation/#read-shape-animations) para recorrer secuencias principales e interactivas.

## **Orden de los comportamientos, preajustes y reproducción**

El orden en [BehaviorCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/behaviorcollection/) es el orden almacenado de las operaciones de un efecto. No es una lista de reproducción en la que cada comportamiento espere automáticamente al anterior. La temporización y el efecto contenedor determinan la programación. Los comportamientos pueden solaparse, y las operaciones sobre la misma propiedad pueden interactuar mediante configuraciones [additive](https://reference.aspose.com/slides/es/php-java/aspose.slides/behavioradditivetype/) y [accumulation](https://reference.aspose.com/slides/es/php-java/aspose.slides/behavioraccumulatetype/). No utilice solo el reordenamiento de la colección para programar “mover, luego girar”; use temporización explícita o efectos separados como se describe en [Animación de formas](/slides/es/php-java/shape-animation/).

Los métodos [getType](https://reference.aspose.com/slides/es/php-java/aspose.slides/effect/gettype/) y [getSubtype](https://reference.aspose.com/slides/es/php-java/aspose.slides/effect/getsubtype/) del efecto describen su preajuste. No constituyen una descripción completa de un árbol de comportamientos editado. Elija el preajuste y el subtipo antes de personalizar los comportamientos: cambiar el preajuste puede reconstruir la colección y descartar sus operaciones personalizadas. Por ejemplo, cambiar un efecto Spin personalizado a Fade puede reemplazar su comportamiento de rotación por comportamientos de set y filter. Inspeccione nuevamente la colección después de cambiar un preajuste o subtipo. Vaciar los comportamientos del preajuste también puede eliminar operaciones de visibilidad o inicialización que el preajuste necesita. Los ejemplos usan deliberadamente formas visibles y reemplazan los comportamientos; no reconstruyen la implementación completa de cada preajuste.

## **Compatibilidad de formatos**

Un árbol de comportamientos preservado no garantiza una reproducción idéntica en todos los visores o renderizadores de exportación. Verifique los datos guardados y la salida renderizada por separado.

| Format or output | What to verify |
| --- | --- |
| PPTX | Use as the primary format for these examples. Reopen it to verify the editable behavior tree, then check playback in the intended PowerPoint version. |
| PPT | Legacy binary representation can differ from PPTX. Test a separate save-and-reopen cycle and playback; do not infer support for every custom combination from successful PPTX output. |
| PDF, PNG, JPEG, and other static slide images | Contain a static slide representation, not a playable behavior timeline or a guaranteed final animation frame. |
| [HTML5](/slides/es/php-java/export-to-html5/) | Can play supported animations when shape animation is enabled in the export options. Test custom combinations in the browser. |
| [Animated GIF](/slides/es/php-java/convert-powerpoint-to-animated-gif/) | Stores rendered frames, not editable behaviors or click-triggered interaction. Check the actual rendered motion. |
| [Video](/slides/es/php-java/convert-powerpoint-to-video/) | Render animation frames and encode them as video. Support is limited to the renderer's [supported animations and effects](/slides/es/php-java/convert-powerpoint-to-video/#supported-animations-and-effects); commands and interactive events do not become an editable timeline. |

## **FAQ**

**Why does my effect contain behaviors before I add any?**  
Crear un efecto predefinido puede crear sus operaciones subyacentes. Inspeccionalas antes de decidir si ampliar el preajuste o reemplazar sus comportamientos.

**Does moving a behavior to the beginning make it play first?**  
No necesariamente. El orden de la colección no sustituye a la temporización. Verifique retrasos, duraciones e interacciones entre operaciones sobre la misma propiedad.

**Why does an end command have no points?**  
Marca el final de la ruta y no necesita coordenadas. Compruebe que el arreglo de puntos sea nulo al inspeccionar una ruta leída de un archivo.

**Is a successful round trip sufficient to confirm playback?**  
No. Reabrir confirma la preservación de las propiedades que comprobó. Pruebe el reproductor de presentaciones o la exportación animada por separado para confirmar su comportamiento visual.