using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];
        var marker = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        marker.Name = "DemoText";
        marker.TextFrame.Text = "Slide";

        foreach (var shape in slide.Shapes)
        {
            // Only AutoShapes can contain editable text.
            if (shape is AutoShape autoShape && autoShape.Name == "DemoText")
            {
                if (autoShape.TextFrame.Text.Contains("Slide"))
                {
                    Context.Require(autoShape.TextFrame.Text == "Slide", "Accessed the known text box.");
                }
            }
        }

        VerifyCase02(presentation);
    }
}
