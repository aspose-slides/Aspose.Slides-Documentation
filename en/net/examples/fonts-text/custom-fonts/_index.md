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

## **Download and run**

Download [the complete project](example.zip) and open **Example.sln** in a compatible IDE. Automatic NuGet restore should run when it opens. The project accepts supported installed release SDKs instead of requiring one exact patch. [Setup and supported environments](/slides/net/examples/getting-started/) explains native libraries, fonts and the SDK/runtime distinction.

```text
dotnet run --project Example.csproj -- --mode evaluation
```

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes the bootstrap, solution and editor profiles.


## **Input and prerequisites**

Use a supported .NET SDK with the supplied project. Evaluation mode runs without a license; licensed mode requires your own authorized license covering this release. No license is distributed.

The project download includes the regular Noto Sans font and its OFL notice and checks the font hash before use. That project also uses Arabic and CJK faces. It acquires them from the pinned official URLs in the code on first use, which requires internet access. For an offline first run, place those exact files in the project Fonts directory before building; the same hashes are validated. Fonts are not installed system-wide. See the [Noto font license](https://github.com/notofonts/noto-fonts/blob/ffebf8c1ee449e544955a7e813c54f9b73848eac/LICENSE) and [Noto CJK license](https://github.com/notofonts/noto-cjk/blob/f8d157532fbfaeda587e826d4cd5b21a49186f7c/Sans/LICENSE). Preserve their notices when redistributing fonts.

## **Example**

The source uses a deliberately missing Latin font plus Arabic and Chinese text. It first exports without a replacement rule to collect a real missing-font warning. Then it supplies a substitution rule and Unicode-range fallback fonts from the verified application folder and exports again.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

The program needs Noto Sans (`NotoSans-Regular.ttf`), Noto Naskh Arabic (`NotoNaskhArabic-Regular.ttf`), and Noto Sans CJK SC (`NotoSansCJKsc-Regular.otf`). It downloads pinned font files with a two-minute timeout and checks SHA-256 before use. Exact cached files in `example-output/fonts` work offline. These fonts are under the SIL Open Font License; the download includes its notice.

```csharp
using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class Program
{
    private static void Main()
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);
        var outputDirectory = Directory.CreateDirectory("example-output").FullName;
        if (!LoadVerifiedFonts("NotoSans-Regular.ttf", "NotoNaskhArabic-Regular.ttf", "NotoSansCJKsc-Regular.otf"))
            return;
        try
        {
            using (var source = new Presentation())
            {
                source.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
                var text = Label(source.Slides[0], "Latin مرحبا 中文");
                text.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Missing Example Font 42");
                source.Save("example-output/input.pptx", SaveFormat.Pptx);
            }

            var log = new WarningLog();
            using var presentation = new Presentation("example-output/input.pptx", new LoadOptions { WarningCallback = log });
            // Observe the initial missing-font warning before applying the replacement rules.
            presentation.Save("example-output/missing-font.pdf", SaveFormat.Pdf, new PdfOptions { WarningCallback = log });
            var substitutions = new FontSubstRuleCollection();
            substitutions.Add(new FontSubstRule(new FontData("Missing Example Font 42"), new FontData("Noto Sans"), FontSubstCondition.WhenInaccessible));
            presentation.FontsManager.FontSubstRuleList = substitutions;
            var fallback = new FontFallBackRulesCollection();
            fallback.Add(new FontFallBackRule(0x0600, 0x06FF, "Noto Naskh Arabic"));
            fallback.Add(new FontFallBackRule(0x4E00, 0x9FFF, "Noto Sans CJK SC"));
            presentation.FontsManager.FontFallBackRulesCollection = fallback;
            presentation.Save("example-output/fallback.pdf", SaveFormat.Pdf, new PdfOptions { WarningCallback = log });
            Render(presentation.Slides[0], "example-output/preview.png");
            File.WriteAllText("example-output/warnings.txt", string.Join(Environment.NewLine, log.Messages));
            foreach (var warning in log.Messages)
                Console.WriteLine(warning);
        }
        finally
        {
            FontsLoader.ClearCache();
        }

        Console.WriteLine("Output: " + outputDirectory);
    }

    private static bool LoadVerifiedFonts(params string[] requiredFontFiles)
    {
        try
        {
            Directory.CreateDirectory("example-output/fonts");
            using var client = new HttpClient
            {
                Timeout = TimeSpan.FromMinutes(2)
            };
            var fonts = new (string Name, string Url, string Hash)[]
            {
                ("NotoSans-Regular.ttf", "https://raw.githubusercontent.com/notofonts/noto-fonts/ffebf8c1ee449e544955a7e813c54f9b73848eac/hinted/ttf/NotoSans/NotoSans-Regular.ttf", "b85c38ecea8a7cfb39c24e395a4007474fa5a4fc864f6ee33309eb4948d232d5"),
                ("NotoNaskhArabic-Regular.ttf", "https://raw.githubusercontent.com/notofonts/noto-fonts/ffebf8c1ee449e544955a7e813c54f9b73848eac/hinted/ttf/NotoNaskhArabic/NotoNaskhArabic-Regular.ttf", "2f4b88e6ee50fa82c617e2d1d4ba18281cb1c6cd71c3af3ec64970c23995db4b"),
                ("NotoSansCJKsc-Regular.otf", "https://raw.githubusercontent.com/notofonts/noto-cjk/f8d157532fbfaeda587e826d4cd5b21a49186f7c/Sans/OTF/SimplifiedChinese/NotoSansCJKsc-Regular.otf", "2c76254f6fc379fddfce0a7e84fb5385bb135d3e399294f6eeb6680d0365b74b"),
            };
            foreach (var font in fonts.Where(font => requiredFontFiles.Contains(font.Name)))
            {
                string path = Path.Combine("example-output/fonts", font.Name);
                if (!File.Exists(path) || Hash(path) != font.Hash)
                {
                    string bundled = Path.Combine(AppContext.BaseDirectory, "Fonts", font.Name);
                    byte[] bytes = File.Exists(bundled) ? File.ReadAllBytes(bundled) : client.GetByteArrayAsync(font.Url).GetAwaiter().GetResult();
                    if (Convert.ToHexString(SHA256.HashData(bytes)).ToLowerInvariant() != font.Hash)
                    {
                        Console.Error.WriteLine("Font checksum mismatch: " + font.Name);
                        return false;
                    }

                    File.WriteAllBytes(path, bytes);
                }
            }

            FontsLoader.ClearCache();
            FontsLoader.LoadExternalFonts(new[] { Path.GetFullPath("example-output/fonts") });
            return true;
        }
        catch (Exception error) when (error is HttpRequestException || error is IOException || error is OperationCanceledException)
        {
            Console.Error.WriteLine("Font setup failed. Cache the documented font files under example-output/fonts and retry. " + error.GetType().Name);
            return false;
        }
    }

    private static string Hash(string path) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path))).ToLowerInvariant();
    private static IAutoShape Label(IBaseSlide slide, string text, float y = 50)
    {
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, y, 560, 90);
        shape.TextFrame.Text = text;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;
        return shape;
    }

    private static void Render(ISlide slide, string output)
    {
        using var image = slide.GetImage(new Size(640, 360));
        image.Save(output, Aspose.Slides.ImageFormat.Png);
    }

    private sealed class WarningLog : IWarningCallback
    {
        public List<string> Messages { get; } = new List<string>();

        public ReturnAction Warning(IWarningInfo warning)
        {
            Messages.Add(warning.Description);
            return ReturnAction.Continue;
        }
    }
}
```

## **Run and inspect the result**

Extract the download into an empty directory and run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation
```

The code writes "input.pptx", "missing-font.pdf", "fallback.pdf", "preview.png", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## **Practical limits**

LoadExternalFonts adds search folders; it does not remove system fonts or override their initialization priority. The Noto families used here were not installed in the test environment. Each sample runs in its own process and clears the global font cache in a finally block. Warning wording can vary by version and rendering backend; collect the actual warnings rather than assuming an exact message.

Read the [detailed guide](/slides/net/custom-font/) for the full API and platform requirements.
