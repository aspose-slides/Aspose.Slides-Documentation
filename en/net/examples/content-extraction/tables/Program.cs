using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Runtime.Versioning;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

[SupportedOSPlatform("windows")]
internal static class Program
{

    private sealed record Cell(int Row,int Column,int FirstRow,int FirstColumn,int RowSpan,int ColumnSpan,bool Merged,string? Text);
    private sealed record TableData(int Slide,string Shape,Cell[] Cells);
    private static void Main()
    {
        Example.Setup();using(var p=new Presentation())
        {var group=p.Slides[0].Shapes.AddGroupShape();var table=group.Shapes.AddTable(30,30,new double[]{200,160,200},new double[]{45,45,45});table.Name="Source table";
         table[0,0].TextFrame.Text="Customer";table[1,0].TextFrame.Text="Detail";table.MergeCells(table[1,0],table[2,0],false);
         table[0,1].TextFrame.Text="Acme, Inc.";table[1,1].TextFrame.Text="東京";table[2,1].TextFrame.Text="\"Quoted\"";table[0,2].TextFrame.Text="Résumé";p.Save("output/input.pptx",SaveFormat.Pptx);}
        using var input=new Presentation("output/input.pptx");var tables=new List<TableData>();var csv=new StringBuilder("Slide,Shape,Row,Column,Text\n");
        for(int i=0;i<input.Slides.Count;i++)foreach(var table in Example.Walk(input.Slides[i].Shapes).OfType<ITable>())
        {var cells=new List<Cell>();for(int r=0;r<table.Rows.Count;r++)for(int c=0;c<table.Columns.Count;c++)
         {var cell=table[c,r];bool covered=cell.IsMergedCell&&(cell.FirstRowIndex!=r||cell.FirstColumnIndex!=c);string? text=covered?null:cell.TextFrame.Text;
          cells.Add(new(r,c,cell.FirstRowIndex,cell.FirstColumnIndex,cell.RowSpan,cell.ColSpan,cell.IsMergedCell,text));
          csv.AppendLine(string.Join(",",i+1,Example.CsvCell(table.Name),r,c,Example.CsvCell(text??"")));}
         tables.Add(new(i+1,table.Name,cells.ToArray()));}
        Example.Json("output/tables.json",tables);File.WriteAllText("output/tables.csv",csv.ToString(),new UTF8Encoding(false));
        var rows=Example.Csv(csv.ToString(),5);var extracted=tables.Single().Cells;
        Example.Require(extracted.Single(c=>c.Row==1&&c.Column==0).Text=="Acme, Inc."&&extracted.Single(c=>c.Row==1&&c.Column==1).Text=="東京","Values/Unicode lost.");
        Example.Require(extracted.Single(c=>c.Row==0&&c.Column==2).Text==null&&extracted.Single(c=>c.Row==0&&c.Column==1).ColumnSpan==2,"Merged-cell representation differs.");
        Example.Require(rows.Any(r=>r[4]=="\"Quoted\"")&&rows.Count==10,"CSV quoting or grid size differs.");
        Example.Result(new{tables=1,grid_cells=9,merged_coverage_explicit=true,unicode_and_csv_quoting_checked=true,group_traversal_checked=true});
    }

}
