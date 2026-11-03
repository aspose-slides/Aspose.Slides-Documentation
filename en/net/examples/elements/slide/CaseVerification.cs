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
            Context.Require(p.Slides.Count == 2, "AddSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/slide/block-001", "AddSlide", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides.Count == 2, "AccessSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/slide/block-002", "AccessSlide", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Slides.Count == 2, "CloneSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/slide/block-003", "CloneSlide", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides.Count == 2 && p.Slides[0].Name == "Clone", "ReorderSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/slide/block-004", "ReorderSlide", "save-reopen-structure");
    }

    private static void VerifyCase05(Presentation presentation)
    {
        RoundTrip(presentation, "block-005", p =>
        {
            Context.Require(p.Slides.Count == 1, "RemoveSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/slide/block-005", "RemoveSlide", "save-reopen-structure");
    }
}
