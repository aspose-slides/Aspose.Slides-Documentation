---
title: Video
type: docs
weight: 80
url: /net/examples/elements/video/
keywords:
- video
- video frame
- add video
- access video
- remove video
- video playback
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Add and control videos with Aspose.Slides for .NET: insert, play, trim, set poster frames, and export with C# examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates how to embed video frames and set playback options using **Aspose.Slides for .NET**.

The checks verify embedded MP4 bytes and playback settings. Actual playback also depends on the presentation application's codec and security support.

For the copied blocks, pass an MP4 file as the first argument, for example `dotnet run -- video.mp4`. You can use your own MP4 or the [sample video](Fixtures/video.mp4).

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks. The copied code runs in evaluation mode. For licensed output, apply your license before creating a presentation, as described in the [licensing guide](/slides/net/licensing/).

## **Download and run**

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add a Video Frame**

Embed the supplied MP4 in a video frame. Pass its path as the program argument; a missing file produces a readable message.

Use `dotnet run -- video.mp4` with the [sample MP4](Fixtures/video.mp4) or your own file.

```csharp
using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides;

// Pass the path to an MP4 file as the first argument.
if (args.Length != 1)
{
    Console.WriteLine("Usage: dotnet run -- <video.mp4>");
    return;
}

var videoPath = args[0];
if (!File.Exists(videoPath))
{
    Console.WriteLine($"Video file not found: {videoPath}");
    return;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Add a video.
var videoData = File.ReadAllBytes(videoPath);
var video = presentation.Videos.AddVideo(videoData);
slide.Shapes.AddVideoFrame(50, 50, 320, 240, video);

presentation.Save("video-01.pptx", SaveFormat.Pptx);
```

## **Access a Video Frame**

Retrieve the first video frame added to a slide.

Use `dotnet run -- video.mp4` with the [sample MP4](Fixtures/video.mp4) or your own file.

```csharp
using System;
using System.IO;
using Aspose.Slides.Export;
using System.Linq;
using Aspose.Slides;

// Pass the path to an MP4 file as the first argument.
if (args.Length != 1)
{
    Console.WriteLine("Usage: dotnet run -- <video.mp4>");
    return;
}

var videoPath = args[0];
if (!File.Exists(videoPath))
{
    Console.WriteLine($"Video file not found: {videoPath}");
    return;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes(videoPath);
var video = presentation.Videos.AddVideo(videoData);
slide.Shapes.AddVideoFrame(50, 50, 320, 240, video);

// Access the first video frame on the slide.
var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
Console.WriteLine(firstVideo.EmbeddedVideo.BinaryData.Length);

presentation.Save("video-02.pptx", SaveFormat.Pptx);
```

## **Remove a Video Frame**

Delete a video frame from the slide.

Use `dotnet run -- video.mp4` with the [sample MP4](Fixtures/video.mp4) or your own file.

```csharp
using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides;

// Pass the path to an MP4 file as the first argument.
if (args.Length != 1)
{
    Console.WriteLine("Usage: dotnet run -- <video.mp4>");
    return;
}

var videoPath = args[0];
if (!File.Exists(videoPath))
{
    Console.WriteLine($"Video file not found: {videoPath}");
    return;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes(videoPath);
var video = presentation.Videos.AddVideo(videoData);
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, video);

// Remove the video frame.
slide.Shapes.Remove(videoFrame);

presentation.Save("video-03.pptx", SaveFormat.Pptx);
```

## **Set Video Playback**

Configure the video to play automatically when the slide is displayed.

Use `dotnet run -- video.mp4` with the [sample MP4](Fixtures/video.mp4) or your own file.

```csharp
using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides;

// Pass the path to an MP4 file as the first argument.
if (args.Length != 1)
{
    Console.WriteLine("Usage: dotnet run -- <video.mp4>");
    return;
}

var videoPath = args[0];
if (!File.Exists(videoPath))
{
    Console.WriteLine($"Video file not found: {videoPath}");
    return;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes(videoPath);
var video = presentation.Videos.AddVideo(videoData);
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, video);

// Configure the video to play automatically.
videoFrame.PlayMode = VideoPlayModePreset.Auto;

presentation.Save("video-04.pptx", SaveFormat.Pptx);
```
