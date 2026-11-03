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
            Context.Require(p.Slides[0].HeaderFooterManager.IsFooterVisible, "AddHeaderFooter: semantic check 1 failed.");
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame.Text == "Foot"), "AddHeaderFooter: semantic check 2 failed.");
        });
        Context.Pass("elements/header-footer/block-001", "AddHeaderFooter", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].HeaderFooterManager.IsDateTimeVisible, "UpdateDateTime: semantic check 1 failed.");
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame.Text == "Today"), "UpdateDateTime: semantic check 2 failed.");
        });
        Context.Pass("elements/header-footer/block-002", "UpdateDateTime", "save-reopen-structure");
    }
}
