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

        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.TextFrame.Text = "Aspose";

        var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
        textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

        textPortion.PortionFormat.HyperlinkClick = null;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame?.Paragraphs.Any(q => q.Portions.Any(t => t.PortionFormat.HyperlinkClick != null)) == true), "RemoveHyperlink: semantic check 1 failed.");
        });
        Context.Pass("elements/hyperlink/block-003", "RemoveHyperlink", "save-reopen-structure");
    }
}
