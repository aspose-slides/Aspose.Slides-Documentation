using Aspose.Slides;
using Aspose.Slides.Charts;

internal static partial class Program
{
    static void Case04(ISlide slide)
    {
        var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Sales");
    }
}
