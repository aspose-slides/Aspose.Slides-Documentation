---
title: 使用 Python 管理演示文稿中的视频帧
linktitle: 视频帧
type: docs
weight: 10
url: /zh/python-java/video-frame/
keywords:
- 添加视频
- 创建视频
- 嵌入视频
- 提取视频
- 检索视频
- 视频帧
- 网络来源
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for Python via Java，以编程方式在 PowerPoint 和 OpenDocument 幻灯片中添加和提取视频帧。快速实用指南。"
---
## **简介**

在演示文稿中恰当地放置视频可以使您的信息更具说服力，并提升观众的参与度。

PowerPoint 允许您以两种方式向演示文稿的幻灯片添加视频：

* 添加或嵌入本地视频（存储在您的机器上）
* 添加在线视频（来自诸如 YouTube 的网络来源）。

为了让您能够向演示文稿添加视频（video 对象），Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/zh/python-java/aspose.slides/video/) 类、[VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 类以及其他相关类型。

## **创建嵌入式视频帧**

如果您要添加到幻灯片的视频文件存储在本地，您可以创建视频帧以在演示文稿中嵌入该视频。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个 [Video](https://reference.aspose.com/slides/zh/python-java/aspose.slides/video/) 对象并传入视频文件数据，以将视频嵌入演示文稿。
1. 添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 对象以创建视频帧。
1. 保存修改后的演示文稿。

以下 Python 代码演示了如何将本地存储的视频添加到演示文稿中：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

或者，您可以直接将视频文件路径传递给 [addVideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addVideoFrame) 方法来添加视频：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **使用网络来源视频创建视频帧**

Microsoft [PowerPoint 2013 及更高版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支持在演示文稿中使用 YouTube 视频。如果您要使用的视频可在线获取（例如在 YouTube 上），您可以通过其网络链接将其添加到演示文稿中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 对象并传入视频链接。
1. 为视频帧设置缩略图。
1. 保存演示文稿。

以下 Python 代码演示了如何将网络视频添加到 PowerPoint 演示文稿的幻灯片中：

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # 加载缩略图。
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **剪裁视频帧**

Aspose.Slides 允许您通过在 [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#setTrimFromStart) 和 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#setTrimFromEnd) 中设置 trim-from-start 和 trim-from-end 值来控制播放的视频片段。两个值均以毫秒为单位，定义了从视频开头和结尾分别跳过的时间。这些设置更改演示文稿中的视频播放设置；它们不会剪切或以其他方式修改嵌入视频的二进制数据。

**设置剪裁参数**

要创建视频帧并设置其剪裁参数：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 添加一个 [Video](https://reference.aspose.com/slides/zh/python-java/aspose.slides/video/) 对象到演示文稿。
1. 添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 对象到幻灯片。
1. 通过 [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#setTrimFromStart) 和 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#setTrimFromEnd) 设置 trim-from-start 和 trim-from-end 值。
1. 保存修改后的演示文稿。

以下代码示例在播放期间跳过嵌入视频的前 2.5 秒和最后 1 秒：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**读取剪裁参数**

要检查现有的剪裁参数，加载演示文稿，查找第一张幻灯片上的形状中 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 对象，并通过 [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#getTrimFromStart) 和 [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#getTrimFromEnd) 读取这些值。

以下代码示例查找第一张幻灯片上的第一个视频帧，并以毫秒为单位报告其剪裁参数：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **管理视频字幕**

Aspose.Slides 允许您管理 PowerPoint 演示文稿中视频帧的闭合字幕。字幕以 WebVTT 格式存储，可通过 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#getCaptionTracks) 方法获取。

**向视频帧添加字幕**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 向演示文稿添加 video。
1. 添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 对象到幻灯片。
1. 使用 [getCaptionTracks](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#getCaptionTracks) 返回的 [CaptionsCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/) 添加 WebVTT 字幕轨道。
1. 保存修改后的演示文稿。

以下代码演示了如何向视频帧添加字幕：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # 添加来自 WebVTT 文件的新字幕轨道。
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[CaptionsCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/) 类还提供了一个重载，允许您从流中添加字幕。

**从视频帧提取字幕**

1. 加载包含视频的演示文稿。
1. 找到目标 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 对象。
1. 遍历 [CaptionsCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/) 中的字幕轨道。
1. 将每个字幕轨道保存为 `.vtt` 文件。

以下代码演示了如何从视频帧提取字幕：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # 将字幕轨道保存为 WebVTT 文件。
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

每个 [Captions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captions/) 对象公开字幕标识符、标签、二进制数据以及以 UTF-8 字符串形式的字幕文本。

**从视频帧移除字幕**

1. 加载包含视频的演示文稿。
1. 获取目标 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 对象。
1. 从 [CaptionsCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/) 中移除字幕轨道。
1. 保存修改后的演示文稿。

以下代码演示了如何从视频帧中移除所有字幕：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # 删除视频帧中的所有字幕。
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

如果只需要移除单个字幕轨道，请使用 [remove](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/#removeAt) 方法，而不是 [clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/#clear)。

## **从幻灯片提取视频**

除了向幻灯片添加视频外，Aspose.Slides 还允许您提取嵌入演示文稿中的视频。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例以加载包含视频的演示文稿。
2. 遍历所有的 [Slide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/) 对象。
3. 遍历所有的 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/) 对象以查找 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/)。
4. 将视频保存到磁盘。

以下 Python 代码演示了如何提取演示文稿幻灯片中的视频：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **FAQ**

**可以更改 VideoFrame 的哪些视频播放参数？**

您可以通过 VideoFrame 对象的属性控制 [playback mode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#setPlayMode)（自动或单击）和 [looping](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#setPlayLoopMode)。这些选项可通过 VideoFrame 对象的属性获得。

**添加视频会影响 PPTX 文件大小吗？**

会。嵌入本地视频时，二进制数据会包含在文档中，演示文稿大小会随文件大小等比例增加。添加在线视频时，只会嵌入链接和缩略图，因此大小增幅较小。

**可以在不更改位置和大小的情况下替换现有 VideoFrame 中的视频吗？**

可以。您可以在保持形状几何不变的情况下交换帧内的视频内容，这在更新已有布局中的媒体时非常常见。

**可以确定嵌入视频的内容类型（MIME）吗？**

可以。嵌入的视频具有可读取的内容类型，例如在保存到磁盘时可使用该信息。