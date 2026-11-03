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

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);

    private static void ReplaceFonts()
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
}
```

## Run and inspect the result

Extract the download into an empty directory and run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation
```

The code writes "input.pptx", "output.pptx", "preview.png", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## Practical limits

Fonts can also come from theme major/minor settings, defaults and script-specific formatting. Inspect effective formatting and adjust a theme deliberately when that is the intended design change. Replacing a font does not guarantee identical character widths, wrapping or appearance.

Read the [detailed guide](/slides/net/font-replacement/) for the full API and platform requirements.
