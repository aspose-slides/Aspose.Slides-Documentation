---
title: PowerPoint プレゼンテーションを .NET で動画に変換する
linktitle: PowerPoint を動画に変換
type: docs
weight: 130
url: /ja/net/convert-powerpoint-to-video/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- PPT を変換
- PPTX を変換
- PowerPoint を動画に変換
- プレゼンテーションを動画に変換
- PPT を動画に変換
- PPTX を動画に変換
- PowerPoint を MP4 に変換
- プレゼンテーションを MP4 に変換
- PPT を MP4 に変換
- PPTX を MP4 に変換
- PPT を MP4 として保存
- PPTX を MP4 として保存
- PPT を MP4 にエクスポート
- PPTX を MP4 にエクスポート
- 動画変換
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: ".NET で PowerPoint プレゼンテーションを動画に変換する方法を学びます。ワークフローを効率化するサンプル C# コードと自動化テクニックをご紹介します。"
---

## **概要**

PowerPoint または OpenDocument プレゼンテーションを動画に変換することで、次のメリットが得られます：

**アクセシビリティの向上:** すべてのデバイスはデフォルトで動画プレーヤーを備えているため、従来のプレゼンテーションアプリケーションよりも動画の再生や開封が容易です。

**リーチの拡大:** 動画はより大きな視聴者にリーチでき、情報をより魅力的な形で提示できます。調査や統計によると、人々は他の形態よりも動画コンテンツの視聴・消費を好むため、メッセージのインパクトが高まります。

{{% alert color="primary" %}} 
以下の[**PowerPoint を動画に変換するオンラインコンバータ**](https://products.aspose.app/slides/video)をご確認ください。こちらは本記事で説明したプロセスをライブかつ効果的に実装しています。
{{% /alert %}} 

Aspose.Slides for .NET では、プレゼンテーションを動画に変換する機能を実装しました。

* Aspose.Slides for .NET を使用して、プレゼンテーションのスライドから指定したフレームレート（FPS）でフレームを生成します。
* その後、ffmpeg などのサードパーティユーティリティを使用して、これらのフレームを動画に結合します。

## **PowerPoint プレゼンテーションを動画に変換する**

1. `dotnet add package` コマンドで Aspose.Slides と FFMpegCore ライブラリをプロジェクトに追加します：
   * `dotnet add package Aspose.Slides.NET --version 22.11.0` を実行
   * `dotnet add package FFMpegCore --version 4.8.0` を実行
2. ffmpeg を[here](https://ffmpeg.org/download.html)からダウンロードします。
3. FFMpegCore では、ダウンロードした ffmpeg のパス（例: "C:\tools\ffmpeg" に展開）を指定する必要があります：  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```

4. PowerPoint から動画への変換コードを実行します。

この C# コードは、シェイプと 2 つのアニメーション効果を含むプレゼンテーションを動画に変換する方法を示しています：
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // 以前抽出した C:\tools\ffmpeg の FFmpeg バイナリを使用します。
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // スマイル形状を追加し、アニメーションを付けます。
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

    // ffmpeg バイナリ フォルダーを設定します。こちらのページをご参照ください: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // フレームを WebM ビデオに変換します。
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **動画エフェクト**

Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションを動画に変換する際、出力の視覚品質を向上させるさまざまな動画エフェクトを適用できます。これらのエフェクトにより、スムーズなトランジションやアニメーション、その他の視覚要素を動画に追加して、スライドの外観を制御できます。このセクションでは利用可能な動画エフェクトオプションを説明し、適用方法を示します。

{{% alert color="primary" %}} 
参照:
- [C# でアニメーションを使用した PowerPoint プレゼンテーションの強化](https://docs.aspose.com/slides/net/powerpoint-animation/)
- [シェイプ アニメーション](https://docs.aspose.com/slides/net/shape-animation/)
- [C# で PowerPoint のシェイプ エフェクトを適用する](https://docs.aspose.com/slides/net/shape-effect/)
{{% /alert %}} 

アニメーションとトランジションはスライドショーをより魅力的にし、動画でも同様の効果を発揮します。前のプレゼンテーションのコードに別のスライドとトランジションを追加してみましょう：
```c#
 // 笑顔のシェイプを追加し、アニメーションを付けます。
 // ...
 // 新しいスライドとアニメーション付きトランジションを追加します。
 ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
 newSlide.Background.Type = BackgroundType.OwnBackground;
 newSlide.Background.FillFormat.FillType = FillType.Solid;
 newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
 newSlide.SlideShowTransition.Type = TransitionType.Push;
```


Aspose.Slides はテキストアニメーションもサポートしています。この例では、オブジェクト上の段落を順番に表示させ、各段落の間に 1 秒の遅延を設定します：
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

    // ffmpeg バイナリ フォルダーを設定します。こちらのページをご参照ください: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // フレームを WebM ビデオに変換します。
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **動画変換クラス**

PowerPoint から動画への変換タスクを実行できるよう、Aspose.Slides for .NET は [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) と [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) クラスを提供します。

`PresentationAnimationsGenerator` はコンストラクタで動画のフレームサイズ（後で作成される）と FPS（フレーム/秒）値を設定できます。プレゼンテーションのインスタンスを渡すと、その `Presentation.SlideSize` が使用され、[PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) が使用するアニメーションを生成します。

アニメーションが生成されると、各連続アニメーションごとに `NewAnimation` イベントが発生し、[IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) パラメータが含まれます。このクラスは個々のアニメーションのプレーヤーを表します。

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) を使用するには、全体のアニメーション時間を示す `Duration` プロパティと、位置を設定する `SetTimePosition` メソッドを利用します。各アニメーション位置は *0 から duration* の範囲で設定され、`GetFrame` メソッドはその時点のアニメーション状態を表す Bitmap を返します。
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 笑顔シェイプを追加してアニメーションさせます。
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

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // 最終アニメーション状態。
            Bitmap lastBitmap = animationPlayer.GetFrame();             // アニメーションの最終フレーム。
            lastBitmap.Save("last.png");
        };
    }
}
```


すべてのアニメーションを同時に再生するには、[PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) クラスを使用します。このクラスはコンストラクタで [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) インスタンスと FPS 値を受け取り、すべてのアニメーションに対して `FrameTick` イベントを呼び出して再生します：
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


生成されたフレームは動画にコンパイルできます。[PowerPoint プレゼンテーションを動画に変換する](/slides/ja/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) セクションをご参照ください。

## **サポートされているアニメーションとエフェクト**

PowerPoint プレゼンテーションを Aspose.Slides for .NET で動画に変換する際、出力でサポートされているアニメーションとエフェクトを理解することが重要です。Aspose.Slides はフェード、フライイン、ズーム、スピンなどの一般的な入退場および強調エフェクトを広くサポートしています。ただし、一部の高度なカスタムアニメーションは完全に保持されない場合や、最終動画で異なる表示になることがあります。このセクションではサポート対象のアニメーションとエフェクトを概観します。

**入場**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![未サポート](x.png) | ![サポート](v.png) |
| **Fade** | ![サポート](v.png) | ![サポート](v.png) |
| **Fly In** | ![サポート](v.png) | ![サポート](v.png) |
| **Float In** | ![サポート](v.png) | ![サポート](v.png) |
| **Split** | ![サポート](v.png) | ![サポート](v.png) |
| **Wipe** | ![サポート](v.png) | ![サポート](v.png) |
| **Shape** | ![サポート](v.png) | ![サポート](v.png) |
| **Wheel** | ![サポート](v.png) | ![サポート](v.png) |
| **Random Bars** | ![サポート](v.png) | ![サポート](v.png) |
| **Grow & Turn** | ![未サポート](x.png) | ![サポート](v.png) |
| **Zoom** | ![サポート](v.png) | ![サポート](v.png) |
| **Swivel** | ![サポート](v.png) | ![サポート](v.png) |
| **Bounce** | ![サポート](v.png) | ![サポート](v.png) |

**強調**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![未サポート](x.png) | ![サポート](v.png) |
| **Color Pulse** | ![未サポート](x.png) | ![サポート](v.png) |
| **Teeter** | ![サポート](v.png) | ![サポート](v.png) |
| **Spin** | ![サポート](v.png) | ![サポート](v.png) |
| **Grow/Shrink** | ![未サポート](x.png) | ![サポート](v.png) |
| **Desaturate** | ![未サポート](x.png) | ![サポート](v.png) |
| **Darken** | ![未サポート](x.png) | ![サポート](v.png) |
| **Lighten** | ![未サポート](x.png) | ![サポート](v.png) |
| **Transparency** | ![未サポート](x.png) | ![サポート](v.png) |
| **Object Color** | ![未サポート](x.png) | ![サポート](v.png) |
| **Complementary Color** | ![未サポート](x.png) | ![サポート](v.png) |
| **Line Color** | ![未サポート](x.png) | ![サポート](v.png) |
| **Fill Color** | ![未サポート](x.png) | ![サポート](v.png) |

**退出**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![未サポート](x.png) | ![サポート](v.png) |
| **Fade** | ![サポート](v.png) | ![サポート](v.png) |
| **Fly Out** | ![サポート](v.png) | ![サポート](v.png) |
| **Float Out** | ![サポート](v.png) | ![サポート](v.png) |
| **Split** | ![サポート](v.png) | ![サポート](v.png) |
| **Wipe** | ![サポート](v.png) | ![サポート](v.png) |
| **Shape** | ![サポート](v.png) | ![サポート](v.png) |
| **Random Bars** | ![サポート](v.png) | ![サポート](v.png) |
| **Shrink & Turn** | ![未サポート](x.png) | ![サポート](v.png) |
| **Zoom** | ![サポート](v.png) | ![サポート](v.png) |
| **Swivel** | ![サポート](v.png) | ![サポート](v.png) |
| **Bounce** | ![サポート](v.png) | ![サポート](v.png) |

**モーション パス**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![サポート](v.png) | ![サポート](v.png) |
| **Arcs** | ![サポート](v.png) | ![サポート](v.png) |
| **Turns** | ![サポート](v.png) | ![サポート](v.png) |
| **Shapes** | ![サポート](v.png) | ![サポート](v.png) |
| **Loops** | ![サポート](v.png) | ![サポート](v.png) |
| **Custom Path** | ![サポート](v.png) | ![サポート](v.png) |

## **サポートされているスライド トランジション エフェクト**

スライド トランジション エフェクトは、動画内でスライド間のスムーズで視覚的に魅力的な切り替えを実現する重要な要素です。Aspose.Slides for .NET は、元のプレゼンテーションの流れとスタイルを保持するために、一般的に使用されるさまざまなトランジション エフェクトをサポートしています。このセクションでは、変換プロセス中にサポートされているトランジション エフェクトをまとめています。

**微妙**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![未サポート](x.png) | ![サポート](v.png) |
| **Fade** | ![サポート](v.png) | ![サポート](v.png) |
| **Push** | ![サポート](v.png) | ![サポート](v.png) |
| **Pull** | ![サポート](v.png) | ![サポート](v.png) |
| **Wipe** | ![サポート](v.png) | ![サポート](v.png) |
| **Split** | ![サポート](v.png) | ![サポート](v.png) |
| **Reveal** | ![未サポート](x.png) | ![サポート](v.png) |
| **Random Bars** | ![サポート](v.png) | ![サポート](v.png) |
| **Shape** | ![未サポート](x.png) | ![サポート](v.png) |
| **Uncover** | ![未サポート](x.png) | ![サポート](v.png) |
| **Cover** | ![サポート](v.png) | ![サポート](v.png) |
| **Flash** | ![サポート](v.png) | ![サポート](v.png) |
| **Strips** | ![サポート](v.png) | ![サポート](v.png) |

**エキサイティング**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![未サポート](x.png) | ![サポート](v.png) |
| **Drape** | ![未サポート](x.png) | ![サポート](v.png) |
| **Curtains** | ![未サポート](x.png) | ![サポート](v.png) |
| **Wind** | ![未サポート](x.png) | ![サポート](v.png) |
| **Prestige** | ![未サポート](x.png) | ![サポート](v.png) |
| **Fracture** | ![未サポート](x.png) | ![サポート](v.png) |
| **Crush** | ![未サポート](x.png) | ![サポート](v.png) |
| **Peel Off** | ![未サポート](x.png) | ![サポート](v.png) |
| **Page Curl** | ![未サポート](x.png) | ![サポート](v.png) |
| **Airplane** | ![未サポート](x.png) | ![サポート](v.png) |
| **Origami** | ![未サポート](x.png) | ![サポート](v.png) |
| **Dissolve** | ![サポート](v.png) | ![サポート](v.png) |
| **Checkerboard** | ![未サポート](x.png) | ![サポート](v.png) |
| **Blinds** | ![未サポート](x.png) | ![サポート](v.png) |
| **Clock** | ![サポート](v.png) | ![サポート](v.png) |
| **Ripple** | ![未サポート](x.png) | ![サポート](v.png) |
| **Honeycomb** | ![未サポート](x.png) | ![サポート](v.png) |
| **Glitter** | ![未サポート](x.png) | ![サポート](v.png) |
| **Vortex** | ![未サポート](x.png) | ![サポート](v.png) |
| **Shred** | ![未サポート](x.png) | ![サポート](v.png) |
| **Switch** | ![未サポート](x.png) | ![サポート](v.png) |
| **Flip** | ![未サポート](x.png) | ![サポート](v.png) |
| **Gallery** | ![未サポート](x.png) | ![サポート](v.png) |
| **Cube** | ![未サポート](x.png) | ![サポート](v.png) |
| **Doors** | ![未サポート](x.png) | ![サポート](v.png) |
| **Box** | ![未サポート](x.png) | ![サポート](v.png) |
| **Comb** | ![未サポート](x.png) | ![サポート](v.png) |
| **Zoom** | ![サポート](v.png) | ![サポート](v.png) |
| **Random** | ![未サポート](x.png) | ![サポート](v.png) |

**ダイナミック コンテンツ**:

| アニメーションタイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![未サポート](x.png) | ![サポート](v.png) |
| **Ferris Wheel** | ![サポート](v.png) | ![サポート](v.png) |
| **Conveyor** | ![未サポート](x.png) | ![サポート](v.png) |
| **Rotate** | ![未サポート](x.png) | ![サポート](v.png) |
| **Orbit** | ![未サポート](x.png) | ![サポート](v.png) |
| **Fly Through** | ![サポート](v.png) | ![サポート](v.png) |

## **FAQ**

**パスワード保護されたプレゼンテーションを変換できますか？**

はい、Aspose.Slides for .NET はパスワードで保護されたプレゼンテーションの操作をサポートしています。これらのファイルを処理する際は、正しいパスワードを提供してライブラリがプレゼンテーションのコンテンツにアクセスできるようにする必要があります。

**Aspose.Slides for .NET はクラウド ソリューションでの使用をサポートしていますか？**

はい、Aspose.Slides for .NET はクラウド アプリケーションやサービスに統合可能です。サーバー環境での高性能・スケーラビリティを考慮して設計されており、ファイルのバッチ処理に最適です。

**変換時にプレゼンテーションのサイズ制限はありますか？**

Aspose.Slides for .NET は実質的に任意のサイズのプレゼンテーションを扱うことができます。ただし、非常に大きなファイルを処理する場合は追加のシステムリソースが必要になることがあり、パフォーマンス向上のためにプレゼンテーションを最適化することが推奨されることがあります。