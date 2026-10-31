using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        
        // Automatically removes all layout slides not referenced by any slide.
        presentation.LayoutSlides.RemoveUnused();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.LayoutSlides.Count == p.Slides.Select(s => s.LayoutSlide).Distinct().Count(), "RemoveUnusedLayoutSlides: semantic check 1 failed.");
        });
        Context.Pass("elements/layout-slide/block-004", "RemoveUnusedLayoutSlides", "save-reopen-structure");
    }
}
