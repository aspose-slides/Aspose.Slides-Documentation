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
- sonido de efecto
- aplicar animación
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprende cómo añadir, inspeccionar y personalizar animaciones de forma, temporización, sonidos, comportamiento después de la animación y texto animado con Aspose.Slides para Node.js a través de Java."
---
## **Descripción general**

Aspose.Slides for Node.js a través de Java representa las animaciones de diapositiva como efectos en la línea de tiempo de una diapositiva. Un efecto tiene una forma objetivo, un tipo y subtipo de animación, un disparador, ajustes de temporización y propiedades opcionales como sonido o comportamiento después de la animación.

La línea de tiempo contiene dos tipos de secuencias:

- La **secuencia principal** se reproduce al avanzar la diapositiva.  
- Una **secuencia interactiva** comienza cuando se hace clic en su forma disparadora.

Porque los cuadros de texto, imágenes, gráficos, tablas y otros objetos de diapositiva son objetos [Shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/), se utiliza el mismo método [Sequence.addEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/#addEffect) para la mayor parte del contenido de la diapositiva. Los efectos disponibles se enumeran en la enumeración [EffectType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effecttype/).

## **Agregar animaciones a formas**

Para agregar una animación, obtenga la secuencia principal de la diapositiva y llame a [Sequence.addEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/#addEffect) con la forma objetivo, el tipo de efecto, el subtipo y el disparador. Para un efecto que comienza cuando se hace clic en otra forma, cree una secuencia interactiva cuyo disparador sea esa otra forma.

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

El disparador controla cuándo comienza un efecto:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effecttriggertype/#OnClick) espera un clic en la secuencia principal, o un clic en la forma disparadora en una secuencia interactiva.  
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) comienza con el efecto anterior.  
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) comienza cuando termina el efecto anterior.

Para animar una imagen, un gráfico u otro tipo de forma, pase ese objeto a [Sequence.addEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/#addEffect) en lugar de `targetShape`. Para opciones de agrupación específicas de gráficos, consulte [Animated Charts](/slides/es/nodejs-java/animated-charts/).

## **Leer animaciones de formas**

Utilice [Sequence.getEffectsByShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/#getEffectsByShape) cuando conozca la forma objetivo. Para inspeccionar cada efecto, recorra la secuencia principal y todas las secuencias interactivas. Enumerar evita asumir que una secuencia contiene un efecto en el índice `0`.

El siguiente ejemplo crea una forma con efectos de secuencia principal e interactiva, obtiene los efectos que apuntan a la forma y luego recorre cada secuencia de la diapositiva.

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

Si solo necesita los efectos de una forma, primero identifique la forma por nombre, tipo de marcador de posición u otra propiedad estable; a continuación, llame a [Sequence.getEffectsByShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/#getEffectsByShape). No asuma que [ShapeCollection.get_Item](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/#get_Item) en el índice `0` sea siempre el objeto deseado.

## **Trabajar con efectos heredados de marcadores de posición**

Un marcador de posición en una diapositiva normal puede heredar el comportamiento de animación del marcador de posición correspondiente en la diapositiva de diseño y en la diapositiva maestra. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getBasePlaceholder) devuelve ese marcador de posición padre, o `null` cuando no existe padre.

En la presentación de ejemplo siguiente, el pie de página tiene **Random Bars** en la diapositiva normal, **Split** en la diapositiva de diseño y **Fly In** en la diapositiva maestra.

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

El siguiente ejemplo utiliza una jerarquía de marcadores de posición de una presentación nueva. Añade efectos a un marcador de posición maestro, a un marcador de posición de diseño y al marcador de posición correspondiente en una diapositiva normal. Cada llamada a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getBasePlaceholder) se comprueba antes de usar la forma devuelta.

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

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** se corresponde con [Timing.getTriggerType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getTriggerType).  
- **Duration** se corresponde con [Timing.getDuration](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getDuration), en segundos.  
- **Delay** se corresponde con [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getTriggerDelayTime), en segundos.  
- **Repeat** se corresponde con [Timing.getRepeatCount](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) o [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).  
- **Rewind when done playing** se corresponde con [Timing.getRewind](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#getRewind).

Este ejemplo independiente añade un efecto, modifica su temporización mediante el objeto devuelto por [Sequence.addEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/#addEffect) y guarda el resultado. Mantener la referencia al [Effect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/) devuelto evita una indexación innecesaria de la colección.

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

Utilice un modo de repetición a la vez. Combinar un recuento de repeticiones con una bandera “until” puede producir resultados confusos en diferentes visores. Al cambiar los modos de repetición, establezca [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) y [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) antes de [Timing.setRepeatCount](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/timing/#setRepeatCount), porque establecer cualquiera de las banderas también modifica el modo de repetición activo.

## **Agregar y extraer sonidos de animación**

Un efecto de animación puede hacer referencia a audio incrustado mediante [Effect.getSound](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/#setStopPreviousSound) indica que un efecto debe detener el audio iniciado por un efecto anterior.

### **Agregar un sonido a un efecto**

El ejemplo siguiente supone un archivo de audio local llamado `animation-sound.wav`. Crea dos efectos, incrusta ese archivo como sonido del primer efecto y configura el segundo efecto para detener el sonido. Utiliza los objetos devueltos por [Sequence.addEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/#addEffect), por lo que no se requiere un índice de secuencia.

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

El ejemplo siguiente supone una presentación local llamada `presentation-with-animation-sounds.pptx`. Analiza tanto la secuencia principal como la interactiva y escribe cada sonido de efecto incrustado en el directorio `extracted-animation-sounds`. La extensión se selecciona a partir del tipo MIME de audio expuesto por [Audio.getContentType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/audio/#getContentType).

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

La opción **After animation** controla qué ocurre con una forma después de que su efecto finaliza.

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

La enumeración [AfterAnimationType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/afteranimationtype/) permite dejar la forma sin cambios, cambiar su color, ocultarla después de la animación o ocultarla en el siguiente clic. Cuando el tipo es [AfterAnimationType.Color](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/afteranimationtype/#Color), también configure [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/#getAfterAnimationColor).

Este ejemplo independiente crea un efecto, define su comportamiento después de la animación mediante el objeto de efecto devuelto y guarda el resultado.

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

Cambiar el tipo a algo distinto de [AfterAnimationType.Color](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/afteranimationtype/#Color) borra la configuración del color después de la animación.

## **Animar texto**

La animación de texto tiene dos controles relacionados:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textanimation/#getBuildType) controla si los párrafos aparecen juntos o por nivel de párrafo.  
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/#getAnimateTextType) controla si el texto aparece de una sola vez, por palabra o por letra. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) establece el retraso entre palabras o letras. Un valor positivo es un porcentaje de la duración del efecto; un valor negativo es un retraso en segundos.

El siguiente ejemplo independiente anima las palabras de un cuadro de texto. [BuildType.AsOneObject](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/buildtype/#AsOneObject) desactiva la construcción párrafo a párrafo para que la configuración de palabras se aplique a todo el marco de texto.

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

Para construir un cuadro de texto por párrafo, establezca [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (u otro nivel de párrafo). Para dirigir un solo párrafo con su propio efecto, utilice la sobrecarga de [Sequence.addEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sequence/#addEffect) que acepta un [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/). Consulte [Animated Text](/slides/es/nodejs-java/animated-text/) para ejemplos a nivel de párrafo.

## **Exportar y notas de compatibilidad**

- Guardar en PPT o PPTX preserva el modelo de animación, pero la reproducción final está controlada por el visor de la presentación.  
- PDF e imágenes estáticas no reproducen animaciones. Utilice la [exportación HTML5](/slides/es/nodejs-java/export-to-html5/), GIF animado o la [conversión a vídeo](/slides/es/nodejs-java/convert-powerpoint-to-video/) cuando la salida deba mostrar movimiento.  
- Para HTML5, habilite [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/html5options/#setAnimateShapes) y, cuando sea necesario, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).  
- La renderización de vídeo admite muchos efectos de entrada, énfasis, salida y trayectoria de movimiento, pero no todos los efectos de PowerPoint están soportados. Consulte la tabla actual de [animaciones y efectos soportados](/slides/es/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) y pruebe las presentaciones críticas con la versión de Aspose.Slides que vaya a usar.  
- Los efectos personalizados avanzados y los efectos importados de otros formatos de presentación pueden preservarse en el archivo pero renderizarse de forma distinta en PowerPoint, HTML5 o vídeo. Valide el resultado exportado en lugar de confiar únicamente en el nombre del efecto.

## **Preguntas frecuentes**

**¿Por qué una animación aparece en PowerPoint pero no en un PDF?**

PDF es un formato estático, por lo que las animaciones y transiciones de diapositiva no se reproducen. Exporte a HTML5, GIF animado o vídeo cuando sea necesario conservar el movimiento.

**¿Por qué un efecto se reproduce de forma diferente en un vídeo?**

La exportación a vídeo procesa las animaciones en lugar de almacenar el comportamiento original de PowerPoint. Algunos efectos avanzados no están soportados o se aproximan. Revise la tabla de efectos soportados y pruebe la presentación real antes de usarla en producción.

**¿Mover una forma hacia adelante o hacia atrás cambia su orden de animación?**

No. El orden Z de la forma controla la superposición, mientras que el orden de la secuencia y los disparadores controlan la reproducción de la animación. Modifique la línea de tiempo si necesita un orden de reproducción diferente.