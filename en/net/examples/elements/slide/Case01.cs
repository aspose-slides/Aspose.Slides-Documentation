using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();

        // Each slide is based on a layout, which itself is based on a master slide.
        // Use the Blank layout to create a new slide.
        var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

        // Add a new empty slide using the selected layout.
        presentation.Slides.AddEmptySlide(layout: blankLayout);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides.Count == 2, "AddSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/slide/block-001", "AddSlide", "save-reopen-structure");
    }
}
