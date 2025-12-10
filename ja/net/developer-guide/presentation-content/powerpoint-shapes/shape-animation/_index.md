---
title: .NET のプレゼンテーションでシェイプ アニメーションを適用する
linktitle: シェイプ アニメーション
type: docs
weight: 60
url: /ja/net/shape-animation/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションのシェイプ アニメーションを作成およびカスタマイズする方法を紹介します。目立ちましょう！"
---

アニメーションは、テキスト、画像、図形、または[チャート](/slides/ja/net/animated-charts/)に適用できる視覚効果です。プレゼンテーションやその構成要素に命を吹き込みます。

## **プレゼンテーションでアニメーションを使用する理由**

* 情報の流れを制御する
* 重要なポイントを強調する
* 聴衆の関心や参加を高める
* コンテンツを読みやすく、理解しやすく、または処理しやすくする
* 読者や視聴者の注意をプレゼンテーションの重要な部分に引きつける

PowerPoint は、**entrance**、**exit**、**emphasis**、および**motion paths** カテゴリにわたるアニメーションとアニメーション効果の多くのオプションとツールを提供します。

## **Aspose.Slides のアニメーション**

* Aspose.Slides は、アニメーションを操作するために必要なクラスと型を [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) 名前空間で提供します、  
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) 列挙体で **150** 以上のアニメーション効果を提供します。これらの効果は、本質的に PowerPoint で使用されているものと同じ（または同等）です。

## **テキストボックスへのアニメーション適用**

Aspose.Slides for .NET を使用すると、図形内のテキストにアニメーションを適用できます。

1. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) クラスのインスタンスを作成します。
2. スライドのインデックスを使用して参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) を追加します。
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) にテキストを追加します。
5. 主なエフェクト シーケンスを取得します。
6. [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) にアニメーション効果を追加します。
7. [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) プロパティを [BuildType Enumeration](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype) の値に設定します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この C# コードは、`Fade` 効果を AutoShape に適用し、テキスト アニメーションを *By 1st Level Paragraphs* の値に設定する方法を示します：
```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // テキスト付きの新しいAutoShapeを追加します
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // スライドのメインシーケンスを取得します
    ISequence sequence = sld.Timeline.MainSequence;

    // シェイプにFadeアニメーション効果を追加します
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // シェイプテキストを第1レベル段落単位でアニメートします
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // PPTXファイルをディスクに保存します
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```


{{%  alert color="primary"  %}} 
テキストへのアニメーション適用に加えて、単一の[Paragraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph)にアニメーションを適用することもできます。[**Animated Text**](/slides/ja/net/animated-text/) を参照してください。
{{% /alert %}} 

## **PictureFrame へのアニメーション適用**

1. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) クラスのインスタンスを作成します。
2. スライドのインデックスを使用して参照を取得します。
3. スライド上に[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) を追加または取得します。
5. 主なエフェクト シーケンスを取得します。
6. [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) にアニメーション効果を追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この C# コードは、`Fly` 効果を picture frame に適用する方法を示します：
```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
using (Presentation pres = new Presentation())
{
    // プレゼンテーションの画像コレクションに追加する画像を読み込みます
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // スライドに画像フレームを追加します
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // スライドのメインシーケンスを取得します
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // 画像フレームに左からのフライアニメーション効果を追加します
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTXファイルをディスクに保存します
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```


## **Shape へのアニメーション適用**

1. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) クラスのインスタンスを作成します。
2. スライドのインデックスを使用して参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) を追加します。
4. `Bevel` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) を追加します（このオブジェクトがクリックされるとアニメーションが再生されます）。
5. ベベル形状上でエフェクト シーケンスを作成します。
6. カスタム `UserPath` を作成します。
7. `UserPath` への移動コマンドを追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この C# コードは、`PathFootball`（パスフットボール）効果を shape に適用する方法を示します：
```c#
// プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成します。
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // 既存のシェイプに対してPathFootball効果を一から作成します。
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // PathFootBallアニメーション効果を追加します。
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // いわゆる「ボタン」を作成します。
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // ボタン用の効果シーケンスを作成します。
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // カスタムユーザーパスを作成します。オブジェクトはボタンがクリックされた後にのみ移動します。
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // 作成したパスが空なので、移動コマンドを追加します。
    IMotionEffect motionBvh = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBvh.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBvh.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBvh.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // PPTXファイルをディスクに書き込みます
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```


## **Shape に適用されたアニメーション効果の取得**

以下の例は、[ISequence](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/) インターフェイスの `GetEffectsByShape` メソッドを使用して shape に適用されたすべてのアニメーション効果を取得する方法を示します。

**例 1: 通常スライド上の Shape に適用されたアニメーション効果の取得**

以前、PowerPoint プレゼンテーションの shape にアニメーション効果を追加する方法を学びました。次のサンプルコードは、プレゼンテーション `AnimExample_out.pptx` の最初の通常スライド上の最初の shape に適用された効果を取得する方法を示します。
```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // スライドのメインアニメーションシーケンスを取得します。
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // スライド上の最初のシェイプを取得します。
    IShape shape = firstSlide.Shapes[0];

    // シェイプに適用されたアニメーション効果を取得します。
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```


**例 2: プレースホルダーから継承されたものを含むすべてのアニメーション効果の取得**

通常スライド上の shape にレイアウトスライドやマスタースライド上のプレースホルダーがあり、これらのプレースホルダーにアニメーション効果が追加されている場合、スライドショー中に shape のすべての効果が再生され、プレースホルダーから継承されたものも含まれます。

たとえば、`sample.pptx` という PowerPoint ファイルにフッター shape（テキスト「Made with Aspose.Slides」）が1つだけあり、**Random Bars** 効果がその shape に適用されているとします。

![スライド シェイプ アニメーション効果](slide-shape-animation.png)

さらに、レイアウトスライドのフッタープレースホルダーに **Split** 効果が適用されているとします。

![レイアウト シェイプ アニメーション効果](layout-shape-animation.png)

最後に、マスタースライドのフッタープレースホルダーに **Fly In** 効果が適用されているとします。

![マスター シェイプ アニメーション効果](master-shape-animation.png)

次のサンプルコードは、[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) インターフェイスの `GetBasePlaceholder` メソッドを使用して shape のプレースホルダーにアクセスし、レイアウトおよびマスタースライド上のプレースホルダーから継承されたものを含むフッター shape に適用されたアニメーション効果を取得する方法を示します。
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


出力：
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **アニメーション効果のタイミング プロパティの変更**

Aspose.Slides for .NET は、アニメーション効果のタイミング プロパティを変更できます。

これは Microsoft PowerPoint のアニメーション タイミング パネルと拡張メニューです：

![example1_image](shape-animation.png)

以下は PowerPoint のタイミングと [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) プロパティの対応関係です：
- PowerPoint のタイミング **Start** ドロップダウンは [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype) プロパティに対応します。  
- PowerPoint のタイミング **Duration** は [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration) プロパティに対応します。アニメーションの期間（秒）は、アニメーションが 1 サイクルを完了するのにかかる総時間です。  
- PowerPoint のタイミング **Delay** は [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime) プロパティに対応します。  
- PowerPoint のタイミング **Repeat** ドロップダウンは次のプロパティに対応します：  
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount) プロパティ（効果が繰り返される回数）  
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide) フラグ（スライドの最後まで繰り返すか）  
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick) フラグ（次のクリックまで繰り返すか）  
- PowerPoint のタイミング **Rewind when done playing** チェックボックスは [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/) プロパティに対応します。  

Effect のタイミング プロパティを変更する手順：

1. [Apply](#apply-animation-to-shape) するか、アニメーション効果を取得します。
2. 必要な [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) プロパティに新しい値を設定します。  
3. 修正した PPTX ファイルを保存します。

この C# コードは操作を示します：
```c#
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // スライドのメインシーケンスを取得します。
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // メインシーケンスの最初の効果を取得します。
    IEffect effect = sequence[0];

    // 効果の TriggerType をクリックで開始するように変更します。
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // 効果の Duration を変更します。
    effect.Timing.Duration = 3f;

    // 効果の TriggerDelayTime を変更します。
    effect.Timing.TriggerDelayTime = 0.5f;

    // 効果の Repeat 値が "none" の場合
    if (effect.Timing.RepeatCount == 1f)
    {
        // 効果の Repeat を "Until Next Click" に変更します。
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // 効果の Repeat を "Until End of Slide" に変更します。
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // 効果の Rewind を有効にします。
        effect.Timing.Rewind = true;
    
    // PPTX ファイルをディスクに保存します。
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```


## **アニメーション効果のサウンド**

Aspose.Slides は、アニメーション効果のサウンドを操作するために次のプロパティを提供します：  
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/)  
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/)  

### **アニメーション効果サウンドの追加**

この C# コードは、アニメーション効果サウンドを追加し、次の効果が開始されたときにそれを停止する方法を示します：
```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// プレゼンテーションのオーディオコレクションに音声を追加します
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// スライドのメインシーケンスを取得します。
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// メインシーケンスの最初の効果を取得します。
	IEffect firstEffect = sequence[0];

	// 効果に「サウンドなし」があるかチェックします
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// 最初の効果にサウンドを追加します
		firstEffect.Sound = effectSound;
	}

	// スライドの最初のインタラクティブシーケンスを取得します。
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// 効果の「前のサウンドを停止」フラグを設定します
	interactiveSequence[0].StopPreviousSound = true;

	// PPTXファイルをディスクに書き込みます
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```


### **アニメーション効果サウンドの抽出**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドのインデックスを使用して参照を取得します。 
3. 主なエフェクト シーケンスを取得します。 
4. 各アニメーション効果に埋め込まれた [Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) を抽出します。 

この C# コードは、アニメーション効果に埋め込まれたサウンドを抽出する方法を示します：
```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // スライドのメインシーケンスを取得します。
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

Aspose.Slides for .NET は、アニメーション効果の「After animation」プロパティを変更できます。

これは Microsoft PowerPoint のアニメーション効果パネルと拡張メニューです：

![example1_image](shape-after-animation.png)

PowerPoint の **After animation** ドロップダウンは次のプロパティに対応します：  

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) プロパティ（After animation のタイプ）  
  * PowerPoint の **More Colors** は [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) タイプに対応します。  
  * PowerPoint の **Don't Dim** は [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) タイプ（デフォルト）に対応します。  
  * PowerPoint の **Hide After Animation** は [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) タイプに対応します。  
  * PowerPoint の **Hide on Next Mouse Click** は [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) タイプに対応します。  
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) プロパティは After animation のカラー形式を定義します。このプロパティは [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) タイプと連動して動作します。タイプを別のものに変更すると、After animation のカラーはクリアされます。  

この C# コードは、After animation 効果を変更する方法を示します：
```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // メインシーケンスの最初の効果を取得します
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // アフターアニメーションのタイプを Color に変更します
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // アフターアニメーションの暗くする色を設定します
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // PPTX ファイルをディスクに書き込みます
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```


## **テキストのアニメーション**

Aspose.Slides は、アニメーション効果の *Animate text* ブロックを操作するために次のプロパティを提供します：  

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/)（効果の Animate text タイプ）形状のテキストは次のいずれかでアニメーション化できます：  
  - All at once（[AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/)）  
  - By word（[AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/)）  
  - By letter（[AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/)）  
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) は、アニメーション化されたテキスト部分（単語または文字）間の遅延を設定します。正の値は効果継続時間のパーセンテージを示し、負の値は秒単位の遅延を示します。  

Effect の Animate text プロパティを変更する手順：

1. [Apply](#apply-animation-to-shape) するか、アニメーション効果を取得します。  
2. [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) プロパティを [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) の値に設定し、*By Paragraphs* アニメーション モードをオフにします。  
3. 新しい値を [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) および [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) に設定します。  
4. 修正した PPTX ファイルを保存します。  

この C# コードは操作を示します：
```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// メインシーケンスの最初の効果を取得します
	IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

	// エフェクトのテキストアニメーションタイプを「As One Object」に変更します
	firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

	// エフェクトのアニメートテキストタイプを「By word」に変更します
	firstEffect.AnimateTextType = AnimateTextType.ByWord;

	// 単語間の遅延をエフェクト期間の20%に設定します
	firstEffect.DelayBetweenTextParts = 20f;

	// PPTX ファイルをディスクに保存します
	pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**プレゼンテーションを Web に公開する際にアニメーションを保持するにはどうすればよいですか？**

[HTML5 へのエクスポート](/slides/ja/net/export-to-html5/) を使用し、[shape](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) および [transition](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) アニメーションを有効にするオプションを設定します。プレーン HTML ではスライド アニメーションは再生されませんが、HTML5 では再生されます。

**shape の Z オーダー（レイヤー順）を変更するとアニメーションにどのような影響がありますか？**

アニメーションと描画順序は独立しています。効果は表示/非表示のタイミングとタイプを制御し、[z-order](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) は何が何を覆うかを決めます。最終的な見た目は両者の組み合わせで決まります。（これは PowerPoint の一般的な動作であり、Aspose.Slides の効果と shape のモデルも同様です。）

**特定の効果をビデオに変換する際に制限はありますか？**

一般に、[アニメーションはサポートされています](/slides/ja/net/convert-powerpoint-to-video/)、ただしまれに例外や特定の効果が異なる方法でレンダリングされることがあります。使用する効果とライブラリのバージョンでテストすることを推奨します。