---
title: "Export Presentations to Markdown"
type: docs
weight: 50
url: /net/examples/conversion-rendering/markdown/
description: "Runnable C# example for export presentations to markdown using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

Export headings, text, lists, tables and images to Markdown using visual export. The example explicitly writes images under the images subfolder of its working directory. Copy that folder with slides.md so its relative image links continue to work.

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
        var list = source.Slides[2].Shapes.AddAutoShape(ShapeType.Rectangle, 300, 110, 300, 150);
        list.TextFrame.Text = "A\rB"; // Carriage returns create separate paragraphs.
        foreach (var paragraph in list.TextFrame.Paragraphs)
        {
            paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
            paragraph.ParagraphFormat.Bullet.Char = (char)8226;
        }

        source.Save("source.pptx", SaveFormat.Pptx);
        var options = new MarkdownSaveOptions
        {
            ExportType = MarkdownExportType.Visual,
            BasePath = Directory.GetCurrentDirectory(),
            ImagesSaveFolderName = "images",
            ShowSlideNumber = true
        };
        source.Save("slides.md", SaveFormat.Md, options);
        Console.WriteLine("Created slides.md and its relative images folder.");
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

        var table = presentation.Slides[0].Shapes.AddTable(30, 100, [140, 100], [35, 35]);
        table[0, 0].TextFrame.Text = "Item";
        table[1, 0].TextFrame.Text = "Units";
        table[0, 1].TextFrame.Text = "Pens";
        table[1, 1].TextFrame.Text = "12";
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

    // Original blue-and-white fixture; no image library or download is needed.
    private static byte[] SampleImage() => Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAwAAAAICAYAAADN5B7xAAAAI0lEQVR4nGNImfr2PymYgWoaQIAoDdgATg34AHVsIMsPhDAAMPMqpQBAkJ0AAAAASUVORK5CYII=");
}
```

## **Expected result**

`slides.md` contains all four slide labels, the Pens/12 table and the A/B list. Referenced image files are under `images`, relative to the Markdown file. `source.pptx` includes the list before export.

Continue with the [detailed guide](/slides/net/convert-powerpoint-to-markdown/).


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
