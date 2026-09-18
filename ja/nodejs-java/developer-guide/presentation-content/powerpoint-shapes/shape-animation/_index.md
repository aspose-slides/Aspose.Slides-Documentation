---
title: JavaScript を使用してプレゼンテーションでシェイプ アニメーションを適用する
linktitle: シェイプ アニメーション
type: docs
weight: 60
url: /ja/nodejs-java/shape-animation/
keywords:
- シェイプ
- アニメーション
- エフェクト
- アニメーション シェイプ
- アニメーション テキスト
- アニメーション の追加
- アニメーション の取得
- アニメーション の抽出
- エフェクト の追加
- エフェクト の取得
- エフェクト の抽出
- エフェクト サウンド
- アニメーション の適用
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、シェイプ アニメーションの追加、検査、カスタマイズ、タイミング、サウンド、アフター アニメーション動作、アニメーション テキストを学びます。"
---
## **概要**

エフェクト内の個々の動作やモーションパス セグメントを操作するには、[Custom Animation](/slides/ja/nodejs-java/custom-animation/) を参照してください。

Aspose.Slides for Node.js via Java はスライド アニメーションをスライド タイムライン上のエフェクトとして表します。エフェクトには対象のシェイプ、アニメーション タイプとサブタイプ、トリガー、タイミング設定、およびサウンドやアフター アニメーション動作などのオプション プロパティがあります。

タイムラインには次の 2 種類のシーケンスがあります。

- **メイン シーケンス** はスライドが進むときに再生されます。
- **インタラクティブ シーケンス** はトリガー シェイプがクリックされたときに開始されます。

テキスト ボックス、画像、チャート、表、その他のスライド オブジェクトはすべて [Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/) オブジェクトであるため、ほとんどのスライド コンテンツに対して同じ [Sequence.addEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/#addEffect) メソッドを使用します。利用可能なエフェクトは [EffectType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effecttype/) 列挙体に一覧されています。

## **シェイプ アニメーションの追加**

アニメーションを追加するには、スライドのメイン シーケンスを取得し、対象シェイプ、エフェクト タイプ、サブタイプ、トリガーを指定して [Sequence.addEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/#addEffect) を呼び出します。他のシェイプがクリックされたときに開始するエフェクトの場合は、そのシェイプをトリガーとしてインタラクティブ シーケンスを作成します。

次の例は 2 種類のアニメーションを作成し、結果を `shape-animations.pptx` に保存します。

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

トリガーはエフェクトの開始タイミングを制御します。

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effecttriggertype/#OnClick) はメイン シーケンスではクリック待ち、インタラクティブ シーケンスではトリガー シェイプのクリック待ちです。
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) は直前のエフェクトと同時に開始します。
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) は直前のエフェクトが終了したときに開始します。

画像、チャート、またはその他のシェイプ タイプをアニメーション化するには、`targetShape` の代わりにそのオブジェクトを [Sequence.addEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/#addEffect) に渡します。チャート固有のグループ化オプションについては、[Animated Charts](/slides/ja/nodejs-java/animated-charts/) を参照してください。

## **シェイプ アニメーションの取得**

対象シェイプが分かっている場合は、[Sequence.getEffectsByShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/#getEffectsByShape) を使用します。すべてのエフェクトを調べるには、メイン シーケンスとすべてのインタラクティブ シーケンスを列挙します。列挙時にインデックス `0` にエフェクトが必ず存在すると仮定しないでください。

次の例はメイン シーケンスとインタラクティブ シーケンスにエフェクトを持つシェイプを作成し、そのシェイプを対象とするエフェクトを取得した後、スライド上のすべてのシーケンスを列挙します。

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

1 つのシェイプだけのエフェクトが必要な場合は、名前、プレースホルダー タイプ、または他の安定したプロパティでシェイプを特定し、次に [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/#getEffectsByShape) を呼び出します。[ShapeCollection.get_Item](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/#get_Item) のインデックス `0` が常に目的のオブジェクトであるとは限らないことに注意してください。

## **継承プレースホルダー エフェクトの操作**

通常のスライド上のプレースホルダーは、レイアウト スライドおよびマスタースライド上の対応するプレースホルダーからアニメーション 動作を継承できます。[Shape.getBasePlaceholder](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getBasePlaceholder) は親プレースホルダーを返すか、存在しなければ `null` を返します。

以下の例のプレゼンテーションでは、フッターは通常スライドで **Random Bars**、レイアウト スライドで **Split**、マスタースライドで **Fly In** のアニメーションが設定されています。

![通常スライド上のフッター アニメーション効果](slide-shape-animation.png)

![レイアウトスライド上のフッター プレースホルダー アニメーション効果](layout-shape-animation.png)

![マスタースライド上のフッター プレースホルダー アニメーション効果](master-shape-animation.png)

次の例は新規プレゼンテーションのプレースホルダー階層を使用します。マスタープレースホルダー、レイアウトプレースホルダー、および通常スライド上の対応プレースホルダーにエフェクトを追加します。各 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getBasePlaceholder) 呼び出しは、返されたシェイプが使用される前にチェックされています。

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

## **アニメーション タイミングの変更**

PowerPoint の **Timing** ダイアログは [Timing](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/) のプロパティに対応しています。

![アニメーション効果の PowerPoint Timing ダイアログ](shape-animation.png)

- **Start** は [Timing.getTriggerType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getTriggerType) に対応します。
- **Duration** は [Timing.getDuration](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getDuration) に対応し、秒で指定します。
- **Delay** は [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) に対応し、秒で指定します。
- **Repeat** は [Timing.getRepeatCount](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getRepeatCount)、[Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) または [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) に対応します。
- **Rewind when done playing** は [Timing.getRewind](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getRewind) に対応します。

この独立した例はエフェクトを追加し、[Sequence.addEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/#addEffect) が返すオブジェクトを介してタイミングを変更し、結果を保存します。返された [Effect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/) 参照を保持することで不要なコレクション インデックスの取得を回避できます。

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

1 つのリピート モードだけを意図的に使用してください。リピート カウントと「until」フラグを組み合わせると、ビューアーによって結果が混乱する可能性があります。リピート モードを変更する際は、[Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) および [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) を [Timing.setRepeatCount](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#setRepeatCount) より先に設定してください。いずれかのフラグを設定するとアクティブなリピート モードも変更されます。

## **アニメーション サウンドの追加と抽出**

アニメーション エフェクトは [Effect.getSound](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/#getSound) を通じて埋め込みオーディオを参照できます。[Effect.setStopPreviousSound](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/#setStopPreviousSound) は、以前のエフェクトが開始した音声を停止させるよう指示します。

### **エフェクトにサウンドを追加する**

次の例はローカルの音声ファイル `animation-sound.wav` が存在することを想定しています。2 つのエフェクトを作成し、最初のエフェクトのサウンドとしてそのファイルを埋め込み、2 番目のエフェクトをサウンド停止に設定します。[Sequence.addEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/#addEffect) が返すオブジェクトを使用するため、シーケンス インデックスは不要です。

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

### **埋め込みエフェクトサウンドの抽出**

次の例はローカルのプレゼンテーション `presentation-with-animation-sounds.pptx` が存在することを想定しています。メインとインタラクティブの両シーケンスを走査し、すべての埋め込みエフェクトサウンドを `extracted-animation-sounds` ディレクトリに書き出します。拡張子は [Audio.getContentType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audio/#getContentType) が返すオーディオ MIME タイプから決定されます。

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

大きなオーディオ オブジェクトの場合は、[Audio.getStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audio/#getStream) を使用してストリームをファイルにコピーし、全体をバイト配列に読み込むのを避けてください。

## **アフター アニメーション 動作の設定**

**After animation** オプションはエフェクトが完了した後にシェイプに対して行われる処理を制御します。

![After animation 設定を表示する PowerPoint Effect Options ダイアログ](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/afteranimationtype/) 列挙体は、シェイプを変更せずに残す、色を変更する、アニメーション後に非表示にする、次のクリックで非表示にする、などをサポートします。タイプが [AfterAnimationType.Color](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/afteranimationtype/#Color) の場合は、[Effect.getAfterAnimationColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/#getAfterAnimationColor) も設定してください。

この独立した例はエフェクトを作成し、返されたエフェクト オブジェクトを介してアフター アニメーション 動作を設定し、結果を保存します。

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

[AfterAnimationType.Color](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/afteranimationtype/#Color) 以外のタイプに変更すると、アフター アニメーションの色設定はクリアされます。

## **テキストのアニメーション**

テキスト アニメーションには次の 2 つの関連コントロールがあります。

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textanimation/#getBuildType) は、段落全体をまとめて表示するか、段落単位で表示するかを制御します。
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/#getAnimateTextType) は、テキストを一度にすべて、単語単位、または文字単位で表示するかを制御します。[Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) は単語または文字間の遅延を設定します。正の値はエフェクト期間のパーセンテージ、負の値は秒単位の遅延です。

次の独立した例はテキスト ボックス内の単語をアニメーション化します。[BuildType.AsOneObject](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/buildtype/#AsOneObject) を使用すると段落単位のビルドが無効化され、単語設定がテキスト フレーム全体に適用されます。

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

段落単位でテキスト ボックスを構築するには、[BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1)（または別の段落レベル）を設定します。単一の段落に個別のエフェクトを適用したい場合は、[Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) を受け取るオーバーロードの [Sequence.addEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/#addEffect) を使用してください。段落レベルの例は [Animated Text](/slides/ja/nodejs-java/animated-text/) を参照してください。

## **エクスポートと互換性に関する注意事項**

- PPT または PPTX に保存するとアニメーション モデルは保持されますが、最終的な再生はプレゼンテーション ビューアに依存します。
- PDF や静止画像はアニメーションを再生しません。モーションを示す必要がある場合は、[HTML5 エクスポート](/slides/ja/nodejs-java/export-to-html5/)、アニメーション GIF、または [ビデオ変換](/slides/ja/nodejs-java/convert-powerpoint-to-video/) を使用してください。
- HTML5 では [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/html5options/#setAnimateShapes) を有効にし、必要に応じて [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/html5options/#setAnimateTransitions) も有効にしてください。
- ビデオ レンダリングは多くの一般的な入口、強調、退出、モーション パス エフェクトをサポートしますが、すべての PowerPoint エフェクトがサポートされているわけではありません。現在の [サポートされているアニメーションとエフェクト](/slides/ja/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) を確認し、対象の Aspose.Slides バージョンで重要なプレゼンテーションをテストしてください。
- カスタム エフェクトや他のプレゼンテーション形式からインポートしたエフェクトは、ファイル内に保持されるものの、PowerPoint、HTML5、またはビデオでのレンダリングが異なる場合があります。エフェクト名だけに依存せず、エクスポート結果を必ず検証してください。

## **FAQ**

**なぜアニメーションは PowerPoint では表示されるのに PDF では表示されないのですか？**

PDF は静的形式のため、アニメーションやスライド遷移は再生されません。モーションを保持する必要がある場合は、HTML5、アニメーション GIF、またはビデオにエクスポートしてください。

**なぜエフェクトがビデオで異なる動作をするのですか？**

ビデオ エクスポートはアニメーションをレンダリングして保存するため、元の PowerPoint の動作そのものは保持されません。高度なエフェクトの一部はサポートされていないか、近似されます。サポートされているエフェクトの表を確認し、実際のプレゼンテーションをテストしてから本番環境で使用してください。

**シェイプを前面または背面に移動するとアニメーション順序が変わりますか？**

いいえ。シェイプの Z オーダーは重なり順を制御し、シーケンス順序とトリガーがアニメーション再生順を制御します。再生順序を変更する必要がある場合は、タイムラインを調整してください。