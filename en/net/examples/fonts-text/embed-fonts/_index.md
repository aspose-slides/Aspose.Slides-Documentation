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

The program downloads and verifies the regular Noto Sans font. It writes separate full and used-character embedded copies, lists their embedded font family after reopening, clears the font cache, removes the downloaded file, and renders the full-font copy. The fixture does not rely on a system installation of Noto Sans.

```csharp
using System.Buffers.Binary;
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
        context.BeginAction("fonts-text/embed-fonts/block-001");
        RunExample();
        await Task.CompletedTask;
        context.Pass("fonts-text/embed-fonts/block-001", "recipe semantic assertions", "source inputs preserved", "documented output generated");
    });

    private static void RunExample()
    {
        PrepareFonts(false);
        try
        {
            byte[] font = File.ReadAllBytes("fonts/NotoSans-Regular.ttf");
            foreach (bool full in new[] { true, false })
            {
                using var p = new Presentation();
                p.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
                var shape = Label(p.Slides[0], "Embedded Noto Sans");
                shape.Name = "sample";
                shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Noto Sans");
                p.FontsManager.AddEmbeddedFont(font, full ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed);
                p.Save(full ? "full.pptx" : "used.pptx", SaveFormat.Pptx);
            }
            FontsLoader.ClearCache();
            Require(!FontsLoader.GetFontFolders().Any(folder => Path.GetFullPath(folder).StartsWith(AppContext.BaseDirectory, StringComparison.OrdinalIgnoreCase)), "An application font folder remains registered after ClearCache.");
            ValidateEmbeddedPayload("full.pptx", font, true);
            ValidateEmbeddedPayload("used.pptx", font, false);
            File.Delete("fonts/NotoSans-Regular.ttf");
            foreach (string file in new[] { "full.pptx", "used.pptx" })
            {
                using var p = new Presentation(file);
                Require(p.FontsManager.GetEmbeddedFonts().Any(f => f.FontName == "Noto Sans"), "Embedded family missing in " + file);
                Require(p.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name == "sample").TextFrame.Text == Context.ExpectedText("Embedded Noto Sans"), "Text changed.");
                if (file == "full.pptx") Render(p.Slides[0], "preview.png");
            }
            Require(!File.Exists("fonts/NotoSans-Regular.ttf"), "External font file still exists.");
            Report(new { full_embedded = true, used_embedded = true, reopened_without_external_file = true, text_retained = true });
        }
        finally { FontsLoader.ClearCache(); }
    }


    // EOT fields follow https://www.w3.org/submissions/EOT/; this checks actual font bytes, not only a family name.
    private static void ValidateEmbeddedPayload(string path, byte[] sourceFont, bool full)
    {
        using var archive = ZipFile.OpenRead(path);
        var entries = archive.Entries.Where(entry => entry.FullName.StartsWith("ppt/fonts/", StringComparison.Ordinal) && entry.FullName.EndsWith(".fntdata", StringComparison.Ordinal)).ToArray();
        Require(entries.Length == 1, "Expected one real embedded font payload.");
        using var stream = entries[0].Open(); using var memory = new MemoryStream(); stream.CopyTo(memory); byte[] eot = memory.ToArray();
        Require(eot.Length > 1000 && BinaryPrimitives.ReadUInt32LittleEndian(eot.AsSpan(0, 4)) == eot.Length, "Embedded EOT size is invalid.");
        uint dataSize = BinaryPrimitives.ReadUInt32LittleEndian(eot.AsSpan(4, 4));
        Require(dataSize > 1000 && dataSize < eot.Length && BinaryPrimitives.ReadUInt16LittleEndian(eot.AsSpan(34, 2)) == 0x504c, "Embedded EOT payload/header is invalid.");
        Require(Encoding.Unicode.GetString(eot, 0, (int)(eot.Length - dataSize)).Contains("Noto Sans", StringComparison.Ordinal), "Embedded EOT identifies the wrong family.");
        if (full)
        {
            int tables = BinaryPrimitives.ReadUInt16BigEndian(sourceFont.AsSpan(4, 2));
            int head = Enumerable.Range(0, tables).Select(i => 12 + i * 16).Single(offset => Encoding.ASCII.GetString(sourceFont, offset, 4) == "head");
            int headOffset = (int)BinaryPrimitives.ReadUInt32BigEndian(sourceFont.AsSpan(head + 8, 4));
            uint checksum = BinaryPrimitives.ReadUInt32BigEndian(sourceFont.AsSpan(headOffset + 8, 4));
            Require(BinaryPrimitives.ReadUInt32LittleEndian(eot.AsSpan(60, 4)) == checksum, "Full embedded font checksum differs from the verified source font.");
        }
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
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation -- --mode evaluation -- --mode evaluation
```

The code writes "full.pptx", "used.pptx", "preview.png", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## Practical limits

Font availability and legal embedding permission are different checks. Preserve the font license and respect embedding restrictions for every font you use. Used-character embedding can require replacement fonts when later edits introduce new characters. PowerPoint and other readers may handle embedded fonts differently; inspect the intended reader.

Read the [detailed guide](/slides/net/embedded-font/) for the full API and platform requirements.
