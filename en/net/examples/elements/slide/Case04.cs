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
        var firstSlide = presentation.Slides[0];

        // Add a clone of the first slide (created by default).
        var clonedSlide = presentation.Slides.AddClone(firstSlide);

        clonedSlide.Name = "Clone";

        // Move the cloned slide to the first position (others shift down).
        presentation.Slides.Reorder(index: 0, clonedSlide);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides.Count == 2 && p.Slides[0].Name == "Clone", "ReorderSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/slide/block-004", "ReorderSlide", "save-reopen-structure");
    }
}
