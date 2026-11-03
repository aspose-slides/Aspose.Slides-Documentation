---
title: "Export Slides to SVG"
type: docs
weight: 70
url: /net/examples/conversion-rendering/svg/
description: "Runnable C# example for export slides to svg using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

Write one slide to a scalable SVG. Text appearance still depends on the output representation and fonts; SVG does not imply that each PowerPoint object becomes an editable browser element. Inspect the SVG in a browser and check any resource references before embedding it elsewhere.

<span id="run-the-example"></span>

## **Complete C# example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files in the current working directory.

```csharp
using System;
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
        var selectedSlide = source.Slides[0];
        using (var svg = File.Create("slide.svg"))
        {
            selectedSlide.WriteAsSvg(svg);
        }

        Console.WriteLine("Created slide.svg from the Alpha slide and its table.");
    }

    private static Presentation CreateSource()
    {
        var presentation = new Presentation();
        presentation.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
        var blank = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
        string[] labels = ["Alpha"];
        for (int i = 0; i < labels.Length; i++)
        {
            var slide = i == 0 ? presentation.Slides[0] : presentation.Slides.AddEmptySlide(blank);
            AddTitle(slide, labels[i]);
        }

        var table = presentation.Slides[0].Shapes.AddTable(30, 100, [140, 100], [35, 35]);
        table[0, 0].TextFrame.Text = "Item";
        table[1, 0].TextFrame.Text = "Units";
        table[0, 1].TextFrame.Text = "Pens";
        table[1, 1].TextFrame.Text = "12";
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

`slide.svg` depicts the single Alpha slide and its Pens/12 table. `source.pptx` contains exactly that slide. Open the SVG in a browser or vector viewer.

Continue with the [detailed guide](/slides/net/render-a-slide-as-an-svg-image/).


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
