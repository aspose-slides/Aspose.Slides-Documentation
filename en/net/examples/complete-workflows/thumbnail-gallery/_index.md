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

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes that bootstrap, solution and editor profiles; the C# block below is Program.cs from the same archive.


## Inputs and execution

[Download the complete project](example.zip), including its original inputs, all source and pinned dependencies. The project uses bundled Noto Sans and the flexible SDK policy described in the setup guide. Set `ASPOSE_LICENSE_PATH` to your license file; unrestricted content checks require a valid license. See [licensing](/slides/net/licensing/). No PowerPoint installation is required.

```text
dotnet run --project Example.csproj --configuration Release
```

The program generates its own original presentation/template fixture. JSON inputs, when present, are included in the download. All output files are separate from those inputs.

## Complete project source

The code below shows the main operation. The runnable download includes [ExampleSupport.cs](ExampleSupport.cs) with the entry point and supporting code.

```csharp
using System.Threading.Tasks;
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

internal static partial class Program
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
}
```

## Expected outputs

The project writes gallery.html, gallery.json, slide-1.png, slide-2.png, slide-3.png and result.json. Reopen the PPTX/PDF or gallery and inspect its content before adapting the code to a real dataset. Production applications should validate external inputs and choose their own output paths and credentials.

See also [Templates and Data](/slides/net/examples/templates-data/), [Presentations](/slides/net/examples/presentations/) and [Conversion and Rendering](/slides/net/examples/conversion-rendering/).
