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

## **Download and run**

Download [the complete project](example.zip) and open **Example.sln** in a compatible IDE. Automatic NuGet restore should run when it opens. The project accepts supported installed release SDKs instead of requiring one exact patch. [Setup and supported environments](/slides/net/examples/getting-started/) explains native libraries, fonts and the SDK/runtime distinction.

```text
dotnet run --project Example.csproj -- --mode evaluation
```

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes the bootstrap, solution and editor profiles.


## **Input and prerequisites**

Use a supported .NET SDK with the supplied project. Evaluation mode runs without a license; licensed mode requires your own authorized license covering this release. No license is distributed.

All presentation input is created by the code from original synthetic data.

## **Example**

An application-owned traversal selects the text frames to process. Replacement operates on each full frame, so a literal match can span text runs. This fixture includes a run-spanning match, grouped shape, table cell, master text, speaker notes and unrelated styled text. Notes are explicitly included.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

The generated fixture includes a literal split across text portions, a grouped shape, a table cell, slide notes, and master text. Literal matching is case-sensitive; one compiled regex matches the year in every location. Evaluation mode may shorten read-back text.

```csharp
using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
        CreateInput();
        using (var presentation = new Presentation("example-output/input.pptx"))
        {
            var literalOptions = new TextSearchOptions
            {
                CaseSensitive = true
            };
            var yearPattern = new Regex(@"\b2025\b", RegexOptions.Compiled);
            foreach (var textFrame in SlideNotesAndMasterText(presentation))
            {
                textFrame.ReplaceText("OLD", "NEW", literalOptions, null);
                textFrame.ReplaceRegex(yearPattern, "2026", null);
            }

            presentation.Save("example-output/output.pptx", SaveFormat.Pptx);
        }

        using var reopened = new Presentation("example-output/output.pptx");
        Render(reopened.Slides[0], "example-output/preview.png");
        foreach (var textFrame in SlideNotesAndMasterText(reopened))
            Console.WriteLine(textFrame.Text);
        Console.WriteLine("Output: " + outputDirectory);
    }

    private static IEnumerable<ITextFrame> ShapeTextFrames(IShapeCollection shapes)
    {
        foreach (var shape in shapes)
        {
            if (shape is IAutoShape auto && auto.TextFrame != null)
                yield return auto.TextFrame;
            if (shape is IGroupShape group)
                foreach (var frame in ShapeTextFrames(group.Shapes))
                    yield return frame;
            if (shape is ITable table)
                for (int row = 0; row < table.Rows.Count; row++)
                    for (int column = 0; column < table.Columns.Count; column++)
                        yield return table[column, row].TextFrame;
        }
    }

    private static IEnumerable<ITextFrame> SlideNotesAndMasterText(Presentation presentation)
    {
        foreach (var slide in presentation.Slides)
        {
            foreach (var frame in ShapeTextFrames(slide.Shapes))
                yield return frame;
            if (slide.NotesSlideManager.NotesSlide?.NotesTextFrame is ITextFrame notes)
                yield return notes;
        }

        foreach (var master in presentation.Masters)
            foreach (var frame in ShapeTextFrames(master.Shapes))
                yield return frame;
    }

    private static void CreateInput()
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
            source.Save("example-output/input.pptx", SaveFormat.Pptx);
        }
    }

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

The traversal below covers the demonstrated shapes, groups, tables, masters and notes. Additional object types such as SmartArt require their own text traversal. Choose note/master participation deliberately. A match spanning differently formatted runs may inherit formatting from part of the original; inspect the result when formatting boundaries matter.

Read the [detailed guide](/slides/net/search-and-replace-text/) for the full API and platform requirements.
