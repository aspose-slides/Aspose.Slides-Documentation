---
title: 使用 Python 管理演示文稿中的音频帧
linktitle: 音频帧
type: docs
weight: 10
url: /zh/python-java/audio-frame/
keywords:
- 音频
- 音频帧
- 缩略图
- 添加音频
- 音频属性
- 音频选项
- 提取音频
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 将音频嵌入幻灯片、更改音频图标、配置播放、管理 WebVTT 字幕，并提取幻灯片切换声音。"
---
## **概述**

音频帧可让您在幻灯片上播放声音。使用 Aspose.Slides for Python via Java，您可以嵌入音频剪辑，选择代表它的图像，调整播放，并附加字幕。您还可以检索分配给幻灯片切换的声音。

## **创建音频帧**

将 `audio.wav` 的字节添加到演示文稿的音频集合中，然后使用 [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) 在第一张幻灯片上嵌入本地音频剪辑。前两个坐标定位帧在幻灯片上的位置，接下来的两个值设置其宽度和高度，单位均为点。此示例调用 [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) 以自动开始剪辑，并调用 [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) 选择响亮的预设。

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

## **更改音频帧缩略图**

默认情况下，音频帧显示扬声器图标。要显示自定义缩略图，请使用 [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) 将图像添加到演示文稿中，并使用 [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage) 将其设置到帧的图片上。示例使用 JPEG 作为嵌入音频剪辑的缩略图。

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

## **更改音频播放选项**

PowerPoint 的 **音频选项** 控件决定剪辑何时开始、音量大小以及在幻灯片放映期间的行为。

![PowerPoint 音频选项控件（音频帧）](audio_frame_0.png)

| PowerPoint 控件 | Aspose.Slides for Python via Java 方法 |
| --- | --- |
| 开始 | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| 音量预设 | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| 跨幻灯片播放 | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| 循环直到停止 | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| 放映期间隐藏 | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| 播放后倒回 | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| 淡入 | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| 淡出 | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| 剪辑音频开始时间 | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| 剪辑音频结束时间 | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| 音量滑块 | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

此示例在第一张幻灯片上查找第一个音频帧，调用 [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) 以在点击时启动播放，并选择低音量预设。剪辑在幻灯片之间继续播放，且循环已禁用。图标在放映期间保持隐藏，剪辑在播放后倒回。

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        # 单击播放，低音量，跨幻灯片，未循环。
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # 在放映期间隐藏帧，并在播放后倒回。
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

对于时长超过 3.5 秒的剪辑，此示例跳过前 1.5 秒和后 2 秒。 [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) 接收要从剪辑末尾省略的时长。要获取 PowerPoint 中显示的结束时间，请将该偏移量从完整剪辑时长中减去。剪辑在 200 毫秒内淡入，500 毫秒内淡出。所有四个方法的参数单位均为毫秒。

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

    # 从开头裁剪 1.5 秒，末尾裁剪 2 秒。
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # 将淡入设置为 200 毫秒，淡出设置为 500 毫秒。
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

要将播放音量设置为特定百分比，请使用 [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue)。此示例将第一张幻灯片上的第一个音频帧的音量设置为 85%。

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

## **管理音频字幕**

每个音频帧可通过 [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks) 访问其字幕轨道。使用该集合可将 WebVTT 字幕附加到剪辑、导出现有轨道或将其删除。

### **添加音频字幕**

此示例在第一张幻灯片上嵌入音频剪辑，并使用 [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) 将本地 WebVTT 轨道附加。第一个参数提供轨道标签，第二个参数标识包含时间字幕的文件。

```python
from pathlib import Path

import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpile.JArray(jpile.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # 从 WebVTT 文件添加新的字幕轨道。
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **提取音频字幕**

此示例导出附加到第一张幻灯片上音频帧的每个字幕轨道。它将 [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) 返回的字节写入 WebVTT 文件，并使用 [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) 返回的标识符作为文件名，以便每个轨道生成单独的输出。

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
                # 将字幕轨道保存为 .vtt 文件。
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **删除音频字幕**

使用 [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) 删除单个轨道。示例使用 [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) 删除第一张幻灯片上第一个音频帧的所有字幕，同时保留剪辑。

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

### **在音频字幕中查找行**

要在第一张幻灯片的音频字幕中查找行，请在内存中搜索 [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) 返回的文本。在纯文本 WebVTT 提示中，时间行包含 `-->`，字幕行随其之后，空行结束提示。此示例打印轨道标签以及包含 “café” 的每行字幕。

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

## **提取音频**

幻灯片切换可以拥有自己的声音。要检索它，请在幻灯片切换上调用 [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound)。示例访问 [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) 返回的字节并打印字节数。如果第一张幻灯片没有切换声音，则打印相应的提示信息。

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
        print(f"Transition sound: {len(audio_data)} bytes.")
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **常见问题**

**我可以在多个幻灯片之间重复使用相同的音频剪辑而不复制它吗？**

是的。将剪辑一次添加到演示文稿的 [音频集合](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) 中，并为每张幻灯片将相同的音频对象传递给 [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded)。

**我可以替换现有音频帧中的声音吗？**

是的。对于链接的声音，使用 [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong) 指向替换文件。对于嵌入的声音，使用 [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio) 从演示文稿的音频集合中选择另一个剪辑。这两种方法都保留现有的帧。

**裁剪会更改存储在演示文稿中的音频数据吗？**

不会。[setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) 和 [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) 仅设置播放边界。您仍然可以通过 [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio) 检索完整的剪辑。