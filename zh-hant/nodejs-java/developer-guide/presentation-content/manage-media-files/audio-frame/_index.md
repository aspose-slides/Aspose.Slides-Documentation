---
title: 使用 JavaScript 管理簡報中的音訊
linktitle: 音訊框架
type: docs
weight: 10
url: /zh-hant/nodejs-java/audio-frame/
keywords:
- 音訊
- 音訊框架
- 縮圖
- 新增音訊
- 音訊屬性
- 音訊選項
- 擷取音訊
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中建立與控制音訊框架——示範如何嵌入、剪裁、循環，以及在 PPT、PPTX 與 ODP 簡報中配置播放。"
---
## **概觀**

本篇文章說明如何在 Aspose.Slides 中使用音訊框架。它示範了如何將嵌入式音訊加入投影片、 自訂音訊框架的縮圖、 設定播放選項（如音量、循環、隱藏、剪裁與淡入淡出時間），以及如何 擷取投影片放映過程中使用的音訊。

## **建立音訊框架**

Aspose.Slides for Node.js via Java 允許您將音訊檔案加入投影片。音訊檔案會以音訊框架的形式嵌入投影片中。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 載入要嵌入投影片的音訊檔案串流。  
4. 將嵌入式音訊框架（包含音訊檔案）加入投影片。  
5. 設定由 [AudioFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AudioFrame) 物件所公開的 [PlayMode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AudioPlayModePreset) 與 `Volume`。  
6. 儲存已修改的簡報。

這段 JavaScript 程式碼示範如何將嵌入式音訊框架加入投影片：

```javascript
// 建立一個代表簡報檔案的 Presentation 類別實例
const pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    const sld = pres.getSlides().get_Item(0);
    // 將 wav 音訊檔載入為串流
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // 新增音訊框架
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // 設定音訊的播放模式與音量
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // 將 PowerPoint 檔寫入磁碟
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **變更音訊框架縮圖**

當您將音訊檔案加入簡報時，音訊會以具標準預設圖像的框架顯示（請參閱下方圖片）。您可以變更音訊框架的預覽圖片（設定您喜好的圖像）。

此 JavaScript 程式碼示範如何變更音訊框架的縮圖或預覽圖像：

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // 在投影片上加入音訊框架，指定位置與大小。
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // 將圖片加入簡報資源。
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 設定音訊框架的圖片。
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // 將修改後的簡報儲存至磁碟
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **變更音訊播放選項**

Aspose.Slides for Node.js via Java 允許您變更控制音訊播放或屬性的選項。例如，您可以調整音訊音量、設定音訊循環播放，甚至隱藏音訊圖示。

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/) properties:
- **Start** 下拉清單對應 [AudioFrame.setPlayMode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/#setPlayMode) 方法
- **Volume** 對應 [AudioFrame.setVolume](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/#setVolume) 方法
- **Play Across Slides** 對應 [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) 方法
- **Loop until Stopped** 對應 [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) 方法
- **Hide During Show** 對應 [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) 方法
- **Rewind after Playing** 對應 [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/#setRewindAudio) 方法

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/) properties:
- **Fade In** 對應 [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) 方法
- **Fade Out** 對應 [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) 方法
- **Trim Audio Start Time** 對應 [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) 方法
- **Trim Audio End Time** 的值等於音訊總長度減去 [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) 方法的值

PowerPoint 音量控制面板對應 [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/#setVolumeValue) 方法。您可以以百分比方式調整音訊音量。

以下說明如何變更音訊播放選項：

1. [建立](#create-audio-frame) 或取得音訊框架。  
2. 為想調整的音訊框架屬性設定新值。  
3. 儲存已修改的 PowerPoint 檔案。

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // 取得 AudioFrame 形狀
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // 設定播放模式為點擊時播放
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // 設定音量為低
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // 設定音訊跨投影片播放
    audioFrame.setPlayAcrossSlides(true);
    // 停用音訊的循環
    audioFrame.setPlayLoopMode(false);
    // 在投影片放映期間隱藏 AudioFrame
    audioFrame.setHideAtShowing(true);
    // 播放完畢後將音訊倒帶至開始
    audioFrame.setRewindAudio(true);
    // 將 PowerPoint 檔案儲存至磁碟
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

此 JavaScript 範例示範如何加入含嵌入式音訊的新音訊框架、剪裁它，並設定淡入淡出時間：

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // 設定剪裁開始偏移為 1.5 秒
    audioFrame.setTrimFromStart(1500);
    // 設定剪裁結束偏移為 2 秒
    audioFrame.setTrimFromEnd(2000);

    // 設定淡入持續時間為 200 毫秒
    audioFrame.setFadeInDuration(200);
    // 設定淡出持續時間為 500 毫秒
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

以下程式碼範例說明如何取得帶嵌入式音訊的音訊框架，並將音量設定為 85%：

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // 取得音訊框架形狀
    const audioFrame = slide.getShapes().get_Item(0);

    // 將音訊音量設定為 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **管理音訊字幕**

Aspose.Slides 允許您透過 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) 方法為音訊框架加入閉路字幕。此方法會回傳一個 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/)，讓您能新增 WebVTT 字幕軌、遍歷既有軌道，並在需要時移除它們。

**加入音訊字幕**

使用 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) 方法將一個或多個字幕軌附加到音訊框架。以下範例先將音訊檔案加入投影片，然後從 `.vtt` 檔案載入新的字幕軌。

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // 從 WebVTT 檔案新增一條字幕軌道。
    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**擷取音訊字幕**

您可以遍歷與音訊框架關聯的字幕軌，並將其儲存為 `.vtt` 檔案。每條字幕軌會暴露其二進位資料與唯一識別碼，可於匯出字幕時使用。

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            let audioFrame = shape;
            let trackCount = audioFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = audioFrame.getCaptionTracks().get_Item(trackIndex);
                // 將字幕軌道儲存為 .vtt 檔案。
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**移除音訊字幕**

若要從音訊框架移除字幕，請使用 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/) 所提供的方法，例如 [clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/#clear)、[remove](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/captionscollection/#removeAt)。以下範例移除音訊框架中的所有字幕軌。

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // 類型: aspose.slides.AudioFrame

    // 移除音訊框架的所有字幕軌道。
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **擷取音訊**

Aspose.Slides for Node.js via Java 允許您擷取投影片放映過渡時使用的音效。例如，您可以擷取特定投影片中使用的音效。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例，並載入包含音訊的簡報。  
2. 透過索引取得相關投影片的參考。  
3. 取得該投影片的 [slideshow transitions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--)。  
4. 擷取音效的位元組資料。

以下 JavaScript 程式碼示範如何擷取投影片中使用的音訊：

```javascript
// 建立代表簡報檔案的 Presentation 類別實例
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // 取得目標投影片
    const slide = pres.getSlides().get_Item(0);
    // 取得投影片的投影片放映過渡效果
    const transition = slide.getSlideShowTransition();
    // 以位元組陣列形式擷取音效
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**我可以在多張投影片中重複使用相同的音訊資產，而不會增加檔案大小嗎？**

**可以。**將音訊一次加入簡報的共用 [audio collection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getaudios/)，然後建立額外的音訊框架來參照該已存在的資產。此方式避免複製媒體資料，保持簡報大小受控。

**我可以在不重新建立形狀的情況下，替換現有音訊框架的音效嗎？**

**可以。**對於連結音訊，更新 [link path](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) 以指向新檔案。對於嵌入式音訊，將 [embedded audio](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) 物件替換為簡報的另一個 [audio collection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getaudios/) 中的音訊。框架的格式與大多數播放設定將保持不變。

**剪裁會改變簡報中儲存的音訊底層資料嗎？**

**不會。**剪裁僅調整播放的起止界限。原始音訊位元組保持不變，且仍可透過嵌入式音訊或簡報的音訊集合存取。