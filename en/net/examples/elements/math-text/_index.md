---
title: Math Text
type: docs
weight: 160
url: /net/examples/elements/math-text/
keywords:
- math text
- add math text
- access math text
- remove math text
- format math text
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Explore Aspose.Slides for .NET MathematicalText examples: create and format equations, fractions, matrices, and symbols with C# in PPT, PPTX, and ODP presentations."
---

This article demonstrates working with mathematical text shapes and formatting equations using **Aspose.Slides for .NET**.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add Math Text**

Create a math shape containing a fraction and the Pythagorean formula.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Add a Math shape to the slide.
        var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

        // Access the math paragraph.
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Add a simple fraction: x / y
        var fraction = new MathematicalText("x").Divide("y");
        mathParagraph.Add(new MathBlock(fraction));

        // Add equation: c² = a² + b²
        var mathBlock = new MathematicalText("c")
            .SetSuperscript("2")
            .Join("=")
            .Join(new MathematicalText("a").SetSuperscript("2"))
            .Join("+")
            .Join(new MathematicalText("b").SetSuperscript("2"));

        mathParagraph.Add(mathBlock);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(Maths(p).Count == 2, "AddMathText: semantic check 1 failed.");
        });
        Context.Pass("elements/math-text/block-001", "AddMathText", "save-reopen-structure");
    }
}
```

## **Access Math Text**

Locate a shape that contains a math paragraph on the slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation(MathFixture());
        var slide = presentation.Slides[0];

        // Find the first shape that contains a math paragraph.
        var mathShape = slide.Shapes
            .OfType<IAutoShape>()
            .FirstOrDefault(s =>
                s.TextFrame != null &&
                s.TextFrame.Paragraphs.Any(p =>
                    p.Portions.Any(portion => portion is MathPortion)));

        Context.Require(mathShape != null, "Fixture must contain a math shape.");
        if (mathShape != null)
        {
            var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Example: create a fraction (not added here).
            var fraction = new MathematicalText("x").Divide("y");

            Context.Require(mathParagraph.Count == 1 && fraction != null, "Accessed existing fraction.");
        }

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(Maths(p).Count == 1, "AccessMathText: semantic check 1 failed.");
        });
        Context.Pass("elements/math-text/block-002", "AccessMathText", "save-reopen-structure");
    }
}
```

## **Remove Math Text**

Delete a math shape from the slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
        var fraction = new MathematicalText("x").Divide("y");
        mathParagraph.Add(new MathBlock(fraction));

        slide.Shapes.Remove(mathShape);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame?.Paragraphs.Any(q => q.Portions.Any(t => t is MathPortion)) == true), "RemoveMathText: semantic check 1 failed.");
        });
        Context.Pass("elements/math-text/block-003", "RemoveMathText", "save-reopen-structure");
    }
}
```

## **Format Math Text**

Set font properties for a math portion.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
        var fraction = new MathematicalText("x").Divide("y");
        mathParagraph.Add(new MathBlock(fraction));

        // The paragraph default is persisted for its mathematical content.
        mathShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 20;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(Maths(p).Count == 1, "FormatMathText: semantic check 1 failed.");
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().First(s => s.TextFrame.Paragraphs.Any(q => q.Portions.Any(t => t is MathPortion))).TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight == 20, "FormatMathText: semantic check 2 failed.");
        });
        Context.Pass("elements/math-text/block-004", "FormatMathText", "save-reopen-structure");
    }
}
```
