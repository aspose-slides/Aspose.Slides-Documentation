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
