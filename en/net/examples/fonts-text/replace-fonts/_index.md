---
title: Replace Presentation Fonts
type: docs
weight: 20
url: /net/examples/fonts-text/replace-fonts/
description: "Replace an explicit font reference across a presentation and inspect the saved result."
keywords:
- C# example
- .NET
- presentation
- Aspose.Slides
---

Replace an explicit font reference across a presentation and inspect the saved result.

## Download and run

Download [the complete project](example.zip) and open **Example.sln** in a compatible IDE. Automatic NuGet restore should run when it opens. The project accepts supported installed release SDKs instead of requiring one exact patch. [Setup and supported environments](/slides/net/examples/getting-started/) explains native libraries, fonts and the SDK/runtime distinction.

```text
dotnet run --project Example.csproj -- --mode evaluation
```

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes that bootstrap, solution and editor profiles; the C# block below is Program.cs from the same archive.


## Input and prerequisites

Use a supported .NET SDK with the supplied project. Evaluation mode runs without a license; licensed mode requires your own authorized license covering this release. No license is distributed.

The regular Noto Sans font and its OFL notice are included and its SHA-256 is checked before use. This recipe needs no font download and can run offline after package restore. Fonts are not installed system-wide. See the [Noto font license](https://github.com/notofonts/noto-fonts/blob/ffebf8c1ee449e544955a7e813c54f9b73848eac/LICENSE) and [Noto CJK license](https://github.com/notofonts/noto-cjk/blob/f8d157532fbfaeda587e826d4cd5b21a49186f7c/Sans/LICENSE). Preserve their notices when redistributing fonts.

[Download the complete project](example.zip), including code, solution, project and required helpers. Normal package restore is supported.

## Example

The fixture has explicit Arial text and a paragraph-default Arial font. ReplaceFont changes the font references to the application-loaded Noto Sans family. The program reopens the file and inspects both kinds of formatting before rendering it.

```csharp
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, async context =>
    {
        Context = context;
        context.BeginAction("fonts-text/replace-fonts/block-001");
        RunExample();
        await Task.CompletedTask;
        context.Pass("fonts-text/replace-fonts/block-001", "recipe semantic assertions", "source inputs preserved", "documented output generated");
    });

    private static void RunExample()
    {
        PrepareFonts(false);
        try
        {
            using (var source = new Presentation())
            {
                source.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
                var explicitText = Label(source.Slides[0], "Explicit font");
                explicitText.Name = "explicit";
                explicitText.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Arial");
                var defaultText = Label(source.Slides[0], "Paragraph default", 175);
                defaultText.Name = "default";
                defaultText.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
                source.Save("input.pptx", SaveFormat.Pptx);
            }
            string inputHash = Hash("input.pptx");
            using (var editable = new Presentation("input.pptx"))
            {
                Require(editable.Slides[0].Shapes.OfType<IAutoShape>().Single(shape => shape.Name == "explicit").TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont.FontName == "Arial", "The input must contain the original explicit font reference.");
                Require(editable.Slides[0].Shapes.OfType<IAutoShape>().Single(shape => shape.Name == "default").TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.LatinFont.FontName == "Arial", "The input must contain the original paragraph font reference.");
                editable.FontsManager.ReplaceFont(new FontData("Arial"), new FontData("Noto Sans"));
                editable.Save("output.pptx", SaveFormat.Pptx);
            }
            using (var result = new Presentation("output.pptx"))
            {
                var a = result.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name == "explicit");
                var b = result.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name == "default");
                Require(a.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont.FontName == "Noto Sans", "Explicit reference was not replaced.");
                Require(b.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.LatinFont.FontName == "Noto Sans", "Paragraph default was not replaced.");
                Require(a.TextFrame.Text == Context.ExpectedText("Explicit font") && b.TextFrame.Text == Context.ExpectedText("Paragraph default"), "Text changed.");
                Render(result.Slides[0], "preview.png");
            }
            Require(Hash("input.pptx") == inputHash, "Original changed.");
            Report(new { explicit_replaced = true, paragraph_default_replaced = true, saved_text_retained = true, original_unchanged = true });
        }
        finally { FontsLoader.ClearCache(); }
    }

    private static void PrepareFonts(bool includeOtherScripts)
    {
        Directory.CreateDirectory("fonts");
        using var client = new HttpClient { Timeout = TimeSpan.FromMinutes(2) };
        var fonts = new (string Name, string Url, string Hash)[]
        {
            ("NotoSans-Regular.ttf", "https://raw.githubusercontent.com/notofonts/noto-fonts/ffebf8c1ee449e544955a7e813c54f9b73848eac/hinted/ttf/NotoSans/NotoSans-Regular.ttf", "b85c38ecea8a7cfb39c24e395a4007474fa5a4fc864f6ee33309eb4948d232d5"),
            ("NotoNaskhArabic-Regular.ttf", "https://raw.githubusercontent.com/notofonts/noto-fonts/ffebf8c1ee449e544955a7e813c54f9b73848eac/hinted/ttf/NotoNaskhArabic/NotoNaskhArabic-Regular.ttf", "2f4b88e6ee50fa82c617e2d1d4ba18281cb1c6cd71c3af3ec64970c23995db4b"),
            ("NotoSansCJKsc-Regular.otf", "https://raw.githubusercontent.com/notofonts/noto-cjk/f8d157532fbfaeda587e826d4cd5b21a49186f7c/Sans/OTF/SimplifiedChinese/NotoSansCJKsc-Regular.otf", "2c76254f6fc379fddfce0a7e84fb5385bb135d3e399294f6eeb6680d0365b74b"),
        };
        foreach (var font in includeOtherScripts ? fonts : fonts.Take(1))
        {
            string path = Path.Combine("fonts", font.Name);
            if (!File.Exists(path) || Hash(path) != font.Hash)
            {
                string bundled = Path.Combine(AppContext.BaseDirectory, "Fonts", font.Name);
                byte[] bytes = File.Exists(bundled) ? File.ReadAllBytes(bundled) : client.GetByteArrayAsync(font.Url).GetAwaiter().GetResult();
                Require(Convert.ToHexString(SHA256.HashData(bytes)).ToLowerInvariant() == font.Hash, "Downloaded font hash differs: " + font.Name);
                File.WriteAllBytes(path, bytes);
            }
        }
        FontsLoader.ClearCache();
        FontsLoader.LoadExternalFonts(new[] { Path.GetFullPath("fonts") });
    }

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }
    private static IAutoShape Label(IBaseSlide slide, string text, float y = 50)
    {
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, y, 560, 90);
        shape.TextFrame.Text = text;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;
        return shape;
    }
    private static string Hash(string path) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path))).ToLowerInvariant();
    private static void Report(object checks)
    {
        string json = JsonSerializer.Serialize(new { checks }, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json);
        Console.WriteLine(json);
    }
    private static void Render(ISlide slide, string output)
    {
        using var image = slide.GetImage(new Size(640, 360));
        image.Save(output, Aspose.Slides.ImageFormat.Png);
    }
}
```

## Run and inspect the result

Extract the download into an empty directory and run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation -- --mode evaluation
```

The code writes "input.pptx", "output.pptx", "preview.png", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## Practical limits

Fonts can also come from theme major/minor settings, defaults and script-specific formatting. Inspect effective formatting and adjust a theme deliberately when that is the intended design change. Replacing a font does not guarantee identical character widths, wrapping or appearance.

Read the [detailed guide](/slides/net/font-replacement/) for the full API and platform requirements.
