using System;
using System.Linq;
using Aspose.Slides;

internal static partial class Program
{
    static void Case03()
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
        var matchingShapes = slide.Shapes.OfType<IAutoShape>()
            .Where(textShape => textShape.TextFrame?.Text.Contains(keyword, StringComparison.Ordinal) == true)
            .ToList();

        // Snapshot the matches before changing the slide's shape collection.
        foreach (var textShape in matchingShapes)
        {
            slide.Shapes.Remove(textShape);
        }

        VerifyCase03(presentation);
    }
}
