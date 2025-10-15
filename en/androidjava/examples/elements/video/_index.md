---
title: Video
type: docs
weight: 80
url: /androidjava/examples/elements/video/
keywords:
- code example
- video
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Add and control videos with Aspose.Slides for Android: insert, play, trim, set poster frames, and export with Java examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates how to embed video frames and set playback options using **Aspose.Slides for Android via Java**.

## **Add a Video Frame**

Insert an empty video frame onto a slide.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Add a video.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Video Frame**

Retrieve the first video frame added to a slide.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Access the first video frame on the slide.
        IVideoFrame firstVideo = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                firstVideo = (IVideoFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Video Frame**

Delete a video frame from the slide.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Remove the video frame.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Set Video Playback**

Configure the video to play automatically when the slide is displayed.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Configure the video to play automatically.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```
