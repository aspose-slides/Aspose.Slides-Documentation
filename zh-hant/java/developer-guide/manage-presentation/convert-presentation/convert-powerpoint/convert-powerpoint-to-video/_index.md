---
title: 在 Java 中將 PowerPoint 簡報轉換為影片
linktitle: PowerPoint 轉影片
type: docs
weight: 130
url: /zh-hant/java/convert-powerpoint-to-video/
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
- Java
- Aspose.Slides
description: "了解如何在 Java 中將 PowerPoint 簡報轉換為影片。探索範例程式碼與自動化技術，以簡化工作流程。"
---
## **簡介**

將您的 PowerPoint 或 OpenDocument 簡報轉換為影片後，您將獲得：

**提升可及性：** 所有裝置無論平台為何，預設皆配備影片播放器，使使用者相較於傳統簡報應用程式更容易開啟或播放影片。

**更廣的受眾：** 影片讓您能夠觸及更廣大的觀眾，並以更具吸引力的方式呈現資訊。調查與統計顯示，民眾較偏好觀看與消費影片內容，而非其他形式，使您的訊息更具衝擊力。

{{% alert color="primary" %}} 
您可能想要查看我們的 [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-word) 因為它是此處描述流程的即時且有效的實作。
{{% /alert %}} 

## **Aspose.Slides 中的 PowerPoint 轉影片轉換**

在 [Aspose.Slides 22.11](https://docs.aspose.com/slides/zh-hant/java/aspose-slides-for-java-22-11-release-notes/) 中，我們實作了簡報轉影片的支援。 

* 使用 **Aspose.Slides** 產生一組畫格（來自簡報投影片），對應特定的 FPS（每秒畫格數）
* 使用第三方工具，例如 **ffmpeg**（[for java](https://github.com/bramp/ffmpeg-cli-wrapper)）根據這些畫格建立影片。 

### **將 PowerPoint 轉換為影片**

1. 將以下內容加入您的 POM 檔案：
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. 從[此處](https://ffmpeg.org/download.html)下載 ffmpeg。

4. 執行 PowerPoint 轉影片的 Java 程式碼。

此段 Java 程式碼示範如何將包含圖形和兩個動畫效果的簡報轉換為影片：
```java
Presentation presentation = new Presentation();
try {
    // 新增一個笑臉形狀並為其設定動畫
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // 設定 ffmpeg 二進位檔資料夾。請參閱此頁面: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **影片效果**

您可以對投影片上的物件套用動畫，並在投影片之間使用轉場。 

{{% alert color="primary" %}} 
您可能想查看以下文章: [PowerPoint Animation](https://docs.aspose.com/slides/zh-hant/java/powerpoint-animation/)、[Shape Animation](https://docs.aspose.com/slides/zh-hant/java/shape-animation/)、以及 [Shape Effect](https://docs.aspose.com/slides/zh-hant/java/shape-effect/)。
{{% /alert %}} 

動畫與轉場讓投影片秀更具吸引力與趣味──而影片亦同。讓我們為先前的簡報程式碼加入另一張投影片與轉場：
```java
// 新增一個笑臉形狀並為其設定動畫

// ...

// 新增一張投影片並設定動畫轉場

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides 亦支援文字動畫。因此我們對物件上的段落套用動畫，讓它們依序顯示（延遲設定為一秒）：
```java
Presentation presentation = new Presentation();
try {
    // 新增文字與動畫
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraph by paragraph"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // 設定 ffmpeg 二進位檔資料夾。請參閱此頁面: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **影片轉換類別**

為了讓您執行 PowerPoint 轉影片的工作，Aspose.Slides 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationanimationsgenerator/) 與 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationplayer/) 類別。

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationanimationsgenerator/) 允許您透過建構子設定影片的畫格尺寸（之後將建立的影片）。若傳入簡報實例，將使用 `Presentation.SlideSize`，並產生供 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationplayer/) 使用的動畫。 

在產生動畫時，會為每個後續動畫產生 `NewAnimation` 事件，該事件具有 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationanimationplayer/) 參數。後者是一個代表單獨動畫播放器的類別。

使用 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationanimationplayer/) 時，會使用 [Duration](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--)（動畫的完整持續時間）屬性與 [SetTimePosition](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) 方法。每個動畫位置皆設定在 *0 到 duration* 的範圍內，之後 `GetFrame` 方法會回傳對應該時刻動畫狀態的 BufferedImage：
```java
Presentation presentation = new Presentation();
try {
    // 新增一個笑臉形狀並為其設定動畫
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // 初始動畫狀態
            try {
                // 初始動畫狀態位圖
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // 動畫的最終狀態
            try {
                // 動畫的最後一幀
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

若要讓簡報中的所有動畫同時播放，會使用 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationplayer/) 類別。此類別在建構子中接受一個 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationanimationsgenerator/) 實例與效果的 FPS，然後呼叫 `FrameTick` 事件以播放所有動畫：
```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

接著可將產生的畫格編譯成影片。請參閱 [Convert PowerPoint to Video](https://docs.aspose.com/slides/zh-hant/java/convert-powerpoint-to-video/#convert-powerpoint-to-video) 章節。

## **支援的動畫與效果**

**進入**:

| 動畫類型 | Aspose.Slides | PowerPoint |
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

| 動畫類型 | Aspose.Slides | PowerPoint |
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

| 動畫類型 | Aspose.Slides | PowerPoint |
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

**運動路徑**:

| 動畫類型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **常見問題**

**能否轉換受密碼保護的簡報？**

是的，Aspose.Slides 支援處理 [受密碼保護的簡報](/slides/zh-hant/java/password-protected-presentation/)。在處理此類檔案時，您必須提供正確的密碼，以便函式庫能存取簡報內容。

**Aspose.Slides 是否支援在雲端解決方案中使用？**

是的，Aspose.Slides 能整合至雲端應用程式與服務。此函式庫設計用於伺服器環境，確保在批次檔案處理時具備高效能與可擴充性。

**在轉換過程中，簡報的大小是否有限制？**

Aspose.Slides 能處理幾乎任意大小的簡報。然而，處理非常大的檔案時，可能需要額外的系統資源，有時也建議最佳化簡報以提升效能。