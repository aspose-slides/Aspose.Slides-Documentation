---
title: Manage Video Frames in Presentations in .NET
linktitle: Video Frame
type: docs
weight: 10
url: /net/video-frame/
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
- .NET
- C#
- Aspose.Slides
description: "Learn to programmatically add and extract video frames in PowerPoint and OpenDocument slides using Aspose.Slides for .NET. Fast how-to guide."
---

## **Introduction**

Videos can help explain ideas and engage an audience. Aspose.Slides for .NET lets you add video frames to slides, adjust playback settings, manage captions, and extract embedded video data.

PowerPoint supports local videos and links to online videos, such as YouTube videos.

To represent video data and video frames, Aspose.Slides provides the [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) interface, [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) interface, and other relevant types.

## **Create an Embedded Video Frame**

If the video file you want to add to your slide is stored locally, you can create a video frame to embed the video in your presentation.

This example embeds a local video on the first slide of an existing presentation and saves the result. Frame coordinates and dimensions are in points. The stream stays open until saving finishes because [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) keeps it locked while the presentation uses it.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

You can also pass a local video path directly to [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). This example embeds the video on the first slide of a new presentation. The video must remain accessible until the presentation is saved.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Create a Video Frame with Video from a Web Source**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) supports online videos in presentations. You can create a video frame that links to an online video, such as a YouTube video.

This example adds a YouTube video link and thumbnail to the first slide. Replace the video identifier to use another video. The [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) setting requests automatic playback. Downloading the thumbnail and playing the video require internet access. The presentation viewer must also support online video playback.

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **Play a Video in Full-Screen Mode**

In a training presentation, you can play a software demonstration in full-screen mode so the audience can see the details. Set [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) to `true` to enable this behavior during playback.

This example opens a presentation, finds the first [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) on the first slide, and enables full-screen playback. The input presentation must contain at least one slide with an existing video frame on the first slide.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

Full-screen playback controls how the video is displayed. Independently, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) controls whether it starts automatically or on click, and [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) controls whether it repeats. To choose the start behavior, set the playback mode to [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). The example preserves the existing start and loop settings.

## **Rewind a Video After Playback**

In a training presentation, returning a demonstration video to its beginning makes it ready for the presenter to play again. Set [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) to `true` to return the video to the beginning after playback finishes.

This example opens a presentation, finds the first [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) on the first slide, and enables rewinding. It disables looping so playback can finish and sets playback to start on click. The input presentation must contain at least one slide with an existing video frame on the first slide.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

Rewinding returns the video to its beginning without starting it again. In contrast, enabling [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) repeats playback automatically. Keep looping disabled when you want the video to finish and remain ready to replay. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) independently controls automatic or on-click startup; this example uses [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) so the presenter controls when playback starts. Set the playback mode after the loop setting, as shown in the example. Rewinding works independently of [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Trim a Video Frame**

Use [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) and [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) to skip part of the beginning or end of a video during playback. Both values are in milliseconds. Trimming changes playback settings without modifying the embedded video data.

**Set Trim Settings**

This example embeds a local video and skips the first 2.5 seconds and the last second during playback. Use a video longer than 3.5 seconds so a playable segment remains.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Read Trim Settings**

This example prints the trim values of the first video frame on the first slide in milliseconds. The presentation must contain at least one slide. If that slide has no video frame, nothing is printed. The preceding example produces values of 2500 and 1000.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **Manage Video Captions**

Aspose.Slides allows you to manage closed captions for video frames in PowerPoint presentations. Captions are stored in WebVTT format and are exposed through the [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) property.

**Add Captions to a Video Frame**

This example embeds a local video and adds a WebVTT caption track labeled English. The caption timestamps should match the video. The saved presentation includes both the video and its captions.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

The [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) interface also provides an overload that lets you add captions from a stream.

**Extract Captions from a Video Frame**

This example saves all caption tracks from video frames on the first slide as separate WebVTT files. Sequential numbers keep the output files distinct. The console reports the number of extracted tracks. The presentation must contain at least one slide.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

Each [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) object exposes the caption identifier, label, binary data, and caption text as a UTF-8 string.

**Remove Captions from a Video Frame**

This example removes all captions from the video frame at the first shape position on the first slide and saves the result. It assumes that the slide and shape exist and that the shape is a video frame.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

If you need to remove only one caption track, use the [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) or [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) methods instead of [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **Extract Video from a Slide**

Besides adding videos to slides, Aspose.Slides allows you to extract videos embedded in presentations.

This example extracts embedded videos from every slide into separate, numbered binary files. Linked videos are skipped because they have no embedded data. The console prints each video’s MIME type and the total count. Output uses the generic `.bin` extension; change it to match the reported media type when needed.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **FAQ**

**Which video playback parameters can be changed for a video frame?**

You can control the [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (auto or on click) and [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). These options are available via the [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) object's properties.

**Does adding a video affect the PPTX file size?**

Yes. When you embed a local video, the binary data is included in the document, so the presentation size grows in proportion to the file size. When you link to an online video and add a thumbnail, the presentation stores the link and preview image rather than the video data, so the size increase is usually smaller.

**Can I replace the video in an existing video frame without changing its position and size?**

Yes. You can swap the [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) within the frame while preserving the shape's geometry; this is a common scenario for updating media in an existing layout.

**Can the content type (MIME) of an embedded video be determined?**

Yes. An embedded video has a [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) that you can read and use, for example when saving it to disk.
