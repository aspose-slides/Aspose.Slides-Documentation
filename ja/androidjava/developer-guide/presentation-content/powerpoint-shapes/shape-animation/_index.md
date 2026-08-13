---
title: Android でプレゼンテーションにシェイプ アニメーションを適用する
linktitle: シェイプ アニメーション
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
description: "Aspose.Slides for Android via Java を使用して、PowerPoint プレゼンテーションでシェイプ アニメーションを作成およびカスタマイズする方法をご紹介します。目立ちましょう！"
---
## **はじめに**

アニメーションは、テキスト、画像、図形、または[チャート](https://docs.aspose.com/slides/ja/androidjava/animated-charts/)に適用できるビジュアルエフェクトです。プレゼンテーションやその構成要素に命を与えます。

## **なぜプレゼンテーションでアニメーションを使用するのか？**

* 情報の流れを制御する
* 重要なポイントを強調する
* 聴衆の関心や参加意欲を高める
* コンテンツを読みやすく、理解しやすく、または処理しやすくする
* 読者や視聴者の注意をプレゼンテーションの重要な部分に向ける

PowerPoint は、**入口**、**退出**、**強調**、**動きのパス** のカテゴリにわたるアニメーションとアニメーション効果のための多くのオプションとツールを提供します。

## **Aspose.Slides のアニメーション**

* Aspose.Slides は、`Aspose.Slides.Animation` 名前空間でアニメーションを操作するために必要なクラスと型を提供します、  
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/effecttype) 列挙体で **150 を超えるアニメーション効果** を提供します。これらの効果は本質的に PowerPoint で使用される効果と同じ（または同等）です。

## **テキストボックスへのアニメーションの適用**

Aspose.Slides for Android via Java は、図形内のテキストにアニメーションを適用できるようにします。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape) を追加します。
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) にテキストを追加します。
5. メインのエフェクトシーケンスを取得します。
6. [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape) にアニメーション効果を追加します。
7. `TextAnimation.BuildType` プロパティを `BuildType` 列挙体の値に設定します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この Java コードは、AutoShape に `Fade` 効果を適用し、テキストアニメーションを *By 1st Level Paragraphs* の値に設定する方法を示しています：

```java
import com.aspose.slides.*;

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

    // シェイプのテキストを第1レベルの段落単位でアニメーション化します。
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // PPTX ファイルをディスクに保存します。
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 
テキストへのアニメーション適用に加えて、単一の[Paragraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraph)にもアニメーションを適用できます。[**Animated Text**](/slides/ja/androidjava/animated-text/) を参照してください。
{{% /alert %}} 

## **PictureFrame へのアニメーションの適用**

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライド上に [PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe) を追加または取得します。
4. メインのエフェクトシーケンスを取得します。
5. [PictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pictureframe) にアニメーション効果を追加します。
6. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この Java コードは、picture frame に `Fly` 効果を適用する方法を示しています：

```java
import com.aspose.slides.*;

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

    // ピクチャーフレームに左からの Fly アニメーション効果を追加します
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX ファイルをディスクに保存します
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Shape へのアニメーションの適用**

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape) を追加します。
4. `Bevel` の [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape) を追加します（このオブジェクトがクリックされるとアニメーションが再生されます）。
5. Bevel 図形に対してエフェクトのシーケンスを作成します。
6. カスタム `UserPath` を作成します。
7. `UserPath` への移動コマンドを追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この Java コードは、shape に `PathFootball` (path football) 効果を適用する方法を示しています：

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 既存のシェイプに対して PathFootball 効果を最初から作成します。
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // PathFootball アニメーション効果を追加します
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 何らかの「ボタン」を作成します。
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // このボタン用のエフェクトシーケンスを作成します。
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // カスタムユーザーパスを作成します。オブジェクトはボタンがクリックされた後にのみ移動します。
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // 作成されたパスが空なので、移動コマンドを追加します。
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

## **Shape に適用されたアニメーション効果の取得**

以下の例は、[ISequence](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/) インターフェイスの `getEffectsByShape` メソッドを使用して、Shape に適用されたすべてのアニメーション効果を取得する方法を示しています。

**例 1: 通常のスライド上の Shape に適用されたアニメーション効果の取得**

以前、PowerPoint プレゼンテーションの図形にアニメーション効果を追加する方法を学びました。以下のサンプルコードは、プレゼンテーション `AnimExample_out.pptx` の最初の通常スライドの最初の図形に適用された効果を取得する方法を示しています。

```java
import com.aspose.slides.*;

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

**例 2: プレースホルダーから継承されたものも含め、すべてのアニメーション効果を取得**

通常スライド上の図形がレイアウトスライドやマスタースライド上のプレースホルダーを持ち、これらのプレースホルダーにアニメーション効果が追加されている場合、スライドショー中にその図形のすべての効果が再生され、プレースホルダーから継承された効果も含まれます。

`sample.pptx` という PowerPoint プレゼンテーションファイルがあり、1枚のスライドにフッターの図形だけが含まれ、テキストは "Made with Aspose.Slides" で、**Random Bars** 効果がその図形に適用されているとします。

![スライドの図形アニメーション効果](slide-shape-animation.png)

さらに、**layout** スライドのフッタープレースホルダーに **Split** 効果が適用されていると仮定します。

![レイアウトの図形アニメーション効果](layout-shape-animation.png)

そして最後に、**master** スライドのフッタープレースホルダーに **Fly In** 効果が適用されています。

![マスターの図形アニメーション効果](master-shape-animation.png)

以下のサンプルコードは、[IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) インターフェイスの `getBasePlaceholder` メソッドを使用して図形プレースホルダーにアクセスし、レイアウトおよびマスタースライド上のプレースホルダーから継承されたものも含めてフッター図形に適用されたアニメーション効果を取得する方法を示しています。

```java
import com.aspose.slides.*;

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
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

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

Aspose.Slides for Android via Java は、アニメーション効果の Timing プロパティを変更できます。

これは Microsoft PowerPoint のアニメーションタイミングペインです：

![アニメーションタイミングペイン](shape-animation.png)

PowerPoint の Timing **Start** ドロップダウンリストは [Effect.Timing.TriggerType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITiming#getTriggerType--) プロパティと一致します。

PowerPoint の Timing **Duration** は [Effect.Timing.Duration](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITiming#getDuration--) プロパティと一致します。アニメーションの期間（秒）は、アニメーションが1サイクルを完了するのにかかる総時間です。

PowerPoint の Timing **Delay** は [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) プロパティと一致します。

Effect の Timing プロパティを変更する方法は次のとおりです：

1. [Apply](#apply-animation-to-shape) またはアニメーション効果を取得します。
2. 必要な [Effect.Timing](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IEffect#getTiming--) プロパティに新しい値を設定します。
3. 変更された PPTX ファイルを保存します。

```java
import com.aspose.slides.*;

// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // スライドのメインシーケンスを取得します。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // メインシーケンスの最初のエフェクトを取得します。
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

Aspose.Slides は、アニメーション効果でサウンドを扱うための以下のプロパティを提供します：

- [setSound(IAudio value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **アニメーション効果サウンドの追加**

この Java コードは、アニメーション効果のサウンドを追加し、次の効果が開始したときに停止する方法を示しています：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // プレゼンテーションのオーディオコレクションにオーディオを追加します
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // スライドのメインシーケンスを取得します。
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // メインシーケンスの最初のエフェクトを取得します。
    IEffect firstEffect = sequence.get_Item(0);

    // エフェクトが「No Sound」か確認します
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // 最初のエフェクトにサウンドを追加します
        firstEffect.setSound(effectSound);
    }

    // スライドの最初のインタラクティブシーケンスを取得します。
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // エフェクトの「前のサウンドを停止」フラグを設定します
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // PPTX ファイルをディスクに書き込みます
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **アニメーション効果サウンドの抽出**

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。 
3. メインのエフェクトシーケンスを取得します。 
4. 各アニメーション効果に埋め込まれた [setSound(IAudio value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) を抽出します。

この Java コードは、アニメーション効果に埋め込まれたサウンドを抽出する方法を示しています：

```java
import com.aspose.slides.*;

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

## **アフターアニメーション**

Aspose.Slides for Android via Java は、アニメーション効果の After animation プロパティを変更できます。

これは Microsoft PowerPoint のアニメーション効果ペインと拡張メニューです：

![アニメーション効果ペイン](shape-after-animation.png)

PowerPoint の Effect **After animation** ドロップダウンリストは以下のプロパティに対応します：

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) プロパティは After animation のタイプを示します：
  * PowerPoint の **More Colors** は [AfterAnimationType.Color](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/afteranimationtype/#Color) タイプに対応します；
  * PowerPoint の **Don't Dim** は [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) タイプ（デフォルトの after animation タイプ）に対応します；
  * PowerPoint の **Hide After Animation** は [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) タイプに対応します；
  * PowerPoint の **Hide on Next Mouse Click** は [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) タイプに対応します；
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) プロパティは after animation のカラー形式を定義します。このプロパティは [AfterAnimationType.Color](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/afteranimationtype/#Color) タイプと連携して動作します。タイプを別のものに変更すると、after animation のカラーはクリアされます。

```java
import com.aspose.slides.*;
import java.awt.Color;

// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // メインシーケンスの最初のエフェクトを取得します
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // アフターアニメーションのタイプを Color に変更します
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // アフターアニメーションの暗くなる色を設定します
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // PPTX ファイルをディスクに書き込みます
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストのアニメーション**

Aspose.Slides は、アニメーション効果の *Animate text* ブロックを操作するための以下のプロパティを提供します：

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) は効果のアニメートテキストタイプを示します。図形のテキストは次のようにアニメートできます：
  * すべて同時に ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) タイプ)
  * 単語単位で ([AnimateTextType.ByWord](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/animatetexttype/#ByWord) タイプ)
  * 文字単位で ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/animatetexttype/#ByLetter) タイプ)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) はアニメートされたテキスト部分（単語または文字）間の遅延を設定します。正の値は効果期間のパーセンテージを示し、負の値は秒数で遅延を示します。

Effect の Animate text プロパティを変更する方法は次のとおりです：

1. [Apply](#apply-animation-to-shape) またはアニメーション効果を取得します。
2. [setBuildType(int value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) プロパティを [BuildType.AsOneObject](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/buildtype/#AsOneObject) の値に設定して、*By Paragraphs* アニメーションモードをオフにします。
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) と [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) プロパティに新しい値を設定します。
4. 変更された PPTX ファイルを保存します。

```java
import com.aspose.slides.*;

// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // メインシーケンスの最初のエフェクトを取得します
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // エフェクトのテキストアニメーションタイプを「As One Object」に変更します
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // エフェクトのアニメートテキストタイプを「By word」に変更します
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // 単語間の遅延をエフェクト期間の 20% に設定します
    firstEffect.setDelayBetweenTextParts(20f);

    // PPTX ファイルをディスクに書き込みます
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **よくある質問**

### プレゼンテーションを Web に公開する際にアニメーションが保持されるようにするには？

[Export to HTML5](/slides/ja/androidjava/export-to-html5/) を使用し、[shape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) と [transition](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) アニメーションを担当する [options](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/html5options/) を有効にします。プレーン HTML ではスライドのアニメーションは再生されませんが、HTML5 では再生されます。

### 図形の Z オーダー（レイヤー順）を変更するとアニメーションにどのように影響しますか？

アニメーションと描画順序は独立しています。エフェクトは表示/非表示のタイミングとタイプを制御し、[z-order](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#getZOrderPosition--) はどのオブジェクトがどれを覆うかを決定します。可視結果はそれらの組み合わせで定義されます。（これは一般的な PowerPoint の挙動であり、Aspose.Slides のエフェクトと図形のモデルも同じロジックに従います。）

### 特定の効果をビデオに変換する際に制限はありますか？

一般的に、[アニメーションはサポートされています](/slides/ja/androidjava/convert-powerpoint-to-video/)、ただしまれなケースや特定の効果は異なる形でレンダリングされることがあります。使用する効果とライブラリのバージョンでテストすることを推奨します。