---
title: Manage Video Frames in Presentations Using Python
linktitle: Video Frame
type: docs
weight: 10
url: /python-java/video-frame/
keywords:
- add video
- create video
- embed video
- extract video
- retrieve video
- video frame
- web source
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn to programmatically add and extract video frames in PowerPoint and OpenDocument slides using Aspose.Slides for Python via Java. Fast how-to guide."
---

## **Introduction**

Videos can help explain ideas and engage an audience. Aspose.Slides for Python via Java lets you add video frames to slides, adjust playback settings, manage captions, and extract embedded video data.

PowerPoint supports local videos and links to online videos, such as YouTube videos.

To represent video data and video frames, Aspose.Slides provides the [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) class, [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) class, and other relevant types.

## **Create an Embedded Video Frame**

If the video file you want to add to your slide is stored locally, you can create a video frame to embed the video in your presentation.

This example embeds a local video on the first slide of an existing presentation and saves the result. Frame coordinates and dimensions are in points. Python reads the video bytes from disk, and JPype converts them to a Java byte array before the video is added to the presentation.

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

You can also pass a local video path directly to [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). This example embeds the video on the first slide of a new presentation. The video must remain accessible until the presentation is saved.

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

## **Create a Video Frame with Video from a Web Source**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) supports online videos in presentations. You can create a video frame that links to an online video, such as a YouTube video.

This example adds a YouTube video link and thumbnail to the first slide. Replace the video identifier to use another video. The [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) method requests automatic playback. Downloading the thumbnail and playing the video require internet access. The presentation viewer must also support online video playback.

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

## **Play a Video in Full-Screen Mode**

In a training presentation, you can play a software demonstration in full-screen mode so the audience can see the details. Call [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) with `True` to enable this behavior during playback.

This example opens a presentation, finds the first [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) on the first slide, and enables full-screen playback. The input presentation must contain at least one slide with an existing video frame on the first slide.

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

Full-screen playback controls how the video is displayed. Independently, [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) controls whether it starts automatically or on click, and [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) controls whether it repeats. To choose the start behavior, set the playback mode to [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). The example preserves the existing start and loop settings.

## **Rewind a Video After Playback**

In a training presentation, returning a demonstration video to its beginning makes it ready for the presenter to play again. Call [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) with `True` to return the video to the beginning after playback finishes.

This example opens a presentation, finds the first [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) on the first slide, and enables rewinding. It disables looping so playback can finish and sets playback to start on click. The input presentation must contain at least one slide with an existing video frame on the first slide.

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

Rewinding returns the video to its beginning without starting it again. In contrast, calling [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) with `True` repeats playback automatically. Keep looping disabled when you want the video to finish and remain ready to replay. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) independently controls automatic or on-click startup; this example uses [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) so the presenter controls when playback starts. Set the playback mode after the loop setting, as shown in the example. Rewinding works independently of [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Trim a Video Frame**

Use [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) and [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) to skip part of the beginning or end of a video during playback. Both values are in milliseconds. Trimming changes playback settings without modifying the embedded video data.

**Set Trim Settings**

This example embeds a local video and skips the first 2.5 seconds and the last second during playback. Use a video longer than 3.5 seconds so a playable segment remains.

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

**Read Trim Settings**

This example prints the trim values of the first video frame on the first slide in milliseconds. The presentation must contain at least one slide. If that slide has no video frame, nothing is printed. The preceding example produces values of 2500 and 1000.

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

## **Manage Video Captions**

Aspose.Slides allows you to manage closed captions for video frames in PowerPoint presentations. Captions are stored in WebVTT format and are exposed through the [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) method.

**Add Captions to a Video Frame**

This example embeds a local video and adds a WebVTT caption track labeled English. The caption timestamps should match the video. The saved presentation includes both the video and its captions.

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
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Add a new caption track from a WebVTT file.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) class also provides an overload that lets you add captions from a stream.

**Extract Captions from a Video Frame**

This example saves all caption tracks from video frames on the first slide as separate WebVTT files. Sequential numbers keep the output files distinct. The console reports the number of extracted tracks. The presentation must contain at least one slide.

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

Each [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) object exposes the caption identifier, label, binary data, and caption text as a UTF-8 string.

**Remove Captions from a Video Frame**

This example removes all captions from the video frame at the first shape position on the first slide and saves the result. It assumes that the slide and shape exist and that the shape is a video frame.

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
        # Remove all captions from the video frame.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

If you need to remove only one caption track, use the [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) or [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) methods instead of [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

## **Extract Video from a Slide**

Besides adding videos to slides, Aspose.Slides allows you to extract videos embedded in presentations.

This example extracts embedded videos from every slide into separate, numbered binary files. Linked videos are skipped because they have no embedded data. The console prints each video’s MIME type and the total count. Output uses the generic `.bin` extension; change it to match the reported media type when needed.

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

## **FAQ**

**Which video playback parameters can be changed for a video frame?**

You can control the [playback mode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (auto or on click) and [looping](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). These options are available via the [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) object's methods.

**Does adding a video affect the PPTX file size?**

Yes. When you embed a local video, the binary data is included in the document, so the presentation size grows in proportion to the file size. When you link to an online video and add a thumbnail, the presentation stores the link and preview image rather than the video data, so the size increase is usually smaller.

**Can I replace the video in an existing video frame without changing its position and size?**

Yes. You can swap the [video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) within the frame while preserving the shape's geometry; this is a common scenario for updating media in an existing layout.

**Can the content type (MIME) of an embedded video be determined?**

Yes. An embedded video has a [content type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) that you can read and use, for example when saving it to disk.
