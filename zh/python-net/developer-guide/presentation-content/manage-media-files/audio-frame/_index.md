---
title: 在演示文稿中使用 Python 管理音频
linktitle: 音频帧
type: docs
weight: 10
url: /zh/python-net/audio-frame/
keywords:
- 添加音频
- 嵌入音频
- 音频帧
- 音频文件
- 音频属性
- 提取音频
- 获取音频
- 更改音频
- 播放选项
- 播放模式
- 跨幻灯片播放
- 循环播放直至停止
- 演示期间隐藏
- 播放后倒带
- 音频音量
- 默认图像
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "轻松在 PPT、PPTX 和 ODP 中使用 Aspose.Slides for Python via .NET 添加、提取和管理音频帧。探索代码示例，提升您的演示文稿。"
---
## **创建音频帧**

Aspose.Slides for Python via .NET 允许您向幻灯片添加音频文件。音频文件以音频帧的形式嵌入到幻灯片中。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 加载您想要嵌入到幻灯片中的音频文件流。
4. 将嵌入的音频帧（包含音频文件）添加到幻灯片中。
5. 设置由 [IAudioFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/) 对象公开的 [PlayMode](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioplaymodepreset) 和 `Volume`。
6. 保存修改后的演示文稿。

下面的 Python 代码演示了如何向幻灯片添加嵌入的音频帧：

```python
import aspose.slides as slides

# 实例化一个表示演示文件的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 加载 wav 声音文件为流
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # 添加音频帧
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # 设置音频的播放模式和音量
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # 将 PowerPoint 文件写入磁盘
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **更改音频帧缩略图**

当您向演示文稿添加音频文件时，音频会显示为带有标准默认图像的帧（请参见下面章节中的图像）。您可以更改音频帧的缩略图（设置您喜欢的图像）。

下面的 Python 代码演示了如何更改音频帧的缩略图或预览图像：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 在幻灯片上添加音频帧，指定位置和大小。
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # 向演示文稿资源添加图像。
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # 为音频帧设置图像。
        audioFrame.picture_format.picture.image = audioImage
        
        #保存修改后的演示文稿到磁盘
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **更改音频播放选项**

Aspose.Slides for Python via .NET 允许您更改控制音频播放或属性的选项。例如，您可以调节音频音量、设置音频循环播放，甚至隐藏音频图标。

Microsoft PowerPoint 中的 **Audio Options** 面板：

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** 对应于 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/) 属性：

- **Start** 下拉列表对应 [AudioFrame.play_mode](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/play_mode/) 属性
- **Volume** 对应 [AudioFrame.volume](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/volume/) 属性
- **Play Across Slides** 对应 [AudioFrame.play_across_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/play_across_slides/) 属性
- **Loop until Stopped** 对应 [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/play_loop_mode/) 属性
- **Hide During Show** 对应 [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/hide_at_showing/) 属性
- **Rewind after Playing** 对应 [AudioFrame.rewind_audio](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/rewind_audio/) 属性

PowerPoint **Editing** 选项对应于 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/) 属性：

- **Fade In** 对应 [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/fade_in_duration/) 属性
- **Fade Out** 对应 [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/fade_out_duration/) 属性
- **Trim Audio Start Time** 对应 [AudioFrame.trim_from_start](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/trim_from_start/) 属性
- **Trim Audio End Time** 的值等于音频时长减去 [AudioFrame.trim_from_end](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/trim_from_end/) 属性的值

PowerPoint 音频控制面板上的 **Volume controll** 对应于 [AudioFrame.volume_value](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/volume_value/) 属性。它允许您以百分比方式更改音频音量。

以下是更改音频播放选项的方法：

1. [Сreate](#create-audio-frame) 或获取音频帧。
2. 为您想要调整的音频帧属性设置新值。
3. 保存修改后的 PowerPoint 文件。

下面的 Python 代码演示了调整音频选项的操作：

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # 获取 AudioFrame 形状
    audioFrame = pres.slides[0].shapes[0]

    # 设置播放模式为单击播放
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # 设置音量为低
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # 设置音频跨幻灯片播放
    audioFrame.play_across_slides = True

    # 禁用音频循环
    audioFrame.play_loop_mode = False

    # 幻灯片放映期间隐藏 AudioFrame
    audioFrame.hide_at_showing = True

    # 播放后将音频倒回到起点
    audioFrame.rewind_audio = True

    # 将 PowerPoint 文件保存到磁盘
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

下面的 Python 示例展示了如何添加带嵌入音频的新音频帧、进行剪辑并设置淡入淡出持续时间：

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # 设置剪辑起始偏移为 1.5 秒
    audio_frame.trim_from_start = 1500.0
    # 设置剪辑结束偏移为 2 秒
    audio_frame.trim_from_end = 2000.0

    # 设置淡入持续时间为 200 毫秒
    audio_frame.fade_in_duration = 200.0
    # 设置淡出持续时间为 500 毫秒
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

下面的代码示例展示了如何检索带嵌入音频的音频帧并将其音量设置为 85%：

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # 获取音频帧形状
    audio_frame = pres.slides[0].shapes[0]

    # 将音频音量设置为 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **管理音频字幕**

Aspose.Slides 允许您通过 [caption_tracks](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/caption_tracks/) 属性向音频帧添加闭合字幕。该属性返回一个 [CaptionsCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captionscollection/)，您可以使用它添加 WebVTT 字幕轨道、遍历现有轨道，并在需要时将其移除。

**添加音频字幕**

使用 [caption_tracks](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/caption_tracks/) 属性将一个或多个字幕轨道附加到音频帧。在下面的示例中，先向幻灯片添加音频文件，然后从 `.vtt` 文件加载新字幕轨道。

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # 添加一个来自 WebVTT 文件的新字幕轨道。
    audio_frame.caption_tracks.add("New track", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**提取音频字幕**

您可以遍历与音频帧关联的字幕轨道并将其保存为 `.vtt` 文件。每个字幕轨道都公开其二进制数据和唯一标识符，可在导出字幕时使用。

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # 将字幕轨道保存为 .vtt 文件。
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**移除音频字幕**

要从音频帧中移除字幕，请使用 [CaptionsCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captionscollection/) 提供的方法，例如 [clear](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captionscollection/clear/)、[remove](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captionscollection/remove/) 或 [remove_at](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captionscollection/remove_at/)。下面的示例从音频帧中移除所有字幕轨道。

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # 类型: slides.AudioFrame

    # 删除音频帧中的所有字幕轨道。
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **提取音频**

Aspose.Slides for Python via .NET 允许您提取幻灯片放映过渡时使用的声音。例如，您可以提取特定幻灯片使用的声音。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例并加载包含音频的演示文稿。
2. 通过索引获取相关幻灯片的引用。
3. 获取该幻灯片的幻灯片放映过渡。
4. 将声音提取为字节数据。

下面的 Python 代码演示了如何提取幻灯片中使用的音频：

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # 访问所需的幻灯片
    slide = pres.slides[0]  

    # 获取幻灯片的幻灯片放映过渡效果
    transition = slide.slide_show_transition

    # 提取声音的字节数组
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **常见问题**

**我可以在多个幻灯片中重用相同的音频资源而不会增加文件大小吗？**

可以。将音频一次性添加到演示文稿的共享 [audio collection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/audios/) 中，然后创建引用该已有资产的其他音频帧。这样可避免复制媒体数据，并保持演示文稿的大小在可控范围内。

**我可以在不重新创建形状的情况下替换现有音频帧的声音吗？**

可以。对于链接的声音，更新 [link path](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/link_path_long/) 以指向新文件。对于嵌入的声音，将 [embedded audio](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/embedded_audio/) 对象替换为演示文稿的 [audio collection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/audios/) 中的其他音频。帧的格式和大多数播放设置保持不变。

**剪辑会改变演示文稿中存储的底层音频数据吗？**

不会。剪辑仅调整播放边界。原始音频字节保持不变，仍可通过嵌入音频或演示文稿的音频集合访问。