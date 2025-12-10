---
title: Java を使用したプレゼンテーションへのシェイプ アニメーションの適用
linktitle: シェイプ アニメーション
type: docs
weight: 60
url: /ja/java/shape-animation/
keywords:
- シェイプ
- アニメーション
- 効果
- アニメーション シェイプ
- アニメーション テキスト
- アニメーションの追加
- アニメーションの取得
- アニメーションの抽出
- 効果の追加
- 効果の取得
- 効果の抽出
- 効果サウンド
- アニメーションの適用
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint プレゼンテーションのシェイプ アニメーションを作成およびカスタマイズする方法を紹介します。目立ちましょう！"
---

アニメーションは、テキスト、画像、図形、または[charts](https://docs.aspose.com/slides/java/animated-charts/)に適用できる視覚効果です。プレゼンテーションやその構成要素に命を吹き込みます。 

## **プレゼンテーションでアニメーションを使用する理由**

アニメーションを使用すると、以下が可能です

* 情報の流れを制御する
* 重要なポイントを強調する
* 聴衆の関心や参加意欲を高める
* コンテンツを読みやすく、理解しやすく、処理しやすくする
* プレゼンテーションの重要な部分に読者や視聴者の注意を引く

PowerPoint は、**入場**、**退出**、**強調**、および**モーション パス**のカテゴリにわたるアニメーションとアニメーション効果のための多数のオプションとツールを提供しています。 

## **Aspose.Slides のアニメーション**

* Aspose.Slides は、`Aspose.Slides.Animation` 名前空間の下でアニメーション操作に必要なクラスと型を提供します。
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype) 列挙体の下で **150 以上のアニメーション効果** を提供します。これらの効果は、基本的に PowerPoint で使用される効果と同じ（または同等）です。

## **テキストボックスへのアニメーションの適用**

Aspose.Slides for Java を使用すると、図形内のテキストにアニメーションを適用できます。 

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) を追加します。 
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) にテキストを追加します。 
5. メインのエフェクトシーケンスを取得します。
6. [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) にアニメーション効果を追加します。 
7. `TextAnimation.BuildType` プロパティを `BuildType` 列挙体の値に設定します。
8. プレゼンテーションを PPTX ファイルとしてディスクに保存します。

この Java コードは、AutoShape に `Fade` 効果を適用し、テキストアニメーションを *By 1st Level Paragraphs* の値に設定する方法を示しています。
```java
// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // テキスト付きの新しい AutoShape を追加します
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // スライドのメイン シーケンスを取得します。
    ISequence sequence = sld.getTimeline().getMainSequence();

    // シェイプに Fade アニメーション効果を追加します
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // シェイプのテキストを第 1 レベルの段落単位でアニメーション化します
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // PPTX ファイルをディスクに保存します
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert color="primary"  %}} 

テキストへのアニメーション適用に加えて、単一の [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph) にもアニメーションを適用できます。詳しくは[**Animated Text**](/slides/ja/java/animated-text/)をご覧ください。

{{% /alert %}} 

## **PictureFrame へのアニメーションの適用**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライド上に [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) を追加するか取得します。 
4. メインのエフェクトシーケンスを取得します。
5. [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) にアニメーション効果を追加します。
6. プレゼンテーションを PPTX ファイルとしてディスクに保存します。

この Java コードは、ピクチャーフレームに `Fly` 効果を適用する方法を示しています。
```java
// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します。
Presentation pres = new Presentation();
try {
    // プレゼンテーションの画像コレクションに追加する画像を読み込む
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // スライドに画像フレームを追加します
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // スライドのメイン シーケンスを取得します。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // 画像フレームに左から飛び込むアニメーション効果を追加します
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX ファイルをディスクに保存します
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **形状へのアニメーションの適用**

1. the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) を追加します。 
4. `Bevel` の [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) を追加します（このオブジェクトがクリックされるとアニメーションが再生されます）。
5. ベベル形状に対してエフェクトのシーケンスを作成します。
6. カスタムの `UserPath` を作成します。
7. `UserPath` への移動コマンドを追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに保存します。

この Java コードは、形状に `PathFootball`（パスフットボール）効果を適用する方法を示しています。
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 既存の図形に対して PathFootball 効果を最初から作成します。
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // PathFootball アニメーション効果を追加します
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 種類の「ボタン」を作成します。
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // このボタン用のエフェクトシーケンスを作成します。
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // カスタムユーザーパスを作成します。オブジェクトはボタンがクリックされた後にのみ移動します。
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // 作成したパスが空なので、移動コマンドを追加します。
    IMotionEffect motionBvh = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBvh.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // PPTX ファイルをディスクに書き込みます
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **形状に適用されたアニメーション効果の取得**

以下の例は、[ISequence](https://reference.aspose.com/slides/java/com.aspose.slides/isequence/) インターフェイスの `getEffectsByShape` メソッドを使用して、形状に適用されたすべてのアニメーション効果を取得する方法を示します。

**例 1: 通常スライド上の形状に適用されたアニメーション効果の取得**

以前、PowerPoint プレゼンテーションの形状にアニメーション効果を追加する方法を学びました。以下のサンプルコードは、プレゼンテーション `AnimExample_out.pptx` の最初の通常スライド上の最初の形状に適用された効果を取得する方法を示しています。
```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // スライドのメイン アニメーション シーケンスを取得します。
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // 最初のスライド上の最初の図形を取得します。
    IShape shape = firstSlide.getShapes().get_Item(0);

    // 図形に適用されたアニメーション効果を取得します。
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```


**例 2: プレースホルダーから継承されたものを含むすべてのアニメーション効果の取得**

通常スライド上の形状に、レイアウトスライドやマスタースライド上のプレースホルダーがあり、これらのプレースホルダーにアニメーション効果が追加されている場合、形状のすべての効果がスライドショー中に再生され、プレースホルダーから継承されたものも含まれます。

たとえば、`sample.pptx` という PowerPoint プレゼンテーションファイルがあり、1 枚のスライドにフッター形状だけが含まれ、テキストは "Made with Aspose.Slides" で、**Random Bars** 効果がその形状に適用されているとします。

![Slide shape animation effect](slide-shape-animation.png)

さらに、**layout** スライド上のフッタープレースホルダーに **Split** 効果が適用されているとします。

![Layout shape animation effect](layout-shape-animation.png)

最後に、**master** スライド上のフッタープレースホルダーに **Fly In** 効果が適用されているとします。

![Master shape animation effect](master-shape-animation.png)

以下のサンプルコードは、[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) インターフェイスの `getBasePlaceholder` メソッドを使用して形状プレースホルダーにアクセスし、レイアウトおよびマスタースライド上のプレースホルダーから継承されたものを含むフッター形状に適用されたアニメーション効果を取得する方法を示します。
```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// 通常スライド上の図形のアニメーション効果を取得します。
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// レイアウトスライド上のプレースホルダーのアニメーション効果を取得します。
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// マスタースライド上のプレースホルダーのアニメーション効果を取得します。
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```

```java
static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```


Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **アニメーション効果のタイミングプロパティの変更**

Aspose.Slides for Java を使用すると、アニメーション効果のタイミングプロパティを変更できます。

これは Microsoft PowerPoint のアニメーションタイミングペインです：

![example1_image](shape-animation.png)

以下は、PowerPoint のタイミングと [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) プロパティの対応関係です：

- PowerPoint タイミングの **Start** ドロップダウンリストは、[Effect.Timing.TriggerType](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerType--) プロパティに対応しています。 
- PowerPoint タイミングの **Duration** は、[Effect.Timing.Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getDuration--) プロパティに対応しています。アニメーションの持続時間（秒）は、アニメーションが 1 サイクルを完了するのに要する総時間です。 
- PowerPoint タイミングの **Delay** は、[Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerDelayTime--) プロパティに対応しています。 

Effect のタイミングプロパティを変更する手順は次のとおりです：

1. [Apply](#apply-animation-to-shape) またはアニメーション効果を取得します。 
2. 必要な [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) プロパティに新しい値を設定します。 
3. 変更した PPTX ファイルを保存します。

この Java コードは操作を実演しています：
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // スライドのメイン シーケンスを取得します。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // メイン シーケンスの最初のエフェクトを取得します。
    IEffect effect = sequence.get_Item(0);

    // エフェクトの TriggerType をクリックで開始するように変更します。
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // エフェクトの Duration を変更します。
    effect.getTiming().setDuration(3f);

    // エフェクトの TriggerDelayTime を変更します。
    effect.getTiming().setTriggerDelayTime(0.5f);

    // PPTX ファイルをディスクに保存します。
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **アニメーション効果のサウンド**

Aspose.Slides は、アニメーション効果のサウンドを扱うための以下のプロパティを提供しています：

- [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **アニメーション効果サウンドの追加**

この Java コードは、アニメーション効果のサウンドを追加し、次の効果が開始されたときにサウンドを停止する方法を示しています：
```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // プレゼンテーションのオーディオ コレクションにオーディオを追加します
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // スライドのメイン シーケンスを取得します。
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // メイン シーケンスの最初のエフェクトを取得します
    IEffect firstEffect = sequence.get_Item(0);

    // エフェクトに「サウンドなし」かどうかを確認します
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // 最初のエフェクトにサウンドを追加します
        firstEffect.setSound(effectSound);
    }

    // スライドの最初のインタラクティブ シーケンスを取得します。
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // エフェクトの「前のサウンドを停止」フラグを設定します
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // PPTX ファイルをディスクに保存します
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **アニメーション効果サウンドの抽出**

1. [Presentation](https://reference.aspose.com/slides/java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。 
3. メインのエフェクトシーケンスを取得します。 
4. 各アニメーション効果に埋め込まれた [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) を抽出します。 

この Java コードは、アニメーション効果に埋め込まれたサウンドを抽出する方法を示しています：
```java
// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // スライドのメイン シーケンスを取得します。
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // エフェクトのサウンドをバイト配列として抽出します。
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **アフター アニメーション**

Aspose.Slides for Java を使用すると、アニメーション効果の After animation プロパティを変更できます。

これは Microsoft PowerPoint のアニメーション効果ペインと拡張メニューです：

![example1_image](shape-after-animation.png)

PowerPoint の Effect **After animation** ドロップダウンリストは、以下のプロパティに対応しています：

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) プロパティは After animation のタイプを表します：
  * PowerPoint の **More Colors** は [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color) タイプに対応しています；
  * PowerPoint の **Don't Dim** は [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#DoNotDim) タイプに対応しています（デフォルトの After animation タイプ）；
  * PowerPoint の **Hide After Animation** は [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) タイプに対応しています；
  * PowerPoint の **Hide on Next Mouse Click** は [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) タイプに対応しています；
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) プロパティは After animation のカラー形式を定義します。このプロパティは [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color) タイプと連携して機能します。別のタイプに変更すると、After animation のカラーはクリアされます。 

この Java コードは、After animation 効果を変更する方法を示しています：
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // メインシーケンスの最初のエフェクトを取得します
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // アフターアニメーションのタイプを Color に変更します
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // アフターアニメーションの暗くなる色を設定します
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // PPTX ファイルをディスクに保存します
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストのアニメーション**

Aspose.Slides は、アニメーション効果の *Animate text* ブロックを操作するための以下のプロパティを提供しています：

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) は、効果のテキストアニメーションタイプを示します。図形のテキストは以下のようにアニメーション化できます：
  - 全体同時（[AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#AllAtOnce) タイプ）
  - 単語単位（[AnimateTextType.ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByWord) タイプ）
  - 文字単位（[AnimateTextType.ByLetter](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByLetter) タイプ）
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) は、アニメーション化されたテキスト部分（単語または文字）間の遅延を設定します。正の値は効果持続時間のパーセンテージを示し、負の値は秒単位の遅延を示します。

Effect の Animate text プロパティを変更する手順は次のとおりです：

1. [Apply](#apply-animation-to-shape) またはアニメーション効果を取得します。 
2. [setBuildType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/itextanimation/#setBuildType-int-) プロパティを [BuildType.AsOneObject](https://reference.aspose.com/slides/java/com.aspose.slides/buildtype/#AsOneObject) の値に設定し、*By Paragraphs* アニメーションモードをオフにします。 
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) と [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) プロパティに新しい値を設定します。 
4. 変更した PPTX ファイルを保存します。

この Java コードは操作を実演しています：
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // メイン シーケンスの最初のエフェクトを取得します
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // エフェクトのテキストアニメーションタイプを「As One Object」に変更します
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // エフェクトのアニメートテキストタイプを「By word」に変更します
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // 単語間の遅延をエフェクト期間の 20% に設定します
    firstEffect.setDelayBetweenTextParts(20f);

    // PPTX ファイルをディスクに保存します
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**プレゼンテーションを Web に公開する際にアニメーションが保持されるようにするにはどうすればよいですか？**

[Export to HTML5](/slides/ja/java/export-to-html5/) を使用し、[shape](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) および [transition](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) アニメーションを担当する [options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) を有効にします。プレーン HTML ではスライド アニメーションは再生されませんが、HTML5 では再生されます。

**形状の Z オーダー（レイヤー順）を変更すると、アニメーションにどのような影響がありますか？**

アニメーションの順序と描画順序は独立しています。エフェクトは出現/消失のタイミングと種類を制御し、[z-order](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getZOrderPosition--) は何が何を覆うかを決定します。可視結果は両者の組み合わせで決まります。（これは一般的な PowerPoint の動作であり、Aspose.Slides のエフェクトと形状のモデルも同じロジックに従います。）

**特定の効果をビデオに変換する際にアニメーションに制限はありますか？**

一般的に、[animations are supported](/slides/ja/java/convert-powerpoint-to-video/) ですが、稀なケースや特定の効果は異なる形でレンダリングされることがあります。使用する効果とライブラリのバージョンでテストすることを推奨します。