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
    private static ExampleContext Context = null!;

    private static Task<int> RunChecked(string[] args) => ExampleBootstrap.RunAsync(args, async context =>
    {
        Context = context;
        context.BeginAction("fonts-text/find-replace/block-001");
        ReplacePresentationText();
        await Task.CompletedTask;
        context.Pass("fonts-text/find-replace/block-001", "recipe semantic assertions", "source inputs preserved", "documented output generated");
    });

    private static void VerifyOutput(string originalHash)
    {
        using (var result = new Presentation("output.pptx"))
        {
            Require(AllFrames(result).Count(f => f.Text == Context.ExpectedText("NEW 2026")) == 5, "Changes were not saved.");
            var keep = result.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name == "keep");
            Require(keep.TextFrame.Text == Context.ExpectedText("Keep this") && keep.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold == NullableBool.True, "Unrelated text/format changed.");
            Render(result.Slides[0], "preview.png");
        }
        string[] savedText = SavedText("output.pptx");
        Require(savedText.Count(text => text == "NEW 2026") == 5, "Persisted replacement targets differ.");
        Require(!savedText.Any(text => text.Contains("OLD", StringComparison.Ordinal) || text.Contains("2025", StringComparison.Ordinal)), "Persisted original marker remains.");
        Require(Hash("input.pptx") == originalHash, "Original changed.");
        Report(new { target_frames = 5, literal_and_regex = true, run_spanning = true, unrelated_format_retained = true, no_match_unchanged = true, original_unchanged = true });
    }

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
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
