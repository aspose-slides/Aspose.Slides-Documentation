---
title: 使用 Java 管理簡報中的音訊
linktitle: 音訊框架
type: docs
weight: 10
url: /zh-hant/java/audio-frame/
keywords:
- 音訊
- 音訊框架
- 縮圖
- 新增音訊
- 音訊屬性
- 音訊選項
- 擷取音訊
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中建立與控制音訊框架——提供嵌入、修剪、迴圈以及在 PPT、PPTX 與 ODP 簡報中設定播放的程式碼範例。"
---
## **概述**

本文說明如何在 Aspose.Slides 中處理音訊框架。它展示了如何將嵌入式音訊加入投影片、自訂音訊框架縮圖、設定播放選項（例如音量、迴圈、隱藏、修剪和淡入淡出時間），以及如何擷取投影片放映轉場所使用的音訊。

## **建立音訊框架**

Aspose.Slides for Java 允許您將音訊檔案加入投影片。音訊檔案會以音訊框架的形式嵌入投影片中。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
2. 透過索引取得投影片的參考。
3. 載入您想嵌入至投影片的音訊檔案串流。
4. 將嵌入式音訊框架（包含音訊檔案）加入投影片。
5. 設定由 [IAudioFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAudioFrame) 物件所公開的 [PlayMode](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/AudioPlayModePreset) 和 `Volume`。
6. 儲存已修改的簡報。

以下 Java 程式碼示範如何將嵌入式音訊框架加入投影片：

```java
// 實例化一個代表簡報檔的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 將 wav 音訊檔載入為串流
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // 加入音訊框架
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // 設定音訊的播放模式與音量
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // 將 PowerPoint 檔寫入磁碟
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **變更音訊框架縮圖**

當您將音訊檔案加入簡報時，音訊會以具有預設標準圖像的框架顯示（請見下方圖片）。您可以變更音訊框架的預覽圖像（設定您偏好的圖像）。

以下 Java 程式碼示範如何變更音訊框架的縮圖或預覽圖像：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 在投影片上加入音訊框架，並指定位置與大小。
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // 將圖片加入簡報資源。
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 設定音訊框架的圖片。
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    // 將修改後的簡報儲存至磁碟
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **變更音訊播放選項**

Aspose.Slides for Java 允許您變更控制音訊播放或屬性的選項。例如，您可以調整音訊音量、設定音訊迴圈播放，甚至隱藏音訊圖示。

Microsoft PowerPoint 中的 **Audio Options** 面板：

![範例1_圖像](audio_frame_0.png)

PowerPoint **Audio Options** 對應 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/AudioFrame) 屬性：

- **Start** 下拉清單對應 [AudioFrame.setPlayMode](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/audioframe/#setPlayMode-int-) 方法
- **Volume** 對應 [AudioFrame.setVolume](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/audioframe/#setVolume-int-) 方法
- **Play Across Slides** 對應 [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-) 方法
- **Loop until Stopped** 對應 [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-) 方法
- **Hide During Show** 對應 [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-) 方法
- **Rewind after Playing** 對應 [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-) 方法

PowerPoint **Editing** 選項對應 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/AudioFrame) 屬性：

- **Fade In** 對應 [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/audioframe/#setFadeInDuration-float-) 方法
- **Fade Out** 對應 [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-) 方法
- **Trim Audio Start Time** 對應 [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/audioframe/#setTrimFromStart-float-) 方法
- **Trim Audio End Time** 的值等於音訊總長度減去 [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-) 方法的設定值

PowerPoint 音量控制面板對應 [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/audioframe/#setVolumeValue-float-) 方法，可讓您以百分比調整音量。

以下說明如何變更音訊播放選項：

1. [Сreate](#create-audio-frame) 或取得音訊框架。
2. 為要調整的音訊框架屬性設定新值。
3. 儲存已修改的 PowerPoint 檔案。

以下 Java 程式碼示範調整音訊選項的操作：

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // 取得 AudioFrame 形狀
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // 設定播放模式為點擊播放
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // 設定音量為低
    audioFrame.setVolume(AudioVolumeMode.Low);

    // 設定音訊跨投影片播放
    audioFrame.setPlayAcrossSlides(true);

    // 停用音訊的迴圈播放
    audioFrame.setPlayLoopMode(false);

    // 在投影片放映期間隱藏 AudioFrame
    audioFrame.setHideAtShowing(true);

    // 播放結束後將音訊倒回開頭
    audioFrame.setRewindAudio(true);

    // 將 PowerPoint 檔案儲存至磁碟
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

此 Java 範例說明如何加入嵌入式音訊的新音訊框架、修剪音訊並設定淡入淡出時間：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // 設定修剪起始位移為 1.5 秒
    audioFrame.setTrimFromStart(1500f);
    // 設定修剪結束位移為 2 秒
    audioFrame.setTrimFromEnd(2000f);

    // 設定淡入持續時間為 200 毫秒
    audioFrame.setFadeInDuration(200f);
    // 設定淡出持續時間為 500 毫秒
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

以下程式碼示例說明如何取得包含嵌入式音訊的音訊框架並將音量設為 85%：

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // 取得音訊框架形狀
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // 設定音訊音量為 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **管理音訊字幕**

Aspose.Slides 允許您透過 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) 方法為音訊框架加入隱閉字幕。此方法會傳回 [ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/) 介面，您可以加入 WebVTT 字幕軌、遍歷現有軌道，並在需要時將其移除。

**新增音訊字幕**

使用 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) 方法將一個或多個字幕軌附加至音訊框架。下列範例先將音訊檔案加入投影片，然後從 `.vtt` 檔案載入新的字幕軌。

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // 從 WebVTT 檔案新增一個字幕軌道。
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**擷取音訊字幕**

您可以遍歷與音訊框架相關聯的字幕軌，並將它們儲存為 `.vtt` 檔案。每個字幕軌都會公開其二進位資料與唯一識別碼，可於匯出字幕時使用。

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // 將字幕軌道儲存為 .vtt 檔案。
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**移除音訊字幕**

若要從音訊框架移除字幕，請使用 [ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/) 提供的方法，例如 [clear](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/#clear--)、[remove](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) 或 [removeAt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icaptionscollection/#removeAt-int-)。以下範例示範移除音訊框架中的全部字幕軌。

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // 移除音訊框架中的所有字幕軌道。
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **擷取音訊**

Aspose.Slides for Java 允許您擷取投影片放映轉場所使用的聲音。例如，您可以擷取特定投影片所使用的聲音。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例，並載入包含音訊的簡報。
2. 透過索引取得相關投影片的參考。
3. 取得該投影片的 [slideshow transitions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--)。
4. 以位元組資料形式擷取聲音。

以下 Java 程式碼示範如何擷取投影片中使用的音訊：

```java
// 實例化一個代表簡報檔的 Presentation 類別
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // 存取目標投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 取得投影片的投影片放映轉場效果
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //提取聲音的位元組陣列
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以在多個投影片之間重複使用相同的音訊資產，而不會增加檔案大小嗎？**

可以。將音訊一次加入簡報的共用 [audio collection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getAudios--)，然後建立其他參考該資產的音訊框架。這樣可避免重複媒體資料，保持簡報大小在可控範圍。

**我能在不重新建立圖形的情況下取代現有音訊框架中的音效嗎？**

可以。對於連結音訊，只需更新 [link path](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) 以指向新檔案。對於嵌入式音訊，將 [embedded audio](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) 物件替換為簡報的 [audio collection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getAudios--) 中的其他音訊。框架的格式及大多數播放設定會保持不變。

**修剪會改變簡報中儲存的底層音訊資料嗎？**

不會。修剪僅調整播放的起止邊界，原始音訊位元組保持不變，仍可透過嵌入式音訊或簡報的音訊集合取得。