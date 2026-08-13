---
title: 在 Java 中將 PowerPoint 簡報轉換為影片
linktitle: PowerPoint 轉影片
type: docs
weight: 130
url: /zh-hant/java/convert-powerpoint-to-video/
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
- Java
- Aspose.Slides
description: "了解如何在 Java 中將 PowerPoint 簡報轉換為影片。探索範例程式碼與自動化技術，以簡化工作流程。"
---
## **簡介**

將您的 PowerPoint 或 OpenDocument 簡報轉換為影片，您將獲得：

**提高可及性:** 所有裝置，無論平台為何，預設皆配備影片播放程式，較傳統簡報應用程式更方便使用者開啟或播放影片。

**更廣的受眾:** 影片使您能觸及更大的受眾，並以更具吸引力的方式呈現資訊。調查與統計顯示，人們較喜歡觀看和消費影片內容，而非其他形式，讓您的訊息更具影響力。

{{% alert color="info" %}} 
您可能想查看我們的[**PowerPoint 轉影片線上轉換器**](https://products.aspose.app/slides/zh-hant/video)，因為它是此處描述過程的即時且有效的實作。
{{% /alert %}} 

## **PowerPoint 轉影片轉換於 Aspose.Slides**

在 [Aspose.Slides 22.11](https://docs.aspose.com/slides/zh-hant/java/aspose-slides-for-java-22-11-release-notes/)，我們實作了簡報轉影片的支援。

* 使用 **Aspose.Slides** 產生一組符合特定 FPS（每秒影格數）的影格（取自簡報投影片）。
* 使用第三方工具，如 **ffmpeg**（[for java](https://github.com/bramp/ffmpeg-cli-wrapper)）根據這些影格建立影片。

### **轉換 PowerPoint 為影片**

1. Add this to your POM file:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. 下載 ffmpeg [此處](https://ffmpeg.org/download.html)。

4. 執行 PowerPoint 轉影片的 Java 程式碼。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // 新增笑臉形狀並對其進行動畫化
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

    // 設定 ffmpeg 二進位檔案夾。參閱此頁面：https://github.com/rosenbjerg/FFMpegCore#installation
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

您可以對投影片中的物件套用動畫，並在投影片之間使用轉場。

{{% alert color="info" %}} 
您可能想參考以下文章：[PowerPoint 動畫](https://docs.aspose.com/slides/zh-hant/java/powerpoint-animation/)、[形狀動畫](https://docs.aspose.com/slides/zh-hant/java/shape-animation/)，以及[形狀效果](https://docs.aspose.com/slides/zh-hant/java/shape-effect/)。
{{% /alert %}} 

動畫與轉場使投影片秀更具吸引力與趣味——影片亦同。讓我們為先前的簡報程式碼新增另一張投影片與轉場：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    // 新增笑臉形狀並對其進行動畫化

    // ...

    // 新增投影片並加入動畫過場

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides 也支援文字動畫。因此我們會對物件上的段落進行動畫，使其依序出現（延遲設定為一秒）：

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);

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

    // 設定 ffmpeg 二進位檔案夾。參閱此頁面：https://github.com/rosenbjerg/FFMpegCore#installation
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

為了讓您執行 PowerPoint 轉影片的任務，Aspose.Slides 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationanimationsgenerator/) 與 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationplayer/) 類別。

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationanimationsgenerator/) 允許您透過建構函式設定影片的影格大小（稍後會建立）。若傳入簡報實例，將使用 `Presentation.SlideSize`，並產生供 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationplayer/) 使用的動畫。

當產生動畫時，會為每個後續動畫產生 `NewAnimation` 事件，該事件帶有 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationanimationplayer/) 參數。後者是一個代表單獨動畫播放器的類別。

要使用 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationanimationplayer/)，會使用 [Duration](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--)（動畫的完整持續時間）屬性以及 [SetTimePosition](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) 方法。每個動畫位置在 *0 到 duration* 範圍內設定，之後 `getFrame` 方法會回傳對應該時刻動畫狀態的 [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/)：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // 新增笑臉形狀並對其進行動畫化
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
            // 初始動畫狀態位圖
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // 最終動畫狀態
            // 動畫的最後影格
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // 產生動畫 - 這會觸發上述處理的事件
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

若要使簡報中的所有動畫同時播放，使用 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationplayer/) 類別。此類別在建構函式中接受一個 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationanimationsgenerator/) 實例與效果的 FPS，然後對所有動畫觸發 `FrameTick` 事件以播放它們：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
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

接著可將產生的影格編譯成影片。請參閱 [Convert PowerPoint to Video](https://docs.aspose.com/slides/zh-hant/java/convert-powerpoint-to-video/#convert-powerpoint-to-video) 章節。

## **支援的動畫與效果**

**進入**：

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

## **常見問題**

### 是否可以轉換受密碼保護的簡報？

是的，Aspose.Slides 支援處理[受密碼保護的簡報](/slides/zh-hant/java/password-protected-presentation/)。處理此類檔案時，您需提供正確的密碼，以便程式庫存取簡報內容。

### Aspose.Slides 是否支援在雲端解決方案中使用？

是的，Aspose.Slides 可以整合至雲端應用程式與服務。此程式庫設計於伺服器環境中運作，確保高效能與可擴充性，適用於批次處理檔案。

### 轉換過程中簡報的大小是否有限制？

Aspose.Slides 能處理幾乎任何大小的簡報。然而，處理非常大的檔案時，可能需要額外的系統資源，且有時建議最佳化簡報以提升效能。