---
title: Process Multilingual Text
type: docs
weight: 50
url: /net/examples/fonts-text/multilingual-text/
description: "Render Arabic, mixed-direction text and wrapped Chinese text with explicit script-appropriate fonts."
keywords:
- C# example
- .NET
- presentation
- Aspose.Slides
---

Render Arabic, mixed-direction text and wrapped Chinese text with explicit script-appropriate fonts.

## Download and run

Download [the complete project](example.zip) and open **Example.sln** in a compatible IDE. Automatic NuGet restore should run when it opens. The project accepts supported installed release SDKs instead of requiring one exact patch. [Setup and supported environments](/slides/net/examples/getting-started/) explains native libraries, fonts and the SDK/runtime distinction.

```text
dotnet run --project Example.csproj -- --mode evaluation
```

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes that bootstrap, solution and editor profiles; the C# block below is Program.cs from the same archive.


## Input and prerequisites

Use a supported .NET SDK with the supplied project. Evaluation mode runs without a license; licensed mode requires your own authorized license covering this release. No license is distributed.

The regular Noto Sans font and its OFL notice are included and its SHA-256 is checked before use. This recipe also uses Arabic and CJK faces. It acquires them from the pinned official URLs in the code on first use, which requires internet access. For an offline first run, place those exact files in the project Fonts directory before building; the same hashes are validated. Fonts are not installed system-wide. See the [Noto font license](https://github.com/notofonts/noto-fonts/blob/ffebf8c1ee449e544955a7e813c54f9b73848eac/LICENSE) and [Noto CJK license](https://github.com/notofonts/noto-cjk/blob/f8d157532fbfaeda587e826d4cd5b21a49186f7c/Sans/LICENSE). Preserve their notices when redistributing fonts.

[Download the complete project](example.zip), including code, solution, project and required helpers. Normal package restore is supported.

## Example

The fixture uses separate Arabic, mixed-direction and Chinese text frames. RightToLeft controls the Arabic paragraphs; explicit font families supply the glyphs. Chinese text wraps in a narrow frame and uses normal autofit. The example checks saved Unicode strings and the measured paragraph width and height, then produces a preview for visual review.

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

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);

    private static void FormatMultilingualText()
    {
        PrepareFonts(true);
        try
        {
            const string arabic = "مرحبا بالعالم";
            const string mixed = "النتائج 2026 (ABC)";
            const string chinese = "中文演示文稿自动换行测试。保留全部文字并检查布局。";
            using (var p = new Presentation())
            {
                p.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
                var a = Label(p.Slides[0], arabic, 20); a.Name = "arabic"; a.Height = 75;
                var b = Label(p.Slides[0], mixed, 110); b.Name = "mixed"; b.Height = 75;
                foreach (var shape in new[] { a, b })
                {
                    var paragraph = shape.TextFrame.Paragraphs[0];
                    paragraph.ParagraphFormat.RightToLeft = NullableBool.True;
                    paragraph.Portions[0].PortionFormat.LatinFont = new FontData("Noto Naskh Arabic");
                    paragraph.Portions[0].PortionFormat.ComplexScriptFont = new FontData("Noto Naskh Arabic");
                }
                var c = Label(p.Slides[0], chinese, 210); c.Name = "chinese"; c.Width = 330; c.Height = 120;
                c.TextFrame.TextFrameFormat.WrapText = NullableBool.True;
                c.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Normal;
                c.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Noto Sans CJK SC");
                c.TextFrame.Paragraphs[0].Portions[0].PortionFormat.EastAsianFont = new FontData("Noto Sans CJK SC");
                p.Save("output.pptx", SaveFormat.Pptx);
            }
            using var result = new Presentation("output.pptx");
            var shapes = result.Slides[0].Shapes.OfType<IAutoShape>().ToDictionary(s => s.Name);
            Require(shapes["arabic"].TextFrame.Text == Context.ExpectedText(arabic) && shapes["mixed"].TextFrame.Text == Context.ExpectedText(mixed) && shapes["chinese"].TextFrame.Text == Context.ExpectedText(chinese), "Unicode text changed.");
            Require(shapes["arabic"].TextFrame.Paragraphs[0].ParagraphFormat.RightToLeft == NullableBool.True, "RTL setting was lost.");
            Render(result.Slides[0], "preview.png");
            Require(shapes["chinese"].TextFrame.Paragraphs[0].GetLinesCount() > 1, "Chinese text did not wrap.");
            foreach (var shape in new[] { shapes["arabic"], shapes["mixed"], shapes["chinese"] })
            {
                RectangleF bounds = shape.TextFrame.Paragraphs[0].GetRect();
                Require(bounds.Width <= shape.Width + 1 && bounds.Height <= shape.Height + 1, "Text overflows " + shape.Name);
            }
            Require(new[] { arabic, mixed, chinese }.All(text => SavedText("output.pptx").Contains(text)), "Persisted Unicode text differs.");
            Report(new { unicode_retained = true, rtl_enabled = true, cjk_wrapped = true, bounds_fit = true });
        }
        finally { FontsLoader.ClearCache(); }
    }
}
```

## Run and inspect the result

Extract the download into an empty directory and run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation
```

The code writes "output.pptx", "preview.png", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## Practical limits

A successful save does not prove correct shaping or fit. Inspect punctuation, numbers, glyphs, line breaks and output at the intended size. Autofit can reduce text size; use an application-specific minimum size or redesign the layout when content expands. Fallback and rendering can vary with the font environment.

Read the [detailed guide](/slides/net/text-formatting/) for the full API and platform requirements.
