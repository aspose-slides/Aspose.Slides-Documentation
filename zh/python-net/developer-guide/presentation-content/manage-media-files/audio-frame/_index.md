---
title: 音频帧
type: docs
weight: 10
url: /python-net/audio-frame/
keywords: "添加音频, 音频帧, 音频属性, 提取音频, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中向 PowerPoint 演示文稿添加音频"
---

## **创建音频帧**
Aspose.Slides for Python via .NET 允许您向幻灯片添加音频文件。音频文件作为音频帧嵌入到幻灯片中。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 加载您想要嵌入到幻灯片中的音频文件流。
4. 将嵌入的音频帧（包含音频文件）添加到幻灯片。
5. 设置 [PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioplaymodepreset) 和 [IAudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 对象公开的 `Volume`。
6. 保存修改后的演示文稿。

以下 Python 代码演示如何向幻灯片添加嵌入的音频帧：

```python
import aspose.slides as slides

# 实例化表示演示文稿文件的演示文稿类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 加载 wav 音频文件到流
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

当您向演示文稿添加音频文件时，音频会显示为带有标准默认图像的帧（请参阅下面部分的图像）。您可以更改音频帧的缩略图（设置您喜欢的图像）。

以下 Python 代码演示如何更改音频帧的缩略图或预览图像：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 向幻灯片添加具有指定位置和大小的音频帧
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # 将图像添加到演示文稿资源中
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # 设置音频帧的图像
        audioFrame.picture_format.picture.image = audioImage
        
        # 将修改后的演示文稿保存到磁盘
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **更改音频播放选项**

Aspose.Slides for Python via .NET 允许您更改控制音频播放或属性的选项。例如，您可以调整音频的音量，设置音频循环播放，甚至隐藏音频图标。

Microsoft PowerPoint 中的 **音频选项** 窗格：

![example1_image](audio_frame_0.png)

PowerPoint 音频选项与 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 属性对应：
- 音频选项 **开始** 下拉列表对应于 [AudioFrame.PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 属性 
- 音频选项 **音量** 对应于 [AudioFrame.Volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 属性 
- 音频选项 **跨幻灯片播放** 对应于 [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 属性 
- 音频选项 **循环播放直到停止** 对应于 [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 属性 
- 音频选项 **在放映期间隐藏** 对应于 [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 属性 
- 音频选项 **播放后倒带** 对应于 [AudioFrame.RewindAudio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) 属性 

这是如何更改音频播放选项：

1. [创建](#create-audio-frame)或获取音频帧。
2. 设置您希望调整的音频帧属性的新值。
3. 保存修改后的 PowerPoint 文件。

以下 Python 代码演示如何调整音频选项：

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # 获取 AudioFrame 形状
    audioFrame = pres.slides[0].shapes[0]

    # 设置播放模式为点击时播放
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # 设置音量为低
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # 设置音频跨幻灯片播放
    audioFrame.play_across_slides = True

    # 禁用音频循环播放
    audioFrame.play_loop_mode = False

    # 在幻灯片放映期间隐藏 AudioFrame
    audioFrame.hide_at_showing = True

    # 播放后倒带音频
    audioFrame.rewind_audio = True

    # 将 PowerPoint 文件保存到磁盘
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **提取音频**
Aspose.Slides for Python via .NET 允许您提取用于幻灯片放映过渡的声音。例如，您可以提取特定幻灯片中使用的声音。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载包含音频的演示文稿。
2. 通过索引获取相关幻灯片的引用。
3. 访问幻灯片的放映过渡。
4. 以字节数据提取声音。

以下 Python 代码演示如何提取幻灯片中使用的音频：

```python
import aspose.slides as slides

# with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # 访问所需幻灯片
    slide = pres.slides[0]  

    # 获取幻灯片的放映过渡效果
    transition = slide.slide_show_transition

    # 提取字节数组中的声音
    audio = transition.sound.binary_data

    print("长度: " + str(len(audio)))
```