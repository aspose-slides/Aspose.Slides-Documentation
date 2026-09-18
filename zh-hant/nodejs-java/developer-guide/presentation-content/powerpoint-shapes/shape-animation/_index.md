---
title: 在簡報中使用 JavaScript 套用形狀動畫
linktitle: 形狀動畫
type: docs
weight: 60
url: /zh-hant/nodejs-java/shape-animation/
keywords:
- 形狀
- 動畫
- 效果
- 動畫形狀
- 動畫文字
- 新增動畫
- 取得動畫
- 擷取動畫
- 新增效果
- 取得效果
- 擷取效果
- 效果音效
- 套用動畫
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 新增、檢查並自訂形狀動畫、時間設定、音效、動畫結束後的行為，以及動畫文字。"
---
## **概述**

若要處理效果內的各項行為或編輯運動路徑段，請參閱[自訂動畫](/slides/zh-hant/nodejs-java/custom-animation/)。

Aspose.Slides for Node.js via Java 將投影片動畫表示為投影片時間軸中的效果。每個效果都有目標形狀、動畫類型與子類型、觸發條件、時間設定，以及可選屬性（例如音效或動畫結束後的行為）。

時間軸包含兩種序列：

- **主序列** 隨投影片前進時播放。
- **互動序列** 於觸發形狀被點擊時開始。

由於文字方塊、圖片、圖表、表格以及其他投影片物件皆為 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 物件，您可以對大多數投影片內容使用相同的 [Sequence.addEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sequence/#addEffect) 方法。可用的效果列於 [EffectType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effecttype/) 列舉中。

## **新增形狀動畫**

若要新增動畫，先取得投影片的主序列，並以目標形狀、效果類型、子類型與觸發條件呼叫 [Sequence.addEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sequence/#addEffect)。若要在點擊其他形狀時開始的效果，請建立一個觸發形狀為該其他形狀的互動序列。

以下範例會建立兩種動畫，並將結果儲存為 `shape-animations.pptx`。

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

觸發條件決定效果何時開始：

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effecttriggertype/#OnClick) 於主序列中等待點擊，或於互動序列中等待於觸發形狀的點擊。
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) 與前一個效果同時開始。
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) 在前一個效果結束後開始。

若要對圖片、圖表或其他形狀類型動畫，請將該物件傳給 [Sequence.addEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sequence/#addEffect) 以取代 `targetShape`。針對圖表的分組選項，請參閱[動畫圖表](/slides/zh-hant/nodejs-java/animated-charts/)。

## **讀取形狀動畫**

當已知目標形狀時，使用 [Sequence.getEffectsByShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sequence/#getEffectsByShape)。若要檢查每個效果，請列舉主序列與所有互動序列。列舉可避免假設序列在索引 `0` 處一定有效果。

以下範例會建立具有主序列與互動效果的形狀，取得針對該形狀的效果，然後列舉投影片上的每個序列。

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

如果只需要單一形狀的效果，請先依名稱、占位符類型或其他穩定屬性識別該形狀；然後呼叫 [Sequence.getEffectsByShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sequence/#getEffectsByShape)。不要假設索引 `0` 處的 [ShapeCollection.get_Item](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/#get_Item) 永遠是目標物件。

## **處理繼承的占位符效果**

普通投影片上的占位符可以繼承其版面投影片與母片投影片上對應占位符的動畫行為。[Shape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getBasePlaceholder) 會傳回該父占位符，若不存在則回傳 `null`。

在以下範例簡報中，頁腳在普通投影片上為 **Random Bars**、在版面投影片上為 **Split**，在母片投影片上為 **Fly In**。

![普通投影片上的頁腳動畫效果](slide-shape-animation.png)

![版面投影片上的頁腳占位符動畫效果](layout-shape-animation.png)

![母片投影片上的頁腳占位符動畫效果](master-shape-animation.png)

下一個範例使用新簡報中的占位符層級結構。它會對母片占位符、版面占位符以及普通投影片上的相應占位符加入效果。在使用傳回的形狀之前，皆會檢查對 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getBasePlaceholder) 的呼叫結果。

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

## **變更動畫時間設定**

PowerPoint 的 **Timing** 對話方塊對應到 [Timing](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/timing/) 的屬性。

![動畫效果的 PowerPoint 計時對話方塊](shape-animation.png)

- **開始** 對應到 [Timing.getTriggerType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/timing/#getTriggerType)。
- **持續時間** 對應到 [Timing.getDuration](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/timing/#getDuration)（以秒為單位）。
- **延遲** 對應到 [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)（以秒為單位）。
- **重複** 對應到 [Timing.getRepeatCount](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/timing/#getRepeatCount)、[Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) 或 [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide)。
- **播放完畢後倒轉** 對應到 [Timing.getRewind](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/timing/#getRewind)。

此獨立範例會加入一個效果，透過 [Sequence.addEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sequence/#addEffect) 回傳的物件變更其時間設定，並儲存結果。保留回傳的 [Effect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effect/) 參考可避免不必要的集合索引。

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

請刻意僅使用一種重複模式。將重複計數與「直到」旗標結合可能在不同的檢視器中產生混淆結果。變更重複模式時，先設定 [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) 與 [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide)，再呼叫 [Timing.setRepeatCount](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/timing/#setRepeatCount)，因為設定任一旗標也會改變目前的重複模式。

## **新增與擷取動畫音效**

動畫效果可以透過 [Effect.getSound](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effect/#getSound) 參考嵌入的音訊。[Effect.setStopPreviousSound](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effect/#setStopPreviousSound) 會指示效果停止先前效果所啟動的音訊。

### **為效果新增音效**

以下範例需要本機名為 `animation-sound.wav` 的音訊檔案。它會建立兩個效果，將該檔案嵌入為第一個效果的音效，並設定第二個效果停止音效。它使用 [Sequence.addEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sequence/#addEffect) 回傳的物件，因此不需要序列索引。

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

### **擷取嵌入的效果音效**

以下範例需要本機名為 `presentation-with-animation-sounds.pptx` 的簡報。它會掃描主序列與互動序列，並將每個嵌入的效果音效寫入 `extracted-animation-sounds` 目錄。副檔名會根據 [Audio.getContentType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audio/#getContentType) 所揭示的音訊 MIME 類型選取。

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

對於大型音訊物件，請使用 [Audio.getStream](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audio/#getStream) 並將串流複製到檔案，而非將整個物件載入至位元組陣列中。

## **設定動畫結束後的行為**

**After animation** 選項控制形狀在效果結束後的處理方式。

![PowerPoint 效果選項對話方塊顯示「After animation」設定](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/afteranimationtype/) 列舉支援保持形狀不變、變更其顏色、在動畫後隱藏，或在下一次點擊時隱藏。當類型為 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/afteranimationtype/#Color) 時，亦需設定 [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effect/#getAfterAnimationColor)。

此獨立範例會建立一個效果，透過回傳的效果物件設定其動畫結束後的行為，並儲存結果。

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

將類型改為非 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/afteranimationtype/#Color) 會清除動畫結束後的顏色設定。

## **文字動畫**

文字動畫有兩個相關的控制項：

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textanimation/#getBuildType) 控制段落是同時顯示還是逐段落顯示。
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effect/#getAnimateTextType) 控制文字是一次顯示、逐字或逐字母顯示。[Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) 設定字或字母之間的延遲。正值表示效果持續時間的百分比，負值則表示以秒為單位的延遲。

以下獨立範例會對文字方塊中的文字逐字動畫。[BuildType.AsOneObject](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/buildtype/#AsOneObject) 會停用逐段落建構，使字詞設定套用於整個文字框。

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

若要逐段落建構文字方塊，請設定 [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1)（或其他段落層級）。若要針對單一段落套用其專屬效果，請使用接受 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/) 的 [Sequence.addEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sequence/#addEffect) 重載。請參閱[動畫文字](/slides/zh-hant/nodejs-java/animated-text/) 取得段落層級範例。

## **匯出與相容性說明**

- 儲存為 PPT 或 PPTX 會保留動畫模型，但最終播放由簡報檢視器控制。
- PDF 與靜態影像不會播放動畫。若輸出必須顯示動作，請使用[HTML5 匯出](/slides/zh-hant/nodejs-java/export-to-html5/)、動畫 GIF，或[影片轉換](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/)。
- 對於 HTML5，請啟用 [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/html5options/#setAnimateShapes)，必要時亦啟用 [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/html5options/#setAnimateTransitions)。
- 影片轉譯支援許多常見的進入、強調、退出與運動路徑效果，但並非所有 PowerPoint 效果皆受支援。請檢查目前的[支援動畫與效果](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects)，並使用目標 Aspose.Slides 版本測試關鍵簡報。
- 進階自訂效果以及從其他簡報格式匯入的效果可能會保留於檔案中，但在 PowerPoint、HTML5 或影片中呈現方式可能不同。請驗證匯出結果，而非僅依賴效果名稱。

## **常見問題**

**為何動畫在 PowerPoint 中會顯示，但在 PDF 中不會顯示？**

PDF 為靜態格式，故不會播放動畫與投影片切換。若必須保留動作，請匯出為 HTML5、動畫 GIF 或影片。

**為何效果在影片中播放會不同？**

影片匯出會渲染動畫，而非儲存原始 PowerPoint 行為。某些進階效果不受支援或會被近似。請檢視支援效果表，並在正式使用前測試實際簡報。

**將形狀前移或後移會改變其動畫順序嗎？**

不會。形狀的 Z 軸順序僅控制重疊，序列順序與觸發條件才決定動畫播放。若需要不同的播放順序，請調整時間軸。