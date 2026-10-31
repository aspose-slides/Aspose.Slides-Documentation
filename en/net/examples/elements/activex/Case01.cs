using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Add a new ActiveX control.
        var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Optionally set some properties.
        control.Properties["Value"] = "Text";

        presentation.Save("add_activex.pptm", SaveFormat.Pptm);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Controls.Count == 1 && p.Slides[0].Controls[0].Properties["Value"] == "Text", "AddActiveX: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/activex/block-001", "AddActiveX", "save-reopen-structure");
    }
}
