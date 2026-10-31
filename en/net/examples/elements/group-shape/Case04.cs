using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var group = slide.Shapes.AddGroupShape();
        var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Move shape out of the group.
        slide.Shapes.AddClone(rect);
        group.Shapes.Remove(rect);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IGroupShape>().Single().Shapes.Count == 0 && p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.ShapeType == ShapeType.Rectangle), "UngroupShapes: semantic check 1 failed.");
        });
        Context.Pass("elements/group-shape/block-004", "UngroupShapes", "save-reopen-structure");
    }
}
