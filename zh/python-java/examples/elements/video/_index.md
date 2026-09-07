---
title: 视频
type: docs
weight: 80
url: /zh/python-java/examples/elements/video/
keywords:
- 代码示例
- 视频
- 视频帧
- 添加视频
- 访问视频
- 删除视频
- 视频播放
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 和 OpenDocument 演示文稿中添加、访问、删除和配置视频帧。"
---
这篇文章演示了如何使用 **Aspose.Slides for Python via Java** 添加视频帧并设置播放选项。

按照[Installation](/slides/zh/python-java/installation/)中的描述安装包。每个示例在启动 JVM 之前导入 `asposeslides`，随后在 JVM 运行后再导入 API。

## **添加视频帧**

插入引用外部视频文件的视频帧。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 添加一个链接到视频文件的视频帧。
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **访问视频帧**

检索添加到幻灯片的第一个视频帧。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # 访问幻灯片上的第一个视频帧。
    first_video = None
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            first_video = shape
            break

    if first_video is None:
        print("The slide contains no video frames.")
finally:
    presentation.dispose()
```

## **删除视频帧**

从幻灯片中删除视频帧。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # 删除视频帧。
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **设置视频播放**

配置视频在幻灯片显示时自动播放。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # 配置视频自动播放。
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```