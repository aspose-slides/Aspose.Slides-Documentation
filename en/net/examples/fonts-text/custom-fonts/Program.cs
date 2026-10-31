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
        context.BeginAction("fonts-text/custom-fonts/block-001");
        RunExample();
        await Task.CompletedTask;
        context.Pass("fonts-text/custom-fonts/block-001", "recipe semantic assertions", "source inputs preserved", "documented output generated");
    });

    private sealed class WarningLog : IWarningCallback
    {
        public List<string> Messages { get; } = new List<string>();
        public ReturnAction Warning(IWarningInfo warning)
        {
            Messages.Add(warning.Description);
            return ReturnAction.Continue;
        }
    }

    private static void RunExample()
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
