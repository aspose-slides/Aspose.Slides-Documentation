---
title: 用 Python 管理簡報中的音訊
linktitle: 音訊框
type: docs
weight: 10
url: /zh-hant/python-net/audio-frame/
keywords:
- 新增音訊
- 嵌入音訊
- 音訊框
- 音訊檔案
- 音訊屬性
- 抽取音訊
- 取得音訊
- 變更音訊
- 播放選項
- 播放模式
- 跨投影片播放
- 直至停止循環
- 放映時隱藏
- 播放後倒帶
- 音量
- 預設影像
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 輕鬆在 PPT、PPTX 與 ODP 中新增、抽取與管理音訊框。探索程式碼範例，即刻提升您的簡報。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用音訊框架。它展示了如何將嵌入式音訊加入投影片、客製化音訊框視覺縮圖、設定播放選項（例如音量、循環、隱藏、修剪與淡入淡出時間），以及如何擷取投影片放映過程中使用的音訊。

## **建立音訊框架**

Aspose.Slides for Python via .NET 允許您將音訊檔案加入投影片。音訊檔案會以音訊框的形式嵌入投影片中。 

1. 建立 [Presentation] 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 載入您想嵌入投影片的音訊檔案串流。  
4. 將嵌入式音訊框（包含音訊檔案）加入投影片。  
5. 設定由 [IAudioFrame] 物件公開的 [PlayMode] 與 `Volume`。  
6. 儲存已修改的簡報。

以下 Python 程式碼示範如何將嵌入式音訊框加入投影片：

```python
import aspose.slides as slides

# 實例化一個代表簡報檔的 Presentation 類別
with slides.Presentation() as pres:
    # 取得第一張投影片
    sld = pres.slides[0]

    # 載入 wav 聲音檔案為串流
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # 新增音訊框
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # 設定音訊的播放模式與音量
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # 將 PowerPoint 檔寫入磁碟
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **變更音訊框縮圖**

當您將音訊檔案加入簡報時，音訊會以具有預設標準影像的框架顯示（請參見下方圖片）。您可以變更音訊框的縮圖（設定您偏好的影像）。

以下 Python 程式碼示範如何變更音訊框的縮圖或預覽影像：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 在投影片上新增音訊框，指定位置與大小。
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # 將影像新增至簡報資源。
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # 設定音訊框的影像。
        audioFrame.picture_format.picture.image = audioImage
        
        #儲存修改後的簡報至磁碟
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **變更音訊播放選項**

Aspose.Slides for Python via .NET 允許您變更控制音訊播放或屬性的選項。例如，您可以調整音訊的音量、設定音訊循環播放，甚至隱藏音訊圖示。

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** 與 Aspose.Slides [AudioFrame] 屬性對應如下：

- **Start** 下拉式清單對應 [AudioFrame.play_mode] 屬性 
- **Volume** 對應 [AudioFrame.volume] 屬性 
- **Play Across Slides** 對應 [AudioFrame.play_across_slides] 屬性 
- **Loop until Stopped** 對應 [AudioFrame.play_loop_mode] 屬性 
- **Hide During Show** 對應 [AudioFrame.hide_at_showing] 屬性 
- **Rewind after Playing** 對應 [AudioFrame.rewind_audio] 屬性 

PowerPoint **Editing** options 與 Aspose.Slides [AudioFrame] 屬性對應如下：

- **Fade In** 對應 [AudioFrame.fade_in_duration] 屬性 
- **Fade Out** 對應 [AudioFrame.fade_out_duration] 屬性 
- **Trim Audio Start Time** 對應 [AudioFrame.trim_from_start] 屬性 
- **Trim Audio End Time** 的值等於音訊總時長減去 [AudioFrame.trim_from_end] 屬性的值

PowerPoint 音訊控制面板上的 **Volume controll**（音量控制）對應 [AudioFrame.volume_value] 屬性，可讓您以百分比調整音訊音量。

以下說明如何變更音訊播放選項：

1. [Create](#create-audio-frame) 或取得音訊框。  
2. 設定您想調整的音訊框屬性之新值。  
3. 儲存已修改的 PowerPoint 檔案。

以下 Python 程式碼示範調整音訊選項的操作：

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # 取得 AudioFrame 形狀
    audioFrame = pres.slides[0].shapes[0]

    # 設定播放模式為點擊時播放
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # 設定音量為低
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # 設定音訊跨投影片播放
    audioFrame.play_across_slides = True

    # 停用音訊循環
    audioFrame.play_loop_mode = False

    # 在投影片放映期間隱藏 AudioFrame
    audioFrame.hide_at_showing = True

    # 播放結束後將音訊倒帶至開始
    audioFrame.rewind_audio = True

    # 將 PowerPoint 檔儲存至磁碟
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

以下 Python 範例示範如何新增帶嵌入式音訊的音訊框、修剪它，並設定淡入淡出時間：

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # 設定剪裁起始偏移為 1.5 秒
    audio_frame.trim_from_start = 1500.0
    # 設定剪裁結束偏移為 2 秒
    audio_frame.trim_from_end = 2000.0

    # 設定淡入持續時間為 200 毫秒
    audio_frame.fade_in_duration = 200.0
    # 設定淡出持續時間為 500 毫秒
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

以下程式碼範例示範如何取得帶嵌入式音訊的音訊框，並將音量設定為 85%：

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # 取得音訊框形狀
    audio_frame = pres.slides[0].shapes[0]

    # 設定音訊音量為 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **管理音訊字幕**

Aspose.Slides 允許您透過 [caption_tracks] 屬性為音訊框新增閉合式字幕。此屬性會回傳一個 [CaptionsCollection]，讓您可以加入 WebVTT 字幕軌、遍歷現有軌道，並在需要時將其移除。

### **新增音訊字幕**

使用 [caption_tracks] 屬性將一個或多個字幕軌附加至音訊框。以下範例中，先將音訊檔案加入投影片，然後從 `.vtt` 檔案載入新的字幕軌。

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # 新增來自 WebVTT 檔案的字幕軌道。
    audio_frame.caption_tracks.add("New track", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **抽取音訊字幕**

您可以遍歷與音訊框關聯的字幕軌，並將它們儲存為 `.vtt` 檔案。每個字幕軌都會公開其二進位資料與唯一識別碼，可在匯出字幕時使用。

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # 將字幕軌保存為 .vtt 檔案。
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

### **移除音訊字幕**

若要從音訊框移除字幕，請使用 [CaptionsCollection] 提供的方法，例如 [clear]、[remove] 或 [remove_at]。以下範例會移除音訊框的所有字幕軌。

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # 類型: slides.AudioFrame

    # 從音訊框中移除所有字幕軌道。
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **抽取音訊**
Aspose.Slides for Python via .NET 允許您抽取投影片放映過程中使用的音效。例如，您可以抽取特定投影片使用的音效。

1. 建立 [Presentation] 類別的實例，並載入包含音訊的簡報。  
2. 透過索引取得相關投影片的參考。  
3. 取得該投影片的投影片放映轉場。  
4. 將音效以位元組資料抽取出來。

以下 Python 程式碼示範如何抽取投影片中使用的音訊：

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # 存取所需的投影片
    slide = pres.slides[0]  

    # 取得投影片的投影片放映過渡效果
    transition = slide.slide_show_transition

    #提取聲音的位元組陣列
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **常見問題**

**我可以在多張投影片間重複使用相同的音訊資產而不增加檔案大小嗎？**

可以。只需將音訊一次加入簡報的共享 [audio collection]，然後建立額外的音訊框以參照該現有資產。這樣可避免複製媒體資料，保持簡報檔案大小受控。

**我能在不重新建立形狀的情況下替換現有音訊框的音效嗎？**

可以。若為連結式音效，只需更新 [link path] 以指向新檔案。若為嵌入式音效，將 [embedded audio] 物件替換為簡報的 [audio collection] 中的其他音訊。框架的格式與大部分播放設定會保持不變。

**修剪會更改簡報中儲存的底層音訊資料嗎？**

不會。修剪僅調整播放範圍，原始音訊位元組保持不變，仍可透過嵌入式音訊或簡報的音訊集合取得。