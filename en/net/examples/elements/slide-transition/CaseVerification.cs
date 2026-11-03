using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;
using Aspose.Slides;
using System.IO;
using System.Linq;
using System;

internal static partial class Program
{
    private static void VerifyCase01(Presentation presentation)
    {
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].SlideShowTransition.Type == TransitionType.Fade, "AddSlideTransition: semantic check 1 failed.");
        });
        Context.Pass("elements/slide-transition/block-001", "AddSlideTransition", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].SlideShowTransition.Type == TransitionType.Push, "AccessSlideTransition: semantic check 1 failed.");
        });
        Context.Pass("elements/slide-transition/block-002", "AccessSlideTransition", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Slides[0].SlideShowTransition.Type == TransitionType.None, "RemoveSlideTransition: semantic check 1 failed.");
        });
        Context.Pass("elements/slide-transition/block-003", "RemoveSlideTransition", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].SlideShowTransition.AdvanceOnClick && p.Slides[0].SlideShowTransition.AdvanceAfterTime == 2000, "SetTransitionDuration: semantic check 1 failed.");
        });
        Context.Pass("elements/slide-transition/block-004", "SetTransitionDuration", "save-reopen-structure");
    }
}
