---
title: Alakzatanimációk alkalmazása prezentációkban JavaScript használatával
linktitle: Alakzatanimáció
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
description: "Ismerje meg, hogyan lehet hozzáadni, ellenőrizni és testre szabni az alakzatanimációkat, az időzítést, a hangokat, az animáció utáni viselkedést és az animált szöveget az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java a diavetítéseken a slide animációkat effektusokként jeleníti meg egy dia idővonalában. Egy effektusnak van célforma, animáció típusa és altípusa, egy trigger, időzítési beállítások, valamint opcionális tulajdonságai, mint például hang vagy az animáció utáni viselkedés.

Az idővonal kétféle sorozatot tartalmaz:

- A **fő sorozat** játszódik le, amikor a dia előrehalad.
- Egy **interaktív sorozat** akkor indul, amikor a hozzá tartozó trigger forma rákattintanak.

Mivel a szövegdobozok, képek, diagramok, táblázatok és egyéb diaobjektumok [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) objektumok, ugyanazt a [Sequence.addEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#addEffect) metódust használja a legtöbb diatartalomhoz. A rendelkezésre álló effektusok a [EffectType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effecttype/) felsorolásban találhatók.

## **Alakzatanimációk hozzáadása**

Az animáció hozzáadásához szerezze meg a dia fő sorozatát, és hívja meg a [Sequence.addEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#addEffect) metódust a célformával, az effektus típusával, altípusával és triggerrel. Olyan efektushoz, amely egy másik forma kattintásakor indul, hozzon létre egy interaktív sorozatot, amelynek triggerje ez a másik forma.

Az alábbi példa mindkét típusú animációt létrehozza, és a `shape-animations.pptx` fájlba menti az eredményt.

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

A trigger szabályozza, mikor indul egy effektus:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effecttriggertype/#OnClick) egy kattintásra vár a fő sorozatban, vagy a trigger forma kattintására egy interaktív sorozatban.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) az előző effektussal együtt indul.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) az előző effektus befejeződésekor indul.

Kép, diagram vagy más forma animálásához adja át azt az objektumot a [Sequence.addEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#addEffect) metódusnak a `targetShape` helyett. Diagram-specifikus csoportosítási lehetőségekért tekintse meg a [Animated Charts](/slides/hu/nodejs-java/animated-charts/) oldalt.

## **Alakzatanimációk olvasása**

Használja a [Sequence.getEffectsByShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#getEffectsByShape) metódust, ha ismeri a célformát. Minden effektus megtekintéséhez enumerálja a fő sorozatot és minden interaktív sorozatot. Az enumerálás megakadályozza, hogy feltételezze, egy sorozat tartalmaz effektust a `0` indexen.

Az alábbi példa egy formát hoz létre fő‑sorozati és interaktív effektusokkal, lekéri a formát célozó effektusokat, majd minden sorozatot enumerál a dián.

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

Ha csak egy forma effektusaira van szüksége, először azonosítsa a formát név, helyőrző típus vagy más stabil tulajdonság alapján; ezután hívja meg a [Sequence.getEffectsByShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#getEffectsByShape) metódust. Ne feltételezze, hogy a [ShapeCollection.get_Item](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/#get_Item) a `0` indexen mindig a kívánt objektum.

## **Örökölt helyőrző effektusok kezelése**

Egy normál dián lévő helyőrző örökölheti az animációs viselkedést a megfelelő helyőrzőtől a diaelrendezésen és a mesterdián. A [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getBasePlaceholder) visszaadja ezt a szülőhelyőrzőt, vagy `null`‑t, ha nincs szülő.

Az alábbi példaprezentációban a lábléc **Random Bars** effektust kap a normál dián, **Split**‑et az elrendezés dián, és **Fly In**‑t a mester dián.

![Lábléc animációs effektus a normál dián](slide-shape-animation.png)

![Lábléc helyőrző animációs effektus az elrendezés dián](layout-shape-animation.png)

![Lábléc helyőrző animációs effektus a mester dián](master-shape-animation.png)

A következő példa egy új prezentáció helyőrzőhierarchiáját használja. Effektusokat ad egy mester helyőrzőhöz, egy elrendezés helyőrzőhöz és a megfelelő helyőrzőhöz a normál dián. Minden meghívás előtt ellenőrzi a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getBasePlaceholder) visszatérési értékét.

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

A PowerPoint **Timing** párbeszédablaka a [Timing](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/) tulajdonságaira leképeződik.

![PowerPoint Időzítés párbeszédablak egy animációs effektushoz](shape-animation.png)

- **Indítás** a [Timing.getTriggerType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getTriggerType) értékre tér vissza.
- **Időtartam** a [Timing.getDuration](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getDuration) értékre tér vissza, másodpercben.
- **Késleltetés** a [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) értékre tér vissza, másodpercben.
- **Ismétlés** a [Timing.getRepeatCount](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) vagy [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) értékekre tér vissza.
- **Visszatekerés a lejátszás befejezése után** a [Timing.getRewind](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#getRewind) értékére tér vissza.

Ez a különálló példa hozzáad egy effektust, módosítja annak időzítését a [Sequence.addEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#addEffect) által visszaadott objektumon keresztül, majd elmenti az eredményt. A visszakapott [Effect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/) hivatkozás megtartása elkerüli a felesleges gyűjtemény index használatát.

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

Használjon egy ismétlési módot szándékosan. Egy ismétlésszám kombinálása egy „until” jelzővel zavaró eredményeket okozhat különböző megjelenítőkben. Ismétlési módok módosításakor állítsa be a [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) és a [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) értékeket a [Timing.setRepeatCount](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/timing/#setRepeatCount) előtt, mivel bármely jelző beállítása megváltoztatja az aktív ismétlési módot.

## **Animációs hangok hozzáadása és kinyerése**

Egy animációs effektus hivatkozhat beágyazott hangra a [Effect.getSound](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#getSound) segítségével. A [Effect.setStopPreviousSound](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#setStopPreviousSound) azt mondja az effektusnak, hogy állítsa le az előző effektus által indított hangot.

### **Effektushoz hang hozzáadása**

Az alábbi példa egy helyi `animation-sound.wav` hangfájlt vár. Két effektust hoz létre, az elsőhez beágyazza a fájlt hangként, a másodikat úgy konfigurálja, hogy leállítsa a hangot. A [Sequence.addEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#addEffect) által visszaadott objektumokat használja, így nincs szükség sorozat indexre.

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

Az alábbi példa egy helyi `presentation-with-animation-sounds.pptx` prezentációt vár. Mind a fő, mind az interaktív sorozatot átvizsgálja, és minden beágyazott effektushangot a `extracted-animation-sounds` könyvtárba ír. A kiterjesztés a [Audio.getContentType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audio/#getContentType) által visszaadott audio MIME típus alapján kerül kiválasztásra.

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

Nagy audio objektumok esetén használja a [Audio.getStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audio/#getStream) metódust, és másolja a streamet fájlba a teljes objektum byte‑tömbbe való betöltése helyett.

## **Az animáció utáni viselkedés beállítása**

A **After animation** opció szabályozza, mi történik a formával, miután az effektus befejeződik.

![PowerPoint Effektus beállítások párbeszédablak, az animáció utáni beállítások megjelenítése](shape-after-animation.png)

Az [AfterAnimationType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/afteranimationtype/) felsorolás támogatja a forma érintetlenül hagyását, a színének változtatását, az animáció után való elrejtését vagy a következő kattintásra történő elrejtését. Ha a típus [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/afteranimationtype/#Color), állítsa be a [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#getAfterAnimationColor) értéket is.

Ez a különálló példa létrehoz egy effektust, a visszakapott objektumon keresztül beállítja az animáció utáni viselkedést, majd elmenti az eredményt.

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

A típus [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/afteranimationtype/#Color)-ról való eltávolítása törli az animáció utáni színbeállítást.

## **Szöveg animálása**

A szöveganimációnak két kapcsolódó vezérlése van:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textanimation/#getBuildType) szabályozza, hogy a bekezdések együtt vagy bekezdésenként jelenjenek meg.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#getAnimateTextType) szabályozza, hogy a szöveg egyszerre, szóként vagy betűként jelenjen meg. A [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) a szavak vagy betűk közti késleltetést állítja be. A pozitív érték az effektus időtartamának százalékát jelenti; a negatív érték másodpercben megadott késleltetés.

Az alábbi különálló példa a szövegdoboz szavait animálja. A [BuildType.AsOneObject](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/buildtype/#AsOneObject) letiltja a bekezdés‑ről‑bekezdésre építést, így a szó beállítás a teljes szövegdobozra vonatkozik.

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

A szövegdoboz bekezdésenkénti építéséhez állítsa be a [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (vagy egy másik bekezdés‑szintet). Egyetlen bekezdés önálló effektussal történő célzásához használja a [Sequence.addEffect](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sequence/#addEffect) túlterhelt változatát, amely egy [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) paramétert fogad. Lásd a [Animated Text](/slides/hu/nodejs-java/animated-text/) oldalt bekezdés‑szintű példákért.

## **Exportálási és kompatibilitási megjegyzések**

- A PPT vagy PPTX formátumba mentés megőrzi az animációs modellt, de a végső lejátszást a prezentációs megjelenítő irányítja.
- A PDF és a statikus képek nem játszanak le animációkat. Használjon [HTML5 export](/slides/hu/nodejs-java/export-to-html5/), animált GIF‑et vagy [videó konverziót](/slides/hu/nodejs-java/convert-powerpoint-to-video/)‑t, ha a kimenetnek mozgást kell mutatnia.
- HTML5 esetén engedélyezze a [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/html5options/#setAnimateShapes) és szükség esetén a [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/html5options/#setAnimateTransitions) beállítását.
- A videó renderelés számos gyakori belépő, hangsúly, kilépő és mozgáspálya effektust támogat, de nem minden PowerPoint effektus támogatott. Ellenőrizze a jelenlegi [supported animations and effects](/slides/hu/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) oldalt, és tesztelje a kritikus prezentációkat a cél Aspose.Slides verzióval.
- A fejlett egyedi effektusok és más prezentációs formátumokból importált effektusok megmaradhatnak a fájlban, de eltérően jelenhetnek meg PowerPointban, HTML5‑ben vagy videóban. Ellenőrizze az exportált eredményt, ne csak az effektus nevére támaszkodjon.

## **GYIK**

**Miért jelenik meg egy animáció a PowerPointban, de nem a PDF‑ben?**

A PDF egy statikus formátum, ezért az animációk és diaátmenetek nem játszanak le. Exportáljon HTML5‑re, animált GIF‑re vagy videóra, ha a mozgást meg kell őrizni.

**Miért játszódik le egy effektus másképp a videóban?**

A videó exportálás az animációkat rendereli, nem tárolja az eredeti PowerPoint viselkedést. Néhány fejlett effektus nem támogatott vagy csak közelítőleg jelenik meg. Tekintse meg a támogatott‑effektusok táblázatát, és tesztelje a prezentációt a tényleges felhasználás előtt.

**Megváltoztatja-e egy forma előre vagy hátra helyezése az animáció sorrendjét?**

Nem. A forma Z‑rendje a átfedést szabályozza, míözben a sorozat sorrendje és a triggerek az animáció lejátszását irányítják. Módosítsa az idővonalat, ha más lejátszási sorrendre van szüksége.