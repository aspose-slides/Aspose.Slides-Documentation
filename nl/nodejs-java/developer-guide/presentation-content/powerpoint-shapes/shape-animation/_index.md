---
title: Vormanimaties toepassen in presentaties met JavaScript
linktitle: Vormanimatie
type: docs
weight: 60
url: /nl/nodejs-java/shape-animation/
keywords:
- vorm
- animatie
- effect
- geanimeerde vorm
- geanimeerde tekst
- animatie toevoegen
- animatie ophalen
- animatie extraheren
- effect toevoegen
- effect ophalen
- effect extraheren
- effectgeluid
- animatie toepassen
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe je vormanimaties, timing, geluiden, gedrag na animatie en geanimeerde tekst kunt toevoegen, inspecteren en aanpassen met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Om met de individuele gedragingen binnen een effect te werken of motion‑path‑segmenten te bewerken, zie [Aangepaste animatie](/slides/nl/nodejs-java/custom-animation/).

Aspose.Slides for Node.js via Java vertegenwoordigt dia‑animaties als effecten in een dia‑tijdlijn. Een effect heeft een doelfiguur, een animatietype en subtype, een trigger, timinginstellingen en optionele eigenschappen zoals geluid of gedrag na de animatie.

De tijdlijn bevat twee soorten sequenties:

- De **hoofd‑sequentie** wordt afgespeeld terwijl de dia vooruitgaat.
- Een **interactieve sequentie** start wanneer de trigger‑figuur wordt aangeklikt.

Omdat tekstvakken, afbeeldingen, grafieken, tabellen en andere dia‑objecten [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/) objecten zijn, gebruik je dezelfde [Sequence.addEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/#addEffect)‑methode voor de meeste dia‑inhoud. De beschikbare effecten staan opgesomd in de [EffectType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effecttype/)‑enumeratie.

## **Vormanimaties toevoegen**

Om een animatie toe te voegen, haal je de hoofd‑sequentie van de dia op en roep je [Sequence.addEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/#addEffect) aan met de doelfiguur, het effecttype, subtype en trigger. Voor een effect dat start wanneer een andere figuur wordt aangeklikt, maak je een interactieve sequentie waarvan de trigger die andere figuur is.

Het volgende voorbeeld maakt beide soorten animaties en slaat het resultaat op in `shape-animations.pptx`.

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

De trigger bepaalt wanneer een effect start:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effecttriggertype/#OnClick) wacht op een klik in de hoofd‑sequentie, of op een klik op de trigger‑figuur in een interactieve sequentie.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) start samen met het voorgaande effect.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) start wanneer het voorgaande effect eindigt.

Om een afbeelding, grafiek of een ander figuurtype te animeren, geef je dat object door aan [Sequence.addEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/#addEffect) in plaats van `targetShape`. Voor grafiek‑specifieke groeperingsopties, zie [Geanimeerde grafieken](/slides/nl/nodejs-java/animated-charts/).

## **Vormanimaties lezen**

Gebruik [Sequence.getEffectsByShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/#getEffectsByShape) wanneer je de doelfiguur kent. Om elk effect te inspecteren, doorloop je de hoofd‑sequentie en elke interactieve sequentie. Enumeratie voorkomt de veronderstelling dat een sequentie een effect bevat op index `0`.

Het volgende voorbeeld maakt een figuur met hoofd‑sequentie‑ en interactieve effecten, haalt de effecten op die op de figuur richten en doorloopt vervolgens elke sequentie op de dia.

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

Als je alleen de effecten voor één figuur nodig hebt, identificeer dan eerst de figuur op naam, placeholder‑type of een andere stabiele eigenschap; roep vervolgens [Sequence.getEffectsByShape] aan. Ga er niet van uit dat [ShapeCollection.get_Item] op index `0` altijd het beoogde object is.

## **Werken met geërfde placeholder‑effecten**

Een placeholder op een normale dia kan animatiegedrag overnemen van de overeenkomstige placeholder op de lay‑outdia en de master‑dia. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getBasePlaceholder) retourneert die bovenliggende placeholder, of `null` wanneer er geen bovenligger bestaat.

In de volgende voorbeeldpresentatie heeft de voettekst **Random Bars** op de normale dia, **Split** op de lay‑outdia en **Fly In** op de master‑dia.

![Animatie‑effect van de voettekst op de normale dia](slide-shape-animation.png)

![Animatie‑effect van de voettekst‑placeholder op de lay‑outdia](layout-shape-animation.png)

![Animatie‑effect van de voettekst‑placeholder op de master‑dia](master-shape-animation.png)

Het volgende voorbeeld gebruikt een placeholder‑hiërarchie uit een nieuwe presentatie. Het voegt effecten toe aan een master‑placeholder, een lay‑out‑placeholder en de overeenkomstige placeholder op een normale dia. Elke aanroep van [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getBasePlaceholder) wordt gecontroleerd voordat de geretourneerde figuur wordt gebruikt.

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

## **Animatietiming wijzigen**

Het PowerPoint **Timing**‑dialoogvenster correspondeert met de eigenschappen van [Timing](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/).

![PowerPoint‑timingdialoog voor een animatie‑effect](shape-animation.png)

- **Start** correspondeert met [Timing.getTriggerType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getTriggerType).
- **Duur** correspondeert met [Timing.getDuration](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getDuration), in seconden.
- **Vertraging** correspondeert met [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getTriggerDelayTime), in seconden.
- **Herhalen** correspondeert met [Timing.getRepeatCount](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) of [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Terugspoelen bij voltooid** correspondeert met [Timing.getRewind](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getRewind).

Dit zelfstandige voorbeeld voegt een effect toe, wijzigt de timing via het object dat wordt geretourneerd door [Sequence.addEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/#addEffect), en slaat het resultaat op. Het behouden van de geretourneerde [Effect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/)‑referentie voorkomt een onnodige collectie‑index.

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

Gebruik opzettelijk één herhaal‑modus. Het combineren van een herhaal‑aantal met een "until"‑vlag kan verwarrende resultaten geven in verschillende weergaveprogramma's. Bij het wijzigen van herhaal‑modi, stel eerst [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) en [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) in alvorens [Timing.setRepeatCount](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#setRepeatCount) aan te roepen, omdat het instellen van een van beide vlaggen de actieve herhaal‑modus wijzigt.

## **Animatiegeluiden toevoegen en extraheren**

Een animatie‑effect kan ingebedde audio refereren via [Effect.getSound](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#setStopPreviousSound) vertelt een effect om audio te stoppen die door een eerder effect is gestart.

### **Een geluid aan een effect toevoegen**

Het volgende voorbeeld verwacht een lokaal audiobestand met de naam `animation-sound.wav`. Het maakt twee effecten, embedden dat bestand als geluid voor het eerste effect, en configureert het tweede effect om het geluid te stoppen. Het gebruikt de objecten die worden geretourneerd door [Sequence.addEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/#addEffect), zodat geen sequentie‑index nodig is.

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

### **Ingebedde effectgeluiden extraheren**

Het volgende voorbeeld verwacht een lokale presentatie met de naam `presentation-with-animation-sounds.pptx`. Het doorzoekt zowel de hoofd‑ als interactieve sequenties en schrijft elk ingebed effectgeluid naar de map `extracted-animation-sounds`. De extensie wordt gekozen op basis van het audio‑MIME‑type dat wordt blootgesteld door [Audio.getContentType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audio/#getContentType).

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

Voor grote audio‑objecten, gebruik [Audio.getStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audio/#getStream) en kopieer de stream naar een bestand in plaats van het gehele object in een byte‑array te laden.

## **Gedrag na animatie instellen**

De optie **After animation** bepaalt wat er met een figuur gebeurt nadat het effect is voltooid.

![PowerPoint‑effectopties‑dialoog met After‑animation‑instellingen](shape-after-animation.png)

De [AfterAnimationType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/afteranimationtype/)‑enumeratie ondersteunt het ongewijzigd laten van de figuur, het wijzigen van de kleur, het verbergen na de animatie, of het verbergen bij de volgende klik. Wanneer het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/afteranimationtype/#Color) is, stel dan ook [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#getAfterAnimationColor) in.

Dit zelfstandige voorbeeld maakt een effect, stelt het gedrag na animatie in via het geretourneerde effect‑object, en slaat het resultaat op.

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

Het wijzigen van het type van [AfterAnimationType.Color] wist de after‑animation‑kleurinstelling.

## **Tekst animeren**

Tekst‑animatie heeft twee gerelateerde instellingen:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textanimation/#getBuildType) bepaalt of alinea's tegelijk of per alinea‑niveau verschijnen.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#getAnimateTextType) bepaalt of tekst in één keer, per woord of per letter verschijnt. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) stelt de vertraging tussen woorden of letters in. Een positieve waarde is een percentage van de effectduur; een negatieve waarde is een vertraging in seconden.

Het volgende zelfstandige voorbeeld animeert de woorden in een tekstvak. [BuildType.AsOneObject](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/buildtype/#AsOneObject) schakelt opbouw per alinea uit zodat de woord‑instelling van toepassing is op het hele tekstframe.

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

Om een tekstvak per alinea op te bouwen, stel je [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (of een ander alinea‑niveau) in. Om een enkele alinea met een eigen effect te richten, gebruik je de overload van [Sequence.addEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/#addEffect) die een [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) accepteert. Zie [Geanimeerde tekst](/slides/nl/nodejs-java/animated-text/) voor voorbeelden op alinea‑niveau.

## **Export‑ en compatibiliteitsopmerkingen**

- Opslaan als PPT of PPTX behoudt het animatiemodel, maar de uiteindelijke weergave wordt beheerd door de presentatiewerker.
- PDF en statische afbeeldingen spelen geen animaties af. Gebruik [HTML5-export](/slides/nl/nodejs-java/export-to-html5/), geanimeerde GIF of [video‑conversie](/slides/nl/nodejs-java/convert-powerpoint-to-video/) wanneer de uitvoer beweging moet tonen.
- Voor HTML5, schakel [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/html5options/#setAnimateShapes) in en, indien nodig, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).
- Video‑rendering ondersteunt veel gangbare ingang‑, nadruk‑, exit‑ en motion‑path‑effecten, maar niet elk PowerPoint‑effect wordt ondersteund. Controleer de actuele [ondersteunde animaties en effecten](/slides/nl/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) en test kritieke presentaties met uw beoogde Aspose.Slides‑versie.
- Geavanceerde aangepaste effecten en effecten geïmporteerd uit andere presentatie‑formaten kunnen in het bestand worden bewaard maar anders worden gerenderd in PowerPoint, HTML5 of video. Valideer het geëxporteerde resultaat in plaats van alleen op de effectnaam te vertrouwen.

## **FAQ**

**Waarom verschijnt een animatie in PowerPoint maar niet in een PDF?**

PDF is een statisch formaat, dus animaties en dia‑overgangen worden niet afgespeeld. Exporteer naar HTML5, een geanimeerde GIF of video wanneer beweging bewaard moet blijven.

**Waarom wordt een effect anders afgespeeld in een video?**

Video‑export renderen animaties in plaats van het originele PowerPoint‑gedrag op te slaan. Sommige geavanceerde effecten worden niet ondersteund of benaderd. Bekijk de tabel met ondersteunde effecten en test de werkelijke presentatie voordat u deze in productie gebruikt.

**Verandert het verplaatsen van een figuur naar voren of naar achteren de volgorde van de animatie?**

Nee. De z‑orde van de figuur bepaalt de overlap, terwijl de volgorde van de sequentie en triggers de weergave van de animatie bepalen. Pas de tijdlijn aan als u een andere afspeelvolgorde nodig heeft.