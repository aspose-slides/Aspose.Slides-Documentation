using System.Linq;
using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        double[] widths = { 80, 80 };
        double[] heights = { 30, 30 };
        var table = slide.Shapes.AddTable(50, 50, widths, heights);

        // Access first table on slide.
        var firstTable = slide.Shapes.OfType<ITable>().First();

        VerifyCase02(presentation);
    }
}
