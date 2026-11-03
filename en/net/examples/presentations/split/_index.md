---
title: Split Presentations
type: docs
weight: 40
url: /net/examples/presentations/split/
description: "Save individual slides, a selected range, or named sections to separate presentation files."
keywords:
- presentation example
- C#
- .NET
- Aspose.Slides
---

Save individual slides, a selected range, or named sections to separate presentation files.

## **Input and prerequisites**

The copied program generates its own input. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native dependencies. Evaluation output includes the SDK watermark and text limits.

## **Example**

The selection helper accepts zero-based slide indices, clones them in the requested order, and saves each result. The fixture deliberately uses duplicate section names. A numeric section prefix keeps filenames unique after invalid characters have been replaced.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files in the current working directory.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        string outputDirectory = Directory.CreateDirectory("outputs").FullName;
        using (var created = new Presentation())
        {
            var blank = created.LayoutSlides.GetByType(SlideLayoutType.Blank);
            for (int i = 0; i < 3; i++)
                AddTitle(i == 0 ? created.Slides[0] : created.Slides.AddEmptySlide(blank), "S" + (i + 1));
            created.Sections.AddSection("Part/One", created.Slides[0]);
            created.Sections.AddSection("Part/One", created.Slides[1]); // Duplicate names are valid input here.
            created.Save("input.pptx", SaveFormat.Pptx);
        }

        using var input = new Presentation("input.pptx");
        for (int i = 0; i < input.Slides.Count; i++)
            SaveSelection(input, new[] { i }, Path.Combine(outputDirectory, $"slide-{i + 1:D2}.pptx"));
        SaveSelection(input, new[] { 1, 2 }, Path.Combine(outputDirectory, "range-2-3.pptx"));
        var sectionPaths = new List<string>();
        for (int i = 0; i < input.Sections.Count; i++)
        {
            var section = input.Sections[i];
            int[] indices = section.GetSlidesListOfSection().Select(slide => input.Slides.IndexOf(slide)).ToArray();
            string filename = Path.Combine(outputDirectory, $"section-{i + 1:D2}-{SafeName(section.Name)}.pptx");
            SaveSelection(input, indices, filename);
            sectionPaths.Add(filename); // Numeric prefix prevents duplicate/sanitized-name collisions.
        }

        Console.WriteLine("Split files: " + outputDirectory);
    }

    private static string SafeName(string value)
    {
        char[] invalid = Path.GetInvalidFileNameChars();
        string clean = new string (value.Select(c => invalid.Contains(c) || c == '/' || c == '\\' ? '_' : c).ToArray()).Trim().TrimEnd('.');
        return string.IsNullOrWhiteSpace(clean) ? "section" : clean;
    }

    private static bool SaveSelection(Presentation input, int[] indices, string output)
    {
        if (indices.Length == 0 || indices.Any(index => index < 0 || index >= input.Slides.Count))
        {
            Console.Error.WriteLine("Select at least one slide and use valid zero-based indices.");
            return false;
        }

        using var result = new Presentation();
        result.Slides.RemoveAt(0);
        foreach (int index in indices)
            result.Slides.AddClone(input.Slides[index]);
        result.Save(output, SaveFormat.Pptx);
        return true;
    }

    private static IAutoShape AddTitle(ISlide slide, string text)
    {
        var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 580, 55);
        title.Name = "RecipeTitle";
        title.TextFrame.Text = text;
        title.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 26;
        return title;
    }
}
```

<span id="run-and-check-the-result"></span>

## **Download and run**

[Download the complete project](example.zip), extract it, and open `Example.sln` or run the following commands.

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation
```

The downloaded project writes "input.pptx", "outputs/slide-01.pptx", "outputs/slide-02.pptx", "outputs/slide-03.pptx", "outputs/range-2-3.pptx", "outputs/section-01-Part_One.pptx", "outputs/section-02-Part_One.pptx" and "result.json". It reopens the generated presentation files and checks the expected data. A failed check raises an exception; successful checks are recorded in "result.json".

Use `--mode licensed` with your authorized `ASPOSE_LICENSE_PATH` for unrestricted checks. The project prints its output directory.


## **Practical limits**

Empty selections and out-of-range indices are rejected before writing a file. Filenames are generated inside an application-selected output directory; avoid using an arbitrary supplied path as a section name. In the range example, indices 1 and 2 correspond to slides 2 and 3.

See the [detailed guide](/slides/net/clone-slides/) and [individual slide examples](/slides/net/examples/elements/slide/).
