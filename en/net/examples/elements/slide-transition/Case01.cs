using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Apply a fade transition.
        slide.SlideShowTransition.Type = TransitionType.Fade;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].SlideShowTransition.Type == TransitionType.Fade, "AddSlideTransition: semantic check 1 failed.");
        });
        Context.Pass("elements/slide-transition/block-001", "AddSlideTransition", "save-reopen-structure");
    }
}
