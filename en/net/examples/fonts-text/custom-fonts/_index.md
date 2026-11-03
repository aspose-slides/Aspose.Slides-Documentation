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

The source uses a deliberately missing Latin font plus Arabic and Chinese text. It first exports without a replacement rule to collect a real missing-font warning. Then it supplies a substitution rule and Unicode-range fallback fonts from the verified application folder and exports again.

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

    private sealed class WarningLog : IWarningCallback
    {
        public List<string> Messages { get; } = new List<string>();
        public ReturnAction Warning(IWarningInfo warning)
        {
            Messages.Add(warning.Description);
            return ReturnAction.Continue;
        }
    }

    private static void LoadCustomFonts()
    {
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
}
```

## Run and inspect the result

Extract the download into an empty directory and run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation
```

The code writes "input.pptx", "missing-font.pdf", "fallback.pdf", "preview.png", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## Practical limits

LoadExternalFonts adds search folders; it does not remove system fonts or override their initialization priority. The Noto families used here were not installed in the test environment. Each sample runs in its own process and clears the global font cache in a finally block. Warning wording can vary by version and rendering backend; collect the actual warnings rather than assuming an exact message.

Read the [detailed guide](/slides/net/custom-font/) for the full API and platform requirements.
