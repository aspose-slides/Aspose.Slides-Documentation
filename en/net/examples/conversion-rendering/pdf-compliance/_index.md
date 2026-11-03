---
title: "Export PDF/A and Tagged PDF"
type: docs
weight: 30
url: /net/examples/conversion-rendering/pdf-compliance/
description: "Runnable C# example for export pdf/a and tagged pdf using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

PDF/A is an archival target; tagged PDF and PDF/UA address document structure and accessibility. The sample adds alternative text for its chart and image, then requests PDF/A-2b and PDF/UA separately. Validate the produced files with a standards validator, then inspect headings, reading order, language and alternative text. An export option alone does not establish full accessibility.

<span id="run-the-example"></span>

## **Complete C# example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files in the current working directory.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        using var source = CreateSource();
        source.DocumentProperties.Title = "Accessible sample";
        source.DocumentProperties.Author = "Example author";
        foreach (var slide in source.Slides)
            foreach (var shape in slide.Shapes)
            {
                if (shape is IChart)
                    shape.AlternativeText = "Example column chart comparing three series across three categories.";
                if (shape is IPictureFrame)
                    shape.AlternativeText = "Blue rectangle with a white ellipse.";
            }

        source.Save("source.pptx", SaveFormat.Pptx);
        source.Save("archive.pdf", SaveFormat.Pdf, new PdfOptions { Compliance = PdfCompliance.PdfA2b });
        source.Save("tagged.pdf", SaveFormat.Pdf, new PdfOptions { Compliance = PdfCompliance.PdfUa });
        Console.WriteLine("Created archive.pdf (PDF/A-2b) and tagged.pdf (PDF/UA).");
    }

    private static Presentation CreateSource()
    {
        var presentation = new Presentation();
        presentation.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
        var blank = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
        string[] labels = ["Alpha", "Chart", "Image"];
        for (int i = 0; i < labels.Length; i++)
        {
            var slide = i == 0 ? presentation.Slides[0] : presentation.Slides.AddEmptySlide(blank);
            AddTitle(slide, labels[i]);
        }

        byte[] imageBytes = SampleImage();
        var image = presentation.Images.AddImage(imageBytes);
        presentation.Slides[2].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 120, 200, 120, image);
        presentation.Slides[1].Shapes.AddChart(ChartType.ClusteredColumn, 30, 100, 400, 220);
        return presentation;
    }

    private static IAutoShape AddTitle(ISlide slide, string text)
    {
        var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 580, 55);
        title.Name = "RecipeTitle";
        title.TextFrame.Text = text;
        title.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 26;
        return title;
    }

    // Original blue-and-white fixture; no image library or download is needed.
    private static byte[] SampleImage() => Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAwAAAAICAYAAADN5B7xAAAAI0lEQVR4nGNImfr2PymYgWoaQIAoDdgATg34AHVsIMsPhDAAMPMqpQBAkJ0AAAAASUVORK5CYII=");
}
```

## **Expected result**

`archive.pdf` requests PDF/A-2b; `tagged.pdf` requests PDF/UA. `source.pptx` retains title, author and alternative text on the chart and picture. File creation is not proof of conformance: inspect structure and use an independent standards validator for your actual presentation.

Continue with the [detailed guide](/slides/net/convert-powerpoint-to-pdf/).


## **Open and run the complete project**

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
See [setup and prerequisites](/slides/net/examples/getting-started/) for native libraries,
fonts, IDE settings and the .NET 8/9 runtime support boundary of 2026-11-10.
