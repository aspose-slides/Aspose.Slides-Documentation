---
title: "Render Slides as Images"
type: docs
weight: 60
url: /net/examples/conversion-rendering/images/
description: "Runnable C# example for render slides as images using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

Render PNG/JPEG images and small previews at explicit pixel dimensions. The source is 16:9 and the requested sizes use the same ratio. Choose matching dimensions to avoid distortion; preserve or pad the aspect ratio in your application when a fixed container has a different shape. This explicit loop also renders the hidden slide.

## Run the example

[Download the complete project](example.zip). It includes the solution, source, SDK settings, package configuration and required fixtures. The code creates its own four-slide input with a hidden slide, speaker notes, a table, chart and picture.

This download uses Aspose.Slides.NET6.CrossPlatform 26.10.0, bundled Noto Sans fonts and original portable PNG fixtures. Open the supplied solution with a compatible stable SDK; the current .NET 10 LTS is recommended. Evaluation runs without a license; unrestricted assertions use your authorized license. See [setup and prerequisites](/slides/net/examples/getting-started/) for native dependencies and tool selection.

```text
dotnet run --project Example.csproj --configuration Release
```

## Complete C# example

```csharp
using System.Threading.Tasks;
using System;
using System.IO;
using System.Linq;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);

    private static void RenderSlides(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        for (int i = 0; i < source.Slides.Count; i++)
        {
            using var image = source.Slides[i].GetImage(new Size(640, 360));
            image.Save($"slide-{i + 1}.png", Aspose.Slides.ImageFormat.Png);
            image.Save($"slide-{i + 1}.jpg", Aspose.Slides.ImageFormat.Jpeg);
            using var thumbnail = source.Slides[i].GetImage(new Size(160, 90));
            thumbnail.Save($"thumbnail-{i + 1}.png", Aspose.Slides.ImageFormat.Png);
        }
        Report(new { rendered_slides = source.Slides.Count, width = 640, height = 360, thumbnail_width = 160, thumbnail_height = 90 });
    }
}
```

## Expected result

The program writes "slide-1.png", "slide-1.jpg", "thumbnail-1.png", "slide-2.png", "slide-2.jpg", "thumbnail-2.png", "slide-3.png", "slide-3.jpg", "thumbnail-3.png", "slide-4.png", "slide-4.jpg", "thumbnail-4.png" in the printed output directory, plus the synthetic source.pptx and a result.json summary. Inspect the rendered/exported files with the viewer appropriate to the format. Input generation is visible in CreateSource; replace it with opening your own presentation when adapting the example.

Continue with the [detailed guide](/slides/net/convert-powerpoint-to-png/).


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
