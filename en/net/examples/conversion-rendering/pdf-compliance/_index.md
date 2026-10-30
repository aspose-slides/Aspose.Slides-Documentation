---
title: "Export PDF/A and Tagged PDF"
type: docs
weight: 30
url: /net/examples/conversion-rendering/pdf-compliance/
description: "Runnable C# example for export pdf/a and tagged pdf using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

PDF/A is an archival target; tagged PDF and PDF/UA address document structure and accessibility. The sample adds alternative text for its chart and image, then requests PDF/A-2b and PDF/UA separately. Validate the produced files with a standards validator, then inspect headings, reading order, language and alternative text. An export option alone does not establish full accessibility.

## Run the example

[Download the complete project](example.zip). It includes all source, SDK settings and locked NuGet dependencies. The code creates its own four-slide input with a hidden slide, speaker notes, a table, chart and picture.

These projects were tested on Windows x64 with Arial and the .NET SDK 8.0.427 pinned by global.json. Their synthetic picture generator uses System.Drawing on Windows. For a separately tested Linux environment, see [the Docker converter](/slides/net/examples/application-integration/docker/). Restore the pinned Aspose.Slides.NET package and set `ASPOSE_LICENSE_PATH` to your license file for unrestricted results; evaluation mode adds a watermark and limits extracted text. See [installation](/slides/net/installation/) and [licensing](/slides/net/licensing/).

```text
dotnet run --project Example.csproj --configuration Release
```

## Complete C# example

```csharp
using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

internal static class Program
{
    private static void Main()
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath)) new License().SetLicense(licensePath);
        using var source = CreateSource();
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

    private static Presentation CreateSource()
    {
        var deck = new Presentation();
        deck.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
        var layout = deck.LayoutSlides.GetByType(SlideLayoutType.Blank);
        string[] labels = { "Alpha", "Bravo", "Charlie", "Hidden" };
        for (int i = 0; i < labels.Length; i++)
        {
            var slide = i == 0 ? deck.Slides[0] : deck.Slides.AddEmptySlide(layout);
            var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 580, 55);
            shape.TextFrame.Text = labels[i];
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Arial");
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 26;
            slide.NotesSlideManager.AddNotesSlide().NotesTextFrame.Text = "Speaker note " + labels[i];
            slide.Hidden = i == 3;
        }
        var table = deck.Slides[0].Shapes.AddTable(30, 100, new double[] { 140, 100 }, new double[] { 35, 35 });
        table[0, 0].TextFrame.Text = "Product";
        table[1, 0].TextFrame.Text = "Units";
        table[0, 1].TextFrame.Text = "Pens";
        table[1, 1].TextFrame.Text = "12";
        deck.Slides[1].Shapes.AddChart(ChartType.ClusteredColumn, 30, 100, 400, 220);
        using (var bitmap = new Bitmap(100, 60))
        {
            using (var graphics = Graphics.FromImage(bitmap)) graphics.Clear(Color.CornflowerBlue);
            using var stream = new MemoryStream();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            var image = deck.Images.AddImage(stream.ToArray());
            deck.Slides[2].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 120, 200, 120, image);
        }
        deck.Slides[0].Timeline.MainSequence.AddEffect(deck.Slides[0].Shapes[0], EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
        deck.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
        return deck;
    }

    private static void Report(object values)
    {
        string json = JsonSerializer.Serialize(values, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json);
        Console.WriteLine(json);
    }
}
```

## Expected result

The program writes "archive.pdf", "tagged.pdf" beside the project, plus the synthetic source.pptx and a result.json summary. Inspect the rendered/exported files with the viewer appropriate to the format. Input generation is visible in CreateSource; replace it with opening your own presentation when adapting the example.

Continue with the [detailed guide](/slides/net/convert-powerpoint-to-pdf/).
