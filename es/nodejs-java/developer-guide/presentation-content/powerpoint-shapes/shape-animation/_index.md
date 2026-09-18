---
title: Aplicar animaciones de forma en presentaciones usando JavaScript
linktitle: Animación de forma
type: docs
weight: 60
url: /es/nodejs-java/shape-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda cómo añadir, inspeccionar y personalizar animaciones de forma, temporización, sonidos, comportamiento después de la animación y texto animado con Aspose.Slides para Node.js a través de Java."
---
## **Descripción general**

Para trabajar con los comportamientos individuales dentro de un efecto o editar segmentos de trayectoria de movimiento, consulte [Animación personalizada](/slides/es/nodejs-java/custom-animation/).

Aspose.Slides para Node.js a través de Java representa las animaciones de diapositivas como efectos en una línea de tiempo de diapositiva. Un efecto tiene una forma de destino, un tipo y subtipo de animación, un desencadenador, ajustes de temporización y propiedades opcionales como sonido o comportamiento después de la animación.

La línea de tiempo contiene dos tipos de secuencias:

- La **secuencia principal** se reproduce al avanzar la diapositiva.
- Una **secuencia interactiva** comienza cuando se hace clic en su forma desencadenadora.

Dado que los cuadros de texto, imágenes, gráficos, tablas y otros objetos de diapositiva son objetos [Shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/) , utiliza el mismo método [Sequence.addEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/#addEffect) para la mayor parte del contenido de la diapositiva. Los efectos disponibles se enumeran en la enumeración [EffectType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effecttype/).

## **Añadir animaciones de forma**

Para añadir una animación, obtenga la secuencia principal de la diapositiva y llame a [Sequence.addEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/#addEffect) con la forma de destino, el tipo de efecto, el subtipo y el desencadenador. Para un efecto que se inicie cuando se haga clic en otra forma, cree una secuencia interactiva cuyo desencadenador sea esa otra forma.

El siguiente ejemplo crea ambos tipos de animación y guarda el resultado en `shape-animations.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Click to animate this shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    const entranceEffect = mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    entranceEffect.getTiming().setDuration(java.newFloat(1.5));

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    presentation.save("shape-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El desencadenador controla cuándo comienza un efecto:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effecttriggertype/#OnClick) espera a un clic en la secuencia principal, o a un clic en la forma desencadenadora en una secuencia interactiva.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) inicia con el efecto anterior.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) inicia cuando termina el efecto anterior.

Para animar una imagen, gráfico u otro tipo de forma, pase ese objeto a [Sequence.addEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/#addEffect) en lugar de `targetShape`. Para opciones de agrupación específicas de gráficos, consulte [Gráficos animados](/slides/es/nodejs-java/animated-charts/).

## **Leer animaciones de forma**

Utilice [Sequence.getEffectsByShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/#getEffectsByShape) cuando conozca la forma de destino. Para inspeccionar cada efecto, enumere la secuencia principal y cada secuencia interactiva. La enumeración evita suponer que una secuencia contiene un efecto en el índice `0`.

El siguiente ejemplo crea una forma con efectos de secuencia principal e interactiva, obtiene los efectos que apuntan a la forma y luego enumera cada secuencia en la diapositiva.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printSequence(label, sequence) {
    console.log(`  ${label}: ${sequence.getCount()} effect(s)`);

    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);
        const targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        const triggerName = getEnumName(aspose.slides.EffectTriggerType, effect.getTiming().getTriggerType());
        console.log(`    ${typeName} ${subtypeName}; target: ${targetName}; trigger: ${triggerName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Animated shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const targetEffects = mainSequence.getEffectsByShape(targetShape);
    console.log(`The main sequence contains ${targetEffects.length} effect(s) for ${targetShape.getName()}.`);

    printSequence("Main sequence", mainSequence);

    const interactiveSequences = slide.getTimeline().getInteractiveSequences();
    for (let i = 0; i < interactiveSequences.getCount(); i++) {
        const sequence = interactiveSequences.get_Item(i);
        const triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
        printSequence(`Interactive sequence ${i + 1}, trigger: ${triggerName}`, sequence);
    }
} finally {
    presentation.dispose();
}
```

Si solo necesita los efectos para una forma, primero identifique la forma por nombre, tipo de marcador de posición u otra propiedad estable; luego llame a [Sequence.getEffectsByShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/#getEffectsByShape). No suponga que [ShapeCollection.get_Item](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/#get_Item) en el índice `0` sea siempre el objeto deseado.

## **Trabajar con efectos de marcadores de posición heredados**

Un marcador de posición en una diapositiva normal puede heredar el comportamiento de animación del marcador de posición correspondiente en su diapositiva de diseño y diapositiva maestra. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getBasePlaceholder) devuelve ese marcador de posición padre, o `null` cuando no existe un padre.

En la presentación de ejemplo siguiente, el pie de página tiene **Random Bars** en la diapositiva normal, **Split** en la diapositiva de diseño y **Fly In** en la diapositiva maestra.

![Efecto de animación del pie de página en la diapositiva normal](slide-shape-animation.png)

![Efecto de animación del marcador de posición de pie de página en la diapositiva de diseño](layout-shape-animation.png)

![Efecto de animación del marcador de posición de pie de página en la diapositiva maestra](master-shape-animation.png)

El siguiente ejemplo utiliza una jerarquía de marcadores de posición de una nueva presentación. Añade efectos a un marcador de posición maestro, a un marcador de posición de diseño y al marcador de posición correspondiente en una diapositiva normal. Cada llamada a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getBasePlaceholder) se verifica antes de usar la forma devuelta.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function findPlaceholderWithBase(baseSlide, expectedBase) {
    const shapes = baseSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const basePlaceholder = shape.getBasePlaceholder();

        if (basePlaceholder == null) {
            continue;
        }

        if (expectedBase == null || basePlaceholder.getPlaceholder().getType() === expectedBase.getPlaceholder().getType()) {
            return shape;
        }
    }

    return null;
}

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printEffects(source, effects) {
    console.log(`${source}: ${effects.length} effect(s)`);

    for (const effect of effects) {
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        console.log(`  ${typeName} ${subtypeName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const layoutSlide = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    const layoutPlaceholder = findPlaceholderWithBase(layoutSlide, null);

    if (layoutPlaceholder == null) {
        throw new Error("The layout slide does not contain a placeholder linked to its master slide.");
    }

    const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
    layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);
    layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, aspose.slides.EffectType.Split, aspose.slides.EffectSubtype.VerticalIn, aspose.slides.EffectTriggerType.OnClick);

    const slide = presentation.getSlides().addEmptySlide(layoutSlide);
    const slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

    if (slidePlaceholder == null) {
        throw new Error("The slide does not contain a placeholder linked to its layout slide.");
    }

    slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, aspose.slides.EffectType.RandomBars, aspose.slides.EffectSubtype.Horizontal, aspose.slides.EffectTriggerType.OnClick);
    printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

    const baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
    if (baseLayoutPlaceholder != null) {
        printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

        const baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
        if (baseMasterPlaceholder != null) {
            printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
        }
    }

    presentation.save("placeholder-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Cambiar la temporización de la animación**

El cuadro de diálogo **Timing** de PowerPoint se corresponde con las propiedades de [Timing](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/).

![Cuadro de diálogo Timing de PowerPoint para un efecto de animación](shape-animation.png)

- **Inicio** se corresponde con [Timing.getTriggerType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getTriggerType).
- **Duración** se corresponde con [Timing.getDuration](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getDuration), en segundos.
- **Retraso** se corresponde con [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getTriggerDelayTime), en segundos.
- **Repetir** se corresponde con [Timing.getRepeatCount](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) o [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rebobinar al finalizar la reproducción** se corresponde con [Timing.getRewind](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getRewind).

Este ejemplo independiente añade un efecto, cambia su temporización a través del objeto devuelto por [Sequence.addEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/#addEffect), y guarda el resultado. Mantener la referencia al [Effect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/) devuelta evita un índice de colección innecesario.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Timed animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setDuration(java.newFloat(2.0));
    effect.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    effect.getTiming().setRepeatUntilNextClick(false);
    effect.getTiming().setRepeatUntilEndSlide(false);
    effect.getTiming().setRepeatCount(java.newFloat(2.0));
    effect.getTiming().setRewind(true);

    presentation.save("shape-animation-timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilice intencionalmente un solo modo de repetición. Combinar un recuento de repeticiones con una bandera "hasta" puede producir resultados confusos en diferentes reproductores. Al cambiar los modos de repetición, establezca [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) y [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) antes de [Timing.setRepeatCount](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#setRepeatCount), porque activar cualquiera de esas banderas también cambia el modo de repetición activo.

## **Añadir y extraer sonidos de animación**

Un efecto de animación puede hacer referencia a audio incrustado mediante [Effect.getSound](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/#setStopPreviousSound) indica a un efecto que detenga el audio iniciado por un efecto anterior.

### **Añadir un sonido a un efecto**

El siguiente ejemplo requiere un archivo de audio local llamado `animation-sound.wav`. Crea dos efectos, incrusta ese archivo como sonido del primer efecto y configura el segundo efecto para detener el sonido. Utiliza los objetos devueltos por [Sequence.addEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/#addEffect), por lo que no se necesita un índice de secuencia.

```javascript
const fs = require("fs");
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const firstShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 100, 240, 80);
    const secondShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 400, 100, 240, 80);
    firstShape.addTextFrame("Starts sound");
    secondShape.addTextFrame("Stops sound");

    const sequence = slide.getTimeline().getMainSequence();
    const firstEffect = sequence.addEffect(firstShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    const secondEffect = sequence.addEffect(secondShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const audioData = java.newArray("byte", Array.from(fs.readFileSync("animation-sound.wav")));
    const effectSound = presentation.getAudios().addAudio(audioData);
    firstEffect.setSound(effectSound);
    secondEffect.setStopPreviousSound(true);

    presentation.save("shape-animation-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Extraer sonidos incrustados de efectos**

El siguiente ejemplo requiere una presentación local llamada `presentation-with-animation-sounds.pptx`. Analiza tanto la secuencia principal como la interactiva y escribe cada sonido de efecto incrustado en el directorio `extracted-animation-sounds`. La extensión se selecciona a partir del tipo MIME de audio que expone [Audio.getContentType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audio/#getContentType).

```javascript
const fs = require("fs");
const path = require("path");
const aspose = { slides: require("aspose.slides.via.java") };

function getAudioExtension(contentType) {
    const normalizedType = contentType == null ? "" : contentType.toLowerCase();

    if (normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if (normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if (normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if (normalizedType === "audio/wav" || normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds(sequence, outputDirectory, soundIndex) {
    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);

        if (effect.getSound() == null) {
            continue;
        }

        const extension = getAudioExtension(effect.getSound().getContentType());
        const outputPath = path.join(outputDirectory, `effect-sound-${soundIndex}${extension}`);
        fs.writeFileSync(outputPath, Buffer.from(effect.getSound().getBinaryData()));
        soundIndex++;
    }

    return soundIndex;
}

const outputDirectory = "extracted-animation-sounds";
fs.mkdirSync(outputDirectory, { recursive: true });

const presentation = new aspose.slides.Presentation("presentation-with-animation-sounds.pptx");
try {
    let soundIndex = 1;

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

        const interactiveSequences = slide.getTimeline().getInteractiveSequences();
        for (let sequenceIndex = 0; sequenceIndex < interactiveSequences.getCount(); sequenceIndex++) {
            soundIndex = saveSounds(interactiveSequences.get_Item(sequenceIndex), outputDirectory, soundIndex);
        }
    }

    console.log(`Extracted ${soundIndex - 1} sound file(s) to ${path.resolve(outputDirectory)}.`);
} finally {
    presentation.dispose();
}
```

Para objetos de audio grandes, utilice [Audio.getStream](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audio/#getStream) y copie el flujo a un archivo en lugar de cargar todo el objeto en una matriz de bytes.

## **Establecer el comportamiento después de la animación**

La opción **After animation** controla lo que ocurre con una forma después de que su efecto finaliza.

![Cuadro de diálogo Opciones de efecto de PowerPoint que muestra la configuración After animation](shape-after-animation.png)

La enumeración [AfterAnimationType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/afteranimationtype/) permite dejar la forma sin cambios, cambiar su color, ocultarla después de la animación o ocultarla en el siguiente clic. Cuando el tipo es [AfterAnimationType.Color](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/afteranimationtype/#Color), establezca también [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/#getAfterAnimationColor).

Este ejemplo independiente crea un efecto, establece su comportamiento después de la animación a través del objeto de efecto devuelto y guarda el resultado.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Dim after animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    effect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("shape-animation-after-effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Cambiar el tipo fuera de [AfterAnimationType.Color](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/afteranimationtype/#Color) borra la configuración de color después de la animación.

## **Animar texto**

La animación de texto tiene dos controles relacionados:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textanimation/#getBuildType) controla si los párrafos aparecen juntos o por nivel de párrafo.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/#getAnimateTextType) controla si el texto aparece todo a la vez, por palabra o por letra. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) establece el retraso entre palabras o letras. Un valor positivo es un porcentaje de la duración del efecto; un valor negativo es un retraso en segundos.

El siguiente ejemplo independiente anima las palabras en un cuadro de texto. [BuildType.AsOneObject](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/buildtype/#AsOneObject) desactiva la construcción párrafo a párrafo para que la configuración de palabras se aplique a todo el marco de texto.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 560, 100);
    textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

    const effect = slide.getTimeline().getMainSequence().addEffect(textBox, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    effect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    effect.setDelayBetweenTextParts(java.newFloat(20.0));

    presentation.save("animated-text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para construir un cuadro de texto por párrafo, establezca [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (u otro nivel de párrafo). Para apuntar a un solo párrafo con su propio efecto, use la sobrecarga de [Sequence.addEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/#addEffect) que acepta un [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/). Consulte [Texto animado](/slides/es/nodejs-java/animated-text/) para ejemplos a nivel de párrafo.

## **Notas de exportación y compatibilidad**

- Guardar en PPT o PPTX conserva el modelo de animación, pero la reproducción final está controlada por el visor de presentaciones.
- PDF e imágenes estáticas no reproducen animaciones. Use [Exportación a HTML5](/slides/es/nodejs-java/export-to-html5/), GIF animado o [conversión a video](/slides/es/nodejs-java/convert-powerpoint-to-video/) cuando el resultado debe mostrar movimiento.
- Para HTML5, habilite [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/html5options/#setAnimateShapes) y, cuando sea necesario, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).
- La renderización de video admite muchos efectos comunes de entrada, énfasis, salida y trayectoria de movimiento, pero no todos los efectos de PowerPoint son compatibles. Consulte las [animaciones y efectos compatibles](/slides/es/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) actuales y pruebe presentaciones críticas con la versión objetivo de Aspose.Slides.
- Los efectos personalizados avanzados y los efectos importados de otros formatos de presentación pueden preservarse en el archivo pero renderizarse de forma diferente en PowerPoint, HTML5 o video. Valide el resultado exportado en lugar de confiar únicamente en el nombre del efecto.

## **FAQ**

**¿Por qué una animación aparece en PowerPoint pero no en un PDF?**

PDF es un formato estático, por lo que las animaciones y transiciones de diapositiva no se reproducen. Exporte a HTML5, GIF animado o video cuando sea necesario preservar el movimiento.

**¿Por qué un efecto se reproduce de forma diferente en un video?**

La exportación a video renderiza las animaciones en lugar de almacenar el comportamiento original de PowerPoint. Algunos efectos avanzados no son compatibles o se aproximan. Revise la tabla de efectos compatibles y pruebe la presentación real antes de su uso en producción.

**¿Mover una forma hacia adelante o hacia atrás cambia su orden de animación?**

No. El orden Z de la forma controla la superposición, mientras que el orden de la secuencia y los desencadenadores controlan la reproducción de la animación. Cambie la línea de tiempo si necesita un orden de reproducción diferente.