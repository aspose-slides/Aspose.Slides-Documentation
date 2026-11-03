using System.Linq;
using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        double[] columnWidths = { 80, 80 };
        double[] rowHeights = { 30, 30 };
        slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Access first table on slide.
        var firstTable = slide.Shapes.OfType<ITable>().First();

        VerifyCase02(presentation);
    }
}
