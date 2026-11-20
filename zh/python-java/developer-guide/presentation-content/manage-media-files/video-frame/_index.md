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
description: "学习使用 Aspose.Slides for Python via Java 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速实用指南。"
---
## **介绍**

视频可以帮助解释想法并吸引观众。Aspose.Slides for Python via Java 允许您向幻灯片添加视频帧，调整播放设置，管理字幕，并提取嵌入的视频数据。

PowerPoint 支持本地视频和指向在线视频的链接，例如 YouTube 视频。

为了表示视频数据和视频帧，Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) 类、[VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) 类和其他相关类型。

## **创建嵌入式视频帧**

如果您想要添加到幻灯片的视频文件保存在本地，您可以创建视频帧将视频嵌入到演示文稿中。

此示例将本地视频嵌入现有演示文稿的第一张幻灯片并保存结果。帧坐标和尺寸以点为单位。Python 从磁盘读取视频字节，JPype 在将视频添加到演示文稿之前将其转换为 Java 字节数组。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

您也可以直接将本地视频路径传递给 [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame)。此示例将视频嵌入新演示文稿的第一张幻灯片。视频必须在演示文稿保存之前保持可访问。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **创建来自网络来源的视频帧**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 在演示文稿中支持在线视频。您可以创建一个链接到在线视频（例如 YouTube 视频）的视频帧。

此示例向第一张幻灯片添加 YouTube 视频链接和缩略图。替换视频标识符即可使用其他视频。[setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) 方法请求自动播放。下载缩略图和播放视频需要互联网访问。演示文稿查看器还必须支持在线视频播放。

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **全屏播放视频**

在培训演示文稿中，您可以以全屏模式播放软件演示，以便观众看到细节。调用 [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) 并传入 `True` 可在播放期间启用此行为。

此示例打开一个演示文稿，查找第一张幻灯片上的第一个 [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/)，并启用全屏播放。输入演示文稿必须至少在第一张幻灯片上包含一个已有的视频帧。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

全屏播放控制视频的显示方式。另行，[setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) 控制视频是自动开始还是点击开始，而 [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) 控制是否循环播放。要选择启动行为，请将播放模式设置为 [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/)。示例保留了现有的启动和循环设置。

## **播放后倒退视频**

在培训演示文稿中，将演示视频返回到开头可使演示者再次播放。调用 [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) 并传入 `True` 可在播放结束后将视频返回到开头。

此示例打开一个演示文稿，查找第一张幻灯片上的第一个 [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/)，并启用倒退。它禁用循环以便播放可以结束，并将播放设置为点击开始。输入演示文稿必须至少在第一张幻灯片上包含一个已有的视频帧。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

倒退会把视频返回到开头而不重新开始。相比之下，调用 [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) 并传入 `True` 会自动循环播放。希望视频播放完毕后保持可重新播放时，请保持循环关闭。[setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) 独立控制自动或点击启动；本示例使用 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/)，因此演示者可以控制何时开始播放。示例中先设置循环后设置播放模式。倒退独立于 [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) 工作。

## **裁剪视频帧**

使用 [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) 和 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) 可在播放期间跳过视频开头或结尾的部分。两个数值均以毫秒为单位。裁剪会更改播放设置，但不修改嵌入的视频数据。

**设置裁剪参数**

此示例嵌入本地视频，并在播放时跳过前 2.5 秒和最后 1 秒。使用时长超过 3.5 秒的视频，以保证仍有可播放的片段。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**读取裁剪参数**

此示例以毫秒为单位打印第一张幻灯片上第一个视频帧的裁剪值。演示文稿必须至少包含一张幻灯片。如果该幻灯片没有视频帧，则不打印任何内容。前面的示例生成的值为 2500 和 1000。

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

Aspose.Slides 允许您管理 PowerPoint 演示文稿中视频帧的闭合字幕。字幕以 WebVTT 格式存储，并通过 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) 方法公开。

### **向视频帧添加字幕**

此示例嵌入本地视频并添加标记为 English 的 WebVTT 字幕轨道。字幕时间戳应与视频匹配。保存的演示文稿同时包含视频及其字幕。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpame.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # 从 WebVTT 文件添加新的字幕轨道。
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) 类还提供了一个重载，允许您从流中添加字幕。

### **从视频帧提取字幕**

此示例将第一张幻灯片上所有视频帧的字幕轨道保存为单独的 WebVTT 文件。使用顺序编号保持输出文件的唯一性。控制台报告提取的轨道数量。演示文稿必须至少包含一张幻灯片。

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

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

每个 [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) 对象公开字幕标识符、标签、二进制数据以及以 UTF-8 字符串形式的字幕文本。

### **从视频帧移除字幕**

此示例删除第一张幻灯片上第一个形状位置处视频帧的所有字幕并保存结果。它假设幻灯片和形状均存在且该形状是视频帧。

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

如果只需要移除单个字幕轨道，请使用 [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) 方法，而不是 [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear)。

### **搜索视频字幕**

[Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) 返回完整的 WebVTT 轨道，包括其头部、时间线和字幕文本。您可以在内存中搜索字幕以查找短语及其时间戳。例如，幻灯片 2 上的英文轨道可能包含以下文本。

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

此示例打开 `captioned_media.pptx` 并使用 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) 读取每张幻灯片上每个顶层视频帧的轨道。在纯文本 cue 中，时间行包含 `-->`，空行结束 cue。对于包含任意大小写的 “café” 的字幕，示例会打印幻灯片编号、轨道标签、原始时间行和完整字幕。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("captioned_media.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, VideoFrame):
                continue
            for track in shape.getCaptionTracks():
                track_text = str(track.getDataAsString())
                lines = iter(track_text.splitlines())
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
                        print(f"Slide {slide.getSlideNumber()} | {track.getLabel()} | {timing}")
                        print(caption)
finally:
    presentation.dispose()
```

搜索 “café” 为示例轨道产生一次匹配。搜索会排除轨道头部，并在输出中保留时间设置和换行。

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **从幻灯片提取视频**

除了向幻灯片添加视频之外，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

此示例将每张幻灯片中的嵌入视频提取为单独的、编号的二进制文件。链接视频会被跳过，因为它们没有嵌入数据。控制台打印每个视频的 MIME 类型以及总计数。输出使用通用的 `.bin` 扩展名；需要时可将其更改为匹配报告的媒体类型。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **常见问题**

**可以更改视频帧的哪些播放参数？**

您可以通过 [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) 对象的方法控制 [playback mode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode)（自动或点击）和 [looping](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode)。这些选项可通过相应的方法进行设置。

**添加视频会影响 PPTX 文件大小吗？**

是的。嵌入本地视频时，二进制数据会包含在文档中，导致演示文稿大小按文件大小比例增长。链接在线视频并添加缩略图时，演示文稿只存储链接和预览图像，而不是视频数据，因而大小增加通常较小。

**我能在不更改位置和尺寸的情况下替换已有视频帧中的视频吗？**

可以。您可以在保持形状几何不变的情况下交换帧内的 [video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo)，这在更新已有布局中的媒体时很常见。

**可以确定嵌入视频的内容类型（MIME）吗？**

可以。嵌入的视频具有可读取的 [content type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType)，例如在保存到磁盘时可以使用该信息。