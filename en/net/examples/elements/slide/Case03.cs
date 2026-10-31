using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case03()
    {
        // By default, the presentation contains one empty slide.
        using var presentation = new Presentation();
        var firstSlide = presentation.Slides[0];

        // Clone the first slide; it will be added at the end of the presentation.
        var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

        // The cloned slide index is 1 (second slide in the presentation).
        var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Slides.Count == 2, "CloneSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/slide/block-003", "CloneSlide", "save-reopen-structure");
    }
}
