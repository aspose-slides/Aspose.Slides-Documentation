using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;

internal static partial class Program
{
    static void Case02(ISlide slide)
    {
        slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

        var firstChart = slide.Shapes.OfType<IChart>().First();
        Console.WriteLine(firstChart.Type);
    }
}
