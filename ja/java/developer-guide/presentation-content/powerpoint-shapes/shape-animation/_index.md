---
title: Java を使用してプレゼンテーションにシェイプ アニメーションを適用する
linktitle: シェイプ アニメーション
type: docs
weight: 60
url: /ja/java/shape-animation/
keywords:
- シェイプ
- アニメーション
- エフェクト
- アニメーション シェイプ
- アニメーション テキスト
- アニメーションの追加
- アニメーションの取得
- アニメーションの抽出
- エフェクトの追加
- エフェクトの取得
- エフェクトの抽出
- エフェクト サウンド
- アニメーションの適用
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint プレゼンテーションでシェイプ アニメーションを作成およびカスタマイズする方法を紹介します。目立ちましょう！"
---
## **概要**

アニメーションは、テキスト、画像、図形、または[チャート](https://docs.aspose.com/slides/ja/java/animated-charts/)に適用できる視覚効果です。プレゼンテーションやその構成要素に命を吹き込みます。

## **プレゼンテーションでアニメーションを使用する理由は？**

アニメーションを使用すると

* 情報の流れを制御する
* 重要なポイントを強調する
* 聴衆の関心や参加意欲を高める
* コンテンツを読みやすく、理解しやすく、処理しやすくする
* 読者や視聴者の注意をプレゼンテーションの重要部分に引きつける

PowerPointは、**entrance**、**exit**、**emphasis**、**motion paths** の各カテゴリにわたるアニメーションとアニメーション効果の多数のオプションとツールを提供します。

## **Aspose.Slides のアニメーション**

* Aspose.Slides は、`Aspose.Slides.Animation` 名前空間以下でアニメーションを操作するために必要なクラスと型を提供します。
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/effecttype) 列挙体で **150** 以上のアニメーション効果を提供します。これらの効果は、本質的に PowerPoint で使用されるものと同じ（または同等）です。

## **テキストボックスへのアニメーションの適用**

Aspose.Slides for Java を使用すると、シェイプ内のテキストにアニメーションを適用できます。

1. `Presentation` クラスのインスタンスを作成します。
2. インデックスを指定してスライドの参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape) を追加します。 
4. テキストを [IAutoShape.TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) に追加します。 
5. メインのエフェクトシーケンスを取得します。
6. [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape) にアニメーション効果を追加します。 
7. `TextAnimation.BuildType` プロパティを `BuildType` 列挙体の値に設定します。
8. プレゼンテーションを PPTX ファイルとしてディスクに保存します。

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

    // スライドのメインシーケンスを取得します
    ISequence sequence = sld.getTimeline().getMainSequence();

    // シェイプに Fade アニメーション効果を追加します
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // シェイプのテキストを第1レベル段落単位でアニメーションさせます
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // PPTX ファイルをディスクに保存します
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

テキストへのアニメーション適用に加えて、単一の[Paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph)にもアニメーションを適用できます。詳細は[**Animated Text**](/slides/ja/java/animated-text/)をご覧ください。

{{% /alert %}} 

## **PictureFrame へのアニメーションの適用**

1. `Presentation` クラスのインスタンスを作成します。
2. インデックスを指定してスライドの参照を取得します。
3. スライドに [PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe) を追加または取得します。 
4. メインのエフェクトシーケンスを取得します。
5. [PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pictureframe) にアニメーション効果を追加します。
6. プレゼンテーションを PPTX ファイルとしてディスクに保存します。

```java
import com.aspose.slides.*;

// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
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

## **シェイプへのアニメーションの適用**

1. `Presentation` クラスのインスタンスを作成します。
2. インデックスを指定してスライドの参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape) を追加します。 
4. `Bevel` の [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape) を追加します（このオブジェクトがクリックされるとアニメーションが再生されます）。
5. ベベルシェイプに対してエフェクトのシーケンスを作成します。
6. カスタム `UserPath` を作成します。
7. `UserPath` へ移動するコマンドを追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに保存します。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// PPTX ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 既存のシェイプに対して PathFootball エフェクトを最初から作成します。
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

     // 作成したパスが空なので、移動コマンドを追加します。
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // PPTX ファイルをディスクに書き出します
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **シェイプに適用されたアニメーション効果の取得**

以下の例は、[ISequence](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isequence/) インターフェイスの `getEffectsByShape` メソッドを使用して、シェイプに適用されたすべてのアニメーション効果を取得する方法を示します。

**例 1: 通常スライド上のシェイプに適用されたアニメーション効果の取得**

以前は、PowerPoint プレゼンテーションのシェイプにアニメーション効果を追加する方法を学びました。以下のサンプルコードは、プレゼンテーション `AnimExample_out.pptx` の最初の通常スライドの最初のシェイプに適用された効果を取得する方法を示します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // スライドのメイン アニメーション シーケンスを取得します。
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

**例 2: プレースホルダーから継承されたものを含むすべてのアニメーション効果の取得**

通常スライド上のシェイプに、レイアウトスライドやマスタースライド上のプレースホルダーがあり、これらのプレースホルダーにアニメーション効果が追加されている場合、スライドショー中にシェイプのすべての効果が再生されます。これにはプレースホルダーから継承された効果も含まれます。

たとえば、`sample.pptx` という PowerPoint ファイルに、フッターシェイプ「Made with Aspose.Slides」のみが含まれ、**Random Bars** 効果がシェイプに適用されているとします。

![スライド シェイプ アニメーション効果](slide-shape-animation.png)

さらに、**Split** 効果がレイアウトスライド上のフッタープレースホルダーに適用されているとします。

![レイアウト シェイプ アニメーション効果](layout-shape-animation.png)

最後に、**Fly In** 効果がマスタースライド上のフッタープレースホルダーに適用されているとします。

![マスタ シェイプ アニメーション効果](master-shape-animation.png)

以下のサンプルコードは、[IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) インターフェイスの `getBasePlaceholder` メソッドを使用してシェイプのプレースホルダーにアクセスし、レイアウトおよびマスタースライド上のプレースホルダーから継承されたものを含めてフッターシェイプに適用されたアニメーション効果を取得する方法を示します。

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

Aspose.Slides for Java を使用すると、アニメーション効果の Timing プロパティを変更できます。

これは Microsoft PowerPoint の Animation Timing ペインです：

![例1_画像](shape-animation.png)

PowerPoint Timing と [Effect.Timing](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IEffect#getTiming--) プロパティの対応関係は次のとおりです。

- PowerPoint の **Start** ドロップダウンリストは、[Effect.Timing.TriggerType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ITiming#getTriggerType--) プロパティに対応しています。 
- PowerPoint の **Duration** は、[Effect.Timing.Duration](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ITiming#getDuration--) プロパティに対応しています。アニメーションの期間（秒）は、アニメーションが 1 サイクルを完了するのにかかる総時間です。 
- PowerPoint の **Delay** は、[Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ITiming#getTriggerDelayTime--) プロパティに対応しています。 

このように Effect Timing プロパティを変更します：

1. [Apply](#apply-animation-to-shape) またはアニメーション効果を取得します。
2. 必要な [Effect.Timing](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IEffect#getTiming--) プロパティに新しい値を設定します。 
3. 変更した PPTX ファイルを保存します。

```java
import com.aspose.slides.*;

// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // スライドのメインシーケンスを取得します。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // メインシーケンスの最初のエフェクトを取得します。
    IEffect effect = sequence.get_Item(0);

    // エフェクトの TriggerType をクリックで開始するように変更します
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // エフェクトの Duration を変更します
    effect.getTiming().setDuration(3f);

    // エフェクトの TriggerDelayTime を変更します
    effect.getTiming().setTriggerDelayTime(0.5f);

    // PPTX ファイルをディスクに保存します
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **アニメーション効果のサウンド**

Aspose.Slides は、アニメーション効果のサウンドを操作できる次のプロパティを提供します：

- [setSound(IAudio value)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **アニメーション効果サウンドの追加**

この Java コードは、アニメーション効果サウンドを追加し、次の効果が開始されるときにサウンドを停止する方法を示します：

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

    // メインシーケンスの最初のエフェクトを取得します
    IEffect firstEffect = sequence.get_Item(0);

    // エフェクトが「サウンドなし」かどうかを確認します
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // 最初のエフェクトにサウンドを追加します
        firstEffect.setSound(effectSound);
    }

    // スライドの最初のインタラクティブ シーケンスを取得します。
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

1. `Presentation` クラスのインスタンスを作成します。
2. インデックスを指定してスライドの参照を取得します。 
3. メインのエフェクトシーケンスを取得します。 
4. 各アニメーション効果に埋め込まれた [setSound(IAudio value)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) を抽出します。 

この Java コードは、アニメーション効果に埋め込まれたサウンドを抽出する方法を示します：

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

        // エフェクトサウンドをバイト配列として抽出します
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **アニメーション後**

Aspose.Slides for Java を使用すると、アニメーション効果の After animation プロパティを変更できます。

これは Microsoft PowerPoint の Animation Effect ペインと拡張メニューです：

![例1_画像](shape-after-animation.png)

PowerPoint Effect **After animation** ドロップダウンリストは以下のプロパティに対応しています：

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) プロパティはアフターアニメーションのタイプを指定します：
  * PowerPoint **More Colors** は [AfterAnimationType.Color](https://reference.aspose.com/slides/ja/java/com.aspose.slides/afteranimationtype/#Color) に対応します；
  * PowerPoint **Don't Dim** は [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/ja/java/com.aspose.slides/afteranimationtype/#DoNotDim)（デフォルト）に対応します；
  * PowerPoint **Hide After Animation** は [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) に対応します；
  * PowerPoint **Hide on Next Mouse Click** は [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) に対応します；
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) プロパティはアフターアニメーションのカラー形式を定義します。このプロパティは [AfterAnimationType.Color](https://reference.aspose.com/slides/ja/java/com.aspose.slides/afteranimationtype/#Color) と組み合わせて使用します。別のタイプに変更すると、アフターアニメーションのカラーはクリアされます。

この Java コードは、アフターアニメーション効果を変更する方法を示します：

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

    // アフターアニメーションのディムカラーを設定します
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // PPTX ファイルをディスクに書き込みます
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストのアニメーション**

Aspose.Slides は、アニメーション効果の *Animate text* ブロックを操作できる次のプロパティを提供します：

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) は効果のテキストアニメーションタイプを指定します。シェイプのテキストは次の方式でアニメーションできます：
  - All at once ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/ja/java/com.aspose.slides/animatetexttype/#AllAtOnce) タイプ)
  - By word ([AnimateTextType.ByWord](https://reference.aspose.com/slides/ja/java/com.aspose.slides/animatetexttype/#ByWord) タイプ)
  - By letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/ja/java/com.aspose.slides/animatetexttype/#ByLetter) タイプ)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) は、アニメーションテキストの各部位（単語または文字）間の遅延を設定します。正の値は効果期間のパーセンテージを、負の値は秒単位の遅延を表します。

このように Effect Animate text プロパティを変更します：

1. [Apply](#apply-animation-to-shape) またはアニメーション効果を取得します。
2. `BuildType` を [BuildType.AsOneObject](https://reference.aspose.com/slides/ja/java/com.aspose.slides/buildtype/#AsOneObject) に設定して *By Paragraphs* アニメーションモードをオフにします。
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) と [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) の新しい値を設定します。
4. 変更した PPTX ファイルを保存します。

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

## **FAQ**

### プレゼンテーションをWebに公開する際にアニメーションを保持するにはどうすればよいですか？

[Export to HTML5](/slides/ja/java/export-to-html5/) を使用し、[shape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) と [transition](https://reference.aspose.com/slides/ja/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) アニメーションを有効にするオプションを設定します。普通の HTML ではスライドアニメーションは再生されませんが、HTML5 では再生されます。

### シェイプの z 順序（レイヤー順序）を変更するとアニメーションにどのような影響がありますか？

アニメーションと描画順序は独立しています。効果は表示／非表示のタイミングとタイプを制御し、[z-order](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#getZOrderPosition--) はどちらが上に覆いかぶさるかを決定します。最終的な見た目は両者の組み合わせで決まります。（これは一般的な PowerPoint の挙動であり、Aspose.Slides の効果とシェイプのモデルも同様のロジックに従います。）

### 特定の効果をビデオに変換する際に制限はありますか？

一般的に[アニメーションはサポートされています](/slides/ja/java/convert-powerpoint-to-video/)、ただしまれに稀なケースや特定の効果が異なる形でレンダリングされることがあります。使用する効果とライブラリのバージョンでテストすることを推奨します。