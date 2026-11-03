using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);

    private sealed record Cell(int Row,int Column,int FirstRow,int FirstColumn,int RowSpan,int ColumnSpan,bool Merged,string? Text);

    private sealed record TableData(int Slide,string Shape,Cell[] Cells);

    private static void ExtractTables()
    {
        CreateInput();
        using var input=new Presentation("output/input.pptx");var tables=new List<TableData>();var csv=new StringBuilder("Slide,Shape,Row,Column,Text\n");
        for(int i=0;i<input.Slides.Count;i++)foreach(var table in Example.Walk(input.Slides[i].Shapes).OfType<ITable>())
        {var cells=new List<Cell>();for(int r=0;r<table.Rows.Count;r++)for(int c=0;c<table.Columns.Count;c++)
         {var cell=table[c,r];bool coveredByMergedCell = cell.IsMergedCell&&(cell.FirstRowIndex!=r||cell.FirstColumnIndex!=c);string? text=coveredByMergedCell?null:cell.TextFrame.Text;
          cells.Add(new(r,c,cell.FirstRowIndex,cell.FirstColumnIndex,cell.RowSpan,cell.ColSpan,cell.IsMergedCell,text));
          csv.AppendLine(string.Join(",",i+1,Example.CsvCell(table.Name),r,c,Example.CsvCell(text??"")));}
         tables.Add(new(i+1,table.Name,cells.ToArray()));}
        Example.Json("output/tables.json",tables);File.WriteAllText("output/tables.csv",csv.ToString(),new UTF8Encoding(false));
        VerifyExtraction(tables, csv);
    }
}
