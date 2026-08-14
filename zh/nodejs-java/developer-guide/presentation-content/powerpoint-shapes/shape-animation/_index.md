---
title: 在演示文稿中使用 JavaScript 应用形状动画
linktitle: 形状动画
type: docs
weight: 60
url: /zh/nodejs-java/shape-animation/
keywords:
- 形状
- 动画
- 效果
- 动画形状
- 动画文字
- 添加动画
- 获取动画
- 提取动画
- 添加效果
- 获取效果
- 提取效果
- 效果声音
- 应用动画
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 添加、检查和自定义形状动画、时间设置、声音、动画后行为以及动画文本。"
---
## **概述**

Aspose.Slides for Node.js via Java 将幻灯片动画表示为幻灯片时间线中的效果。每个效果具有目标形状、动画类型和子类型、触发器、时间设置以及可选属性，例如声音或动画后行为。

时间线包含两种序列：

- **主序列** 在幻灯片前进时播放。
- **交互序列** 在其触发形状被点击时开始。

因为文本框、图片、图表、表格以及其他幻灯片对象都是 [Shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/) 对象，所以对大多数幻灯片内容使用相同的 [Sequence.addEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sequence/#addEffect) 方法。可用的效果列在 [EffectType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effecttype/) 枚举中。

## **添加形状动画**

要添加动画，获取幻灯片的主序列并调用 [Sequence.addEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sequence/#addEffect)，传入目标形状、效果类型、子类型和触发器。对于在其他形状被点击时启动的效果，需要创建一个触发器为该其他形状的交互序列。

以下示例创建两种类型的动画并将结果保存为 `shape-animations.pptx`。

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

触发器控制效果何时开始：

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effecttriggertype/#OnClick) 在主序列中等待点击，或在交互序列中等待对触发形状的点击。
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) 与前一个效果同时开始。
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) 在前一个效果结束后开始。

要为图片、图表或其他形状类型添加动画，请将该对象传递给 [Sequence.addEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sequence/#addEffect)，而不是 `targetShape`。有关图表特定的分组选项，请参阅 [Animated Charts](/slides/zh/nodejs-java/animated-charts/)。

## **读取形状动画**

当已知目标形状时，使用 [Sequence.getEffectsByShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sequence/#getEffectsByShape)。若要检查每个效果，请枚举主序列和所有交互序列。枚举可避免假设序列在索引 `0` 处包含效果。

以下示例创建一个具有主序列和交互效果的形状，获取针对该形状的效果，然后枚举幻灯片上的所有序列。

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

如果只需要某个形状的效果，请先通过名称、占位符类型或其他稳定属性识别该形状；然后调用 [Sequence.getEffectsByShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sequence/#getEffectsByShape)。不要假设索引 `0` 处的 [ShapeCollection.get_Item](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapecollection/#get_Item) 总是所需的对象。

## **使用继承的占位符效果**

普通幻灯片上的占位符可以继承其布局幻灯片和母版幻灯片上对应占位符的动画行为。[Shape.getBasePlaceholder](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/#getBasePlaceholder) 返回该父占位符，如果不存在父占位符则返回 `null`。

在下面的示例演示文稿中，页脚在普通幻灯片上使用 **Random Bars**，在布局幻灯片上使用 **Split**，在母版幻灯片上使用 **Fly In**。

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

下一个示例使用新演示文稿中的占位符层次结构。它向母版占位符、布局占位符以及普通幻灯片上的相应占位符添加效果。在使用返回的形状之前，都会检查对 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/#getBasePlaceholder) 的调用。

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

## **更改动画时间设置**

PowerPoint **Timing** 对话框映射到 [Timing](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/) 的属性。

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **开始** 映射到 [Timing.getTriggerType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#getTriggerType)。
- **持续时间** 映射到 [Timing.getDuration](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#getDuration)，单位为秒。
- **延迟** 映射到 [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)，单位为秒。
- **重复** 映射到 [Timing.getRepeatCount](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#getRepeatCount)、[Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) 或 [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide)。
- **播放完成后倒回** 映射到 [Timing.getRewind](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#getRewind)。

此独立示例添加一个效果，通过 [Sequence.addEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sequence/#addEffect) 返回的对象修改其时间设置，并保存结果。保留返回的 [Effect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effect/) 引用可避免不必要的集合索引。

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

请有意仅使用一种重复模式。将重复计数与 “until” 标志组合可能在不同的查看器中产生混乱的结果。更改重复模式时，先调用 [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) 和 [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide)，再调用 [Timing.setRepeatCount](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#setRepeatCount)，因为设置任一标志都会更改当前的重复模式。

## **添加和提取动画声音**

动画效果可以通过 [Effect.getSound](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effect/#getSound) 引用嵌入的音频。[Effect.setStopPreviousSound](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effect/#setStopPreviousSound) 指示效果停止先前效果开始的音频。

### **向效果添加声音**

以下示例要求本地音频文件 `animation-sound.wav`。它创建两个效果，将该文件嵌入为第一个效果的声音，并配置第二个效果停止该声音。它使用 [Sequence.addEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sequence/#addEffect) 返回的对象，因此不需要序列索引。

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

### **提取嵌入的效果声音**

以下示例要求本地演示文稿 `presentation-with-animation-sounds.pptx`。它扫描主序列和交互序列，并将每个嵌入的效果声音写入 `extracted-animation-sounds` 目录。扩展名根据 [Audio.getContentType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/audio/#getContentType) 暴露的音频 MIME 类型选择。

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

对于大型音频对象，请使用 [Audio.getStream](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/audio/#getStream) 并将流复制到文件，而不是将整个对象加载到字节数组中。

## **设置动画后行为**

**After animation** 选项控制效果完成后形状的处理方式。

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/afteranimationtype/) 枚举支持保持形状不变、改变其颜色、动画后隐藏或在下次点击时隐藏。当类型为 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/afteranimationtype/#Color) 时，还需设置 [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effect/#getAfterAnimationColor)。

此独立示例创建一个效果，通过返回的效果对象设置其动画后行为，并保存结果。

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

将类型从 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/afteranimationtype/#Color) 改为其他，会清除动画后颜色设置。

## **动画文字**

文字动画有两个相关控制：

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textanimation/#getBuildType) 控制段落是一起出现还是按段落级别出现。
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effect/#getAnimateTextType) 控制文字是一次全部出现、按词或按字出现。[Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) 设置词或字之间的延迟。正值表示效果持续时间的百分比，负值表示以秒为单位的延迟。

以下独立示例为文本框中的词语添加动画。[BuildType.AsOneObject](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/buildtype/#AsOneObject) 禁用按段落构建，使词设置适用于整个文本框。

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

若要按段落构建文本框，请设置 [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1)（或其他段落级别）。若要为单独段落设置效果，请使用接受 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 的 [Sequence.addEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sequence/#addEffect) 重载。请参阅 [Animated Text](/slides/zh/nodejs-java/animated-text/) 获取段落级别示例。

## **导出和兼容性说明**

- 将 PPT 或 PPTX 保存可保留动画模型，但最终播放由演示文稿查看器控制。
- PDF 和静态图像不播放动画。若输出必须显示运动，请使用 [HTML5 export](/slides/zh/nodejs-java/export-to-html5/)、动画 GIF 或 [video conversion](/slides/zh/nodejs-java/convert-powerpoint-to-video/)。
- 对于 HTML5，请启用 [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/html5options/#setAnimateShapes)，必要时还启用 [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/html5options/#setAnimateTransitions)。
- 视频渲染支持许多常见的进入、强调、退出和运动路径效果，但并非所有 PowerPoint 效果都受支持。请检查当前的 [supported animations and effects](/slides/zh/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) 并使用目标 Aspose.Slides 版本对关键演示文稿进行测试。
- 高级自定义效果以及从其他演示文稿格式导入的效果可能在文件中保留，但在 PowerPoint、HTML5 或视频中渲染方式不同。请验证导出结果，而不仅仅依赖效果名称。

## **常见问题**

**为什么动画在 PowerPoint 中显示但在 PDF 中不显示？**

PDF 是静态格式，动画和幻灯片切换不会播放。需要保持运动时，请导出为 HTML5、动画 GIF 或视频。

**为什么效果在视频中播放情况不同？**

视频导出会渲染动画，而不是存储原始 PowerPoint 行为。某些高级效果不受支持或被近似。请查看受支持的效果表，并在生产使用前测试实际演示文稿。

**移动形状的前后层级会改变其动画顺序吗？**

不会。形状的 Z 顺序控制重叠，而序列顺序和触发器控制动画播放。如果需要不同的播放顺序，请修改时间线。