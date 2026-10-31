using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];
        
        var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

        chart.HasTitle = true;

        // Change the chart title.
        chart.ChartTitle.AddTextFrameForOverriding("Sales");

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IChart>().Single().ChartTitle.TextFrameForOverriding.Text == "Sales", "UpdateChartData: semantic check 1 failed.");
        });
        Context.Pass("elements/chart/block-004", "UpdateChartData", "save-reopen-structure");
    }
}
