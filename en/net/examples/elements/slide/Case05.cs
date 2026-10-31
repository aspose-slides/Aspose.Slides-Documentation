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

        // Add a new empty slide in addition to the default first slide.
        var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
        var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

        // Remove the first slide; only the newly added slide will remain.
        var firstSlide = presentation.Slides[0];
        presentation.Slides.Remove(firstSlide);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-005", p =>
        {
            Context.Require(p.Slides.Count == 1, "RemoveSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/slide/block-005", "RemoveSlide", "save-reopen-structure");
    }
}
