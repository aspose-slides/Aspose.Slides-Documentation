using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation(Context.Input("ink.pptx"));
        var slide = presentation.Slides[0];

        var inkShape = slide.Shapes.OfType<Ink>().First();
        inkShape.CustomData.Tags["kind"] = "Ink";
        if (inkShape != null)
        {
            var tags = inkShape.CustomData.Tags;
            if (tags.Count > 0)
            {
                var tagName = tags.GetNameByIndex(0);
                Context.Require(tags[tagName] == "Ink", "Read the known Ink tag value.");
            }
        }

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<Ink>().Any(), "AccessInk: semantic check 1 failed.");
            Context.Require(p.Slides[0].Shapes.OfType<Ink>().First().CustomData.Tags.Count > 0, "AccessInk: semantic check 2 failed.");
        });
        Context.Pass("elements/ink/block-001", "AccessInk", "save-reopen-structure");
    }
}
