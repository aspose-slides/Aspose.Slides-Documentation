using Aspose.Slides;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.TextFrame.Text = "Aspose";

        var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
        textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

        // Changing a hyperlink inside existing text should be done via
        // HyperlinkManager rather than setting the property directly.
        // This mimics how PowerPoint safely updates hyperlinks.
        textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");

        VerifyCase04(presentation);
    }
}
