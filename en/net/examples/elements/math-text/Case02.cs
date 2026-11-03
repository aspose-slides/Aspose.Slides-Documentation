using System.Linq;
using Aspose.Slides;
using Aspose.Slides.MathText;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation(MathFixture());
        var slide = presentation.Slides[0];

        // Search all text portions, rather than assuming math is in the first shape.
        var mathPortion = slide.Shapes
            .OfType<IAutoShape>()
            .SelectMany(textShape => textShape.TextFrame.Paragraphs)
            .SelectMany(paragraph => paragraph.Portions)
            .OfType<MathPortion>()
            .First();
        Context.Require(mathPortion.MathParagraph.Count == 1, "Accessed existing fraction.");

        VerifyCase02(presentation);
    }
}
