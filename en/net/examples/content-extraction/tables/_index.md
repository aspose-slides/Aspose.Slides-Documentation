---
title: Extract Table Data
type: docs
weight: 40
url: /net/examples/content-extraction/tables/
description: "Extract table grids from slides and nested groups as JSON and CSV, preserving identifiers, Unicode and merged-cell coordinates."
---

Extract table grids from slides and nested groups as JSON and CSV, preserving identifiers, Unicode and merged-cell coordinates.

## Run the example

Download the [complete project](sample.zip), extract it, and run it with the .NET 8 SDK.
The project pins Aspose.Slides.NET 26.10.0. The example was tested on Windows x64.
For the complete data assertions, set `ASPOSE_LICENSE_PATH` to your own valid license;
the visible helper loads it when supplied. Evaluation mode may truncate text or add watermarks.

```text
dotnet restore Example.csproj --locked-mode
dotnet run --project Example.csproj --configuration Release --no-restore
```

The download contains [Program.cs](Program.cs), [Example.cs](Example.cs), the project,
dependency lock, and any JSON/CSV input. The helper source contains fixture generation,
license loading, serialization and assertions; it is part of the runnable project.
All presentation inputs are generated from original synthetic data. Results go to `output/`.

## Example

```csharp
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
```

## Expected result and checks

The program writes its semantic checks to `output/result.json` and throws if a required
result differs. Expected check values are:

```json
{
  "tables": 1,
  "grid_cells": 9,
  "merged_coverage_explicit": true,
  "unicode_and_csv_quoting_checked": true,
  "group_traversal_checked": true
}
```

Rows and columns in each table are zero-based; slide numbers are one-based. JSON records every grid position and the anchor/extent of merged regions. Covered cells use null text, preventing duplicated merged-cell content. CSV uses blank text for those covered positions; consult JSON for merge structure.

## Learn more

- [Manage Presentation Tables in .NET](https://docs.aspose.com/slides/net/manage-table/)
- [Manage Table Cells in Presentations in .NET](https://docs.aspose.com/slides/net/manage-cells/)
