---
title: "Convert Presentation Formats"
type: docs
weight: 10
url: /net/examples/conversion-rendering/presentation-formats/
description: "Runnable C# example for convert presentation formats using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

The sample exports PPTX, PPT and ODP, reopens each file and writes a PPTX copy from each input format. It checks text and slide counts and produces a preview for each result. Format-specific features may be changed or omitted; inspect the features your deck uses.

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

    private static void ConvertFormats(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        (SaveFormat Format, string Extension)[] formats =
        [
            (SaveFormat.Pptx, "pptx"),
            (SaveFormat.Ppt, "ppt"),
            (SaveFormat.Odp, "odp")
        ];
        int checks = 0;
        foreach (var (format, extension) in formats)
        {
            source.Save("converted." + extension, format);
            using var reopened = new Presentation("converted." + extension);
            if (reopened.Slides.Count != 4) throw new InvalidOperationException("Slide count changed.");
            string text = string.Join(" ", reopened.Slides.SelectMany(s => s.Shapes.OfType<IAutoShape>()).Select(s => s.TextFrame.Text));
            if (!text.Contains("Alpha") || !text.Contains(licensed ? "Hidden" : "Hide")) throw new InvalidOperationException("Text changed.");
            reopened.Save("from-" + extension + ".pptx", SaveFormat.Pptx);
            using var preview = reopened.Slides[0].GetImage(new Size(320, 180));
            preview.Save("preview-" + extension + ".png", Aspose.Slides.ImageFormat.Png);
            checks++;
        }
        Report(new { formats_checked = checks, slides_per_deck = 4 });
    }
}
```

## Expected result

The program writes "converted.pptx", "converted.ppt", "converted.odp", "from-pptx.pptx", "from-ppt.pptx", "from-odp.pptx", "preview-pptx.png", "preview-ppt.png", "preview-odp.png" in the printed output directory, plus the synthetic source.pptx and a result.json summary. Inspect the rendered/exported files with the viewer appropriate to the format. Input generation is visible in CreateSource; replace it with opening your own presentation when adapting the example.

Continue with the [detailed guide](/slides/net/convert-ppt-to-pptx/).


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
