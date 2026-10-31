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
