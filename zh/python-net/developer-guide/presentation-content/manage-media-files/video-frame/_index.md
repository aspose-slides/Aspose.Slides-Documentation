---
title: 在 Python 中向演示文稿添加视频
linktitle: 视频帧
type: docs
weight: 10
url: /zh/python-net/video-frame/
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
description: "学习使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速操作指南。"
---
在演示文稿中恰当地放置视频可以使您的信息更具说服力，并提升观众的参与度。

PowerPoint 允许您以两种方式向演示文稿的幻灯片添加视频：

* 添加或嵌入本地视频（存储在您的计算机上）
* 添加在线视频（来自诸如 YouTube 的网络来源）。

为了让您向演示文稿添加视频（视频对象），Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/zh/python-net/aspose.slides/video/) 类、[VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/) 类以及其他相关类型。

## **创建嵌入式视频帧**

如果您想添加到幻灯片的视频文件存储在本地，您可以创建视频帧以在演示文稿中嵌入该视频。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个 [Video](https://reference.aspose.com/slides/zh/python-net/aspose.slides/video/) 对象，并传递视频文件路径以将视频嵌入演示文稿。
1. 添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/) 对象，以创建视频帧。
1. 保存修改后的演示文稿。

下面的 Python 代码展示了如何向演示文稿添加本地存储的视频：

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # 获取第一张幻灯片并添加视频帧
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # 将演示文稿保存到磁盘
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

或者，您可以直接将文件路径传递给 `add_video_frame(x, y, width, height, fname)` 方法来添加视频：

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **使用网络来源视频创建视频帧**

Microsoft [PowerPoint 2013 及更高版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支持在演示文稿中使用 YouTube 视频。如果您要使用的视频在线可用（例如在 YouTube 上），可以通过其网络链接将其添加到演示文稿中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例
1. 通过索引获取幻灯片的引用。
1. 添加一个 [Video](https://reference.aspose.com/slides/zh/python-net/aspose.slides/video/) 对象，并传递视频链接。
1. 为视频帧设置缩略图。
1. 保存演示文稿。

以下 Python 代码演示了如何将网络视频添加到 PowerPoint 演示文稿的幻灯片中：

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # 添加 videoFrame
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # 加载缩略图
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **管理视频字幕**

Aspose.Slides 允许您管理 PowerPoint 演示文稿中视频帧的闭合字幕。字幕以 WebVTT 格式存储，并通过 [VideoFrame.caption_tracks](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/caption_tracks/) 属性公开。

**向视频帧添加字幕**

向视频帧添加字幕的步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
1. 向演示文稿添加视频。
1. 向幻灯片添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/) 对象。
1. 使用由 [caption_tracks](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/caption_tracks/) 返回的 [CaptionsCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captionscollection/) 添加 WebVTT 字幕轨道。
1. 保存修改后的演示文稿。

以下代码展示了如何向视频帧添加字幕：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # 添加来自 WebVTT 文件的新字幕轨道。
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

[CaptionsCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captionscollection/) 类还提供了一个重载，允许您从流中添加字幕。

**从视频帧提取字幕**

从视频帧提取字幕的步骤如下：

1. 加载包含该视频的演示文稿。
1. 找到目标 [VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/) 对象。
1. 遍历 [caption_tracks](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/caption_tracks/) 集合。
1. 将每个字幕轨道保存为 `.vtt` 文件。

以下代码展示了如何从视频帧提取字幕：

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # 将字幕轨道保存为 WebVTT 文件。
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

每个 [Captions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captions/) 对象都公开字幕标识符、标签、二进制数据以及以 UTF-8 字符串形式的字幕文本。

**从视频帧移除字幕**

从视频帧移除字幕的步骤如下：

1. 加载包含该视频的演示文稿。
1. 获取目标 [VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/) 对象。
1. 从 [CaptionsCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captionscollection/) 中移除字幕轨道。
1. 保存修改后的演示文稿。

以下代码展示了如何从视频帧中移除所有字幕：

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # 类型: slides.VideoFrame

    # 移除视频帧中的所有字幕。
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

如果您只需要移除单个字幕轨道，请使用 [remove](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captionscollection/remove/) 或 [remove_at](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captionscollection/remove_at/) 方法，而不是 [clear](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captionscollection/clear/) 方法。

## **从幻灯片提取视频**

除向幻灯片添加视频外，Aspose.Slides 还允许您提取嵌入演示文稿中的视频。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例，以加载包含视频的演示文稿。
2. 遍历所有 [Slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/) 对象。
3. 遍历所有 [Shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/) 对象以查找 [VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/)。
4. 将视频保存到磁盘。

以下 Python 代码展示了如何提取演示文稿幻灯片上的视频：

```python
import aspose.slides as slides

# 实例化一个表示演示文件的 Presentation 对象
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **常见问题**

**可以为 VideoFrame 更改哪些视频播放参数？**

您可以通过 [VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/) 对象的属性控制[播放模式](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/play_mode/)（自动或点击）和[循环](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/play_loop_mode/) 。

**添加视频会影响 PPTX 文件大小吗？**

会。嵌入本地视频时，二进制数据会写入文档，演示文稿的大小会随视频文件大小成比例增长。添加在线视频时，只嵌入链接和缩略图，尺寸增长相对较小。

**我能在不更改位置和大小的情况下替换现有 VideoFrame 中的视频吗？**

可以。您可以在保持形状几何尺寸不变的情况下，替换帧内的[视频内容](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/embedded_video/)，这在更新已有布局中的媒体时很常见。

**可以确定嵌入视频的内容类型（MIME）吗？**

可以。嵌入的视频具有可读取的[内容类型](https://reference.aspose.com/slides/zh/python-net/aspose.slides/video/content_type/)，例如在保存到磁盘时可使用该信息。