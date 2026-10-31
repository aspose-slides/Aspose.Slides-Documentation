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
        
        // Access a layout slide by index.
        var firstLayoutSlide = presentation.LayoutSlides[0];
        
        // Access a layout slide by type.
        var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.LayoutSlides.Count > 0 && p.LayoutSlides.GetByType(SlideLayoutType.Blank) != null, "AccessLayoutSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/layout-slide/block-002", "AccessLayoutSlide", "save-reopen-structure");
    }
}
