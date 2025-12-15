---
title: Android でのプレゼンテーションにおけるシェイプ アニメーションの適用
linktitle: シェイプ アニメーション
type: docs
weight: 60
url: /ja/androidjava/shape-animation/
keywords:
- シェイプ
- アニメーション
- 効果
- アニメーション シェイプ
- アニメーション テキスト
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
description: "Aspose.Slides for Android via Java を使用して、PowerPoint プレゼンテーションでシェイプ アニメーションを作成およびカスタマイズする方法を学びましょう。際立ちましょう！"
---

アニメーションは、テキスト、画像、図形、または[チャート](https://docs.aspose.com/slides/androidjava/animated-charts/)に適用できる視覚効果です。プレゼンテーションやその構成要素に命を吹き込みます。

## **プレゼンテーションでアニメーションを使用する理由**

アニメーションを使用すると

* 情報の流れを制御する
* 重要なポイントを強調する
* 聴衆の関心や参加を高める
* コンテンツを読みやすく、理解しやすく、処理しやすくする
* 読者や視聴者の注意をプレゼンテーションの重要な部分へ引きつける

PowerPoint は、**entrance**、**exit**、**emphasis**、**motion paths** カテゴリにわたるアニメーションとアニメーション効果の多くのオプションとツールを提供しています。

## **Aspose.Slides のアニメーション**

* Aspose.Slides は、`Aspose.Slides.Animation` 名前空間でアニメーションを操作するために必要なクラスと型を提供します。
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype) 列挙体で **150** 以上のアニメーション効果を提供します。これらの効果は、実質的に PowerPoint で使用される効果と同じ（または同等）です。

## **テキストボックスへのアニメーションの適用**

Aspose.Slides for Android via Java では、図形内のテキストにアニメーションを適用できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライド参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) を追加します。
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) にテキストを追加します。
5. メインの効果シーケンスを取得します。
6. [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) にアニメーション効果を追加します。
7. `TextAnimation.BuildType` プロパティを `BuildType` 列挙体の値に設定します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この Java コードは、`Fade` 効果を AutoShape に適用し、テキストアニメーションを *By 1st Level Paragraphs* の値に設定する方法を示しています。
```java
// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // テキスト付きの新しい AutoShape を追加します
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // スライドのメインシーケンスを取得します。
    ISequence sequence = sld.getTimeline().getMainSequence();

    // シェイプに Fade アニメーション効果を追加します
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // シェイプのテキストを第1レベルの段落でアニメーションします
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // PPTX ファイルをディスクに保存します
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert color="primary"  %}} 
テキストへのアニメーション適用に加えて、単一の[Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph)にもアニメーションを適用できます。詳しくは[**Animated Text**](/slides/ja/androidjava/animated-text/)をご覧ください。
{{% /alert %}} 

## **PictureFrame へのアニメーションの適用**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライド参照を取得します。
3. スライド上に [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) を追加または取得します。
4. メインの効果シーケンスを取得します。
5. [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) にアニメーション効果を追加します。
6. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この Java コードは、`Fly` 効果を picture frame に適用する方法を示しています。
```java
// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
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

    // スライドにピクチャーフレームを追加します
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // スライドのメインシーケンスを取得します。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // ピクチャーフレームに左からのFlyアニメーション効果を追加します
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX ファイルをディスクに保存します
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Shape へのアニメーションの適用**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライド参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) を追加します。
4. `Bevel` の [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) を追加します（このオブジェクトがクリックされるとアニメーションが再生されます）。
5. Bevel 図形上に効果シーケンスを作成します。
6. カスタムの `UserPath` を作成します。
7. `UserPath` への移動コマンドを追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この Java コードは、`PathFootball`（path football）効果を shape に適用する方法を示しています。
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 既存のシェイプに対して最初から PathFootball 効果を作成します。
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // PathFootBall アニメーション効果を追加します
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 種類の「ボタン」を作成します。
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // このボタン用の効果シーケンスを作成します。
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // カスタム ユーザーパスを作成します。オブジェクトはボタンがクリックされた後にのみ移動します。
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // 作成されたパスが空なので、移動コマンドを追加します。
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // PPTX ファイルをディスクに保存します
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Shape に適用されたアニメーション効果の取得**

以下の例は、[ISequence](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isequence/) インターフェイスの `getEffectsByShape` メソッドを使用して、shape に適用されたすべてのアニメーション効果を取得する方法を示します。

**例 1: 通常スライド上の Shape に適用されたアニメーション効果の取得**

以前、PowerPoint プレゼンテーションの shape にアニメーション効果を追加する方法を学びました。以下のサンプルコードは、プレゼンテーション `AnimExample_out.pptx` の最初の通常スライドの最初の shape に適用された効果を取得する方法を示します。
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

通常スライド上の図形に、レイアウトスライドやマスタースライド上のプレースホルダーがあり、これらのプレースホルダーにアニメーション効果が追加されている場合、スライドショー中にその図形はプレースホルダーから継承された効果も含めてすべての効果が再生されます。

PowerPoint プレゼンテーション ファイル `sample.pptx` があり、1枚のスライドにフッターの図形だけがあり、テキストは「Made with Aspose.Slides」で、**Random Bars** 効果がその図形に適用されているとします。

![Slide shape animation effect](slide-shape-animation.png)

さらに、**layout** スライドのフッタープレースホルダーに **Split** 効果が適用されていると仮定します。

![Layout shape animation effect](layout-shape-animation.png)

最後に、**master** スライドのフッタープレースホルダーに **Fly In** 効果が適用されているとします。

![Master shape animation effect](master-shape-animation.png)

以下のサンプルコードは、[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) インターフェイスの `getBasePlaceholder` メソッドを使用して shape のプレースホルダーにアクセスし、レイアウトおよびマスター スライド上のプレースホルダーから継承されたものを含めてフッター shape に適用されたアニメーション効果を取得する方法を示します。
```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
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

Aspose.Slides for Android via Java では、アニメーション効果の Timing プロパティを変更できます。

これは Microsoft PowerPoint のアニメーションタイミング パネルです：

![example1_image](shape-animation.png)

PowerPoint の Timing と [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) プロパティの対応関係は次のとおりです。

- PowerPoint の Timing **Start** ドロップダウンリストは、[Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--) プロパティと一致します。
- PowerPoint の Timing **Duration** は、[Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--) プロパティと一致します。アニメーションの継続時間（秒）は、アニメーションが 1 サイクルを完了するのに要する合計時間です。
- PowerPoint の Timing **Delay** は、[Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) プロパティと一致します。

Effect Timing プロパティを変更する手順は次のとおりです。

1. [Apply](#apply-animation-to-shape) またはアニメーション効果を取得します。
2. 必要な [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) プロパティに新しい値を設定します。
3. 変更された PPTX ファイルを保存します。

この Java コードは操作を示しています。
```java
// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // スライドのメイン シーケンスを取得します。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // メイン シーケンスの最初の効果を取得します。
    IEffect effect = sequence.get_Item(0);

    // 効果の TriggerType をクリックで開始するように変更します。
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // 効果の Duration（継続時間）を変更します。
    effect.getTiming().setDuration(3f);

    // 効果の TriggerDelayTime（トリガー遅延時間）を変更します。
    effect.getTiming().setTriggerDelayTime(0.5f);

    // PPTX ファイルをディスクに保存します。
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **アニメーション効果サウンド**

Aspose.Slides は、アニメーション効果のサウンドを操作するために次のプロパティを提供します。

- [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) - アニメーション効果のサウンドを設定します。
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-) - 前のサウンドを停止するかを設定します。

### **アニメーション効果サウンドの追加**

この Java コードは、アニメーション効果サウンドを追加し、次の効果が開始するときにサウンドを停止する方法を示しています。
```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // プレゼンテーションのオーディオコレクションにオーディオを追加します
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // スライドのメインシーケンスを取得します。
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // メインシーケンスの最初の効果を取得します
    IEffect firstEffect = sequence.get_Item(0);

    // 効果が「無音」かチェックします
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // 最初の効果にサウンドを追加します
        firstEffect.setSound(effectSound);
    }

    // スライドの最初のインタラクティブシーケンスを取得します。
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // 効果の「前のサウンドを停止」フラグを設定します
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // PPTX ファイルをディスクに保存します
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **アニメーション効果サウンドの抽出**

1. [Presentation](https://reference.aspose.com/slides/androidjava/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. メインの効果シーケンスを取得します。
4. 各アニメーション効果に埋め込まれた [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) を抽出します。

この Java コードは、アニメーション効果に埋め込まれたサウンドを抽出する方法を示しています。
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

        // エフェクトのサウンドをバイト配列として抽出します
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **アニメーション後**

Aspose.Slides for Android via Java では、アニメーション効果の After animation プロパティを変更できます。

これは Microsoft PowerPoint のアニメーション効果パネルと拡張メニューです：

![example1_image](shape-after-animation.png)

PowerPoint の Effect **After animation** ドロップダウンリストは、以下のプロパティに対応しています：

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) プロパティは After animation のタイプを示します：
  * PowerPoint **More Colors** は、[AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) タイプに一致します；
  * PowerPoint **Don't Dim** は、[AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) タイプに一致します（デフォルトの After animation タイプ）；
  * PowerPoint **Hide After Animation** は、[AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) タイプに一致します；
  * PowerPoint **Hide on Next Mouse Click** は、[AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) タイプに一致します；
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) プロパティは After animation のカラー形式を定義します。このプロパティは [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) タイプと組み合わせて使用されます。別のタイプに変更すると、After animation のカラーはクリアされます。

この Java コードは After animation 効果を変更する方法を示しています。
```java
// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // メインシーケンスの最初の効果を取得します
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // アフターアニメーションのタイプを Color に変更します
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // アフターアニメーションの暗転カラーを設定します
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // PPTX ファイルをディスクに書き込みます
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストのアニメーション**

Aspose.Slides は、アニメーション効果の *Animate text* ブロックを操作するために次のプロパティを提供します。

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) は、効果のアニメートテキストタイプを指定します。形状のテキストは次のいずれかでアニメーションできます：
  * All at once（[AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) タイプ）
  * By word（[AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord) タイプ）
  * By letter（[AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter) タイプ）
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) は、アニメートされたテキスト部分（単語または文字）間の遅延を設定します。正の値は効果継続時間のパーセンテージを示し、負の値は秒単位の遅延を示します。

Effect Animate text プロパティを変更する手順は次のとおりです。

1. [Apply](#apply-animation-to-shape) またはアニメーション効果を取得します。
2. [BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject) の値を `setBuildType(int value)` に設定し、*By Paragraphs* アニメーションモードをオフにします。
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) と [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) プロパティに新しい値を設定します。
4. 変更された PPTX ファイルを保存します。

この Java コードは操作を示しています。
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

    // PPTX ファイルをディスクに書き込みます
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**プレゼンテーションを Web に公開するときにアニメーションを保持するにはどうすればよいですか？**

[Export to HTML5](/slides/ja/androidjava/export-to-html5/) を使用し、[options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) のうち [shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) と [transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) アニメーションを有効にします。プレーン HTML はスライドアニメーションを再生しませんが、HTML5 は再生します。

**図形の Z オーダー（レイヤー順）を変更するとアニメーションにどのような影響がありますか？**

アニメーションと描画順序は独立しています。効果は表示/非表示のタイミングとタイプを制御し、[z-order](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getZOrderPosition--) は何が何を覆うかを決定します。最終的な見た目は両者の組み合わせで定義されます。（これは一般的な PowerPoint の挙動であり、Aspose.Slides の効果と図形のモデルも同じロジックに従います。）

**特定の効果をビデオに変換する際に制限はありますか？**

一般的に[アニメーションはサポートされています](/slides/ja/androidjava/convert-powerpoint-to-video/)、ただし稀なケースや特定の効果は異なる方式でレンダリングされることがあります。使用する効果とライブラリのバージョンでテストすることを推奨します。