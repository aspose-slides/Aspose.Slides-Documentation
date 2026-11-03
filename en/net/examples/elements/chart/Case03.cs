using Aspose.Slides;
using Aspose.Slides.Charts;

internal static partial class Program
{
    static void Case03(ISlide slide)
    {
        var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);
        slide.Shapes.Remove(chart);
    }
}
