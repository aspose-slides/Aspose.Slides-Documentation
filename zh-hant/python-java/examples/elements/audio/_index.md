---
title: 音訊
type: docs
weight: 70
url: /zh-hant/python-java/examples/elements/audio/
keywords:
- 程式碼範例
- 音訊
- 音訊框架
- 新增音訊
- 存取音訊
- 移除音訊
- 音訊播放
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 與 OpenDocument 簡報中新增、存取、移除及設定音訊框架。"
---
本文示範如何在 **Aspose.Slides for Python via Java** 中嵌入音訊框架並控制播放。以下範例展示基本的音訊操作。

安裝套件請參考[Installation](/slides/zh-hant/python-java/installation/)。每個範例在啟動 JVM 之前先匯入 `asposeslides`，然後在 JVM 运行后匯入 API。

## **Add an Audio Frame**
插入一個空的音訊框架，以便稍後存放嵌入的聲音資料。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)

    # 建立一個空的音訊框架（音訊稍後會嵌入）。
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **Access an Audio Frame**
此程式碼會取得投影片上的第一個音訊框架。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # 存取投影片上的第一個音訊框架。
    first_audio = None
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            first_audio = shape
            break

    if first_audio is None:
        print("The slide contains no audio frames.")
finally:
    presentation.dispose()
```

## **Remove an Audio Frame**
刪除先前新增的音訊框架。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # 移除音訊框架。
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **Set Audio Playback**
設定音訊框架在投影片出現時自動播放。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioPlayModePreset, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # 投影片出現時自動播放。
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```