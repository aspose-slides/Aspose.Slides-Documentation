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

        presentation.Masters.AddClone(presentation.Masters[0]).Name = "Unused";

        // Remove all unused master slides (even those marked as Preserve).
        presentation.Masters.RemoveUnused(ignorePreserveField: true);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Masters.Count == 1 && p.Slides[0].LayoutSlide.MasterSlide == p.Masters[0], "RemoveUnusedMasterSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/master-slide/block-004", "RemoveUnusedMasterSlide", "save-reopen-structure");
    }
}
