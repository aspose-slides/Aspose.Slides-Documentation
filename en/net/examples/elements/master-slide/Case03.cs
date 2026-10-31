using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation(Seed("master"));

        // Remove the first explicitly unused master by index.
        presentation.Masters.RemoveAt(1);

        // Remove a master slide by reference.
        var firstMasterSlide = presentation.Masters[1];
        presentation.Masters.Remove(firstMasterSlide);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Masters.Count == 1 && p.Slides[0].LayoutSlide.MasterSlide == p.Masters[0], "RemoveMasterSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/master-slide/block-003", "RemoveMasterSlide", "save-reopen-structure");
    }
}
