---
title: JavaScript を使用したプレゼンテーションへのシェイプ アニメーションの適用
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
- アニメーションを追加
- アニメーションを取得
- アニメーションを抽出
- エフェクトを追加
- エフェクトを取得
- エフェクトを抽出
- エフェクト サウンド
- アニメーションを適用
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、シェイプ アニメーション、タイミング、サウンド、アフター アニメーション動作、アニメーション テキストの追加、検査、カスタマイズ方法を学びます。"
---
## **概要**

Aspose.Slides for Node.js via Java は、スライド アニメーションをスライド タイムライン内のエフェクトとして表します。エフェクトは対象シェイプ、アニメーションの種類とサブタイプ、トリガー、タイミング設定、そしてサウンドやアフター アニメーション動作などのオプション プロパティを持ちます。

タイムラインには 2 種類のシーケンスがあります：

- **メイン シーケンス** はスライドが進むと再生されます。
- **インタラクティブ シーケンス** は、そのトリガー シェイプがクリックされたときに開始されます。

テキスト ボックス、画像、チャート、表、その他のスライド オブジェクトはすべて [Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/) オブジェクトであるため、ほとんどのスライド コンテンツに対して同じ [Sequence.addEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/#addEffect) メソッドを使用します。利用可能なエフェクトは [EffectType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effecttype/) 列挙体に一覧されています。

## **シェイプ アニメーションの追加**

アニメーションを追加するには、スライドのメイン シーケンスを取得し、対象シェイプ、エフェクトの種類、サブタイプ、トリガーを指定して [Sequence.addEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/#addEffect) を呼び出します。他のシェイプがクリックされたときに開始するエフェクトの場合、そのシェイプをトリガーとしたインタラクティブ シーケンスを作成します。

以下の例は、両方のタイプのアニメーションを作成し、結果を `shape-animations.pptx` に保存します。

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

トリガーはエフェクトの開始タイミングを制御します：

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effecttriggertype/#OnClick) は、メイン シーケンスでのクリック、またはインタラクティブ シーケンスでトリガー シェイプのクリックを待機します。
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) は、直前のエフェクトと同時に開始します。
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) は、直前のエフェクトが終了したときに開始します。

画像、チャート、またはその他のシェイプ タイプをアニメーション化するには、`targetShape` の代わりにそのオブジェクトを [Sequence.addEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/#addEffect) に渡します。チャート固有のグルーピング オプションについては、[Animated Charts](/slides/ja/nodejs-java/animated-charts/) を参照してください。

## **シェイプ アニメーションの取得**

対象シェイプが分かっている場合は [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/#getEffectsByShape) を使用します。すべてのエフェクトを確認するには、メイン シーケンスとすべてのインタラクティブ シーケンスを列挙します。列挙することで、シーケンスにインデックス `0` のエフェクトが必ず存在すると仮定することを防げます。

以下の例は、メイン シーケンスとインタラクティブ エフェクトを持つシェイプを作成し、そのシェイプを対象とするエフェクトを取得し、さらにスライド上のすべてのシーケンスを列挙します。

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

1 つのシェイプのエフェクトだけが必要な場合は、まず名前、プレースホルダー タイプ、または他の安定したプロパティでシェイプを特定し、次に [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/#getEffectsByShape) を呼び出します。[ShapeCollection.get_Item](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/#get_Item) のインデックス `0` が常に目的のオブジェクトであると仮定しないでください。

## **継承されたプレースホルダー エフェクトの操作**

通常のスライド上のプレースホルダーは、レイアウト スライドやマスタースライド上の対応するプレースホルダーからアニメーション 動作を継承できます。[Shape.getBasePlaceholder](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getBasePlaceholder) はその親プレースホルダーを返し、親が存在しない場合は `null` を返します。

以下のサンプル プレゼンテーションでは、フッターは通常のスライドで **Random Bars**、レイアウト スライドで **Split**、マスタースライドで **Fly In** のアニメーションが設定されています。

![通常のスライド上のフッター アニメーション効果](slide-shape-animation.png)

![レイアウト スライド上のフッター プレースホルダー アニメーション効果](layout-shape-animation.png)

![マスタースライド上のフッター プレースホルダー アニメーション効果](master-shape-animation.png)

次の例では、新しいプレゼンテーションのプレースホルダー階層を使用します。マスタープレースホルダー、レイアウトプレースホルダー、および通常のスライド上の対応するプレースホルダーにエフェクトを追加します。[Shape.getBasePlaceholder](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getBasePlaceholder) への呼び出しは、返されたシェイプを使用する前に必ずチェックされます。

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

PowerPoint の **Timing** ダイアログは、[Timing](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/) のプロパティに対応しています。

![アニメーション効果の PowerPoint Timing ダイアログ](shape-animation.png)

- **開始** は [Timing.getTriggerType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getTriggerType) に対応します。
- **期間** は [Timing.getDuration](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getDuration) に対応し、単位は秒です。
- **遅延** は [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) に対応し、単位は秒です。
- **繰り返し** は [Timing.getRepeatCount](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getRepeatCount)、[Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick)、または [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) に対応します。
- **再生完了後に巻き戻す** は [Timing.getRewind](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getRewind) に対応します。

この独立した例はエフェクトを追加し、[Sequence.addEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/#addEffect) が返すオブジェクトを介してタイミングを変更し、結果を保存します。返された [Effect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/) 参照を保持することで、不要なコレクション インデックスの使用を回避できます。

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

意図的に 1 つの繰り返しモードのみを使用してください。繰り返し回数と "until" フラグを組み合わせると、ビューアーによって混乱を招く結果になることがあります。繰り返しモードを変更する場合は、[Timing.setRepeatCount](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#setRepeatCount) を呼び出す前に、[Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) と [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) を設定してください。いずれかのフラグを設定すると、アクティブな繰り返しモードも変更されます。

## **アニメーション サウンドの追加と抽出**

アニメーション エフェクトは、[Effect.getSound](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/#getSound) を介して埋め込みオーディオを参照できます。[Effect.setStopPreviousSound](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/#setStopPreviousSound) は、エフェクトに以前のエフェクトが開始したオーディオを停止させます。

### **エフェクトにサウンドを追加**

以下の例は、ローカルのオーディオ ファイル `animation-sound.wav` が存在することを前提としています。2 つのエフェクトを作成し、最初のエフェクトのサウンドとしてそのファイルを埋め込み、2 番目のエフェクトでサウンドを停止するよう設定します。[Sequence.addEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/#addEffect) が返すオブジェクトを使用するため、シーケンス インデックスは不要です。

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

以下の例は、ローカルのプレゼンテーション `presentation-with-animation-sounds.pptx` が存在することを前提としています。メインとインタラクティブの両シーケンスを走査し、埋め込まれたすべてのエフェクトサウンドを `extracted-animation-sounds` ディレクトリに書き出します。拡張子は [Audio.getContentType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audio/#getContentType) が示すオーディオ MIME タイプから選択されます。

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

大きなオーディオ オブジェクトの場合は、[Audio.getStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audio/#getStream) を使用し、オブジェクト全体をバイト配列に読み込む代わりにストリームをファイルにコピーしてください。

## **アフター アニメーション動作の設定**

**After animation** オプションは、エフェクトが終了した後にシェイプに何が起こるかを制御します。

![After animation 設定を示す PowerPoint エフェクト オプション ダイアログ](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/afteranimationtype/) 列挙体は、シェイプを変更せずに残す、色を変更する、アニメーション後に非表示にする、次のクリックで非表示にする、という動作をサポートします。タイプが [AfterAnimationType.Color](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/afteranimationtype/#Color) の場合は、[Effect.getAfterAnimationColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/#getAfterAnimationColor) も設定してください。

この独立した例はエフェクトを作成し、返されたエフェクト オブジェクトを通じてアフター アニメーション動作を設定し、結果を保存します。

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

テキスト アニメーションには関連する 2 つの制御があります：

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textanimation/#getBuildType) は、段落をまとめて表示するか段落レベルで表示するかを制御します。
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/#getAnimateTextType) は、テキストを一度に表示するか、単語単位か、文字単位かを制御します。[Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) は単語または文字間の遅延を設定します。正の値はエフェクト期間のパーセンテージ、負の値は秒単位の遅延です。

以下の独立した例はテキスト ボックス内の単語をアニメーション化します。[BuildType.AsOneObject](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/buildtype/#AsOneObject) は段落ごとのビルドを無効にし、単語設定がテキスト フレーム全体に適用されるようにします。

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

段落単位でテキスト ボックスを構築するには、[BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1)（または他の段落レベル）を設定します。単一の段落に個別のエフェクトを適用するには、[Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) を受け取るオーバーロードの [Sequence.addEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/#addEffect) を使用します。段落レベルの例については、[Animated Text](/slides/ja/nodejs-java/animated-text/) を参照してください。

## **エクスポートと互換性に関する注意事項**

- PPT または PPTX への保存はアニメーション モデルを保持しますが、最終的な再生はプレゼンテーション ビューアーが制御します。
- PDF や静止画像はアニメーションを再生しません。出力に動きを示す必要がある場合は、[HTML5 export](/slides/ja/nodejs-java/export-to-html5/)、アニメーション GIF、または [video conversion](/slides/ja/nodejs-java/convert-powerpoint-to-video/) を使用してください。
- HTML5 では、[Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/html5options/#setAnimateShapes) を有効にし、必要に応じて [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/html5options/#setAnimateTransitions) も有効にしてください。
- ビデオレンダリングは、一般的な入口、強調、終了、およびモーション パス エフェクトの多くをサポートしますが、すべての PowerPoint エフェクトがサポートされているわけではありません。現在の [supported animations and effects](/slides/ja/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) を確認し、対象の Aspose.Slides バージョンで重要なプレゼンテーションをテストしてください。
- 高度なカスタム エフェクトや他のプレゼンテーション形式からインポートされたエフェクトはファイル内で保持されることがありますが、PowerPoint、HTML5、またはビデオでの描画が異なる場合があります。エフェクト名だけに依存せず、エクスポート結果を検証してください。

## **FAQ**

**なぜアニメーションは PowerPoint では表示されるのに PDF では表示されないのですか？**

PDF は静的なフォーマットであるため、アニメーションやスライド遷移は再生されません。動きを保持する必要がある場合は、HTML5、アニメーション GIF、またはビデオにエクスポートしてください。

**なぜビデオでエフェクトの再生が異なるのですか？**

ビデオエクスポートは、元の PowerPoint の動作を保持せずにアニメーションをレンダリングします。高度なエフェクトの一部はサポートされていないか、近似されます。サポート対象エフェクトの表を確認し、実際のプレゼンテーションを本番使用前にテストしてください。

**シェイプを前面または背面に移動すると、アニメーション順序が変わりますか？**

いいえ。シェイプの Z オーダーは重なり順を制御し、シーケンスの順序とトリガーがアニメーションの再生順序を制御します。再生順序を変更したい場合は、タイムラインを調整してください。