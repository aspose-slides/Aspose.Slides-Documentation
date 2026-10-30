---
title: "Render Slides as Images"
type: docs
weight: 60
url: /net/examples/conversion-rendering/images/
description: "Runnable C# example for render slides as images using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

Render PNG/JPEG images and small previews at explicit pixel dimensions. The source is 16:9 and the requested sizes use the same ratio. Choose matching dimensions to avoid distortion; preserve or pad the aspect ratio in your application when a fixed container has a different shape. This explicit loop also renders the hidden slide.

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
        for (int i = 0; i < source.Slides.Count; i++)
        {
            using var image = source.Slides[i].GetImage(new Size(640, 360));
            image.Save($"slide-{i + 1}.png", Aspose.Slides.ImageFormat.Png);
            image.Save($"slide-{i + 1}.jpg", Aspose.Slides.ImageFormat.Jpeg);
            using var thumbnail = source.Slides[i].GetImage(new Size(160, 90));
            thumbnail.Save($"thumbnail-{i + 1}.png", Aspose.Slides.ImageFormat.Png);
        }
        Report(new { rendered_slides = source.Slides.Count, width = 640, height = 360, thumbnail_width = 160, thumbnail_height = 90 });
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

The program writes "slide-1.png", "slide-1.jpg", "thumbnail-1.png", "slide-2.png", "slide-2.jpg", "thumbnail-2.png", "slide-3.png", "slide-3.jpg", "thumbnail-3.png", "slide-4.png", "slide-4.jpg", "thumbnail-4.png" beside the project, plus the synthetic source.pptx and a result.json summary. Inspect the rendered/exported files with the viewer appropriate to the format. Input generation is visible in CreateSource; replace it with opening your own presentation when adapting the example.

Continue with the [detailed guide](/slides/net/convert-powerpoint-to-png/).
