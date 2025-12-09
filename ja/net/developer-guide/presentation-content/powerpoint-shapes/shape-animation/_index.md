---
title: .NET のプレゼンテーションでシェイプ アニメーションを適用する
linktitle: シェイプ アニメーション
type: docs
weight: 60
url: /ja/net/shape-animation/
keywords:
- シェイプ
- アニメーション
- 効果
- アニメーション シェイプ
- アニメーション テキスト
- アニメーションを追加
- アニメーションを取得
- アニメーションを抽出
- 効果を追加
- 効果を取得
- 効果を抽出
- 効果 サウンド
- アニメーションを適用
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションのシェイプ アニメーションを作成およびカスタマイズする方法を学び、際立ちましょう！"
---

アニメーションは、テキスト、画像、図形、または[チャート](/slides/ja/net/animated-charts/)に適用できるビジュアル効果です。プレゼンテーションやその構成要素に命を吹き込みます。

## **プレゼンテーションでアニメーションを使用する理由**
アニメーションを使用すると、以下が可能です
* 情報の流れを制御する
* 重要なポイントを強調する
* 聴衆の関心や参加意欲を高める
* コンテンツを読みやすく、理解しやすく、処理しやすくする
* プレゼンテーションの重要な部分に読者や視聴者の注意を向けさせる

PowerPoint は、**entrance**、**exit**、**emphasis**、および**motion paths**のカテゴリにわたる多数のアニメーションオプションとツールを提供します。

## **Aspose.Slides のアニメーション**
* Aspose.Slides は、[Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) 名前空間以下でアニメーションを操作するために必要なクラスと型を提供します。
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) 列挙体で **150以上のアニメーション効果** を提供します。これらの効果は、実質的に PowerPoint で使用されているものと同じ（または同等）です。

## **テキスト ボックスへのアニメーションの適用**
Aspose.Slides for .NET を使用すると、図形内のテキストにアニメーションを適用できます。

1. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) を追加します。
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) にテキストを追加します。
5. メインのエフェクト シーケンスを取得します。
6. [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) にアニメーション効果を追加します。
7. [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) プロパティを、[BuildType 列挙体](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype) の値に設定します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

以下の C# コードは、AutoShape に `Fade` 効果を適用し、テキスト アニメーションを *By 1st Level Paragraphs* の値に設定する方法を示します:
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // テキスト付きの新しい AutoShape を追加します
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // スライドのメインシーケンスを取得します。
    ISequence sequence = sld.Timeline.MainSequence;

    // シェイプに Fade アニメーション効果を追加します
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // シェイプのテキストを第1レベル段落単位でアニメーション化します
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // PPTX ファイルをディスクに保存します
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```


{{%  alert color="primary"  %}} 
テキストへのアニメーション適用に加えて、単一の[Paragraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph)にもアニメーションを適用できます。[**Animated Text**](/slides/ja/net/animated-text/)をご覧ください。
{{% /alert %}} 

## **PictureFrame へのアニメーションの適用**
1. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライド上に [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) を追加または取得します。
5. メインのエフェクト シーケンスを取得します。
6. [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) にアニメーション効果を追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

以下の C# コードは、ピクチャーフレームに `Fly` 効果を適用する方法を示します:
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation pres = new Presentation())
{
    // プレゼンテーションの画像コレクションに追加する画像をロードします
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // スライドにピクチャーフレームを追加します
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // スライドのメインシーケンスを取得します。
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // ピクチャーフレームに左からの Fly アニメーション効果を追加します
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX ファイルをディスクに保存します
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```


## **Shape へのアニメーションの適用**
1. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) を追加します。
4. `Bevel` の [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) を追加します（このオブジェクトがクリックされると、アニメーションが再生されます）。
5. ベベル形状に対してエフェクトのシーケンスを作成します。
6. カスタム `UserPath` を作成します。
7. `UserPath` への移動コマンドを追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

以下の C# コードは、Shape に `PathFootball`（パス フットボール）効果を適用する方法を示します:
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // 既存のシェイプに対して PathFootball エフェクトを最初から作成します。
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // PathFootBall アニメーション効果を追加します。
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 一種の「ボタン」を作成します。
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // ボタン用のエフェクト シーケンスを作成します。
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // カスタム ユーザーパスを作成します。オブジェクトはボタンがクリックされた後にのみ移動します。
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // 作成したパスが空なので、移動コマンドを追加します。
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
以下の例では、[ISequence](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/) インターフェイスの `GetEffectsByShape` メソッドを使用して、Shape に適用されたすべてのアニメーション効果を取得する方法を示します。

**例 1: 通常のスライド上の Shape に適用されたアニメーション効果を取得**
以前、PowerPoint プレゼンテーションで Shape にアニメーション効果を追加する方法を学びました。以下のサンプルコードは、プレゼンテーション `AnimExample_out.pptx` の最初の通常スライド上の最初の Shape に適用された効果を取得する方法を示します。
```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // スライドのメイン アニメーション シーケンスを取得します。
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // 最初のスライド上の最初のシェイプを取得します。
    IShape shape = firstSlide.Shapes[0];

    // シェイプに適用されたアニメーション 効果を取得します。
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```


**例 2: プレースホルダーから継承されたものを含むすべてのアニメーション効果を取得**
通常スライド上の Shape がレイアウト スライドやマスタースライド上のプレースホルダーを持ち、これらのプレースホルダーにアニメーション効果が追加されている場合、スライドショー中に Shape のすべての効果が再生され、プレースホルダーから継承された効果も含まれます。

たとえば、`sample.pptx` という PowerPoint プレゼンテーション ファイルに、フッター Shape のみが含まれるスライドがあり、テキスト "Made with Aspose.Slides" が設定され、**Random Bars** 効果がその Shape に適用されているとします。

![Slide shape animation effect](slide-shape-animation.png)

さらに、**layout** スライド上のフッタープレースホルダーに **Split** 効果が適用されていると仮定します。

![Layout shape animation effect](layout-shape-animation.png)

最後に、**master** スライド上のフッタープレースホルダーに **Fly In** 効果が適用されているとします。

![Master shape animation effect](master-shape-animation.png)

以下のサンプルコードは、[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) インターフェイスの `GetBasePlaceholder` メソッドを使用して Shape のプレースホルダーにアクセスし、レイアウトやマスタースライド上のプレースホルダーから継承されたものを含むフッター Shape に適用されたアニメーション効果を取得する方法を示します。
```cs
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
```

```cs
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
Aspose.Slides for .NET を使用すると、アニメーション効果のタイミング プロパティを変更できます。

This is the Animation Timing pane and extended menu in Microsoft PowerPoint:

![example1_image](shape-animation.png)

以下は、PowerPoint のタイミングと [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) プロパティとの対応です：
- PowerPoint のタイミング **Start** ドロップダウン リストは、[Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype) プロパティに対応しています。 
- PowerPoint のタイミング **Duration** は、[Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration) プロパティに対応しています。アニメーションの期間（秒）は、アニメーションが 1 サイクルを完了するのに要する総時間です。 
- PowerPoint のタイミング **Delay** は、[Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime) プロパティに対応しています。 
- PowerPoint のタイミング **Repeat** ドロップダウン リストは、以下のプロパティに対応しています： 
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount) プロパティは、効果が繰り返される *回数* を示します;
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide) フラグは、効果がスライドの最後まで繰り返されるかどうかを指定します;
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick) フラグは、効果が次のクリックまで繰り返されるかどうかを指定します。
- PowerPoint のタイミング **Rewind when done playing** チェックボックスは、[Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/) プロパティに対応しています。 

Effect のタイミング プロパティを変更する方法は次のとおりです：

1. [Apply](#apply-animation-to-shape) またはアニメーション効果を取得します。
2. 必要な [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) プロパティに新しい値を設定します。 
3. 変更された PPTX ファイルを保存します。

以下の C# コードは、この操作を示しています：
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // スライドのメイン シーケンスを取得します。
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // メイン シーケンスの最初の効果を取得します。
    IEffect effect = sequence[0];

    // 効果の TriggerType をクリックで開始するように変更します。
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // 効果の Duration を変更します。
    effect.Timing.Duration = 3f;

    // 効果の TriggerDelayTime を変更します。
    effect.Timing.TriggerDelayTime = 0.5f;

    // 効果の Repeat 値が「none」の場合
    if (effect.Timing.RepeatCount == 1f)
    {
        // 効果の Repeat を「次のクリックまで」に変更します。
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // 効果の Repeat を「スライドの最後まで」に変更します。
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // 効果の Rewind をオンにします。
        effect.Timing.Rewind = true;
    
    // PPTX ファイルをディスクに保存します。
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```


## **アニメーション効果のサウンド**
Aspose.Slides は、アニメーション効果のサウンドを操作するために以下のプロパティを提供します： 
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/)  
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/)  

### **アニメーション効果のサウンドを追加**
以下の C# コードは、アニメーション効果のサウンドを追加し、次の効果が開始されたときにサウンドを停止する方法を示します：
```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// プレゼンテーションのオーディオ コレクションにオーディオを追加します
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// スライドのメイン シーケンスを取得します。
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// メイン シーケンスの最初の効果を取得します
	IEffect firstEffect = sequence[0];

	// 効果に「サウンドなし」かどうかを確認します
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// 最初の効果にサウンドを追加します
		firstEffect.Sound = effectSound;
	}

	// スライドの最初のインタラクティブ シーケンスを取得します。
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// 効果の「前のサウンドを停止」フラグを設定します
	interactiveSequence[0].StopPreviousSound = true;

	// PPTX ファイルをディスクに書き込みます
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```


### **アニメーション効果のサウンドを抽出**
1. [Presentation] クラスのインスタンスを作成します。 
2. インデックスでスライドの参照を取得します。 
3. メインのエフェクト シーケンスを取得します。 
4. 各アニメーション効果に埋め込まれた [Sound] を抽出します。 

以下の C# コードは、アニメーション効果に埋め込まれたサウンドを抽出する方法を示します：
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // スライドのメインシーケンスを取得します。
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // エフェクトのサウンドをバイト配列で抽出します
        byte[] audio = effect.Sound.BinaryData;
    }
}
```


## **アフター アニメーション**
Aspose.Slides for .NET を使用すると、アニメーション効果の After animation プロパティを変更できます。

This is the Animation Effect pane and extended menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

PowerPoint の Effect **After animation** ドロップダウン リストは、以下のプロパティに対応しています： 

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) プロパティは、After animation のタイプを表します：
  * PowerPoint **More Colors** は、[AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) タイプに対応しています;
  * PowerPoint **Don't Dim** は、[AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) タイプに対応しています（デフォルトの After animation タイプ）;
  * PowerPoint **Hide After Animation** は、[AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) タイプに対応しています;
  * PowerPoint **Hide on Next Mouse Click** は、[AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) タイプに対応しています;
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) プロパティは、After animation のカラー形式を定義します。このプロパティは [AfterAnimationType.Color] タイプと連動して機能します。別のタイプに変更すると、After animation のカラーはクリアされます。

以下の C# コードは、After animation 効果を変更する方法を示します：
```c#
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // メイン シーケンスの最初の効果を取得します
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // 後のアニメーションタイプを Color に変更します
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // 後のアニメーションの暗くする色を設定します
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // PPTX ファイルをディスクに書き込みます
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```


## **テキスト アニメーション**
Aspose.Slides は、アニメーション効果の *Animate text* ブロックを操作するために以下のプロパティを提供します：

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) は、効果のテキスト アニメーション タイプを示します。シェイプのテキストは次のいずれかでアニメーション化できます：
  - 一度に全体 ([AnimateTextType.AllAtOnce] タイプ)
  - 単語単位 ([AnimateTextType.ByWord] タイプ)
  - 文字単位 ([AnimateTextType.ByLetter] タイプ)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) は、アニメーション化されたテキスト パーツ（単語または文字）間の遅延を設定します。正の値は効果期間のパーセンテージを、負の値は秒単位の遅延を表します。

Effect の Animate text プロパティを変更する方法は次のとおりです：

1. [Apply](#apply-animation-to-shape) またはアニメーション効果を取得します。
2. [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) プロパティを [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) の値に設定して *By Paragraphs* アニメーション モードをオフにします。
3. [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) と [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) プロパティに新しい値を設定します。
4. 変更された PPTX ファイルを保存します。

以下の C# コードは、この操作を示しています：
```c#
	// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
	using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
	{
		ISlide firstSlide = pres.Slides[0];

		// メイン シーケンスの最初の効果を取得します
		IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

		// 効果の Text animation タイプを「As One Object」に変更します
		firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

		// 効果の Animate text タイプを「By word」に変更します
		firstEffect.AnimateTextType = AnimateTextType.ByWord;

		// 単語間の遅延を効果の期間の 20% に設定します
		firstEffect.DelayBetweenTextParts = 20f;

		// PPTX ファイルをディスクに書き込みます
		pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
	}
```


## **FAQ**

**プレゼンテーションを Web に公開する際にアニメーションを保持するにはどうすればよいですか？**  
[Export to HTML5](/slides/ja/net/export-to-html5/) を使用し、[options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) で [shape](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) と [transition](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) アニメーションを有効にします。プレーン HTML ではスライド アニメーションは再生されませんが、HTML5 では再生されます。

**シェイプの z 順序（レイヤー順序）を変更するとアニメーションにどのような影響がありますか？**  
アニメーションと描画順序は独立しています。エフェクトは表示/非表示のタイミングと種類を制御し、[z-order](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) はどのオブジェクトが他を覆うかを決定します。最終的な表示は両者の組み合わせで決まります。（これは一般的な PowerPoint の動作であり、Aspose.Slides のエフェクトとシェイプのモデルも同様のロジックに従います。）

**特定の効果をビデオに変換する際に制限はありますか？**  
一般的に、[animations are supported](/slides/ja/net/convert-powerpoint-to-video/) ですが、稀なケースや特定の効果は異なる形でレンダリングされることがあります。使用する効果とライブラリのバージョンでテストすることを推奨します。