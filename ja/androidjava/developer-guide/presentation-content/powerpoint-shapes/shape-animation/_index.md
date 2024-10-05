---
title: シェイプアニメーション
type: docs
weight: 60
url: /androidjava/shape-animation/
keywords: "PowerPointアニメーション, アニメーション効果, アニメーションの適用, PowerPointプレゼンテーション, Java, Aspose.Slides for Android via Java"
description: "JavaでPowerPointアニメーションを適用する"
---

アニメーションは、テキスト、画像、シェイプ、または[チャート](https://docs.aspose.com/slides/androidjava/animated-charts/)に適用できる視覚効果です。これらはプレゼンテーションやその構成要素に命を吹き込みます。

### **プレゼンテーションでアニメーションを使用する理由**

アニメーションを使用すると、 

* 情報の流れを制御できる
* 重要なポイントを強調できる
* 聴衆の興味や参加を高めることができる
* コンテンツを読みやすく、理解しやすくする
* プレゼンテーションの重要な部分に読者や視聴者の注意を引くことができる

PowerPointは、**入り**、**退出**、**強調**、および**動きの経路**カテゴリ全体にわたるアニメーションとアニメーション効果のための多くのオプションとツールを提供しています。

### **Aspose.Slidesにおけるアニメーション**

* Aspose.Slidesは、`Aspose.Slides.Animation`名前空間の下でアニメーションに必要なクラスと型を提供します。
* Aspose.Slidesは、[EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype)列挙型の下で150以上のアニメーション効果を提供します。これらの効果は、基本的にPowerPointで使用される同じ（または同等の）効果です。

## **テキストボックスにアニメーションを適用する**

Aspose.Slides for Android via Javaを使用すると、シェイプ内のテキストにアニメーションを適用できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape)を追加します。
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-)にテキストを追加します。
5. 効果のメインシーケンスを取得します。
6. [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape)にアニメーション効果を追加します。
7. `TextAnimation.BuildType`プロパティを`BuildType`列挙型からの値に設定します。
8. プレゼンテーションをPPTXファイルとしてディスクに保存します。

このJavaコードは、`Fade`効果をAutoShapeに適用し、テキストアニメーションを*1段落ごと*の値に設定する方法を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // テキスト付きの新しいAutoShapeを追加します
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("最初の段落 \n2番目の段落 \n3番目の段落");

    // スライドのメインシーケンスを取得します。
    ISequence sequence = sld.getTimeline().getMainSequence();

    // シェイプにFadeアニメーション効果を追加します
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 1段階の段落ごとにシェイプテキストをアニメーション化します
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // PPTXファイルをディスクに保存します
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

テキストにアニメーションを適用するだけでなく、単一の[段落](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph)にもアニメーションを適用できます。詳しくは[**アニメーションテキスト**](/slides/androidjava/animated-text/)を参照してください。

{{% /alert %}} 

## **PictureFrameにアニメーションを適用する**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. スライド上に[PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe)を追加または取得します。
4. 効果のメインシーケンスを取得します。
5. [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe)にアニメーション効果を追加します。
6. プレゼンテーションをPPTXファイルとしてディスクに保存します。

このJavaコードは、ピクチャフレームに`Fly`効果を適用する方法を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
Presentation pres = new Presentation();
try {
    // プレゼンテーションの画像コレクションに追加する画像を読み込みます
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // スライドに画像フレームを追加します
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // スライドのメインシーケンスを取得します。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // 画像フレームに左からの飛び出しアニメーション効果を追加します
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTXファイルをディスクに保存します
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **シェイプにアニメーションを適用する**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape)を追加します。
4. `Bevel` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape)を追加します（このオブジェクトがクリックされるとアニメーションが再生されます）。
5. ビベルシェイプの効果のシーケンスを作成します。
6. カスタム`UserPath`を作成します。
7. `UserPath`への移動コマンドを追加します。
8. プレゼンテーションをPPTXファイルとしてディスクに保存します。

このJavaコードは、シェイプに`PathFootball`（パスフットボール）効果を適用する方法を示しています：

```java
// PPTXファイルを表すプレゼンテーションクラスのインスタンスを作成します。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 既存のシェイプのためにPathFootball効果をゼロから作成します。
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("アニメーションテキストボックス");

    // PathFootBallアニメーション効果を追加します
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 何らかの「ボタン」を作成します。
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // このボタンのために効果のシーケンスを作成します。
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // カスタムユーザーパスを作成します。 私たちのオブジェクトはボタンがクリックされるまで移動しません。
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // 作成したパスが空であるため、移動のためのコマンドを追加します。
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // PPTXファイルをディスクに保存します
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **シェイプに適用されたアニメーション効果を取得する**

単一のシェイプに適用されたすべてのアニメーション効果を確認したい場合があります。 

このJavaコードは、特定のシェイプに適用されたすべての効果を取得する方法を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // スライドのメインシーケンスを取得します。
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

Aspose.Slides for Android via Javaを使用すると、アニメーション効果のタイミングプロパティを変更できます。

これはMicrosoft PowerPointのアニメーションタイミングペインです：

![example1_image](shape-animation.png)

これらは、PowerPointタイミングと[Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--)プロパティの対応関係です：

- PowerPointタイミングの**開始**ドロップダウンリストは、[Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--)プロパティに対応します。
- PowerPointタイミングの**持続時間**は、[Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--)プロパティに対応します。アニメーションの持続時間（秒単位）は、アニメーションが1サイクルを完了するのにかかる合計時間です。
- PowerPointタイミングの**遅延**は、[Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--)プロパティに対応します。

効果のタイミングプロパティを変更する方法は次のとおりです：

1. [アニメーションを適用](#apply-animation-to-shape)するか、アニメーション効果を取得します。
2. 必要な[Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--)プロパティに新しい値を設定します。
3. 修正されたPPTXファイルを保存します。

このJavaコードは操作を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // スライドのメインシーケンスを取得します。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // メインシーケンスの最初の効果を取得します。
    IEffect effect = sequence.get_Item(0);

    // 効果のTriggerTypeをクリックで開始するように変更します
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // 効果の持続時間を変更します
    effect.getTiming().setDuration(3f);

    // 効果のTriggerDelayTimeを変更します
    effect.getTiming().setTriggerDelayTime(0.5f);

    // PPTXファイルをディスクに保存します
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **アニメーション効果の音声**

Aspose.Slidesは、アニメーション効果の音声を操作するためのプロパティを提供します：

- [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **アニメーション効果の音声を追加する**

このJavaコードは、アニメーション効果の音声を追加し、次の効果が開始されたときにそれを停止する方法を示しています：

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // プレゼンテーションの音声コレクションに音声を追加します
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // スライドのメインシーケンスを取得します。
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // メインシーケンスの最初の効果を取得します
    IEffect firstEffect = sequence.get_Item(0);

    // "音声なし"の効果を確認します
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // 最初の効果のために音を追加します
        firstEffect.setSound(effectSound);
    }

    // スライドの最初のインタラクティブシーケンスを取得します。
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // 効果の「前の音声を停止」のフラグを設定します
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // PPTXファイルをディスクに保存します
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **アニメーション効果の音声を抽出する**

1. [Presentation](https://reference.aspose.com/slides/androidjava/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. 効果のメインシーケンスを取得します。 
4. 各アニメーション効果に埋め込まれた[setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)を抽出します。

このJavaコードは、アニメーション効果に埋め込まれた音声を抽出する方法を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // スライドのメインシーケンスを取得します。
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // 効果の音声をバイト配列として抽出します
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **アニメーションの後**

Aspose.Slides for Android via Javaを使用すると、アニメーション効果の*後*のプロパティを変更できます。

これはMicrosoft PowerPointのアニメーション効果ペインと拡張メニューです：

![example1_image](shape-after-animation.png)

PowerPoint効果の**アニメーション後**ドロップダウンリストは、以下のプロパティに対応します：

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-)プロパティで、アニメーション後のタイプを説明します：
  * PowerPointの**その他の色**は、[AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color)タイプに対応します。
  * PowerPointの**ぼかさない**リスト項目は、[AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim)タイプに対応します（デフォルトのアニメーション後のタイプ）。
  * PowerPointの**アニメーション後に非表示**項目は、[AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation)タイプに対応します。
  * PowerPointの**次のマウスクリックで非表示**項目は、[AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick)タイプに対応します。
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-)プロパティは、アニメーション後の色形式を定義します。このプロパティは、[AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color)タイプと連動して機能します。タイプを別のものに変更すると、アニメーション後の色はクリアされます。

このJavaコードは、アニメーション後の効果を変更する方法を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // メインシーケンスの最初の効果を取得します
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // アニメーション後のタイプを色に変更します
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // アニメーション後のぼかし色を設定します
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // PPTXファイルをディスクに保存します
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストをアニメーション化する**

Aspose.Slidesは、アニメーション効果の*テキストをアニメーション化*ブロックを操作するためのプロパティを提供します：

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-)は、効果のアニメートテキストタイプを説明します。シェイプのテキストは以下の方法でアニメーション化できます：
  - 一度にすべて（[AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce)タイプ）
  - 単語ごと（[AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord)タイプ）
  - 文字ごと（[AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter)タイプ）
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-)は、アニメートされたテキスト部分（単語または文字）間の遅延を設定します。正の値は効果持続時間の割合を指定し、負の値は秒単位の遅延を指定します。

これが、効果のテキストをアニメーション化のプロパティを変更する方法です：

1. [アニメーションを適用](#apply-animation-to-shape)するか、アニメーション効果を取得します。
2. [setBuildType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-)プロパティを[BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject)値に設定し、*段落ごと*アニメーションモードをオフにします。
3. 新しい値を[setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-)と[setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-)プロパティに設定します。
4. 修正されたPPTXファイルを保存します。

このJavaコードは操作を示しています：

```java
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // メインシーケンスの最初の効果を取得します
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // 効果のテキストアニメーションタイプを「1つのオブジェクト」として変更します
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // 効果のアニメートテキストタイプを「単語ごと」に変更します
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // 単語間の遅延を効果の持続時間の20%に設定します
    firstEffect.setDelayBetweenTextParts(20f);

    // PPTXファイルをディスクに保存します
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```