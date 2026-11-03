using Aspose.Slides;
using Aspose.Slides.MathText;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
        var paragraph = mathShape.TextFrame.Paragraphs[0];
        var mathParagraph = ((MathPortion)paragraph.Portions[0]).MathParagraph;
        var fraction = new MathematicalText("x").Divide("y");
        mathParagraph.Add(new MathBlock(fraction));

        // The paragraph default is persisted for its mathematical content.
        paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;

        VerifyCase04(presentation);
    }
}
