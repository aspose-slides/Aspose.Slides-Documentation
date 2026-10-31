using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

        // Access the first chart on the slide.
        var firstChart = slide.Shapes.OfType<IChart>().First();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IChart>().Single().Type == ChartType.Line, "AccessChart: semantic check 1 failed.");
        });
        Context.Pass("elements/chart/block-002", "AccessChart", "save-reopen-structure");
    }
}
