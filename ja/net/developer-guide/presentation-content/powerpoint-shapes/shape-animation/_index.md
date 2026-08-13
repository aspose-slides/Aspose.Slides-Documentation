---
title: .NET でプレゼンテーションに形状アニメーションを適用する
linktitle: 形状アニメーション
type: docs
weight: 60
url: /ja/net/shape-animation/
keywords:
- 形状
- アニメーション
- 効果
- アニメーション形状
- アニメーションテキスト
- アニメーション追加
- アニメーション取得
- アニメーション抽出
- 効果追加
- 効果取得
- 効果抽出
- 効果サウンド
- アニメーション適用
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションで形状アニメーションを作成およびカスタマイズする方法を学びましょう。差別化を図れます！"
---
## **はじめに**

アニメーションは、テキスト、画像、図形、または[チャート](/slides/ja/net/animated-charts/)に適用できる視覚効果です。プレゼンテーションやその構成要素に生命を吹き込みます。

## **プレゼンテーションでアニメーションを使用する理由**

アニメーションを使用すると

* 情報の流れを制御する
* 重要なポイントを強調する
* 聴衆の関心や参加意欲を高める
* コンテンツを読みやすく、理解しやすく、処理しやすくする
* 読者や視聴者の注意をプレゼンテーションの重要な部分に引きつける

PowerPoint は、**エントランス**、**エグジット**、**エンファシス**、**モーション パス** のカテゴリにわたるアニメーションとアニメーション効果の多くのオプションとツールを提供します。

## **Aspose.Slides のアニメーション**

* Aspose.Slides は、[Aspose.Slides.Animation](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/) 名前空間でアニメーションを操作するために必要なクラスと型を提供します。
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/effecttype) 列挙体で **150 以上のアニメーション効果** を提供します。これらの効果は本質的に PowerPoint で使用される効果と同じ（または同等）です。

## **テキストボックスへのアニメーションの適用**

Aspose.Slides for .NET を使用すると、図形内のテキストにアニメーションを適用できます。

1. [Presentation](http://www.aspose.com/api/net/slides/ja/aspose.slides/) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape) を追加します。
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/properties/textframe) にテキストを追加します。
5. メインのエフェクト シーケンスを取得します。
6. [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape) にアニメーション効果を追加します。
7. [TextAnimation.BuildType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/textanimation/properties/buildtype) プロパティを [BuildType 列挙体](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/buildtype) の値に設定します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この C# コードは、`Fade` 効果を AutoShape に適用し、テキスト アニメーションを *By 1st Level Paragraphs* に設定する方法を示しています:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します。
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // テキスト付きの新しい AutoShape を追加します
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // パラグラフ ビルドがステップを進められるように 3 つの段落を追加します
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // スライドのメイン シーケンスを取得します
    ISequence sequence = sld.Timeline.MainSequence;

    // シェイプに Fade アニメーション効果を追加します
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // シェイプのテキストを第1レベル段落単位でアニメーション化します
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // PPTX ファイルをディスクに保存します
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info"%}}  

テキストへのアニメーション適用に加えて、単一の[Paragraph](/slides/ja/net/animated-text/)にもアニメーションを適用できます。[**Animated Text**](/slides/ja/net/animated-text/)をご覧ください。

{{% /alert %}}  

## **PictureFrame へのアニメーションの適用**

1. [Presentation](http://www.aspose.com/api/net/slides/ja/aspose.slides/) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. スライド上に [PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframe) を追加または取得します。
5. メインのエフェクト シーケンスを取得します。
6. [PictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframe) にアニメーション効果を追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この C# コードは、`Fly` 効果を画像フレームに適用する方法を示しています:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します。
using (Presentation pres = new Presentation())
{
    // プレゼンテーションの画像コレクションに追加する画像をロードします
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // スライドに画像フレームを追加します
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // スライドのメイン シーケンスを取得します。
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // 画像フレームに左からの Fly アニメーション効果を追加します
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX ファイルをディスクに保存します
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Shape へのアニメーションの適用**

1. [Presentation](http://www.aspose.com/api/net/slides/ja/aspose.slides/) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape) を追加します。
4. `Bevel` [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape) を追加します（このオブジェクトがクリックされると、アニメーションが再生されます）。
5. ベベル形状上にエフェクト シーケンスを作成します。
6. カスタム `UserPath` を作成します。
7. `UserPath` への移動コマンドを追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この C# コードは、`PathFootball`（パスフットボール）効果を形状に適用する方法を示しています:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // 既存のシェイプに対して PathFootball 効果をゼロから作成します。
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // PathFootBall アニメーション効果を追加します。
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // "ボタン" のようなものを作成します。
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // ボタン用のエフェクト シーケンスを作成します。
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // カスタム ユーザーパスを作成します。オブジェクトはボタンがクリックされた後にのみ移動します。
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // 作成されたパスが空なので、移動コマンドを追加します。
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // PPTX ファイルをディスクに書き込みます
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Shape に適用されたアニメーション効果の取得**

以下の例は、[ISequence](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/isequence/) インターフェイスの `GetEffectsByShape` メソッドを使用して、形状に適用されたすべてのアニメーション効果を取得する方法を示しています。

**例 1: 通常スライド上の Shape に適用されたアニメーション効果の取得**

以前、PowerPoint プレゼンテーションで形状にアニメーション効果を追加する方法を学びました。以下のサンプルコードは、プレゼンテーション `AnimExample_out.pptx` の最初の通常スライドの最初の形状に適用された効果を取得する方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // スライドのメイン アニメーション シーケンスを取得します。
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // 最初のスライド上の最初のシェイプを取得します。
    IShape shape = firstSlide.Shapes[0];

    // シェイプに適用されたアニメーション効果を取得します。
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**例 2: プレースホルダーから継承されたものも含め、すべてのアニメーション効果の取得**

通常スライド上の形状にレイアウト スライドまたはマスタースライド上のプレースホルダーがあり、これらのプレースホルダーにアニメーション効果が追加されている場合、スライドショー中に形状のすべての効果が再生されます。これにはプレースホルダーから継承された効果も含まれます。

たとえば、`sample.pptx` という PowerPoint ファイルに、フッター形状のみがありテキストが「Made with Aspose.Slides」となっていて、**Random Bars** 効果がその形状に適用されているとします。

![スライド シェイプ アニメーション効果](slide-shape-animation.png)

さらに、**Split** 効果がレイアウト スライドのフッター プレースホルダーに適用されているとします。

![レイアウト シェイプ アニメーション効果](layout-shape-animation.png)

最後に、**Fly In** 効果がマスター スライドのフッター プレースホルダーに適用されているとします。

![マスター シェイプ アニメーション効果](master-shape-animation.png)

以下のサンプルコードは、[IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/) インターフェイスの `GetBasePlaceholder` メソッドを使用して形状のプレースホルダーにアクセスし、レイアウトおよびマスター スライド上のプレースホルダーから継承されたものを含めてフッター形状に適用されたアニメーション効果を取得する方法を示しています。

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 通常スライド上のシェイプのアニメーション効果を取得します。
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // レイアウトスライド上のプレースホルダーのアニメーション効果を取得します。
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // マスタースライド上のプレースホルダーのアニメーション効果を取得します。
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
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

## **アニメーション効果のタイミング プロパティの変更**

Aspose.Slides for .NET を使用すると、アニメーション効果の Timing プロパティを変更できます。

これは Microsoft PowerPoint のアニメーション タイミング ペインと拡張メニューです:

![例1_画像](shape-animation.png)

以下は PowerPoint タイミングと [Effect.Timing](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/effect/properties/timing) プロパティ間の対応です:
- PowerPoint タイミング **Start** ドロップダウン リストは [Effect.Timing.TriggerType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/properties/triggertype) プロパティに対応します。 
- PowerPoint タイミング **Duration** は [Effect.Timing.Duration](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/properties/duration) プロパティに対応します。アニメーションの実行時間（秒）は、アニメーションが 1 サイクルを完了するのに要する総時間です。 
- PowerPoint タイミング **Delay** は [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/properties/triggerdelaytime) プロパティに対応します。 
- PowerPoint タイミング **Repeat** ドロップダウン リストは以下のプロパティに対応します: 
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/repeatcount) プロパティは効果が繰り返される *回数* を示します;
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/repeatuntilendslide) フラグは効果がスライドの最後まで繰り返されるかどうかを指定します;
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/repeatuntilnextclick) フラグは効果が次のクリックまで繰り返されるかどうかを指定します。
- PowerPoint タイミング **Rewind when done playing** チェックボックスは [Effect.Timing.Rewind](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/rewind/) プロパティに対応します。 

Effect Timing プロパティを変更する手順は次のとおりです:

1. [Apply](#apply-animation-to-shape) または取得したアニメーション効果を取得します。
2. 必要な [Effect.Timing](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/effect/properties/timing) プロパティに新しい値を設定します。 
3. 変更された PPTX ファイルを保存します。

この C# コードは操作をデモンストレーションします:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // スライドのメイン シーケンスを取得します。
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // メイン シーケンスの最初のエフェクトを取得します。
    IEffect effect = sequence[0];

    // エフェクトの TriggerType をクリック開始に変更します。
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // エフェクトの Duration を変更します。
    effect.Timing.Duration = 3f;

    // エフェクトの TriggerDelayTime を変更します。
    effect.Timing.TriggerDelayTime = 0.5f;

    // エフェクトの Repeat 値が "none" の場合
    if (effect.Timing.RepeatCount == 1f)
    {
        // エフェクトの Repeat を "次のクリックまで" に変更します。
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // エフェクトの Repeat を "スライドの最後まで" に変更します。
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // エフェクトの Rewind をオンにします。
        effect.Timing.Rewind = true;
    
    // PPTX ファイルをディスクに保存します。
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **アニメーション効果のサウンド**

Aspose.Slides は、アニメーション効果のサウンドを操作するために次のプロパティを提供します: 
- [IEffect.Sound](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/effect/stopprevioussound/) 

### **アニメーション効果サウンドの追加**

この C# コードは、アニメーション効果サウンドを追加し、次の効果が開始されたときにサウンドを停止する方法を示しています:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// プレゼンテーションのオーディオ コレクションにオーディオを追加します
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// スライドのメイン シーケンスを取得します。
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// メイン シーケンスの最初のエフェクトを取得します
	IEffect firstEffect = sequence[0];

	// エフェクトが「サウンドなし」かどうかを確認します
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// 最初のエフェクトにサウンドを追加します
		firstEffect.Sound = effectSound;
	}

	// スライドの最初のインタラクティブ シーケンスを取得します。
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// エフェクトの「前のサウンドを停止」フラグを設定します
	interactiveSequence[0].StopPreviousSound = true;

	// PPTX ファイルをディスクに書き込みます
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **アニメーション効果サウンドの抽出**

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。 
3. メインのエフェクト シーケンスを取得します。 
4. 各アニメーション効果に埋め込まれた [Sound](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/effect/sound/) を抽出します。 

この C# コードは、アニメーション効果に埋め込まれたサウンドを抽出する方法を示しています:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // スライドのメイン シーケンスを取得します。
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // エフェクトのサウンドをバイト配列として抽出します
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **アフター アニメーション**

Aspose.Slides for .NET を使用すると、アニメーション効果の After animation プロパティを変更できます。

これは Microsoft PowerPoint のアニメーション効果ペインと拡張メニューです:

![例1_画像](shape-after-animation.png)

PowerPoint の **After animation** ドロップダウン リストは以下のプロパティに対応します: 

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/afteranimationtype/) プロパティは After animation タイプを示します:
  * PowerPoint の **More Colors** は [AfterAnimationType.Color](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/afteranimationtype/) タイプに対応します;
  * PowerPoint の **Don't Dim** は [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/afteranimationtype/) タイプに対応します（デフォルトの After animation タイプ）;
  * PowerPoint の **Hide After Animation** は [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/afteranimationtype/) タイプに対応します;
  * PowerPoint の **Hide on Next Mouse Click** は [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/afteranimationtype/) タイプに対応します;
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/afteranimationcolor/) プロパティは After animation のカラー形式を定義します。このプロパティは [AfterAnimationType.Color](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/afteranimationtype/) タイプと共に機能します。タイプを別のものに変更すると、After animation のカラーはクリアされます。

この C# コードは After animation 効果を変更する方法を示しています:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // メイン シーケンスの最初のエフェクトを取得します
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // アフター アニメーションのタイプを Color に変更します
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // アフター アニメーションのディム カラーを設定します
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // PPTX ファイルをディスクに書き込みます
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **テキストのアニメーション**

Aspose.Slides は、アニメーション効果の *Animate text* ブロックを操作するために次のプロパティを提供します:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/animatetexttype/) は効果のアニメート テキスト タイプを示します。形状のテキストは次のいずれかでアニメーションできます:
  - All at once ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/animatetexttype/) タイプ)
  - By word ([AnimateTextType.ByWord](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/animatetexttype/) タイプ)
  - By letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/animatetexttype/) タイプ)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/delaybetweentextparts/) はアニメートされたテキスト部分（単語または文字）間の遅延を設定します。正の値は効果期間のパーセンテージを示し、負の値は秒単位の遅延を示します。

Effect Animate text プロパティを変更する手順:

1. [Apply](#apply-animation-to-shape) または取得したアニメーション効果を取得します。
2. [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itextanimation/buildtype/) プロパティを [BuildType.AsOneObject](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/buildtype/) に設定して *By Paragraphs* アニメーション モードをオフにします。
3. [IEffect.AnimateTextType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/animatetexttype/) と [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/delaybetweentextparts/) プロパティに新しい値を設定します。
4. 変更された PPTX ファイルを保存します。

この C# コードは操作をデモンストレーションします:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します。
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // メイン シーケンスの最初のエフェクトを取得します
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // エフェクトのテキスト アニメーション タイプを「As One Object」に変更します
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // エフェクトのアニメート テキスト タイプを「単語単位」に変更します
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // 単語間の遅延をエフェクト期間の 20% に設定します
    firstEffect.DelayBetweenTextParts = 20f;

    // PPTX ファイルをディスクに書き込みます
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### プレゼンテーションを Web に公開する際にアニメーションが保持されることを確認するには？

[Export to HTML5](/slides/ja/net/export-to-html5/) を使用し、[shape](https://reference.aspose.com/slides/ja/net/aspose.slides.export/html5options/animateshapes/) と [transition](https://reference.aspose.com/slides/ja/net/aspose.slides.export/html5options/animatetransitions/) アニメーションを担当する [options](https://reference.aspose.com/slides/ja/net/aspose.slides.export/html5options/) を有効にします。プレーン HTML ではスライド アニメーションは再生されませんが、HTML5 では再生されます。

### シェイプの z-order（レイヤー順序）を変更すると、アニメーションにどのような影響がありますか？

アニメーションと描画順序は独立しています。エフェクトは表示/非表示のタイミングとタイプを制御し、[z-order](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/zorderposition/) は何が何を覆うかを決定します。最終的な表示結果は両者の組み合わせで定義されます。（これは一般的な PowerPoint の動作であり、Aspose.Slides のエフェクトとシェイプのモデルも同様のロジックに従います。）

### 特定の効果をビデオに変換する際に制限はありますか？

一般的に[アニメーションはサポートされています](/slides/ja/net/convert-powerpoint-to-video/)、しかしまれに特定の効果が異なる方法でレンダリングされることがあります。使用する効果とライブラリのバージョンでテストすることをお勧めします。