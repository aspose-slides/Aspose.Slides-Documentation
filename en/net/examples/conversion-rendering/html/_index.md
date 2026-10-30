---
title: "Export Presentations to HTML"
type: docs
weight: 40
url: /net/examples/conversion-rendering/html/
description: "Runnable C# example for export presentations to html using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

Classic HTML uses SVG-based slide output and can scale to its container. HTML5 has presentation navigation and supported shape/transition animation. Serve the generated HTML together with its supporting asset folders; the example keeps HTML5 images and styles external. The HTML5 copy contains only visible slides so its navigation matches the exported deck. Click its first slide to play the title fade; each visible slide has a title effect and fade transition. In this SDK, generated navigation can remain disabled after a slide without animations, so verify mixed animated/static decks before hosting them. Generated HTML5 also references public JavaScript CDNs; offline hosting must provide those dependencies. The export flags do not add effects to a deck without them.

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
        source.Save("classic.html", SaveFormat.Html, new HtmlOptions { HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new ResponsiveHtmlController()) });
        using var web = new Presentation("source.pptx");
        for (int i = web.Slides.Count - 1; i >= 0; i--)
            if (web.Slides[i].Hidden) web.Slides.RemoveAt(i);
        web.Slides[0].Timeline.MainSequence[0].Timing.TriggerType = EffectTriggerType.OnClick;
        foreach (var slide in web.Slides)
        {
            slide.SlideShowTransition.Type = TransitionType.Fade;
            if (slide.Timeline.MainSequence.Count == 0)
                slide.Timeline.MainSequence.AddEffect(slide.Shapes[0], EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
        }
        web.Save("slides.html", SaveFormat.Html5, new Html5Options { AnimateShapes = true, AnimateTransitions = true, EmbedImages = false });
        Report(new { classic_html = File.Exists("classic.html"), html5 = File.Exists("slides.html"), asset_files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*", SearchOption.AllDirectories).Length });
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

The program writes "classic.html", "slides.html" beside the project, plus the synthetic source.pptx and a result.json summary. Inspect the rendered/exported files with the viewer appropriate to the format. Input generation is visible in CreateSource; replace it with opening your own presentation when adapting the example.

Continue with the [detailed guide](/slides/net/convert-powerpoint-to-html/).
