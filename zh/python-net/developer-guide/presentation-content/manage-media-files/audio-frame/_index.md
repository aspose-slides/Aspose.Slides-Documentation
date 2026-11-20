---
title: 在演示文稿中使用 Python 管理音频帧
linktitle: 音频帧
type: docs
weight: 10
url: /zh/python-net/audio-frame/
keywords:
- 音频
- 音频帧
- 缩略图
- 添加音频
- 音频属性
- 音频选项
- 提取音频
- WebVTT
- Python
- Aspose.Slides
description: "在幻灯片中嵌入音频、更改音频图标、配置播放、管理 WebVTT 字幕，并使用 Aspose.Slides for Python via .NET 提取幻灯片切换声音。"
---
## **概述**

音频帧允许您在幻灯片上播放声音。使用 Aspose.Slides for Python via .NET，您可以嵌入音频剪辑，选择代表它的图像，调整播放设置，并附加字幕。您还可以检索分配给幻灯片切换的声音。

## **创建音频帧**

使用 [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) 在第一张幻灯片上嵌入本地音频剪辑。前两个坐标定位帧在幻灯片上的位置，接下来的两个值设置其宽度和高度，全部以点为单位。本示例将 [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) 设置为自动启动剪辑，并将 [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) 设置为响亮预设。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 150, 100, 100, audio_stream)
    audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
    audio_frame.volume = slides.AudioVolumeMode.LOUD

    presentation.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```
## **更改音频帧缩略图**

默认情况下，音频帧显示扬声器图标。要显示自定义缩略图，请使用 [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) 将图像添加到演示文稿，并将其分配给帧的 [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) 属性。示例使用 JPEG 作为嵌入音频剪辑的缩略图。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("eagle.jpeg", "rb") as image_stream:
        thumbnail = presentation.images.add_image(image_stream)

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_stream)
    audio_frame.picture_format.picture.image = thumbnail

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```
## **更改音频播放选项**

PowerPoint 的 **Audio Options** 控件决定剪辑何时开始、音量大小以及在幻灯片放映期间的行为。

![PowerPoint 音频选项控件用于音频帧](audio_frame_0.png)

| PowerPoint 控件 | Aspose.Slides 属性 |
| --- | --- |
| 开始 | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| 音量预设 | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| 跨幻灯片播放 | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| 循环直到停止 | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| 演示期间隐藏 | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| 播放后倒带 | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| 淡入 | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| 淡出 | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| 修剪音频开始时间 | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| 修剪音频结束时间 | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| 音量滑块 | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

示例在第一张幻灯片上找到第一个音频帧，将 [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) 设置为单击时开始播放，并选择低音量预设。剪辑在跨幻灯片播放时保持循环关闭。图标在演示期间保持隐藏，剪辑在播放后倒带。

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.play_mode = slides.AudioPlayModePreset.ON_CLICK
        audio_frame.volume = slides.AudioVolumeMode.LOW
        audio_frame.play_across_slides = True
        audio_frame.play_loop_mode = False
        audio_frame.hide_at_showing = True
        audio_frame.rewind_audio = True
        
        presentation.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

对于时长超过 3.5 秒的剪辑，本示例跳过前 1.5 秒和后 2 秒。[trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) 测量要从剪辑结尾省略的时长。要获取 PowerPoint 中显示的结束时间，请将该偏移量从完整剪辑时长中减去。修剪后的剪辑在 200 毫秒内淡入，在 500 毫秒内淡出。所有四个属性的取值均为毫秒。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)
    audio_frame.trim_from_start = 1500.0
    audio_frame.trim_from_end = 2000.0
    audio_frame.fade_in_duration = 200.0
    audio_frame.fade_out_duration = 500.0

    presentation.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

要将播放音量设置为特定百分比，请使用 [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/)。本示例将第一张幻灯片上的第一个音频帧音量设置为 85%。

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.volume_value = 85.0
        presentation.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```
## **管理音频字幕**

每个音频帧都有一个 [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/) 集合。可使用它为剪辑附加 WebVTT 字幕、导出现有轨道或将其移除。

### **添加音频字幕**

示例在第一张幻灯片上嵌入音频剪辑，并使用 [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) 将本地 WebVTT 轨道附加。第一个参数提供轨道标签，第二个参数指定包含时间字幕的文件。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```
### **提取音频字幕**

本示例导出附加在第一张幻灯片的音频帧上的每个字幕轨道。它将轨道的 [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) 写入 WebVTT 文件，并使用其 [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) 作为文件名，以便每个轨道都有单独的输出。

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                with open(f"{track.caption_id}.vtt", "wb") as output:
                    output.write(track.binary_data)
```
### **移除音频字幕**

使用 [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) 或 [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) 删除单个轨道。示例使用 [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) 从第一张幻灯片的第一个音频帧中移除所有字幕，同时保留剪辑。

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.caption_tracks.clear()
        presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```
### **在音频字幕中查找行**

要在第一张幻灯片的音频字幕中查找行，请在内存中读取每个轨道的 [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/)。在纯文本 WebVTT 提示中，时间行包含 `-->`，字幕行随后出现，空行结束提示。此示例打印轨道标签以及包含 “café” 的每个字幕行。

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                in_cue = False
                for line in track.data_as_string.splitlines():
                    if not line:
                        in_cue = False
                    elif "-->" in line:
                        in_cue = True
                    elif in_cue and "café" in line.casefold():
                        print(f"{track.label}: {line}")
```
## **提取音频**

幻灯片切换可以拥有自己的声音。要检索它，请读取切换的 [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) 属性。示例访问声音的 [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) 并打印其字节大小。如果第一张幻灯片没有切换声音，则会打印一条消息。

```python
import aspose.slides as slides

with slides.Presentation("AudioSlide.pptx") as presentation:
    slide = presentation.slides[0]

    sound = slide.slide_show_transition.sound
    if sound is None:
        print("The first slide has no transition sound.")
    else:
        audio_data = sound.binary_data
        print(f"Transition sound: {len(audio_data)} bytes.")
```
## **常见问题**

**我可以在多个幻灯片之间重复使用相同的音频剪辑，而不进行复制吗？**

是的。将剪辑一次添加到演示文稿的 [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) 中，然后对每张幻灯片将相同的音频对象传递给 [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/)。

**我可以替换现有音频帧中的声音吗？**

是的。对于链接的声音，更新 [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) 以指向替换文件。对于嵌入的声音，将演示文稿音频集合中的另一个剪辑分配给 [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/)。这两种方法都保留了现有帧。

**修剪会更改存储在演示文稿中的音频数据吗？**

不会。[trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) 和 [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) 设置播放边界。您仍然可以从 [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) 检索完整剪辑。