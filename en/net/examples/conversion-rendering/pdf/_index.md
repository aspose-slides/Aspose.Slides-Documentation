---
title: "Export Presentations to PDF"
type: docs
weight: 20
url: /net/examples/conversion-rendering/pdf/
description: "Runnable C# example for export presentations to pdf using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

Export visible slides, include hidden slides deliberately, or specify one-based slide positions in the desired order. JPEG quality and resolution influence images; they do not guarantee a particular file size. This fixture includes text, a chart, a table and an image.

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

    private static void ExportPdf(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        source.Save("visible.pdf", SaveFormat.Pdf, new PdfOptions { ShowHiddenSlides = false });
        source.Save("all-slides.pdf", SaveFormat.Pdf, new PdfOptions { ShowHiddenSlides = true });
        source.Save("selected.pdf", new int[] { 3, 1 }, SaveFormat.Pdf, new PdfOptions());
        source.Save("quality-high.pdf", SaveFormat.Pdf, new PdfOptions { JpegQuality = 95, SufficientResolution = 300 });
        source.Save("quality-small.pdf", SaveFormat.Pdf, new PdfOptions { JpegQuality = 35, SufficientResolution = 72 });
        Report(new { visible_slides = source.Slides.Count(s => !s.Hidden), all_slides = source.Slides.Count, selected_order = licensed ? "Charlie,Alpha" : "C,Alpha" });
    }
}
```

## Expected result

The program writes "visible.pdf", "all-slides.pdf", "selected.pdf", "quality-high.pdf", "quality-small.pdf" in the printed output directory, plus the synthetic source.pptx and a result.json summary. Inspect the rendered/exported files with the viewer appropriate to the format. Input generation is visible in CreateSource; replace it with opening your own presentation when adapting the example.

Continue with the [detailed guide](/slides/net/convert-powerpoint-to-pdf/).


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
