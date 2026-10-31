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

        slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
        slide.HeaderFooterManager.SetFooterText("Foot");

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].HeaderFooterManager.IsFooterVisible, "AddHeaderFooter: semantic check 1 failed.");
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame.Text == "Foot"), "AddHeaderFooter: semantic check 2 failed.");
        });
        Context.Pass("elements/header-footer/block-001", "AddHeaderFooter", "save-reopen-structure");
    }
}
