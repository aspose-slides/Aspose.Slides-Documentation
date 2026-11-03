---
title: "Export Presentations to PDF"
type: docs
weight: 20
url: /net/examples/conversion-rendering/pdf/
description: "Runnable C# example for export presentations to pdf using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

Export visible slides, include hidden slides deliberately, or specify one-based slide positions in the desired order. JPEG quality and resolution influence images; they do not guarantee a particular file size. The copied fixture uses distinct slide labels and an original 600×360 raster image.

<span id="run-the-example"></span>

## **Complete C# example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files in the current working directory.

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        using var source = CreateSource();
        source.Save("source.pptx", SaveFormat.Pptx);

        // Hidden-slide policy.
        source.Save("visible.pdf", SaveFormat.Pdf, new PdfOptions { ShowHiddenSlides = false });
        source.Save("all-slides.pdf", SaveFormat.Pdf, new PdfOptions { ShowHiddenSlides = true });

        // One-based positions: C first, then Alpha.
        int[] selectedSlides = [3, 1];
        source.Save("selected.pdf", selectedSlides, SaveFormat.Pdf, new PdfOptions());

        // Both variants export the same visible slides.
        var highQuality = new PdfOptions
        {
            JpegQuality = 95,
            SufficientResolution = 300
        };
        var smallerImages = new PdfOptions
        {
            JpegQuality = 35,
            SufficientResolution = 72
        };
        source.Save("quality-high.pdf", SaveFormat.Pdf, highQuality);
        source.Save("quality-small.pdf", SaveFormat.Pdf, smallerImages);
        Console.WriteLine("Created visible.pdf, all-slides.pdf, selected.pdf and two quality variants.");
    }

    private static Presentation CreateSource()
    {
        var presentation = new Presentation();
        presentation.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
        var blank = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
        string[] labels = ["Alpha", "Bravo", "C", "Hide"];
        for (int i = 0; i < labels.Length; i++)
        {
            var slide = i == 0 ? presentation.Slides[0] : presentation.Slides.AddEmptySlide(blank);
            AddTitle(slide, labels[i]);
            slide.Hidden = i == labels.Length - 1;
        }

        byte[] imageBytes = SampleImage();
        var image = presentation.Images.AddImage(imageBytes);
        presentation.Slides[2].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 120, 200, 120, image);
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

    private static byte[] SampleImage()
    {
        using var fixture = new Presentation();
        fixture.SlideSize.SetSize(600, 360, SlideSizeScaleType.DoNotScale);
        var slide = fixture.Slides[0];
        slide.Background.Type = BackgroundType.OwnBackground;
        slide.Background.FillFormat.FillType = FillType.Solid;
        slide.Background.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;
        var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 90, 300, 180);
        ellipse.FillFormat.FillType = FillType.Solid;
        ellipse.FillFormat.SolidFillColor.Color = Color.White;
        ellipse.LineFormat.FillFormat.FillType = FillType.NoFill;
        using var image = slide.GetImage(new Size(600, 360));
        using var bytes = new MemoryStream();
        image.Save(bytes, Aspose.Slides.ImageFormat.Png);
        return bytes.ToArray();
    }
}
```

## **Expected result**

`visible.pdf` has three visible slides; `all-slides.pdf` includes the fourth, hidden slide. `selected.pdf` contains C then Alpha. The two `quality-*.pdf` files use the same visible slides with different JPEG quality and image resolution. `source.pptx` is the generated input.

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
