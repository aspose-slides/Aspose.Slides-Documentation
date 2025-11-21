---
title: .NET で PowerPoint プレゼンテーションをビデオに変換
linktitle: PowerPoint をビデオに変換
type: docs
weight: 130
url: /ja/net/convert-powerpoint-to-video/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- PPT を変換
- PPTX を変換
- PowerPoint をビデオに変換
- プレゼンテーションをビデオに変換
- PPT をビデオに変換
- PPTX をビデオに変換
- PowerPoint を MP4 に変換
- プレゼンテーションを MP4 に変換
- PPT を MP4 に変換
- PPTX を MP4 に変換
- PPT を MP4 として保存
- PPTX を MP4 として保存
- PPT を MP4 にエクスポート
- PPTX を MP4 にエクスポート
- ビデオ変換
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: ".NET で PowerPoint プレゼンテーションをビデオに変換する方法を学びます。サンプル C# コードと自動化テクニックを活用して、ワークフローを効率化しましょう。"
---

## **概要**

PowerPoint または OpenDocument のプレゼンテーションをビデオに変換することで、次の利点が得られます:

**アクセシビリティの向上:** すべてのデバイスは、プラットフォームに関係なくデフォルトでビデオプレーヤーが装備されているため、従来のプレゼンテーションアプリケーションに比べてビデオを開く・再生する方が容易です。

**リーチの拡大:** ビデオにより、より多くの視聴者にリーチし、情報をより魅力的な形式で提示できます。調査や統計では、人々は他の形式よりもビデオコンテンツの視聴・消費を好むことが示されており、メッセージのインパクトが高まります。

{{% alert color="primary" %}} 
こちらの[**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/video)をご覧ください。ここで紹介されたプロセスのライブかつ効果的な実装が提供されています。
{{% /alert %}} 

Aspose.Slides for .NET では、プレゼンテーションをビデオに変換する機能を実装しました。

* Aspose.Slides for .NET を使用して、指定されたフレームレート（FPS）でプレゼンテーションスライドからフレームを生成します。
* 次に、ffmpeg などのサードパーティユーティリティを使用して、これらのフレームをビデオに編成します。

## **PowerPoint プレゼンテーションをビデオに変換する**

1. `dotnet add package` コマンドを使用して、Aspose.Slides と FFMpegCore ライブラリをプロジェクトに追加します:
   * `dotnet add package Aspose.Slides.NET --version 22.11.0` を実行します
   * `dotnet add package FFMpegCore --version 4.8.0` を実行します
2. [here](https://ffmpeg.org/download.html) から ffmpeg をダウンロードします。
3. FFMpegCore では、ダウンロードした ffmpeg のパス（例: "C:\tools\ffmpeg" に展開した場合）を指定する必要があります:  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```

4. PowerPoint からビデオへの変換コードを実行します。

この C# コードは、シェイプと 2 つのアニメーション効果を含むプレゼンテーションをビデオに変換する方法を示しています:
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // 以前に C:\tools\ffmpeg に展開した FFmpeg バイナリを使用します。
using Aspose.Slides.Animation;

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

    // フレームを WebM 動画に変換します。
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **ビデオ効果**

Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションをビデオに変換する際、さまざまなビデオ効果を適用して出力の視覚品質を向上させることができます。これらの効果により、スムーズなトランジションやアニメーション、その他の視覚要素を追加して、最終ビデオ内のスライドの外観を制御できます。本節では利用可能なビデオ効果オプションを説明し、適用方法を示します。

{{% alert color="primary" %}} 
参照:
- [C# でアニメーションを使用した PowerPoint プレゼンテーションの強化](https://docs.aspose.com/slides/net/powerpoint-animation/)
- [シェイプアニメーション](https://docs.aspose.com/slides/net/shape-animation/)
- [C# で PowerPoint のシェイプ効果を適用する](https://docs.aspose.com/slides/net/shape-effect/)
{{% /alert %}} 

アニメーションとトランジションはスライドショーをより魅力的にし、ビデオにも同様の効果をもたらします。前述のプレゼンテーションのコードに別のスライドとトランジションを追加してみましょう:
```c#
// スマイルシェイプを追加し、アニメーションを付けます.
// ...

// 新しいスライドを追加し、アニメーション付きのトランジションを設定します。
ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
newSlide.Background.Type = BackgroundType.OwnBackground;
newSlide.Background.FillFormat.FillType = FillType.Solid;
newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
newSlide.SlideShowTransition.Type = TransitionType.Push;
```


Aspose.Slides はテキストアニメーションもサポートしています。以下の例では、オブジェクト上の段落を順番に表示し、各段落の間に 1 秒の遅延を設定しています:
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

    // ffmpeg バイナリフォルダーを設定します。こちらのページをご覧ください: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // フレームを WebM 動画に変換します。
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **ビデオ変換クラス**

PowerPoint からビデオへの変換タスクを実現するために、Aspose.Slides for .NET は [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) と [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) クラスを提供します。

`PresentationAnimationsGenerator` は、ビデオ（後で作成される）のフレームサイズと FPS（秒間フレーム数）をコンストラクタで設定できるようにします。プレゼンテーション インスタンスを渡すと、その `Presentation.SlideSize` が使用され、[PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) が使用するアニメーションが生成されます。

アニメーションが生成されると、各アニメーションごとに `NewAnimation` イベントがトリガーされ、[IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) パラメータが渡されます。このクラスは個々のアニメーションのプレーヤーを表します。

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) を操作するには、アニメーション全体の長さを示す `Duration` プロパティと、`SetTimePosition` メソッドを使用します。各アニメーション位置は *0 から Duration* の範囲で設定され、`GetFrame` メソッドはその時点のアニメーション状態を表す Bitmap を返します。
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

            animationPlayer.SetTimePosition(0);          // 初期アニメーション状態です。
            Bitmap bitmap = animationPlayer.GetFrame();  // 初期アニメーション状態のビットマップです。

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // アニメーションの最終状態です。
            Bitmap lastBitmap = animationPlayer.GetFrame();             // アニメーションの最後のフレームです。
            lastBitmap.Save("last.png");
        };
    }
}
```


すべてのアニメーションを同時に再生するには、[PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) クラスを使用します。このクラスはコンストラクタで [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) インスタンスと FPS 値を受け取り、`FrameTick` イベントを呼び出してすべてのアニメーションを再生します:
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


生成されたフレームはビデオに編成できます。詳しくは [Convert a PowerPoint Presentation to Video](/slides/ja/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) セクションを参照してください。

## **サポートされているアニメーションと効果**

PowerPoint プレゼンテーションを Aspose.Slides for .NET でビデオに変換する際、出力でサポートされるアニメーションと効果を理解することが重要です。Aspose.Slides はフェード、フライイン、ズーム、スピンなどの一般的な出入りおよび強調効果を幅広くサポートしていますが、いくつかの高度なカスタムアニメーションは完全に保持されないか、最終ビデオで異なる表示になる場合があります。本節ではサポートされているアニメーションと効果を概説します。

**入口**:

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **サポートされているスライド トランジション効果**

スライド トランジション効果は、ビデオ内でスライド間の滑らかで視覚的に魅力的な切り替えを作成する上で重要な役割を果たします。Aspose.Slides for .NET は、元のプレゼンテーションの流れとスタイルを保持するために、一般的に使用されるさまざまなトランジション効果をサポートしています。本節では、変換プロセス中にサポートされているトランジション効果をハイライトします。

**微妙**:

| Animation Type | Aspose.Slides | PowerPoint |
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

**刺激的**:

| Animation Type | Aspose.Slides | PowerPoint |
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
| **Origami** | ![not supported](x/png) | ![supported](v.png) |
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
| **Cube** | ![not supported](x/png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**動的コンテンツ**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**パスワードで保護されたプレゼンテーションを変換できますか？**

はい、Aspose.Slides for .NET はパスワードで保護されたプレゼンテーションの操作をサポートしています。これらのファイルを処理する際は、正しいパスワードを提供してライブラリがプレゼンテーションの内容にアクセスできるようにしてください。

**Aspose.Slides for .NET はクラウド ソリューションでの使用をサポートしていますか？**

はい、Aspose.Slides for .NET はクラウド アプリケーションやサービスに統合できます。サーバー環境での動作を前提に設計されており、バッチ処理での高性能とスケーラビリティを提供します。

**変換時にプレゼンテーションのサイズ制限はありますか？**

Aspose.Slides for .NET は実質的に任意のサイズのプレゼンテーションを処理可能です。ただし、非常に大きなファイルを扱う場合は追加のシステムリソースが必要になることがあり、パフォーマンス向上のためにプレゼンテーションを最適化することが推奨されることがあります。