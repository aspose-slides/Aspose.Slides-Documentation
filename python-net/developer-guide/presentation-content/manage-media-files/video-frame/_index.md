---
title: Video Frame
type: docs
weight: 10
url: /python-net/video-frame/
keywords: "Add video, create video frame, extract video, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add Video frame to PowerPoint presentation in Python"
---


## **Create Embedded Video Frame**
Developers can also add and play video files in the slides to enrich their presentations. Aspose.Slides for Python via .NET supports adding Video Frames to the slides that make it possible for developers to add videos to their presentations. This topic will help developers to follow the simple steps with examples for adding video frames in their slides. To add a Video Frame in a slide using Aspose.Slides for Python via .NET, please follow the steps below:

1. Create an instance of [Presentation ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/)class.
1. Obtain the reference of a slide by using its Index.
1. Add the Video Frame (containing the video file name) into the slide.
1. Write the modified presentation as a PPTX file.

In the example below, we added a Video Frame into the slide.

```py
import aspose.slides as slides

# Instantiate Presentation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Embedd vide inside presentation
    with open(path + "Wildlife.mp4", "rb") as in_file:
        vid = pres.videos.add_video(in_file)

        # Add Video Frame
        vf = sld.shapes.add_video_frame(50, 150, 300, 350, vid)

        # Set video to Video Frame
        vf.embedded_video = vid

        # Set Play Mode and Volume of the Video
        vf.play_mode = slides.VideoPlayModePreset.AUTO
        vf.volume = slides.AudioVolumeMode.LOUD

    # Write the PPTX file to disk
    pres.save("VideoFrame_out.pptx", slides.export.SaveFormat.PPTX)
```
It is possible to add a video passing path to the video file directly into AddVideoFrame method:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Create Video Frame with Video from Web Source**
PowerPoint 2010 and newer versions support YouTube videos. To play these videos in PowerPoint make sure your [environment meet requirements ](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)for embedding videos from web source.

Follow these steps:

1. Create an instance of [Presentation ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/)class
1. Obtain the reference of a slide by using its Index
1. Add the Video Frame by passing video URL
1. Set Image for Video Frame
1. Save presentation as a PPTX file

This sample code shows you how to to add a video from YouTube to your presentation using Aspose.Slides:

```py
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    #add videoFrame
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # load thumbnail
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Extract Video From Slide**
Aspose.Slides for Python via .NET supports extracting video from the slide. In order to extract the video. Please follow the steps below:

- Load a Presentation containing a video.
- Loop through all the slides of the [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/).
- Search for Video Frame.
- Save the Video to disk.
  In the example given below, we have saved the video file from a slide.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

