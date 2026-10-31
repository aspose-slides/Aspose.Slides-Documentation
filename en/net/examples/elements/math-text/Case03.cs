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
