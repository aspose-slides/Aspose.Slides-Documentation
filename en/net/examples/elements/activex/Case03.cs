using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation(Seed("control"));
        var slide = presentation.Slides[0];

        if (slide.Controls.Count > 0)
        {
            // Remove the first ActiveX control.
            slide.Controls.RemoveAt(0);
        }

        presentation.Save("removed_activex.pptm", SaveFormat.Pptm);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Slides[0].Controls.Count == 0, "RemoveActiveX: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/activex/block-003", "RemoveActiveX", "save-reopen-structure");
    }
}
