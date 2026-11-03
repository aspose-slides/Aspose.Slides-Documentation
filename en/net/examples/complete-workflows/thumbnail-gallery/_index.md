---
title: "Build a Presentation Preview Gallery"
type: docs
weight: 30
url: /net/examples/complete-workflows/thumbnail-gallery/
description: "Complete runnable C# project to build a presentation preview gallery using Aspose.Slides for .NET."
---

Create a preview gallery and JSON index for a presentation. The example uses duplicate titles and a non-ASCII input filename, generates filenames from slide numbers and escapes titles in HTML. Open gallery.html with its three thumbnail files beside it.

## **Download and run**

Download [the complete project](example.zip) and open **Example.sln** in a compatible IDE. Automatic NuGet restore should run when it opens. The project accepts supported installed release SDKs instead of requiring one exact patch. [Setup and supported environments](/slides/net/examples/getting-started/) explains native libraries, fonts and the SDK/runtime distinction.

```text
dotnet run --project Example.csproj -- --mode evaluation
```

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes the bootstrap, solution and editor profiles.


## **Inputs and execution**

[Download the complete project](example.zip), including its original inputs, all source and pinned dependencies. The project uses bundled Noto Sans and the flexible SDK policy described in the setup guide. Set `ASPOSE_LICENSE_PATH` to your license file; unrestricted content checks require a valid license. See [licensing](/slides/net/licensing/). No PowerPoint installation is required.

```text
dotnet run --project Example.csproj --configuration Release
```

The program generates its own original presentation/template fixture. JSON inputs, when present, are included in the download. All output files are separate from those inputs.

## **Complete project source**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

The source includes a Unicode filename and repeated slide labels. Thumbnail filenames use slide numbers, while HTML captions are encoded at interpolation boundaries.

```csharp
using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);
        var outputDirectory = Directory.CreateDirectory("example-output").FullName;
        const string sourcePath = "example-output/презентация.pptx";
        using (var fixture = CreateDeck("<Planning & Review>", "<Planning & Review>", "Результаты"))
            fixture.Save(sourcePath, SaveFormat.Pptx);
        using var source = new Presentation(sourcePath);
        var thumbnails = new List<GalleryItem>();
        for (var index = 0; index < source.Slides.Count; index++)
        {
            var slide = source.Slides[index];
            var imagePath = $"slide-{index + 1}.png";
            using var image = slide.GetImage(new Size(320, 180));
            image.Save(Path.Combine(outputDirectory, imagePath), Aspose.Slides.ImageFormat.Png);
            thumbnails.Add(new GalleryItem(index + 1, SlideTitle(slide), imagePath));
        }

        var html = new StringBuilder("<!doctype html><html lang=\"en\"><meta charset=\"utf-8\"><title>Presentation gallery</title><body><h1>Presentation gallery</h1>");
        foreach (var item in thumbnails)
        {
            html.Append($"<figure><img width=\"320\" height=\"180\" src=\"{WebUtility.HtmlEncode(item.Thumbnail)}\" alt=\"Slide {item.Slide}\"><figcaption>{item.Slide}. {WebUtility.HtmlEncode(item.Title)}</figcaption></figure>");
        }

        html.Append("</body></html>");
        File.WriteAllText("example-output/gallery.html", html.ToString(), new UTF8Encoding(false));
        File.WriteAllText("example-output/gallery.json", JsonSerializer.Serialize(thumbnails, new JsonSerializerOptions { WriteIndented = true }), new UTF8Encoding(false));
        Console.WriteLine($"Created gallery.html and {thumbnails.Count} uniquely numbered thumbnails.");
        Console.WriteLine("Output: " + outputDirectory);
    }

    private static Presentation CreateDeck(params string[] titles)
    {
        var deck = new Presentation();
        deck.SlideSize.SetSize(960, 540, SlideSizeScaleType.DoNotScale);
        var layout = deck.LayoutSlides.GetByType(SlideLayoutType.Blank);
        for (int i = 0; i < titles.Length; i++)
        {
            var slide = i == 0 ? deck.Slides[0] : deck.Slides.AddEmptySlide(layout);
            AddLabel(slide, titles[i], "Title", 40, 30, 880, 80);
        }

        return deck;
    }

    private static IAutoShape AddLabel(ISlide slide, string value, string name, float x, float y, float w, float h)
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
                portion.PortionFormat.LatinFont = new FontData("Noto Sans");
                portion.PortionFormat.FillFormat.FillType = FillType.Solid;
                portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
            }

        return shape;
    }

    private static string SlideTitle(ISlide slide) => string.Join(" ", slide.Shapes.OfType<IAutoShape>().Where(s => s.Name is "Title" or "Total" or "Units").Select(s => s.TextFrame?.Text));
    private sealed record GalleryItem(int Slide, string Title, string Thumbnail);
}
```

## **Expected outputs**

The project writes gallery.html, gallery.json, slide-1.png, slide-2.png, slide-3.png and result.json. Reopen the PPTX/PDF or gallery and inspect its content before adapting the code to a real dataset. Production applications should validate external inputs and choose their own output paths and credentials.

See also [Templates and Data](/slides/net/examples/templates-data/), [Presentations](/slides/net/examples/presentations/) and [Conversion and Rendering](/slides/net/examples/conversion-rendering/).
