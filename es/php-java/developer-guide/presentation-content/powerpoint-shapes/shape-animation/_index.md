---
title: Aplicar animaciones de forma en presentaciones usando PHP
linktitle: Animación de forma
type: docs
weight: 60
url: /es/php-java/shape-animation/
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
- PHP
- Aspose.Slides
description: "Aprenda cómo añadir, inspeccionar y personalizar animaciones de forma, temporización, sonidos, comportamiento después de la animación y texto animado con Aspose.Slides para PHP mediante Java."
---
## **Visión general**

Aspose.Slides para PHP mediante Java representa las animaciones de diapositiva como efectos en una línea de tiempo de diapositiva. Un efecto tiene una forma objetivo, un tipo y subtipo de animación, un disparador, configuraciones de tiempo y propiedades opcionales como sonido o comportamiento después de la animación.

La línea de tiempo contiene dos tipos de secuencias:

- La **secuencia principal** se reproduce al avanzar la diapositiva.
- Una **secuencia interactiva** se inicia cuando se hace clic en su forma disparadora.

Dado que los cuadros de texto, imágenes, gráficos, tablas y otros objetos de diapositiva son formas, se utiliza el mismo [Sequence::addEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/sequence/addeffect/) para la mayor parte del contenido de la diapositiva. Los efectos disponibles se enumeran en la clase [EffectType](https://reference.aspose.com/slides/es/php-java/aspose.slides/effecttype/).

## **Añadir animaciones a formas**

Para añadir una animación, obtenga la secuencia principal de la diapositiva y llame a [Sequence::addEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/sequence/addeffect/) con la forma objetivo, el tipo de efecto, el subtipo y el disparador. Para un efecto que se inicia cuando se hace clic en otra forma, cree una secuencia interactiva cuyo disparador sea esa otra forma.

El siguiente ejemplo crea ambos tipos de animación y guarda el resultado en `shape-animations.pptx`.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Click to animate this shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $entranceEffect = $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $entranceEffect->getTiming()->setDuration(1.5);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $presentation->save("shape-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El disparador controla cuándo comienza un efecto:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/es/php-java/aspose.slides/effecttriggertype/) espera un clic en la secuencia principal, o un clic en la forma disparadora en una secuencia interactiva.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/es/php-java/aspose.slides/effecttriggertype/) se inicia con el efecto precedente.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/es/php-java/aspose.slides/effecttriggertype/) se inicia cuando termina el efecto precedente.

Para animar una imagen, un gráfico u otro tipo de forma, pase ese objeto a [Sequence::addEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/sequence/addeffect/) en lugar de `$targetShape`. Para opciones de agrupamiento específicas de gráficos, consulte [Animated Charts](/slides/es/php-java/animated-charts/).

## **Leer animaciones de formas**

Utilice [Sequence::getEffectsByShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/sequence/geteffectsbyshape/) cuando conozca la forma objetivo. Para inspeccionar cada efecto, recorra la secuencia principal y cada secuencia interactiva. Recorrer evita suponer que una secuencia contiene un efecto en el índice `0`.

El siguiente ejemplo crea una forma con efectos de secuencia principal e interactiva, obtiene los efectos que apuntan a la forma y luego recorre cada secuencia de la diapositiva.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function printSequence($label, $sequence)
{
    $effectCount = java_values($sequence->getCount());

    echo "  " . $label . ": " . $effectCount . " effect(s)" . PHP_EOL;

    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $targetShape = $effect->getTargetShape();
        $targetName = java_is_null($targetShape) ? "unknown" : java_values($targetShape->getName());
        $effectType = java_values($effect->getType());
        $effectSubtype = java_values($effect->getSubtype());
        $triggerType = java_values($effect->getTiming()->getTriggerType());
        echo "    type: " . $effectType . "; subtype: " . $effectSubtype . "; target: " . $targetName . "; trigger: " . $triggerType . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Animated shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $targetEffects = $mainSequence->getEffectsByShape($targetShape);
    $Array = new JavaClass("java.lang.reflect.Array");
    echo "The main sequence contains " . java_values($Array->getLength($targetEffects)) . " effect(s) for " . java_values($targetShape->getName()) . "." . PHP_EOL;

    printSequence("Main sequence", $mainSequence);

    $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
    $interactiveCount = java_values($interactiveSequences->getCount());
    for ($interactiveIndex = 0; $interactiveIndex < $interactiveCount; $interactiveIndex++) {
        $sequence = $interactiveSequences->get_Item($interactiveIndex);
        $sequenceTrigger = $sequence->getTriggerShape();
        $triggerName = java_is_null($sequenceTrigger) ? "unknown" : java_values($sequenceTrigger->getName());
        printSequence("Interactive sequence " . ($interactiveIndex + 1) . ", trigger: " . $triggerName, $sequence);
    }
} finally {
    $presentation->dispose();
}
```

Si solo necesita los efectos para una forma, identifique primero la forma por nombre, tipo de marcador de posición u otra propiedad estable; después llame a [Sequence::getEffectsByShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/sequence/geteffectsbyshape/). No asuma que [ShapeCollection::get_Item](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/get_item/) en el índice `0` sea siempre el objeto deseado.

## **Trabajar con efectos heredados de marcadores de posición**

Un marcador de posición en una diapositiva normal puede heredar el comportamiento de animación del marcador de posición correspondiente en su diapositiva de diseño y en la diapositiva maestra. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/getbaseplaceholder/) devuelve ese marcador de posición padre, o `null` cuando no existe padre.

En la presentación de ejemplo siguiente, el pie de página tiene **Random Bars** en la diapositiva normal, **Split** en la diapositiva de diseño y **Fly In** en la diapositiva maestra.

![Efecto de animación del pie de página en la diapositiva normal](slide-shape-animation.png)

![Efecto de animación del marcador de posición del pie de página en la diapositiva de diseño](layout-shape-animation.png)

![Efecto de animación del marcador de posición del pie de página en la diapositiva maestra](master-shape-animation.png)

El siguiente ejemplo usa una jerarquía de marcadores de posición de una nueva presentación. Añade efectos a un marcador de posición maestro, a un marcador de posición de diseño y al marcador de posición correspondiente en una diapositiva normal. Cada llamada a [Shape::getBasePlaceholder](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/getbaseplaceholder/) se verifica antes de usar la forma devuelta.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

function findLayoutPlaceholderWithBase($layoutSlide)
{
    $shapes = $layoutSlide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_is_null($shape->getBasePlaceholder())) {
            return $shape;
        }
    }

    return null;
}

function findSlidePlaceholderWithBase($slide, $expectedBase)
{
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $basePlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($basePlaceholder) && java_values($basePlaceholder->equals($expectedBase))) {
            return $shape;
        }
    }

    return null;
}

function printEffects($source, $effects)
{
    $Array = new JavaClass("java.lang.reflect.Array");
    echo $source . ": " . java_values($Array->getLength($effects)) . " effect(s)" . PHP_EOL;

    foreach ($effects as $effect) {
        echo "  type: " . java_values($effect->getType()) . "; subtype: " . java_values($effect->getSubtype()) . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);
    $layoutPlaceholder = findLayoutPlaceholderWithBase($layoutSlide);

    if ($layoutPlaceholder === null) {
        throw new RuntimeException("The layout slide does not contain a placeholder linked to its master slide.");
    }

    $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
    $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->addEffect($masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
    $layoutSlide->getTimeline()->getMainSequence()->addEffect($layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

    $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $slidePlaceholder = findSlidePlaceholderWithBase($slide, $layoutPlaceholder);

    if ($slidePlaceholder === null) {
        throw new RuntimeException("The slide does not contain a placeholder linked to its layout slide.");
    }

    $slide->getTimeline()->getMainSequence()->addEffect($slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
    printEffects("Normal slide", $slide->getTimeline()->getMainSequence()->getEffectsByShape($slidePlaceholder));

    $baseLayoutPlaceholder = $slidePlaceholder->getBasePlaceholder();
    if (!java_is_null($baseLayoutPlaceholder)) {
        printEffects("Layout slide", $layoutSlide->getTimeline()->getMainSequence()->getEffectsByShape($baseLayoutPlaceholder));

        $baseMasterPlaceholder = $baseLayoutPlaceholder->getBasePlaceholder();
        if (!java_is_null($baseMasterPlaceholder)) {
            printEffects("Master slide", $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($baseMasterPlaceholder));
        }
    }

    $presentation->save("placeholder-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Cambiar el tiempo de la animación**

El cuadro de diálogo **Timing** de PowerPoint se corresponde con las propiedades de [Timing](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/).

![Cuadro de diálogo de temporización de PowerPoint para un efecto de animación](shape-animation.png)

- **Start** se corresponde con [Timing::getTriggerType](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/gettriggertype/).
- **Duration** se corresponde con [Timing::getDuration](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/getduration/), en segundos.
- **Delay** se corresponde con [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/gettriggerdelaytime/), en segundos.
- **Repeat** se corresponde con [Timing::getRepeatCount](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/getrepeatuntilnextclick/), o [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/getrepeatuntilendslide/).
- **Rewind when done playing** se corresponde con [Timing::getRewind](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/getrewind/).

Este ejemplo independiente añade un efecto, cambia su tiempo mediante el objeto devuelto por [Sequence::addEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/sequence/addeffect/) y guarda el resultado. Conservar la referencia al [Effect](https://reference.aspose.com/slides/es/php-java/aspose.slides/effect/) devuelta evita un índice de colección innecesario.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Timed animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    $effect->getTiming()->setDuration(2.0);
    $effect->getTiming()->setTriggerDelayTime(0.5);
    $effect->getTiming()->setRepeatUntilNextClick(false);
    $effect->getTiming()->setRepeatUntilEndSlide(false);
    $effect->getTiming()->setRepeatCount(2.0);
    $effect->getTiming()->setRewind(true);

    $presentation->save("shape-animation-timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Utilice un modo de repetición de forma intencionada. Combinar un recuento de repeticiones con una bandera “until” puede producir resultados confusos en distintos visores. Al cambiar los modos de repetición, establezca [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/setrepeatuntilnextclick/) y [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/setrepeatuntilendslide/) antes de [Timing::setRepeatCount](https://reference.aspose.com/slides/es/php-java/aspose.slides/timing/setrepeatcount/), porque establecer cualquiera de las banderas también modifica el modo de repetición activo.

## **Añadir y extraer sonidos de animación**

Un efecto de animación puede hacer referencia a audio incrustado mediante [Effect::getSound](https://reference.aspose.com/slides/es/php-java/aspose.slides/effect/getsound/). [Effect::setStopPreviousSound](https://reference.aspose.com/slides/es/php-java/aspose.slides/effect/setstopprevioussound/) indica a un efecto que detenga el audio iniciado por un efecto anterior.

### **Añadir un sonido a un efecto**

El siguiente ejemplo necesita un archivo de audio local llamado `animation-sound.wav`. Crea dos efectos, incrusta ese archivo como sonido del primer efecto y configura el segundo efecto para detener el sonido. Utiliza los objetos devueltos por [Sequence::addEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/sequence/addeffect/), por lo que no se requiere un índice de secuencia.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$Files = new JavaClass("java.nio.file.Files");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 100, 240, 80);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 400, 100, 240, 80);
    $firstShape->addTextFrame("Starts sound");
    $secondShape->addTextFrame("Stops sound");

    $sequence = $slide->getTimeline()->getMainSequence();
    $firstEffect = $sequence->addEffect($firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $secondEffect = $sequence->addEffect($secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $baseDirectory = getcwd();
    $audioPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "animation-sound.wav"))->toPath();
    $audioData = $Files->readAllBytes($audioPath);
    $effectSound = $presentation->getAudios()->addAudio($audioData);
    $firstEffect->setSound($effectSound);
    $secondEffect->setStopPreviousSound(true);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "shape-animation-sound.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Extraer sonidos de efectos incrustados**

El siguiente ejemplo necesita una presentación local llamada `presentation-with-animation-sounds.pptx`. Analiza tanto las secuencias principales como las interactivas y escribe cada sonido de efecto incrustado en el directorio `extracted-animation-sounds`. La extensión se selecciona a partir del tipo MIME de audio expuesto por [Audio::getContentType](https://reference.aspose.com/slides/es/php-java/aspose.slides/audio/getcontenttype/).

```php
use aspose\slides\Presentation;

function getAudioExtension($contentType)
{
    $normalizedType = strtolower($contentType === null ? "" : java_values($contentType));

    if ($normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if ($normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if ($normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if ($normalizedType === "audio/wav" || $normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds($sequence, $outputDirectory, $soundIndex)
{
    $effectCount = java_values($sequence->getCount());
    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $sound = $effect->getSound();
        if (java_is_null($sound)) {
            continue;
        }

        $extension = getAudioExtension($sound->getContentType());
        $outputPath = $outputDirectory->resolve("effect-sound-" . $soundIndex . $extension);
        $outputStream = new Java("java.io.FileOutputStream", $outputPath->toFile());
        try {
            $outputStream->write($sound->getBinaryData());
        } finally {
            $outputStream->close();
        }
        $soundIndex++;
    }

    return $soundIndex;
}

$baseDirectory = getcwd();
$inputPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "presentation-with-animation-sounds.pptx"))->toPath();
$outputDirectoryName = $baseDirectory . DIRECTORY_SEPARATOR . "extracted-animation-sounds";
if (!is_dir($outputDirectoryName)) {
    mkdir($outputDirectoryName, 0777, true);
}
$outputDirectory = (new Java("java.io.File", $outputDirectoryName))->toPath();

$presentation = new Presentation($inputPath->toString());
try {
    $soundIndex = 1;

    $slides = $presentation->getSlides();
    $slideCount = java_values($slides->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $slides->get_Item($slideIndex);
        $soundIndex = saveSounds($slide->getTimeline()->getMainSequence(), $outputDirectory, $soundIndex);

        $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
        $interactiveCount = java_values($interactiveSequences->getCount());
        for ($sequenceIndex = 0; $sequenceIndex < $interactiveCount; $sequenceIndex++) {
            $sequence = $interactiveSequences->get_Item($sequenceIndex);
            $soundIndex = saveSounds($sequence, $outputDirectory, $soundIndex);
        }
    }

    echo "Extracted " . ($soundIndex - 1) . " sound file(s) to " . java_values($outputDirectory->toAbsolutePath()->toString()) . "." . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Para objetos de audio grandes, utilice [Audio::getStream](https://reference.aspose.com/slides/es/php-java/aspose.slides/audio/getstream/) y copie el flujo a un archivo en lugar de cargar todo el objeto en un array de bytes.

## **Establecer el comportamiento después de la animación**

La opción **After animation** controla qué ocurre con una forma después de que su efecto finaliza.

![Cuadro de diálogo de opciones de efecto de PowerPoint que muestra la configuración After animation](shape-after-animation.png)

La clase [AfterAnimationType](https://reference.aspose.com/slides/es/php-java/aspose.slides/afteranimationtype/) permite dejar la forma sin cambios, cambiar su color, ocultarla después de la animación o ocultarla en el siguiente clic. Cuando el tipo es [AfterAnimationType::Color](https://reference.aspose.com/slides/es/php-java/aspose.slides/afteranimationtype/), establezca también [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/es/php-java/aspose.slides/effect/getafteranimationcolor/).

Este ejemplo independiente crea un efecto, establece su comportamiento después de la animación mediante el objeto efecto devuelto y guarda el resultado.

```php
use aspose\slides\AfterAnimationType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Dim after animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->setAfterAnimationType(AfterAnimationType::Color);
    $effect->getAfterAnimationColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("shape-animation-after-effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Cambiar el tipo a algo distinto de [AfterAnimationType::Color](https://reference.aspose.com/slides/es/php-java/aspose.slides/afteranimationtype/) borra la configuración del color después de la animación.

## **Animar texto**

La animación de texto tiene dos controles relacionados:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/es/php-java/aspose.slides/textanimation/getbuildtype/) controla si los párrafos aparecen juntos o por nivel de párrafo.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/es/php-java/aspose.slides/effect/getanimatetexttype/) controla si el texto aparece todo a la vez, por palabra o por letra. [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/es/php-java/aspose.slides/effect/getdelaybetweentextparts/) define el retraso entre palabras o letras. Un valor positivo es un porcentaje de la duración del efecto; un valor negativo es un retraso en segundos.

El siguiente ejemplo independiente anima las palabras en un cuadro de texto. [BuildType::AsOneObject](https://reference.aspose.com/slides/es/php-java/aspose.slides/buildtype/) desactiva la construcción párrafo a párrafo para que la configuración por palabra se aplique a todo el marco de texto.

```php
use aspose\slides\AnimateTextType;
use aspose\slides\BuildType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 560, 100);
    $textBox->addTextFrame("Aspose.Slides animates this sentence word by word.");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    $effect->setAnimateTextType(AnimateTextType::ByWord);
    $effect->setDelayBetweenTextParts(20.0);

    $presentation->save("animated-text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para construir un cuadro de texto por párrafo, establezca [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/es/php-java/aspose.slides/buildtype/) (u otro nivel de párrafo). Para dirigir un solo párrafo con su propio efecto, utilice la sobrecarga de [Sequence::addEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/sequence/addeffect/) que acepta un [Paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/). Consulte [Animated Text](/slides/es/php-java/animated-text/) para ejemplos a nivel de párrafo.

## **Exportar y notas de compatibilidad**

- Guardar en PPT o PPTX preserva el modelo de animación, pero la reproducción final depende del visor de presentaciones.
- PDF e imágenes estáticas no reproducen animaciones. Utilice la [exportación a HTML5](/slides/es/php-java/export-to-html5/), GIF animado o la [conversión a video](/slides/es/php-java/convert-powerpoint-to-video/) cuando la salida deba mostrar movimiento.
- Para HTML5, habilite [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/es/php-java/aspose.slides/html5options/setanimateshapes/) y, cuando sea necesario, [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/es/php-java/aspose.slides/html5options/setanimatetransitions/).
- La renderización de video admite muchos efectos de entrada, énfasis, salida y trayectorias, pero no todos los efectos de PowerPoint están soportados. Consulte la tabla actual de [animaciones y efectos compatibles](/slides/es/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) y pruebe presentaciones críticas con la versión de Aspose.Slides que utilice.
- Los efectos personalizados avanzados y los efectos importados de otros formatos de presentación pueden preservarse en el archivo pero renderizarse de forma distinta en PowerPoint, HTML5 o video. Valide el resultado exportado en lugar de basarse solo en el nombre del efecto.

## **Preguntas frecuentes**

**¿Por qué una animación aparece en PowerPoint pero no en un PDF?**

PDF es un formato estático, por lo que las animaciones y transiciones de diapositiva no se reproducen. Exporte a HTML5, GIF animado o video cuando sea necesario conservar el movimiento.

**¿Por qué un efecto se reproduce de forma diferente en un video?**

La exportación a video renderiza las animaciones en lugar de almacenar el comportamiento original de PowerPoint. Algunos efectos avanzados no son compatibles o se aproximan. Revise la tabla de efectos compatibles y pruebe la presentación real antes de su uso en producción.

**¿Mover una forma hacia adelante o hacia atrás cambia su orden de animación?**

No. El orden Z controla la superposición de formas, mientras que el orden de la secuencia y los disparadores controlan la reproducción de la animación. Modifique la línea de tiempo si necesita un orden de reproducción distinto.