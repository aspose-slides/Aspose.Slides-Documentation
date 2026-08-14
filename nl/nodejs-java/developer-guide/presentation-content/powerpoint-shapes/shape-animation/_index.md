---
title: Toepassen van vormanimaties in presentaties met JavaScript
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
description: "Leer hoe u vormanimaties, timing, geluiden, gedrag na animatie en geanimeerde tekst kunt toevoegen, inspecteren en aanpassen met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Aspose.Slides for Node.js via Java stelt dia‑animaties voor als effecten in een diatijdlijn. Een effect heeft een doelvorm, een animatietype en subtype, een trigger, timinginstellingen en optionele eigenschappen zoals geluid of gedrag na de animatie.

De tijdlijn bevat twee soorten sequenties:

- De **hoofdsequentie** speelt af terwijl de dia vordert.
- Een **interactieve sequentie** begint wanneer de triggervorm wordt aangeklikt.

Omdat tekstvakken, afbeeldingen, grafieken, tabellen en andere dia‑objecten [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/)‑objecten zijn, gebruik je dezelfde [Sequence.addEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/#addEffect)‑methode voor de meeste dia‑inhoud. De beschikbare effecten staan opgesomd in de [EffectType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effecttype/)‑enumeratie.

## **Vormanimaties toevoegen**

Om een animatie toe te voegen, haal je de hoofdsequentie van de dia op en roep je [Sequence.addEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/#addEffect) aan met de doelvorm, het effecttype, subtype en trigger. Voor een effect dat start wanneer een andere vorm wordt aangeklikt, maak je een interactieve sequentie aan waarvan de trigger die andere vorm is.

Het volgende voorbeeld maakt beide soorten animatie en slaat het resultaat op als `shape-animations.pptx`.

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

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effecttriggertype/#OnClick) wacht op een klik in de hoofdsequentie, of op een klik op de triggervorm in een interactieve sequentie.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) start samen met het voorafgaande effect.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) start wanneer het voorafgaande effect eindigt.

Om een afbeelding, grafiek of een ander type vorm te animeren, geef je dat object door aan [Sequence.addEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/#addEffect) in plaats van `targetShape`. Voor specifieke groeperingsopties voor grafieken, zie [Animated Charts](/slides/nl/nodejs-java/animated-charts/).

## **Vormanimaties lezen**

Gebruik [Sequence.getEffectsByShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/#getEffectsByShape) wanneer je de doelvorm kent. Om elk effect te inspecteren, doorloop je de hoofdsequentie en elke interactieve sequentie. Enumeratie voorkomt dat je aanneemt dat een sequentie een effect bevat op index `0`.

Het volgende voorbeeld maakt een vorm met hoofd‑ en interactieve effecten, haalt de effecten op die op de vorm gericht zijn, en doorloopt vervolgens elke sequentie op de dia.

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

Als je alleen de effecten voor één vorm nodig hebt, identificeer dan eerst de vorm op naam, placeholder‑type of een andere stabiele eigenschap; roep daarna [Sequence.getEffectsByShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/#getEffectsByShape) aan. Ga niet ervan uit dat [ShapeCollection.get_Item](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/#get_Item) op index `0` altijd het beoogde object is.

## **Werken met overgeërfde placeholder‑effecten**

Een placeholder op een gewone dia kan het animatiegedrag erven van de overeenkomstige placeholder op de lay‑outdia en de mastersdia. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getBasePlaceholder) retourneert die bovenliggende placeholder, of `null` wanneer er geen bovenligger bestaat.

In de volgende voorbeeldpresentatie heeft de voettekst **Random Bars** op de gewone dia, **Split** op de lay‑outdia en **Fly In** op de mastersdia.

![Animatie‑effect van de voettekst op de gewone dia](slide-shape-animation.png)

![Animatie‑effect van de voettekst‑placeholder op de lay‑outdia](layout-shape-animation.png)

![Animatie‑effect van de voettekst‑placeholder op de mastersdia](master-shape-animation.png)

Het volgende voorbeeld gebruikt een placeholder‑hiërarchie uit een nieuwe presentatie. Het voegt effecten toe aan een master‑placeholder, een lay‑out‑placeholder en de overeenkomstige placeholder op een gewone dia. Elke oproep aan [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getBasePlaceholder) wordt gecontroleerd voordat de geretourneerde vorm wordt gebruikt.

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

- **Start** komt overeen met [Timing.getTriggerType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getTriggerType).
- **Duur** komt overeen met [Timing.getDuration](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getDuration), in seconden.
- **Vertraging** komt overeen met [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getTriggerDelayTime), in seconden.
- **Herhalen** komt overeen met [Timing.getRepeatCount](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick), of [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Terugspoelen na afspelen** komt overeen met [Timing.getRewind](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#getRewind).

Dit onafhankelijke voorbeeld voegt een effect toe, wijzigt de timing via het object dat wordt geretourneerd door [Sequence.addEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/#addEffect), en slaat het resultaat op. Het bewaren van de geretourneerde [Effect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/)‑referentie voorkomt een onnodige collecties‑index.

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

Gebruik bewust één herhaalmodus. Het combineren van een herhaaltaantal met een “until”‑vlag kan verwarrende resultaten geven in verschillende weergave‑programma’s. Wanneer je herhaalmodi wijzigt, stel je [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) en [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) in vóór [Timing.setRepeatCount](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/timing/#setRepeatCount), omdat het instellen van een van de vlaggen ook de actieve herhaalmodus wijzigt.

## **Animatiegeluiden toevoegen en extraheren**

Een animatie‑effect kan via [Effect.getSound](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#getSound) naar ingesloten audio verwijzen. [Effect.setStopPreviousSound](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#setStopPreviousSound) geeft een effect de opdracht om audio die door een eerder effect is gestart te stoppen.

### **Een geluid aan een effect toevoegen**

Het volgende voorbeeld verwacht een lokaal audiobestand met de naam `animation-sound.wav`. Het maakt twee effecten, embed het bestand als geluid voor het eerste effect, en configureert het tweede effect om het geluid te stoppen. Het gebruikt de objecten die worden geretourneerd door [Sequence.addEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/#addEffect), dus een sequentie‑index is niet nodig.

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

### **Ingesloten effectgeluiden extraheren**

Het volgende voorbeeld verwacht een lokale presentatie met de naam `presentation-with-animation-sounds.pptx`. Het scant zowel de hoofd‑ als interactieve sequenties en schrijft elk ingesloten effectgeluid weg naar de map `extracted-animation-sounds`. De extensie wordt gekozen op basis van het audio‑MIME‑type dat wordt blootgesteld door [Audio.getContentType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audio/#getContentType).

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

Voor grote audio‑objecten, gebruik [Audio.getStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audio/#getStream) en kopieer de stream naar een bestand in plaats van het volledige object in een byte‑array te laden.

## **Gedrag na animatie instellen**

De optie **After animation** bepaalt wat er met een vorm gebeurt nadat het effect is voltooid.

![PowerPoint‑effectoptiedialoog met instellingen voor After animation](shape-after-animation.png)

De [AfterAnimationType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/afteranimationtype/)‑enumeratie biedt de mogelijkheid om de vorm ongewijzigd te laten, de kleur te wijzigen, deze na de animatie te verbergen, of te verbergen bij de volgende klik. Wanneer het type [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/afteranimationtype/#Color) is, stel dan ook [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#getAfterAnimationColor) in.

Dit onafhankelijke voorbeeld creëert een effect, stelt het gedrag na de animatie in via het geretourneerde effect‑object, en slaat het resultaat op.

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

Het wijzigen van het type van [AfterAnimationType.Color](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/afteranimationtype/#Color) wist de kleurinstelling voor after‑animation.

## **Tekst animeren**

Tekstanimatie heeft twee gerelateerde besturingen:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textanimation/#getBuildType) bepaalt of alinea’s samen of per alinea‑niveau verschijnen.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#getAnimateTextType) bepaalt of tekst in één keer, per woord of per letter verschijnt. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) stelt de vertraging tussen woorden of letters in. Een positieve waarde is een percentage van de effectduur; een negatieve waarde is een vertraging in seconden.

Het volgende onafhankelijke voorbeeld animeert de woorden in een tekstvak. [BuildType.AsOneObject](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/buildtype/#AsOneObject) schakelt het opbouwen per alinea uit zodat de woordinstelling van toepassing is op het gehele tekstframe.

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

Om een tekstvak per alinea op te bouwen, stel je [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) in (of een ander alinea‑niveau). Om een enkele alinea met een eigen effect te targeten, gebruik je de overload van [Sequence.addEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sequence/#addEffect) die een [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) accepteert. Zie [Animated Text](/slides/nl/nodejs-java/animated-text/) voor voorbeelden op alinea‑niveau.

## **Export‑ en compatibiliteitsopmerkingen**

- Opslaan als PPT of PPTX behoudt het animatiemodel, maar de uiteindelijke weergave wordt bepaald door de presentatieweergave.
- PDF en statische afbeeldingen spelen geen animaties af. Gebruik [HTML5 export](/slides/nl/nodejs-java/export-to-html5/), geanimeerde GIF, of [video conversion](/slides/nl/nodejs-java/convert-powerpoint-to-video/) wanneer de output beweging moet tonen.
- Voor HTML5, schakel [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/html5options/#setAnimateShapes) in en, indien nodig, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).
- Video‑rendering ondersteunt veel gangbare ingang‑, nadruk‑, uitgang‑ en bewegings‑path‑effecten, maar niet elk PowerPoint‑effect wordt ondersteund. Controleer de huidige [supported animations and effects](/slides/nl/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) en test kritieke presentaties met de beoogde Aspose.Slides‑versie.
- Geavanceerde aangepaste effecten en effecten geïmporteerd uit andere presentatieformaten kunnen in het bestand behouden blijven maar anders worden gerenderd in PowerPoint, HTML5 of video. Valideer het geëxporteerde resultaat in plaats van alleen op de effectnaam te vertrouwen.

## **FAQ**

**Waarom verschijnt een animatie in PowerPoint maar niet in een PDF?**

PDF is een statisch formaat, dus animaties en dia‑overgangen worden niet afgespeeld. Exporteer naar HTML5, een geanimeerde GIF, of video wanneer beweging behouden moet blijven.

**Waarom wordt een effect anders afgespeeld in een video?**

Video‑export rendert animaties in plaats van het originele PowerPoint‑gedrag op te slaan. Sommige geavanceerde effecten worden niet ondersteund of benaderd. Bekijk de tabel met ondersteunde effecten en test de daadwerkelijke presentatie voordat je deze in productie neemt.

**Verandert het naar voren of naar achteren verplaatsen van een vorm de volgorde van de animatie?**

Nee. De z‑volgorde van een vorm bepaalt de overlap, terwijl de volgorde van de sequentie en triggers de afspeelvolgorde van de animatie bepalen. Pas de tijdlijn aan als je een andere afspeelvolgorde nodig hebt.