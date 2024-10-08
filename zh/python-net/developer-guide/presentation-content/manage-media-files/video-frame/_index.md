---
title: 视频框架
type: docs
weight: 10
url: /python-net/video-frame/
keywords: "添加视频，创建视频框架，提取视频，PowerPoint 演示文稿，Python，Aspose.Slides for Python via .NET"
description: "在 Python 中向 PowerPoint 演示文稿添加视频框架"
---

在演示文稿中适当放置的视频可以使您的信息更具吸引力，并提高与观众的参与度。

PowerPoint 允许您以两种方式向演示文稿中的幻灯片添加视频：

* 添加或嵌入本地视频（存储在您的计算机上）
* 添加在线视频（来自 YouTube 等网络来源）。

为了让您在演示文稿中添加视频（视频对象），Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) 接口、[IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) 接口和其他相关类型。

## **创建嵌入式视频框架**

如果您要添加到幻灯片的视频文件存储在本地，您可以创建一个视频框架以将视频嵌入到演示文稿中。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加 [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) 对象并传递视频文件路径以将视频嵌入演示文稿。
1. 添加 [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) 对象以创建视频的框架。
1. 保存已修改的演示文稿。

这段 Python 代码向您展示了如何将本地存储的视频添加到演示文稿中：

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # 获取第一张幻灯片并添加视频框架
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # 将演示文稿保存到磁盘
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

另外，您还可以通过直接将其文件路径传递给 `add_video_frame(x, y, width, height, fname)` 方法来添加视频：

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **使用网络源中的视频创建视频框架**

Microsoft [PowerPoint 2013 及更新版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 在演示文稿中支持 YouTube 视频。如果您想使用的视频在线可用（例如在 YouTube 上），您可以通过其网络链接将其添加到演示文稿中。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例
1. 通过索引获取幻灯片的引用。
1. 添加 [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) 对象并传递视频链接。
1. 设置视频框架的缩略图。
1. 保存演示文稿。

这段 Python 代码向您展示了如何将网络中的视频添加到 PowerPoint 演示文稿中的幻灯片：

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # 添加视频框架
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

除了向幻灯片添加视频外，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例以加载包含视频的演示文稿。
2. 遍历所有 [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 对象。
3. 遍历所有 [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) 对象以查找 [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)。
4. 将视频保存到磁盘。

这段 Python 代码向您展示了如何提取演示文稿幻灯片上的视频：

```python
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 对象
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```