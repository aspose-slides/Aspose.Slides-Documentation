---
title: PowerPointをビデオに変換
type: docs
weight: 130
url: /ja/net/convert-powerpoint-to-video/
keywords: "PowerPointを変換, PPT, PPTX, プレゼンテーション, ビデオ, MP4, PPTをビデオに, PPTをMP4に, C#, Csharp, .NET, Aspose.Slides"
description: "C#または.NETでPowerPointをビデオに変換"
---

PowerPointプレゼンテーションをビデオに変換することで、次の利点があります。

* **アクセシビリティの向上:** プレゼンテーションを開くアプリケーションと比較すると、すべてのデバイス（プラットフォームに関係なく）はデフォルトでビデオプレーヤーを備えているため、ユーザーはビデオを開くまたは再生するのが簡単です。
* **到達範囲の拡大:** ビデオを通じて、広範なオーディエンスにリーチし、プレゼンテーションでは退屈に思えるかもしれない情報をターゲットにすることができます。ほとんどの調査や統計によると、人々は他の形態のコンテンツよりもビデオを視聴し、消費することが多く、一般的にそのようなコンテンツを好みます。

{{% alert color="primary" %}} 

こちらの[**PowerPointをビデオに変換するオンラインコンバーター**](https://products.aspose.app/slides/conversion/ppt-to-word)を確認することをお勧めします。これは、ここで説明されたプロセスのライブで効果的な実装です。

{{% /alert %}} 

## **Aspose.SlidesにおけるPowerPointからビデオへの変換**

[Aspose.Slides 22.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-22-11-release-notes/)で、プレゼンテーションからビデオへの変換をサポートしました。

* Aspose.Slidesを使用して、特定のFPS（フレーム毎秒）に対応する一連のフレーム（プレゼンテーションスライドから）を生成します。
* FFMpegCore（ffmpeg）などのサードパーティユーティリティを使用して、フレームに基づいてビデオを作成します。 

### **PowerPointをビデオに変換**

1. dotnet add packageコマンドを使用して、Aspose.SlidesおよびFFMpegCoreライブラリをプロジェクトに追加します：
   * `dotnet add package Aspose.Slides.NET --version 22.11.0`を実行します。
   * `dotnet add package FFMpegCore --version 4.8.0`を実行します。
2. ここからffmpegをダウンロードします。[ここ](https://ffmpeg.org/download.html)。
3. FFMpegCoreは、ダウンロードしたffmpegへのパスを指定する必要があります（例: "C:\tools\ffmpeg"に解凍した場合）： `GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin",} );`
4. PowerPointをビデオに変換するコードを実行します。

このC#コードは、プレゼンテーション（図と2つのアニメーション効果を含む）をビデオに変換する方法を示しています：

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // "c:\tools\ffmpeg"に解凍したFFmpegバイナリを使用します
using Aspose.Slides.Animation;
using (Presentation presentation = new Presentation())

{
    // 笑顔の形を追加し、アニメーションを加えます
    IAutoShape smile = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    IEffect effectIn = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

   const int Fps = 33;
   List<string> frames = new List<string>();

   using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }

    // ffmpegバイナリフォルダーを設定します。このページを参照してください: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin", });
    // フレームをwebmビデオに変換します
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());

}
```

## **ビデオ効果**

スライド上のオブジェクトにアニメーションを適用し、スライド間の遷移を使用できます。

{{% alert color="primary" %}} 

これらの文書をご覧になることをお勧めします: [PowerPointアニメーション](https://docs.aspose.com/slides/net/powerpoint-animation/)、[図形のアニメーション](https://docs.aspose.com/slides/net/shape-animation/)、および[図形効果](https://docs.aspose.com/slides/net/shape-effect/)。

{{% /alert %}} 

アニメーションと遷移はスライドショーをより魅力的で面白くし、ビデオに対しても同じことを行います。前のプレゼンテーションのコードに別のスライドと遷移を追加しましょう：

```c#
// 笑顔の形を追加し、アニメーションを加えます

// ...

// 新しいスライドとアニメーション遷移を追加します

ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

newSlide.Background.Type = BackgroundType.OwnBackground;

newSlide.Background.FillFormat.FillType = FillType.Solid;

newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;

newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slidesでは、テキストのアニメーションもサポートされています。したがって、オブジェクト上の段落にアニメーションを適用し、1秒の遅延で順に表示されるようにします：

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    // テキストとアニメーションを追加します
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("テキストを含むPowerPointプレゼンテーションをビデオに変換"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("段落ごとに"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    // フレームをビデオに変換します
    const int Fps = 33;
    List<string> frames = new List<string>();
    
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))

    using (var player = new PresentationPlayer(animationsGenerator, Fps))

    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }
    // ffmpegバイナリフォルダーを設定します。このページを参照してください: https://github.com/rosenbjerg/FFMpegCore#installation

    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin", });
    // フレームをwebmビデオに変換します
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());

}
```

## **ビデオ変換クラス**

PowerPointからビデオへの変換タスクを実行できるように、Aspose.Slidesは[PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/)および[PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/)クラスを提供します。

PresentationAnimationsGeneratorを使用すると、後で作成されるビデオのフレームサイズをコンストラクタを通じて設定できます。プレゼンテーションのインスタンスを渡すと、`Presentation.SlideSize`が使用され、[PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/)が使用するアニメーションを生成します。 

アニメーションが生成されると、各後続アニメーションについて`NewAnimation`イベントが生成され、[IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/)パラメータがあります。後者は、個別のアニメーション用のプレーヤーを表すクラスです。

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/)と連携するために、[Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/)（アニメーションの総持続時間）プロパティと[SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/)メソッドが使用されます。各アニメーション位置は*0からduration*の範囲内で設定され、次に`GetFrame`メソッドは、その時点でのアニメーション状態に対応するBitmapを返します。

```c#
using (Presentation presentation = new Presentation())
{
    // 笑顔の形を追加し、アニメーションを加えます
    IAutoShape smile = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    IEffect effectIn = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"アニメーションの総持続時間: {animationPlayer.Duration}");
            
            animationPlayer.SetTimePosition(0); // 初期アニメーション状態
            Bitmap bitmap = animationPlayer.GetFrame(); // 初期アニメーション状態のビットマップ

            animationPlayer.SetTimePosition(animationPlayer.Duration); // アニメーションの最終状態
            Bitmap lastBitmap = animationPlayer.GetFrame(); // アニメーションの最終フレーム
            lastBitmap.Save("last.png");
        };
    }
}
```

プレゼンテーション内のすべてのアニメーションを一度に再生する場合は、[PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/)クラスを使用します。このクラスは、[PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/)インスタンスと、効果のFPSをコンストラクタに取り込み、すべてのアニメーションを再生するために`FrameTick`イベントを呼び出します：

```c#
using (Presentation presentation = new Presentation("animated.pptx"))
{
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, 33))
    {
        player.FrameTick += (sender, args) =>
        {
            args.GetFrame().Save($"frame_{sender.FrameIndex}.png");
        };
        animationsGenerator.Run(presentation.Slides);
    }
}
```

生成されたフレームは、ビデオを作成するためにコンパイルできます。[PowerPointをビデオに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-video/#convert-powerpoint-to-video)セクションを参照してください。

## **サポートされているアニメーションと効果**


**入口**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **出現** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **フェード** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **フライイン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **フロートイン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スプリット** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ワイプ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **シェイプ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ホイール** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ランダムバー** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **グロウ＆ターン** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ズーム** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スイベル** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **バウンス** | ![サポートされています](v.png) | ![サポートされています](v.png) |


**強調**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **パルス** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **カラー パルス** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ティーター** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スピン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **成長/縮小** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **デサチュレート** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **暗くする** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **明るくする** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **透明度** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **オブジェクトカラー** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **補色** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ラインカラー** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **塗りつぶしカラー** | ![サポートされていません](x.png) | ![サポートされています](v.png) |

**退出**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **消失** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **フェード** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **フライアウト** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **フロートアウト** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スプリット** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ワイプ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **シェイプ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ランダムバー** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **縮小＆ターン** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ズーム** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スイベル** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **バウンス** | ![サポートされています](v.png) | ![サポートされています](v.png) |

**モーションパス**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **ライン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **アーク** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ターン** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **形状** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ループ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **カスタムパス** | ![サポートされています](v.png) | ![サポートされています](v.png) |

## **サポートされているスライド遷移効果**

**微妙**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **モーフ** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **フェード** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **プッシュ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **プル** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ワイプ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **スプリット** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **リビール** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ランダムバー** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **シェイプ** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **アンカバー** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **カバー** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **フラッシュ** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ストリップ** | ![サポートされています](v.png) | ![サポートされています](v.png) |

**エキサイティング**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **フォールオーバー** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ドレープ** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **カーテン** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **風** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **プレステージ** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **フラクチャー** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **クラッシュ** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **剥がす** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ページカール** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **飛行機** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **折り紙** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **溶解** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **チェッカーボード** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ブラインド** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **時計** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **波紋** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ハニカム** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **グリッター** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **渦** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **シュレッド** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **スイッチ** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **フリップ** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ギャラリー** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **キューブ** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ドア** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ボックス** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **コーム** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **ズーム** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **ランダム** | ![サポートされていません](x.png) | ![サポートされています](v.png) |

**動的コンテンツ**:

| アニメーションの種類 | Aspose.Slides | PowerPoint |
|---|---|---|
| **パン** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **観覧車** | ![サポートされています](v.png) | ![サポートされています](v.png) |
| **コンベヤ** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **回転** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **軌道** | ![サポートされていません](x.png) | ![サポートされています](v.png) |
| **飛行を通過する** | ![サポートされています](v.png) | ![サポートされています](v.png) |