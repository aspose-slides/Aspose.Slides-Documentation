---
title: 使用 Python 管理演示文稿中的音频
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
- 检索音频
- 更改音频
- 播放选项
- 播放模式
- 跨幻灯片播放
- 循环直至停止
- 演示期间隐藏
- 播放后倒带
- 音量
- 默认图片
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "轻松使用 Aspose.Slides for Python via .NET 在 PPT、PPTX 和 ODP 中添加、提取和管理音频帧。探索代码示例，提升您的演示文稿。"
---

## **创建音频帧**

Aspose.Slides for Python via .NET 允许您向幻灯片添加音频文件。音频文件以音频帧的形式嵌入到幻灯片中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 加载要嵌入到幻灯片中的音频文件流。
4. 将嵌入的音频帧（包含音频文件）添加到幻灯片中。
5. 为 [IAudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 对象设置 [PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioplaymodepreset) 和 `Volume`。
6. 保存修改后的演示文稿。

此 Python 代码演示如何向幻灯片添加嵌入的音频帧：
```python
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 将 wav 音频文件加载为流
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

当您向演示文稿添加音频文件时，音频会以带有标准默认图像的帧形式出现（见下节的图像）。您可以更改音频帧的缩略图（设置您喜欢的图像）。

此 Python 代码演示如何更改音频帧的缩略图或预览图像：
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 在幻灯片上添加音频帧，并指定位置和尺寸。
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # 向演示文稿资源添加图像。
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # 设置音频帧的图片。
        audioFrame.picture_format.picture.image = audioImage
        
        #保存修改后的演示文稿到磁盘
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```


## **更改音频播放选项**

Aspose.Slides for Python via .NET 允许您更改控制音频播放或属性的选项。例如，您可以调节音频音量、设置音频循环播放，甚至隐藏音频图标。

Microsoft PowerPoint 中的 **Audio Options** 窗格：

![example1_image](audio_frame_0.png)

PowerPoint **音频选项** 与 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 属性对应：

- **开始** 下拉列表对应 [AudioFrame.play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) 属性
- **音量** 对应 [AudioFrame.volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) 属性
- **跨幻灯片播放** 对应 [AudioFrame.play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) 属性
- **循环直到停止** 对应 [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) 属性
- **演示期间隐藏** 对应 [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) 属性
- **播放后倒带** 对应 [AudioFrame.rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) 属性

PowerPoint **编辑** 选项与 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 属性对应：

- **淡入** 对应 [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) 属性
- **淡出** 对应 [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) 属性
- **修剪音频开始时间** 对应 [AudioFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) 属性
- **修剪音频结束时间** 的值等于音频时长减去 [AudioFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) 属性的值

PowerPoint **音量控制** 位于音频控制面板上，对应 [AudioFrame.volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) 属性。它允许您以百分比方式更改音频音量。

以下是更改音频播放选项的步骤：

1. [创建](#create-audio-frame) 或获取音频帧。
2. 为需要调整的音频帧属性设置新值。
3. 保存修改后的 PowerPoint 文件。

此 Python 代码演示调整音频选项的操作：
```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # 获取 AudioFrame 形状
    audioFrame = pres.slides[0].shapes[0]

    # 将播放模式设置为单击播放
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # 将音量设置为低
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # 设置音频跨幻灯片播放
    audioFrame.play_across_slides = True

    # 禁用音频循环
    audioFrame.play_loop_mode = False

    # 在幻灯片放映期间隐藏 AudioFrame
    audioFrame.hide_at_showing = True

    # 播放后将音频倒带至开始
    audioFrame.rewind_audio = True

    # 将 PowerPoint 文件保存到磁盘
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```


此 Python 示例展示如何添加带有嵌入音频的新音频帧、进行修剪并设置淡入淡出时长：
```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # 将修剪起始偏移设置为 1.5 秒
    # 将修剪结束偏移设置为 2 秒
    # 将淡入时长设置为 200 毫秒
    # 将淡出时长设置为 500 毫秒

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```


以下代码示例展示如何检索带嵌入音频的音频帧并将其音量设置为 85%：
```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # 获取音频帧形状
    audio_frame = pres.slides[0].shapes[0]

    # 将音频音量设置为 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```


## **提取音频**
Aspose.Slides for Python via .NET 允许您提取幻灯片切换时使用的声音。例如，您可以提取特定幻灯片使用的声音。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载包含音频的演示文稿。
2. 通过索引获取相关幻灯片的引用。
3. 访问该幻灯片的幻灯片切换设置。
4. 将声音提取为字节数据。

此 Python 代码演示如何提取幻灯片中使用的音频：
```python
import aspose.slides as slides

# 使用 slides.Presentation("AudioSlide.pptx") 作为 pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # 访问所需的幻灯片
    slide = pres.slides[0]  

    # 获取幻灯片的幻灯片放映过渡效果
    transition = slide.slide_show_transition

    # 提取字节数组中的声音
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```


## **常见问题**

**我可以在多个幻灯片间复用同一音频资源而不增加文件大小吗？**

可以。将音频一次性添加到演示文稿的共享 [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) 中，然后创建引用该已有资源的额外音频帧。这样可避免媒体数据重复，从而保持演示文稿体积可控。

**我可以在不重新创建形状的情况下替换现有音频帧中的声音吗？**

可以。对于链接的声音，更新 [link path](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) 以指向新文件。对于嵌入的声音，交换 [embedded audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) 对象为演示文稿的另一项 [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) 中的音频。帧的格式和大多数播放设置保持不变。

**修剪会改变演示文稿中存储的底层音频数据吗？**

不会。修剪仅调整播放边界。原始音频字节保持不变，可通过嵌入的音频或演示文稿的音频集合继续访问。