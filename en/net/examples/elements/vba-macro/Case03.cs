using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        presentation.VbaProject = new VbaProject();

        var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
        module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

        presentation.VbaProject.Modules.Remove(module);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.VbaProject != null && p.VbaProject.Modules.Count == 0, "RemoveVbaMacro: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/vba-macro/block-003", "RemoveVbaMacro", "save-reopen-structure");
    }
}
