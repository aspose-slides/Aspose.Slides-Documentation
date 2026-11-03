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

```csharp
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);

    private static void ExportGif(bool licensed)
    {
        using var presentation = CreateSource(licensed);
        var options = new GifOptions
        {
            FrameSize = new Size(320, 180),
            DefaultDelay = 1000,
            TransitionFps = 10
        };

        presentation.Save("source.pptx", SaveFormat.Pptx);
        const string gifPath = "slides.gif";
        presentation.Save(gifPath, SaveFormat.Gif, options);

        Report(new
        {
            gif_created = File.Exists(gifPath),
            frame_width = options.FrameSize.Width,
            frame_height = options.FrameSize.Height,
            slide_delay_ms = options.DefaultDelay
        });
    }
}
```

## Expected result

The program writes "slides.gif" in the printed output directory, plus the synthetic source.pptx and a result.json summary. Inspect the rendered/exported files with the viewer appropriate to the format. Input generation is visible in CreateSource; replace it with opening your own presentation when adapting the example.

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
