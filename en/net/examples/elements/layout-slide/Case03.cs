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
        
        // Get a layout slide by type and remove it.
        var blankLayoutSlide = presentation.LayoutSlides.Add(presentation.Masters[0], SlideLayoutType.Blank, "Unused");
        presentation.LayoutSlides.Remove(blankLayoutSlide);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.LayoutSlides.Any(l => l.Name == "Unused"), "RemoveLayoutSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/layout-slide/block-003", "RemoveLayoutSlide", "save-reopen-structure");
    }
}
