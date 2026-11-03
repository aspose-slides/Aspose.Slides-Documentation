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

Each printed `CaseNN.cs` file is compiled verbatim. The download checks each case in `CaseVerification.cs` before saving and after reopening the result.

## **Add Math Text**

Create a math shape containing a fraction and the Pythagorean formula.

```csharp
using System;
using Aspose.Slides;
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

        VerifyCase01(presentation);
    }
}
```

## **Access Math Text**

Locate a shape that contains a math paragraph on the slide.

```csharp
using System.Linq;
using Aspose.Slides;
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

        VerifyCase02(presentation);
    }
}
```

## **Remove Math Text**

Delete a math shape from the slide.

```csharp
using Aspose.Slides;
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

        VerifyCase03(presentation);
    }
}
```

## **Format Math Text**

Set font properties for a math portion.

```csharp
using Aspose.Slides;
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

        VerifyCase04(presentation);
    }
}
```
