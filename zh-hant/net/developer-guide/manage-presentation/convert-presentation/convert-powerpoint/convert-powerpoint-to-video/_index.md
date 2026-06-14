---
title: .NET 中將 PowerPoint 簡報轉換為影片
linktitle: PowerPoint 轉影片
type: docs
weight: 130
url: /zh-hant/net/convert-powerpoint-to-video/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉影片
- 簡報 轉影片
- PPT 轉影片
- PPTX 轉影片
- PowerPoint 轉 MP4
- 簡報 轉 MP4
- PPT 轉 MP4
- PPTX 轉 MP4
- 將 PPT 儲存為 MP4
- 將 PPTX 儲存為 MP4
- 匯出 PPT 為 MP4
- 匯出 PPTX 為 MP4
- 影片 轉換
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "了解如何在 .NET 中將 PowerPoint 簡報轉換為影片。探索範例 C# 程式碼與自動化技術，以簡化您的工作流程。"
---
## **簡介**

將 PowerPoint 或 OpenDocument 簡報轉換為影片，可為您帶來以下好處：

**提升可及性：**所有裝置（不論平台）預設皆具備影片播放器，相較於傳統簡報應用程式，使用者開啟或播放影片更為容易。

**更廣的觸及範圍：**影片讓您能夠觸及更大的受眾，並以更具吸引力的形式呈現資訊。調查與統計顯示，人們較喜歡觀看和消費影片內容，這使您的訊息更具衝擊力。

{{% alert color="primary" %}} 
請查看我們的[**PowerPoint 轉影片線上轉換器**](https://products.aspose.app/slides/zh-hant/video)，因為它提供了本文所述流程的即時且有效的實作。
{{% /alert %}} 

在 Aspose.Slides for .NET 中，我們已實作將簡報轉換為影片的支援。

* 使用 Aspose.Slides for .NET 以指定的影格速率（FPS）從簡報投影片產生影格。
* 然後，使用第三方工具（如 ffmpeg）將這些影格編譯成影片。

## **將 PowerPoint 簡報轉換為影片**

1. 使用 `dotnet add package` 命令將 Aspose.Slides 與 FFMpegCore 套件加入您的專案：
   * 執行 `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * 執行 `dotnet add package FFMpegCore --version 4.8.0`
2. 從[此處](https://ffmpeg.org/download.html)下載 ffmpeg。
3. FFMpegCore 需要您指定已下載的 ffmpeg 路徑（例如，解壓縮至「C:\tools\ffmpeg」）：  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. 執行 PowerPoint 轉影片的轉換程式碼。

以下 C# 程式碼示範如何將包含形狀與兩個動畫效果的簡報轉換為影片：

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // 將使用我們先前解壓縮到 C:\tools\ffmpeg 的 FFmpeg 二進位檔。
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 新增一個笑臉圖形，然後對其進行動畫。
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

    // 設定 ffmpeg 二進位檔資料夾。參考此頁面：https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // 將影格轉換為 webm 影片。
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **影片效果**

在使用 Aspose.Slides for .NET 將 PowerPoint 簡報轉換為影片時，您可以套用各種影片效果以提升輸出之視覺品質。這些效果允許您透過平滑的轉場、動畫與其他視覺元素，控制最終影片中投影片的呈現方式。本節說明可用的影片效果選項，並示範如何套用它們。

{{% alert color="primary" %}} 
請參閱：
- [在 C# 中使用動畫增強 PowerPoint 簡報](https://docs.aspose.com/slides/zh-hant/net/powerpoint-animation/)
- [圖形動畫](https://docs.aspose.com/slides/zh-hant/net/shape-animation/)
- [在 PowerPoint 中使用 C# 套用圖形效果](https://docs.aspose.com/slides/zh-hant/net/shape-effect/)
{{% /alert %}} 

動畫與轉場使投影片秀更具吸引力與趣味，影片亦同。讓我們為先前的簡報程式碼新增另一張投影片與轉場效果：

```c#
// 新增一個笑臉圖形並為其設定動畫。
// ...

// 新增一張投影片並加入動畫轉場。
ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
newSlide.Background.Type = BackgroundType.OwnBackground;
newSlide.Background.FillFormat.FillType = FillType.Solid;
newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slides 也支援文字動畫。在此範例中，我們對物件上的段落進行動畫，使其依序出現，且每個段落之間相隔一秒鐘：

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 新增文字與動畫。
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

    // 設定 ffmpeg 二進位檔資料夾。參考此頁面：https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // 將影格轉換為 webm 影片。
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **影片轉換類別**

為了支援 PowerPoint 轉影片的任務，Aspose.Slides for .NET 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/presentationanimationsgenerator/) 與 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/presentationplayer/) 類別。

`PresentationAnimationsGenerator` 允許您透過建構子設定稍後要建立的影片影格大小與 FPS（每秒影格數）值。若傳入簡報實例，將使用其 `Presentation.SlideSize`，並產生供 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/presentationplayer/) 使用的動畫。

產生動畫時，會為每個後續動畫觸發 `NewAnimation` 事件，該事件包含一個 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ipresentationanimationplayer/) 參數。此類別代表單一動畫的播放者。

使用 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ipresentationanimationplayer/) 時，您會使用 [Duration](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ipresentationanimationplayer/duration/) 屬性（取得動畫的完整持續時間）以及 [SetTimePosition](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/) 方法。每個動畫位置皆在 *0 到 duration* 範圍內設定，`GetFrame` 方法則回傳代表該時間點動畫狀態的 Bitmap。

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 新增一個笑臉圖形並為其設定動畫。
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

            animationPlayer.SetTimePosition(0);          // 動畫的初始狀態。
            Bitmap bitmap = animationPlayer.GetFrame();  // 動畫初始狀態的位圖。

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // 動畫的最終狀態。
            Bitmap lastBitmap = animationPlayer.GetFrame();             // 動畫的最後一幀。
            lastBitmap.Save("last.png");
        };
    }
}
```

若要讓簡報中的所有動畫同時播放，會使用 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/presentationplayer/) 類別。此類別在建構子中接受一個 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/presentationanimationsgenerator/) 實例與 FPS 值，接著呼叫 `FrameTick` 事件以播放所有動畫：

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

之後即可將產生的影格編譯成影片。請參閱 [將 PowerPoint 簡報轉換為影片](/slides/zh-hant/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) 章節。

## **支援的動畫與效果**

在使用 Aspose.Slides for .NET 將 PowerPoint 簡報轉換為影片時，了解輸出中支援的動畫與效果十分重要。Aspose.Slides 支援多種常見的進入、退出與強調效果，如淡入、飛入、縮放與旋轉。然而，某些進階或自訂動畫可能不會完整保留，或在最終影片中呈現方式不同。本節概述支援的動畫與效果。

**進入效果**：

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **出現** | ![not supported](x.png) | ![supported](v.png) |
| **淡出** | ![supported](v.png) | ![supported](v.png) |
| **飛入** | ![supported](v.png) | ![supported](v.png) |
| **漂入** | ![supported](v.png) | ![supported](v.png) |
| **分割** | ![supported](v.png) | ![supported](v.png) |
| **抹除** | ![supported](v.png) | ![supported](v.png) |
| **形狀** | ![supported](v.png) | ![supported](v.png) |
| **輪轉** | ![supported](v.png) | ![supported](v.png) |
| **隨機條紋** | ![supported](v.png) | ![supported](v.png) |
| **增長與旋轉** | ![not supported](x.png) | ![supported](v.png) |
| **縮放** | ![supported](v.png) | ![supported](v.png) |
| **搖擺** | ![supported](v.png) | ![supported](v.png) |
| **彈跳** | ![supported](v.png) | ![supported](v.png) |

**強調效果**：

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **脈衝** | ![not supported](x.png) | ![supported](v.png) |
| **顏色脈衝** | ![not supported](x.png) | ![supported](v.png) |
| **顛簸** | ![supported](v.png) | ![supported](v.png) |
| **旋轉** | ![supported](v.png) | ![supported](v.png) |
| **增長/縮小** | ![not supported](x.png) | ![supported](v.png) |
| **去飽和** | ![not supported](x.png) | ![supported](v.png) |
| **變暗** | ![not supported](x.png) | ![supported](v.png) |
| **變亮** | ![not supported](x.png) | ![supported](v.png) |
| **透明度** | ![not supported](x.png) | ![supported](v.png) |
| **物件顏色** | ![not supported](x.png) | ![supported](v.png) |
| **互補色** | ![not supported](x.png) | ![supported](v.png) |
| **線條顏色** | ![not supported](x.png) | ![supported](v.png) |
| **填充顏色** | ![not supported](x.png) | ![supported](v.png) |

**退出效果**：

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **消失** | ![not supported](x.png) | ![supported](v.png) |
| **淡出** | ![supported](v.png) | ![supported](v.png) |
| **飛出** | ![supported](v.png) | ![supported](v.png) |
| **漂出** | ![supported](v.png) | ![supported](v.png) |
| **分割** | ![supported](v.png) | ![supported](v.png) |
| **抹除** | ![supported](v.png) | ![supported](v.png) |
| **形狀** | ![supported](v.png) | ![supported](v.png) |
| **隨機條紋** | ![supported](v.png) | ![supported](v.png) |
| **縮小與旋轉** | ![not supported](x.png) | ![supported](v.png) |
| **縮放** | ![supported](v.png) | ![supported](v.png) |
| **搖擺** | ![supported](v.png) | ![supported](v.png) |
| **彈跳** | ![supported](v.png) | ![supported](v.png) |

**動作路徑**：

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **直線** | ![supported](v.png) | ![supported](v.png) |
| **弧線** | ![supported](v.png) | ![supported](v.png) |
| **轉彎** | ![supported](v.png) | ![supported](v.png) |
| **形狀** | ![supported](v.png) | ![supported](v.png) |
| **迴圈** | ![supported](v.png) | ![supported](v.png) |
| **自訂路徑** | ![supported](v.png) | ![supported](v.png) |

## **支援的投影片轉場效果**

投影片轉場效果在影片中創造平滑且具視覺吸引力的切換扮演重要角色。Aspose.Slides for .NET 支援多種常用的轉場效果，以協助保留原始簡報的流程與風格。以下列出在轉換過程中受支援的轉場效果。

**細緻**：

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **形變** | ![not supported](x.png) | ![supported](v.png) |
| **淡出** | ![supported](v.png) | ![supported](v.png) |
| **推進** | ![supported](v.png) | ![supported](v.png) |
| **拉出** | ![supported](v.png) | ![supported](v.png) |
| **抹除** | ![supported](v.png) | ![supported](v.png) |
| **分割** | ![supported](v.png) | ![supported](v.png) |
| **揭露** | ![not supported](x.png) | ![supported](v.png) |
| **隨機條紋** | ![supported](v.png) | ![supported](v.png) |
| **形狀** | ![not supported](x.png) | ![supported](v.png) |
| **顯露** | ![not supported](x.png) | ![supported](v.png) |
| **覆蓋** | ![supported](v.png) | ![supported](v.png) |
| **閃爍** | ![supported](v.png) | ![supported](v.png) |
| **條紋** | ![supported](v.png) | ![supported](v.png) |

**刺激**：

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **倒塌** | ![not supported](x.png) | ![supported](v.png) |
| **懸掛** | ![not supported](x.png) | ![supported](v.png) |
| **窗簾** | ![not supported](x.png) | ![supported](v.png) |
| **風** | ![not supported](x.png) | ![supported](v.png) |
| **聲望** | ![not supported](x.png) | ![supported](v.png) |
| **裂痕** | ![not supported](x.png) | ![supported](v.png) |
| **粉碎** | ![not supported](x.png) | ![supported](v.png) |
| **剝離** | ![not supported](x.png) | ![supported](v.png) |
| **頁面翻捲** | ![not supported](x.png) | ![supported](v.png) |
| **飛機** | ![not supported](x.png) | ![supported](v.png) |
| **摺紙** | ![not supported](x.png) | ![supported](v.png) |
| **溶解** | ![supported](v.png) | ![supported](v.png) |
| **棋盤** | ![not supported](x.png) | ![supported](v.png) |
| **百葉窗** | ![not supported](x.png) | ![supported](v.png) |
| **時鐘** | ![supported](v.png) | ![supported](v.png) |
| **波紋** | ![not supported](x.png) | ![supported](v.png) |
| **蜂巢** | ![not supported](x.png) | ![supported](v.png) |
| **閃光** | ![not supported](x.png) | ![supported](v.png) |
| **漩渦** | ![not supported](x.png) | ![supported](v.png) |
| **撕裂** | ![not supported](x.png) | ![supported](v.png) |
| **切換** | ![not supported](x.png) | ![supported](v.png) |
| **翻轉** | ![not supported](x.png) | ![supported](v.png) |
| **畫廊** | ![not supported](x.png) | ![supported](v.png) |
| **立方體** | ![not supported](x.png) | ![supported](v.png) |
| **門** | ![not supported](x.png) | ![supported](v.png) |
| **盒子** | ![not supported](x.png) | ![supported](v.png) |
| **梳子** | ![not supported](x.png) | ![supported](v.png) |
| **縮放** | ![supported](v.png) | ![supported](v.png) |
| **隨機** | ![not supported](x.png) | ![supported](v.png) |

**動態內容**：

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **平移** | ![not supported](x.png) | ![supported](v.png) |
| **摩天輪** | ![supported](v.png) | ![supported](v.png) |
| **傳送帶** | ![not supported](x.png) | ![supported](v.png) |
| **旋轉** | ![not supported](x.png) | ![supported](v.png) |
| **軌道** | ![not supported](x.png) | ![supported](v.png) |
| **穿越** | ![supported](v.png) | ![supported](v.png) |

## **常見問題**

**是否可以轉換受密碼保護的簡報？**

是的，Aspose.Slides for .NET 支援處理受密碼保護的簡報。處理此類檔案時，您需要提供正確的密碼，以便程式庫存取簡報內容。

**Aspose.Slides for .NET 是否支援在雲端解決方案中使用？**

是的，Aspose.Slides for .NET 可整合至雲端應用程式與服務。此程式庫設計用於伺服器環境，確保在大量檔案批次處理時具備高效能與可擴展性。

**在轉換過程中，簡報的大小是否有限制？**

Aspose.Slides for .NET 能處理實質上任意大小的簡報。然而，處理極大檔案時可能需要額外的系統資源，建議視需要最佳化簡報以提升效能。