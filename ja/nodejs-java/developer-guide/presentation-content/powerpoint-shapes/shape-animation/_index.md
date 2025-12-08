---
title: 形状アニメーション
type: docs
weight: 60
url: /ja/nodejs-java/shape-animation/
keywords:
- 形状
- アニメーション
- 効果
- 効果の追加
- 効果の取得
- 効果の抽出
- アニメーションの適用
- PowerPoint
- プレゼンテーション
- Node.js
- Java
- Aspose.Slides for Node.js via Java
description: JavaScriptでPowerPointアニメーションを適用する
---

アニメーションはテキスト、画像、図形、または[チャート](/slides/ja/nodejs-java/animated-charts/)に適用できる視覚効果です。プレゼンテーションやその構成要素に命を吹き込みます。

## **プレゼンテーションでアニメーションを使用する理由**

* 情報の流れを制御する
* 重要なポイントを強調する
* 聴衆の関心や参加意欲を高める
* コンテンツを読みやすく、吸収しやすく、処理しやすくする
* プレゼンテーションの重要な部分に読者や視聴者の注意を引く

PowerPoint には、**entrance**、**exit**、**emphasis**、**motion paths** カテゴリにわたるアニメーションとアニメーション効果のための多くのオプションとツールが用意されています。 

## **Aspose.Slides のアニメーション**

* Aspose.Slides は、`Aspose.Slides.Animation` 名前空間にある、アニメーションを操作するために必要なクラスと型を提供します。
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttype) 列挙体に **150 以上のアニメーション効果** を提供します。これらの効果は、基本的に PowerPoint で使用されるものと同じ（または同等）です。

## **テキストボックスへのアニメーション適用**

Node.js 用 Aspose.Slides for Java を使用すると、図形内のテキストにアニメーションを適用できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. `rectangle` の [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape) を追加します。
4. [AutoShape.addTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) を使用してテキストを追加します。
5. メインのエフェクトシーケンスを取得します。
6. [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape) にアニメーション効果を追加します。
7. `BuildType` 列挙体の値を使用して `TextAnimation.setBuildType` メソッドを呼び出します。
8. プレゼンテーションを PPTX ファイルとしてディスクに保存します。

この Javascript コードは、`Fade` 効果を AutoShape に適用し、テキストアニメーションを *By 1st Level Paragraphs* に設定する方法を示しています:
```javascript
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを生成します。
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // テキスト付きの新しいAutoShapeを追加します
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // スライドのメインシーケンスを取得します。
    var sequence = sld.getTimeline().getMainSequence();
    // シェイプにFadeアニメーション効果を追加します
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // シェイプのテキストを第1レベル段落単位でアニメーション化します
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // PPTXファイルをディスクに保存します
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert color="primary"  %}} 

テキストへのアニメーション適用に加えて、単一の[Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph)にもアニメーションを適用できます。**Animated Text**をご覧ください。

{{% /alert %}} 

## **PictureFrame へのアニメーション適用**

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. スライド上に [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe) を追加または取得します。
4. メインのエフェクトシーケンスを取得します。
5. [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe) にアニメーション効果を追加します。
6. プレゼンテーションを PPTX ファイルとしてディスクに保存します。

この Javascript コードは、picture frame に `Fly` 効果を適用する方法を示しています:
```javascript
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを生成します。
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションの画像コレクションに追加する画像をロードします
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // スライドに画像フレームを追加します
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // スライドのメインシーケンスを取得します。
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // 画像フレームに左からフライアニメーション効果を追加します
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // PPTXファイルをディスクに保存します
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Shape へのアニメーション適用**

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. `rectangle` の [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape) を追加します。
4. `Bevel` の [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape) を追加します（このオブジェクトがクリックされるとアニメーションが再生されます）。
5. ベベル形状上にエフェクトシーケンスを作成します。
6. カスタムの `UserPath` を作成します。
7. `UserPath` への移動コマンドを追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに保存します。

この Javascript コードは、shape に `PathFootball`（パスフットボール）効果を適用する方法を示しています:
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // 既存の図形に対して最初から PathFootball 効果を作成します。
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // PathFootBall アニメーション効果を追加します
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // ボタンのようなものを作成します。
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // このボタン用の効果シーケンスを作成します。
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // カスタムユーザーパスを作成します。オブジェクトはボタンがクリックされた後にのみ移動します。
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // 作成されたパスが空なので、移動コマンドを追加します。
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // PPTX ファイルをディスクに保存します
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Shape に適用されたアニメーション効果の取得**

以下の例は、[Sequence](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sequence/) クラスの `getEffectsByShape` メソッドを使用して、図形に適用されたすべてのアニメーション効果を取得する方法を示しています。

**例 1: 通常のスライド上の図形に適用されたアニメーション効果の取得**

以前、PowerPoint プレゼンテーションの図形にアニメーション効果を追加する方法を学びました。以下のサンプルコードは、プレゼンテーション `AnimExample_out.pptx` の最初の通常スライド上の最初の図形に適用された効果を取得する方法を示しています。
```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // スライドのメインアニメーションシーケンスを取得します。
    var sequence = firstSlide.getTimeline().getMainSequence();

    // 最初のスライド上の最初の図形を取得します。
    var shape = firstSlide.getShapes().get_Item(0);

    // 図形に適用されたアニメーション効果を取得します。
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


**例 2: プレースホルダーから継承されたものを含むすべてのアニメーション効果の取得**

通常スライド上の図形に、レイアウトスライドやマスタースライド上のプレースホルダーがあり、これらのプレースホルダーにアニメーション効果が追加されている場合、スライドショー中に図形のすべての効果が再生されます。これにはプレースホルダーから継承された効果も含まれます。

たとえば、`sample.pptx` という PowerPoint プレゼンテーションに、フッター形状のみが含まれ、テキスト「Made with Aspose.Slides」に **Random Bars** 効果が適用されているとします。

![スライド形状アニメーション効果](slide-shape-animation.png)

さらに、レイアウトスライドのフッター プレースホルダーに **Split** 効果が適用されているとします。

![レイアウト形状アニメーション効果](layout-shape-animation.png)

最後に、マスタースライドのフッター プレースホルダーに **Fly In** 効果が適用されているとします。

![マスタ形状アニメーション効果](master-shape-animation.png)

以下のサンプルコードは、[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) クラスの `getBasePlaceholder` メソッドを使用して形状プレースホルダーにアクセスし、レイアウトおよびマスタースライド上のプレースホルダーから継承されたものを含むフッター形状に適用されたアニメーション効果を取得する方法を示しています。
```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// 通常スライド上の図形のアニメーション効果を取得します。
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// レイアウトスライド上のプレースホルダーのアニメーション効果を取得します。
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// マスタースライド上のプレースホルダーのアニメーション効果を取得します。
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```

```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```


Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // フライ, ボトム
Type: 134, subtype: 45            // スプリット, 垂直イン
Type: 126, subtype: 22            // ランダムバー, 水平
```


## **アニメーション効果のタイミングプロパティの変更**

Aspose.Slides for Node.js via Java を使用すると、アニメーション効果のタイミングプロパティを変更できます。

この画像は Microsoft PowerPoint のアニメーションタイミング ペインです:

![Microsoft PowerPoint のアニメーションタイミング ペイン](shape-animation.png)

以下は PowerPoint のタイミングと [Effect.Timing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Effect#getTiming--) プロパティの対応です:

- PowerPoint のタイミング **Start** ドロップダウンは [Effect.Timing.TriggerType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getTriggerType--) プロパティに対応します。
- PowerPoint のタイミング **Duration** は [Effect.Timing.Duration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getDuration--) プロパティに対応します。アニメーションの継続時間（秒）は、アニメーションが 1 サイクルを完了するのに要する総時間です。
- PowerPoint のタイミング **Delay** は [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--) プロパティに対応します。

タイミングプロパティを変更する手順:

1. [Apply](#apply-animation-to-shape) するか、アニメーション効果を取得します。
2. 必要な [Effect.Timing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Effect#getTiming--) プロパティに新しい値を設定します。
3. 変更した PPTX ファイルを保存します。

この Javascript コードは操作を示しています:
```javascript
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを生成します。
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // スライドのメインシーケンスを取得します。
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // メインシーケンスの最初のエフェクトを取得します。
    var effect = sequence.get_Item(0);
    // エフェクトの TriggerType をクリック時開始に変更します。
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // エフェクトの Duration を変更します。
    effect.getTiming().setDuration(3.0);
    // エフェクトの TriggerDelayTime を変更します。
    effect.getTiming().setTriggerDelayTime(0.5);
    // PPTX ファイルをディスクに保存します。
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **アニメーション効果のサウンド**

Aspose.Slides は、アニメーション効果のサウンドを操作するための次のプロパティを提供します:

- [setSound(IAudio value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **アニメーション効果のサウンド追加**

この Javascript コードは、アニメーション効果のサウンドを追加し、次の効果が開始するときにサウンドを停止する方法を示しています:
```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // プレゼンテーションのオーディオコレクションに音声を追加します
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // スライドのメインシーケンスを取得します。
    var sequence = firstSlide.getTimeline().getMainSequence();
    // メインシーケンスの最初のエフェクトを取得します
    var firstEffect = sequence.get_Item(0);
    // エフェクトが「サウンドなし」かチェックします
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // 最初のエフェクトにサウンドを追加します
        firstEffect.setSound(effectSound);
    }
    // スライドの最初のインタラクティブシーケンスを取得します。
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // エフェクトの「前のサウンドを停止」フラグを設定します
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // PPTX ファイルをディスクに保存します
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **アニメーション効果のサウンド抽出**

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。 
3. メインのエフェクトシーケンスを取得します。 
4. 各アニメーション効果に埋め込まれた [setSound(IAudio value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) を抽出します。

この Javascript コードは、アニメーション効果に埋め込まれたサウンドを抽出する方法を示しています:
```javascript
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // スライドのメインシーケンスを取得します。
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // エフェクトのサウンドをバイト配列で抽出します
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **アフター アニメーション**

Aspose.Slides for Node.js via Java を使用すると、アニメーション効果の After animation プロパティを変更できます。

この画像は Microsoft PowerPoint のアニメーション効果ペインと拡張メニューです:

![Microsoft PowerPoint のアニメーション効果ペインと拡張メニュー](shape-after-animation.png)

PowerPoint の **After animation** ドロップダウンは次のプロパティに対応します:

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) メソッドは After animation タイプを指定します。
  * PowerPoint の **More Colors** は [AfterAnimationType.Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#Color) タイプに対応します。
  * PowerPoint の **Don't Dim** は [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) タイプ（デフォルト）に対応します。
  * PowerPoint の **Hide After Animation** は [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation) タイプに対応します。
  * PowerPoint の **Hide on Next Mouse Click** は [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) タイプに対応します。
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) メソッドは After animation のカラー形式を定義します。このメソッドは [AfterAnimationType.Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#Color) タイプと組み合わせて使用します。別のタイプに変更するとカラーはクリアされます。

この Javascript コードは After animation 効果を変更する方法を示しています:
```javascript
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // メインシーケンスの最初のエフェクトを取得します
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // 後のアニメーションのタイプを Color に変更します
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // 後のアニメーションのカラーを設定します
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // PPTX ファイルをディスクに保存します
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テキストのアニメーション**

Aspose.Slides は、アニメーション効果の *Animate text* ブロックを操作するために次のプロパティを提供します:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) はテキストのアニメーションタイプを指定します。テキストは次のいずれかでアニメーション化できます:
  - All at once ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce) タイプ)
  - By word ([AnimateTextType.ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#ByWord) タイプ)
  - By letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#ByLetter) タイプ)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) はアニメーション化されたテキスト部分（単語または文字）間の遅延を設定します。正の値は効果の継続時間の割合、負の値は秒単位の遅延を表します。

テキストアニメーションプロパティを変更する手順:

1. [Apply](#apply-animation-to-shape) するか、アニメーション効果を取得します。
2. `BuildType.AsOneObject` 値を使用して `setBuildType(int value)` メソッドを呼び出し、*By Paragraphs* アニメーションモードをオフにします。
3. 新しい [setAnimateTextType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) と [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) の値を設定します。
4. 変更した PPTX ファイルを保存します。

この Javascript コードは操作を示しています:
```javascript
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // メインシーケンスの最初のエフェクトを取得します
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // エフェクトのテキストアニメーションタイプを「As One Object」に変更します
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // エフェクトのアニメートテキストタイプを「By word」に変更します
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // 単語間の遅延を効果時間の20%に設定します
    firstEffect.setDelayBetweenTextParts(20.0);
    // PPTX ファイルをディスクに保存します
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**プレゼンテーションを Web に公開する際に、アニメーションを保持するにはどうすればよいですか？**

[HTML5 にエクスポート](/slides/ja/nodejs-java/export-to-html5/)し、[shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimateshapes/) と [transition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimatetransitions/) アニメーションを有効にするオプションを設定します。普通の HTML ではスライド アニメーションは再生されませんが、HTML5 では再生されます。

**図形の Z オーダー（レイヤー順）を変更すると、アニメーションにどのような影響がありますか？**

アニメーションと描画順序は独立しています。効果は表示・非表示のタイミングと種類を制御し、[z-order](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getzorderposition/) は何が何を覆うかを決定します。最終的な見た目は両者の組み合わせで決まります。（これは一般的な PowerPoint の動作であり、Aspose.Slides の効果と形状のモデルも同様です。）

**特定の効果をビデオに変換する際に、制限はありますか？**

一般に[アニメーションはサポート](/slides/ja/nodejs-java/convert-powerpoint-to-video/)されていますが、稀なケースや特定の効果は異なる形でレンダリングされることがあります。使用する効果とライブラリのバージョンでテストすることを推奨します。