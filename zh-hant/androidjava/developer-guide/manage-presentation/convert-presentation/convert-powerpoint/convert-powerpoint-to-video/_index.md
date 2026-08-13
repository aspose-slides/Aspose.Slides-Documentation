---
title: 在 Android 上將 PowerPoint 簡報轉換為影片
linktitle: PowerPoint 轉影片
type: docs
weight: 130
url: /zh-hant/androidjava/convert-powerpoint-to-video/
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
- Android
- Java
- Aspose.Slides
description: "了解如何在 Java 中將 PowerPoint 簡報轉換為影片。探索範例程式碼與自動化技術，以簡化您的工作流程。"
---
## **簡介**

將 PowerPoint 簡報轉換成影片後，您將獲得

* **可近性提升：** 與簡報開啟應用程式相比，所有裝置（不論平台）預設皆具備影片播放器，因此使用者較容易開啟或播放影片。
* **更廣的觸及範圍：** 透過影片，您可以接觸大量觀眾，並向他們傳遞在簡報中可能顯得乏味的資訊。大多數調查與統計顯示，人們觀看與消費影片的意願高於其他形式的內容，且普遍偏好此類內容。

## **Aspose.Slides 中的 PowerPoint 轉影片功能**

Aspose.Slides 支援簡報轉影片。

* 使用 **Aspose.Slides** 產生一組對應特定 FPS（每秒幀數）的影格（來自簡報投影片）。
* 使用諸如 **ffmpeg**（[for java](https://github.com/bramp/ffmpeg-cli-wrapper)）等第三方工具，依據這些影格建立影片。

### **將 PowerPoint 轉換為影片**

1. 在您的 POM 檔案中加入以下內容：
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. 前往 [此處](https://ffmpeg.org/download.html) 下載 ffmpeg。

3. 執行 PowerPoint 轉影片的 Java 程式碼。

以下 Java 程式碼展示了如何將包含圖形與兩個動畫效果的簡報轉換為影片：

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // 新增笑臉形狀，然後為其添加動畫
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

    // 設定 ffmpeg 二進位檔所在資料夾。請參閱此頁面: https://github.com/bramp/ffmpeg-cli-wrapper
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

{{% alert color="info" %}} 
您可能想閱讀以下文章：[PowerPoint Animation](https://docs.aspose.com/slides/zh-hant/androidjava/powerpoint-animation/)、[Shape Animation](https://docs.aspose.com/slides/zh-hant/androidjava/shape-animation/)、以及 [Shape Effect](https://docs.aspose.com/slides/zh-hant/androidjava/shape-effect/)。
{{% /alert %}} 

動畫與轉場使投影片放映更具吸引力與趣味，影片亦同理。讓我們為先前的簡報程式碼加入另一張投影片與轉場：

```java
import com.aspose.slides.*;
import java.awt.Color;

// 上面建立的帶有動畫笑臉形狀的簡報。
Presentation presentation = new Presentation();
try {
    // 新增一張投影片並加入動畫轉場

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides 也支援文字動畫。因此，我們對物件上的段落進行動畫，使其依次顯示（延遲設為 1 秒）：

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

    // 設定 ffmpeg 二進位檔所在資料夾。請參閱此頁面: https://github.com/bramp/ffmpeg-cli-wrapper
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

為了讓您執行 PowerPoint 轉影片的工作，Aspose.Slides 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationanimationsgenerator/) 與 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationplayer/) 類別。

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationanimationsgenerator/) 允許您在建構函式中設定稍後將建立之影片的影格尺寸。若傳入簡報實例，將使用 `Presentation.SlideSize`，並產生供 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationplayer/) 使用的動畫。

產生動畫時，會為每個後續動畫觸發 `NewAnimation` 事件，該事件帶有 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationanimationplayer/) 參數。此類別代表單一動畫的播放器。

使用 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationanimationplayer/) 時，會使用 [Duration](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--)（動畫的完整持續時間）屬性以及 [SetTimePosition](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) 方法。每個動畫位置皆設定在 *0 至 duration* 範圍內，然後 `getFrame` 方法會回傳對應於該時刻動畫狀態的 [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/)：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // 新增笑臉形狀並為其加入動畫
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

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // 動畫的最終狀態
            // 動畫的最後一幀
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // 產生動畫。上述回呼函式會對每個動畫執行
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

若要一次播放簡報中所有動畫，使用 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationplayer/) 類別。此類別在建構函式中接受一個 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentationanimationsgenerator/) 實例與 FPS，然後為所有動畫呼叫 `FrameTick` 事件以進行播放：

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

接著，產生的影格即可編譯為影片。請參閱 [Convert PowerPoint to Video](https://docs.aspose.com/slides/zh-hant/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video) 章節。

## **支援的動畫與效果**

**入口動畫**：

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

**強調動畫**：

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

**退出動畫**：

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

**動作路徑**：

| 動畫類型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **常見問題**

### 是否可以轉換受密碼保護的簡報？

是的，Aspose.Slides 支援處理 [受密碼保護的簡報](/slides/zh-hant/androidjava/password-protected-presentation/)。在處理此類檔案時，您需要提供正確的密碼，以便程式庫存取簡報內容。

### Aspose.Slides 是否支援在雲端解決方案中使用？

是的，Aspose.Slides 可整合至雲端應用與服務。此函式庫設計用於伺服器環境，確保高效能與可擴充性，以批次處理檔案。

### 轉換過程中對簡報大小有沒有限制？

Aspose.Slides 能處理實質上任何大小的簡報。然而，處理極大型檔案時可能需要額外的系統資源，建議在必要時最佳化簡報以提升效能。