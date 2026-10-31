using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        slide.Shapes.Remove(smartArt);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<ISmartArt>().Any(), "RemoveSmartArt: semantic check 1 failed.");
        });
        Context.Pass("elements/smart-art/block-003", "RemoveSmartArt", "save-reopen-structure");
    }
}
