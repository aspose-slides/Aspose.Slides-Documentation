using Aspose.Slides;
using System.Drawing;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Create a rectangle shape (defaults to filled with border and no text).
        var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

        // Remove fill and border to make it look like a typical text box.
        textBox.FillFormat.FillType = FillType.NoFill;
        textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

        // Set text formatting.
        var paragraph = textBox.TextFrame.Paragraphs[0];
        var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
        textFormat.FillFormat.FillType = FillType.Solid;
        textFormat.FillFormat.SolidFillColor.Color = Color.Black;

        // Assign the actual text content.
        textBox.TextFrame.Text = "Text";

        VerifyCase01(presentation);
    }
}
