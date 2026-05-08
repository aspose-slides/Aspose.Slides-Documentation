---
title: Add Videos to Presentations in Python
linktitle: Video Frame
type: docs
weight: 10
url: /python-net/video-frame/
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
description: "Learn to programmatically add and extract video frames in PowerPoint and OpenDocument slides using Aspose.Slides for Python via .NET. Fast how-to guide."
---

## **Introduction**

A well-placed video in a presentation can make your message more compelling and increase engagement levels with your audience. 

PowerPoint allows you to add videos to a slide in a presentation in two ways:

* Add or embed a local video (stored on your machine)
* Add an online video (from a web source such as YouTube).

To allow you to add videos (video objects) to a presentation, Aspose.Slides provides the [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) class, [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) class, and other relevant types. 

## **Create Embedded Video Frame**

If the video file you want to add to your slide is stored locally, you can create a video frame to embed the video in your presentation. 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a slide's reference through its index. 
1. Add a [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) object and pass the video file path to embed the video with the presentation. 
1. Add a [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) object to create a frame for the video.  
1. Save the modified presentation. 

This Python code shows you how to add a video stored locally to a presentation:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Gets the first slide and adds a videoframe
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Saves the presentation to disk
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Alternatively, you can add a video by passing its file path directly to the `add_video_frame(x, y, width, height, fname)`  method:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Create Video Frame with Video from Web Source**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) support YouTube videos in presentations. If the video you want to use is available online (e.g. on YouTube), you can add it to your presentation through its web link. 

1. Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class
1. Get a slide's reference through its index. 
1. Add a [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) object and pass the link to the video.
1. Set a thumbnail for the video frame. 
1. Save the presentation. 

This Python code shows you how to add a video from the web to a slide in a PowerPoint presentation:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Adds a videoFrame
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Loads thumbnail
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Manage Video Captions**

Aspose.Slides allows you to manage closed captions for video frames in PowerPoint presentations. Captions are stored in WebVTT format and are exposed through the [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) property.

**Add Captions to a Video Frame**

To add captions to a video frame:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Add a video to the presentation.
1. Add a [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) object to a slide.
1. Use the [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) returned by [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) to add a WebVTT caption track.
1. Save the modified presentation.

The following code shows you how to add captions to a video frame:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Adds a new captions track from a WebVTT file.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

The [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) class also provides an overload that lets you add captions from a stream.

**Extract Captions from a Video Frame**

To extract captions from a video frame:

1. Load the presentation that contains the video.
1. Find the target [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) object.
1. Iterate through the [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) collection.
1. Save each caption track to a `.vtt` file.

The following code shows you how to extract captions from a video frame:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # Saves the captions track to a WebVTT file.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Each [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) object exposes the caption identifier, label, binary data, and caption text as a UTF-8 string.

**Remove Captions from a Video Frame**

To remove captions from a video frame:

1. Load the presentation that contains the video.
1. Get the target [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) object.
1. Remove caption tracks from the [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/).
1. Save the modified presentation.

The following code shows you how to remove all captions from a video frame:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # type: slides.VideoFrame

    # Removes all captions from the video frame.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

If you need to remove only one caption track, use the [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) or [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) methods instead of [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

## **Extract Video From Slide**

Besides adding videos to slides, Aspose.Slides allows you to extract videos embedded in presentations.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class to load the presentation containing the video. 
2. Iterate through all the [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) objects.
3. Iterate through all the [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) objects to find a [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/). 
4. Save the video to disk.

This Python code shows you how to extract the video on a presentation slide:

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a presentation file 
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**Which video playback parameters can be changed for a VideoFrame?**

You can control the [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (auto or on click) and [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). These options are available via the [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) object's properties.

**Does adding a video affect the PPTX file size?**

Yes. When you embed a local video, the binary data is included in the document, so the presentation size grows in proportion to the file size. When you add an online video, a link and a thumbnail are embedded, so the size increase is smaller.

**Can I replace the video in an existing VideoFrame without changing its position and size?**

Yes. You can swap the [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) within the frame while preserving the shape's geometry; this is a common scenario for updating media in an existing layout.

**Can the content type (MIME) of an embedded video be determined?**

Yes. An embedded video has a [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) that you can read and use, for example when saving it to disk.
