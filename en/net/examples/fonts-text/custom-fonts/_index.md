---
title: Load Fonts and Configure Fallback
type: docs
weight: 30
url: /net/examples/fonts-text/custom-fonts/
description: "Load application-managed fonts, configure substitution and character-range fallback, and collect export warnings."
keywords:
- C# example
- .NET
- presentation
- Aspose.Slides
---

Load application-managed fonts, configure substitution and character-range fallback, and collect export warnings.

## Input and prerequisites

Use .NET SDK 8.0.427 and Aspose.Slides for .NET 26.10.0 with the supplied pinned project. Set **ASPOSE_LICENSE_PATH** to your own valid license file; no license file is distributed. This complete fixture stops clearly when no license has been applied.

The code downloads pinned Noto fonts from their official repositories and verifies SHA-256 before loading them from an application folder. Internet access is required on the first run; the fonts are not installed system-wide or included in this project ZIP. See the [Noto font license](https://github.com/notofonts/noto-fonts/blob/ffebf8c1ee449e544955a7e813c54f9b73848eac/LICENSE) and [Noto CJK license](https://github.com/notofonts/noto-cjk/blob/f8d157532fbfaeda587e826d4cd5b21a49186f7c/Sans/LICENSE). Both are SIL Open Font License 1.1. Preserve their notices if you redistribute the fonts.

[Download the complete project](example.zip), including code, project and package lock. It was executed on Windows.

## Example

The source uses a deliberately missing Latin font plus Arabic and Chinese text. It first exports without a replacement rule to collect a real missing-font warning. Then it supplies a substitution rule and Unicode-range fallback fonts from the verified application folder and exports again.

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
    private sealed class WarningLog : IWarningCallback
    {
        public List<string> Messages { get; } = new List<string>();
        public ReturnAction Warning(IWarningInfo warning)
        {
            Messages.Add(warning.Description);
            return ReturnAction.Continue;
        }
    }

    private static void Main()
    {
        ApplyLicense();
        PrepareFonts(true);
        try
        {
            using (var source = new Presentation())
            {
                source.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
                var text = Label(source.Slides[0], "Latin مرحبا 中文");
                text.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Missing Example Font 42");
                source.Save("input.pptx", SaveFormat.Pptx);
            }
            var log = new WarningLog();
            using var presentation = new Presentation("input.pptx", new LoadOptions { WarningCallback = log });
            byte[] loaded = presentation.FontsManager.GetFontBytes(new FontData("Noto Sans"), FontStyleType.Regular);
            Require(Convert.ToHexString(SHA256.HashData(loaded)).ToLowerInvariant() == Hash("fonts/NotoSans-Regular.ttf"), "Requested custom font did not resolve to the supplied file.");
            presentation.Save("missing-font.pdf", SaveFormat.Pdf, new PdfOptions { WarningCallback = log });
            Require(log.Messages.Count > 0, "The deliberately missing font did not produce a warning.");
            var substitutions = new FontSubstRuleCollection();
            substitutions.Add(new FontSubstRule(new FontData("Missing Example Font 42"), new FontData("Noto Sans"), FontSubstCondition.WhenInaccessible));
            presentation.FontsManager.FontSubstRuleList = substitutions;
            var fallback = new FontFallBackRulesCollection();
            fallback.Add(new FontFallBackRule(0x0600, 0x06FF, "Noto Naskh Arabic"));
            fallback.Add(new FontFallBackRule(0x4E00, 0x9FFF, "Noto Sans CJK SC"));
            presentation.FontsManager.FontFallBackRulesCollection = fallback;
            presentation.Save("fallback.pdf", SaveFormat.Pdf, new PdfOptions { WarningCallback = log });
            Render(presentation.Slides[0], "preview.png");
            File.WriteAllText("warnings.txt", string.Join(Environment.NewLine, log.Messages));
            Report(new { loaded_font_bytes_match = true, warning_received = true, substitution_rule = true, arabic_cjk_fallback = true });
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

The code writes "input.pptx", "missing-font.pdf", "fallback.pdf", "preview.png", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## Practical limits

LoadExternalFonts adds search folders; it does not remove system fonts or override their initialization priority. The Noto families used here were not installed in the test environment. Each sample runs in its own process and clears the global font cache in a finally block. Warning wording can vary by version and rendering backend; collect the actual warnings rather than assuming an exact message.

Read the [detailed guide](/slides/net/custom-font/) for the full API and platform requirements.
