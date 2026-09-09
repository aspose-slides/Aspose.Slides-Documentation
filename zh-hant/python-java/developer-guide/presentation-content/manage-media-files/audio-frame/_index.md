---
title: 使用 Python 在簡報中管理音訊
linktitle: 音訊框架
type: docs
weight: 10
url: /zh-hant/python-java/audio-frame/
keywords:
- 音訊
- 音訊框架
- 縮圖
- 新增音訊
- 音訊屬性
- 音訊選項
- 提取音訊
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中建立與控制音訊框架——提供嵌入、修剪、循環以及在 PPT、PPTX 與 ODP 簡報中設定播放的程式碼範例。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中處理音訊框架。它展示了如何將嵌入式音訊新增到投影片、客製化音訊框架的縮圖、設定播放選項（如音量、循環、隱藏、修剪與淡入淡出時間），以及如何擷取投影片放映過渡時使用的音訊。

## **建立音訊框架**

Aspose.Slides for Python via Java 允許您將音訊檔案新增到投影片。音訊檔案會以音訊框架的形式嵌入於投影片中。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 讀取您想要嵌入於投影片的音訊檔案。  
4. 將嵌入式音訊框架（包含音訊檔案）新增至投影片。  
5. 使用由 [AudioFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/) 物件公開的 [setPlayMode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setPlayMode) 與 [setVolume](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setVolume)。  
6. 儲存已修改的簡報。

以下 Python 程式碼示範如何將嵌入式音訊框架新增至投影片：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)
    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **變更音訊框架縮圖**

將音訊檔案加入簡報時，音訊會以預設圖示顯示（請參考下方圖示）。您可以將音訊框架的預覽圖更改為自訂圖像。

以下 Python 程式碼示範如何變更音訊框架的縮圖或預覽圖：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sample2.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **變更音訊播放選項**

Aspose.Slides for Python via Java 允許您變更控制音訊播放的選項或屬性。例如，您可以調整音量、設定循環播放，甚至隱藏音訊圖示。

Microsoft PowerPoint 中的 **Audio Options** 面板：

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** 與 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/) 屬性對應如下：

- **Start** 下拉清單對應 [setPlayMode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setPlayMode) 方法  
- **Volume** 對應 [setVolume](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setVolume) 方法  
- **Play Across Slides** 對應 [setPlayAcrossSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) 方法  
- **Loop until Stopped** 對應 [setPlayLoopMode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setPlayLoopMode) 方法  
- **Hide During Show** 對應 [setHideAtShowing](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setHideAtShowing) 方法  
- **Rewind after Playing** 對應 [setRewindAudio](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setRewindAudio) 方法  

PowerPoint **Editing** 選項與 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/) 屬性對應如下：

- **Fade In** 對應 [setFadeInDuration](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setFadeInDuration) 方法  
- **Fade Out** 對應 [setFadeOutDuration](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setFadeOutDuration) 方法  
- **Trim Audio Start Time** 對應 [setTrimFromStart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setTrimFromStart) 方法  
- **Trim Audio End Time** 的值等於音訊總長度減去 [setTrimFromEnd](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setTrimFromEnd) 設定的值  

PowerPoint 音訊控制面板上的 **Volume control** 對應 [setVolumeValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setVolumeValue) 方法，可讓您以百分比調整音量。

變更音訊播放選項的步驟如下：

1. 依照 [建立音訊框架](#create-audio-frames) 的方式取得音訊框架。  
2. 為需要調整的音訊框架屬性設定新值。  
3. 儲存已修改的 PowerPoint 檔案。

以下 Python 程式碼示範調整音訊選項的作業：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # 點擊時播放，音量低，跨投影片播放，且不循環。
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # 在投影片放映期間隱藏框架，播放後倒帶。
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

以下 Python 範例示範如何新增含嵌入式音訊的音訊框架、修剪它，並設定淡入淡出時間：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # 從起點修剪 1.5 秒，從終點修剪 2 秒。
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # 設定淡入 200 毫秒，淡出 500 毫秒。
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

以下程式碼範例示範如何取得含嵌入式音訊的音訊框架，並將音量設定為 85%：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **管理音訊字幕**

Aspose.Slides 允許您透過 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#getCaptionTracks) 方法為音訊框架新增封閉字幕。此方法會傳回一個 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captionscollection/)，您可以在其中加入 WebVTT 字幕軌、遍歷現有軌道，或在需要時將其移除。

**新增音訊字幕**

使用 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#getCaptionTracks) 方法將一個或多個字幕軌附加至音訊框架。以下範例先將音訊檔案新增至投影片，然後從 `.vtt` 檔案載入新的字幕軌。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # 從 WebVTT 檔案新增新的字幕軌道。
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**擷取音訊字幕**

您可以遍歷與音訊框架關聯的字幕軌，並將其儲存為 `.vtt` 檔案。每個字幕軌都會暴露其二進位資料與唯一識別碼，可在匯出字幕時使用。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # 將字幕軌道另存為 .vtt 檔案。
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**移除音訊字幕**

若要從音訊框架移除字幕，請使用 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captionscollection/) 所提供的方法，例如 [clear](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captionscollection/#clear)、[remove](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captionscollection/#removeAt)。以下範例移除音訊框架的所有字幕軌。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **提取音訊**

Aspose.Slides for Python via Java 允許您提取投影片放映過渡時使用的音效。例如，您可以提取特定投影片所使用的音效。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例，並載入含有音訊的簡報。  
2. 依索引取得相關投影片的參考。  
3. 透過 [slideshow transitions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/#getSlideShowTransition) 取得投影片的過渡設定。  
4. 將音效以位元組資料形式提取出來。

以下 Python 程式碼示範如何提取投影片使用的音訊：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**我可以在多個投影片間重複使用相同的音訊資產，而不會使檔案大小膨脹嗎？**

可以。將音訊一次加入簡報的共用 [audio collection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getAudios)，然後建立其他引用該資產的音訊框架。這樣可避免媒體資料重複，控制簡報大小。

**我可以在不重新建立圖形的情況下，替換現有音訊框架中的聲音嗎？**

可以。對於連結音訊，更新 [link path](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setLinkPathLong) 以指向新檔案。對於嵌入式音訊，將 [embedded audio](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setEmbeddedAudio) 物件交換為簡報 [audio collection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getAudios) 中的另一個音訊。框架的格式與大多數播放設定會保持不變。

**修剪會改變簡報中儲存的音訊資料嗎？**

不會。修剪僅調整播放的起迄範圍，原始音訊位元組保持不變，仍可透過嵌入式音訊或簡報的音訊集合存取。