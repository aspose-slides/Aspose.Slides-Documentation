---
title: 音频
type: docs
weight: 70
url: /zh/python-net/examples/elements/audio/
keywords:
- 音频
- 音频帧
- 添加音频
- 访问音频
- 删除音频
- 音频播放
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中处理音频：添加、替换、提取和修剪声音，为 PowerPoint 和 OpenDocument 中的幻灯片和形状设置音量和播放。"
---
演示如何嵌入音频帧并使用 **Aspose.Slides for Python via .NET** 控制播放。以下示例展示了基本的音频操作。

## **添加音频帧**

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **访问音频帧**

```py
def access_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        first_audio_frame = None
        for shape in slide.shapes:
            if isinstance(shape, slides.AudioFrame):
                first_audio_frame = shape
                break
```

## **删除音频帧**

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是 AudioFrame。
        audio_frame = slide.shapes[0]

        # 删除音频帧。
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **设置音频播放**

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是 AudioFrame。
        audio_frame = slide.shapes[0]

        # 当幻灯片出现时自动播放。
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```