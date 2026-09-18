---
title: Použití animací tvarů v prezentacích pomocí JavaScriptu
linktitle: Animace tvaru
type: docs
weight: 60
url: /cs/nodejs-java/shape-animation/
keywords:
- tvar
- animace
- efekt
- animovaný tvar
- animovaný text
- přidat animaci
- získat animaci
- extrahovat animaci
- přidat efekt
- získat efekt
- extrahovat efekt
- zvuk efektu
- aplikovat animaci
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak přidávat, kontrolovat a přizpůsobovat animace tvarů, časování, zvuky, chování po animaci a animovaný text pomocí Aspose.Slides pro Node.js přes Java."
---
## **Přehled**

Chcete-li pracovat s jednotlivými chováními uvnitř efektu nebo upravovat segmenty dráhy pohybu, podívejte se na [Vlastní animaci](/slides/cs/nodejs-java/custom-animation/).

Aspose.Slides pro Node.js prostřednictvím Java představuje animace snímků jako efekty v časové ose snímku. Efekt má cílový tvar, typ a podtyp animace, spouštěč, nastavení časování a volitelné vlastnosti, jako je zvuk nebo chování po animaci.

Časová osa obsahuje dva typy sekvencí:

- **hlavní sekvence** se přehrává, když snímek postupuje.
- **interaktivní sekvence** se spustí, když je kliknuto na její spouštěcí tvar.

Protože textová pole, obrázky, grafy, tabulky a další objekty snímku jsou objekty [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/) , používáte stejnou metodu [Sequence.addEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sequence/#addEffect) pro většinu obsahu snímku. Dostupné efekty jsou uvedeny v výčtu [EffectType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effecttype/).

## **Přidání animací tvarů**

Chcete-li přidat animaci, získejte hlavní sekvenci snímku a zavolejte [Sequence.addEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sequence/#addEffect) s cílovým tvarem, typem efektu, podtypem a spouštěčem. Pro efekt, který se spustí po kliknutí na jiný tvar, vytvořte interaktivní sekvenci, jejíž spouštěčem je ten jiný tvar.

Následující příklad vytvoří oba typy animací a výsledek uloží do `shape-animations.pptx`.

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

Spouštěč řídí, kdy efekt začne:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effecttriggertype/#OnClick) čeká na kliknutí v hlavní sekvenci nebo na kliknutí na spouštěcí tvar v interaktivní sekvenci.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) začne spolu s předchozím efektem.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) začne po dokončení předchozího efektu.

Chcete-li animovat obrázek, graf nebo jiný typ tvaru, předávejte tento objekt metodě [Sequence.addEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sequence/#addEffect) místo `targetShape`. Pro možnosti seskupování specifické pro grafy viz [Animated Charts](/slides/cs/nodejs-java/animated-charts/).

## **Čtení animací tvarů**

Použijte [Sequence.getEffectsByShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sequence/#getEffectsByShape), když znáte cílový tvar. Chcete‑li prozkoumat každý efekt, enumerujte hlavní sekvenci i všechny interaktivní sekvence. Enumerace zabraňuje předpokladu, že sekvence obsahuje efekt na indexu `0`.

Následující příklad vytvoří tvar s hlavními a interaktivními efekty, získá efekty, které cílí na tvar, a poté enumeruje každou sekvenci na snímku.

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

Pokud potřebujete efekty jen pro jeden tvar, nejprve identifikujte tvar podle názvu, typu zástupného znaku nebo jiné stabilní vlastnosti; pak zavolejte [Sequence.getEffectsByShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sequence/#getEffectsByShape). Nepředpokládejte, že [ShapeCollection.get_Item](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/#get_Item) na indexu `0` je vždy zamýšlený objekt.

## **Práce s děděnými efekty zástupných znaků**

Zástupný znak na normálním snímku může dědit chování animace ze odpovídajícího zástupného znaku na rozvržení snímku a hlavním snímku. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getBasePlaceholder) vrací tento nadřazený zástupný znak nebo `null`, pokud žádný nadřazený neexistuje.

V následující ukázkové prezentaci má zápatí **Random Bars** na normálním snímku, **Split** na snímku rozvržení a **Fly In** na hlavním snímku.

![Animace zápatí na normálním snímku](slide-shape-animation.png)

![Animace zástupného znaku zápatí na rozvržení snímku](layout-shape-animation.png)

![Animace zástupného znaku zápatí na hlavním snímku](master-shape-animation.png)

Další příklad používá hierarchii zástupných znaků z nové prezentace. Přidává efekty k hlavnímu zástupnému znaku, zástupnému znaku rozvržení a odpovídajícímu zástupnému znaku na normálním snímku. Každé volání [Shape.getBasePlaceholder](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getBasePlaceholder) je zkontrolováno před použitím vráceného tvaru.

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

## **Změna časování animace**

Dialog **Timing** v PowerPointu mapuje na vlastnosti [Timing](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/).

![Dialog Časování v PowerPointu pro animační efekt](shape-animation.png)

- **Start** mapuje na [Timing.getTriggerType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#getTriggerType).
- **Duration** mapuje na [Timing.getDuration](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#getDuration) v sekundách.
- **Delay** mapuje na [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) v sekundách.
- **Repeat** mapuje na [Timing.getRepeatCount](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) nebo [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** mapuje na [Timing.getRewind](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#getRewind).

Tento samostatný příklad přidá efekt, změní jeho časování pomocí objektu vráceného metodou [Sequence.addEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sequence/#addEffect) a výsledek uloží. Uložení reference na vrácený [Effect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/) zabraňuje zbytečnému indexování kolekce.

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

Používejte jediný režim opakování úmyslně. Kombinace počtu opakování s příznakem „until“ může v různých přehrávačích způsobit matoucí výsledky. Při změně režimů opakování nastavte [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) a [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) před [Timing.setRepeatCount](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/timing/#setRepeatCount), protože nastavení kterékoli z těchto příznaků také mění aktivní režim opakování.

## **Přidání a extrakce zvuků animace**

Animovaný efekt může odkazovat na vložený zvuk pomocí [Effect.getSound](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#setStopPreviousSound) říká efektu, aby zastavil zvuk zahájený předchozím efektem.

### **Přidat zvuk k efektu**

Následující příklad očekává lokální zvukový soubor pojmenovaný `animation-sound.wav`. Vytvoří dva efekty, vloží tento soubor jako zvuk pro první efekt a nastaví druhý efekt tak, aby zvuk zastavil. Využívá objekty vrácené metodou [Sequence.addEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sequence/#addEffect), takže není vyžadován index sekvence.

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

### **Extrahovat vložené zvuky efektů**

Následující příklad očekává lokální prezentaci pojmenovanou `presentation-with-animation-sounds.pptx`. Prohledá hlavní i interaktivní sekvence a zapíše každý vložený zvuk efektu do adresáře `extracted-animation-sounds`. Přípona je vybrána z MIME typu zvuku vráceného metodou [Audio.getContentType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audio/#getContentType).

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

U velkých zvukových objektů použijte [Audio.getStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audio/#getStream) a zkopírujte proud do souboru místo načítání celého objektu do pole bajtů.

## **Nastavení chování po animaci**

Možnost **After animation** určuje, co se stane s tvarem po dokončení jeho efektu.

![Dialog možností efektu PowerPointu zobrazující nastavení Po animaci](shape-after-animation.png)

Výčet [AfterAnimationType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/afteranimationtype/) podporuje ponechání tvaru beze změny, změnu jeho barvy, skrytí po animaci nebo skrytí při dalším kliknutí. Když je typ [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/afteranimationtype/#Color), nastavte také [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#getAfterAnimationColor).

Tento samostatný příklad vytvoří efekt, nastaví jeho chování po animaci pomocí vráceného objektu efektu a výsledek uloží.

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

Změna typu od [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/afteranimationtype/#Color) vymaže nastavení barvy po animaci.

## **Animovat text**

Animace textu má dva související ovladače:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textanimation/#getBuildType) určuje, zda se odstavce zobrazují najednou nebo po úrovních odstavců.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#getAnimateTextType) určuje, zda se text zobrazí najednou, po slovech nebo po písmenech. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) nastavuje zpoždění mezi slovy nebo písmeny. Kladná hodnota je procento trvání efektu; záporná hodnota je zpoždění v sekundách.

Následující samostatný příklad animuje slova v textovém poli. [BuildType.AsOneObject](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/buildtype/#AsOneObject) zakáže budování po odstavcích, takže se nastavení slov použije na celý textový rámec.

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

Pro budování textového pole po odstavcích nastavte [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (nebo jinou úroveň odstavce). Chcete‑li cílit na jeden odstavec s vlastním efektem, použijte přetížení [Sequence.addEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sequence/#addEffect), které přijímá [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/). Viz [Animated Text](/slides/cs/nodejs-java/animated-text/) pro příklady na úrovni odstavců.

## **Export a poznámky o kompatibilitě**

- Ukládání do PPT nebo PPTX zachovává model animací, ale finální přehrávání řídí prohlížeč prezentace.
- PDF a statické obrázky animace nepřehrávají. Použijte [HTML5 export](/slides/cs/nodejs-java/export-to-html5/), animovaný GIF nebo [video konverzi](/slides/cs/nodejs-java/convert-powerpoint-to-video/), když výstup musí zobrazovat pohyb.
- Pro HTML5 povolte [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/html5options/#setAnimateShapes) a podle potřeby [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).
- Video rendering podporuje mnoho běžných vstupních, zdůrazňovacích, odchozích a dráhových efektů, ale ne každý efekt PowerPointu je podporován. Zkontrolujte aktuální [supported animations and effects](/slides/cs/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) a otestujte kritické prezentace s verzí Aspose.Slides, kterou používáte.
- Pokročilé vlastní efekty a efekty importované z jiných formátů prezentací mohou být v souboru zachovány, ale vykreslí se odlišně v PowerPointu, HTML5 nebo videu. Ověřte exportovaný výsledek místo spoléhání se jen na název efektu.

## **FAQ**

**Proč se animace zobrazuje v PowerPointu, ale ne v PDF?**

PDF je statický formát, takže animace a přechody snímků se nepřehrávají. Exportujte do HTML5, animovaného GIFu nebo videa, když je potřeba zachovat pohyb.

**Proč se efekt přehrává jinak ve videu?**

Export do videa renderuje animace místo uložení původního chování PowerPointu. Některé pokročilé efekty nejsou podporovány nebo jsou aproximovány. Prostudujte tabulku podporovaných efektů a otestujte skutečnou prezentaci před produkčním nasazením.

**Mění přesunutí tvaru dopředu nebo dozadu pořadí jeho animace?**

Ne. Z‑order tvaru určuje překrytí, zatímco pořadí sekvence a spouštěče řídí přehrávání animací. Změňte časovou osu, pokud potřebujete jiný pořádek přehrávání.