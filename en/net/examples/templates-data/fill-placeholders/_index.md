---
title: Fill a Presentation Template
type: docs
weight: 10
url: /net/examples/templates-data/fill-placeholders/
description: "Fill required customer markers, including a marker split across text portions, from JSON. The sample keeps surrounding bold formatting and leaves the template unchanged."
---

Fill required customer markers, including a marker split across text portions, from JSON. The sample keeps surrounding bold formatting and leaves the template unchanged.

<span id="run-the-example"></span>

## **Example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files in the current working directory.

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        const string json = """{"Customer":"Example customer"}""";
        var values = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        if (values is null)
        {
            Console.Error.WriteLine("Customer JSON contains no data.");
            return;
        }

        using var presentation = CreateTemplate();
        presentation.Save("template.pptx", SaveFormat.Pptx);
        if (!Bind(presentation.Slides[0], values))
            return;
        var title = FindNamed<IAutoShape>(presentation.Slides[0], "Customer");
        if (title is null || !FitText(title))
            return;
        presentation.Save("filled.pptx", SaveFormat.Pptx);
        SavePreview(presentation, "preview.png");
        Console.WriteLine("Created filled.pptx and preview.png.");
    }

    private static bool Bind(ISlide slide, Dictionary<string, string> values)
    {
        if (!values.TryGetValue("Customer", out string? customer) || string.IsNullOrWhiteSpace(customer))
        {
            Console.Error.WriteLine("Customer is required.");
            return false;
        }

        string optional = values.GetValueOrDefault("Optional", "");
        var frames = Walk(slide.Shapes).OfType<IAutoShape>().Select(shape => shape.TextFrame).ToArray();
        var search = new TextSearchOptions
        {
            CaseSensitive = true
        };
        foreach (var frame in frames)
        {
            frame.ReplaceText("{{Customer}}", customer, search, null);
            frame.ReplaceText("{{Optional}}", optional, search, null);
            frame.TextFrameFormat.AutofitType = TextAutofitType.Normal;
        }

        if (frames.Any(frame => frame.Text.Contains("{{")))
        {
            Console.Error.WriteLine("An unresolved template marker remains.");
            return false;
        }

        return true;
    }

    private static bool FitText(IAutoShape shape)
    {
        shape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
        for (float size = 24; size >= 10; size--)
        {
            foreach (var paragraph in shape.TextFrame.Paragraphs)
            {
                foreach (var portion in paragraph.Portions)
                    portion.PortionFormat.FontHeight = size;
            }

            double textHeight = shape.TextFrame.Paragraphs.Sum(paragraph => paragraph.GetRect().Height);
            if (textHeight <= shape.Height - 12)
                return true;
        }

        Console.Error.WriteLine("Text does not fit at the minimum font size.");
        return false;
    }

    private static Presentation CreateTemplate()
    {
        var presentation = new Presentation();
        var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 35, 35, 600, 100);
        title.Name = "Customer";
        var paragraph = title.TextFrame.Paragraphs[0];
        paragraph.Portions.Clear();
        var prefix = new Portion("Customer: ");
        prefix.PortionFormat.FontBold = NullableBool.True;
        paragraph.Portions.Add(prefix);
        paragraph.Portions.Add(new Portion("{{Cus"));
        paragraph.Portions.Add(new Portion("tomer}}"));
        foreach (var portion in paragraph.Portions)
            portion.PortionFormat.FontHeight = 24;
        var optional = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 35, 180, 600, 60);
        optional.TextFrame.Text = "{{Optional}}";
        return presentation;
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

    private static T? FindNamed<T>(ISlide slide, string name)
        where T : class, IShape
    {
        var matches = Walk(slide.Shapes).Where(shape => shape.Name == name).ToArray();
        if (matches.Length == 1 && matches[0] is T result)
            return result;
        Console.Error.WriteLine("Expected exactly one named shape: " + name);
        return null;
    }

    private static void SavePreview(Presentation presentation, string path)
    {
        using var image = presentation.Slides[0].GetImage(new Size(800, 450));
        image.Save(path, Aspose.Slides.ImageFormat.Png);
    }
}
```

## **Expected result and checks**

`filled.pptx` replaces the marker split across two text portions, retaining the bold Customer prefix. The absent optional value clears its marker. `preview.png` shows the result; `template.pptx` remains the input. Fitting stops at 10 points and reports an error if the text still overflows. The ZIP also checks missing values, unresolved markers and saved formatting.

The downloaded project writes its verification checks to `output/result.json`. The following values describe the ZIP’s checks; the copied program does not write this report:

```json
{
  "marker_replaced": true,
  "format_retained": true,
  "missing_required_rejected": true,
  "long_text_checked": true,
  "input_unchanged": true
}
```

Required values are checked before replacement. Optional values default to empty strings. The ZIP’s additional long-name case applies a bounded font-size reduction, checks paragraph height and creates a separate preview for visual review. Mixed styles within a replaced marker need their own design decision; this example preserves the surrounding prefix.

## **Learn more**

- [Manage Presentation Placeholders in .NET](/slides/net/manage-placeholder/)
- [Search and Replace Text in PowerPoint Presentations in .NET](/slides/net/search-and-replace-text/)
- [Enhance Your Presentations with AutoFit in .NET](/slides/net/manage-autofit-settings/)


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
