using Aspose.Slides.Export;
using Aspose.Slides.Vba;
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
            Context.Require(p.VbaProject != null && p.VbaProject.Modules.Count == 1 && p.VbaProject.Modules[0].SourceCode.Contains("Sub Test()"), "AddVbaMacro: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/vba-macro/block-001", "AddVbaMacro", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.VbaProject.Modules[0].Name == "Module" && p.VbaProject.Modules[0].SourceCode.Contains("MsgBox"), "AccessVbaMacro: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/vba-macro/block-002", "AccessVbaMacro", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.VbaProject != null && p.VbaProject.Modules.Count == 0, "RemoveVbaMacro: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/vba-macro/block-003", "RemoveVbaMacro", "save-reopen-structure");
    }
}
