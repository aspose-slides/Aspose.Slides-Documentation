using Aspose.Slides.Export;
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
            Context.Require(p.LayoutSlides.Any(l => l.Name == "Main layout") && p.Slides.Count == 3 && p.Slides[1].LayoutSlide.Name == "Main layout" && p.Slides[2].LayoutSlide.Name == "Main layout", "AddLayoutSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/layout-slide/block-001", "AddLayoutSlide", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.LayoutSlides.Count > 0 && p.LayoutSlides.GetByType(SlideLayoutType.Blank) != null, "AccessLayoutSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/layout-slide/block-002", "AccessLayoutSlide", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.LayoutSlides.Any(l => l.Name == "Unused"), "RemoveLayoutSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/layout-slide/block-003", "RemoveLayoutSlide", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.LayoutSlides.Count == p.Slides.Select(s => s.LayoutSlide).Distinct().Count(), "RemoveUnusedLayoutSlides: semantic check 1 failed.");
        });
        Context.Pass("elements/layout-slide/block-004", "RemoveUnusedLayoutSlides", "save-reopen-structure");
    }

    private static void VerifyCase05(Presentation presentation)
    {
        RoundTrip(presentation, "block-005", p =>
        {
            Context.Require(p.LayoutSlides.Any(l => l.Name == "Clone"), "CloneLayoutSlides: semantic check 1 failed.");
        });
        Context.Pass("elements/layout-slide/block-005", "CloneLayoutSlides", "save-reopen-structure");
    }
}
