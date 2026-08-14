---
title: Formanimationen in Präsentationen mit JavaScript anwenden
linktitle: Formanimation
type: docs
weight: 60
url: /de/nodejs-java/shape-animation/
keywords:
- Form
- Animation
- Effekt
- animierte Form
- animierter Text
- Animation hinzufügen
- Animation abrufen
- Animation extrahieren
- Effekt hinzufügen
- Effekt abrufen
- Effekt extrahieren
- Effektton
- Animation anwenden
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formanimationen, Timing, Sounds, das Verhalten nach der Animation und animierten Text mit Aspose.Slides für Node.js via Java hinzufügen, prüfen und anpassen."
---
## **Übersicht**

Aspose.Slides for Node.js via Java stellt Folienanimationen als Effekte in einer Folientimeline dar. Ein Effekt hat eine Zielform, einen Animationstyp und -untertyp, einen Auslöser, Zeiteinstellungen und optionale Eigenschaften wie Sound oder das Verhalten nach der Animation.

Die Timeline enthält zwei Arten von Sequenzen:

- Die **Hauptsequenz** wird abgespielt, wenn die Folie voranschreitet.
- Eine **interaktive Sequenz** beginnt, wenn die auslösende Form angeklickt wird.

Da Textfelder, Bilder, Diagramme, Tabellen und andere Folienobjekte [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/)‑Objekte sind, verwenden Sie die gleiche Methode [Sequence.addEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sequence/#addEffect) für die meisten Folieninhalte. Die verfügbaren Effekte sind in der Aufzählung [EffectType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effecttype/) aufgelistet.

## **Formanimationen hinzufügen**

Um eine Animation hinzuzufügen, holen Sie sich die Hauptsequenz der Folie und rufen [Sequence.addEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sequence/#addEffect) mit der Zielform, dem Effekt­typ, -untertyp und dem Auslöser auf. Für einen Effekt, der startet, wenn eine andere Form angeklickt wird, erstellen Sie eine interaktive Sequenz, deren Auslöser diese andere Form ist.

Das folgende Beispiel erstellt beide Animationsarten und speichert das Ergebnis in `shape-animations.pptx`.

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

Der Auslöser bestimmt, wann ein Effekt startet:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effecttriggertype/#OnClick) wartet auf einen Klick in der Hauptsequenz oder auf einen Klick auf die auslösende Form in einer interaktiven Sequenz.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) beginnt mit dem vorherigen Effekt.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) beginnt, wenn der vorherige Effekt endet.

Um ein Bild, Diagramm oder einen anderen Formtyp zu animieren, übergeben Sie dieses Objekt an [Sequence.addEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sequence/#addEffect) anstelle von `targetShape`. Für diagrammspezifische Gruppierungsoptionen siehe [Animated Charts](/slides/de/nodejs-java/animated-charts/).

## **Formanimationen lesen**

Verwenden Sie [Sequence.getEffectsByShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sequence/#getEffectsByShape), wenn Sie die Zielform kennen. Um jeden Effekt zu prüfen, enumerieren Sie die Hauptsequenz und jede interaktive Sequenz. Die Enumeration verhindert die Annahme, dass eine Sequenz einen Effekt an Index `0` enthält.

Das folgende Beispiel erstellt eine Form mit Haupt‑ und Interaktiv‑Effekten, ermittelt die Effekte, die die Form anvisieren, und enumeriert anschließend jede Sequenz auf der Folie.

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

Wenn Sie nur die Effekte für eine einzelne Form benötigen, ermitteln Sie zunächst die Form anhand von Name, Platzhaltertyp oder einer anderen stabilen Eigenschaft; rufen Sie dann [Sequence.getEffectsByShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sequence/#getEffectsByShape) auf. Gehen Sie nicht davon aus, dass [ShapeCollection.get_Item](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/#get_Item) an Index `0` immer das gewünschte Objekt ist.

## **Arbeiten mit geerbten Platzhalter‑Effekten**

Ein Platzhalter auf einer normalen Folie kann das Animationsverhalten vom entsprechenden Platzhalter auf ihrer Layout‑ und Master‑Folie erben. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getBasePlaceholder) gibt diesen übergeordneten Platzhalter zurück oder `null`, wenn kein übergeordneter Platzhalter existiert.

Im folgenden Beispiel‑Präsentation hat die Fußzeile **Random Bars** auf der normalen Folie, **Split** auf der Layout‑Folie und **Fly In** auf der Master‑Folie.

![Fußzeilen‑Animationseffekt auf der normalen Folie](slide-shape-animation.png)

![Fußzeilen‑Platzhalter‑Animationseffekt auf der Layout‑Folie](layout-shape-animation.png)

![Fußzeilen‑Platzhalter‑Animationseffekt auf der Master‑Folie](master-shape-animation.png)

Das nächste Beispiel verwendet eine Platzhalter‑Hierarchie aus einer neuen Präsentation. Es fügt Effekte zu einem Master‑Platzhalter, einem Layout‑Platzhalter und dem entsprechenden Platzhalter auf einer normalen Folie hinzu. Jeder Aufruf von [Shape.getBasePlaceholder](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getBasePlaceholder) wird geprüft, bevor die zurückgegebene Form verwendet wird.

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

## **Animationszeit ändern**

Der PowerPoint‑**Timing**‑Dialog entspricht den Eigenschaften von [Timing](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/).

![PowerPoint‑Timing‑Dialog für einen Animationseffekt](shape-animation.png)

- **Start** entspricht [Timing.getTriggerType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#getTriggerType).
- **Dauer** entspricht [Timing.getDuration](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#getDuration) in Sekunden.
- **Verzögerung** entspricht [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) in Sekunden.
- **Wiederholung** entspricht [Timing.getRepeatCount](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) oder [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Zurückspulen nach dem Abspielen** entspricht [Timing.getRewind](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#getRewind).

Dieses unabhängige Beispiel fügt einen Effekt hinzu, ändert dessen Timing über das von [Sequence.addEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sequence/#addEffect) zurückgegebene Objekt und speichert das Ergebnis. Das Beibehalten der zurückgegebenen [Effect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effect/)‑Referenz vermeidet einen unnötigen Sammlungs‑Index.

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

Verwenden Sie bewusst nur einen Wiederholungsmodus. Die Kombination eines Wiederholungszählers mit einem „until“‑Flag kann in verschiedenen Betrachtern verwirrende Ergebnisse erzeugen. Beim Ändern von Wiederholungsmodi setzen Sie zuerst [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) und [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide), bevor Sie [Timing.setRepeatCount](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/timing/#setRepeatCount) aufrufen, da das Setzen eines der Flags ebenfalls den aktiven Wiederholungsmodus ändert.

## **Animationssounds hinzufügen und extrahieren**

Ein Animationseffekt kann über [Effect.getSound](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effect/#getSound) auf eingebettetes Audio verweisen. [Effect.setStopPreviousSound](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effect/#setStopPreviousSound) weist einen Effekt an, Audio zu stoppen, das von einem früheren Effekt gestartet wurde.

### **Einem Effekt einen Sound hinzufügen**

Das folgende Beispiel erwartet eine lokale Audiodatei mit dem Namen `animation-sound.wav`. Es erstellt zwei Effekte, bettet diese Datei als Sound für den ersten Effekt ein und konfiguriert den zweiten Effekt so, dass er den Sound stoppt. Es nutzt die von [Sequence.addEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sequence/#addEffect) zurückgegebenen Objekte, sodass kein Sequenz‑Index erforderlich ist.

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

### **Eingebettete Effekt‑Sounds extrahieren**

Das folgende Beispiel erwartet eine lokale Präsentation mit dem Namen `presentation-with-animation-sounds.pptx`. Es durchsucht sowohl Haupt‑ als auch Interaktiv‑Sequenzen und schreibt jeden eingebetteten Effekt‑Sound in das Verzeichnis `extracted-animation-sounds`. Die Dateierweiterung wird aus dem Audio‑MIME‑Typ ermittelt, der von [Audio.getContentType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audio/#getContentType) bereitgestellt wird.

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

Für große Audioobjekte verwenden Sie [Audio.getStream](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audio/#getStream) und kopieren den Stream in eine Datei, anstatt das gesamte Objekt in ein Byte‑Array zu laden.

## **Nach‑Animation‑Verhalten festlegen**

Die Option **After animation** steuert, was mit einer Form geschieht, nachdem ihr Effekt abgeschlossen ist.

![PowerPoint‑Effekt‑Optionen‑Dialog mit After‑Animation‑Einstellungen](shape-after-animation.png)

Die Aufzählung [AfterAnimationType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/afteranimationtype/) unterstützt das Belassen der Form unverändert, das Ändern ihrer Farbe, das Ausblenden nach der Animation oder das Ausblenden beim nächsten Klick. Wenn der Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/afteranimationtype/#Color) ist, setzen Sie zusätzlich [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effect/#getAfterAnimationColor).

Dieses unabhängige Beispiel erstellt einen Effekt, legt sein Nach‑Animation‑Verhalten über das zurückgegebene Effektobjekt fest und speichert das Ergebnis.

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

Das Ändern des Typs von [AfterAnimationType.Color](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/afteranimationtype/#Color) löscht die Einstellung für die Nach‑Animation‑Farbe.

## **Text animieren**

Textanimation hat zwei verwandte Einstellungen:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textanimation/#getBuildType) steuert, ob Absätze zusammen oder absatzweise angezeigt werden.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effect/#getAnimateTextType) steuert, ob der Text gleichzeitig, wortweise oder buchstabenweise erscheint. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) legt die Verzögerung zwischen Worten oder Buchstaben fest. Ein positiver Wert ist ein Prozentsatz der Effekt‑Dauer; ein negativer Wert ist eine Verzögerung in Sekunden.

Das folgende unabhängige Beispiel animiert die Wörter in einem Textfeld. [BuildType.AsOneObject](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/buildtype/#AsOneObject) deaktiviert das absatzweise Aufbauen, sodass die Wort‑Einstellung auf den gesamten Textrahmen angewendet wird.

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

Um ein Textfeld absatzweise aufzubauen, setzen Sie [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (oder ein anderes Absatz‑Level). Um einen einzelnen Absatz mit einem eigenen Effekt zu versehen, verwenden Sie die Überladung von [Sequence.addEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sequence/#addEffect), die ein [Paragraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/paragraph/) akzeptiert. Siehe [Animated Text](/slides/de/nodejs-java/animated-text/) für Beispiele auf Absatz‑Ebene.

## **Export‑ und Kompatibilitäts‑Hinweise**

- Das Speichern als PPT oder PPTX erhält das Animationsmodell, doch die endgültige Wiedergabe wird vom Präsentationsbetrachter gesteuert.
- PDF und statische Bilder spielen keine Animationen ab. Verwenden Sie [HTML5‑Export](/slides/de/nodejs-java/export-to-html5/), animierte GIFs oder [Video‑Konvertierung](/slides/de/nodejs-java/convert-powerpoint-to-video/), wenn die Ausgabe Bewegung zeigen muss.
- Für HTML5 aktivieren Sie [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/html5options/#setAnimateShapes) und bei Bedarf [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).
- Die Video‑Renderung unterstützt viele gängige Eingangs‑, Betonungs‑, Ausgangs‑ und Bewegungspfad‑Effekte, aber nicht jeder PowerPoint‑Effekt ist unterstützt. Prüfen Sie die aktuelle [unterstützte Animationen und Effekte](/slides/de/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) und testen Sie kritische Präsentationen mit Ihrer Ziel‑Aspose.Slides‑Version.
- Erweiterte benutzerdefinierte Effekte und aus anderen Präsentationsformaten importierte Effekte können in der Datei erhalten bleiben, werden jedoch in PowerPoint, HTML5 oder Video unterschiedlich gerendert. Validieren Sie das exportierte Ergebnis, anstatt sich ausschließlich auf den Effekt‑Namen zu verlassen.

## **FAQ**

**Warum wird eine Animation in PowerPoint angezeigt, aber nicht in einem PDF?**

PDF ist ein statisches Format, daher werden Animationen und Folienübergänge nicht abgespielt. Exportieren Sie zu HTML5, animiertem GIF oder Video, wenn Bewegung erhalten bleiben muss.

**Warum wird ein Effekt in einem Video anders wiedergegeben?**

Der Video‑Export rendert die Animationen, anstatt das ursprüngliche PowerPoint‑Verhalten zu speichern. Einige fortgeschrittene Effekte werden nicht unterstützt oder nur angenähert dargestellt. Prüfen Sie die Tabelle der unterstützten Effekte und testen Sie die tatsächliche Präsentation vor dem Produktionseinsatz.

**Ändert das Vor- oder Zurückschieben einer Form ihre Animationsreihenfolge?**

Nein. Die Z‑Reihenfolge einer Form bestimmt die Überlagerung, während die Sequenz‑Reihenfolge und die Auslöser die Animationswiedergabe steuern. Ändern Sie die Timeline, wenn Sie eine andere Wiedergabereihenfolge benötigen.