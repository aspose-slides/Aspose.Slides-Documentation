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

        var group = slide.Shapes.AddGroupShape();
        group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        var firstGroup = slide.Shapes.OfType<IGroupShape>().First();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IGroupShape>().Single().Shapes.Count == 1, "AccessGroupShape: semantic check 1 failed.");
        });
        Context.Pass("elements/group-shape/block-002", "AccessGroupShape", "save-reopen-structure");
    }
}
