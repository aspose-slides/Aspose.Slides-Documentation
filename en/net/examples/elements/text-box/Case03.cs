using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];
        var marker = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        marker.Name = "DemoText";
        marker.TextFrame.Text = "Slide";

        var shapesToRemove = slide.Shapes
            .Where(s => s is AutoShape autoShape && autoShape.Name == "DemoText" && autoShape.TextFrame.Text.Contains("Slide"))
            .ToList();

        shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.Any(s => s.Name == "DemoText"), "RemoveTextBox: semantic check 1 failed.");
        });
        Context.Pass("elements/text-box/block-003", "RemoveTextBox", "save-reopen-structure");
    }
}
