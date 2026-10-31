using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Add a simple area chart to the first slide.
        var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IChart>().Single().Type == ChartType.Area, "AddChart: semantic check 1 failed.");
        });
        Context.Pass("elements/chart/block-001", "AddChart", "save-reopen-structure");
    }
}
