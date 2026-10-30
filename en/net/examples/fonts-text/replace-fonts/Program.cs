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
                editable.FontsManager.ReplaceFont(new FontData("Arial"), new FontData("Noto Sans"));
                editable.Save("output.pptx", SaveFormat.Pptx);
            }
            using (var result = new Presentation("output.pptx"))
            {
                var a = result.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name == "explicit");
                var b = result.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name == "default");
                Require(a.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont.FontName == "Noto Sans", "Explicit reference was not replaced.");
                Require(b.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.LatinFont.FontName == "Noto Sans", "Paragraph default was not replaced.");
                Require(a.TextFrame.Text == "Explicit font" && b.TextFrame.Text == "Paragraph default", "Text changed.");
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
