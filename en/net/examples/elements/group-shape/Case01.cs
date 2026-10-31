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

        var group = slide.Shapes.AddGroupShape();
        group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IGroupShape>().Single().Shapes.Count == 2, "AddGroupShape: semantic check 1 failed.");
        });
        Context.Pass("elements/group-shape/block-001", "AddGroupShape", "save-reopen-structure");
    }
}
