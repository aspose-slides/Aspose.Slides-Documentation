---
title: 使用 Python 在簡報中管理音訊
linktitle: 音訊框
type: docs
weight: 10
url: /zh-hant/python-java/audio-frame/
keywords:
- 音訊
- 音訊框
- 縮圖
- 新增音訊
- 音訊屬性
- 音訊選項
- 提取音訊
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中建立與控制音訊框——提供嵌入、修剪、循環以及在 PPT、PPTX 與 ODP 簡報中設定播放的程式碼範例。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用音訊框架。它展示了如何將嵌入式音訊加入投影片、客製化音訊框的縮圖、設定播放選項（例如音量、迴圈、隱藏、修剪和淡入淡出持續時間），以及提取投影片放映過程中使用的音訊。

## **建立音訊框架**

Aspose.Slides for Python via Java 允許您將音訊檔案新增至投影片。音訊檔案會以音訊框的形式嵌入投影片中。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得投影片的參考。
3. 讀取想要嵌入投影片的音訊檔案。
4. 將嵌入式音訊框（包含音訊檔案）新增至投影片。
5. 設定由 [AudioFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/) 物件所公開的 [setPlayMode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setPlayMode) 與 [setVolume](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setVolume)。
6. 保存已修改的簡報。

以下 Python 程式碼示範如何將嵌入式音訊框新增至投影片：

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

## **變更音訊框縮圖**

當您將音訊檔案加入簡報時，音訊會以具有標準預設圖片的框架顯示（請參考下方圖片）。您可以變更音訊框的預覽圖片（設定您偏好的圖片）。

以下 Python 程式碼示範如何變更音訊框的縮圖或預覽圖片：

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

Aspose.Slides for Python via Java 允許您變更控制音訊播放或屬性的選項。例如，您可以調整音訊的音量、設定音訊循環播放，甚至隱藏音訊圖示。

Microsoft PowerPoint 中的 **Audio Options** 面板：

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** 與 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/) 屬性對應如下：

- **Start** 下拉式清單對應 [setPlayMode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setPlayMode) 方法
- **Volume** 對應 [setVolume](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setVolume) 方法
- **Play Across Slides** 對應 [setPlayAcrossSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) 方法
- **Loop until Stopped** 對應 [setPlayLoopMode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setPlayLoopMode) 方法
- **Hide During Show** 對應 [setHideAtShowing](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setHideAtShowing) 方法
- **Rewind after Playing** 對應 [setRewindAudio](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setRewindAudio) 方法

PowerPoint **Editing** 選項與 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/) 屬性對應如下：

- **Fade In** 對應 [setFadeInDuration](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setFadeInDuration) 方法
- **Fade Out** 對應 [setFadeOutDuration](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setFadeOutDuration) 方法
- **Trim Audio Start Time** 對應 [setTrimFromStart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setTrimFromStart) 方法
- **Trim Audio End Time** 值等於音訊持續時間減去 [setTrimFromEnd](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setTrimFromEnd) 方法的值

PowerPoint 音訊控制面板上的 **Volume control** 對應 [setVolumeValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setVolumeValue) 方法。它允許您以百分比調整音訊音量。

以下說明如何變更音訊播放選項：

1. [建立](#create-audio-frames) 或取得音訊框。
2. 設定您想調整的音訊框屬性的新值。
3. 保存已修改的 PowerPoint 檔案。

以下 Python 程式碼示範調整音訊選項的操作：

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

以下 Python 範例展示如何新增帶有嵌入式音訊的音訊框、修剪音訊以及設定淡入淡出持續時間：

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

    # 從開頭修剪 1.5 秒，從結尾修剪 2 秒。
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # 設定淡入 200 毫秒，淡出 500 毫秒。
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

以下程式碼範例展示如何取得帶有嵌入式音訊的音訊框，並將其音量設定為 85%：

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

Aspose.Slides 允許您透過 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#getCaptionTracks) 方法為音訊框加入隱藏式字幕。此方法會回傳一個 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captionscollection/)，讓您新增 WebVTT 字幕軌、遍歷現有軌道，並在需要時移除它們。

**新增音訊字幕**

使用 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#getCaptionTracks) 方法將一個或多個字幕軌附加至音訊框。以下範例先將音訊檔加入投影片，接著從 `.vtt` 檔載入新的字幕軌。

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

    # 從 WebVTT 檔案新增字幕軌跡。
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**提取音訊字幕**

您可以遍歷與音訊框相關的字幕軌，並將它們保存為 `.vtt` 檔案。每個字幕軌會公開其二進位資料和唯一識別碼，可在匯出字幕時使用。

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
                # 將字幕軌儲存為 .vtt 檔案。
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**移除音訊字幕**

若要從音訊框移除字幕，可使用 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captionscollection/) 提供的方法，例如 [clear](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captionscollection/#clear)、[remove](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captionscollection/#removeAt)。以下範例會移除音訊框中的所有字幕軌。

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

Aspose.Slides for Python via Java 允許您提取投影片放映過渡時使用的音效。例如，您可以提取特定投影片使用的音效。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例，並載入包含音訊的簡報。
2. 透過索引取得相關投影片的參考。
3. 存取該投影片的 [slideshow transitions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/#getSlideShowTransition)。
4. 將音效以位元組資料形式提取出來。

以下 Python 程式碼示範如何提取投影片中使用的音訊：

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

## **常見問題**

**我可以在多張投影片之間重複使用相同的音訊資產而不增加檔案大小嗎？**

是的。僅將音訊一次加入簡報的共享 [audio collection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getAudios)，然後建立引用該資產的其他音訊框。這樣可避免重複媒體資料，保持簡報大小受控。

**我可以在不重新建立形狀的情況下取代現有音訊框的音效嗎？**

是的。對於連結式音效，請更新 [link path](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setLinkPathLong) 以指向新檔案。對於嵌入式音效，請以簡報的另一個 [audio collection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getAudios) 中的音訊取代 [embedded audio](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/#setEmbeddedAudio) 物件。音訊框的格式與大部分播放設定會保持不變。

**修剪會改變簡報中儲存的底層音訊資料嗎？**

不會。修剪僅調整播放範圍，原始音訊位元組保持不變，仍可透過嵌入式音訊或簡報的 audio collection 存取。