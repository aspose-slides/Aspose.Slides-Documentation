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
        var slide = presentation.Slides[0];

        slide.SlideShowTransition.AdvanceOnClick = true;
        slide.SlideShowTransition.AdvanceAfterTime = 2000; // in milliseconds

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].SlideShowTransition.AdvanceOnClick && p.Slides[0].SlideShowTransition.AdvanceAfterTime == 2000, "SetTransitionDuration: semantic check 1 failed.");
        });
        Context.Pass("elements/slide-transition/block-004", "SetTransitionDuration", "save-reopen-structure");
    }
}
