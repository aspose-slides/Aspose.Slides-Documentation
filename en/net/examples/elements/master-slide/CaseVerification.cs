using Aspose.Slides.Export;
using Aspose.Slides;
using System.Drawing;
using System.IO;
using System.Linq;
using System;

internal static partial class Program
{
    private static void VerifyCase01(Presentation presentation)
    {
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].LayoutSlide.MasterSlide.Shapes.OfType<IAutoShape>().Any(s => s.TextFrame.Text == "Acme"), "AddMasterSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/master-slide/block-001", "AddMasterSlide", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Masters[0].Background.Type == BackgroundType.OwnBackground, "AccessMasterSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/master-slide/block-002", "AccessMasterSlide", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Masters.Count == 1 && p.Slides[0].LayoutSlide.MasterSlide == p.Masters[0], "RemoveMasterSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/master-slide/block-003", "RemoveMasterSlide", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Masters.Count == 1 && p.Slides[0].LayoutSlide.MasterSlide == p.Masters[0], "RemoveUnusedMasterSlide: semantic check 1 failed.");
        });
        Context.Pass("elements/master-slide/block-004", "RemoveUnusedMasterSlide", "save-reopen-structure");
    }
}
