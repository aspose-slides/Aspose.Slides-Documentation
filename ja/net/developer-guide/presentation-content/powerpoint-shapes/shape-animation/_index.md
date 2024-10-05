---
title: 形のアニメーション
type: docs
weight: 60
url: /net/shape-animation/
keywords: 
- PowerPoint アニメーション
- アニメーション効果
- アニメーションの適用
- PowerPoint プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C# または .NET で PowerPoint アニメーションを適用する"
---

アニメーションは、テキスト、画像、図形、または[チャート](/slides/net/animated-charts/)に適用できる視覚効果です。これにより、プレゼンテーションやその構成要素に命を吹き込むことができます。

### **プレゼンテーションにアニメーションを使用する理由は？**

アニメーションを使用することで、次のことが可能になります。

* 情報の流れを制御する
* 重要なポイントを強調する
* 聴衆の興味や参加を増やす
* コンテンツを読みやすく、理解しやすく、処理しやすくする
* プレゼンテーションの重要な部分に読者や視聴者の注意を引く

PowerPoint は、**入口**、**出口**、**強調**、および **動きの経路** カテゴリ全体にわたって、アニメーションとアニメーション効果のための多くのオプションとツールを提供します。

### **Aspose.Slides におけるアニメーション**

* Aspose.Slides は、[Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) 名前空間の下でアニメーションを操作するために必要なクラスと型を提供します。
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) 列挙型の下で、150 以上のアニメーション効果を提供しています。これらの効果は、PowerPoint で使用される効果と本質的に同じ（または同等の）効果です。

## **TextBox にアニメーションを適用する**

Aspose.Slides for .NET を使用すると、図形内のテキストにアニメーションを適用できます。

1. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) を追加します。
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) にテキストを追加します。
5. 主シーケンスの効果を取得します。
6. [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) にアニメーション効果を追加します。
7. [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) プロパティを [BuildType Enumeration](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype) の値に設定します。
8. プレゼンテーションをディスクに PPTX ファイルとして書き込みます。

この C# コードは、AutoShape に `Fade` 効果を適用し、テキストアニメーションを *1 番目のレベルの段落ごと* の値に設定する方法を示しています：

```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // テキストがある新しい AutoShape を追加します
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "最初の段落 \n第二の段落 \n第三の段落";

    // スライドの主シーケンスを取得します。
    ISequence sequence = sld.Timeline.MainSequence;

    // 形状に Fade アニメーション効果を追加します
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 1 番目のレベルの段落ごとに形状のテキストをアニメーション化します
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // PPTX ファイルをディスクに保存します
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

テキストにアニメーションを適用するだけでなく、単一の[段落](https://reference.aspose.com/slides/net/aspose.slides/iparagraph)にもアニメーションを適用できます。 [**アニメーションテキスト**](/slides/net/animated-text/)を参照してください。

{{% /alert %}} 

## **PictureFrame にアニメーションを適用する**

1. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. スライド上の [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) を追加または取得します。
5. 主シーケンスの効果を取得します。
6. [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) にアニメーション効果を追加します。
8. プレゼンテーションをディスクに PPTX ファイルとして書き込みます。

この C# コードは、ピクチャーフレームに `Fly` 効果を適用する方法を示しています：

```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
using (Presentation pres = new Presentation())
{
    // プレゼンテーションの画像コレクションに追加される画像をロードします
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // スライドにピクチャーフレームを追加します
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // スライドの主シーケンスを取得します。
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // ピクチャーフレームに左からの Fly アニメーション効果を追加します
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX ファイルをディスクに保存します
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Shape にアニメーションを適用する**

1. [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) を追加します。
4. クリック時にアニメーションが再生される `Bevel` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) を追加します。
5. ビベル シェイプの効果のシーケンスを作成します。
6. カスタムの `UserPath` を作成します。
7. `UserPath` への移動コマンドを追加します。
8. プレゼンテーションをディスクに PPTX ファイルとして書き込みます。

この C# コードは、形状に `PathFootball`（パス フットボール）効果を適用する方法を示しています：

```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // 既存の形状の PathFootball 効果をゼロから作成します。
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("アニメーションテキストボックス");

    // PathFootBall アニメーション効果を追加します。
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 何らかの「ボタン」を作成します。
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // ボタンの効果のシーケンスを作成します。
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // カスタムユーザーパスを作成します。ボタンがクリックされるまで、オブジェクトは移動しません。
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // 作成されたパスは空のため移動コマンドを追加します。
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // PPTX ファイルをディスクに保存します
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Shape に適用されたアニメーション効果を取得する**

単一の形状に適用されたすべてのアニメーション効果を見つけることができます。

この C# コードは、特定の形状に適用されたすべての効果を取得する方法を示しています：

```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // スライドの主シーケンスを取得します。
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // スライド上の最初の形状を取得します。
    IShape shape = firstSlide.Shapes[0];

    // 形状に適用されたすべてのアニメーション効果を取得します。
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine("形状 " + shape.Name + " は " + shapeEffects.Length + " のアニメーション効果を持っています。");
}
```

## **アニメーション効果のタイミングプロパティを変更する**

Aspose.Slides for .NET を使用すると、アニメーション効果のタイミングプロパティを変更できます。

これは Microsoft PowerPoint におけるアニメーションタイミングペインと拡張メニューです：

![example1_image](shape-animation.png)

PowerPoint タイミング **開始** ドロップダウンリストは、[Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype) プロパティに対応しています。 
PowerPoint タイミング **持続時間** は、[Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration) プロパティに一致します。アニメーションの持続時間（秒）は、アニメーションが 1 サイクルを完了するのにかかる総時間です。 
PowerPoint タイミング **遅延** は、[Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime) プロパティに対応しています。 
PowerPoint タイミング **繰り返し** ドロップダウンリストは、次のプロパティに一致します： 
  * 効果の繰り返し回数を示す[Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount) プロパティ。
  * 効果がスライドの最後まで繰り返されるかどうかを示す [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide) フラグ。
  * 効果が次のクリックまで繰り返されるかどうかを示す [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick) フラグ。
- PowerPoint タイミング **再生完了時に巻き戻す** チェックボックスは、[Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/) プロパティに一致します。 

これは、効果のタイミングプロパティを変更する方法です。

1. [アニメーション効果を適用](#apply-animation-to-shape)または取得します。
2. 必要な [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) プロパティに新しい値を設定します。 
3. 修正された PPTX ファイルを保存します。

この C# コードは、操作を示しています：

```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // スライドの主シーケンスを取得します。
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // 主シーケンスの最初の効果を取得します。
    IEffect effect = sequence[0];

    // 効果の TriggerType をクリック時に開始するように変更します
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // 効果の持続時間を変更します
    effect.Timing.Duration = 3f;

    // 効果の TriggerDelayTime を変更します
    effect.Timing.TriggerDelayTime = 0.5f;

    // 効果の繰り返し値が「なし」の場合
    if (effect.Timing.RepeatCount == 1f)
    {
        // 効果の繰り返しを「次回のクリックまで」に変更します
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // 効果の繰り返しを「スライドの終了まで」に変更します
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // 効果を巻き戻します
        effect.Timing.Rewind = true;
    
    // PPTX ファイルをディスクに保存します
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **アニメーション効果の音**

Aspose.Slides は、アニメーション効果の音を操作するために、次のプロパティを提供します：
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/) 

### **アニメーション効果の音を追加する**

この C# コードは、アニメーション効果の音を追加し、次の効果が開始されるときにそれを停止する方法を示しています：

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// プレゼンテーションの音声コレクションにオーディオを追加します
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// スライドの主シーケンスを取得します。
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// 主シーケンスの最初の効果を取得します
	IEffect firstEffect = sequence[0];

	// 効果の「無音」チェック
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// 最初の効果の音を追加します
		firstEffect.Sound = effectSound;
	}

	// スライドの最初のインタラクティブシーケンスを取得します。
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// 効果の「前の音を停止する」フラグを設定します
	interactiveSequence[0].StopPreviousSound = true;

	// PPTX ファイルをディスクに書き込みます
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **アニメーション効果の音を抽出する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。 
3. 主シーケンスの効果を取得します。 
4. 各アニメーション効果に埋め込まれた[Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/)を抽出します。 

この C# コードは、アニメーション効果に埋め込まれた音を抽出する方法を示しています：

```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // スライドの主シーケンスを取得します。
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // 効果音をバイト配列に抽出します
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **アニメーション後**

Aspose.Slides for .NET を使用すると、アニメーション効果のアフターアニメーションプロパティを変更できます。

これは Microsoft PowerPoint におけるアニメーション効果ペインと拡張メニューです：

![example1_image](shape-after-animation.png)

PowerPoint 効果 **アフターアニメーション** ドロップダウンリストは、次のプロパティに一致します：

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) プロパティはアフターアニメーションタイプを説明します：
  * PowerPoint **その他の色** は、[AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) タイプに一致します。
  * PowerPoint **暗くしない** リスト項目は、[AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) タイプ（デフォルトのアフターアニメーションタイプ）に一致します。
  * PowerPoint **アニメーション後に非表示** 項目は、[AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) タイプに一致します。
  * PowerPoint **次のマウスクリックで非表示** 項目は、[AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) タイプに一致します。
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) プロパティは、アフターアニメーションのカラー形式を定義します。このプロパティは、[AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) タイプと協力して機能します。他のタイプに変更すると、アフターアニメーションカラーはクリアされます。

この C# コードは、アフターアニメーション効果を変更する方法を示しています：

```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // 主シーケンスの最初の効果を取得します
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // アフターアニメーションタイプをカラーに変更します
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // アフターアニメーションの淡色を設定します
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // PPTX ファイルをディスクに保存します
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **テキストをアニメートする**

Aspose.Slides は、アニメーション効果の *テキストをアニメート* ブロックを操作するための次のプロパティを提供します。

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) は、効果のアニメートテキストタイプを説明します。図形のテキストは次の方法でアニメーション化できます：
  - 一度にすべて ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) タイプ)
  - 単語ごと ([AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) タイプ)
  - 文字ごと ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) タイプ)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) は、アニメーション化されたテキスト部分（単語または文字）の間の遅延を設定します。正の値は効果の持続時間の割合を示し、負の値は秒単位での遅延を示します。

これは、効果のアニメート テキストプロパティを変更する方法です：

1. [アニメーション効果を適用](#apply-animation-to-shape)または取得します。
2. [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) プロパティを [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) 値に設定して、*段落ごと* のアニメーションモードをオフにします。
3. [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) と [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) プロパティに新しい値を設定します。
4. 修正された PPTX ファイルを保存します。

この C# コードは、操作を示しています：

```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // 主シーケンスの最初の効果を取得します
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // 効果のテキストアニメーションタイプを「1つのオブジェクト」として変更します
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // 効果のアニメートテキストタイプを「単語ごと」として変更します
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // 単語間の遅延を効果の持続時間の 20% に設定します
    firstEffect.DelayBetweenTextParts = 20f;

    // PPTX ファイルをディスクに保存します
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```