using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var group = slide.Shapes.AddGroupShape();

        slide.Shapes.Remove(group);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IGroupShape>().Any(), "RemoveGroupShape: semantic check 1 failed.");
        });
        Context.Pass("elements/group-shape/block-003", "RemoveGroupShape", "save-reopen-structure");
    }
}
