---
title: Applicare animazioni di forma nelle presentazioni usando JavaScript
linktitle: Animazione Forma
type: docs
weight: 60
url: /it/nodejs-java/shape-animation/
keywords:
- forma
- animazione
- effetto
- forma animata
- testo animato
- aggiungi animazione
- ottieni animazione
- estrai animazione
- aggiungi effetto
- ottieni effetto
- estrai effetto
- suono effetto
- applica animazione
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come aggiungere, ispezionare e personalizzare le animazioni di forma, la temporizzazione, i suoni, il comportamento dopo l'animazione e il testo animato con Aspose.Slides per Node.js tramite Java."
---
## **Panoramica**

Aspose.Slides for Node.js via Java rappresenta le animazioni delle diapositive come effetti in una timeline della diapositiva. Un effetto ha una forma target, un tipo di animazione e un sottotipo, un trigger, impostazioni di temporizzazione e proprietà opzionali come suono o comportamento dopo l'animazione.

La timeline contiene due tipi di sequenze:

- La **sequenza principale** viene riprodotta mentre la diapositiva avanza.  
- Una **sequenza interattiva** inizia quando la sua forma trigger viene cliccata.

Poiché caselle di testo, immagini, grafici, tabelle e altri oggetti della diapositiva sono oggetti [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/) , si utilizza lo stesso metodo [Sequence.addEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#addEffect) per la maggior parte dei contenuti della diapositiva. Gli effetti disponibili sono elencati nell'enumerazione [EffectType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effecttype/).

## **Aggiungi animazioni forma**

Per aggiungere un'animazione, ottieni la sequenza principale della diapositiva e chiamaci [Sequence.addEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#addEffect) passando la forma target, il tipo di effetto, il sottotipo e il trigger. Per un effetto che inizia quando un'altra forma viene cliccata, crea una sequenza interattiva il cui trigger è quell'altra forma.

L'esempio seguente crea entrambi i tipi di animazione e salva il risultato in `shape-animations.pptx`.

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

Il trigger controlla quando un effetto inizia:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effecttriggertype/#OnClick) attende un clic nella sequenza principale, o un clic sulla forma trigger in una sequenza interattiva.  
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) inizia con l'effetto precedente.  
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) inizia quando l'effetto precedente termina.

Per animare un'immagine, un grafico o un altro tipo di forma, passa quell'oggetto a [Sequence.addEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#addEffect) invece di `targetShape`. Per le opzioni di raggruppamento specifiche per i grafici, vedere [Animated Charts](/slides/it/nodejs-java/animated-charts/).

## **Leggi animazioni forma**

Usa [Sequence.getEffectsByShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#getEffectsByShape) quando conosci la forma target. Per esaminare ogni effetto, enumera la sequenza principale e ogni sequenza interattiva. L'enumerazione evita di presumere che una sequenza contenga un effetto all'indice `0`.

L'esempio seguente crea una forma con effetti nella sequenza principale e interattiva, ottiene gli effetti che hanno come target la forma, quindi enumera ogni sequenza nella diapositiva.

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

Se ti servono solo gli effetti per una singola forma, identifica prima la forma per nome, tipo di placeholder o un'altra proprietà stabile; quindi chiama [Sequence.getEffectsByShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#getEffectsByShape). Non presumere che [ShapeCollection.get_Item](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/#get_Item) all'indice `0` sia sempre l'oggetto desiderato.

## **Lavora con gli effetti placeholder ereditati**

Un placeholder su una diapositiva normale può ereditare il comportamento di animazione dal corrispondente placeholder sulla diapositiva layout e master. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getBasePlaceholder) restituisce quel placeholder genitore, o `null` quando non esiste un genitore.

Nella presentazione di esempio seguente, il piè di pagina ha **Random Bars** sulla diapositiva normale, **Split** sulla diapositiva layout e **Fly In** sulla diapositiva master.

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

L'esempio successivo utilizza una gerarchia di placeholder da una nuova presentazione. Aggiunge effetti a un placeholder master, a un placeholder layout e al corrispondente placeholder su una diapositiva normale. Ogni chiamata a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getBasePlaceholder) è verificata prima di utilizzare la forma restituita.

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

## **Modifica la temporizzazione dell'animazione**

La finestra di dialogo **Timing** di PowerPoint corrisponde alle proprietà di [Timing](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/).

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** corrisponde a [Timing.getTriggerType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getTriggerType).  
- **Duration** corrisponde a [Timing.getDuration](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getDuration), in secondi.  
- **Delay** corrisponde a [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getTriggerDelayTime), in secondi.  
- **Repeat** corrisponde a [Timing.getRepeatCount](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) o [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).  
- **Rewind when done playing** corrisponde a [Timing.getRewind](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getRewind).

Questo esempio indipendente aggiunge un effetto, ne modifica la temporizzazione attraverso l'oggetto restituito da [Sequence.addEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#addEffect) e salva il risultato. Mantenere il riferimento all'[Effect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/) restituito evita di dover utilizzare un indice della collezione.

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

Utilizza un solo modo di ripetizione intenzionalmente. Combinare un conteggio di ripetizioni con un flag “until” può produrre risultati confusi in visualizzatori diversi. Quando modifichi i modi di ripetizione, imposta prima [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) e [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide), quindi [Timing.setRepeatCount](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#setRepeatCount), perché impostare uno dei due flag cambia anche il modo di ripetizione attivo.

## **Aggiungi ed estrai suoni dell'animazione**

Un effetto di animazione può fare riferimento a audio incorporato tramite [Effect.getSound](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#setStopPreviousSound) indica a un effetto di fermare l’audio avviato da un effetto precedente.

### **Aggiungi un suono a un effetto**

L'esempio seguente richiede un file audio locale chiamato `animation-sound.wav`. Crea due effetti, incorpora quel file come suono per il primo effetto e configura il secondo effetto per fermare il suono. Utilizza gli oggetti restituiti da [Sequence.addEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#addEffect), quindi non è necessario alcun indice di sequenza.

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

### **Estrai suoni incorporati negli effetti**

L'esempio seguente richiede una presentazione locale chiamata `presentation-with-animation-sounds.pptx`. Scansiona sia le sequenze principali che quelle interattive e scrive ogni suono incorporato in una cartella `extracted-animation-sounds`. L'estensione è selezionata dal tipo MIME audio fornito da [Audio.getContentType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audio/#getContentType).

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

Per oggetti audio di grandi dimensioni, usa [Audio.getStream](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audio/#getStream) e copia lo stream in un file invece di caricare l’intero oggetto in un array di byte.

## **Imposta comportamento dopo l'animazione**

L'opzione **After animation** controlla cosa accade a una forma dopo che il suo effetto è terminato.

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

L'enumerazione [AfterAnimationType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/afteranimationtype/) supporta il mantenimento della forma invariata, la modifica del colore, la sua scomparsa dopo l'animazione o la scomparsa al prossimo clic. Quando il tipo è [AfterAnimationType.Color](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/afteranimationtype/#Color), impostare anche [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#getAfterAnimationColor).

Questo esempio indipendente crea un effetto, imposta il suo comportamento dopo l'animazione tramite l'oggetto effetto restituito e salva il risultato.

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

Cambiare il tipo da [AfterAnimationType.Color](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/afteranimationtype/#Color) elimina l'impostazione del colore dopo l'animazione.

## **Anima testo**

L'animazione del testo ha due controlli correlati:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textanimation/#getBuildType) controlla se i paragrafi appaiono insieme o per livello di paragrafo.  
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#getAnimateTextType) controlla se il testo appare tutto in una volta, per parola o per lettera. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) imposta il ritardo tra parole o lettere. Un valore positivo è una percentuale della durata dell'effetto; un valore negativo è un ritardo in secondi.

L'esempio indipendente seguente anima le parole in una casella di testo. [BuildType.AsOneObject](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/buildtype/#AsOneObject) disabilita la costruzione paragrafo per paragrafo in modo che l'impostazione per parola si applichi all'intero riquadro di testo.

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

Per costruire una casella di testo per paragrafo, imposta [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (o un altro livello di paragrafo). Per mirare a un singolo paragrafo con il proprio effetto, usa la sovraccarica di [Sequence.addEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#addEffect) che accetta un [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/). Vedi [Animated Text](/slides/it/nodejs-java/animated-text/) per esempi a livello di paragrafo.

## **Esporta e note di compatibilità**

- Il salvataggio in PPT o PPTX conserva il modello di animazione, ma la riproduzione finale è controllata dal visualizzatore della presentazione.  
- PDF e immagini statiche non riproducono animazioni. Usa [HTML5 export](/slides/it/nodejs-java/export-to-html5/), GIF animato o [video conversion](/slides/it/nodejs-java/convert-powerpoint-to-video/) quando l'output deve mostrare movimento.  
- Per HTML5, abilita [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/html5options/#setAnimateShapes) e, se necessario, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).  
- Il rendering video supporta molti effetti di ingresso, enfasi, uscita e percorsi di movimento comuni, ma non tutti gli effetti di PowerPoint sono supportati. Consulta la pagina corrente su [supported animations and effects](/slides/it/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) e testa le presentazioni critiche con la versione di Aspose.Slides che utilizzi.  
- Effetti personalizzati avanzati e effetti importati da altri formati di presentazione possono essere conservati nel file ma renderizzati in modo diverso in PowerPoint, HTML5 o video. Convalida il risultato esportato anziché fare affidamento solo sul nome dell'effetto.

## **FAQ**

**Perché un'animazione appare in PowerPoint ma non in un PDF?**

Il PDF è un formato statico, quindi le animazioni e le transizioni delle diapositive non vengono riprodotte. Esporta in HTML5, GIF animato o video quando è necessario preservare il movimento.

**Perché un effetto viene riprodotto diversamente in un video?**

L'esportazione video rende le animazioni invece di memorizzare il comportamento originale di PowerPoint. Alcuni effetti avanzati non sono supportati o vengono approssimati. Consulta la tabella degli effetti supportati e testa la presentazione reale prima dell'uso in produzione.

**Spostare una forma in avanti o indietro modifica l'ordine delle animazioni?**

No. L'ordine Z controlla la sovrapposizione delle forme, mentre l'ordine delle sequenze e i trigger controllano la riproduzione delle animazioni. Modifica la timeline se hai bisogno di un ordine di riproduzione diverso.