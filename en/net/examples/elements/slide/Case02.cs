using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case02()
    {
        // By default, a presentation is created with one empty slide.
        using var presentation = new Presentation();

        // Add another empty slide.
        var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
        presentation.Slides.AddEmptySlide(layout: blankLayout);

        // Access slides by index.
        var firstSlide = presentation.Slides[0];
        var secondSlide = presentation.Slides[1];

        // Get slide index from a reference, then access it by index.
        var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
        var secondSlideByIndex = presentation.Slides[secondSlideIndex];

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides.Count == 2, "AccessSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/slide/block-002", "AccessSlide", "save-reopen-structure");
    }
}
