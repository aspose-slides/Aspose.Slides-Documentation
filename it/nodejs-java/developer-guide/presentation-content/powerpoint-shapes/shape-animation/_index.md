---
title: Applicare animazioni di forma nelle presentazioni usando JavaScript
linktitle: Animazione forma
type: docs
weight: 60
url: /it/nodejs-java/shape-animation/
keywords:
- forma
- animazione
- effetto
- forma animata
- testo animato
- aggiungere animazione
- ottenere animazione
- estrarre animazione
- aggiungere effetto
- ottenere effetto
- estrarre effetto
- suono effetto
- applicare animazione
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come aggiungere, ispezionare e personalizzare le animazioni di forma, la temporizzazione, i suoni, il comportamento post-animazione e il testo animato con Aspose.Slides per Node.js tramite Java."
---
## **Panoramica**

Per lavorare con i singoli comportamenti all'interno di un effetto o modificare i segmenti del percorso di movimento, vedere [Animazione personalizzata](/slides/it/nodejs-java/custom-animation/).

Aspose.Slides per Node.js tramite Java rappresenta le animazioni delle diapositive come effetti in una timeline della diapositiva. Un effetto ha una forma target, un tipo e sottotipo di animazione, un trigger, impostazioni di temporizzazione e proprietà opzionali come suono o comportamento post‑animazione.

La timeline contiene due tipi di sequenze:

- La **sequenza principale** viene riprodotta mentre la diapositiva avanza.
- Una **sequenza interattiva** inizia quando la sua forma di trigger viene cliccata.

Poiché caselle di testo, immagini, grafici, tabelle e altri oggetti della diapositiva sono oggetti [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/), si utilizza lo stesso metodo [Sequence.addEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#addEffect) per la maggior parte del contenuto della diapositiva. Gli effetti disponibili sono elencati nell'enumerazione [EffectType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effecttype/).

## **Aggiungere animazioni alle forme**

Per aggiungere un'animazione, ottenere la sequenza principale della diapositiva e chiamare [Sequence.addEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#addEffect) con la forma target, il tipo di effetto, il sottotipo e il trigger. Per un effetto che inizia quando un'altra forma viene cliccata, creare una sequenza interattiva il cui trigger è quell'altra forma.

Il seguente esempio crea entrambi i tipi di animazione e salva il risultato in `shape-animations.pptx`.

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

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effecttriggertype/#OnClick) attende un clic nella sequenza principale, o un clic sulla forma di trigger in una sequenza interattiva.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) inizia con l'effetto precedente.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) inizia quando l'effetto precedente termina.

Per animare un'immagine, un grafico o un altro tipo di forma, passare quell'oggetto a [Sequence.addEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#addEffect) invece di `targetShape`. Per le opzioni di raggruppamento specifiche dei grafici, vedere [Grafici animati](/slides/it/nodejs-java/animated-charts/).

## **Leggere le animazioni delle forme**

Utilizzare [Sequence.getEffectsByShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#getEffectsByShape) quando si conosce la forma target. Per ispezionare ogni effetto, enumerare la sequenza principale e ogni sequenza interattiva. L'enumerazione evita di presumere che una sequenza contenga un effetto all'indice `0`.

Il seguente esempio crea una forma con effetti nella sequenza principale e interattiva, ottiene gli effetti che hanno la forma come target, e poi enumera ogni sequenza sulla diapositiva.

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

Se hai bisogno solo degli effetti per una singola forma, identifica prima la forma per nome, tipo di segnaposto o un'altra proprietà stabile; poi chiama [Sequence.getEffectsByShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#getEffectsByShape). Non presumere che [ShapeCollection.get_Item](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/#get_Item) all'indice `0` sia sempre l'oggetto desiderato.

## **Lavorare con gli effetti dei segnaposto ereditati**

Un segnaposto su una diapositiva normale può ereditare il comportamento dell'animazione dal corrispondente segnaposto sulla diapositiva layout e su quella master. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getBasePlaceholder) restituisce quel segnaposto genitore, o `null` se non esiste alcun genitore.

Nella presentazione di esempio seguente, il piè di pagina ha **Random Bars** sulla diapositiva normale, **Split** sulla diapositiva layout e **Fly In** sulla diapositiva master.

![Effetto di animazione del piè di pagina sulla diapositiva normale](slide-shape-animation.png)

![Effetto di animazione del segnaposto piè di pagina sulla diapositiva layout](layout-shape-animation.png)

![Effetto di animazione del segnaposto piè di pagina sulla diapositiva master](master-shape-animation.png)

Il prossimo esempio utilizza una gerarchia di segnaposto da una nuova presentazione. Aggiunge effetti a un segnaposto master, a un segnaposto layout e al corrispondente segnaposto su una diapositiva normale. Ogni chiamata a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getBasePlaceholder) è verificata prima di utilizzare la forma restituita.

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

## **Modificare la temporizzazione dell'animazione**

La finestra di dialogo **Timing** di PowerPoint corrisponde alle proprietà di [Timing](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/).

![Finestra di dialogo Timing di PowerPoint per un effetto di animazione](shape-animation.png)

- **Inizio** corrisponde a [Timing.getTriggerType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getTriggerType).
- **Durata** corrisponde a [Timing.getDuration](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getDuration), in secondi.
- **Ritardo** corrisponde a [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getTriggerDelayTime), in secondi.
- **Ripetizione** corrisponde a [Timing.getRepeatCount](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick), o [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Riavvolgi al termine della riproduzione** corrisponde a [Timing.getRewind](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#getRewind).

Questo esempio autonomo aggiunge un effetto, ne modifica la temporizzazione tramite l'oggetto restituito da [Sequence.addEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#addEffect), e salva il risultato. Mantenere il riferimento al [Effect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/) restituito evita un indice di raccolta non necessario.

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

Utilizzare intenzionalmente una sola modalità di ripetizione. Combinare un conteggio di ripetizioni con un flag "until" può produrre risultati confusi in diversi visualizzatori. Quando si modificano le modalità di ripetizione, impostare [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) e [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) prima di [Timing.setRepeatCount](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/timing/#setRepeatCount), poiché l'impostazione di uno dei flag cambia anche la modalità di ripetizione attiva.

## **Aggiungere ed estrarre suoni delle animazioni**

Un effetto di animazione può fare riferimento a audio incorporato tramite [Effect.getSound](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#setStopPreviousSound) indica a un effetto di interrompere l'audio avviato da un effetto precedente.

### **Aggiungere un suono a un effetto**

Il seguente esempio richiede un file audio locale denominato `animation-sound.wav`. Crea due effetti, incorpora quel file come suono per il primo effetto e configura il secondo effetto per fermare il suono. Utilizza gli oggetti restituiti da [Sequence.addEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#addEffect), quindi non è necessario specificare un indice di sequenza.

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

### **Estrarre suoni incorporati negli effetti**

Il seguente esempio richiede una presentazione locale denominata `presentation-with-animation-sounds.pptx`. Scansiona sia le sequenze principali che quelle interattive e scrive ogni suono di effetto incorporato nella directory `extracted-animation-sounds`. L'estensione è selezionata dal tipo MIME audio fornito da [Audio.getContentType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audio/#getContentType).

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

Per oggetti audio di grandi dimensioni, utilizzare [Audio.getStream](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audio/#getStream) e copiare lo stream in un file invece di caricare l'intero oggetto in un array di byte.

## **Impostare il comportamento post‑animazione**

L'opzione **After animation** controlla cosa succede a una forma dopo che il suo effetto è terminato.

![Finestra di dialogo Opzioni effetto di PowerPoint che mostra le impostazioni After animation](shape-after-animation.png)

L'enumerazione [AfterAnimationType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/afteranimationtype/) consente di lasciare la forma invariata, cambiarne il colore, nasconderla dopo l'animazione o nasconderla al prossimo clic. Quando il tipo è [AfterAnimationType.Color](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/afteranimationtype/#Color), impostare anche [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#getAfterAnimationColor).

Questo esempio autonomo crea un effetto, imposta il suo comportamento post‑animazione tramite l'oggetto effetto restituito e salva il risultato.

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

Cambiare il tipo da [AfterAnimationType.Color](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/afteranimationtype/#Color) cancella l'impostazione del colore post‑animazione.

## **Animare il testo**

L'animazione del testo ha due controlli correlati:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textanimation/#getBuildType) controlla se i paragrafi appaiono tutti insieme o livello per livello di paragrafo.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#getAnimateTextType) controlla se il testo appare tutto in una volta, parola per parola o lettera per lettera. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) imposta il ritardo tra parole o lettere. Un valore positivo è una percentuale della durata dell'effetto; un valore negativo è un ritardo in secondi.

Il seguente esempio autonomo anima le parole in una casella di testo. [BuildType.AsOneObject](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/buildtype/#AsOneObject) disabilita la costruzione paragrafo per paragrafo in modo che l'impostazione per parola si applichi all'intero riquadro di testo.

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

Per costruire una casella di testo per paragrafo, impostare [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (o un altro livello di paragrafo). Per mirare a un singolo paragrafo con un proprio effetto, utilizzare la sovraccarico di [Sequence.addEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sequence/#addEffect) che accetta un [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/). Vedere [Testo animato](/slides/it/nodejs-java/animated-text/) per esempi a livello di paragrafo.

## **Note su esportazione e compatibilità**

- Salvare in PPT o PPTX preserva il modello di animazione, ma la riproduzione finale è controllata dal visualizzatore della presentazione.
- PDF e immagini statiche non riproducono animazioni. Utilizzare [esportazione HTML5](/slides/it/nodejs-java/export-to-html5/), GIF animate o [conversione video](/slides/it/nodejs-java/convert-powerpoint-to-video/) quando l'output deve mostrare movimento.
- Per HTML5, abilitare [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/html5options/#setAnimateShapes) e, se necessario, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).
- Il rendering video supporta molti effetti comuni di ingresso, enfasi, uscita e percorsi di movimento, ma non tutti gli effetti di PowerPoint sono supportati. Verificare le attuali [animazioni e effetti supportati](/slides/it/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) e testare le presentazioni critiche con la versione di Aspose.Slides di destinazione.
- Effetti personalizzati avanzati e effetti importati da altri formati di presentazione possono essere preservati nel file ma renderizzati diversamente in PowerPoint, HTML5 o video. Convalidare il risultato esportato invece di fare affidamento solo sul nome dell'effetto.

## **FAQ**

**Perché un'animazione appare in PowerPoint ma non in un PDF?**

Il PDF è un formato statico, quindi le animazioni e le transizioni delle diapositive non vengono riprodotte. Esportare in HTML5, GIF animate o video quando è necessario preservare il movimento.

**Perché un effetto viene riprodotto diversamente in un video?**

L'esportazione video rende le animazioni invece di memorizzare il comportamento originale di PowerPoint. Alcuni effetti avanzati non sono supportati o sono approssimati. Consultare la tabella degli effetti supportati e testare la presentazione reale prima dell'uso in produzione.

**Spostare una forma avanti o indietro cambia l'ordine dell'animazione?**

No. L'ordine z della forma controlla la sovrapposizione, mentre l'ordine delle sequenze e i trigger controllano la riproduzione dell'animazione. Modificare la timeline se è necessario un ordine di riproduzione diverso.