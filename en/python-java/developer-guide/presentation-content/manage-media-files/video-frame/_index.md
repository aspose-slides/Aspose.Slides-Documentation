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
- retrive video
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

A well-placed video in a presentation can make your message more compelling and increase engagement levels with your audience.

PowerPoint allows you to add videos to a slide in a presentation in two ways:

* Add or embed a local video (stored on your machine)
* Add an online video (from a web source such as YouTube).

To allow you to add videos (video objects) to a presentation, Aspose.Slides provides the [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) class, [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) class, and other relevant types.

## **Create Embedded Video Frames**

If the video file you want to add to your slide is stored locally, you can create a video frame to embed the video in your presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add a [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) object and pass the video file data to embed the video in the presentation.
1. Add a [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) object to create a frame for the video.
1. Save the modified presentation.

This Python code shows you how to add a video stored locally to a presentation:

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

Alternatively, you can add a video by passing its file path directly to the [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame) method:

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


## **Create Video Frames with Video from Web Sources**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) support YouTube videos in presentations. If the video you want to use is available online (e.g. on YouTube), you can add it to your presentation through its web link.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add a [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) object and pass the link to the video.
1. Set a thumbnail for the video frame.
1. Save the presentation.

This Python code shows you how to add a video from the web to a slide in a PowerPoint presentation:

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

    # Load the thumbnail.
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

## **Trim a Video Frame**

Aspose.Slides allows you to control which part of a video is played by setting the trim-from-start and trim-from-end values through [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) and [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd). Both values are specified in milliseconds and define how much time is skipped from the beginning and end of the video, respectively. These settings change the video playback settings in the presentation; they do not cut or otherwise modify the embedded video binary data.

**Set Trim Settings**

To create a video frame and set its trim settings:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Add a [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) object to the presentation.
1. Add a [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) object to a slide.
1. Set the trim-from-start and trim-from-end values through [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) and [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd).
1. Save the modified presentation.

The following code example skips the first 2.5 seconds and the last second of an embedded video during playback:

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

**Read Trim Settings**

To inspect existing trim settings, load a presentation, find a [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) object among the shapes on the first slide, and read the values through [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getTrimFromStart) and [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getTrimFromEnd).

The following code example finds the first video frame on the first slide and reports its trim settings in milliseconds:

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

To add captions to a video frame:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Add a video to the presentation.
1. Add a [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) object to a slide.
1. Use the [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) returned by [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) to add a WebVTT caption track.
1. Save the modified presentation.

The following code shows you how to add captions to a video frame:

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

    # Add a new caption track from a WebVTT file.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) class also provides an overload that lets you add captions from a stream.

**Extract Captions from a Video Frame**

To extract captions from a video frame:

1. Load the presentation that contains the video.
1. Find the target [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) object.
1. Iterate through the caption tracks in the [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/).
1. Save each caption track to a `.vtt` file.

The following code shows you how to extract captions from a video frame:

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
                # Save the caption track to a WebVTT file.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Each [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) object exposes the caption identifier, label, binary data, and caption text as a UTF-8 string.

**Remove Captions from a Video Frame**

To remove captions from a video frame:

1. Load the presentation that contains the video.
1. Get the target [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) object.
1. Remove caption tracks from the [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/).
1. Save the modified presentation.

The following code shows you how to remove all captions from a video frame:

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

## **Extract Video from Slides**

Besides adding videos to slides, Aspose.Slides allows you to extract videos embedded in presentations.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class to load the presentation containing the video.
2. Iterate through all the [Slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) objects.
3. Iterate through all the [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) objects to find a [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).
4. Save the video to disk.

This Python code shows you how to extract the video on a presentation slide:

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

**Which video playback parameters can be changed for a VideoFrame?**

You can control the [playback mode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (auto or on click) and [looping](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). These options are available via the [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) object's properties.

**Does adding a video affect the PPTX file size?**

Yes. When you embed a local video, the binary data is included in the document, so the presentation size grows in proportion to the file size. When you add an online video, a link and a thumbnail are embedded, so the size increase is smaller.

**Can I replace the video in an existing VideoFrame without changing its position and size?**

Yes. You can swap the [video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) within the frame while preserving the shape's geometry; this is a common scenario for updating media in an existing layout.

**Can the content type (MIME) of an embedded video be determined?**

Yes. An embedded video has a [content type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) that you can read and use, for example when saving it to disk.
