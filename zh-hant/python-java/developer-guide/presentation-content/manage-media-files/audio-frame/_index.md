---
title: 使用 Python 管理簡報中的音訊框架
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
- 擷取音訊
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在投影片中嵌入音訊、更換音訊圖示、設定播放、管理 WebVTT 字幕，並擷取投影片切換音效。"
---
## **概覽**

音訊框架讓您在投影片上播放聲音。使用 Aspose.Slides for Python via Java，您可以嵌入音訊剪輯、選擇代表它的影像、調整播放設定，並附加字幕。您也可以取得指派給投影片切換的聲音。

## **建立音訊框架**

將 `audio.wav` 的位元組加入簡報的音訊集合，然後使用 [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) 在第一張投影片上嵌入本機音訊剪輯。前兩個座標定位框架於投影片上，接下來兩個值設定其寬度與高度，單位均為點。此範例呼叫 [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) 以自動開始播放，並呼叫 [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) 以選擇較大的音量預設。

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

預設情況下，音訊框架會顯示揚聲器圖示。若要顯示自訂縮圖，先使用 [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) 將影像加入簡報，然後使用 [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage) 設定於框架的圖片上。此範例使用 JPEG 作為嵌入音訊剪輯的縮圖。

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

    audio_data = Path("audio.wav").read_bytes()
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

PowerPoint 的 **音訊選項** 控制項決定剪輯何時開始、音量大小，以及在投影片放映期間的行為。

![PowerPoint 音訊框架的音訊選項控制項](audio_frame_0.png)

| PowerPoint 控制項 | Aspose.Slides for Python via Java 方法 |
| --- | --- |
| 開始 | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| 音量預設 | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| 跨投影片播放 | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| 迴圈播放直至停止 | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| 放映時隱藏 | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| 播放完後倒帶 | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| 淡入 | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| 淡出 | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| 修剪音訊開始時間 | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| 修剪音訊結束時間 | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| 音量滑桿 | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

此範例在第一張投影片上找到第一個音訊框架，呼叫 [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) 以點擊時開始播放，並選擇低音量預設。剪輯會跨投影片持續播放，且未啟用迴圈。圖示在放映期間保持隱藏，且剪輯在播放完畢後倒帶。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        # 在點擊時播放，低音量，跨投影片，且不迴圈。
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # 在投影片放映期間隱藏框架，播放完畢後倒帶。
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

對於長度超過 3.5 秒的剪輯，此範例會跳過前 1.5 秒與最後 2 秒。[setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) 接受要從剪輯結尾省略的持續時間。若要取得 PowerPoint 顯示的結束時間，請將此偏移量從完整剪輯長度中減去。修剪後的剪輯會在 200 毫秒內淡入，並在 500 毫秒內淡出。所有四個方法皆以毫秒為單位。

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # 從起始位置裁剪 1.5 秒，從結束位置裁剪 2 秒。
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # 將淡入時間設定為 200 毫秒，淡出時間設定為 500 毫秒。
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

若要將播放音量設定為特定百分比，請使用 [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue)。此範例將第一張投影片上第一個音訊框架的音量設定為 85%。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

## **管理音訊字幕**

每個音訊框架皆可透過 [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks) 取得其字幕軌道。使用此集合可將 WebVTT 字幕附加至剪輯、匯出現有軌道，或移除它們。

### **新增音訊字幕**

此範例在第一張投影片上嵌入音訊剪輯，並使用 [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) 附加本機 WebVTT 軌道。第一個參數提供軌道標籤，第二個參數指定包含計時字幕的檔案。

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # 新增來自 WebVTT 檔案的字幕軌道。
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **擷取音訊字幕**

此範例匯出第一張投影片上音訊框架所附加的每個字幕軌道。它將 [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) 回傳的位元組寫入 WebVTT 檔案，並使用 [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) 回傳的識別碼作為檔名，以便每個軌道都有單獨的輸出。

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
                # 將字幕軌道儲存為 .vtt 檔案。
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **移除音訊字幕**

使用 [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) 刪除單一軌道。此範例使用 [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) 移除第一張投影片上第一個音訊框架的所有字幕，同時保留剪輯。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

### **在音訊字幕中尋找行**

若要在第一張投影片的音訊字幕中尋找特定行，請在記憶體中搜尋 [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) 回傳的文字。於純文字 WebVTT cue 中，計時行包含 `-->`，字幕行緊隨其後，空白行則結束該 cue。此範例列印軌道標籤以及每一行包含「café」的字幕內容。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, AudioFrame):
            continue
        for track in shape.getCaptionTracks():
            in_cue = False
            captions = str(track.getDataAsString())
            for line in captions.splitlines():
                if not line:
                    in_cue = False
                elif "-->" in line:
                    in_cue = True
                elif in_cue and "café" in line.casefold():
                    print(f"{track.getLabel()}: {line}")
finally:
    presentation.dispose()
```

## **擷取音訊**

投影片切換可以有自己的聲音。要取得它，請對投影片切換呼叫 [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound)。此範例存取 [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) 回傳的位元組，並印出位元組數量。如果第一張投影片沒有切換聲音，則會改印出訊息。

```python
import jpice
import asposeslides

if not jpice.isJVMStarted():
    jpice.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print(f"Transition sound: {len(audio_data)} bytes.")
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **常見問題**

**Can I reuse the same audio clip across multiple slides without duplicating it?**

是的。將剪輯一次加入簡報的 [音訊集合](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) 並在每張投影片傳遞相同的音訊物件給 [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded)。

**Can I replace the sound in an existing audio frame?**

是的。對於連結的聲音，使用 [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong) 指向取代檔案。對於嵌入的聲音，使用 [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio) 從簡報的音訊集合中選擇另一個剪輯。兩種方式皆保留現有框架。

**Does trimming change the audio data stored in the presentation?**

不會。[setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) 和 [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) 只設定播放邊界。您仍可透過 [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio) 取得完整的剪輯。