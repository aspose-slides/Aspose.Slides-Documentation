using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.TextFrame.Text = "Aspose";

        var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
        var portionFormat = textPortion.PortionFormat;
        portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

        var hyperlink = portionFormat.HyperlinkClick;

        VerifyCase02(presentation);
    }
}
