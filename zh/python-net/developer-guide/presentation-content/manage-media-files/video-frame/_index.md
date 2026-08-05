---
title: 添加视频到 Python 演示文稿
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
description: "学习如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速操作指南。"
---
## **介绍**

在演示文稿中恰当地放置视频可以使您的信息更具说服力并提升观众的参与度。

PowerPoint 允许您以两种方式向幻灯片添加视频：

* 添加或嵌入本地视频（存储在您的计算机上）
* 添加在线视频（来自诸如 YouTube 的网页来源）

为了让您能够向演示文稿添加视频（视频对象），Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/zh/python-net/aspose.slides/video/) 类、[VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/) 类以及其他相关类型。

## **创建嵌入式视频帧**

如果要添加到幻灯片的视频文件存储在本地，您可以创建视频帧将视频嵌入到演示文稿中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 添加一个 [Video](https://reference.aspose.com/slides/zh/python-net/aspose.slides/video/) 对象并传入视频文件路径，以将视频嵌入演示文稿。  
1. 添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/) 对象以为视频创建帧。  
1. 保存修改后的演示文稿。

下面的 Python 代码演示了如何将本地存储的视频添加到演示文稿中：

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

或者，您也可以直接将视频文件路径传递给 `add_video_frame(x, y, width, height, fname)` 方法来添加视频：

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **创建来自网络来源的视频帧**

较新的 Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) 版本支持在演示文稿中使用在线视频。如果您要使用的视频可在网上获取（例如 YouTube），可以通过其网页链接将其添加到演示文稿中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 添加一个 [Video](https://reference.aspose.com/slides/zh/python-net/aspose.slides/video/) 对象并传入视频链接。  
1. 为视频帧设置缩略图。  
1. 保存演示文稿。

下面的 Python 代码演示了如何将网络视频添加到 PowerPoint 幻灯片中：

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # 添加视频帧
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

## **裁剪视频帧**

Aspose.Slides 通过 [VideoFrame.trim_from_start](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/trim_from_start/) 和 [VideoFrame.trim_from_end](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/trim_from_end/) 设置剪切起始点和结束点的值来控制播放的视频片段。两个值均以毫秒为单位，分别定义从视频开头和结尾跳过的时间长度。这些设置仅影响演示文稿中的视频播放行为；不对嵌入的视频二进制数据进行剪切或其他修改。

**设置裁剪参数**

要创建视频帧并设置其裁剪参数：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。  
1. 向演示文稿添加一个 [Video](https://reference.aspose.com/slides/zh/python-net/aspose.slides/video/) 对象。  
1. 向幻灯片添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/) 对象。  
1. 通过 [VideoFrame.trim_from_start](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/trim_from_start/) 和 [VideoFrame.trim_from_end](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/trim_from_end/) 设置起始和结束剪切值。  
1. 保存修改后的演示文稿。

以下代码示例在播放期间跳过嵌入视频的前 2.5 秒和最后 1 秒：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**读取裁剪参数**

要检查已有的裁剪设置，加载演示文稿，找到第一张幻灯片中形状列表里的 [VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/) 对象，并通过 [VideoFrame.trim_from_start](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/trim_from_start/) 与 [VideoFrame.trim_from_end](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/trim_from_end/) 读取数值。

以下代码示例查找第一张幻灯片上的首个视频帧并以毫秒为单位报告其裁剪设置：

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **管理视频字幕**

Aspose.Slides 允许您在 PowerPoint 演示文稿中管理视频帧的闭合字幕。字幕以 WebVTT 格式存储，并通过 [VideoFrame.caption_tracks](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/caption_tracks/) 属性公开。

**向视频帧添加字幕**

向视频帧添加字幕的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。  
1. 向演示文稿添加视频。  
1. 向幻灯片添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/) 对象。  
1. 使用由 [caption_tracks](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/caption_tracks/) 返回的 [CaptionsCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captionscollection/) 添加 WebVTT 字幕轨道。  
1. 保存修改后的演示文稿。

下面的代码演示了如何向视频帧添加字幕：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # 添加来自 WebVTT 文件的新字幕轨道
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

[CaptionsCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captionscollection/) 类还提供了一个重载，可让您从流中添加字幕。

**从视频帧提取字幕**

从视频帧提取字幕的步骤：

1. 加载包含视频的演示文稿。  
1. 找到目标 [VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/) 对象。  
1. 遍历 [caption_tracks](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/caption_tracks/) 集合。  
1. 将每个字幕轨道保存为 `.vtt` 文件。

下面的代码演示了如何从视频帧提取字幕：

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

每个 [Captions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captions/) 对象都会公开字幕标识符、标签、二进制数据以及以 UTF-8 字符串形式的字幕文本。

**从视频帧移除字幕**

从视频帧移除字幕的步骤：

1. 加载包含视频的演示文稿。  
1. 获取目标 [VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/) 对象。  
1. 从 [CaptionsCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captionscollection/) 中移除字幕轨道。  
1. 保存修改后的演示文稿。

下面的代码演示了如何移除视频帧中的所有字幕：

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # 类型: slides.VideoFrame

    # 移除视频帧中的所有字幕
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

如果只需移除单个字幕轨道，请使用 [remove](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captionscollection/remove/) 或 [remove_at](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captionscollection/remove_at/) 方法，而不是 [clear](https://reference.aspose.com/slides/zh/python-net/aspose.slides/captionscollection/clear/)。

## **从幻灯片提取视频**

除了向幻灯片添加视频，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例以加载包含视频的演示文稿。  
2. 遍历所有 [Slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/) 对象。  
3. 遍历所有 [Shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/) 对象以查找 [VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/)。  
4. 将视频保存到磁盘。

下面的 Python 代码演示了如何提取演示文稿幻灯片中的视频：

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

**可以更改 VideoFrame 的哪些视频播放参数？**

您可以通过 [VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/) 对象的属性控制[播放模式](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/play_mode/)（自动或单击）和[循环](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/play_loop_mode/)。

**添加视频会影响 PPTX 文件大小吗？**

会的。嵌入本地视频时，二进制数据会包含在文档中，文件大小会随视频文件大小成比例增长。添加在线视频时，只会嵌入链接和缩略图，因此增幅相对较小。

**是否可以在不改变位置和尺寸的情况下替换已有 VideoFrame 中的视频？**

可以。您可以在保持形状几何属性不变的前提下，替换帧内的[视频内容](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/embedded_video/)，这在更新已有布局的媒体时非常常见。

**是否可以确定嵌入视频的内容类型（MIME）？**

可以。嵌入视频具有可读取的[内容类型](https://reference.aspose.com/slides/zh/python-net/aspose.slides/video/content_type/)，您可以在保存到磁盘等场景中使用它。