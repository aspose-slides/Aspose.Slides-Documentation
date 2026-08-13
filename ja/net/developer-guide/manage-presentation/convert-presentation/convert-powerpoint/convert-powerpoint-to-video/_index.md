---
title: .NET で PowerPoint プレゼンテーションを動画に変換する
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
description: ".NET で PowerPoint プレゼンテーションを動画に変換する方法を学びます。サンプル C# コードと自動化テクニックを活用してワークフローを効率化しましょう。"
---
## **はじめに**

PowerPoint または OpenDocument のプレゼンテーションを動画に変換することで、次のメリットが得られます。

**アクセシビリティの向上:** すべてのデバイスはデフォルトで動画プレーヤーを搭載しているため、従来のプレゼンテーションアプリケーションと比べて動画の再生や閲覧が容易です。

**リーチの拡大:** 動画はより魅力的な形式で情報を提供でき、さまざまな統計や調査で人々がテキストやスライドよりも動画コンテンツを好むことが示されています。これによりメッセージのインパクトが高まります。

{{% alert color="info" %}} 
[**PowerPoint を Video に変換するオンラインコンバーター**](https://products.aspose.app/slides/ja/video) をぜひご確認ください。この記事で説明したプロセスの実装例がライブで提供されています。
{{% /alert %}} 

Aspose.Slides for .NET では、プレゼンテーションを動画に変換する機能を実装しました。

* Aspose.Slides for .NET を使用して、指定したフレームレート (FPS) でスライドからフレームを生成します。
* その後、ffmpeg などのサードパーティユーティリティを利用して、生成したフレームを動画に結合します。

## **PowerPoint プレゼンテーションを動画に変換する手順**

1. `dotnet add package` コマンドで Aspose.Slides と FFMpegCore ライブラリをプロジェクトに追加します:
   * `dotnet add package Aspose.Slides.NET --version 22.11.0` を実行
   * `dotnet add package FFMpegCore --version 4.8.0` を実行
2. ffmpeg を [here](https://ffmpeg.org/download.html) からダウンロードします。
3. FFMpegCore にはダウンロードした ffmpeg のパスを指定する必要があります (例: 「C:\tools\ffmpeg」に解凍した場合):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. PowerPoint から動画への変換コードを実行します。

以下の C# コードは、図形と 2 つのアニメーション効果を含むプレゼンテーションを動画に変換する例です:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // 以前に C:\tools\ffmpeg に抽出した FFmpeg バイナリを使用します。
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // スマイルシェイプを追加し、アニメーションを適用します。
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

    // ffmpeg バイナリ フォルダーを設定します。このページをご参照ください: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // フレームを webm 動画に変換します。
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **動画エフェクト**

Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションを動画に変換する際、さまざまな動画エフェクトを適用して出力の視覚的品質を向上させることができます。これらのエフェクトにより、スムーズなトランジションやアニメーション、その他のビジュアル要素を最終動画に組み込むことができます。このセクションでは利用可能な動画エフェクトオプションを説明し、適用方法を示します。

{{% alert color="info" %}} 
- [C# で PowerPoint プレゼンテーションにアニメーションを追加する方法](https://docs.aspose.com/slides/ja/net/powerpoint-animation/)
- [シェイプ アニメーション](https://docs.aspose.com/slides/ja/net/shape-animation/)
- [C# で PowerPoint のシェイプ エフェクトを適用する方法](https://docs.aspose.com/slides/ja/net/shape-effect/)
{{% /alert %}} 

アニメーションとトランジションはスライドショーをより魅力的にし、動画でも同様の効果を発揮します。前回のプレゼンテーションに別のスライドとトランジションを追加したコード例は次のとおりです:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using (Presentation presentation = new Presentation())
{
    // スマイルシェイプを追加し、アニメーションを適用します（上記のコードを参照）。

    // 新しいスライドを追加し、アニメーション付きトランジションを設定します。
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
}
```

Aspose.Slides はテキストアニメーションもサポートしています。以下の例では、オブジェクト上の段落を 1 秒の遅延で順に表示するようにアニメーションさせます:

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

    // ffmpeg バイナリ フォルダーを設定します。このページをご参照ください: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // フレームを webm 動画に変換します。
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **動画変換クラス**

PowerPoint から動画への変換タスクを実現するために、Aspose.Slides for .NET は [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ja/net/aspose.slides.export/presentationanimationsgenerator/) と [PresentationPlayer](https://reference.aspose.com/slides/ja/net/aspose.slides.export/presentationplayer/) クラスを提供します。

`PresentationAnimationsGenerator` はコンストラクターで作成される動画のフレームサイズと FPS (フレーム/秒) を設定できます。プレゼンテーション インスタンスを渡すと、その `Presentation.SlideSize` が使用され、[PresentationPlayer](https://reference.aspose.com/slides/ja/net/aspose.slides.export/presentationplayer/) が利用するアニメーションが生成されます。

アニメーションが生成されると、各アニメーションごとに `NewAnimation` イベントが発生し、[IPresentationAnimationPlayer](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ipresentationanimationplayer/) パラメーターが渡されます。このクラスは個々のアニメーション用プレーヤーを表します。

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ipresentationanimationplayer/) を使用するには、全体の長さを取得できる `Duration` プロパティと、再生位置を設定できる `SetTimePosition` メソッドを利用します。各アニメーション位置は *0 から Duration* の範囲で設定され、`GetFrame` メソッドはその時点のアニメーション状態を表す Bitmap を返します。

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // スマイルシェイプを追加し、アニメーションを適用します。
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

            animationPlayer.SetTimePosition(0);        // 最初のアニメーション状態。
            IImage image = animationPlayer.GetFrame(); // 最初のアニメーション状態の画像。

            animationPlayer.SetTimePosition(animationPlayer.Duration); // アニメーションの最終状態。
            IImage lastImage = animationPlayer.GetFrame();             // アニメーションの最後のフレーム。
            lastImage.Save("last.png");
        };
    }
}
```

すべてのアニメーションを同時に再生させるには、[PresentationPlayer](https://reference.aspose.com/slides/ja/net/aspose.slides.export/presentationplayer/) クラスを使用します。このクラスはコンストラクターで [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ja/net/aspose.slides.export/presentationanimationsgenerator/) インスタンスと FPS を受け取り、`FrameTick` イベントを呼び出して全アニメーションを再生します:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

生成されたフレームは動画に編成できます。詳しくは [PowerPoint プレゼンテーションを動画に変換する](/slides/ja/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) セクションをご参照ください。

## **サポートされているアニメーションとエフェクト**

PowerPoint プレゼンテーションを動画に変換する際、出力でサポートされるアニメーションとエフェクトを把握しておくことが重要です。Aspose.Slides はフェード、フライイン、ズーム、回転などの一般的な入場・退出・強調エフェクトを幅広くサポートしています。ただし、一部の高度なカスタムアニメーションは完全に保持できなかったり、最終動画で見た目が変わる場合があります。このセクションでサポート対象をまとめます。

**入場**:

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

**強調**:

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

**退出**:

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

**モーション パス**:

| アニメーション タイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **サポートされているスライド トランジション エフェクト**

スライド トランジション エフェクトは、動画内でスライド間の切り替えをスムーズかつ視覚的に魅力的にするために重要です。Aspose.Slides for .NET は、元のプレゼンテーションの流れとスタイルを保持できるよう、一般的に使用されるさまざまなトランジション エフェクトをサポートしています。このセクションでは、変換中にサポートされるトランジション エフェクトをまとめます。

**サブティル**:

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

**エキサイティング**:

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

**ダイナミック コンテンツ**:

| アニメーション タイプ | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

### パスワードで保護されたプレゼンテーションの変換は可能ですか？

はい、Aspose.Slides for .NET はパスワードで保護されたプレゼンテーションの操作をサポートしています。対象ファイルを処理する際は、正しいパスワードを指定してライブラリがコンテンツにアクセスできるようにしてください。

### Aspose.Slides for .NET はクラウド ソリューションで使用できますか？

はい、Aspose.Slides for .NET はクラウド アプリケーションやサービスに組み込むことができます。サーバー環境での高性能・スケーラビリティを意識して設計されており、バッチ処理に最適です。

### 変換時にプレゼンテーションのサイズ制限はありますか？

Aspose.Slides for .NET は実質的に任意のサイズのプレゼンテーションを処理可能です。ただし、非常に大きなファイルを扱う場合はシステム リソースが多く必要になることがあり、パフォーマンス向上のためにプレゼンテーションを最適化することが推奨されます。