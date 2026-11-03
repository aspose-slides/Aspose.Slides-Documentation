---
title: "Export Notes and Handouts"
type: docs
weight: 80
url: /net/examples/conversion-rendering/notes-handouts/
description: "Runnable C# example for export notes and handouts using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

Export speaker notes below slides and create handouts with several slides per PDF page. The notes example omits hidden slides by default; the handout explicitly selects three slides so its final page is partially filled. Check the final partially filled handout page when your slide count is not a multiple of the chosen layout.

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

    private static void ExportNotesAndHandouts(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        var notesOptions = new PdfOptions
        {
            SlidesLayoutOptions = new NotesCommentsLayoutingOptions
            {
                NotesPosition = NotesPositions.BottomFull
            }
        };
        source.Save("notes.pdf", SaveFormat.Pdf, notesOptions);
        var handoutOptions = new PdfOptions
        {
            ShowHiddenSlides = false,
            SlidesLayoutOptions = new HandoutLayoutingOptions
            {
                Handout = HandoutType.Handouts2,
                PrintSlideNumbers = true,
                PrintFrameSlide = true
            }
        };
        int[] handoutSlides = [1, 2, 3];
        source.Save("handout.pdf", handoutSlides, SaveFormat.Pdf, handoutOptions);
        Report(new { notes_export = File.Exists("notes.pdf"), handout_export = File.Exists("handout.pdf"), source_notes = source.Slides[0].NotesSlideManager.NotesSlide.NotesTextFrame.Text.Contains("Alpha") });
    }
}
```

## Expected result

The program writes "notes.pdf", "handout.pdf" in the printed output directory, plus the synthetic source.pptx and a result.json summary. Inspect the rendered/exported files with the viewer appropriate to the format. Input generation is visible in CreateSource; replace it with opening your own presentation when adapting the example.

Continue with the [detailed guide](/slides/net/convert-powerpoint-to-pdf-with-notes/).


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
