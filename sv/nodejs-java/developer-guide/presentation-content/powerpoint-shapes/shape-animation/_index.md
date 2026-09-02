---
title: Tillämpa formanimationer i presentationer med JavaScript
linktitle: Formanimation
type: docs
weight: 60
url: /sv/nodejs-java/shape-animation/
keywords:
- form
- animation
- effekt
- animerad form
- animerad text
- lägga till animation
- hämta animation
- extrahera animation
- lägga till effekt
- hämta effekt
- extrahera effekt
- effektljud
- tillämpa animation
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du lägger till, granskar och anpassar formanimationer, timing, ljud, beteende efter animation samt animerad text med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Aspose.Slides för Node.js via Java representerar bildanimationer som effekter i en bildtidslinje. En effekt har en målform, en animationstyp och undertyp, en trigger, tidsinställningar och valfria egenskaper såsom ljud eller beteende efter animationen.

Tidslinjen innehåller två typer av sekvenser:

- **huvudsekvensen** spelas när bilden avancerar.
- En **interaktiv sekvens** startas när dess triggerform klickas.

Eftersom textrutor, bilder, diagram, tabeller och andra bildobjekt är [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/)-objekt använder du samma [Sequence.addEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sequence/#addEffect)-metod för det mesta av bildinnehållet. De tillgängliga effekterna listas i uppräkningen [EffectType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effecttype/).

## **Lägg till formanimationer**

För att lägga till en animation hämtar du bildens huvudsekvens och anropar [Sequence.addEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sequence/#addEffect) med målformen, effekt‑typen, undertypen och triggern. För en effekt som startas när en annan form klickas skapar du en interaktiv sekvens vars trigger är den andra formen.

Följande exempel skapar båda typerna av animation och sparar resultatet till `shape-animations.pptx`.

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

Triggern bestämmer när en effekt startar:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effecttriggertype/#OnClick) väntar på ett klick i huvudsekvensen, eller på ett klick på triggerformen i en interaktiv sekvens.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) startar med den föregående effekten.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) startar när den föregående effekten slutar.

För att animera en bild, ett diagram eller en annan formtyp, skicka det objektet till [Sequence.addEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sequence/#addEffect) i stället för `targetShape`. För diagramspecifika grupperingalternativ, se [Animated Charts](/slides/sv/nodejs-java/animated-charts/).

## **Läs formanimationer**

Använd [Sequence.getEffectsByShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sequence/#getEffectsByShape) när du känner till målformen. För att inspektera varje effekt, iterera över huvudsekvensen och varje interaktiv sekvens. Iteration undviker antagandet att en sekvens innehåller en effekt på index `0`.

Följande exempel skapar en form med huvud‑ och interaktiva effekter, hämtar de effekter som riktar sig mot formen och itererar sedan över varje sekvens på bilden.

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

Om du bara behöver effekterna för en form, identifiera först formen efter namn, platshållartyp eller annan stabil egenskap; anropa sedan [Sequence.getEffectsByShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sequence/#getEffectsByShape). Anta inte att [ShapeCollection.get_Item](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/#get_Item) på index `0` alltid är det avsedda objektet.

## **Arbeta med ärvda platshållareffekter**

En platshållare på en normal bild kan ärva animationsbeteende från motsvarande platshållare på layout‑ och masternivå. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getBasePlaceholder) returnerar den överordnade platshållaren, eller `null` när ingen förälder finns.

I den följande exempelpresentationen har sidfoten **Random Bars** på den normala bilden, **Split** på layout‑bilden och **Fly In** på mastern.

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

Det nästa exemplet använder en platshållar‑hierarki från en ny presentation. Det lägger till effekter på en master‑platshållare, en layout‑platshållare och motsvarande platshållare på en normal bild. Varje anrop till [Shape.getBasePlaceholder](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getBasePlaceholder) kontrolleras innan den returnerade formen används.

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

## **Ändra animationstiming**

PowerPoint‑dialogen **Timing** motsvarar egenskaperna i [Timing](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/).

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** motsvarar [Timing.getTriggerType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#getTriggerType).
- **Duration** motsvarar [Timing.getDuration](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#getDuration), i sekunder.
- **Delay** motsvarar [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#getTriggerDelayTime), i sekunder.
- **Repeat** motsvarar [Timing.getRepeatCount](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) eller [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** motsvarar [Timing.getRewind](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#getRewind).

Detta fristående exempel lägger till en effekt, ändrar dess timing via objektet som returneras av [Sequence.addEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sequence/#addEffect) och sparar resultatet. Att behålla den returnerade [Effect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/)-referensen undviker ett onödigt samla‑index.

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

Använd ett upprepningsläge avsiktligt. Att kombinera ett upprepningsantal med ett ”tills‑”‑flagga kan ge förvirrande resultat i olika visare. När du ändrar upprepningslägen, anropa först [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) och [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) innan du anropar [Timing.setRepeatCount](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/timing/#setRepeatCount), eftersom att sätta någon av flaggorna även ändrar det aktiva upprepningsläget.

## **Lägg till och extrahera animationsljud**

En animationseffekt kan referera inbäddat ljud via [Effect.getSound](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#setStopPreviousSound) talar om för en effekt att stoppa ljud som startats av en tidigare effekt.

### **Lägg till ett ljud i en effekt**

Följande exempel förutsätter en lokal ljudfil med namn `animation-sound.wav`. Det skapar två effekter, bäddar in den filen som ljud för den första effekten och konfigurerar den andra effekten att stoppa ljudet. Det använder objekten som returneras av [Sequence.addEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sequence/#addEffect), så inget sekvensindex krävs.

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

### **Extrahera inbäddade effektljud**

Följande exempel förutsätter en lokal presentation med namn `presentation-with-animation-sounds.pptx`. Det skannar både huvud‑ och interaktiva sekvenser och skriver varje inbäddat effektljud till katalogen `extracted-animation-sounds`. Filändelsen väljs utifrån ljud‑MIME‑typen som exponeras av [Audio.getContentType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audio/#getContentType).

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

För stora ljudobjekt, använd [Audio.getStream](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audio/#getStream) och kopiera strömmen till en fil i stället för att ladda hela objektet i en byte‑array.

## **Ställ in beteende efter animation**

Alternativet **After animation** styr vad som händer med en form efter att dess effekt är klar.

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/afteranimationtype/)-uppräkningen stödjer att låta formen förbli oförändrad, ändra dess färg, dölja den efter animationen eller dölja den vid nästa klick. När typen är [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/afteranimationtype/#Color) sätt även [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#getAfterAnimationColor).

Detta fristående exempel skapar en effekt, sätter dess efter‑animationsbeteende via det returnerade effekt‑objektet och sparar resultatet.

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

Att ändra typen från [AfterAnimationType.Color](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/afteranimationtype/#Color) rensar färginställningen för efter‑animationen.

## **Animera text**

Textanimation har två relaterade kontroller:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textanimation/#getBuildType) styr om stycken visas tillsammans eller stycke för stycke.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#getAnimateTextType) styr om text visas på en gång, ord för ord eller bokstav för bokstav. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) anger fördröjningen mellan ord eller bokstäver. Ett positivt värde är en procentandel av effektens varaktighet; ett negativt värde är en fördröjning i sekunder.

Följande fristående exempel animerar orden i en textruta. [BuildType.AsOneObject](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/buildtype/#AsOneObject) inaktiverar byggande stycke för stycke så att ordinställningen gäller hela textramen.

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

För att bygga en textruta stycke för stycke, sätt [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (eller en annan stycknivå). För att rikta en enskild paragraf med sin egen effekt, använd [Sequence.addEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sequence/#addEffect)-överlagringen som accepterar ett [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/). Se [Animated Text](/slides/sv/nodejs-java/animated-text/) för exempel på stycknivå.

## **Export och kompatibilitetsnoteringar**

- Att spara till PPT eller PPTX bevarar animationsmodellen, men den slutliga uppspelningen styrs av presentationsvisaren.
- PDF och statiska bilder spelar inte upp animationer. Använd [HTML5 export](/slides/sv/nodejs-java/export-to-html5/), animerad GIF eller [videokonvertering](/slides/sv/nodejs-java/convert-powerpoint-to-video/) när utdata måste visa rörelse.
- För HTML5, aktivera [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/html5options/#setAnimateShapes) och, vid behov, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).
- Videorendering stödjer många vanliga ingångs‑, betoning‑, utgångs‑ och rörelse‑banefeekter, men inte varje PowerPoint‑effekt stöds. Kontrollera de aktuella [supported animations and effects](/slides/sv/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) och testa kritiska presentationer med den version av Aspose.Slides du använder.
- Avancerade anpassade effekter och effekter importerade från andra presentationsformat kan bevaras i filen men renderas annorlunda i PowerPoint, HTML5 eller video. Validera det exporterade resultatet istället för att enbart förlita dig på effektens namn.

## **FAQ**

**Varför visas en animation i PowerPoint men inte i en PDF?**

PDF är ett statiskt format, så animationer och bildövergångar spelas inte upp. Exportera till HTML5, animerad GIF eller video när rörelse måste bevaras.

**Varför spelas en effekt annorlunda i en video?**

Videoexport renderar animationer i stället för att lagra det ursprungliga PowerPoint‑beteendet. Vissa avancerade effekter stöds inte eller approximeras. Granska tabellen över stödjade effekter och testa den faktiska presentationen innan produktionsanvändning.

**Ändrar en flyttning av en form framåt eller bakåt dess animationsordning?**

Nej. Formens z‑ordning styr överlappning, medan sekvensordning och triggers styr animationsuppspelning. Ändra tidslinjen om du behöver en annan uppspelningsordning.