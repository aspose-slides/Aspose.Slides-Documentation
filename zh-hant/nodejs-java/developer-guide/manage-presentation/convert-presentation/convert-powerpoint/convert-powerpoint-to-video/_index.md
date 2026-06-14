---
title: 在 JavaScript 中將 PowerPoint 簡報轉換為影片
linktitle: PowerPoint 轉影片
type: docs
weight: 130
url: /zh-hant/nodejs-java/convert-powerpoint-to-video/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何在 JavaScript 中將 PowerPoint 簡報轉換為影片。探索範例程式碼和自動化技術，以簡化您的工作流程。"
---
## **簡介**

* **可及性提升：** 所有裝置（不論平台）預設皆具備影片播放器，相較於開啟簡報的應用程式，使用者更容易開啟或播放影片。
* **更廣的觸及範圍：** 透過影片，您可以觸及大量觀眾，並向他們傳遞在簡報中可能顯得冗長的資訊。大多數調查與統計顯示，人們觀看與消化影片的比例高於其他形式的內容，且普遍偏好此類內容。

{{% alert color="primary" %}} 
您可能想查看我們的[**PowerPoint 轉影片線上轉換器**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-word)，因為它是此處說明流程的即時且有效的實作。
{{% /alert %}} 

## **Aspose.Slides 中的 PowerPoint 轉影片轉換**

Aspose.Slides 支援簡報轉影片的轉換。

* 使用 **Aspose.Slides** 產生一組對應特定 FPS（每秒影格數）的框格（來自簡報投影片）。
* 使用第三方工具，如 **ffmpeg**（[for java](https://github.com/bramp/ffmpeg-cli-wrapper)）依據這些框格建立影片。

### **將 PowerPoint 轉換為影片**

1. 下載 ffmpeg [here](https://ffmpeg.org/download.html)。
2. 執行 PowerPoint 轉影片的 JavaScript 程式碼。

此 JavaScript 程式碼示範如何將包含圖形與兩個動畫效果的簡報轉換為影片：

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 新增一個笑臉形狀，然後為其設定動畫
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // 設定 ffmpeg 二進位檔案資料夾。詳見此頁面：https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **影片效果**

您可以對投影片上的物件套用動畫，並在投影片之間使用轉場。

{{% alert color="primary" %}} 
您可能想閱讀以下文章：[PowerPoint 動畫](https://docs.aspose.com/slides/zh-hant/nodejs-java/powerpoint-animation/)、[形狀動畫](https://docs.aspose.com/slides/zh-hant/nodejs-java/shape-animation/)、以及[形狀效果](https://docs.aspose.com/slides/zh-hant/nodejs-java/shape-effect/)。
{{% /alert %}} 

動畫與轉場使投影片更具吸引力與趣味，影片亦同。讓我們為先前的簡報程式碼新增另一張投影片與轉場：

```javascript
// 新增一個笑臉形狀並為其設定動畫
// ...
// 新增一個投影片並加入動畫轉場
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```

Aspose.Slides 也支援文字動畫。因此我們對物件上的段落進行動畫，使其依序顯示（延遲設定為一秒）：

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 新增文字與動畫
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // 設定 ffmpeg 二進位檔案資料夾。參見此頁面：https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **影片轉換類別**

為了讓您執行 PowerPoint 轉影片的任務，Aspose.Slides 提供了 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationanimationsgenerator/) 與 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationplayer/) 類別。

`PresentationAnimationsGenerator` 允許您透過建構函式設定稍後將建立的影片的框格大小。若傳入簡報實例，將使用 `Presentation.getSlideSize`，並產生供 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationplayer/) 使用的動畫。

產生動畫時，會為每個後續動畫觸發 `NewAnimation` 事件，該事件帶有簡報動畫播放器參數。此參數是代表單一動畫播放器的類別。

要操作簡報動畫播放器，使用 `getDuration`（動畫的完整持續時間）方法與 `setTimePosition` 方法。每個動畫位置設定於 *0 到 duration* 的範圍內，然後 `getFrame` 方法會回傳對應於該時刻動畫狀態的 BufferedImage：

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 新增一個笑臉形狀並為其設定動畫
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0);// 初始動畫狀態
            try {
                // 初始動畫狀態位圖
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// 動畫的最終狀態
            try {
                // 動畫的最後一幀
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

為了讓簡報中的所有動畫一次播放，使用 [PresentationPlayer](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationplayer/) 類別。此類別在建構函式中接收 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationanimationsgenerator/) 實例與 FPS，然後對所有動畫觸發 `FrameTick` 事件，以完成播放：

```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

接著即可將產生的框格編譯成影片。請參考 [Convert PowerPoint to Video](https://docs.aspose.com/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video) 章節。

## **支援的動畫與效果**

**進入**：

| 動畫類型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **顯示** | ![not supported](x.png) | ![supported](v.png) |
| **淡入淡出** | ![supported](v.png) | ![supported](v.png) |
| **飛入** | ![supported](v.png) | ![supported](v.png) |
| **浮入** | ![supported](v.png) | ![supported](v.png) |
| **分割** | ![supported](v.png) | ![supported](v.png) |
| **擦拭** | ![supported](v.png) | ![supported](v.png) |
| **形狀** | ![supported](v.png) | ![supported](v.png) |
| **輪子** | ![supported](v.png) | ![supported](v.png) |
| **隨機條紋** | ![supported](v.png) | ![supported](v.png) |
| **成長並旋轉** | ![not supported](x.png) | ![supported](v.png) |
| **縮放** | ![supported](v.png) | ![supported](v.png) |
| **旋轉** | ![supported](v.png) | ![supported](v.png) |
| **彈跳** | ![supported](v.png) | ![supported](v.png) |

**強調**：

| 動畫類型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **脈衝** | ![not supported](x.png) | ![supported](v.png) |
| **顏色脈衝** | ![not supported](x.png) | ![supported](v.png) |
| **搖擺** | ![supported](v.png) | ![supported](v.png) |
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

**退出**：

| 動畫類型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **消失** | ![not supported](x.png) | ![supported](v.png) |
| **淡入淡出** | ![supported](v.png) | ![supported](v.png) |
| **飛出** | ![supported](v.png) | ![supported](v.png) |
| **浮出** | ![supported](v.png) | ![supported](v.png) |
| **分割** | ![supported](v.png) | ![supported](v.png) |
| **擦拭** | ![supported](v.png) | ![supported](v.png) |
| **形狀** | ![supported](v.png) | ![supported](v.png) |
| **隨機條紋** | ![supported](v.png) | ![supported](v.png) |
| **縮小並旋轉** | ![not supported](x.png) | ![supported](v.png) |
| **縮放** | ![supported](v.png) | ![supported](v.png) |
| **旋轉** | ![supported](v.png) | ![supported](v.png) |
| **彈跳** | ![supported](v.png) | ![supported](v.png) |

**運動路徑**：

| 動畫類型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **線條** | ![supported](v.png) | ![supported](v.png) |
| **弧線** | ![supported](v.png) | ![supported](v.png) |
| **轉彎** | ![supported](v.png) | ![supported](v.png) |
| **形狀** | ![supported](v.png) | ![supported](v.png) |
| **迴圈** | ![supported](v.png) | ![supported](v.png) |
| **自訂路徑** | ![supported](v.png) | ![supported](v.png) |

## **常見問題**

**是否可以轉換受密碼保護的簡報？**

是的，Aspose.Slides 支援處理受密碼保護的簡報。處理此類檔案時，您需要提供正確的密碼，以便程式庫存取簡報內容。

**Aspose.Slides 是否支援在雲端解決方案中使用？**

是的，Aspose.Slides 可整合至雲端應用程式與服務。該程式庫設計於伺服器環境中運作，確保批次檔案處理時具備高效能與可擴充性。

**在轉換過程中，簡報的大小是否有限制？**

Aspose.Slides 能處理實質上任意大小的簡報。然而，處理非常大的檔案時可能需要額外的系統資源，建議適度最佳化簡報以提升效能。