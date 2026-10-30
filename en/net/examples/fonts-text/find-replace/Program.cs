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
    private static IEnumerable<ITextFrame> Frames(IShapeCollection shapes)
    {
        foreach (var shape in shapes)
        {
            if (shape is IAutoShape auto && auto.TextFrame != null) yield return auto.TextFrame;
            if (shape is IGroupShape group)
                foreach (var frame in Frames(group.Shapes)) yield return frame;
            if (shape is ITable table)
                for (int row = 0; row < table.Rows.Count; row++)
                    for (int column = 0; column < table.Columns.Count; column++) yield return table[column, row].TextFrame;
        }
    }

    private static IEnumerable<ITextFrame> AllFrames(Presentation p)
    {
        foreach (var slide in p.Slides)
        {
            foreach (var frame in Frames(slide.Shapes)) yield return frame;
            if (slide.NotesSlideManager.NotesSlide?.NotesTextFrame is ITextFrame notes) yield return notes;
        }
        foreach (var master in p.Masters)
            foreach (var frame in Frames(master.Shapes)) yield return frame;
    }

    private static void Main()
    {
        ApplyLicense();
        using (var source = new Presentation())
        {
            source.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
            var split = Label(source.Slides[0], "");
            split.TextFrame.Paragraphs.Clear();
            var paragraph = new Paragraph();
            paragraph.Portions.Add(new Portion("OL"));
            paragraph.Portions.Add(new Portion("D 2025"));
            paragraph.Portions[0].PortionFormat.FontBold = NullableBool.True;
            split.TextFrame.Paragraphs.Add(paragraph);
            var group = source.Slides[0].Shapes.AddGroupShape();
            var grouped = group.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 155, 200, 40);
            grouped.TextFrame.Text = "OLD 2025";
            var table = source.Slides[0].Shapes.AddTable(300, 155, new[] { 250.0 }, new[] { 40.0 });
            table[0, 0].TextFrame.Text = "OLD 2025";
            var masterText = Label(source.Masters[0], "OLD 2025", 310);
            masterText.Height = 40;
            source.Slides[0].NotesSlideManager.AddNotesSlide().NotesTextFrame.Text = "OLD 2025";
            var keep = Label(source.Slides[0], "Keep this", 210);
            keep.Name = "keep";
            keep.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold = NullableBool.True;
            source.Save("input.pptx", SaveFormat.Pptx);
        }
        string originalHash = Hash("input.pptx");
        using (var editable = new Presentation("input.pptx"))
        {
            var options = new TextSearchOptions { CaseSensitive = true };
            foreach (var frame in AllFrames(editable))
            {
                frame.ReplaceText("OLD", "NEW", options, null);
                frame.ReplaceRegex(new Regex(@"\b2025\b"), "2026", null);
            }
            Require(AllFrames(editable).Count(f => f.Text.Contains("NEW 2026", StringComparison.Ordinal)) == 5, "A target location was missed.");
            string beforeNoMatch = string.Join("|", AllFrames(editable).Select(f => f.Text));
            foreach (var frame in AllFrames(editable)) frame.ReplaceText("NO-SUCH-MARKER", "ignored", options, null);
            Require(beforeNoMatch == string.Join("|", AllFrames(editable).Select(f => f.Text)), "No-match replacement changed text.");
            editable.Save("output.pptx", SaveFormat.Pptx);
        }
        using (var result = new Presentation("output.pptx"))
        {
            Require(AllFrames(result).Count(f => f.Text.Contains("NEW 2026", StringComparison.Ordinal)) == 5, "Changes were not saved.");
            var keep = result.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name == "keep");
            Require(keep.TextFrame.Text == "Keep this" && keep.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold == NullableBool.True, "Unrelated text/format changed.");
            Render(result.Slides[0], "preview.png");
        }
        Require(Hash("input.pptx") == originalHash, "Original changed.");
        Report(new { target_frames = 5, literal_and_regex = true, run_spanning = true, unrelated_format_retained = true, no_match_unchanged = true, original_unchanged = true });
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
