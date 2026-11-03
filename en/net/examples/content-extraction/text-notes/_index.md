---
title: Extract Slide Text and Notes
type: docs
weight: 10
url: /net/examples/content-extraction/text-notes/
description: "Extract slide text and speaker notes to JSON with one-based slide numbers and an explicit hidden-slide policy."
---

Extract slide text and speaker notes to JSON with one-based slide numbers and an explicit hidden-slide policy.

<span id="run-the-example"></span>

## **Example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `output/` in the current working directory.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        Directory.CreateDirectory("output");
        ExtractTextAndNotes();
    }

    private sealed record TextItem(string Shape, string Text);
    private sealed record SlideText(int Number, bool Hidden, TextItem[] Text, string Notes);
    private static SlideText[] Extract(Presentation presentation, bool includeHidden)
    {
        var slides = new List<SlideText>();
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            var slide = presentation.Slides[i];
            int originalSlideNumber = i + 1;
            if (!includeHidden && slide.Hidden)
                continue;
            var textItems = new List<TextItem>();
            foreach (var shape in Walk(slide.Shapes).OfType<IAutoShape>())
                textItems.Add(new TextItem(shape.Name, shape.TextFrame.Text));
            string notes = slide.NotesSlideManager.NotesSlide?.NotesTextFrame.Text ?? "";
            slides.Add(new SlideText(originalSlideNumber, slide.Hidden, textItems.ToArray(), notes));
        }

        return slides.ToArray();
    }

    private static void ExtractTextAndNotes()
    {
        CreateInput();
        using var input = new Presentation("output/input.pptx");
        var all = Extract(input, includeHidden: true); // Change to false for visible slides only.
        var visible = Extract(input, includeHidden: false);
        Json("output/text.json", new { include_hidden = true, slides = all });
        Console.WriteLine("Results: " + Path.GetFullPath("output"));
    }

    private static void CreateInput()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];
        AddText(slide.Shapes, "Title", "東京 β");
        var group = slide.Shapes.AddGroupShape();
        AddText(group.Shapes, "Group text", "α");
        var nested = group.Shapes.AddGroupShape();
        AddText(nested.Shapes, "Nested text", "β");
        AddText(slide.Shapes, "Empty", "");
        slide.NotesSlideManager.AddNotesSlide().NotesTextFrame.Text = "✓";
        var hidden = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        hidden.Hidden = true;
        AddText(hidden.Shapes, "Hidden text", "Hide");
        presentation.Save("output/input.pptx", SaveFormat.Pptx);
    }

    private static IEnumerable<IShape> Walk(IShapeCollection shapes)
    {
        foreach (var shape in shapes)
        {
            yield return shape;
            if (shape is IGroupShape group)
            {
                foreach (var child in Walk(group.Shapes))
                    yield return child;
            }
        }
    }

    private static void Json(string path, object value)
    {
        string json = JsonSerializer.Serialize(value, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json, new UTF8Encoding(false));
    }

    private static IAutoShape AddText(IShapeCollection shapes, string name, string text)
    {
        var shape = shapes.AddAutoShape(ShapeType.Rectangle, 35, 35, 600, 70);
        shape.Name = name;
        shape.TextFrame.Text = text;
        return shape;
    }
}
```

## **Expected result and checks**

`output/text.json` includes both slides, including the hidden slide, with their original one-based numbers. It retains nested group text, Unicode and empty text frames. A slide without notes has an empty notes string. Set `includeHidden` to false to omit hidden slides without renumbering.

The downloaded project writes its verification checks to `output/result.json`. The following values describe the ZIP’s checks; the copied program does not write this report:

```json
{
  "slides_including_hidden": 2,
  "visible_slides": 1,
  "unicode_groups_empty_and_notes_checked": true,
  "one_based_numbering": true
}
```

The includeHidden argument controls whether hidden slides appear. Traversal includes nested groups and preserves empty text frames. Shape order is a storage/traversal order, not a promise of human reading order. This is text extraction, not OCR; images are not converted into text.

## **Learn more**

- [Advanced Text Extraction from Presentations in .NET](/slides/net/extract-text-from-presentation/)
- [Manage Presentation Notes in .NET](/slides/net/presentation-notes/)


## **Open and run the complete project**

[Download the complete project](example.zip), extract it and open `Example.sln`, or run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release -- --mode evaluation
```

Use the current supported .NET 10 SDK/runtime. The project keeps a stable `net8.0`
target and accepts compatible stable SDKs; no exact SDK patch is required.
Evaluation runs without a license and explicitly ignores license environment settings.
It uses bounded fixtures and checks valid output while allowing the evaluation watermark
and documented read-back text truncation. For unrestricted checks, use `--mode licensed`
with your authorized `ASPOSE_LICENSE_PATH`. No license is included.

Inputs are copied from `Fixtures` into a separate output workspace. The program prints
the absolute output path; `execution.json` records the actual runtime and verified action.
See [setup and prerequisites](/slides/net/examples/getting-started/) for native libraries,
fonts, IDE settings and the .NET 8/9 runtime support boundary of 2026-11-10.
