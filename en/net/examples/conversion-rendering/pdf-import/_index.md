---
title: "Import PDF Pages into Slides"
type: docs
weight: 90
url: /net/examples/conversion-rendering/pdf-import/
description: "Runnable C# example for import pdf pages into slides using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

Create a two-page PDF fixture, import its pages, and save an editable presentation container. The default empty slide is removed before import. Imported object editability depends on the PDF content and reconstruction; this is not a promise to restore the original PowerPoint object model or exact formatting.

<span id="run-the-example"></span>

## **Complete C# example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files in the current working directory.

```csharp
using System;
using System.Drawing;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        CreatePdfInput();
        using var imported = new Presentation();
        imported.Slides.RemoveAt(0); // Remove the default slide before adding the PDF pages.
        imported.Slides.AddFromPdf("input.pdf");
        imported.Save("imported.pptx", SaveFormat.Pptx);
        for (int i = 0; i < imported.Slides.Count; i++)
        {
            using var preview = imported.Slides[i].GetImage(new Size(640, 360));
            preview.Save($"imported-{i + 1}.png", Aspose.Slides.ImageFormat.Png);
        }

        int editableTextShapes = imported.Slides.Sum(slide => slide.Shapes.OfType<IAutoShape>().Count(shape => !string.IsNullOrWhiteSpace(shape.TextFrame?.Text)));
        Console.WriteLine($"Imported {imported.Slides.Count} pages; {editableTextShapes} nonempty text shapes.");
    }

    private static void CreatePdfInput()
    {
        using var source = CreateSource();
        source.Save("source.pptx", SaveFormat.Pptx);
        source.Save("input.pdf", SaveFormat.Pdf);
    }

    private static Presentation CreateSource()
    {
        var presentation = new Presentation();
        presentation.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
        var blank = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
        string[] labels = ["Alpha", "C"];
        for (int i = 0; i < labels.Length; i++)
        {
            var slide = i == 0 ? presentation.Slides[0] : presentation.Slides.AddEmptySlide(blank);
            AddTitle(slide, labels[i]);
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

`input.pdf` contains Alpha then C. `imported.pptx` contains the two reconstructed slides without a leading blank slide; `imported-1.png` and `imported-2.png` show their order. Recoverable text is editable for this fixture; PDF import does not promise the original PowerPoint structure.

Continue with the [detailed guide](/slides/net/import-presentation/).


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
