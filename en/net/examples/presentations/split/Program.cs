using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, async context =>
    {
        Context = context;
        context.BeginAction("presentations/split/block-001");
        RunExample();
        await Task.CompletedTask;
        context.Pass("presentations/split/block-001", "recipe semantic assertions", "source inputs preserved", "documented output generated");
    });

    private static string SafeName(string value)
    {
        char[] invalid = Path.GetInvalidFileNameChars();
        string clean = new string(value.Select(c => invalid.Contains(c) || c == '/' || c == '\\' ? '_' : c).ToArray()).Trim().TrimEnd('.');
        return string.IsNullOrWhiteSpace(clean) ? "section" : clean;
    }

    private static void SaveSelection(Presentation input, int[] indices, string output)
    {
        if (indices.Length == 0) throw new ArgumentException("Select at least one slide.", nameof(indices));
        if (indices.Any(i => i < 0 || i >= input.Slides.Count)) throw new ArgumentOutOfRangeException(nameof(indices));
        using var result = new Presentation();
        result.Slides.RemoveAt(0);
        foreach (int index in indices) result.Slides.AddClone(input.Slides[index]);
        result.Save(output, SaveFormat.Pptx);
        using var reopened = new Presentation(output);
        Require(reopened.Slides.Count == indices.Length, "Wrong split count.");
        Require(reopened.Slides.Select(Text).SequenceEqual(indices.Select(i => Text(input.Slides[i]))), "Wrong split content/order.");
    }

    private static void RunExample()
    {
        Directory.CreateDirectory("outputs");
        using (var created = new Presentation())
        {
            var blank = created.LayoutSlides.GetByType(SlideLayoutType.Blank);
            for (int i = 0; i < 3; i++) Label(i == 0 ? created.Slides[0] : created.Slides.AddEmptySlide(blank), "S" + (i + 1));
            created.Sections.AddSection("Part/One", created.Slides[0]);
            created.Sections.AddSection("Part/One", created.Slides[1]); // Duplicate names are valid input here.
            created.Save("input.pptx", SaveFormat.Pptx);
        }
        string inputHash = Hash("input.pptx");
        using var input = new Presentation("input.pptx");
        for (int i = 0; i < input.Slides.Count; i++) SaveSelection(input, new[] { i }, $"outputs/slide-{i + 1:D2}.pptx");
        SaveSelection(input, new[] { 1, 2 }, "outputs/range-2-3.pptx");
        var sectionPaths = new List<string>();
        for (int i = 0; i < input.Sections.Count; i++)
        {
            var section = input.Sections[i];
            int[] indices = section.GetSlidesListOfSection().Select(slide => input.Slides.IndexOf(slide)).ToArray();
            string filename = $"outputs/section-{i + 1:D2}-{SafeName(section.Name)}.pptx";
            SaveSelection(input, indices, filename);
            sectionPaths.Add(filename); // Numeric prefix prevents duplicate/sanitized-name collisions.
        }
        bool invalidRejected = false, emptyRejected = false;
        try { SaveSelection(input, new[] { 3 }, "outputs/invalid.pptx"); }
        catch (ArgumentOutOfRangeException) { invalidRejected = true; }
        try { SaveSelection(input, Array.Empty<int>(), "outputs/empty.pptx"); }
        catch (ArgumentException) { emptyRejected = true; }
        Require(invalidRejected && emptyRejected, "Invalid selections were accepted.");
        Require(!File.Exists("outputs/invalid.pptx") && !File.Exists("outputs/empty.pptx"), "Invalid selections produced files.");
        Require(sectionPaths.Distinct(StringComparer.OrdinalIgnoreCase).Count() == 2, "Section filenames collide.");
        Require(sectionPaths.All(p => Path.GetFullPath(p).StartsWith(Path.GetFullPath("outputs") + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase)), "Output escaped its directory.");
        Require(Hash("input.pptx") == inputHash, "Input changed.");
        Report(new { individual_files = 3, range_slides = 2, section_files = 2, first_last_verified = true, duplicate_names_safe = true, invalid_rejected = invalidRejected, empty_rejected = emptyRejected, original_unchanged = true });
    }


    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }

    private static IAutoShape Label(ISlide slide, string text)
    {
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 80, 540, 100);
        shape.Name = "content-" + text;
        shape.TextFrame.Text = text;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 28;
        return shape;
    }

    private static string Text(ISlide slide) => string.Join("|", slide.Shapes.OfType<IAutoShape>().Where(s => s.Name.StartsWith("content-", StringComparison.Ordinal)).Select(s => s.TextFrame.Text));
    private static string Hash(string file) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(file)));
    private static void Report(object checks)
    {
        string json = JsonSerializer.Serialize(new { checks }, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json);
        Console.WriteLine(json);
    }
}
