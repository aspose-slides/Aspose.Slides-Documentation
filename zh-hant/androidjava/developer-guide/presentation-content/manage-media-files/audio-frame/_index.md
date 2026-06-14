---
title: 在 Android 上管理簡報中的音訊
linktitle: 音訊框架
type: docs
weight: 10
url: /zh-hant/androidjava/audio-frame/
keywords:
- 音訊
- 音訊框架
- 縮圖
- 新增音訊
- 音訊屬性
- 音訊選項
- 擷取音訊
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中建立與控制音訊框架—提供嵌入、修剪、循環與設定播放於 PPT、PPTX 與 ODP 簡報的 Java 範例。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用音訊框架。它展示了如何將嵌入式音訊添加至投影片、自訂音訊框架縮圖、設定播放選項（例如音量、循環、隱藏、修剪與淡入淡出持續時間），以及提取投影片秀過渡中使用的音訊。

## **建立音訊框架**
Aspose.Slides for Android via Java 允許您將音訊檔案新增至投影片。這些音訊檔案以音訊框架的形式嵌入投影片中。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
2. 透過索引取得投影片的參考。
3. 載入您想嵌入投影片的音訊檔案串流。
4. 將嵌入的音訊框架（包含音訊檔案）新增至投影片。
5. 設定由 [IAudioFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAudioFrame) 物件所公開的 [PlayMode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/AudioPlayModePreset) 和 `Volume`。
6. 儲存已修改的簡報。

以下 Java 程式碼示範如何將嵌入式音訊框架新增至投影片：

```java
// 建立一個表示簡報檔案的 Presentation 類別實例
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 載入 wav 音訊檔案至串流
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // 新增音訊框架
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // 設定音訊的播放模式與音量
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // 將 PowerPoint 檔案寫入磁碟
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **變更音訊框架縮圖**

當您將音訊檔案加入簡報時，音訊會以帶有標準預設圖像的框架顯示（請參見下節的圖像）。您可以變更音訊框架的預覽圖像（設定您偏好的圖像）。

以下 Java 程式碼示範如何變更音訊框架的縮圖或預覽圖像：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 在投影片上新增音訊框架，並指定位置與大小。
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // 將影像新增至簡報資源。
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 設定音訊框架的影像。
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Saves the modified presentation to disk
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **變更音訊播放選項**

Aspose.Slides for Android via Java 允許您變更控制音訊播放或屬性的選項。例如，您可以調整音訊的音量、設定音訊循環播放，甚至隱藏音訊圖示。

Microsoft PowerPoint 中的 **Audio Options** 面板：

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** 對應 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/AudioFrame) 屬性：

- **Start** 下拉清單對應 [AudioFrame.PlayMode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 屬性
- **Volume** 對應 [AudioFrame.Volume](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/AudioFrame#getVolume--) 屬性
- **Play Across Slides** 對應 [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) 屬性
- **Loop until Stopped** 對應 [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) 屬性
- **Hide During Show** 對應 [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) 屬性
- **Rewind after Playing** 對應 [AudioFrame.RewindAudio](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) 屬性

PowerPoint **Editing** 選項對應 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/audioframe/) 屬性：

- **Fade In** 對應 [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) 屬性
- **Fade Out** 對應 [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) 屬性
- **Trim Audio Start Time** 對應 [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) 屬性
- **Trim Audio End Time** 的值等於音訊總長度減去 [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) 屬性的值

PowerPoint 音訊控制面板上的 **Volume controll** 對應 [AudioFrame.VolumeValue](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) 屬性。它允許您以百分比變更音訊音量。

以下說明如何變更音訊播放選項：

1. [建立](#create-audio-frame) 或取得音訊框架。
2. 為您想調整的音訊框架屬性設定新值。
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

    // 設定音訊於各投影片間播放
    audioFrame.setPlayAcrossSlides(true);

    // 停用音訊的循環
    audioFrame.setPlayLoopMode(false);

    // 投影片秀期間隱藏 AudioFrame
    audioFrame.setHideAtShowing(true);

    // 播放完畢後將音訊倒回開頭
    audioFrame.setRewindAudio(true);

    // 將 PowerPoint 檔案寫入磁碟
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

以下 Java 範例示範如何新增帶有嵌入式音訊的音訊框架、對其進行修剪，並設定淡入淡出持續時間：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // 設定修剪起始偏移為 1.5 秒
    audioFrame.setTrimFromStart(1500f);
    // 設定修剪結束偏移為 2 秒
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

以下程式碼範例示範如何取得帶有嵌入式音訊的音訊框架，並將其音量設為 85%：

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

Aspose.Slides 允許您透過 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) 方法為音訊框架新增隱藏式字幕。此方法會回傳一個 [ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icaptionscollection/)，讓您可以新增 WebVTT 字幕軌、遍歷現有軌道，並在需要時將其移除。

**新增音訊字幕**

使用 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) 方法將一個或多個字幕軌附加至音訊框架。以下範例中，先將音訊檔案新增至投影片，然後從 `.vtt` 檔案載入新字幕軌。

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // 從 WebVTT 檔案新增一條字幕軌道。
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**擷取音訊字幕**

您可以遍歷與音訊框架相關聯的字幕軌，並將其儲存為 `.vtt` 檔案。每個字幕軌都會公開其二進位資料和唯一識別碼，可於匯出字幕時使用。

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // 將字幕軌道儲存為 .vtt 檔案。
                FileOutputStream fos = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                fos.write(captionTrack.getBinaryData());
                fos.close();
            }
        }
    }
} catch (IOException e){
} finally {
    presentation.dispose();
}
```

**移除音訊字幕**

若要從音訊框架中移除字幕，請使用 [ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icaptionscollection/) 提供的方法，例如 [clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icaptionscollection/#clear--)、[remove](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) 或 [removeAt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-)。以下範例會從音訊框架中移除所有字幕軌。

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // 移除音訊框架的所有字幕軌道。
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **擷取音訊**

Aspose.Slides for Android via Java 允許您擷取投影片秀過渡中使用的音效。例如，您可以擷取特定投影片中使用的音效。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例，並載入包含音訊的簡報。
2. 透過索引取得相關投影片的參考。
3. 取得投影片的 [slideshow transitions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--)。
4. 以位元組資料形式擷取音效。

以下 Java 程式碼示範如何擷取投影片中使用的音訊：

```java
// 建立一個代表簡報檔案的 Presentation 類別實例
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // 存取目標投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 取得投影片的投影片秀過渡效果
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //以位元組陣列擷取音效
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以在多張投影片間重複使用相同的音訊資源而不會增加檔案大小嗎？**

可以。只需將音訊一次加入簡報的共用 [audio collection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getAudios--)，然後建立其他參考該現有資產的音訊框架。這樣可避免重複儲存媒體資料，保持簡報檔案大小受控。

**我可以在不重新建立形狀的情況下，取代現有音訊框架中的音效嗎？**

可以。對於連結式音效，只需更新 [link path](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) 以指向新檔案。對於嵌入式音效，將 [embedded audio](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) 物件替換為簡報的 [audio collection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getAudios--) 中的其他音訊。框架的格式及大多數播放設定將保持不變。

**修剪會改變簡報中儲存的原始音訊資料嗎？**

不會。修剪僅調整播放的起止範圍，原始音訊位元組保持不變，仍可透過嵌入式音訊或簡報的音訊集合存取。