---
title: Find and Replace Text Across a Deck
type: docs
weight: 10
url: /net/examples/fonts-text/find-replace/
description: "Replace literal and regular-expression matches across slides, groups, tables, masters and notes."
keywords:
- C# example
- .NET
- presentation
- Aspose.Slides
---

Replace literal and regular-expression matches across slides, groups, tables, masters and notes.

## Download and run

Download [the complete project](example.zip) and open **Example.sln** in a compatible IDE. Automatic NuGet restore should run when it opens. The project accepts supported installed release SDKs instead of requiring one exact patch. [Setup and supported environments](/slides/net/examples/getting-started/) explains native libraries, fonts and the SDK/runtime distinction.

```text
dotnet run --project Example.csproj -- --mode evaluation
```

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes that bootstrap, solution and editor profiles; the C# block below is Program.cs from the same archive.


## Input and prerequisites

Use a supported .NET SDK with the supplied project. Evaluation mode runs without a license; licensed mode requires your own authorized license covering this release. No license is distributed.

All presentation input is created by the code from original synthetic data.

[Download the complete project](example.zip), including code, solution, project and required helpers. Normal package restore is supported.

## Example

An application-owned traversal selects the text frames to process. Replacement operates on each full frame, so a literal match can span text runs. This fixture includes a run-spanning match, grouped shape, table cell, master text, speaker notes and unrelated styled text. Notes are explicitly included.

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

internal static class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, async context =>
    {
        Context = context;
        context.BeginAction("fonts-text/find-replace/block-001");
        RunExample();
        await Task.CompletedTask;
        context.Pass("fonts-text/find-replace/block-001", "recipe semantic assertions", "source inputs preserved", "documented output generated");
    });

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

    private static void RunExample()
    {
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
            Require(AllFrames(editable).Count(f => f.Text == Context.ExpectedText("NEW 2026")) == 5, "A target location was missed.");
            string beforeNoMatch = string.Join("|", AllFrames(editable).Select(f => f.Text));
            foreach (var frame in AllFrames(editable)) frame.ReplaceText("NO-SUCH-MARKER", "ignored", options, null);
            Require(beforeNoMatch == string.Join("|", AllFrames(editable).Select(f => f.Text)), "No-match replacement changed text.");
            editable.Save("output.pptx", SaveFormat.Pptx);
        }
        using (var result = new Presentation("output.pptx"))
        {
            Require(AllFrames(result).Count(f => f.Text == Context.ExpectedText("NEW 2026")) == 5, "Changes were not saved.");
            var keep = result.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name == "keep");
            Require(keep.TextFrame.Text == Context.ExpectedText("Keep this") && keep.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold == NullableBool.True, "Unrelated text/format changed.");
            Render(result.Slides[0], "preview.png");
        }
        Require(SavedText("output.pptx").Count(text => text == "NEW 2026") == 5, "Persisted replacement targets differ.");
        Require(!SavedText("output.pptx").Any(text => text.Contains("OLD", StringComparison.Ordinal) || text.Contains("2025", StringComparison.Ordinal)), "Persisted original marker remains.");
        Require(Hash("input.pptx") == originalHash, "Original changed.");
        Report(new { target_frames = 5, literal_and_regex = true, run_spanning = true, unrelated_format_retained = true, no_match_unchanged = true, original_unchanged = true });
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
```

## Run and inspect the result

Extract the download into an empty directory and run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation -- --mode evaluation -- --mode evaluation
```

The code writes "input.pptx", "output.pptx", "preview.png", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## Practical limits

The traversal below covers the demonstrated shapes, groups, tables, masters and notes. Additional object types such as SmartArt require their own text traversal. Choose note/master participation deliberately. A match spanning differently formatted runs may inherit formatting from part of the original; inspect the result when formatting boundaries matter.

Read the [detailed guide](/slides/net/search-and-replace-text/) for the full API and platform requirements.
