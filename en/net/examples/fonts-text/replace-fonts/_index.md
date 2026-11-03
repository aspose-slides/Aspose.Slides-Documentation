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

## **Download and run**

Download [the complete project](example.zip) and open **Example.sln** in a compatible IDE. Automatic NuGet restore should run when it opens. The project accepts supported installed release SDKs instead of requiring one exact patch. [Setup and supported environments](/slides/net/examples/getting-started/) explains native libraries, fonts and the SDK/runtime distinction.

```text
dotnet run --project Example.csproj -- --mode evaluation
```

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes the bootstrap, solution and editor profiles.


## **Input and prerequisites**

Use a supported .NET SDK with the supplied project. Evaluation mode runs without a license; licensed mode requires your own authorized license covering this release. No license is distributed.

The project download includes the regular Noto Sans font and its OFL notice and checks the font hash before use. That project runs offline after package restore. The copied program has its own font setup, described below. Fonts are not installed system-wide. See the [Noto font license](https://github.com/notofonts/noto-fonts/blob/ffebf8c1ee449e544955a7e813c54f9b73848eac/LICENSE) and [Noto CJK license](https://github.com/notofonts/noto-cjk/blob/f8d157532fbfaeda587e826d4cd5b21a49186f7c/Sans/LICENSE). Preserve their notices when redistributing fonts.

## **Example**

The fixture has explicit Arial text and a paragraph-default Arial font. ReplaceFont changes the font references to the application-loaded Noto Sans family. The program reopens the file and inspects both kinds of formatting before rendering it.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

The required Noto Sans font (`NotoSans-Regular.ttf`, SIL Open Font License) is downloaded from a pinned source and SHA-256 checked, with a two-minute timeout. A valid cached file in `example-output/fonts` works offline. The download includes the font and its redistribution notice. The old family is Arial: install a legitimately licensed copy for an accurate before preview; the program does not download or redistribute Arial. The replacement family is Noto Sans.

```csharp
using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Net.Http;
using System.Security.Cryptography;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);
        var outputDirectory = Directory.CreateDirectory("example-output").FullName;
        const string originalFont = "Arial";
        const string replacementFont = "Noto Sans";
        if (!LoadVerifiedFonts("NotoSans-Regular.ttf"))
            return;
        try
        {
            using (var source = new Presentation())
            {
                source.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
                var explicitText = Label(source.Slides[0], "Explicit font");
                explicitText.Name = "explicit";
                explicitText.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(originalFont);
                var defaultText = Label(source.Slides[0], "Paragraph default", 175);
                defaultText.Name = "default";
                defaultText.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData(originalFont);
                source.Save("example-output/input.pptx", SaveFormat.Pptx);
            }

            using (var editable = new Presentation("example-output/input.pptx"))
            {
                Render(editable.Slides[0], "example-output/before.png");
                editable.FontsManager.ReplaceFont(new FontData(originalFont), new FontData(replacementFont));
                editable.Save("example-output/output.pptx", SaveFormat.Pptx);
            }

            using (var result = new Presentation("example-output/output.pptx"))
            {
                var a = result.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name == "explicit");
                var b = result.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name == "default");
                Render(result.Slides[0], "example-output/after.png");
                Console.WriteLine($"Replacement family: {a.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont.FontName}");
            }
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
}
```

## **Run and inspect the result**

Extract the download into an empty directory and run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation
```

The code writes "input.pptx", "output.pptx", "preview.png", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## **Practical limits**

Fonts can also come from theme major/minor settings, defaults and script-specific formatting. Inspect effective formatting and adjust a theme deliberately when that is the intended design change. Replacing a font does not guarantee identical character widths, wrapping or appearance.

Read the [detailed guide](/slides/net/font-replacement/) for the full API and platform requirements.
