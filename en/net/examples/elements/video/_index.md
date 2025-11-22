---
title: Video
type: docs
weight: 80
url: /net/examples/elements/video/
keywords:
- video example
- video frame
- add video
- access video
- remove video
- video playback
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Work with video in C# using Aspose.Slides: insert, replace, trim, set poster frames and playback options, and export presentations for PPT, PPTX and ODP."
---

Shows how to embed video frames and set playback options using **Aspose.Slides for .NET**.

## Add a Video Frame

Insert an empty video frame onto a slide.

```csharp
static void Add_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Add an empty embedded video frame
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## Access a Video Frame

Retrieve the first video frame added to a slide.

```csharp
static void Access_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Access the first video frame on the slide
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## Remove a Video Frame

Delete a video frame from the slide.

```csharp
static void Remove_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Remove the video frame
    slide.Shapes.Remove(videoFrame);
}
```

## Set Video Playback

Configure the video to play automatically when the slide is displayed.

```csharp
static void Set_Video_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Configure the video to play automatically
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```
