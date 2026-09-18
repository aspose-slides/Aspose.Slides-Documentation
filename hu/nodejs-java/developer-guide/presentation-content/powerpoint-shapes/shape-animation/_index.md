---
title: Alakzatanimációk alkalmazása prezentációkban JavaScript használatával
linktitle: Alakzat animáció
type: docs
weight: 60
url: /hu/nodejs-java/shape-animation/
keywords:
- alakzat
- animáció
- effektus
- animált alakzat
- animált szöveg
- animáció hozzáadása
- animáció lekérése
- animáció kinyerése
- effektus hozzáadása
- effektus lekérése
- effektus kinyerése
- effektus hang
- animáció alkalmazása
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Tanulja meg, hogyan adhat hozzá, vizsgálhat és testreszabhat alakzatanimációkat, időzítést, hangokat, az animáció utáni viselkedést és animált szöveget az Aspose.Slides for Node.js Java segítségével."
---
## **Áttekintés**

Az effektusokon belüli egyedi viselkedések kezeléséhez vagy a mozgásút-szegmensek szerkesztéséhez lásd a [Custom Animation](/slides/hu/nodejs-java/custom-animation/) oldalt.

Az Aspose.Slides for Node.js via Java a diavetítéseket animációs effektusokként jeleníti meg a diák idővonalán. Egy effektus rendelkezik célobjektummal, animáció típusával és altípusával, aktiválóval, időzítési beállításokkal, valamint opcionális tulajdonságokkal, például hanggal vagy az animáció utáni viselkedéssel.

Az idővonal kétféle szekvenciát tartalmaz:

- A **main sequence** a dia előrehaladtával játszódik le.
- Egy **interactive sequence** akkor indul, amikor a hozzá tartozó aktiváló alakzatot rákattintják.

Mivel a szövegdobozok, képek, diagramok, táblázatok és egyéb diaelemek [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) objektumok, ezért a legtöbb dia tartalomhoz ugyanazt a [Sequence.addEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#addEffect) metódust használjuk. A rendelkezésre álló effektusok a [EffectType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effecttype/) felsorolásban találhatók.

## **Alakzatanimációk hozzáadása**

Animáció hozzáadásához szerezze be a dia fő szekvenciáját, és hívja meg a [Sequence.addEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#addEffect) metódust a célalakzattal, effektustípussal, altípussal és aktiválóval. Ha egy effektusnak egy másik alakzat kattintásakor kell elindulnia, hozzon létre egy interaktív szekvenciát, amelynek aktiválója ez a másik alakzat.

Az alábbi példában mindkét típusú animációt létrehozzuk, és az eredményt a `shape-animations.pptx` fájlba mentjük.

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

Az aktiváló szabályozza, hogy mikor indul egy effektus:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effecttriggertype/#OnClick) a fő szekvenciában egy kattintásra, vagy egy interaktív szekvenciában a aktiváló alakzatra vár.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) az előző effektussal együtt indul.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) az előző effektus befejeződésekor kezdődik.

Kép, diagram vagy más alakzat animálásához adja át azt az objektumot a [Sequence.addEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#addEffect) metódusnak a `targetShape` helyett. Diagram-specifikus csoportosítási lehetőségekért lásd az [Animated Charts](/slides/hu/nodejs-java/animated-charts/) oldalt.

## **Alakzatanimációk olvasása**

Ha ismeri a célalakzatot, használja a [Sequence.getEffectsByShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#getEffectsByShape) metódust. Minden effektus megtekintéséhez sorolja fel a fő szekvenciát és minden interaktív szekvenciát. Az enumerálás elkerüli azt a feltételezést, hogy egy szekvenciában index `0`‑nál szerepel egy effektus.

Az alábbi példában egy alakzatot hozunk létre fő szekvenciás és interaktív effektusokkal, lekérjük az alakzatra irányuló effektusokat, majd felsoroljuk a dia összes szekvenciáját.

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

Ha csak egy alakzatra van szüksége, először azonosítsa az alakzatot név, helykitöltő típusa vagy más stabil tulajdonság alapján; majd hívja meg a [Sequence.getEffectsByShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#getEffectsByShape) metódust. Ne feltételezze, hogy a [ShapeCollection.get_Item](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/#get_Item) a `0`‑s indexen mindig a kívánt objektum.

## **Az örökölt helykitöltő effektusok használata**

Egy szokásos dián lévő helykitöltő örökölheti az animációs viselkedést a hozzá tartozó helykitöltőből az elrendezés diákról és a mester diáról. A [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getBasePlaceholder) visszaadja azt a szülőhelykitöltőt, vagy `null`‑t, ha nincs szülő.

Az alábbi példaprezentációban a lábléc **Random Bars** animációt tartalmaz a szokásos dián, **Split**‑et az elrendezés dián, és **Fly In**‑t a mester dián.

![Lábléc animációs effektus a szokásos dián](slide-shape-animation.png)

![Lábléc helykitöltő animációs effektus az elrendezés dián](layout-shape-animation.png)

![Lábléc helykitöltő animációs effektus a mester dián](master-shape-animation.png)

A következő példa egy új prezentáció helykitöltő hierarchiáját használja. Effektusokat ad egy mester helykitöltőhöz, egy elrendezés helykitöltőhöz és a megfelelő helykitöltőhöz a szokásos dián. Minden [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getBasePlaceholder) hívás előtt ellenőrzik a visszakapott alakzatot.

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

## **Animáció időzítésének módosítása**

A PowerPoint **Timing** párbeszédablaka a [Timing](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/) tulajdonságaira térképeződik.

![PowerPoint Időzítés párbeszédablaka egy animációs effektushoz](shape-animation.png)

- **Start** a [Timing.getTriggerType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getTriggerType) metódusra térképeződik.
- **Duration** a [Timing.getDuration](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getDuration) metódusra térképeződik, másodpercben.
- **Delay** a [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) metódusra térképeződik, másodpercben.
- **Repeat** a [Timing.getRepeatCount](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) vagy [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) metódusokra térképeződik.
- **Rewind when done playing** a [Timing.getRewind](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getRewind) metódusra térképeződik.

Ez a független példa egy effektust ad hozzá, a [Sequence.addEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#addEffect) által visszaadott objektumon keresztül megváltoztatja annak időzítését, majd menti az eredményt. A visszakapott [Effect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/) hivatkozás megtartása elkerüli a felesleges gyűjtemény indexelést.

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

Használjon szándékosan egy ismétlési módot. Az ismétlési szám és egy "until" jelző kombinálása zavaró eredményeket okozhat különböző megjelenítőkben. Ismétlési módok módosításakor először állítsa be a [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) és a [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) metódusokat, majd a [Timing.setRepeatCount](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#setRepeatCount)‑t, mivel bármely jelző beállítása is módosítja az aktív ismétlési módot.

## **Animációs hangok hozzáadása és kinyerése**

Egy animációs effektus beágyazott hangot hivatkozhat a [Effect.getSound](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#getSound) segítségével. A [Effect.setStopPreviousSound](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#setStopPreviousSound) megmondja az effektusnak, hogy állítsa le a korábbi effektus által elindított hangot.

### **Hang hozzáadása egy effektushoz**

Az alábbi példában egy helyi `animation-sound.wav` nevű hangfájlra van szükség. Két effektust hoz létre, az első effektus hangjaként beágyazza ezt a fájlt, a második effektust úgy állítja be, hogy leállítsa a hangot. A [Sequence.addEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#addEffect) által visszaadott objektumokat használja, így nincs szükség szekvencia indexre.

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

### **Beágyazott effektus hangok kinyerése**

Az alábbi példában egy helyi `presentation-with-animation-sounds.pptx` nevű prezentációra van szükség. A fő és interaktív szekvenciákat átvizsgálja, és minden beágyazott effektus hangot a `extracted-animation-sounds` könyvtárba ír. A kiterjesztést a [Audio.getContentType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audio/#getContentType) által megadott audio MIME típus alapján választja.

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

Nagy audio objektumok esetén használja a [Audio.getStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audio/#getStream) metódust, és másolja a streamet fájlba ahelyett, hogy az egész objektumot byte tömbbe töltené.

## **Az animáció utáni viselkedés beállítása**

A **After animation** opció szabályozza, mi történik egy alakzattal az effektus befejezése után.

![PowerPoint Effektus beállítások párbeszédablaka az After animation beállításokkal](shape-after-animation.png)

A [AfterAnimationType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/afteranimationtype/) felsorolás támogatja, hogy az alakzat változatlan maradjon, megváltoztassa a színét, a animáció után elrejtse, vagy a következő kattintáskor rejtse el. Ha a típus [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/afteranimationtype/#Color), akkor állítsa be a [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#getAfterAnimationColor) értéket is.

Ez a független példa egy effektust hoz létre, a visszaadott effektus objektumon keresztül beállítja annak animáció utáni viselkedését, majd menti az eredményt.

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

A [AfterAnimationType.Color] típusról eltérés törli az animáció utáni színbeállítást.

## **Szöveg animálása**

A szöveg animáció két kapcsolódó beállítással rendelkezik:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textanimation/#getBuildType) szabályozza, hogy a bekezdések egyszerre vagy bekezdésenként jelenjenek meg.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#getAnimateTextType) szabályozza, hogy a szöveg egyszerre, szó szerint vagy betű szerint jelenik meg. A [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) beállítja a szavak vagy betűk közti késleltetést. A pozitív érték a effektus időtartamának százaléka; a negatív érték másodpercben megadott késleltetés.

Az alábbi független példa a szövegdoboz szavait animálja. A [BuildType.AsOneObject](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/buildtype/#AsOneObject) letiltja a bekezdésenkénti építést, így a szó beállítás az egész szövegkeretre vonatkozik.

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

A szövegdoboz bekezdésenkénti felépítéséhez állítsa be a [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (vagy más bekezdés szint). Egyetlen bekezdés saját effektushoz való célzásához használja a [Sequence.addEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#addEffect) olyan overload-ját, amely [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) típusú paramétert fogad. Példákért lásd az [Animated Text](/slides/hu/nodejs-java/animated-text/) oldalt.

## **Exportálási és kompatibilitási megjegyzések**

- A PPT vagy PPTX formátumba mentés megőrzi az animációs modellt, de a végső lejátszást a prezentációs megjelenítő irányítja.
- A PDF és a statikus képek nem játszanak le animációkat. Használja a [HTML5 export](/slides/hu/nodejs-java/export-to-html5/), animált GIF vagy [videó konverzió](/slides/hu/nodejs-java/convert-powerpoint-to-video/) opciót, ha a kimenet mozgást kell mutasson.
- HTML5 esetén engedélyezze a [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/html5options/#setAnimateShapes) beállítást, és szükség esetén a [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/html5options/#setAnimateTransitions)‑t.
- A videó renderelés számos gyakori belépési, hangsúlyozási, kilépési és mozgásút effektust támogat, de nem minden PowerPoint efektus van támogatva. Ellenőrizze a jelenlegi [supported animations and effects](/slides/hu/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) oldalt, és tesztelje a kritikus prezentációkat a cél Aspose.Slides verzióval.
- A fejlett egyedi effektusok és más prezentációs formátumokból importált effektusok megmaradhatnak a fájlban, de a PowerPoint, HTML5 vagy videó esetén másként jelenhetnek meg. Ellenőrizze az exportált eredményt, ne csak az effektus nevére hagyatkozzon.

## **GYIK**

**Miért jelenik meg egy animáció a PowerPointban, de nem a PDF‑ben?**

A PDF statikus formátum, ezért az animációk és diaátmenetek nem játszhatók le. Exportáljon HTML5‑re, animált GIF‑re vagy videóra, ha a mozgást meg kell őrizni.

**Miért játszódik le egy effektus másként a videóban?**

A videó export animációkat renderel, nem az eredeti PowerPoint viselkedést tárolja. Egyes fejlett effektusok nem támogatottak vagy csak közelítőek. Tekintse át a támogatott effektusok táblázatát, és tesztelje a tényleges prezentációt a termelés előtt.

**Megtöri egy alakzat előre vagy hátra helyezése az animáció sorrendjét?**

Nem. Az alakzat z‑rendje az átfedést szabályozza, míint a szekvencia sorrend és az aktiválók szabályozzák az animáció lejátszását. Ha más lejátszási sorrendre van szüksége, módosítsa az idővonalat.