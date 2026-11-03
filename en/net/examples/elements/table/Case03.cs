using Aspose.Slides;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        double[] columnWidths = { 80, 80 };
        double[] rowHeights = { 30, 30 };
        var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        slide.Shapes.Remove(table);

        VerifyCase03(presentation);
    }
}
