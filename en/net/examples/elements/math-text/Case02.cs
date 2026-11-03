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
