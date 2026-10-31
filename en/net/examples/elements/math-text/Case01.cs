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
