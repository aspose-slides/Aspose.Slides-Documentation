---
title: "Convert Presentation Formats"
type: docs
weight: 10
url: /net/examples/conversion-rendering/presentation-formats/
description: "Runnable C# example for convert presentation formats using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

The sample exports PPTX, PPT and ODP, reopens each file and writes a PPTX copy from each input format. It checks text and slide counts and produces a preview for each result. Format-specific features may be changed or omitted; inspect the features your deck uses.

<span id="run-the-example"></span>

## **Complete C# example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files in the current working directory.

```csharp
using System;
using System.Drawing;
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
        (SaveFormat Format, string Extension)[] formats = [(SaveFormat.Pptx, "pptx"), (SaveFormat.Ppt, "ppt"), (SaveFormat.Odp, "odp")];
        foreach (var (format, extension)in formats)
        {
            string convertedPath = "converted." + extension;
            source.Save(convertedPath, format);
            using var reopened = new Presentation(convertedPath);
            Console.WriteLine($"{extension}: {reopened.Slides.Count} slides");
            reopened.Save("from-" + extension + ".pptx", SaveFormat.Pptx);
            using var preview = reopened.Slides[0].GetImage(new Size(320, 180));
            preview.Save("preview-" + extension + ".png", Aspose.Slides.ImageFormat.Png);
        }
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
}
```

## **Expected result**

`converted.pptx`, `converted.ppt` and `converted.odp` each contain the same four-slide input. Each round trip also writes `from-EXT.pptx` and `preview-EXT.png`, where EXT is pptx, ppt or odp.

Continue with the [detailed guide](/slides/net/convert-ppt-to-pptx/).


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
