---
title: 在 Python 中管理演示文稿的视频帧
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
description: "学习使用 Aspose.Slides for Python via .NET 以编程方式在 PowerPoint 和 OpenDocument 幻灯片中添加和提取视频帧。快速实用指南。"
---
## **介绍**

视频可以帮助解释概念并吸引观众。Aspose.Slides for Python via .NET 让您可以向幻灯片添加视频帧，调整播放设置，管理字幕，并提取嵌入的视频数据。

PowerPoint 支持本地视频和在线视频链接，例如 YouTube 视频。

为了表示视频数据和视频帧，Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) 类、[VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) 类以及其他相关类型。

## **创建嵌入式视频帧**

如果要添加到幻灯片的视频文件存储在本地，您可以创建视频帧将视频嵌入演示文稿。

此示例将在现有演示文稿的第一张幻灯片上嵌入本地视频并保存结果。帧的坐标和尺寸使用点为单位。由于 [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) 在演示文稿使用时保持流锁定，流会保持打开状态直至保存完成。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

您还可以直接将本地视频路径传递给 [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/)。此示例将在新演示文稿的第一张幻灯片上嵌入视频。视频必须保持可访问，直到演示文稿保存完成。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **使用网络来源的视频创建视频帧**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支持在演示文稿中嵌入在线视频。您可以创建一个链接到在线视频（如 YouTube 视频）的视频帧。

此示例将在第一张幻灯片上添加 YouTube 视频链接和缩略图。替换视频标识符即可使用其他视频。[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) 设置请求自动播放。下载缩略图和播放视频均需要网络访问。演示文稿查看器也必须支持在线视频播放。

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

## **在全屏模式下播放视频**

在培训演示中，您可以全屏播放软件演示，让观众看到细节。将 [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) 设置为 `True` 可在播放期间启用此行为。

此示例打开一个演示文稿，查找第一张幻灯片上的第一个 [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)，并启用全屏播放。输入演示文稿必须至少包含一张幻灯片，在第一张幻灯片上已有视频帧。

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

全屏播放控制视频的显示方式。除此之外，[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) 控制是自动启动还是点击启动，[play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) 控制是否循环。要选择启动行为，请将播放模式设置为 [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/)。示例保留了现有的启动和循环设置。

## **播放后倒回视频**

在培训演示中，将演示视频返回到开头可以让演讲者再次播放。将 [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) 设置为 `True` 可在播放完成后将视频返回到开头。

此示例打开一个演示文稿，查找第一张幻灯片上的第一个 [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)，并启用倒回。它禁用循环以便播放能够结束，并将播放设置为点击启动。输入演示文稿必须至少包含一张幻灯片，在第一张幻灯片上已有视频帧。

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

倒回会把视频返回到开头而不会再次启动。相反，启用 [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) 会自动重复播放。希望视频播放完毕并保持可重新播放时请保持循环关闭。[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) 独立控制自动或点击启动；本示例使用 [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) 让演讲者自行决定何时开始播放。正如示例所示，先设置循环后再设置播放模式。倒回的行为独立于 [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/)。

## **裁剪视频帧**

使用 [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) 和 [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) 可以在播放时跳过视频开头或结尾的部分。两个值的单位都是毫秒。裁剪仅更改播放设置，不会修改嵌入的视频数据。

**设置裁剪参数**

此示例嵌入本地视频，并在播放时跳过前 2.5 秒和最后 1 秒。请使用时长超过 3.5 秒的视频，以确保仍有可播放的片段。

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

**读取裁剪参数**

此示例以毫秒为单位打印第一张幻灯片上第一个视频帧的裁剪值。演示文稿必须至少包含一张幻灯片。如果该幻灯片没有视频帧，则不输出任何内容。前面的示例会产生 2500 和 1000 两个值。

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

Aspose.Slides 允许您在 PowerPoint 演示文稿中管理视频帧的闭合字幕。字幕以 WebVTT 格式存储，并通过 [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) 属性公开。

### **向视频帧添加字幕**

此示例嵌入本地视频并添加一个标记为 English 的 WebVTT 字幕轨道。字幕时间戳应与视频匹配。保存的演示文稿同时包含视频和字幕。

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

### **从视频帧提取字幕**

此示例将第一张幻灯片上视频帧的所有字幕轨道保存为单独的 WebVTT 文件。顺序编号确保输出文件互不相同。控制台会报告提取的轨道数量。演示文稿必须至少包含一张幻灯片。

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

每个 [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) 对象公开字幕标识符、标签、二进制数据以及以 UTF-8 字符串形式的字幕文本。

### **从视频帧移除字幕**

此示例移除第一张幻灯片上第一个形状位置处的视频帧的所有字幕，并保存结果。它假设幻灯片和形状均存在且该形状为视频帧。

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

如果只需要移除单个字幕轨道，请使用 [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) 或 [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) 方法，而不是 [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/)。

### **搜索视频字幕**

[Captions.data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) 返回整个 WebVTT 轨道，包括其头部、时间线和字幕文本。例如，幻灯片 2 上的英文轨道可能包含以下 cue：

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

此示例打开 `captioned_media.pptx`，读取每张幻灯片上每个顶层视频帧的 [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/)。对于每个纯文本 cue，它查找包含 `-->` 的时间行，并收集直到下一个空行或轨道结束的字幕行。它不区分大小写地搜索字幕文本中的 “café”，并打印匹配项的幻灯片编号、轨道标签、原始时间行以及完整字幕。

```python
import aspose.slides as slides

with slides.Presentation("captioned_media.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.VideoFrame):
                continue

            for track in shape.caption_tracks:
                lines = iter(track.data_as_string.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue

                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)

                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.slide_number} | {track.label} | {timing}")
                        print(caption)
```

该示例轨道产生一次匹配。标题中的 “Café” 位于字幕文本之外，输出保留了时间设置以及两行字幕。

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **从幻灯片提取视频**

除了向幻灯片添加视频，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

此示例将每张幻灯片上嵌入的视频提取为单独的、编号的二进制文件。链接视频会被跳过，因为它们没有嵌入数据。控制台会打印每个视频的 MIME 类型和总计数。输出使用通用的 `.bin` 扩展名；必要时可将其更改为与报告的媒体类型相匹配。

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

会。嵌入本地视频时，二进制数据会写入文档，因而演示文稿大小会按视频文件大小成比例增长。链接在线视频并添加缩略图时，演示文稿只存储链接和预览图像，而不是视频数据，通常导致的大小增加要小得多。

**我可以在不更改位置和尺寸的情况下替换已有视频帧中的视频吗？**

可以。您可以在保持形状几何不变的情况下交换帧内的 [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/)，这在更新已有布局中的媒体时很常见。

**可以确定嵌入视频的内容类型（MIME）吗？**

可以。嵌入的视频具有可读取的 [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/)，例如在将其保存到磁盘时可以使用该信息。