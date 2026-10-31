using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        slide.SlideShowTransition.Type = TransitionType.Fade;

        // Remove transition by setting none.
        slide.SlideShowTransition.Type = TransitionType.None;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Slides[0].SlideShowTransition.Type == TransitionType.None, "RemoveSlideTransition: semantic check 1 failed.");
        });
        Context.Pass("elements/slide-transition/block-003", "RemoveSlideTransition", "save-reopen-structure");
    }
}
