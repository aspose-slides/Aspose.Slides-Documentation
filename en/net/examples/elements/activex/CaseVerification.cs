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
            Context.Require(p.Slides[0].Controls.Count == 1 && p.Slides[0].Controls[0].Properties["Value"] == "Text", "AddActiveX: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/activex/block-001", "AddActiveX", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Controls.Count == 1 && p.Slides[0].Controls[0].Properties["Value"] == "Text", "AccessActiveX: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/activex/block-002", "AccessActiveX", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Slides[0].Controls.Count == 0, "RemoveActiveX: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/activex/block-003", "RemoveActiveX", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Controls.Count == 1 && p.Slides[0].Controls[0].Properties["Caption"] == "Run" && p.Slides[0].Controls[0].Properties["Enabled"] == "true", "SetActiveXProperties: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/activex/block-004", "SetActiveXProperties", "save-reopen-structure");
    }
}
