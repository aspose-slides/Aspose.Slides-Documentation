using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static void CreateInput()
    {
        Example.Setup();
        using (var p = new Presentation())
        {
            var chart = Example.Chart(p.Slides[0], "Internal chart");
            Example.ChartData(chart, new[] { "Jan", "Feb" }, new[] { "North", "South" }, new[] { new[] { 125.5, 80.0 }, new[] { 50.0, 75.25 } });
            var external = p.Slides.AddEmptySlide(p.LayoutSlides[0]);
            var linked = Example.Chart(external, "External chart");
            Example.ChartData(linked, new[] { "Cached" }, new[] { "Cached" }, new[] { new[] { 10.0 } });
            linked.ChartData.SetExternalWorkbook("https://example.invalid/unfetched.xlsx", false);
            p.Save("output/input.pptx", SaveFormat.Pptx);
        }
    }
}
