using Aspose.Slides;
using Aspose.Slides.Charts;

internal static partial class Program
{
    static void Case01(ISlide slide)
    {
        slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
    }
}
