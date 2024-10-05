---
title: シェイプアニメーション
type: docs
weight: 60
url: /java/shape-animation/
keywords: "PowerPoint アニメーション, アニメーション効果, アニメーションの適用, PowerPoint プレゼンテーション, Java, Aspose.Slides for Java"
description: "Java で PowerPoint アニメーションを適用する"
---

アニメーションはテキスト、画像、シェイプ、または [チャート](https://docs.aspose.com/slides/java/animated-charts/) に適用できる視覚効果です。これにより、プレゼンテーションやその要素に命が吹き込まれます。

### **プレゼンテーションでアニメーションを使用する理由は？**

アニメーションを使用することで、

* 情報の流れを制御する
* 重要なポイントを強調する
* 聴衆の興味や参加を高める
* コンテンツを読みやすく、理解しやすくする
* プレゼンテーションの重要な部分に読者や視聴者の注意を引く

PowerPoint は **入口**、**出口**、**強調**、および **動きの経路** カテゴリにわたる多くのオプションとツールをアニメーションやアニメーション効果に提供しています。

### **Aspose.Slides におけるアニメーション**

* Aspose.Slides は、`Aspose.Slides.Animation` 名前空間の下でアニメーションを操作するために必要なクラスと型を提供します。
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype) 列挙型の下で **150 以上のアニメーション効果** を提供しています。これらの効果は、本質的に PowerPoint で使用される同じ（または同等の）効果です。

## **テキストボックスにアニメーションを適用する**

Aspose.Slides for Java を使用すると、シェイプのテキストにアニメーションを適用できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) を追加します。
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) にテキストを追加します。
5. 効果の主なシーケンスを取得します。
6. [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) にアニメーション効果を追加します。
7. `TextAnimation.BuildType` プロパティを `BuildType` 列挙型からの値に設定します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この Java コードは、`Fade` 効果を AutoShape に適用し、テキストアニメーションを *最初のレベルの段落ごとに* 設定する方法を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // テキスト付きの新しい AutoShape を追加
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("最初の段落 \n2 番目の段落 \n 3 番目の段落");

    // スライドの主なシーケンスを取得します。
    ISequence sequence = sld.getTimeline().getMainSequence();

    // シェイプに Fade アニメーション効果を追加
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 1st レベルの段落ごとにシェイプテキストにアニメーションを追加
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // PPTX ファイルをディスクに保存
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

テキストにアニメーションを適用するだけでなく、単一の [段落](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph) にもアニメーションを適用できます。See [**アニメーションテキスト**](/slides/java/animated-text/)。

{{% /alert %}} 

## **PictureFrame にアニメーションを適用する**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライドに [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) を追加または取得します。
4. 効果の主なシーケンスを取得します。
5. [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) にアニメーション効果を追加します。
6. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この Java コードは、画像フレームに `Fly` 効果を適用する方法を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
Presentation pres = new Presentation();
try {
    // プレゼンテーション画像コレクションに追加される画像をロードする
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // スライドにピクチャーフレームを追加
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // スライドの主なシーケンスを取得します。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // ピクチャーフレームに左からの Fly アニメーション効果を追加
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX ファイルをディスクに保存
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **シェイプにアニメーションを適用する**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) を追加します。
4. クリックされたときにアニメーションが再生される `Bevel` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) を追加します。
5. ベベルシェイプの効果のシーケンスを作成します。
6. カスタム `UserPath` を作成します。
7. `UserPath` への移動のためのコマンドを追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この Java コードは、シェイプに `PathFootball`（パスフットボール）効果を適用する方法を示しています：

```java
// PPTX ファイルを表すプレゼンテーションクラスをインスタンス化します。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 新しいシェイプの PathFootball 効果をゼロから作成します。
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("アニメーションテキストボックス");

    // PathFootBall アニメーション効果を追加
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 何らかの「ボタン」を作成します。
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // このボタンのための効果のシーケンスを作成します。
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

    // カスタムユーザーパスを作成します。私たちのオブジェクトはボタンがクリックされるまで移動しません。
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // 作成されたパスが空であるため、移動のためのコマンドを追加します。
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // PPTX ファイルをディスクに書き込みます
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **シェイプに適用されたアニメーション効果を取得する**

単一のシェイプに適用されたすべてのアニメーション効果を確認することができます。

この Java コードは、特定のシェイプに適用されたすべての効果を取得する方法を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // スライドの主なシーケンスを取得します。
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // スライドの最初のシェイプを取得します。
    IShape shape = firstSlide.getShapes().get_Item(0);

    // シェイプに適用されたすべてのアニメーション効果を取得します。
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("シェイプ " + shape.getName() + " には " + shapeEffects.length + " のアニメーション効果があります。");
} finally {
    if (pres != null) pres.dispose();
}
```

## **アニメーション効果のタイミングプロパティを変更する**

Aspose.Slides for Java を使用すると、アニメーション効果のタイミングプロパティを変更できます。

こちらは Microsoft PowerPoint のアニメーションタイミングパネルです：

![example1_image](shape-animation.png)

PowerPoint タイミングと [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) プロパティの対応関係は次の通りです：

- PowerPoint タイミング **開始** ドロップダウンリストは [Effect.Timing.TriggerType](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerType--) プロパティに対応します。
- PowerPoint タイミング **持続時間** は [Effect.Timing.Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getDuration--) プロパティに対応します。アニメーションの持続時間（秒単位）は、アニメーションが1サイクルを完了するのにかかる総時間です。
- PowerPoint タイミング **遅延** は [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerDelayTime--) プロパティに対応します。

次の手順でアニメーション効果のタイミングプロパティを変更します：

1. [アニメーションを適用](#apply-animation-to-shape)するか、アニメーション効果を取得します。
2. 必要な [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) プロパティに新しい値を設定します。
3. 修正された PPTX ファイルを保存します。

この Java コードは操作を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // スライドの主なシーケンスを取得します。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // 主なシーケンスの最初の効果を取得します。
    IEffect effect = sequence.get_Item(0);

    // 効果の TriggerType をクリック時に開始するように変更
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // 効果の持続時間を変更
    effect.getTiming().setDuration(3f);

    // 効果の TriggerDelayTime を変更
    effect.getTiming().setTriggerDelayTime(0.5f);

    // PPTX ファイルをディスクに保存
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **アニメーション効果の音声**

Aspose.Slides は、アニメーション効果の音声を操作するための次のプロパティを提供します：

- [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **アニメーション効果の音声を追加する**

この Java コードは、アニメーション効果の音声を追加し、次の効果が開始されるときに停止する方法を示しています：

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // プレゼンテーションの音声コレクションに音声を追加
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // スライドの主なシーケンスを取得します。
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // 主なシーケンスの最初の効果を取得
    IEffect firstEffect = sequence.get_Item(0);

    // 効果が「音なし」であるかをチェック
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // 最初の効果に音声を追加
        firstEffect.setSound(effectSound);
    }

    // スライドの最初のインタラクティブシーケンスを取得します。
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // 効果の「前の音を停止する」フラグを設定
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // PPTX ファイルをディスクに書き込みます
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **アニメーション効果の音声を抽出する**

1. [Presentation](https://reference.aspose.com/slides/java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。 
3. 効果の主なシーケンスを取得します。 
4. 各アニメーション効果に埋め込まれている [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) を抽出します。 

この Java コードは、アニメーション効果に埋め込まれた音声を抽出する方法を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // スライドの主なシーケンスを取得します。
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // 効果音をバイト配列で抽出
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **アニメーション後**

Aspose.Slides for Java は、アニメーション効果のアニメーション後プロパティを変更することを可能にします。

こちらは Microsoft PowerPoint のアニメーション効果パネルと拡張メニューです：

![example1_image](shape-after-animation.png)

PowerPoint 効果 **アニメーション後** ドロップダウンリストは、次のプロパティに対応します：

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-)プロパティは、アニメーション後のタイプを説明します：
  * PowerPoint **その他の色** は、[AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color) 型にマッチします。
  * PowerPoint **暗くしない** のリストアイテムは、[AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#DoNotDim) 型にマッチします（デフォルトのアニメーション後のタイプ）。
  * PowerPoint **アニメーション後に隠す** のアイテムは、[AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) 型にマッチします。
  * PowerPoint **次のマウスクリックで隠す** のアイテムは、[AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) 型にマッチします。
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) プロパティは、アニメーション後の色の形式を定義します。このプロパティは、[AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color) 型と連携して機能します。タイプを別のものに変更すると、アニメーション後の色はクリアされます。

この Java コードは、アニメーション後の効果を変更する方法を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 主なシーケンスの最初の効果を取得します
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // アニメーション後のタイプを色に変更
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // アニメーション後の暗くする色を設定
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // PPTX ファイルをディスクに保存
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストをアニメーションさせる**

Aspose.Slides は、アニメーション効果の *テキストをアニメーションさせる* ブロックを操作するための次のプロパティを提供します：

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) は、効果のアニメーションテキストのタイプを説明します。シェイプのテキストは次のようにアニメーションできます：
  - 一度にすべて ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#AllAtOnce) 型)
  - 単語ごとに ([AnimateTextType.ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByWord) 型)
  - 文字ごとに ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByLetter) 型)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) は、アニメーションテキスト部分（単語または文字）の間の遅延を設定します。正の値は効果の持続時間のパーセンテージを指定し、負の値は秒単位での遅延を指定します。

次の手順で効果のアニメーションテキストプロパティを変更できます：

1. [アニメーションを適用](#apply-animation-to-shape)するか、アニメーション効果を取得します。
2. [setBuildType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/itextanimation/#setBuildType-int-) プロパティを [BuildType.AsOneObject](https://reference.aspose.com/slides/java/com.aspose.slides/buildtype/#AsOneObject) 値に設定して、*段落ごとに* アニメーションモードをオフにします。
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) と [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) プロパティに新しい値を設定します。
4. 修正された PPTX ファイルを保存します。

この Java コードは操作を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 主なシーケンスの最初の効果を取得
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // 効果のテキストアニメーションタイプを「一つのオブジェクト」として変更
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // 効果のアニメーションテキストタイプを「単語ごと」に変更
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // 単語間の遅延を効果の持続時間の 20% に設定
    firstEffect.setDelayBetweenTextParts(20f);

    // PPTX ファイルをディスクに保存
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```