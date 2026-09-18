---
title: JavaScript でカスタム アニメーション ビヘイビアを作成および変更する
linktitle: カスタム アニメーション
type: docs
weight: 151
url: /ja/nodejs-java/custom-animation/
keywords:
- カスタム アニメーション
- アニメーション ビヘイビア
- モーション パス
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、PowerPoint プレゼンテーション内のカスタム アニメーション ビヘイビアと編集可能なモーション パスを作成、検査、変更します（Java 経由）。"
---
## **概要**

カスタム アニメーション ビヘイビアを使用すると、色の変更、図形の回転、編集可能なモーション パスの追従など、アニメーション効果内の個々の操作を制御できます。このガイドでは、ビヘイビアの作成と組み合わせ方法、タイミングの設定、既存アニメーションの検査と変更、そしてプロパティがプレゼンテーションの保存と再オープン後も保持されることを確認する方法を示します。

事前定義済み効果とクリック トリガーについては、[シェイプ アニメーション](/slides/ja/nodejs-java/shape-animation/)をご覧ください。

## **アニメーション モデルの理解**

アニメーションは **Timeline → Sequence → Effect → Behaviors** の階層で構成されます：

- 【[getTimeline](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslide/#getTimeline)】メソッドはスライドのタイムラインを返します。タイムラインにはメイン シーケンスとインタラクティブ シーケンスが含まれます。
- 【[Sequence](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/)】はエフェクトを保持し、異なる図形を対象にすることがあります。
- 【[Effect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/)】は対象図形、プリセット、サブタイプ、エフェクトのタイミングを識別します。
- 【[Effect.getBehaviors](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/#getBehaviors)】が返すコレクションには、エフェクトを実装する操作が含まれます。例えば色の変更、移動、回転、プロパティの設定などです。

## **個別ビヘイビアの作成**

【[Sequence.addEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sequence/#addEffect)】を呼び出してエフェクトを作成し、【[getBehaviors](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/#getBehaviors)】コレクションにアクセスします。プリセットはこのコレクションを自動的に埋めることができます。プリセットを拡張する場合はその操作を保持し、意図的に置き換える場合は【[clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behaviorcollection/#clear)】を使用します。

【[BehaviorFactory](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behaviorfactory/)】は以下に示す 8 種類のビヘイビアを生成します。モーションは【[Build a Motion Path](#build-a-motion-path)】で扱います。各スニペットはモジュールのインポートを含み、`aspose.slides.via.java` と `java` パッケージがインストールされた環境で Node.js スクリプトとして実行できます。ファイル作成例は、出力を読み取る例の前に実行してください。後の編集例では使用する出力ファイルを明示します。

### **回転**

【[createRotationEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect)】で回転ビヘイビアを作成します。【[getBy](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/rotationeffect/#getBy)】は相対角度（度）を指定し、【[getFrom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/rotationeffect/#getFrom)】と【[getTo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/rotationeffect/#getTo)】は開始点と終了点を指定します。

この例は Spin エフェクトから始め、プリセットの操作を 1 つの回転ビヘイビアに置き換え、その操作に 2 秒の期間を設定します。90 度の相対角度は図形の開始向きから 1/4 回転することを意味するため、明示的な開始角度は不要です。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` には 1 つの図形と 1 つの回転ビヘイビアが含まれます。以下のコレクション、タイミング、回転編集例はこのファイルを使用します。

### **拡大縮小**

【[createScaleEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect)】に X/Y パーセンテージを指定します。【[getFrom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/scaleeffect/#getFrom)】と【[getTo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/scaleeffect/#getTo)】は開始サイズと終了サイズを、【[getBy](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/scaleeffect/#getBy)】は相対変化を表します。ここでは 100 が元のサイズを意味します。

この例は両寸法を 100% から 125% に 2 秒かけて拡大します。水平・垂直のパーセンテージを同等にすると図形の比率が保たれ、異なるパーセンテージにすると一方の寸法が伸びます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **色**

【[createColorEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect)】で塗りを青からオレンジに変更します。【[getFrom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/coloreffect/#getFrom)】と【[getTo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/coloreffect/#getTo)】は色、【[getBy](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/coloreffect/#getBy)】は色のオフセットです。【[Behavior.getProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behavior/#getProperties)】はアニメーション対象の属性を示します。

図形の単色塗りは青で初期化され、アニメーションの開始色と一致します。塗り色属性を選択すると、ビヘイビアが図形のどの部分を変更すべきかが決まります。色の終点だけでは属性は特定できません。保存されたエフェクトは 2 秒でオレンジに変化することを記述しています。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **フィルタ**

【[createFilterEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect)】でワイプを選択します。【[getType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/filtereffect/#getType)】、【[getSubtype](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/filtereffect/#getSubtype)】、【[getReveal](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/filtereffect/#getReveal)】はそれぞれフィルタ、方向、表示/非表示を指定します。

この例は右方向サブタイプで図形を表示する 2 秒のワイプを構成します。フィルタ設定はエフェクト内のビヘイビアに属するため、プリセットの元の操作を除去した後に設定します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **プロパティ**

【[createPropertyEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect)】で不透明度をアニメーションします。【[getFrom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/propertyeffect/#getFrom)】、【[getTo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/propertyeffect/#getTo)】、【[getBy](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/propertyeffect/#getBy)】は文字列で、【[getValueType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/propertyeffect/#getValueType)】と【[getCalcMode](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/propertyeffect/#getCalcMode)】で解釈されます。3 つすべてを無差別に設定するのではなく、終点または相対オフセットのいずれかを選択してください。

ここでは属性として不透明度を選び、数値文字列は 25% の不透明度から完全不透明度への変化を表します。線形補間によりその間が徐々に変化します。この例を別の属性に適用する場合は、属性に適した値タイプと終点値を選択してください。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **設定**

【[createSetEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect)】で【[getTo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/seteffect/#getTo)】を使って可視性を設定します。セットビヘイビアは終点間を補間しません。

この例は可視性属性を選択し、ビヘイビアが実行されると文字列 `visible` を割り当てます。最小構成のプレゼンテーションでは矩形は既に表示されているため、単独では目立った視覚変化はありません。この操作は、図形が非表示になるタイミングや表示になるタイミングを制御する他の効果と組み合わせる際に有用です。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **コマンド**

【[createCommandEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect)】を使用し、【[getType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/commandeffect/#getType)】、【[getCommandString](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/commandeffect/#getCommandString)】、【[getShapeTarget](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/commandeffect/#getShapeTarget)】を設定します。作業ディレクトリに `sample.wav` という名前の WAV 録音ファイルを置いてください。この例は【[addAudioFrameEmbedded](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded)】で埋め込み、再生コマンドをオーディオフレームに付加します。

オーディオフレームはエフェクトのターゲットでもあり、コマンドのターゲットでもあります。これにより再生リクエストが埋め込み音声に結び付けられます。コマンド文字列だけではどのメディアオブジェクトを制御するかは特定できません。エフェクトはスライドショー中のクリックで開始するよう設定されています。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

保存するとコマンドは `command.pptx` に格納されますが、再生は行われません。再生には、コマンドとそのメディアターゲットをサポートするスライドショー プレイヤーが必要です。

## **ビヘイビア コレクションの管理**

【[BehaviorCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behaviorcollection/)】は 【[add](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behaviorcollection/#add)】、【[insert](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behaviorcollection/#insert)】、【[remove](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behaviorcollection/#remove)】、【[removeAt](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behaviorcollection/#removeAt)】をサポートします。この例は `rotation.pptx` を開き、拡大縮小ビヘイビアを追加し、回転の前に挿入し、回転を削除します。削除して再挿入すると、オブジェクトはコピーされずに位置だけが変更されます。

編集の順序はコレクションを「回転→拡大縮小」から「拡大縮小→回転」へ、最終的に「拡大縮小のみ」に変えます。インデックスは現在のコレクションを基準にするため、再順序化後の回転の新しいインデックスを使用して削除します。最終的な列挙で保存されるビヘイビアを確認します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

出力は `ScaleEffect` だけです。コレクションの順序だけではビヘイビアが順に実行されるわけではありません。すべての操作を置き換えるときのみコレクションをクリアしてください。

## **ビヘイビア タイミングの設定**

【[Behavior.getTiming](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behavior/#getTiming)】は【[Timing](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/)】を公開し、【[Effect.getTiming](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/#getTiming)】とは独立しています。エフェクトのタイミングはエフェクト全体をスケジュールし、ビヘイビアのタイミングはその内部の操作を記述します。

### **期間、遅延、繰り返し、加速の設定**

`rotation.pptx` を開き、期間 (**[getDuration](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getDuration)**) とトリガ遅延 (**[getTriggerDelayTime](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)**) を秒単位で設定し、繰り返し回数を **[setRepeatCount](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#setRepeatCount)** で構成します。**[getAccelerate](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getAccelerate)** と **[getDecelerate](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getDecelerate)** は期間の割合で、合計が 1 を超えないようにします。

入力ファイルは回転例で作成したものです。最初のビヘイビアが回転であることがわかっています。この例はそのビヘイビアのタイミングだけを変更し、90 度の角度はそのままです。角度とタイミングを分離しておくと、アニメーションを再構築せずに速度調整が容易になります。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

このビヘイビアは 2 秒の期間、0.5 秒の遅延、繰り返し回数 3 を使用します。期間の最初と最後の 20% が加速と減速に使われます。

他の繰り返しポリシーとして **[getRepeatDuration](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getRepeatDuration)**、**[getRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide)**、**[getRepeatUntilNextClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick)** があります。すべて同時に有効にせず、目的に合ったポリシーを選択してください。**[getAutoReverse](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/timing/#getAutoReverse)** は前進後に逆再生します。加速と減速は連続的な変化に適用され、離散的な代入やコマンドには適用されません。

## **モーション パスの作成**

【[createMotionEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect)】でモーションを作成します。**[getFrom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motioneffect/#getFrom)**、**[getTo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motioneffect/#getTo)**、**[getBy](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motioneffect/#getBy)** はパーセンテージベースの座標またはオフセットを表します。編集可能なルートが必要な場合は 【[MotionPath](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motionpath/)】 を作成し、**[MotionEffect.setPath](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motioneffect/#setPath)** で割り当てます。**[MotionPath](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motionpath/)** はパスコマンドを保持します。

**[MotionCommandPathType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motioncommandpathtype/)** は操作を選択します：

| コマンド | ポイント数 | 意味 |
| --- | --- | --- |
| MoveTo | 1 | 開始位置を設定します。 |
| LineTo | 1 | 直線セグメントの終点まで移動します。 |
| CurveTo | 3 | 2 つの制御点と終点で定義された三次ベジェ曲線に従います。 |
| CloseLoop | 0 | 開始位置に戻ります。 |
| End | 0 | パスを終了します。 |

**[MotionPathPointsType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motionpathpointstype/)** はコーナーやスムーズ点など、ポイントの編集特性を記述します。コマンドタイプの代替ではありません。下の曲線例では曲線ポイントタイプ、直線セグメントではコーナーポイントタイプを使用します。

パス座標はスライド寸法に正規化されます。X の変位 0.25 はスライド幅の 1/4 を表し、0.25 ポイントではありません。Y は下方向が正です。絶対コマンドはパス座標系で位置を指定し、相対コマンドは現在位置からのオフセットを指定します。これは **[getOrigin](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motioneffect/#getOrigin)**（パスの基準フレーム選択）や **[getPathEditMode](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motioneffect/#getPathEditMode)**（図形移動時のパス動作制御）とは別です。

### **直線パスの作成**

開始点、1 本の直線セグメント、終了コマンドを持つモーションビヘイビアを作成します。**[MotionPath.add](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motionpath/#add)** はコマンドタイプ、ポイント配列、ポイントタイプ、相対座標フラグを受け取ります。

開始コマンドは (0, 0) を設定し、線は (0.25, 0) で終わります。これによりスライド幅の 1/4 の水平変位が得られます。終了コマンドには座標ポイントはありません。パスを割り当てた後、モーションビヘイビアをエフェクトに追加すると、そのルートが矩形に結び付けられます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` には 3 つのパスコマンドを持つ 1 つのモーションビヘイビアが含まれます。以下のファイル編集例はこの既知の構造を使用します。

### **絶対座標と相対座標の比較**

この 2 つのパスオブジェクトは同じルートを表します。絶対コマンドは (0.3, 0.1) に終わり、相対コマンドは現在位置に (0.1, 0.1) を加えて (0.2, 0) になります。

両パスは同じ開始位置です。相対線の場合は X と Y のオフセットを現在位置に加えて終点を求め、絶対線の場合は終点を直接読み取ります。フラグだけを切り替えて座標変換を行わないと、別のルートになります。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

いずれかのパスをモーションビヘイビアに割り当ててプレゼンテーションで使用できます。最後の Boolean 引数はそのコマンドの座標が相対かどうかを選択します。

### **直線を曲線に置き換える**

`motion.pptx` を開き、直線コマンドを三次ベジェ曲線に置き換えます。最初に 2 つの制御点を、次に終点を指定します。

開始位置は前のコマンドで供給されます。最初の 2 点が曲線を形作り、3 点目が目的地です。3 点が連続した目的地というわけではありません。コマンドタイプ、ポイント編集タイプ、ポイント配列を同時に更新すると、セグメントが新しいジオメトリと整合します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`curve.pptx` のパスは依然として 3 つのコマンドを持ちますが、真ん中のコマンドが曲線を定義しています。

## **保存されたパスの検査と編集**

各 【[MotionCmdPath](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motioncmdpath/)】は 【[getPoints](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motioncmdpath/#getPoints)】、【[getCommandType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motioncmdpath/#getCommandType)】、【[getPointsType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motioncmdpath/#getPointsType)】、【[isRelative](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motioncmdpath/#isRelative)】を公開します。以下の例は `motion.pptx` の既知の 3 コマンドパスを使用します。任意の入力の場合は、対象エフェクトを特定し、インデックスで編集する前にコマンドタイプとポイント数を確認してください。

### **コマンドと座標の読み取り**

パスを変更せずに読み取ります。終了コマンドと閉ループコマンドはポイントを必要としないため、null のポイント配列を許容します。

出力は各数値コマンドタイプと相対座標フラグの組み合わせを示し、その後にポイントを列挙します。これにより、パスを変更する前に終点とオフセットを区別できます。曲線は 3 点を、直線は 1 点だけを一覧表示します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

この一覧には開始点、絶対線 (0.25, 0) の終点、そして終了コマンドが含まれます。

### **終点の変更**

`motion.pptx` を開き、直線のポイント配列を置き換えて終点を移動します。

入力ファイルではインデックス 0 が開始コマンド、インデックス 1 が直線です。直線の単一ポイントを置き換えると、コマンドタイプ、タイミング、コレクション内の位置は変わらず、目的地だけが変更されます。コマンドが絶対座標を使用しているため、新しいペアはオフセットではなく位置を指定します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion-endpoint.pptx` の線は (0.4, 0.1) で終わり、元のファイルは変更されません。

### **セグメントの置き換え**

【[insert](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motionpath/#insert)】 と 【[removeAt](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/motionpath/#removeAt)】 を使用して `motion.pptx` の線を置き換えます。挿入により古い線はインデックス 2 にシフトします。

この操作は既存座標の編集ではなく、コマンドオブジェクト自体の置換を示します。挿入後、一時的にコレクションは開始コマンド、新しい線、古い線、終了コマンドの 4 要素になります。インデックス 2 を削除すると古い線が破棄され、新しいルートが残ります。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存されたパスは依然として 3 つのコマンドを持ち、新しい線は (0.2, 0.1) で終わり、最後に終了コマンドが続きます。

## **既存ビヘイビアの変更と検証**

ビヘイビアのインデックスが不明な場合はタイプで選択します。この例は `rotation.pptx` を開き、【[RotationEffect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/rotationeffect/)】を見つけて角度を変更し、再オープン後に保存された値を確認します。

タイプチェックにより、回転でないビヘイビアはループでスキップされます。2 回目の読み込みは保存されたファイルを別のプレゼンテーション オブジェクトに読み込むため、比較はメモリ上の値ではなく永続化されたデータを対象とします。この例は対象エフェクトがメインシーケンスの最初にあることを前提としていますが、タイプでビヘイビアを選択しても任意のプレゼンテーションで正しいエフェクトが見つかるとは限りません。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

出力は `Rotation preserved: true` です。同様のタイプチェック パターンを他のビヘイビアにも適用してください。完全な保存チェックでは、対象図形、エフェクト、ビヘイビアタイプと順序、タイミング、パスコマンドを比較し、浮動小数点値には数値許容差を使用します。アニメーション構成が不明なプレゼンテーションについては、[Shape Animations の読み取り](/slides/ja/nodejs-java/shape-animation/#read-shape-animations) を参照し、メインシーケンスとインタラクティブシーケンスを走査してください。

## **ビヘイビアの順序、プリセット、再生**

【[BehaviorCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behaviorcollection/)】の順序はエフェクト内の操作の保存順序です。これは「前のビヘイビアが自動的に待機する」プレイリストではありません。スケジューリングはタイミングとエフェクト全体が決定します。ビヘイビアは重複して実行でき、同一プロパティへの操作は 【[getAdditive](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behavior/#getAdditive)】 や 【[getAccumulate](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/behavior/#getAccumulate)】 を通じて相互作用することがあります。単にコレクションの順序を変えるだけで「移動、次に回転」を実現しようとしないでください。明示的なタイミングや別エフェクトを使用してください（[Shape Animation](/slides/ja/nodejs-java/shape-animation/) 参照）。

エフェクトの 【[getType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/#getType)】 と 【[getSubtype](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/effect/#getSubtype)】はプリセットを記述しますが、編集されたビヘイビア ツリーの完全な記述ではありません。ビヘイビアをカスタマイズする前に、プリセットとサブタイプを選択してください。プリセットを変更するとコレクションが再構築され、カスタム操作が失われることがあります。例えば、カスタム Spin エフェクトを Fade に変更すると、回転ビヘイビアはセットやフィルタ ビヘイビアに置き換えられます。プリセットやサブタイプを変更した後はコレクションを再度検査してください。プリセットのビヘイビアをクリアすると、プリセットが必要とする可視化や初期化操作も失われる可能性があります。この例では可視図形を使用し、ビヘイビアを置き換えているため、すべてのプリセット実装を再構築しているわけではありません。

## **形式互換性**

保存されたビヘイビア ツリーがすべてのビューアやエクスポート レンダラで同一の再生を保証するわけではありません。保存データとレンダリング結果を個別に確認してください。

| 形式または出力 | 確認項目 |
| --- | --- |
| PPTX | 例の主要形式として使用します。再オープンして編集可能なビヘイビア ツリーを確認し、対象の PowerPoint バージョンで再生をチェックしてください。 |
| PPT | 従来のバイナリ形式は PPTX と異なる場合があります。別途保存‑再オープンサイクルと再生をテストし、PPTX の成功だけで全組み合わせのサポートを推測しないでください。 |
| PDF、PNG、JPEG などの静的スライド画像 | 静的なスライド表現であり、再生可能なビヘイビア タイムラインや最終フレームは保証されません。 |
| [HTML5](/slides/ja/nodejs-java/export-to-html5/) | エクスポートオプションでシェイプ アニメーションを有効にすれば、サポートされたアニメーションを再生できます。ブラウザでカスタム組み合わせをテストしてください。 |
| [Animated GIF](/slides/ja/nodejs-java/convert-powerpoint-to-animated-gif/) | レンダリングされたフレームを保存しますが、編集可能なビヘイビアやクリック トリガは含まれません。実際のモーションを確認してください。 |
| [Video](/slides/ja/nodejs-java/convert-powerpoint-to-video/) | アニメーションフレームをレンダリングし、動画としてエンコードします。サポートはレンダラの [supported animations and effects](/slides/ja/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) に限定され、コマンドやインタラクティブ イベントは編集可能なタイムラインになりません。 |

## **FAQ**

**なぜ効果にビヘイビアが何も追加していないのに含まれているのですか？**

事前定義された効果を作成すると、基になる操作が自動的に生成されることがあります。拡張するか置き換えるかを判断する前に、まずそれらを検査してください。

**ビヘイビアを先頭に移動すれば最初に再生されますか？**

必ずしもそうではありません。コレクション順序はタイミングの代替になりません。遅延、期間、同一プロパティへの操作間の相互作用を確認してください。

**終了コマンドにポイントがないのはなぜですか？**

パスの終了を示すだけで座標は不要です。ファイルから読み取ったパスを検査する際は、ポイント配列が null であることを確認してください。

**ラウンドトリップが成功すれば再生も保証されますか？**

いいえ。再オープンはプロパティの保持を確認するだけです。スライドショー プレイヤーやアニメーション エクスポートで実際の視覚的再生を別途テストしてください。