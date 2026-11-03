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
            Context.Require(p.Slides[0].Shapes.OfType<ITable>().Single().Rows.Count == 2 && p.Slides[0].Shapes.OfType<ITable>().Single().Columns.Count == 2, "AddTable: semantic check 1 failed.");
        });
        Context.Pass("elements/table/block-001", "AddTable", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<ITable>().Single().Rows.Count == 2, "AccessTable: semantic check 1 failed.");
        });
        Context.Pass("elements/table/block-002", "AccessTable", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<ITable>().Any(), "RemoveTable: semantic check 1 failed.");
        });
        Context.Pass("elements/table/block-003", "RemoveTable", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<ITable>().Single().Rows.Count == 1 && p.Slides[0].Shapes.OfType<ITable>().Single().Columns.Count == 1, "MergeTableCells: semantic check 1 failed.");
            Context.Require(Math.Abs(p.Slides[0].Shapes.OfType<ITable>().Single()[0, 0].Width - 160) < 0.1 && Math.Abs(p.Slides[0].Shapes.OfType<ITable>().Single()[0, 0].Height - 60) < 0.1, "MergeTableCells: semantic check 2 failed.");
        });
        Context.Pass("elements/table/block-004", "MergeTableCells", "save-reopen-structure");
    }
}
