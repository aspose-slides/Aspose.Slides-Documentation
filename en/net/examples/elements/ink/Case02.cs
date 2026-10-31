using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation(Context.Input("ink.pptx"));
        var slide = presentation.Slides[0];

        if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
        {
            slide.Shapes.Remove(ink);
        }

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<Ink>().Any(), "RemoveInk: semantic check 1 failed.");
        });
        Context.Pass("elements/ink/block-002", "RemoveInk", "save-reopen-structure");
    }
}
