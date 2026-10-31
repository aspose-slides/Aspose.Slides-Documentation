using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case05()
    {
        using var presentation = new Presentation();
        
        // Get an existing layout slide by type.
        var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
        
        // Clone the layout slide to the end of the layout slide collection.
        var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
        clonedLayoutSlide.Name = "Clone";

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-005", p =>
        {
            Context.Require(p.LayoutSlides.Any(l => l.Name == "Clone"), "CloneLayoutSlides: semantic check 1 failed.");
        });
        Context.Pass("elements/layout-slide/block-005", "CloneLayoutSlides", "save-reopen-structure");
    }
}
