using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        presentation.VbaProject = new VbaProject();

        var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
        module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.VbaProject != null && p.VbaProject.Modules.Count == 1 && p.VbaProject.Modules[0].SourceCode.Contains("Sub Test()"), "AddVbaMacro: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/vba-macro/block-001", "AddVbaMacro", "save-reopen-structure");
    }
}
