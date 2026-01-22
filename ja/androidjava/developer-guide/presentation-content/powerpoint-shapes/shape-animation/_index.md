---
title: Android のプレゼンテーションにシェイプアニメーションを適用
linktitle: シェイプアニメーション
type: docs
weight: 60
url: /ja/androidjava/shape-animation/
keywords:
- シェイプ
- アニメーション
- エフェクト
- アニメーションシェイプ
- アニメーションテキスト
- アニメーションを追加
- アニメーションを取得
- アニメーションを抽出
- エフェクトを追加
- エフェクトを取得
- エフェクトを抽出
- エフェクトサウンド
- アニメーションを適用
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint プレゼンテーションでシェイプアニメーションを作成およびカスタマイズする方法を発見できます。際立ちましょう！"
---

アニメーションはテキスト、画像、図形、または[チャート](https://docs.aspose.com/slides/androidjava/animated-charts/)に適用できる視覚効果です。プレゼンテーションやその構成要素に命を吹き込みます。

## **プレゼンテーションでアニメーションを使用する理由**

アニメーションを使用すると、以下が可能です
* 情報の流れを制御する
* 重要なポイントを強調する
* 聴衆の関心や参加を高める
* コンテンツを読みやすく、理解しやすく、処理しやすくする
* プレゼンテーションの重要な部分に読者や視聴者の注意を引く

PowerPoint は、**入口**、**終了**、**強調**、および**モーション パス**のカテゴリーにわたる、アニメーションおよびアニメーション効果のための多くのオプションとツールを提供します。 

## **Aspose.Slides のアニメーション**

* Aspose.Slides は、`Aspose.Slides.Animation` 名前空間下でアニメーションを操作するために必要なクラスと型を提供します。
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype) 列挙体で **150以上のアニメーション効果** を提供します。これらの効果は、実質的に PowerPoint で使用される効果と同じ（または同等）です。

## **テキストボックスへのアニメーションの適用**

Aspose.Slides for Android via Java を使用すると、シェイプ内のテキストにアニメーションを適用できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライド参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) を追加します。
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) にテキストを追加します。
5. メインのエフェクトシーケンスを取得します。
6. [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) にアニメーション効果を追加します。
7. `TextAnimation.BuildType` プロパティを `BuildType` 列挙体の値に設定します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この Java コードは、`Fade` 効果を AutoShape に適用し、テキストアニメーションを *By 1st Level Paragraphs* の値に設定する方法を示します:
```java
// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを生成します。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // テキスト付きの新しい AutoShape を追加します
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // スライドのメインシーケンスを取得します
    ISequence sequence = sld.getTimeline().getMainSequence();

    // シェイプに Fade アニメーション効果を追加します
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // シェイプのテキストを 1 レベル段落単位でアニメーション化します
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // PPTX ファイルをディスクに保存します
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert color="primary"  %}} 

テキストへのアニメーション適用に加えて、単一の[Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph) にもアニメーションを適用できます。 [**アニメーション テキスト**](/slides/ja/androidjava/animated-text/) を参照してください。

{{% /alert %}} 

## **PictureFrame へのアニメーションの適用**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライド参照を取得します。
3. スライドに [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) を追加または取得します。
4. メインのエフェクトシーケンスを取得します。
5. [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) にアニメーション効果を追加します。
6. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この Java コードは、`Fly` 効果を picture frame に適用する方法を示します:
```java
// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを生成します。
Presentation pres = new Presentation();
try {
    // プレゼンテーションの画像コレクションに追加する画像をロードします
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // スライドに画像フレームを追加します
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // スライドのメインシーケンスを取得します
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // 画像フレームに左からのフライ アニメーション効果を追加します
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX ファイルをディスクに保存します
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **シェイプへのアニメーションの適用**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライド参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) を追加します。
4. `Bevel` の [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) を追加します（このオブジェクトがクリックされると、アニメーションが再生されます）。
5. ベベル形状に対してエフェクトシーケンスを作成します。
6. カスタム `UserPath` を作成します。
7. `UserPath` への移動コマンドを追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この Java コードは、シェイプに `PathFootball`（パスフットボール）効果を適用する方法を示します:
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 既存のシェイプに対して PathFootball 効果を最初から作成します。
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // PathFootBall アニメーション効果を追加します
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 何らかの「ボタン」を作成します。
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // このボタン用のエフェクトシーケンスを作成します。
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // カスタムユーザーパスを作成します。オブジェクトはボタンがクリックされた後にのみ移動します。
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // 作成されたパスが空なので、移動コマンドを追加します。
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


## **シェイプに適用されたアニメーション効果の取得**

以下の例は、[ISequence](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isequence/) インターフェイスの `getEffectsByShape` メソッドを使用して、シェイプに適用されたすべてのアニメーション効果を取得する方法を示します。

**例 1: 通常スライド上のシェイプに適用されたアニメーション効果の取得**

以前、PowerPoint プレゼンテーションにアニメーション効果を追加する方法を学びました。以下のサンプルコードは、プレゼンテーション `AnimExample_out.pptx` の最初の通常スライド上の最初のシェイプに適用された効果を取得する方法を示します。
```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // スライドのメインアニメーションシーケンスを取得します。
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // 最初のスライド上の最初のシェイプを取得します。
    IShape shape = firstSlide.getShapes().get_Item(0);

    // シェイプに適用されたアニメーション効果を取得します。
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```


**例 2: プレースホルダーから継承されたものも含め、すべてのアニメーション効果の取得**

通常スライド上のシェイプがレイアウトスライドやマスタースライドにあるプレースホルダーを持ち、これらのプレースホルダーにアニメーション効果が追加されている場合、スライドショー中にシェイプのすべての効果が再生されます。これにはプレースホルダーから継承された効果も含まれます。

例として、`sample.pptx` という PowerPoint ファイルにフッターシェイプ（テキスト「Made with Aspose.Slides」）があり、**Random Bars** 効果がシェイプに適用されているとします。

![スライド形状アニメーション効果](slide-shape-animation.png)

さらに、**Split** 効果がレイアウトスライド上のフッタープレースホルダーに適用されているとします。

![レイアウト形状アニメーション効果](layout-shape-animation.png)

最後に、**Fly In** 効果がマスタースライド上のフッタープレースホルダーに適用されているとします。

![マスター形状アニメーション効果](master-shape-animation.png)

以下のサンプルコードは、[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) インターフェイスの `getBasePlaceholder` メソッドを使用してシェイプのプレースホルダーにアクセスし、レイアウトおよびマスタースライド上のプレースホルダーから継承されたものも含めてフッターシェイプに適用されたアニメーション効果を取得する方法を示します。
```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// 通常スライド上のシェイプのアニメーション効果を取得します。
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


出力:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **アニメーション効果のタイミングプロパティの変更**

Aspose.Slides for Android via Java を使用すると、アニメーション効果の Timing プロパティを変更できます。

Microsoft PowerPoint のアニメーションタイミング ペイン:

![Microsoft PowerPoint のアニメーションタイミング ペイン](shape-animation.png)

PowerPoint Timing **Start** ドロップダウン リストは [Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--) プロパティに対応します。  
PowerPoint Timing **Duration** は [Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--) プロパティに対応します。アニメーションの継続時間（秒）は、アニメーションが 1 サイクルを完了するのにかかる総時間です。  
PowerPoint Timing **Delay** は [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) プロパティに対応します。

Effect Timing プロパティの変更方法:

1. [シェイプへのアニメーションの適用](#apply-animation-to-shape) からアニメーション効果を取得または取得します。
2. 必要な [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) プロパティに新しい値を設定します。
3. 変更した PPTX ファイルを保存します。

この Java コードは操作を示します:
```java
// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを生成します。
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // スライドのメインシーケンスを取得します。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // メインシーケンスの最初の効果を取得します。
    IEffect effect = sequence.get_Item(0);

    // 効果の TriggerType をクリック時開始に変更します
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // 効果の Duration を変更します
    effect.getTiming().setDuration(3f);

    // 効果の TriggerDelayTime を変更します
    effect.getTiming().setTriggerDelayTime(0.5f);

    // PPTX ファイルをディスクに保存します
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **アニメーション効果のサウンド**

Aspose.Slides は、アニメーション効果のサウンドを操作するために以下のプロパティを提供します。

- [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **アニメーション効果のサウンドを追加**

この Java コードは、アニメーション効果のサウンドを追加し、次の効果が開始するときにサウンドを停止する方法を示します:
```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // プレゼンテーションのオーディオコレクションにオーディオを追加します
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // スライドのメインシーケンスを取得します
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // メインシーケンスの最初の効果を取得します
    IEffect firstEffect = sequence.get_Item(0);

    // 効果が「サウンドなし」かチェックします
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // 最初の効果にサウンドを追加します
        firstEffect.setSound(effectSound);
    }

    // スライドの最初のインタラクティブシーケンスを取得します
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // 効果の「前のサウンドを停止」フラグを設定します
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // PPTX ファイルをディスクに保存します
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **アニメーション効果のサウンドを抽出**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. メインのエフェクトシーケンスを取得します。
4. 各アニメーション効果に埋め込まれた [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) を抽出します。

この Java コードは、アニメーション効果に埋め込まれたサウンドを抽出する方法を示します:
```java
// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // スライドのメインシーケンスを取得します。
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // エフェクトサウンドをバイト配列で抽出します
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **アフター アニメーション**

Aspose.Slides for Android via Java を使用すると、アニメーション効果の After animation プロパティを変更できます。

Microsoft PowerPoint のアフター アニメーション ペイン:

![Microsoft PowerPoint のアフター アニメーション ペイン](shape-after-animation.png)

PowerPoint Effect **After animation** ドロップダウン リストは以下のプロパティに対応します:

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) プロパティは After animation のタイプを指定します:
  * PowerPoint **More Colors** は [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) タイプに対応します。
  * PowerPoint **Don't Dim** は [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) タイプ(デフォルト) に対応します。
  * PowerPoint **Hide After Animation** は [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) タイプに対応します。
  * PowerPoint **Hide on Next Mouse Click** は [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) タイプに対応します。
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) プロパティは After animation のカラー形式を定義します。このプロパティは [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) タイプと併用されます。別のタイプに変更すると、After animation のカラーはクリアされます。

この Java コードは、アフター アニメーション効果を変更する方法を示します:
```java
// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // メインシーケンスの最初の効果を取得します
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

Aspose.Slides は、アニメーション効果の *Animate text* ブロックを操作するために以下のプロパティを提供します。

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) は効果のアニメートテキストタイプを指定します。シェイプのテキストは次のようにアニメーションできます:
  - 全体同時 ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) タイプ)
  - 単語単位 ([AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord) タイプ)
  - 文字単位 ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter) タイプ)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) はアニメートテキストの各部分（単語または文字）間の遅延を設定します。正の値は効果継続時間のパーセンテージを示し、負の値は秒単位の遅延を示します。

Effect Animate text プロパティを変更する方法:

1. [シェイプへのアニメーションの適用](#apply-animation-to-shape) からアニメーション効果を取得または取得します。
2. `setBuildType(int value)` プロパティを [BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject) に設定し、*By Paragraphs* アニメーションモードをオフにします。
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) と [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) の新しい値を設定します。
4. 変更した PPTX ファイルを保存します。

この Java コードは操作を示します:
```java
// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // メインシーケンスの最初の効果を取得します
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // 効果のテキストアニメーションタイプを「As One Object」に変更します
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // 効果のアニメートテキストタイプを「By word」に変更します
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // 単語間の遅延を効果の継続時間の20%に設定します
    firstEffect.setDelayBetweenTextParts(20f);

    // PPTX ファイルをディスクに保存します
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**プレゼンテーションを Web に公開する際にアニメーションが保持されるようにするにはどうすればよいですか？**

[HTML5 へのエクスポート](/slides/ja/androidjava/export-to-html5/) を使用し、[shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) と [transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) アニメーションを有効にするオプションを設定します。プレーン HTML はスライドアニメーションを再生しませんが、HTML5 は再生します。

**シェイプの z 順序（レイヤー順序）を変更するとアニメーションにどのような影響がありますか？**

アニメーションと描画順序は独立しています。効果は出現/消失のタイミングとタイプを制御し、[z-order](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getZOrderPosition--) は何が何を覆うかを決定します。可視結果は両者の組み合わせで定義されます。（これは一般的な PowerPoint の動作であり、Aspose.Slides の効果とシェイプのモデルも同様のロジックに従います。）

**特定の効果をビデオに変換する際に制限がありますか？**

一般的に、[アニメーションはサポートされています](/slides/ja/androidjava/convert-powerpoint-to-video/)、しかし稀なケースや特定の効果は異なる形でレンダリングされることがあります。使用する効果とライブラリのバージョンでテストすることを推奨します。