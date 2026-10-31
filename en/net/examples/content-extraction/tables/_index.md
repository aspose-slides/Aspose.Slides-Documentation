---
title: Extract Table Data
type: docs
weight: 40
url: /net/examples/content-extraction/tables/
description: "Extract table grids from slides and nested groups as JSON and CSV, preserving identifiers, Unicode and merged-cell coordinates."
---

Extract table grids from slides and nested groups as JSON and CSV, preserving identifiers, Unicode and merged-cell coordinates.

## Run the example

Download the [complete project](example.zip), extract it, and run it with the .NET 8 SDK.
The project pins Aspose.Slides.NET6.CrossPlatform 26.10.0. The complete project uses portable image fixtures and the CrossPlatform package.
For the complete data assertions, set `ASPOSE_LICENSE_PATH` to your own valid license;
the visible helper loads it when supplied. Evaluation mode may truncate text or add watermarks.

```text
dotnet restore Example.csproj 
dotnet run --project Example.csproj --configuration Release --no-restore
```

The download contains [Program.cs](Program.cs), [Example.cs](Example.cs), the project,
dependency lock, and any JSON/CSV input. The helper source contains fixture generation,
license loading, serialization and assertions; it is part of the runnable project.
All presentation inputs are generated from original synthetic data. Results go to `output/`.

## Example

```csharp
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

internal static class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, async ctx =>
    {
        Context = ctx;
        Example.Context = ctx;
        ctx.BeginAction("content-extraction/tables/block-001");
        RunExample();
        string path=File.Exists("output/result.json")?"output/result.json":"result.json";
        using var result=JsonDocument.Parse(File.ReadAllText(path));
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        if(ctx.IsLicensed)
        {
            using var expected=JsonDocument.Parse("{\"checks.tables\":1,\"checks.grid_cells\":9,\"checks.merged_coverage_explicit\":true,\"checks.unicode_and_csv_quoting_checked\":true,\"checks.group_traversal_checked\":true}");
            foreach(var field in expected.RootElement.EnumerateObject())
            {
                var actual=result.RootElement;foreach(string part in field.Name.Split('.'))actual=actual.GetProperty(part);
                ctx.Require(actual.ToString()==field.Value.ToString(),"Licensed assertion differs: "+field.Name);
                checks["licensed-"+field.Name.Replace('.','-')]=true;
            }
        }
        else
        {
            var values=result.RootElement.TryGetProperty("checks",out var nested)?nested:result.RootElement;
            foreach(var field in values.EnumerateObject())if(field.Value.ValueKind==JsonValueKind.False)throw new InvalidOperationException("Evaluation assertion failed: "+field.Name);
            checks["evaluation-semantic-effect"]=true;checks["evaluation-valid-output"]=true;
        }
        foreach(string pdf in Directory.GetFiles(".","*.pdf",SearchOption.AllDirectories))ctx.Require(File.ReadAllBytes(pdf).AsSpan(0,5).SequenceEqual(System.Text.Encoding.ASCII.GetBytes("%PDF-")),"Invalid PDF output.");
        foreach(string png in Directory.GetFiles(".","*.png",SearchOption.AllDirectories)){var image=PortableImage.Decode(File.ReadAllBytes(png));ctx.Require(image.Width>0&&image.Height>0,"Empty PNG output.");}
        ctx.Pass("content-extraction/tables/block-001",checks);
        await Task.CompletedTask;
    });


    private sealed record Cell(int Row,int Column,int FirstRow,int FirstColumn,int RowSpan,int ColumnSpan,bool Merged,string? Text);
    private sealed record TableData(int Slide,string Shape,Cell[] Cells);
    private static void RunExample()
    {
        Example.Setup();using(var p=new Presentation())
        {var group=p.Slides[0].Shapes.AddGroupShape();var table=group.Shapes.AddTable(30,30,new double[]{200,160,200},new double[]{45,45,45});table.Name="Source table";
         table[0,0].TextFrame.Text="Customer";table[1,0].TextFrame.Text="Detail";table.MergeCells(table[1,0],table[2,0],false);
         table[0,1].TextFrame.Text=Example.Choice("Acme, Inc.","A,β");table[1,1].TextFrame.Text="東京";table[2,1].TextFrame.Text=Example.Choice("\"Quoted\"","\"Q\"");table[0,2].TextFrame.Text=Example.Choice("Résumé","é");p.Save("output/input.pptx",SaveFormat.Pptx);}
        using var input=new Presentation("output/input.pptx");var tables=new List<TableData>();var csv=new StringBuilder("Slide,Shape,Row,Column,Text\n");
        for(int i=0;i<input.Slides.Count;i++)foreach(var table in Example.Walk(input.Slides[i].Shapes).OfType<ITable>())
        {var cells=new List<Cell>();for(int r=0;r<table.Rows.Count;r++)for(int c=0;c<table.Columns.Count;c++)
         {var cell=table[c,r];bool covered=cell.IsMergedCell&&(cell.FirstRowIndex!=r||cell.FirstColumnIndex!=c);string? text=covered?null:cell.TextFrame.Text;
          cells.Add(new(r,c,cell.FirstRowIndex,cell.FirstColumnIndex,cell.RowSpan,cell.ColSpan,cell.IsMergedCell,text));
          csv.AppendLine(string.Join(",",i+1,Example.CsvCell(table.Name),r,c,Example.CsvCell(text??"")));}
         tables.Add(new(i+1,table.Name,cells.ToArray()));}
        Example.Json("output/tables.json",tables);File.WriteAllText("output/tables.csv",csv.ToString(),new UTF8Encoding(false));
        var rows=Example.Csv(csv.ToString(),5);var extracted=tables.Single().Cells;
        Example.Require(extracted.Single(c=>c.Row==1&&c.Column==0).Text==Example.Choice("Acme, Inc.","A,β")&&extracted.Single(c=>c.Row==1&&c.Column==1).Text=="東京","Values/Unicode lost.");
        Example.Require(extracted.Single(c=>c.Row==0&&c.Column==2).Text==null&&extracted.Single(c=>c.Row==0&&c.Column==1).ColumnSpan==2,"Merged-cell representation differs.");
        Example.Require(rows.Any(r=>r[4]==Example.Choice("\"Quoted\"","\"Q\""))&&rows.Count==10,"CSV quoting or grid size differs.");
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


## Open and run the complete project

[Download the complete project](example.zip), extract it and open `Example.sln`, or run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release -- --mode evaluation
```

Use the current supported .NET 10 SDK/runtime. The project keeps a stable `net8.0`
target and accepts compatible stable SDKs; no exact SDK patch is required.
Evaluation runs without a license and explicitly ignores license environment settings.
It uses bounded fixtures and checks valid output while allowing the evaluation watermark
and documented read-back text truncation. For unrestricted checks, use `--mode licensed`
with your authorized `ASPOSE_LICENSE_PATH`. No license is included.

Inputs are copied from `Fixtures` into a separate output workspace. The program prints
the absolute output path; `execution.json` records the actual runtime and verified action.
The portable PNG helper creates original synthetic pixels without a Windows bitmap engine.
See [setup and prerequisites](/slides/net/examples/getting-started/) for native libraries,
fonts, IDE settings and the .NET 8/9 runtime support boundary of 2026-11-10.
