using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
        slide.HeaderFooterManager.SetDateTimeText("Today");

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].HeaderFooterManager.IsDateTimeVisible, "UpdateDateTime: semantic check 1 failed.");
            Context.Require(p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.TextFrame.Text == "Today"), "UpdateDateTime: semantic check 2 failed.");
        });
        Context.Pass("elements/header-footer/block-002", "UpdateDateTime", "save-reopen-structure");
    }
}
