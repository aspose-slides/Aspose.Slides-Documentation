---
title: ".NETでPowerPointプレゼンテーションを動画に変換する"
linktitle: "PowerPointから動画へ"
type: docs
weight: 130
url: /ja/net/convert-powerpoint-to-video/
keywords:
- "PowerPoint を変換"
- "プレゼンテーション を変換"
- "PPT を変換"
- "PPTX を変換"
- "PowerPoint を動画に変換"
- "プレゼンテーション を動画に変換"
- "PPT を動画に変換"
- "PPTX を動画に変換"
- "PowerPoint を MP4 に変換"
- "プレゼンテーション を MP4 に変換"
- "PPT を MP4 に変換"
- "PPTX を MP4 に変換"
- "PPT を MP4 として保存"
- "PPTX を MP4 として保存"
- "PPT を MP4 にエクスポート"
- "PPTX を MP4 にエクスポート"
- "動画変換"
- "PowerPoint"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET で PowerPoint プレゼンテーションを動画に変換する方法を学びます。サンプル C# コードと自動化技術を活用してワークフローを効率化しましょう。"
---

## **概要**

PowerPoint または OpenDocument プレゼンテーションを動画に変換することで、次の利点が得られます。

**アクセシビリティの向上:** プラットフォームに関係なく、すべてのデバイスにはデフォルトで動画プレーヤーが搭載されているため、従来のプレゼンテーションアプリケーションよりも動画の再生や閲覧が容易です。

**リーチの拡大:** 動画はより大きなオーディエンスに届きやすく、情報を魅力的な形式で提示できます。調査や統計によれば、ユーザーは他の形式よりも動画コンテンツの視聴・消費を好むため、メッセージのインパクトが高まります。

{{% alert color="primary" %}} 
[**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/video) をぜひお試しください。こちらは本稿で説明したプロセスをリアルタイムかつ効果的に実装したものです。
{{% /alert %}} 

Aspose.Slides for .NET では、プレゼンテーションを動画に変換する機能を実装しています。

* Aspose.Slides for .NET を使用して、指定したフレームレート (FPS) でスライドからフレームを生成します。  
* その後、ffmpeg などのサードパーティーツールでこれらのフレームを動画にまとめます。

## **PowerPoint プレゼンテーションを動画に変換する方法**

1. `dotnet add package` コマンドで Aspose.Slides と FFMpegCore ライブラリをプロジェクトに追加します:  
   * `dotnet add package Aspose.Slides.NET --version 22.11.0`  
   * `dotnet add package FFMpegCore --version 4.8.0`
2. ffmpeg を [here](https://ffmpeg.org/download.html) からダウンロードします。  
3. FFMpegCore では、ダウンロードした ffmpeg のパスを指定する必要があります (例: 「C:\tools\ffmpeg」に展開した場合):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```

4. PowerPoint から動画への変換コードを実行します。

以下の C# コードは、シェイプと 2 つのアニメーション効果を含むプレゼンテーションを動画に変換する方法を示しています:  
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // 以前に C:\tools\ffmpeg に抽出した FFmpeg バイナリを使用します。
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // スマイルシェイプを追加してからアニメーションを付けます。
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

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

    // ffmpeg バイナリフォルダーを設定します。こちらのページをご覧ください: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // フレームを webm ビデオに変換します。
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **動画エフェクト**

Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションを動画に変換する際、さまざまな動画エフェクトを適用して出力の視覚品質を向上させることができます。これらのエフェクトにより、スムーズなトランジションやアニメーション、その他のビジュアル要素を動画に組み込むことが可能です。本セクションでは利用可能な動画エフェクトオプションとその適用方法を説明します。

{{% alert color="primary" %}} 
- [C# での PowerPoint アニメーションの強化](https://docs.aspose.com/slides/net/powerpoint-animation/)  
- [シェイプ アニメーション](https://docs.aspose.com/slides/net/shape-animation/)  
- [C# で PowerPoint のシェイプ エフェクトを適用する](https://docs.aspose.com/slides/net/shape-effect/)
{{% /alert %}} 

アニメーションやトランジションはスライドショーをより魅力的にしますが、動画でも同様です。前述のプレゼンテーションに別のスライドとトランジションを追加するコード例は次のとおりです:  
```c#
 // スマイルシェイプを追加し、アニメーションを付けます。
 // ...

 // 新しいスライドとアニメーション付きのトランジションを追加します。
 ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
 newSlide.Background.Type = BackgroundType.OwnBackground;
 newSlide.Background.FillFormat.FillType = FillType.Solid;
 newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
 newSlide.SlideShowTransition.Type = TransitionType.Push;
```


Aspose.Slides はテキストアニメーションもサポートしています。以下の例では、オブジェクト上の段落を 1 秒の遅延で順に表示するアニメーションを実装しています:  
```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // テキストとアニメーションを追加します。
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("Convert a PowerPoint presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
        para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
        para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

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

    // ffmpeg バイナリ フォルダーを設定します。こちらのページをご覧ください: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // フレームを webm ビデオに変換します。
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **動画変換クラス**

PowerPoint から動画への変換タスクを実現するために、Aspose.Slides for .NET は [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) と [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) クラスを提供しています。

`PresentationAnimationsGenerator` はコンストラクタで動画のフレームサイズと FPS (1 秒あたりのフレーム数) を設定できます。プレゼンテーション インスタンスを渡すと、その `Presentation.SlideSize` が使用され、生成されたアニメーションは [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) が利用します。

アニメーションが生成されると、各アニメーションごとに `NewAnimation` イベントが発生し、[IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) パラメータが渡されます。このクラスは個々のアニメーション用プレーヤーを表します。

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) を操作するには、全体の再生時間を示す `Duration` プロパティと、再生位置を設定する `SetTimePosition` メソッドを使用します。位置は *0 から Duration* の範囲で指定でき、`GetFrame` メソッドは指定時点のアニメーション状態を表す Bitmap を返します。  
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // スマイルシェイプを追加し、アニメーションを付けます。
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");

            animationPlayer.SetTimePosition(0);          // 初期アニメーション状態。
            Bitmap bitmap = animationPlayer.GetFrame();  // 初期アニメーション状態のビットマップ。

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // アニメーションの最終状態。
            Bitmap lastBitmap = animationPlayer.GetFrame();             // アニメーションの最後のフレーム。
            lastBitmap.Save("last.png");
        };
    }
}
```


すべてのアニメーションを同時に再生させるには、[PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) クラスを使用します。このクラスはコンストラクタで [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) インスタンスと FPS を受け取り、`FrameTick` イベントを介して全アニメーションを再生します:  
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


生成されたフレームは動画にコンパイルできます。詳細は [PowerPoint プレゼンテーションを動画に変換する](/slides/ja/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) セクションをご参照ください。

## **サポートされているアニメーションとエフェクト**

PowerPoint プレゼンテーションを動画に変換する際、出力でサポートされるアニメーションとエフェクトを把握しておくことが重要です。Aspose.Slides はフェード、フライイン、ズーム、スピンなどの一般的な入場、退出、強調エフェクトを幅広くサポートしています。ただし、一部の高度なカスタムアニメーションは完全に保持されないか、動画内で異なる形で表現される場合があります。本節ではサポート対象のアニメーションとエフェクトをまとめています。

**入場 (Entrance):**

| アニメーション タイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**強調 (Emphasis):**

| アニメーション タイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**退出 (Exit):**

| アニメーション タイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**モーション パス (Motion Paths):**

| アニメーション タイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **サポートされているスライド トランジション エフェクト**

スライド トランジション エフェクトは、動画内でスライド間の切り替えをスムーズかつ視覚的に魅力的にする上で重要です。Aspose.Slides for .NET は、元のプレゼンテーションの流れとスタイルを維持するために、一般的に使用されるさまざまなトランジション エフェクトをサポートしています。本節では、変換プロセス中にサポートされるトランジション エフェクトを紹介します。

**サブティル (Subtle):**

| アニメーション タイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**エキサイティング (Exciting):**

| アニメーション タイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**ダイナミック コンテンツ (Dynamic Content):**

| アニメーション タイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**パスワードで保護されたプレゼンテーションを変換できますか？**

はい、Aspose.Slides for .NET はパスワード保護されたプレゼンテーションの取り扱いをサポートしています。処理時に正しいパスワードを指定すれば、ライブラリはプレゼンテーションの内容にアクセスできます。

**Aspose.Slides for .NET はクラウド ソリューションでの使用をサポートしていますか？**

はい、Aspose.Slides for .NET はクラウド アプリケーションやサービスに組み込むことができます。サーバー環境での高パフォーマンスとスケーラビリティを念頭に設計されており、バッチ処理に適しています。

**変換時にプレゼンテーションのサイズ制限はありますか？**

Aspose.Slides for .NET は実質的に任意のサイズのプレゼンテーションを処理できます。ただし、非常に大きなファイルの場合は追加のシステムリソースが必要になることがあり、パフォーマンス向上のためにプレゼンテーションを最適化することが推奨される場合があります。