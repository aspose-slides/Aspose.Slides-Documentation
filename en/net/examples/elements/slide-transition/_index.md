---
title: Slide Transition
type: docs
weight: 110
url: /net/examples/elements/slide-transition/
keywords:
- slide transition
- add slide transition
- access slide transition
- remove slide transition
- slide advance timing
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Add, read and remove slide transitions, and set slide advance timing with Aspose.Slides for .NET C# examples."
---

This article demonstrates applying slide transition effects and timings with **Aspose.Slides for .NET**.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks. The copied code runs in evaluation mode. For licensed output, apply your license before creating a presentation, as described in the [licensing guide](/slides/net/licensing/).

## **Download and run**

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add a Slide Transition**

Apply a fade transition effect to the first slide.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.SlideShowTransition.Type = TransitionType.Fade;

presentation.Save("slide-transition-01.pptx", SaveFormat.Pptx);
```

## **Access a Slide Transition**

Read the transition type currently assigned to a slide.

```csharp
using System;
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.SlideShowTransition.Type = TransitionType.Push;

// Access the transition type.
var type = slide.SlideShowTransition.Type;
Console.WriteLine($"Transition: {type}");

presentation.Save("slide-transition-02.pptx", SaveFormat.Pptx);
```

## **Remove a Slide Transition**

Clear any transition effect by setting the type to `None`.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.SlideShowTransition.Type = TransitionType.Fade;

slide.SlideShowTransition.Type = TransitionType.None;

presentation.Save("slide-transition-03.pptx", SaveFormat.Pptx);
```

<a id="set-transition-duration"></a>

## **Set Slide Advance Timing**

Allow a click to advance the slide, or advance automatically after 2,000 milliseconds. Setting the advance-after time also enables timed advance in the supported SDK.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.SlideShowTransition.AdvanceOnClick = true;
slide.SlideShowTransition.AdvanceAfterTime = 2000; // in milliseconds

presentation.Save("slide-transition-04.pptx", SaveFormat.Pptx);
```
