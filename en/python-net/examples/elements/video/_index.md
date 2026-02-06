---
title: Video
type: docs
weight: 80
url: /python-net/examples/elements/video/
keywords:
- video
- video frame
- add video
- access video
- remove video
- video playback
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Work with video in Python using Aspose.Slides: insert, replace, trim, set poster frames and playback options, and export presentations for PPT, PPTX and ODP."
---

Shows how to embed video frames and set playback options using **Aspose.Slides for Python via .NET**.

## **Add a Video Frame**

Insert an empty video frame onto a slide.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Add a video frame.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Video Frame**

Retrieve the first video frame added to a slide.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Access the first video frame on the slide.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **Remove a Video Frame**

Delete a video frame from the slide.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the first shape is a video frame.
        video_frame = slide.shapes[0]

        # Remove the video frame.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Video Playback**

Configure the video to play automatically when the slide is displayed.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the first shape is a video frame.
        video_frame = slide.shapes[0]

        # Configure the video to play automatically.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```
