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

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks. The copied code runs in evaluation mode. For licensed output, apply your license before creating a presentation, as described in the [licensing guide](/slides/net/licensing/).

## **Download and run**

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add an Audio Frame**

Embed the short PCM WAV tone included in the program. No audio file is required.

```csharp
using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
// Small PCM WAV fixture; no audio file is required.
const string wavBase64 =
    "UklGRnQAAABXQVZFZm10IBAAAAABAAEAQB8AAEAfAAABAAgAZGF0YVAAAACAmK6+x8e/sJuCalRD" +
    "OjlAT2N7lKq8xsjBs5+HblhGOzg+TF93kKe5xMjDtqOLc1tJPDg8SVtzi6O2w8jEuaeQd19MPjg7" +
    "Rlhuh5+zwcjGvA==";
var wavData = Convert.FromBase64String(wavBase64);
using var audioStream = new MemoryStream(wavData);

// Embed a short PCM WAV tone.
slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);

presentation.Save("audio-01.pptx", SaveFormat.Pptx);
```

## **Access an Audio Frame**

This code retrieves the first audio frame on a slide.

```csharp
using System;
using System.IO;
using Aspose.Slides.Export;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
// Small PCM WAV fixture; no audio file is required.
const string wavBase64 =
    "UklGRnQAAABXQVZFZm10IBAAAAABAAEAQB8AAEAfAAABAAgAZGF0YVAAAACAmK6+x8e/sJuCalRD" +
    "OjlAT2N7lKq8xsjBs5+HblhGOzg+TF93kKe5xMjDtqOLc1tJPDg8SVtzi6O2w8jEuaeQd19MPjg7" +
    "Rlhuh5+zwcjGvA==";
var wavData = Convert.FromBase64String(wavBase64);
using var audioStream = new MemoryStream(wavData);

slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);

// Access the first audio frame on the slide.
var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
Console.WriteLine(firstAudio.EmbeddedAudio.BinaryData.Length);

presentation.Save("audio-02.pptx", SaveFormat.Pptx);
```

## **Remove an Audio Frame**

Delete a previously added audio frame.

```csharp
using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
// Small PCM WAV fixture; no audio file is required.
const string wavBase64 =
    "UklGRnQAAABXQVZFZm10IBAAAAABAAEAQB8AAEAfAAABAAgAZGF0YVAAAACAmK6+x8e/sJuCalRD" +
    "OjlAT2N7lKq8xsjBs5+HblhGOzg+TF93kKe5xMjDtqOLc1tJPDg8SVtzi6O2w8jEuaeQd19MPjg7" +
    "Rlhuh5+zwcjGvA==";
var wavData = Convert.FromBase64String(wavBase64);
using var audioStream = new MemoryStream(wavData);

var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);

// Remove the audio frame.
slide.Shapes.Remove(audioFrame);

presentation.Save("audio-03.pptx", SaveFormat.Pptx);
```

## **Set Audio Playback**

Configure the audio frame to play automatically when the slide appears.

```csharp
using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
// Small PCM WAV fixture; no audio file is required.
const string wavBase64 =
    "UklGRnQAAABXQVZFZm10IBAAAAABAAEAQB8AAEAfAAABAAgAZGF0YVAAAACAmK6+x8e/sJuCalRD" +
    "OjlAT2N7lKq8xsjBs5+HblhGOzg+TF93kKe5xMjDtqOLc1tJPDg8SVtzi6O2w8jEuaeQd19MPjg7" +
    "Rlhuh5+zwcjGvA==";
var wavData = Convert.FromBase64String(wavBase64);
using var audioStream = new MemoryStream(wavData);

var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);

// Play automatically when the slide appears.
audioFrame.PlayMode = AudioPlayModePreset.Auto;

presentation.Save("audio-04.pptx", SaveFormat.Pptx);
```
