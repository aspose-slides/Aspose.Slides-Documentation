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

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add a Video Frame**

Insert an empty video frame onto a slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Add a video.
        var video = presentation.Videos.AddVideo(File.ReadAllBytes(Context.Input("video.mp4")));
        var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, video);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IVideoFrame>().Single().EmbeddedVideo.BinaryData.SequenceEqual(File.ReadAllBytes(Context.Input("video.mp4"))), "AddVideo: semantic check 1 failed.");
        });
        Context.Pass("elements/video/block-001", "AddVideo", "save-reopen-structure");
    }
}
```

## **Access a Video Frame**

Retrieve the first video frame added to a slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var video = presentation.Videos.AddVideo(File.ReadAllBytes(Context.Input("video.mp4")));
        var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, video);

        // Access the first video frame on the slide.
        var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IVideoFrame>().Single().EmbeddedVideo.BinaryData.Length > 100, "AccessVideo: semantic check 1 failed.");
        });
        Context.Pass("elements/video/block-002", "AccessVideo", "save-reopen-structure");
    }
}
```

## **Remove a Video Frame**

Delete a video frame from the slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var video = presentation.Videos.AddVideo(File.ReadAllBytes(Context.Input("video.mp4")));
        var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, video);

        // Remove the video frame.
        slide.Shapes.Remove(videoFrame);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IVideoFrame>().Any(), "RemoveVideo: semantic check 1 failed.");
        });
        Context.Pass("elements/video/block-003", "RemoveVideo", "save-reopen-structure");
    }
}
```

## **Set Video Playback**

Configure the video to play automatically when the slide is displayed.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var video = presentation.Videos.AddVideo(File.ReadAllBytes(Context.Input("video.mp4")));
        var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, video);

        // Configure the video to play automatically.
        videoFrame.PlayMode = VideoPlayModePreset.Auto;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IVideoFrame>().Single().PlayMode == VideoPlayModePreset.Auto, "SetVideoPlayback: semantic check 1 failed.");
        });
        Context.Pass("elements/video/block-004", "SetVideoPlayback", "save-reopen-structure");
    }
}
```
