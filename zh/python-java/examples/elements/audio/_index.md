---
title: 音频
type: docs
weight: 70
url: /zh/python-java/examples/elements/audio/
keywords:
- 代码示例
- 音频
- 音频帧
- 添加音频
- 访问音频
- 删除音频
- 音频播放
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 和 OpenDocument 演示文稿中添加、访问、删除并配置音频帧。"
---
本文演示如何嵌入音频帧并使用 **Aspose.Slides for Python via Java** 控制播放。以下示例展示了基本的音频操作。

按照[Installation](/slides/zh/python-java/installation/)中描述的方式安装包。每个示例在启动 JVM 之前导入 `asposeslides`，在 JVM 运行后再导入 API。

## **添加音频帧**

插入一个空的音频帧，以便稍后容纳嵌入的音频数据。

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

    # 创建一个空的音频帧（音频将在稍后嵌入）。
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **访问音频帧**

此代码检索幻灯片上的第一个音频帧。

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

    # 访问幻灯片上的第一个音频帧。
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

## **删除音频帧**

删除先前添加的音频帧。

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

    # 移除音频帧。
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **设置音频播放**

配置音频帧，使其在幻灯片出现时自动播放。

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

    # 幻灯片出现时自动播放。
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```