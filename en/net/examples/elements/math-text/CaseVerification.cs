using Aspose.Slides.Export;
using Aspose.Slides.MathText;
using Aspose.Slides;
using System.IO;
using System.Linq;
using System;

internal static partial class Program
{
    private static void VerifyCase01(Presentation presentation)
    {
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(Maths(p).Count == 2, "AddMathText: semantic check 1 failed.");
        });
        Context.Pass("elements/math-text/block-001", "AddMathText", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(Maths(p).Count == 1, "AccessMathText: semantic check 1 failed.");
        });
        Context.Pass("elements/math-text/block-002", "AccessMathText", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame?.Paragraphs.Any(q => q.Portions.Any(t => t is MathPortion)) == true), "RemoveMathText: semantic check 1 failed.");
        });
        Context.Pass("elements/math-text/block-003", "RemoveMathText", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(Maths(p).Count == 1, "FormatMathText: semantic check 1 failed.");
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().First(s => s.TextFrame.Paragraphs.Any(q => q.Portions.Any(t => t is MathPortion))).TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight == 20, "FormatMathText: semantic check 2 failed.");
        });
        Context.Pass("elements/math-text/block-004", "FormatMathText", "save-reopen-structure");
    }
}
