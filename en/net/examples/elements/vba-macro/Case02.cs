using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        presentation.VbaProject = new VbaProject();

        var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
        module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

        var firstModule = presentation.VbaProject.Modules[0];

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.VbaProject.Modules[0].Name == "Module" && p.VbaProject.Modules[0].SourceCode.Contains("MsgBox"), "AccessVbaMacro: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/vba-macro/block-002", "AccessVbaMacro", "save-reopen-structure");
    }
}
