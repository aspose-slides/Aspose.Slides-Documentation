using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Aspose.Slides;
using System.Threading.Tasks;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private sealed record Cell(int Row, int Column, int FirstRow, int FirstColumn, int RowSpan, int ColumnSpan, bool Merged, string? Text);
    private sealed record TableData(int Slide, string Shape, Cell[] Cells);
    private static bool IsMergedAnchor(ICell cell, int row, int column) => !cell.IsMergedCell || cell.FirstRowIndex == row && cell.FirstColumnIndex == column;
    private static void ExtractTables()
    {
        CreateInput();
        using var input = new Presentation("output/input.pptx");
        var tables = new List<TableData>();
        var csv = new StringBuilder("Slide,Shape,Row,Column,Text\n");
        for (int slideIndex = 0; slideIndex < input.Slides.Count; slideIndex++)
        {
            foreach (var table in Example.Walk(input.Slides[slideIndex].Shapes).OfType<ITable>())
            {
                var cells = new List<Cell>();
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int column = 0; column < table.Columns.Count; column++)
                    {
                        var cell = table[column, row]; // Aspose indexes column first, then row.
                        string? text = IsMergedAnchor(cell, row, column) ? cell.TextFrame.Text : null;
                        var record = new Cell(row, column, cell.FirstRowIndex, cell.FirstColumnIndex, cell.RowSpan, cell.ColSpan, cell.IsMergedCell, text);
                        cells.Add(record);
                        csv.AppendLine(string.Join(",", slideIndex + 1, Example.CsvCell(table.Name), record.Row, record.Column, Example.CsvCell(record.Text ?? "")));
                    }
                }

                tables.Add(new TableData(slideIndex + 1, table.Name, cells.ToArray()));
            }
        }

        Example.Json("output/tables.json", tables);
        File.WriteAllText("output/tables.csv", csv.ToString(), new UTF8Encoding(false));
        VerifyExtraction(tables, csv);
    }
}
