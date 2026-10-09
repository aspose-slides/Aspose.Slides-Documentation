---
title: 在 Python 中管理演示文稿中的视频帧
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
description: "学习使用 Aspose.Slides for Python via .NET 以编程方式在 PowerPoint 和 OpenDocument 幻灯片中添加和提取视频帧。快速入门指南。"
---
## **介绍**

视频可以帮助解释概念并吸引受众。Aspose.Slides for Python via .NET 让您可以向幻灯片添加视频帧、调整播放设置、管理字幕以及提取嵌入的视频数据。

PowerPoint 支持本地视频和指向在线视频的链接，例如 YouTube 视频。

为了表示视频数据和视频帧，Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) 类、[VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) 类以及其他相关类型。

## **创建嵌入式视频帧**

如果要添加到幻灯片的视频文件存储在本地，您可以创建视频帧将视频嵌入到演示文稿中。

此示例将在现有演示文稿的第一页嵌入本地视频并保存结果。帧的坐标和尺寸使用点 (points)。流会保持打开状态直到保存完成，因为 [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) 在演示文稿使用时会锁定它。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

您也可以直接将本地视频路径传递给 [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/)。此示例将在新演示文稿的第一页嵌入视频。视频必须在演示文稿保存之前保持可访问。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **创建来自网络源的视频帧**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支持在演示文稿中使用在线视频。您可以创建一个链接到在线视频（例如 YouTube 视频）的视频帧。

此示例向第一页添加 YouTube 视频链接和缩略图。请替换视频标识符以使用其他视频。[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) 设置请求自动播放。下载缩略图和播放视频需要网络访问。演示文稿查看器也必须支持在线视频播放。

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **全屏模式播放视频**

在培训演示中，您可以全屏播放软件演示，以便观众看到细节。将 [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) 设置为 `True` 可在播放期间启用此行为。

此示例打开演示文稿，查找第一页上的第一个 [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)，并启用全屏播放。输入演示文稿必须至少包含一张带有现有视频帧的幻灯片。

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

全屏播放决定视频的显示方式。独立地，[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) 控制是自动播放还是点击播放，而 [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) 控制是否循环。要选择启动行为，请将播放模式设置为 [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/)。示例保留了现有的启动和循环设置。

## **回放后倒带视频**

在培训演示中，将演示视频返回到开头可以让演讲者再次播放。将 [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) 设置为 `True` 可在播放完成后将视频倒回起始位置。

此示例打开演示文稿，查找第一页上的第一个 [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)，并启用倒带。它禁用循环以便播放结束，并将启动方式设置为点击。输入演示文稿必须至少包含一张带有现有视频帧的幻灯片。

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

倒带会将视频返回到起始位置而不会再次启动。相反，启用 [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) 会自动重复播放。当您希望视频播放完毕后保持可再次播放的状态时，请保持循环关闭。[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) 独立控制自动或点击启动；本例使用 [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) 让演讲者自行决定何时开始播放。请在设置循环后再设置播放模式，如示例所示。倒带与 [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) 相互独立。

## **裁剪视频帧**

使用 [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) 和 [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) 可在播放期间跳过视频的开头或结尾部分。两个值均以毫秒为单位。裁剪仅更改播放设置，不会修改嵌入的视频数据。

**设置修剪**

此示例嵌入本地视频并在播放时跳过前 2.5 秒和后 1 秒。请使用长度超过 3.5 秒的视频，以确保仍有可播放的片段。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**读取修剪**

此示例以毫秒为单位打印第一页上第一个视频帧的裁剪值。演示文稿必须至少包含一张幻灯片。如果该幻灯片没有视频帧，则不会输出任何内容。前面的示例会产生 2500 和 1000 的值。

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **管理视频字幕**

Aspose.Slides 允许您在 PowerPoint 演示文稿中管理视频帧的闭合字幕。字幕以 WebVTT 格式存储，并通过 [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) 属性暴露。

**为视频帧添加字幕**

此示例嵌入本地视频并添加一个标记为 English 的 WebVTT 字幕轨道。字幕时间戳应与视频对应。保存后的演示文稿同时包含视频和字幕。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

[CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) 类还提供了一个重载，允许您从流中添加字幕。

**从视频帧提取字幕**

此示例将第一页上所有视频帧的字幕轨道分别保存为独立的 WebVTT 文件。顺序编号确保输出文件唯一。控制台会报告提取的轨道数量。演示文稿必须至少包含一张幻灯片。

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

每个 [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) 对象会公开字幕标识符、标签、二进制数据以及作为 UTF-8 字符串的字幕文本。

**从视频帧删除字幕**

此示例删除第一页上第一个形状位置的视频帧中的所有字幕并保存结果。它假设幻灯片和形状均已存在且该形状是视频帧。

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

如果只需要删除单个字幕轨道，请使用 [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) 或 [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) 方法，而不是 [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/)。

## **从幻灯片提取视频**

除了向幻灯片添加视频，Aspose.Slides 还允许您提取演示文稿中嵌入的视频。

此示例将每张幻灯片中的嵌入视频提取为单独的、编号的二进制文件。链接视频会被跳过，因为它们没有嵌入数据。控制台会打印每个视频的 MIME 类型以及总计数。输出使用通用的 `.bin` 扩展名；如有需要，可更改为对应的媒体类型后缀。

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **常见问题**

**可以更改视频帧的哪些播放参数？**

您可以控制 [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/)（自动或点击）和 [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/)。这些选项通过 [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) 对象的属性提供。

**添加视频会影响 PPTX 文件大小吗？**

会。当您嵌入本地视频时，二进制数据会写入文档，导致演示文稿大小按视频文件大小比例增长。若链接到在线视频并添加缩略图，演示文稿只存储链接和预览图像，而不是视频本身，通常会导致较小的大小增量。

**可以在不更改位置和尺寸的情况下替换现有视频帧中的视频吗？**

可以。您可以在保持形状几何属性不变的情况下交换帧内的 [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/)，这在更新已有布局中的媒体时非常常见。

**可以确定嵌入视频的内容类型（MIME）吗？**

可以。嵌入视频具有可读取的 [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/)，您可以根据该类型进行后续处理，例如保存到磁盘时使用相应的文件扩展名。