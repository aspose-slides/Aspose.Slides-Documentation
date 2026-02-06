---
title: 视频
type: docs
weight: 80
url: /zh/python-net/examples/elements/video/
keywords:
- 视频
- 视频帧
- 添加视频
- 访问视频
- 删除视频
- 视频播放
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中处理视频：插入、替换、裁剪、设置海报帧和播放选项，并将演示文稿导出为 PPT、PPTX 和 ODP。"
---
展示如何使用 **Aspose.Slides for Python via .NET** 嵌入视频帧并设置播放选项。

## **添加视频帧**

在幻灯片上插入一个空的视频帧。

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 添加视频帧。
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **访问视频帧**

检索添加到幻灯片的第一个视频帧。

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # 访问幻灯片上的第一个视频帧。
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **移除视频帧**

从幻灯片中删除视频帧。

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是视频帧。
        video_frame = slide.shapes[0]

        # 删除视频帧。
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **设置视频播放**

配置视频在幻灯片显示时自动播放。

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是视频帧。
        video_frame = slide.shapes[0]

        # 将视频配置为自动播放。
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```