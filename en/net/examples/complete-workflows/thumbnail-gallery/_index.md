---
title: "Build a Presentation Preview Gallery"
type: docs
weight: 30
url: /net/examples/complete-workflows/thumbnail-gallery/
description: "Complete runnable C# project to build a presentation preview gallery using Aspose.Slides for .NET."
---

Create a preview gallery and JSON index for a presentation. The example uses duplicate titles and a non-ASCII input filename, generates filenames from slide numbers and escapes titles in HTML. Open gallery.html with its three thumbnail files beside it.

## Download and run

Download [the complete project](example.zip) and open **Example.sln** in a compatible IDE. Automatic NuGet restore should run when it opens. The project accepts supported installed release SDKs instead of requiring one exact patch. [Setup and supported environments](/slides/net/examples/getting-started/) explains native libraries, fonts and the SDK/runtime distinction.

```text
dotnet run --project Example.csproj -- --mode evaluation
```

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes the bootstrap, solution and editor profiles.


## Inputs and execution

[Download the complete project](example.zip), including its original inputs, all source and pinned dependencies. The project uses bundled Noto Sans and the flexible SDK policy described in the setup guide. Set `ASPOSE_LICENSE_PATH` to your license file; unrestricted content checks require a valid license. See [licensing](/slides/net/licensing/). No PowerPoint installation is required.

```text
dotnet run --project Example.csproj --configuration Release
```

The program generates its own original presentation/template fixture. JSON inputs, when present, are included in the download. All output files are separate from those inputs.

## Complete project source

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

```csharp
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;
using Aspose.Slides;

internal static class Program
{
    private static void RunExample()
    {
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
        html.Append("</body></html>");
        string galleryHtml = html.ToString();
        File.WriteAllText("gallery.html", galleryHtml);
        File.WriteAllText("gallery.json", JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true }));
        Require(galleryHtml.Contains(WebUtility.HtmlEncode(Context.ExpectedText("<Planning & Review>"))), "HTML labels must be escaped.");
        Require(!galleryHtml.Contains("<Planning", StringComparison.Ordinal), "Raw label HTML remains.");
        Report(new { slides = items.Count, unique_filenames = true, escaped_labels = true });
    }

    private static ExampleContext Context = null!;

    private static Task<int> Main() => ExampleBootstrap.RunAsync(async context =>
    {
        Context = context;
        RunExample();
        await Task.CompletedTask;
    });

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
            portion.PortionFormat.LatinFont = new FontData("Noto Sans");
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        }
        return shape;
    }

    private static string Text(ISlide slide) => string.Join(" ", slide.Shapes.OfType<IAutoShape>().Where(s => s.Name is "Title" or "Total" or "Units").Select(s => s.TextFrame?.Text));

    private static void Require(bool value, string message) { if (!value) throw new InvalidOperationException(message); }

    private static void Report(object value)
    {
        string json = JsonSerializer.Serialize(value, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json); Console.WriteLine(json);
    }
}

internal static class ExampleBootstrap
{
    public static async Task<int> RunAsync(Func<ExampleContext, Task> run)
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        string start = Environment.CurrentDirectory;
        string output = Directory.CreateDirectory(Path.Combine(start, "example-output")).FullName;
        try
        {
            Environment.CurrentDirectory = output;
            await run(new ExampleContext(output, !string.IsNullOrWhiteSpace(licensePath)));
            Console.WriteLine("Output: " + output);
            return 0;
        }
        finally
        {
            Environment.CurrentDirectory = start;
        }
    }
}

internal sealed record ExampleContext(string OutputRoot, bool IsLicensed)
{
    public string ExpectedText(string text) => IsLicensed || text.Length <= 5
        ? text
        : text[..5] + "... text has been truncated due to evaluation version limitation.";
}
```

## Expected outputs

The project writes gallery.html, gallery.json, slide-1.png, slide-2.png, slide-3.png and result.json. Reopen the PPTX/PDF or gallery and inspect its content before adapting the code to a real dataset. Production applications should validate external inputs and choose their own output paths and credentials.

See also [Templates and Data](/slides/net/examples/templates-data/), [Presentations](/slides/net/examples/presentations/) and [Conversion and Rendering](/slides/net/examples/conversion-rendering/).
