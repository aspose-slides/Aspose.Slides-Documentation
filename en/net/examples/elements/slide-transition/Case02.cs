using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        slide.SlideShowTransition.Type = TransitionType.Push;

        // Access the transition type.
        var type = slide.SlideShowTransition.Type;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].SlideShowTransition.Type == TransitionType.Push, "AccessSlideTransition: semantic check 1 failed.");
        });
        Context.Pass("elements/slide-transition/block-002", "AccessSlideTransition", "save-reopen-structure");
    }
}
