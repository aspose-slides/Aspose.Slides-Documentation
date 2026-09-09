---
title: 使用 Python 管理演示文稿中的音频
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
description: "在 Aspose.Slides for Python via Java 中创建和控制音频帧——提供嵌入、修剪、循环以及在 PPT、PPTX 和 ODP 演示文稿中配置播放的代码示例。"
---
## **概述**

本文介绍了如何在 Aspose.Slides 中使用音频帧。它展示了如何将嵌入式音频添加到幻灯片、定制音频帧缩略图、配置播放选项（例如音量、循环、隐藏、修剪和淡入淡出时长），以及提取幻灯片放映过渡中使用的音频。

## **创建音频帧**

Aspose.Slides for Python via Java 允许您向幻灯片添加音频文件。音频文件以音频帧的形式嵌入幻灯片中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 读取要嵌入到幻灯片的音频文件。
4. 将嵌入式音频帧（包含音频文件）添加到幻灯片。
5. 使用由 [AudioFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/) 对象公开的 [setPlayMode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/#setPlayMode) 和 [setVolume](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/#setVolume)。
6. 保存修改后的演示文稿。

以下 Python 代码演示了如何向幻灯片添加嵌入式音频帧：

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

向演示文稿添加音频文件后，音频会以带有默认标准图像的帧形式显示（见下节图片）。您可以将音频帧的预览图像更改为自定义图像。

以下 Python 代码演示了如何更改音频帧的缩略图或预览图像：

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

## **更改音频播放选项**

Aspose.Slides for Python via Java 允许您更改控制音频播放的选项或属性。例如，您可以调节音量、设置循环播放，甚至隐藏音频图标。

Microsoft PowerPoint 中的 **Audio Options** 面板：

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** 对应 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/) 属性：

- **Start** 下拉列表对应 [setPlayMode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/#setPlayMode) 方法
- **Volume** 对应 [setVolume](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/#setVolume) 方法
- **Play Across Slides** 对应 [setPlayAcrossSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) 方法
- **Loop until Stopped** 对应 [setPlayLoopMode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/#setPlayLoopMode) 方法
- **Hide During Show** 对应 [setHideAtShowing](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/#setHideAtShowing) 方法
- **Rewind after Playing** 对应 [setRewindAudio](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/#setRewindAudio) 方法

PowerPoint **Editing** 选项对应 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/) 属性：

- **Fade In** 对应 [setFadeInDuration](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/#setFadeInDuration) 方法
- **Fade Out** 对应 [setFadeOutDuration](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/#setFadeOutDuration) 方法
- **Trim Audio Start Time** 对应 [setTrimFromStart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/#setTrimFromStart) 方法
- **Trim Audio End Time** 的数值等于音频时长减去由 [setTrimFromEnd](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/#setTrimFromEnd) 方法设置的值

PowerPoint 音频控制面板上的 **Volume control** 对应 [setVolumeValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/#setVolumeValue) 方法，可将音量按百分比进行调节。

以下是更改音频播放选项的步骤：

1. 【创建】(#create-audio-frames) 或获取音频帧。
2. 为需要调整的音频帧属性设置新值。
3. 保存修改后的 PowerPoint 文件。

下面的 Python 代码演示了调整音频选项的操作：

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
        # 单击播放，音量低，跨幻灯片播放，不循环。
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # 在放映期间隐藏帧，播放后倒回。
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

以下 Python 示例展示了如何添加带嵌入式音频的新音频帧、修剪它并设置淡入淡出时长：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpime.JArray(jpime.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # 从开头修剪 1.5 秒，末尾修剪 2 秒。
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # 将淡入设置为 200 毫秒，淡出设置为 500 毫秒。
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

下面的代码示例展示了如何获取带嵌入式音频的音频帧并将其音量设置为 85%：

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

## **管理音频字幕**

Aspose.Slides 允许您通过 [getCaptionTracks](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/#getCaptionTracks) 方法为音频帧添加闭合字幕。该方法返回一个 [CaptionsCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/)，您可以向其中添加 WebVTT 字幕轨道、遍历已有轨道，并在需要时将其移除。

**添加音频字幕**

使用 [getCaptionTracks](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/#getCaptionTracks) 方法将一个或多个字幕轨道附加到音频帧。下面的示例中，先向幻灯片添加音频文件，然后从 `.vtt` 文件加载新的字幕轨道。

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

    # 从 WebVTT 文件添加新的字幕轨道。
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**提取音频字幕**

您可以遍历音频帧关联的字幕轨道并将其保存为 `.vtt` 文件。每个字幕轨道都会公开其二进制数据和唯一标识符，可在导出字幕时使用。

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
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**移除音频字幕**

要从音频帧中移除字幕，请使用 [CaptionsCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/) 提供的方法，如 [clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/#clear)、[remove](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/#removeAt)。下面的示例演示了如何删除音频帧中的所有字幕轨道。

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

## **提取音频**

Aspose.Slides for Python via Java 允许您提取幻灯片放映过渡中使用的声音。例如，您可以提取特定幻灯片使用的声音。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例并加载包含音频的演示文稿。
2. 通过索引获取相关幻灯片的引用。
3. 访问该幻灯片的 [slideshow transitions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/#getSlideShowTransition)。
4. 将声音提取为字节数据。

下面的 Python 代码演示了如何提取幻灯片中使用的音频：

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

## **常见问题**

**我可以在多个幻灯片之间重复使用同一音频资源而不会增大文件大小吗？**

可以。将音频一次添加到演示文稿的共享 [audio collection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getAudios)，然后创建引用该已有资源的额外音频帧。这样可以避免复制媒体数据，保持演示文稿大小在可控范围内。

**我可以在不重新创建形状的情况下替换已有音频帧中的声音吗？**

可以。对于链接的声音，更新 [link path](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/#setLinkPathLong) 以指向新文件。对于嵌入式声音，将 [embedded audio](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/#setEmbeddedAudio) 对象替换为演示文稿的 [audio collection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getAudios) 中的另一个对象。帧的格式和大多数播放设置保持不变。

**修剪会改变演示文稿中存储的底层音频数据吗？**

不会。修剪仅调整播放边界。原始音频字节保持不变，仍可通过嵌入式音频或演示文稿的音频集合访问。