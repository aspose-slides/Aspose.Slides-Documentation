---
title: "Export PDF/A and Tagged PDF"
type: docs
weight: 30
url: /net/examples/conversion-rendering/pdf-compliance/
description: "Runnable C# example for export pdf/a and tagged pdf using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

PDF/A is an archival target; tagged PDF and PDF/UA address document structure and accessibility. The sample adds alternative text for its chart and image, then requests PDF/A-2b and PDF/UA separately. Validate the produced files with a standards validator, then inspect headings, reading order, language and alternative text. An export option alone does not establish full accessibility.

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

    private static void ExportComplianceProfiles(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        source.DocumentProperties.Title = "Accessible sample";
        source.DocumentProperties.Author = "Example author";
        foreach (var slide in source.Slides)
        foreach (var shape in slide.Shapes)
        {
            if (shape is IChart) shape.AlternativeText = "Example column chart comparing three series across three categories.";
            if (shape is IPictureFrame) shape.AlternativeText = "Solid cornflower-blue rectangle.";
        }
        source.Save("archive.pdf", SaveFormat.Pdf, new PdfOptions { Compliance = PdfCompliance.PdfA2b });
        source.Save("tagged.pdf", SaveFormat.Pdf, new PdfOptions { Compliance = PdfCompliance.PdfUa });
        Report(new { archival_output = File.Exists("archive.pdf"), tagged_output = File.Exists("tagged.pdf") });
    }
}
```

## Expected result

The program writes "archive.pdf", "tagged.pdf" in the printed output directory, plus the synthetic source.pptx and a result.json summary. Inspect the rendered/exported files with the viewer appropriate to the format. Input generation is visible in CreateSource; replace it with opening your own presentation when adapting the example.

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
