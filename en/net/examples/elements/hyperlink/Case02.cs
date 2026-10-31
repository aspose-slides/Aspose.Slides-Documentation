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

        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.TextFrame.Text = "Aspose";

        var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
        textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

        var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame?.Paragraphs.Any(q => q.Portions.Any(t => t.PortionFormat.HyperlinkClick?.ExternalUrl == "https://www.aspose.com")) == true), "AccessHyperlink: semantic check 1 failed.");
        });
        Context.Pass("elements/hyperlink/block-002", "AccessHyperlink", "save-reopen-structure");
    }
}
