---
title: "Import PDF Pages into Slides"
type: docs
weight: 90
url: /net/examples/conversion-rendering/pdf-import/
description: "Runnable C# example for import pdf pages into slides using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

Create a two-page PDF fixture, import its pages, and save an editable presentation container. The default empty slide is removed before import. Imported object editability depends on the PDF content and reconstruction; this is not a promise to restore the original PowerPoint object model or exact formatting.

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

    private static void ImportPdf(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        source.Save("input.pdf", new int[] { 1, 3 }, SaveFormat.Pdf, new PdfOptions());
        using var imported = new Presentation();
        imported.Slides.RemoveAt(0);
        imported.Slides.AddFromPdf("input.pdf");
        imported.Save("imported.pptx", SaveFormat.Pptx);
        if (imported.Slides.Count != 2) throw new InvalidOperationException("PDF page count was not preserved.");
        for (int i = 0; i < imported.Slides.Count; i++)
        {
            using var image = imported.Slides[i].GetImage(new Size(640, 360));
            image.Save($"imported-{i + 1}.png", Aspose.Slides.ImageFormat.Png);
        }
        Report(new { imported_slides = imported.Slides.Count, editable_text_shapes = imported.Slides.Sum(s => s.Shapes.OfType<IAutoShape>().Count(sh => sh.TextFrame != null)) });
    }
}
```

## Expected result

The program writes "input.pdf", "imported.pptx", "imported-1.png", "imported-2.png" in the printed output directory, plus the synthetic source.pptx and a result.json summary. Inspect the rendered/exported files with the viewer appropriate to the format. Input generation is visible in CreateSource; replace it with opening your own presentation when adapting the example.

Continue with the [detailed guide](/slides/net/import-presentation/).


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
