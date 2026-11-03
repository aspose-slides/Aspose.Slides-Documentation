using Aspose.Slides.Export;
using Aspose.Slides;
using System.IO;
using System.Linq;
using System;

internal static partial class Program
{
    private static void VerifyCase01(Presentation presentation)
    {
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IGroupShape>().Single().Shapes.Count == 2, "AddGroupShape: semantic check 1 failed.");
        });
        Context.Pass("elements/group-shape/block-001", "AddGroupShape", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IGroupShape>().Single().Shapes.Count == 1, "AccessGroupShape: semantic check 1 failed.");
        });
        Context.Pass("elements/group-shape/block-002", "AccessGroupShape", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IGroupShape>().Any(), "RemoveGroupShape: semantic check 1 failed.");
        });
        Context.Pass("elements/group-shape/block-003", "RemoveGroupShape", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IGroupShape>().Single().Shapes.Count == 0 && p.Slides[0].Shapes.OfType<IAutoShape>().Any(s => s.ShapeType == ShapeType.Rectangle), "UngroupShapes: semantic check 1 failed.");
        });
        Context.Pass("elements/group-shape/block-004", "UngroupShapes", "save-reopen-structure");
    }
}
