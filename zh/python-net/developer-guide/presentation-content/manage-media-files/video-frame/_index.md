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
description: "学习使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速入门指南。"
---

在演示文稿中恰当地放置视频可以使您的信息更具说服力，并提升观众的参与度。

PowerPoint 允许您以两种方式向演示文稿的幻灯片添加视频：

* 添加或嵌入本地视频（存储在您的计算机上）
* 添加在线视频（来自如 YouTube 等网络来源）。

为了让您向演示文稿添加视频（视频对象），Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) 接口、[IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) 接口以及其他相关类型。

## **创建嵌入式视频帧**

如果您要添加到幻灯片的视频文件存储在本地，您可以创建一个视频帧将视频嵌入到演示文稿中。

1. 创建 [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加 [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) 对象，并传入视频文件路径以将视频嵌入演示文稿。
1. 添加 [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) 对象以创建视频帧。
1. 保存已修改的演示文稿。

以下 Python 代码展示了如何将本地存储的视频添加到演示文稿中：
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


## **创建来自网络来源的视频帧**

Microsoft [PowerPoint 2013 及更高版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支持在演示文稿中使用 YouTube 视频。如果您想使用的视频在网上可用（例如 YouTube），可以通过其网络链接将其添加到演示文稿中。

1. 创建 [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例
1. 通过索引获取幻灯片的引用。
1. 添加 [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) 对象，并传入视频链接。
1. 为视频帧设置缩略图。
1. 保存演示文稿。

以下 Python 代码展示了如何将网络视频添加到 PowerPoint 幻灯片中：
```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # 添加一个 videoFrame
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


## **从幻灯片中提取视频**

除了向幻灯片添加视频之外，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例，以加载包含视频的演示文稿。 
2. 遍历所有 [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 对象。 
3. 遍历所有 [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) 对象以查找 [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)。 
4. 将视频保存到磁盘。

以下 Python 代码展示了如何提取演示文稿幻灯片中的视频：
```python
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象 
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

您可以通过 [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) 对象的属性控制[播放模式](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/)（自动或点击）以及[循环播放](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/)。

**添加视频会影响 PPTX 文件大小吗？**

是的。嵌入本地视频时，二进制数据会被写入文档，导致演示文稿大小随视频文件大小等比例增长。添加在线视频时，仅嵌入链接和缩略图，文件增幅相对较小。

**我能在不更改位置和大小的情况下替换现有 VideoFrame 中的视频吗？**

可以。您可以在保持形状几何属性不变的前提下，替换帧内的[视频内容](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/)，这在更新现有布局中的媒体时非常常见。

**可以确定嵌入视频的内容类型（MIME）吗？**

可以。嵌入的视频拥有可以读取的[内容类型](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/)，例如在保存到磁盘时使用。