using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

        // Remove the chart.
        slide.Shapes.Remove(chart);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IChart>().Any(), "RemoveChart: semantic check 1 failed.");
        });
        Context.Pass("elements/chart/block-003", "RemoveChart", "save-reopen-structure");
    }
}
