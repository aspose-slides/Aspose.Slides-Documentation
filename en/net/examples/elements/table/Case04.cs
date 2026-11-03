using Aspose.Slides;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        double[] columnWidths = { 80, 80 };
        double[] rowHeights = { 30, 30 };
        var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        var topLeftCell = table[0, 0];
        var bottomRightCell = table[1, 1];

        // Merge the full 2-by-2 rectangle without splitting any cells.
        table.MergeCells(topLeftCell, bottomRightCell, allowSplitting: false);

        VerifyCase04(presentation);
    }
}
