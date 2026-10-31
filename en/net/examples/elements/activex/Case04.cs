using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Add a CommandButton and configure properties.
        var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.Properties["Caption"] = "Run";
        control.Properties["Enabled"] = "true";

        presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Controls.Count == 1 && p.Slides[0].Controls[0].Properties["Caption"] == "Run" && p.Slides[0].Controls[0].Properties["Enabled"] == "true", "SetActiveXProperties: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/activex/block-004", "SetActiveXProperties", "save-reopen-structure");
    }
}
