---
title: Video
type: docs
weight: 80
url: /net/examples/elements/video/
keywords:
- code example
- video
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Add and control videos with Aspose.Slides for .NET: insert, play, trim, set poster frames, and export with C# examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates how to embed video frames and set playback options using **Aspose.Slides for .NET**.

## **Add a Video Frame**

Insert an empty video frame onto a slide.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Add a video.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **Access a Video Frame**

Retrieve the first video frame added to a slide.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Access the first video frame on the slide.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **Remove a Video Frame**

Delete a video frame from the slide.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Remove the video frame.
    slide.Shapes.Remove(videoFrame);
}
```

## **Set Video Playback**

Configure the video to play automatically when the slide is displayed.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Configure the video to play automatically.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```
