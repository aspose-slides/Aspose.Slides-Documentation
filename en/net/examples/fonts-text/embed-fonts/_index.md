---
title: Embed Fonts in a Presentation
type: docs
weight: 40
url: /net/examples/fonts-text/embed-fonts/
description: "Embed a permitted font in full or with used characters, then reopen and render without its external folder."
keywords:
- C# example
- .NET
- presentation
- Aspose.Slides
---

Embed a permitted font in full or with used characters, then reopen and render without its external folder.

## Input and prerequisites

Use .NET SDK 8.0.427 and Aspose.Slides for .NET 26.10.0 with the supplied pinned project. Set **ASPOSE_LICENSE_PATH** to your own valid license file; no license file is distributed. This complete fixture stops clearly when no license has been applied.

The code downloads pinned Noto fonts from their official repositories and verifies SHA-256 before loading them from an application folder. Internet access is required on the first run; the fonts are not installed system-wide or included in this project ZIP. See the [Noto font license](https://github.com/notofonts/noto-fonts/blob/ffebf8c1ee449e544955a7e813c54f9b73848eac/LICENSE) and [Noto CJK license](https://github.com/notofonts/noto-cjk/blob/f8d157532fbfaeda587e826d4cd5b21a49186f7c/Sans/LICENSE). Both are SIL Open Font License 1.1. Preserve their notices if you redistribute the fonts.

[Download the complete project](example.zip), including code, project and package lock. It was executed on Windows.

## Example

The program downloads and verifies the regular Noto Sans font. It writes separate full and used-character embedded copies, lists their embedded font family after reopening, clears the font cache, removes the downloaded file, and renders the full-font copy. The fixture does not rely on a system installation of Noto Sans.

```csharp
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
    private static void Main()
    {
        ApplyLicense();
        PrepareFonts(false);
        try
        {
            byte[] font = File.ReadAllBytes("fonts/NotoSans-Regular.ttf");
            foreach (bool full in new[] { true, false })
            {
                using var p = new Presentation();
                p.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
                var shape = Label(p.Slides[0], "Embedded Noto Sans");
                shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Noto Sans");
                p.FontsManager.AddEmbeddedFont(font, full ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed);
                p.Save(full ? "full.pptx" : "used.pptx", SaveFormat.Pptx);
            }
            FontsLoader.ClearCache();
            File.Delete("fonts/NotoSans-Regular.ttf");
            foreach (string file in new[] { "full.pptx", "used.pptx" })
            {
                using var p = new Presentation(file);
                Require(p.FontsManager.GetEmbeddedFonts().Any(f => f.FontName == "Noto Sans"), "Embedded family missing in " + file);
                Require(p.Slides[0].Shapes.OfType<IAutoShape>().Single().TextFrame.Text == "Embedded Noto Sans", "Text changed.");
                if (file == "full.pptx") Render(p.Slides[0], "preview.png");
            }
            Require(!File.Exists("fonts/NotoSans-Regular.ttf"), "External font file still exists.");
            Report(new { full_embedded = true, used_embedded = true, reopened_without_external_file = true, text_retained = true });
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
                byte[] bytes = client.GetByteArrayAsync(font.Url).GetAwaiter().GetResult();
                Require(Convert.ToHexString(SHA256.HashData(bytes)).ToLowerInvariant() == font.Hash, "Downloaded font hash differs: " + font.Name);
                File.WriteAllBytes(path, bytes);
            }
        }
        FontsLoader.ClearCache();
        FontsLoader.LoadExternalFonts(new[] { Path.GetFullPath("fonts") });
    }

    private static void ApplyLicense()
    {
        var license = new Aspose.Slides.License();
        string? path = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(path)) license.SetLicense(path);
        if (!license.IsLicensed()) throw new InvalidOperationException("Set ASPOSE_LICENSE_PATH to a valid license file.");
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
dotnet restore Example.csproj --locked-mode
dotnet run --project Example.csproj --configuration Release --no-restore
```

The code writes "full.pptx", "used.pptx", "preview.png", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## Practical limits

Font availability and legal embedding permission are different checks. Preserve the font license and respect embedding restrictions for every font you use. Used-character embedding can require replacement fonts when later edits introduce new characters. PowerPoint and other readers may handle embedded fonts differently; inspect the intended reader.

Read the [detailed guide](/slides/net/embedded-font/) for the full API and platform requirements.
