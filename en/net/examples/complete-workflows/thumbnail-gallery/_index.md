---
title: "Build a Presentation Preview Gallery"
type: docs
weight: 30
url: /net/examples/complete-workflows/thumbnail-gallery/
description: "Complete runnable C# project to build a presentation preview gallery using Aspose.Slides for .NET."
---

Create a preview gallery and JSON index for a presentation. The example uses duplicate titles and a non-ASCII input filename, generates filenames from slide numbers and escapes titles in HTML. Open gallery.html with its three thumbnail files beside it.

## Inputs and execution

[Download the complete project](example.zip), including its original inputs, all source and pinned dependencies. The projects were tested on Windows x64 with Arial and the .NET SDK8.0.427 pinned in global.json. Set `ASPOSE_LICENSE_PATH` to your license file; unrestricted content checks require a valid license. See [licensing](/slides/net/licensing/). No PowerPoint installation is required.

```text
dotnet run --project Example.csproj --configuration Release
```

The program generates its own original presentation/template fixture. JSON inputs, when present, are included in the download. All output files are separate from those inputs.

## Complete project source

```csharp
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

internal static class Program
{
    private static void Main()
    {
        var path = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(path)) new License().SetLicense(path);
        using (var input = Deck("<Planning & Review>", "<Planning & Review>", "Результаты")) input.Save("презентация.pptx", SaveFormat.Pptx);
        using var source = new Presentation("презентация.pptx");
        var items = new System.Collections.Generic.List<object>();
        var html = new System.Text.StringBuilder("""<!doctype html><html lang="en"><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1"><title>Presentation gallery</title><body><h1>Presentation gallery</h1>""");
        for (int i = 0; i < source.Slides.Count; i++)
        {
            string file = $"slide-{i + 1}.png"; string title = Text(source.Slides[i]);
            using var image = source.Slides[i].GetImage(new Size(320, 180)); image.Save(file, Aspose.Slides.ImageFormat.Png);
            items.Add(new { slide = i + 1, title, thumbnail = file });
            html.Append($"""<figure><img width="320" height="180" src="{file}" alt="Slide {i + 1}"><figcaption>{i + 1}. {WebUtility.HtmlEncode(title)}</figcaption></figure>""");
        }
        html.Append("</body></html>"); File.WriteAllText("gallery.html", html.ToString());
        File.WriteAllText("gallery.json", JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true }));
        Require(html.ToString().Contains("&lt;Planning &amp; Review&gt;"), "HTML labels must be escaped.");
        Report(new { slides = items.Count, unique_filenames = true, escaped_labels = true });
    }

    private static Presentation Deck(params string[] titles)
    {
        var deck = new Presentation();
        deck.SlideSize.SetSize(960, 540, SlideSizeScaleType.DoNotScale);
        var layout = deck.LayoutSlides.GetByType(SlideLayoutType.Blank);
        for (int i = 0; i < titles.Length; i++)
        {
            var slide = i == 0 ? deck.Slides[0] : deck.Slides.AddEmptySlide(layout);
            Label(slide, titles[i], "Title", 40, 30, 880, 80);
        }
        return deck;
    }

    private static IAutoShape Label(ISlide slide, string value, string name, float x, float y, float w, float h)
    {
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, w, h);
        shape.Name = name;
        shape.FillFormat.FillType = FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = Color.AliceBlue;
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.TextFrame.Text = value;
        shape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Normal;
        foreach (var paragraph in shape.TextFrame.Paragraphs)
        foreach (var portion in paragraph.Portions)
        {
            portion.PortionFormat.FontHeight = 24;
            portion.PortionFormat.LatinFont = new FontData("Arial");
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        }
        return shape;
    }

    private static string Text(ISlide slide) => string.Join(" ", slide.Shapes.OfType<IAutoShape>().Select(s => s.TextFrame?.Text));
    private static string Hash(string path) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path)));
    private static void Require(bool value, string message) { if (!value) throw new InvalidOperationException(message); }
    private static void Preview(Presentation deck, string path)
    {
        using var image = deck.Slides[0].GetImage(new Size(640, 360));
        image.Save(path, Aspose.Slides.ImageFormat.Png);
    }
    private static void Report(object value)
    {
        string json = JsonSerializer.Serialize(value, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json); Console.WriteLine(json);
    }
}
```

## Expected outputs

The project writes gallery.html, gallery.json, slide-1.png, slide-2.png, slide-3.png and result.json. Reopen the PPTX/PDF or gallery and inspect its content before adapting the code to a real dataset. Production applications should validate external inputs and choose their own output paths and credentials.

See also [Templates and Data](/slides/net/examples/templates-data/), [Presentations](/slides/net/examples/presentations/) and [Conversion and Rendering](/slides/net/examples/conversion-rendering/).
