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
        
        double[] widths = { 80, 80 };
        double[] heights = { 30, 30 };
        var table = slide.Shapes.AddTable(50, 50, widths, heights);

        table.MergeCells(table[0, 0], table[1, 1], false);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<ITable>().Single().Rows.Count == 1 && p.Slides[0].Shapes.OfType<ITable>().Single().Columns.Count == 1, "MergeTableCells: semantic check 1 failed.");
            Context.Require(Math.Abs(p.Slides[0].Shapes.OfType<ITable>().Single()[0, 0].Width - 160) < 0.1 && Math.Abs(p.Slides[0].Shapes.OfType<ITable>().Single()[0, 0].Height - 60) < 0.1, "MergeTableCells: semantic check 2 failed.");
        });
        Context.Pass("elements/table/block-004", "MergeTableCells", "save-reopen-structure");
    }
}
