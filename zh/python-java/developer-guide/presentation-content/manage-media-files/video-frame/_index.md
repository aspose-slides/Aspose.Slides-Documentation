---
title: 在演示文稿中使用 Python 管理视频帧
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
description: "了解如何使用 Aspose.Slides for Python via Java，以编程方式在 PowerPoint 和 OpenDocument 幻灯片中添加和提取视频帧。快速入门指南。"
---
## **介绍**

在演示文稿中恰当地放置视频可以使您的信息更具吸引力，并提升观众的参与度。

PowerPoint 提供了两种在幻灯片中添加视频的方法：

* 添加或嵌入本地视频（存储在您的机器上）
* 添加在线视频（如 YouTube）。

为了让您能够向演示文稿添加视频（视频对象），Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/zh/python-java/aspose.slides/video/) 类、[VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 类以及其他相关类型。

## **创建嵌入式视频帧**

如果要添加到幻灯片的视频文件存放在本地，您可以创建视频帧将视频嵌入到演示文稿中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个 [Video](https://reference.aspose.com/slides/zh/python-java/aspose.slides/video/) 对象，并传入视频文件数据以将视频嵌入演示文稿。  
4. 添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 对象，为视频创建帧。  
5. 保存修改后的演示文稿。

下面的 Python 代码演示了如何将本地视频添加到演示文稿中：

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

另外，您也可以直接将视频文件路径传递给 [addVideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addVideoFrame) 方法来添加视频：

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

## **创建来自网络来源的视频帧**

Microsoft [PowerPoint 2013 及更高版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支持在演示文稿中使用 YouTube 视频。如果您要使用的视频可在网上获取（例如 YouTube），可以通过其网络链接将其添加到演示文稿中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 对象，并传入视频链接。  
4. 为视频帧设置缩略图。  
5. 保存演示文稿。

下面的 Python 代码演示了如何从网络向 PowerPoint 幻灯片添加视频：

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

## **修剪视频帧**

Aspose.Slides 通过 [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#setTrimFromStart) 和 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#setTrimFromEnd) 方法设置 trim‑from‑start 和 trim‑from‑end 值，以控制播放的视频片段。这两个值以毫秒为单位，分别定义从视频开始和结束处跳过的时间长度。此设置仅影响演示文稿中的播放行为，不会裁剪或修改嵌入视频的二进制数据。

**设置修剪属性**

要创建视频帧并设置其修剪属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
2. 向演示文稿添加一个 [Video](https://reference.aspose.com/slides/zh/python-java/aspose.slides/video/) 对象。  
3. 向幻灯片添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 对象。  
4. 通过 [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#setTrimFromStart) 和 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#setTrimFromEnd) 设置 trim‑from‑start 与 trim‑from‑end。  
5. 保存修改后的演示文稿。

下面的代码示例在播放时跳过嵌入视频的前 2.5 秒和最后 1 秒：

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

**读取修剪属性**

要检查已存在的修剪属性，加载演示文稿，在第一张幻灯片的形状集合中找到 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 对象，并通过 [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#getTrimFromStart) 与 [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#getTrimFromEnd) 读取其数值。

下面的代码示例查找第一张幻灯片上的第一个视频帧，并以毫秒为单位报告其修剪属性：

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

向视频帧添加字幕的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
2. 向演示文稿中添加视频。  
3. 向幻灯片添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 对象。  
4. 使用由 [getCaptionTracks](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#getCaptionTracks) 返回的 [CaptionsCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/) 添加 WebVTT 字幕轨道。  
5. 保存修改后的演示文稿。

下面的代码展示了如何向视频帧添加字幕：

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

    # 添加一个来自 WebVTT 文件的新字幕轨道。
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[CaptionsCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/) 类还提供了一个重载，可通过流添加字幕。

**从视频帧提取字幕**

从视频帧提取字幕的步骤：

1. 加载包含视频的演示文稿。  
2. 找到目标 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 对象。  
3. 遍历 [CaptionsCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/) 中的字幕轨道。  
4. 将每条字幕轨道保存为 `.vtt` 文件。

下面的代码展示了如何从视频帧提取字幕：

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

每个 [Captions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captions/) 对象都会公开字幕标识符、标签、二进制数据以及以 UTF‑8 编码的字幕文本。

**从视频帧移除字幕**

移除视频帧字幕的步骤：

1. 加载包含视频的演示文稿。  
2. 获取目标 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 对象。  
3. 从 [CaptionsCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/) 中移除字幕轨道。  
4. 保存修改后的演示文稿。

下面的代码展示了如何移除视频帧中的所有字幕：

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

如果只需要移除单条字幕轨道，请使用 [remove](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/#removeAt) 方法，而不是 [clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/captionscollection/#clear)。

## **从幻灯片中提取视频**

除了向幻灯片添加视频，Aspose.Slides 还支持提取演示文稿中嵌入的视频。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例以加载包含视频的演示文稿。  
2. 遍历所有 [Slide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/) 对象。  
3. 遍历每个 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/) 对象，查找其中的 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/)。  
4. 将视频保存到磁盘。

下面的 Python 代码演示了如何提取演示文稿幻灯片中的视频：

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

## **常见问题**

**可以为 VideoFrame 更改哪些视频播放参数？**

您可以通过 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 对象的属性控制 [playback mode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#setPlayMode)（自动或点击）以及 [looping](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#setPlayLoopMode)。这些选项均通过 VideoFrame 的属性进行设置。

**添加视频会影响 PPTX 文件大小吗？**

会。当您嵌入本地视频时，二进制数据会包含在文档中，文件大小会随视频文件大小等比例增长。添加在线视频时，仅会嵌入链接和缩略图，导致的大小增幅相对较小。

**是否可以在不更改位置和尺寸的前提下替换现有 VideoFrame 中的视频？**

可以。您可以通过 [VideoFrame.setEmbeddedVideo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/#setEmbeddedVideo) 替换帧内的视频内容，同时保持形状的几何属性不变；这在需要更新已有布局中的媒体时非常常见。

**是否可以确定嵌入视频的内容类型（MIME）？**

可以。嵌入的视频拥有可通过 [Video.getContentType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/video/#getContentType) 读取的内容类型，例如在将其保存到磁盘时使用。