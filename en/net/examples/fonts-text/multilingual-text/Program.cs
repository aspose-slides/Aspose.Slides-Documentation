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
        context.BeginAction("fonts-text/multilingual-text/block-001");
        RunExample();
        await Task.CompletedTask;
        context.Pass("fonts-text/multilingual-text/block-001", "recipe semantic assertions", "source inputs preserved", "documented output generated");
    });

    private static void RunExample()
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

    // Inspect persisted OOXML independently; evaluation text getters remain explicitly limited.
    private static string[] SavedText(string file)
    {
        using var archive = ZipFile.OpenRead(file);
        System.Xml.Linq.XNamespace drawing = "http://schemas.openxmlformats.org/drawingml/2006/main";
        return archive.Entries.Where(entry => entry.FullName.StartsWith("ppt/", StringComparison.Ordinal) && entry.FullName.EndsWith(".xml", StringComparison.Ordinal))
            .SelectMany(entry => { using var stream = entry.Open(); return System.Xml.Linq.XDocument.Load(stream, System.Xml.Linq.LoadOptions.PreserveWhitespace).Descendants(drawing + "p").Select(paragraph => string.Concat(paragraph.Descendants(drawing + "t").Select(node => node.Value))).ToArray(); }).ToArray();
    }

}
