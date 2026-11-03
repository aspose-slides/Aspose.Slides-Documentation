---
title: Reduce Presentation Size
type: docs
weight: 10
url: /net/examples/optimization-batch/compression/
description: "Compress an intentionally oversized picture at 96 DPI, save a new presentation and compare file size and representative renders."
---

Compress an intentionally oversized picture at 96 DPI, save a new presentation and compare file size and representative renders.

<span id="run-the-example"></span>

## **Example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

The generated 4000 × 2400 image occupies only 500 × 300 points in the deck. The program compresses it to 96 DPI, saves a separate presentation, and reopens that output for the after preview.

```csharp
using System.Drawing;
using System.IO;
using System.Linq;
using System;
using Aspose.Slides.Export;
using Aspose.Slides;

internal static class Program
{
    private static void Main()
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);
        var outputDirectory = Directory.CreateDirectory("example-output").FullName;
        CreateImagePresentation();
        var inputBytes = new FileInfo("example-output/input.pptx").Length;
        using (var presentation = new Presentation("example-output/input.pptx"))
        {
            SavePreview(presentation, "example-output/before.png");
            var picture = presentation.Slides[0].Shapes.OfType<IPictureFrame>().Single();
            var compressed = picture.PictureFormat.CompressImage(true, PicturesCompression.Dpi96);
            presentation.Save("example-output/compressed.pptx", SaveFormat.Pptx);
            Console.WriteLine("Image compression applied: " + compressed);
        }

        using var reopened = new Presentation("example-output/compressed.pptx");
        SavePreview(reopened, "example-output/after.png");
        var outputBytes = new FileInfo("example-output/compressed.pptx").Length;
        Console.WriteLine($"Presentation size: {inputBytes:N0} to {outputBytes:N0} bytes");
        Console.WriteLine("Output: " + outputDirectory);
    }

    private static void CreateImagePresentation()
    {
        // Render an original geometric fixture at high resolution; no PNG codec is needed.
        using (var imageSource = new Presentation())
        {
            imageSource.SlideSize.SetSize(1000, 600, SlideSizeScaleType.DoNotScale);
            for (var column = 0; column < 20; column++)
            {
                var stripe = imageSource.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, column * 50, 0, 50, 600);
                stripe.FillFormat.FillType = FillType.Solid;
                stripe.FillFormat.SolidFillColor.Color = Color.FromArgb(20 + column * 8, 100, 140);
                stripe.LineFormat.FillFormat.FillType = FillType.NoFill;
            }

            using var raster = imageSource.Slides[0].GetImage(new Size(4000, 2400));
            raster.Save("example-output/large-image.png", Aspose.Slides.ImageFormat.Png);
        }

        using var presentation = new Presentation();
        var imageBytes = File.ReadAllBytes("example-output/large-image.png");
        var picture = presentation.Images.AddImage(imageBytes);
        presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 80, 110, 500, 300, picture);
        presentation.Save("example-output/input.pptx", SaveFormat.Pptx);
    }

    private static void SavePreview(Presentation presentation, string path)
    {
        using var image = presentation.Slides[0].GetImage(new Size(640, 360));
        image.Save(path, Aspose.Slides.ImageFormat.Png);
    }
}
```

## **Expected result and checks**

`example-output` contains the unchanged `input.pptx`, smaller `compressed.pptx`, and `before.png`/`after.png`. Size changes are printed. The download retains independent image bounds and pixel-difference checks.

## **Learn more**

- [Optimize Image Management in Presentations in .NET](/slides/net/image/)
- [Save Presentations in .NET](/slides/net/save-presentation/)


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
