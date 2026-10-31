---
title: Audio
type: docs
weight: 70
url: /net/examples/elements/audio/
keywords:
- audio
- audio frame
- add audio
- access audio
- remove audio
- audio playback
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Discover Aspose.Slides for .NET audio examples: insert, play, trim, and extract sound in PPT, PPTX, and ODP presentations with clear C# code."
---

This article demonstrates how to embed audio frames and control playback with **Aspose.Slides for .NET**. The following examples show basic audio operations.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add an Audio Frame**

Insert an empty audio frame that can later hold embedded sound data.

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
        using var audioStream = File.OpenRead(Context.Input("tone.wav"));

        // Embed the complete packaged PCM WAV tone.
        var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAudioFrame>().Single().EmbeddedAudio.BinaryData.SequenceEqual(File.ReadAllBytes(Context.Input("tone.wav"))), "AddAudio: semantic check 1 failed.");
        });
        Context.Pass("elements/audio/block-001", "AddAudio", "save-reopen-structure");
    }
}
```

## **Access an Audio Frame**

This code retrieves the first audio frame on a slide.

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
        using var audioStream = File.OpenRead(Context.Input("tone.wav"));

        slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);

        // Access the first audio frame on the slide.
        var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAudioFrame>().Single().EmbeddedAudio.BinaryData.Length > 44, "AccessAudio: semantic check 1 failed.");
        });
        Context.Pass("elements/audio/block-002", "AccessAudio", "save-reopen-structure");
    }
}
```

## **Remove an Audio Frame**

Delete a previously added audio frame.

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
        using var audioStream = File.OpenRead(Context.Input("tone.wav"));

        var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);

        // Remove the audio frame.
        slide.Shapes.Remove(audioFrame);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IAudioFrame>().Any(), "RemoveAudio: semantic check 1 failed.");
        });
        Context.Pass("elements/audio/block-003", "RemoveAudio", "save-reopen-structure");
    }
}
```

## **Set Audio Playback**

Configure the audio frame to play automatically when the slide appears.

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
        using var audioStream = File.OpenRead(Context.Input("tone.wav"));
        
        var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);

        // Play automatically when the slide appears.
        audioFrame.PlayMode = AudioPlayModePreset.Auto;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAudioFrame>().Single().PlayMode == AudioPlayModePreset.Auto, "SetAudioPlayback: semantic check 1 failed.");
        });
        Context.Pass("elements/audio/block-004", "SetAudioPlayback", "save-reopen-structure");
    }
}
```
