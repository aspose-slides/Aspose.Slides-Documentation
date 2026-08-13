---
title: 在 .NET 中將 PowerPoint 簡報轉換為影片
linktitle: PowerPoint 轉影片
type: docs
weight: 130
url: /zh-hant/net/convert-powerpoint-to-video/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉影片
- 簡報轉影片
- PPT 轉影片
- PPTX 轉影片
- PowerPoint 轉 MP4
- 簡報轉 MP4
- PPT 轉 MP4
- PPTX 轉 MP4
- 將 PPT 儲存為 MP4
- 將 PPTX 儲存為 MP4
- 匯出 PPT 為 MP4
- 匯出 PPTX 為 MP4
- 影片轉換
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "了解如何在 .NET 中將 PowerPoint 簡報轉換為影片。探索範例 C# 程式碼與自動化技術，以精簡您的工作流程。"
---
## **簡介**

將您的 PowerPoint 或 OpenDocument 簡報轉換為影片，您將獲得以下好處：

**提升可及性：** 所有裝置，無論平台，預設皆配備影片播放器，相較於傳統簡報應用程式，使用者開啟或播放影片更為便利。

**更廣的受眾：** 影片讓您能觸及更大的觀眾群，並以更具吸引力的方式呈現資訊。調查與統計顯示，人們較喜好觀看與消費影片內容，而非其他形式，讓您的訊息更具衝擊力。

{{% alert color="info" %}} 

請查看我們的[**PowerPoint 轉影片線上轉換器**](https://products.aspose.app/slides/zh-hant/video)，因為它提供了本文描述流程的即時且有效的實作。

{{% /alert %}} 

在 Aspose.Slides for .NET 中，我們已實作將簡報轉換為影片的支援。

* 使用 Aspose.Slides for .NET 從簡報投影片產生畫面，並以指定的框架速率 (FPS) 產生。
* 然後，使用第三方工具（例如 ffmpeg）將這些畫面編譯成影片。

## **將 PowerPoint 簡報轉換為影片**

1. 使用 `dotnet add package` 指令將 Aspose.Slides 與 FFMpegCore 函式庫加入您的專案：
   * 執行 `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * 執行 `dotnet add package FFMpegCore --version 4.8.0`
2. 從[此處](https://ffmpeg.org/download.html)下載 ffmpeg。
3. FFMpegCore 需要您指定已下載 ffmpeg 的路徑（例如，已解壓縮至「C:\tools\ffmpeg」）：  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. 執行 PowerPoint 轉影片的轉換程式碼。

以下 C# 程式碼示範如何將包含圖形與兩個動畫效果的簡報轉換為影片：

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // 將使用我們先前解壓縮到 C:\tools\ffmpeg 的 FFmpeg 二進位檔。
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 加入笑臉形狀，然後為其添加動畫。
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

    // 設定 ffmpeg 二進位檔資料夾。請參閱此頁面：https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // 將畫格轉換為 webm 影片。
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **影片效果**

使用 Aspose.Slides for .NET 將 PowerPoint 簡報轉換為影片時，您可以套用各種影片效果，以提升輸出的視覺品質。這些效果讓您能透過平滑過渡、動畫與其他視覺元素，控制最終影片中投影片的呈現方式。本節說明可用的影片效果選項並示範如何套用它們。

{{% alert color="info" %}} 

請參考：
- [使用 C# 強化 PowerPoint 簡報的動畫](https://docs.aspose.com/slides/zh-hant/net/powerpoint-animation/)
- [圖形動畫](https://docs.aspose.com/slides/zh-hant/net/shape-animation/)
- [使用 C# 在 PowerPoint 中套用圖形效果](https://docs.aspose.com/slides/zh-hant/net/shape-effect/)

{{% /alert %}} 

動畫與過渡讓投影片播放更具吸引力與趣味性──影片亦同。讓我們在先前簡報的程式碼中新增另一張投影片與過渡效果：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using (Presentation presentation = new Presentation())
{
    // 加入笑臉形狀並為其添加動畫（請參考上面的程式碼）。

    // 新增一張投影片並加入動畫過渡效果。
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
}
```

Aspose.Slides 也支援文字動畫。在此範例中，我們對物件上的段落設定動畫，使其依次出現，且每個段落之間有一秒的延遲：

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 加入文字與動畫。
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

    // 設定 ffmpeg 二進位檔資料夾。請參閱此頁面：https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // 將畫格轉換為 webm 影片。
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **影片轉換類別**

為了支援 PowerPoint 轉影片的轉換任務，Aspose.Slides for .NET 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/presentationanimationsgenerator/) 與 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/presentationplayer/) 類別。

`PresentationAnimationsGenerator` 允許您透過建構函式設定影片的框架大小（稍後會建立）以及 FPS（每秒框架）值。若傳入簡報實例，將使用其 `Presentation.SlideSize`，且產生的動畫會被 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/presentationplayer/) 使用。

當產生動畫時，會為每個後續動畫觸發 `NewAnimation` 事件，該事件包含一個 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ipresentationanimationplayer/) 參數。此類別代表單一動畫的播放器。

若要使用 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ipresentationanimationplayer/)，您可使用 [Duration](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ipresentationanimationplayer/duration/) 屬性（提供動畫的完整持續時間）與 [SetTimePosition](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/) 方法。每個動畫位置設定於 *0 至 duration* 範圍內，然後 `GetFrame` 方法會回傳表示該時間點動畫狀態的 Bitmap。

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 加入笑臉形狀並為其添加動畫。
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

            animationPlayer.SetTimePosition(0);        // 初始動畫狀態。
            IImage image = animationPlayer.GetFrame(); // 初始動畫狀態影像。

            animationPlayer.SetTimePosition(animationPlayer.Duration); // 動畫的最終狀態。
            IImage lastImage = animationPlayer.GetFrame();             // 動畫的最後一幀。
            lastImage.Save("last.png");
        };
    }
}
```

若要一次播放簡報中所有動畫，會使用 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/presentationplayer/) 類別。此類別在建構函式中接受一個 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/presentationanimationsgenerator/) 實例與效果的 FPS 值，然後對所有動畫呼叫 `FrameTick` 事件以播放它們：

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

然後可將產生的框架編譯成影片。請參閱 [將 PowerPoint 簡報轉換為影片](/slides/zh-hant/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) 章節。

## **支援的動畫與效果**

使用 Aspose.Slides for .NET 將 PowerPoint 簡報轉換為影片時，了解輸出中支援哪些動畫與效果十分重要。Aspose.Slides 支援各種常見的進場、退出與強調效果，如淡出、飛入、縮放與旋轉等。然而，某些進階或自訂動畫可能無法完整保留，或在最終影片中顯示不同。本節列出支援的動畫與效果。

**進場**：

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![不支援](x.png) | ![支援](v.png) |
| **Fade** | ![支援](v.png) | ![支援](v.png) |
| **Fly In** | ![支援](v.png) | ![支援](v.png) |
| **Float In** | ![支援](v.png) | ![支援](v.png) |
| **Split** | ![支援](v.png) | ![支援](v.png) |
| **Wipe** | ![支援](v.png) | ![支援](v.png) |
| **Shape** | ![支援](v.png) | ![支援](v.png) |
| **Wheel** | ![支援](v.png) | ![支援](v.png) |
| **Random Bars** | ![支援](v.png) | ![支援](v.png) |
| **Grow & Turn** | ![不支援](x.png) | ![支援](v.png) |
| **Zoom** | ![支援](v.png) | ![支援](v.png) |
| **Swivel** | ![支援](v.png) | ![支援](v.png) |
| **Bounce** | ![支援](v.png) | ![支援](v.png) |

**強調**：

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![不支援](x.png) | ![支援](v.png) |
| **Color Pulse** | ![不支援](x.png) | ![支援](v.png) |
| **Teeter** | ![支援](v.png) | ![支援](v.png) |
| **Spin** | ![支援](v.png) | ![支援](v.png) |
| **Grow/Shrink** | ![不支援](x.png) | ![支援](v.png) |
| **Desaturate** | ![不支援](x.png) | ![支援](v.png) |
| **Darken** | ![不支援](x.png) | ![支援](v.png) |
| **Lighten** | ![不支援](x.png) | ![支援](v.png) |
| **Transparency** | ![不支援](x.png) | ![支援](v.png) |
| **Object Color** | ![不支援](x.png) | ![支援](v.png) |
| **Complementary Color** | ![不支援](x.png) | ![支援](v.png) |
| **Line Color** | ![不支援](x.png) | ![支援](v.png) |
| **Fill Color** | ![不支援](x.png) | ![支援](v.png) |

**退出**：

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![不支援](x.png) | ![支援](v.png) |
| **Fade** | ![支援](v.png) | ![支援](v.png) |
| **Fly Out** | ![支援](v.png) | ![支援](v.png) |
| **Float Out** | ![支援](v.png) | ![支援](v.png) |
| **Split** | ![支援](v.png) | ![支援](v.png) |
| **Wipe** | ![支援](v.png) | ![支援](v.png) |
| **Shape** | ![支援](v.png) | ![支援](v.png) |
| **Random Bars** | ![支援](v.png) | ![支援](v.png) |
| **Shrink & Turn** | ![不支援](x.png) | ![支援](v.png) |
| **Zoom** | ![支援](v.png) | ![支援](v.png) |
| **Swivel** | ![支援](v.png) | ![支援](v.png) |
| **Bounce** | ![支援](v.png) | ![支援](v.png) |

**移動路徑**：

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![支援](v.png) | ![支援](v.png) |
| **Arcs** | ![支援](v.png) | ![支援](v.png) |
| **Turns** | ![支援](v.png) | ![支援](v.png) |
| **Shapes** | ![支援](v.png) | ![支援](v.png) |
| **Loops** | ![支援](v.png) | ![支援](v.png) |
| **Custom Path** | ![支援](v.png) | ![支援](v.png) |

## **支援的投影片切換效果**

投影片切換效果在影片中創造平滑且具視覺吸引力的變換上扮演重要角色。Aspose.Slides for .NET 支援各種常用的切換效果，協助保留原始簡報的流程與風格。本節概述在轉換過程中支援的切換效果。

**細緻**：

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![不支援](x.png) | ![支援](v.png) |
| **Fade** | ![支援](v.png) | ![支援](v.png) |
| **Push** | ![支援](v.png) | ![支援](v.png) |
| **Pull** | ![支援](v.png) | ![支援](v.png) |
| **Wipe** | ![支援](v.png) | ![支援](v.png) |
| **Split** | ![支援](v.png) | ![支援](v.png) |
| **Reveal** | ![不支援](x.png) | ![支援](v.png) |
| **Random Bars** | ![支援](v.png) | ![支援](v.png) |
| **Shape** | ![不支援](x.png) | ![支援](v.png) |
| **Uncover** | ![不支援](x.png) | ![支援](v.png) |
| **Cover** | ![支援](v.png) | ![支援](v.png) |
| **Flash** | ![支援](v.png) | ![支援](v.png) |
| **Strips** | ![支援](v.png) | ![支援](v.png) |

**令人興奮**：

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![不支援](x.png) | ![支援](v.png) |
| **Drape** | ![不支援](x.png) | ![支援](v.png) |
| **Curtains** | ![不支援](x.png) | ![支援](v.png) |
| **Wind** | ![不支援](x.png) | ![支援](v.png) |
| **Prestige** | ![不支援](x.png) | ![支援](v.png) |
| **Fracture** | ![不支援](x.png) | ![支援](v.png) |
| **Crush** | ![不支援](x.png) | ![支援](v.png) |
| **Peel Off** | ![不支援](x.png) | ![支援](v.png) |
| **Page Curl** | ![不支援](x.png) | ![支援](v.png) |
| **Airplane** | ![不支援](x.png) | ![支援](v.png) |
| **Origami** | ![不支援](x.png) | ![支援](v.png) |
| **Dissolve** | ![支援](v.png) | ![支援](v.png) |
| **Checkerboard** | ![不支援](x.png) | ![支援](v.png) |
| **Blinds** | ![不支援](x.png) | ![支援](v.png) |
| **Clock** | ![支援](v.png) | ![支援](v.png) |
| **Ripple** | ![不支援](x.png) | ![支援](v.png) |
| **Honeycomb** | ![不支援](x.png) | ![支援](v.png) |
| **Glitter** | ![不支援](x.png) | ![支援](v.png) |
| **Vortex** | ![不支援](x.png) | ![支援](v.png) |
| **Shred** | ![不支援](x.png) | ![支援](v.png) |
| **Switch** | ![不支援](x.png) | ![支援](v.png) |
| **Flip** | ![不支援](x.png) | ![支援](v.png) |
| **Gallery** | ![不支援](x.png) | ![支援](v.png) |
| **Cube** | ![不支援](x.png) | ![支援](v.png) |
| **Doors** | ![不支援](x.png) | ![支援](v.png) |
| **Box** | ![不支援](x.png) | ![支援](v.png) |
| **Comb** | ![不支援](x.png) | ![支援](v.png) |
| **Zoom** | ![支援](v.png) | ![支援](v.png) |
| **Random** | ![不支援](x.png) | ![支援](v.png) |

**動態內容**：

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![不支援](x.png) | ![支援](v.png) |
| **Ferris Wheel** | ![支援](v.png) | ![支援](v.png) |
| **Conveyor** | ![不支援](x.png) | ![支援](v.png) |
| **Rotate** | ![不支援](x.png) | ![支援](v.png) |
| **Orbit** | ![不支援](x.png) | ![支援](v.png) |
| **Fly Through** | ![支援](v.png) | ![支援](v.png) |

## **常見問題**

### 是否可以轉換受密碼保護的簡報？

是的，Aspose.Slides for .NET 允許處理受密碼保護的簡報。處理此類檔案時，您需要提供正確的密碼，以便函式庫能存取簡報內容。

### Aspose.Slides for .NET 是否支援在雲端解決方案中使用？

是的，Aspose.Slides for .NET 可整合至雲端應用程式與服務。此函式庫設計用於伺服器環境，確保在批次檔案處理時具備高效能與可擴充性。

### 轉換過程中，簡報的大小是否有任何限制？

Aspose.Slides for .NET 能處理幾乎任何大小的簡報。然而，當處理非常大型的檔案時，可能需要額外的系統資源，有時建議先最佳化簡報以提升效能。