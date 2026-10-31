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

        double[] widths = { 80, 80 };
        double[] heights = { 30, 30 };
        var table = slide.Shapes.AddTable(50, 50, widths, heights);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<ITable>().Single().Rows.Count == 2 && p.Slides[0].Shapes.OfType<ITable>().Single().Columns.Count == 2, "AddTable: semantic check 1 failed.");
        });
        Context.Pass("elements/table/block-001", "AddTable", "save-reopen-structure");
    }
}
