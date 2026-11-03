using System.Linq;
using System;
using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];
        // Seed matching and unrelated text, plus a shape with no text frame.
        var matchingText = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        matchingText.Name = "DemoText";
        matchingText.TextFrame.Text = "Slide";
        var unrelatedText = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 120, 150, 50);
        unrelatedText.TextFrame.Text = "Other";
        slide.Shapes.AddConnector(ShapeType.Line, 50, 190, 150, 0);

        const string keyword = "Slide";
        foreach (var textShape in slide.Shapes.OfType<IAutoShape>())
        {
            if (textShape.TextFrame?.Text.Contains(keyword, StringComparison.Ordinal) == true)
            {
                Console.WriteLine(textShape.TextFrame.Text);
            }
        }
        Context.Require(matchingText.TextFrame.Text == "Slide", "Accessed the known text box.");

        VerifyCase02(presentation);
    }
}
