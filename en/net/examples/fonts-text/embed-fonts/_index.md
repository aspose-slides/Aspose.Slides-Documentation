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

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);

    private static void EmbedFonts()
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
}
```

## Run and inspect the result

Extract the download into an empty directory and run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation
```

The code writes "full.pptx", "used.pptx", "preview.png", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## Practical limits

Font availability and legal embedding permission are different checks. Preserve the font license and respect embedding restrictions for every font you use. Used-character embedding can require replacement fonts when later edits introduce new characters. PowerPoint and other readers may handle embedded fonts differently; inspect the intended reader.

Read the [detailed guide](/slides/net/embedded-font/) for the full API and platform requirements.
