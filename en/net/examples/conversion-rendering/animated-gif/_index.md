---
title: "Export an Animated GIF"
type: docs
weight: 100
url: /net/examples/conversion-rendering/animated-gif/
description: "Runnable C# example for export an animated gif using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

Export the fixture as an animated GIF with a chosen frame size, slide delay and transition frame rate. GIF is a rendered animation, so its text and shapes are not editable. Inspect decoded frames and timing; supported transition rendering does not imply that every PowerPoint effect or interactive trigger is reproduced.

## Run the example

[Download the complete project](example.zip). It includes the solution, source, SDK settings, package configuration and required fixtures. The code creates its own four-slide input with a hidden slide, speaker notes, a table, chart and picture.

This download uses Aspose.Slides.NET6.CrossPlatform 26.10.0, bundled Noto Sans fonts and original portable PNG fixtures. Open the supplied solution with a compatible stable SDK; the current .NET 10 LTS is recommended. Evaluation runs without a license; unrestricted assertions use your authorized license. See [setup and prerequisites](/slides/net/examples/getting-started/) for native dependencies and tool selection.

```text
dotnet run --project Example.csproj --configuration Release
```

## Complete C# example

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();
var first = presentation.Slides[0];
var second = presentation.Slides.AddEmptySlide(first.LayoutSlide);

first.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 60, 350, 140)
    .TextFrame.Text = "First";
second.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 90, 350, 140)
    .TextFrame.Text = "Next";
first.SlideShowTransition.Type = TransitionType.Fade;
second.SlideShowTransition.Type = TransitionType.Fade;

var options = new GifOptions
{
    FrameSize = new Size(320, 180),
    DefaultDelay = 1000,
    TransitionFps = 10
};

presentation.Save("slides.gif", SaveFormat.Gif, options);
Console.WriteLine("Saved slides.gif");
```

## Expected result

The copied program writes `slides.gif` in the working directory. The downloaded project writes the GIF, `source.pptx`, and `result.json` in its printed output directory. Open the GIF in an image viewer to check its frames and timing.

Continue with the [detailed guide](/slides/net/convert-powerpoint-to-animated-gif/).


## Open and run the complete project

[Download the complete project](example.zip), extract it and open `Example.sln`, or run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release -- --mode evaluation
```

Use the current supported .NET 10 SDK/runtime. The project keeps a stable `net8.0`
target and accepts compatible stable SDKs; no exact SDK patch is required.
Evaluation runs without a license and explicitly ignores license environment settings.
It uses bounded fixtures and checks valid output while allowing the evaluation watermark
and documented read-back text truncation. For unrestricted checks, use `--mode licensed`
with your authorized `ASPOSE_LICENSE_PATH`. No license is included.

Inputs are copied from `Fixtures` into a separate output workspace. The program prints
the absolute output path; `execution.json` records the actual runtime and verified action.
The portable PNG helper creates original synthetic pixels without a Windows bitmap engine.
See [setup and prerequisites](/slides/net/examples/getting-started/) for native libraries,
fonts, IDE settings and the .NET 8/9 runtime support boundary of 2026-11-10.
