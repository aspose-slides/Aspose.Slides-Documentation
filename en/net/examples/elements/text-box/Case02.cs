using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

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

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Count(s => s.Name == "DemoText" && s.TextFrame.Text == "Slide") == 1, "AccessTextBox: semantic check 1 failed.");
        });
        Context.Pass("elements/text-box/block-002", "AccessTextBox", "save-reopen-structure");
    }
}
