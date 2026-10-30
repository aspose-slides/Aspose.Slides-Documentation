---
title: Populate Tables from Data
type: docs
weight: 40
url: /net/examples/templates-data/populate-tables/
description: "Read CSV records with quoted commas and Unicode, reuse a formatted row, and produce a table with explicit number and date formatting."
---

Read CSV records with quoted commas and Unicode, reuse a formatted row, and produce a table with explicit number and date formatting.

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

    private sealed record Row(string Customer,decimal Amount,DateTime Date);
    private static List<Row> Read(string text)
    {
        var csv=Example.Csv(text,3);if(csv.Count==0 || !csv[0].SequenceEqual(new[]{"Customer","Amount","Date"}))throw new InvalidDataException("Expected Customer,Amount,Date header.");
        return csv.Skip(1).Select(r=>new Row(r[0],decimal.Parse(r[1],NumberStyles.Number,CultureInfo.InvariantCulture),DateTime.ParseExact(r[2],"yyyy-MM-dd",CultureInfo.InvariantCulture))).ToList();
    }
    private static void Fill(ITable table,List<Row> rows)
    {
        if(rows.Count==0){table.Rows.RemoveAt(1,false);return;}
        for(int i=0;i<rows.Count;i++)
        {if(i>0)table.Rows.AddClone(table.Rows[1],false);table[0,i+1].TextFrame.Text=rows[i].Customer;
         table[1,i+1].TextFrame.Text=rows[i].Amount.ToString("0.00",CultureInfo.InvariantCulture);table[2,i+1].TextFrame.Text=rows[i].Date.ToString("yyyy-MM-dd",CultureInfo.InvariantCulture);}
    }
    private static void Main()
    {
        Example.Setup();var rows=Read(File.ReadAllText("records.csv"));
        using(var p=new Presentation())
        {var table=p.Slides[0].Shapes.AddTable(35,50,new double[]{280,140,180},new double[]{50,45});table.Name="Records";
         string[] labels={"Customer","Amount","Date"};for(int c=0;c<3;c++){table[c,0].TextFrame.Text=labels[c];table[c,0].TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold=NullableBool.True;}
         Fill(table,rows);p.Save("output/report.pptx",SaveFormat.Pptx);Example.Render(p,"output/preview.png");}
        using var reopened=new Presentation("output/report.pptx");var saved=Example.Named<ITable>(reopened.Slides[0],"Records");
        Example.Require(saved.Rows.Count==rows.Count+1,"Wrong row count.");
        for(int i=0;i<rows.Count;i++){Example.Require(saved[0,i+1].TextFrame.Text==rows[i].Customer,"Customer differs.");Example.Require(saved[1,i+1].TextFrame.Text==rows[i].Amount.ToString("0.00",CultureInfo.InvariantCulture),"Amount differs.");}
        Example.Require(saved[0,0].TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold==NullableBool.True,"Header style lost.");
        using var empty=new Presentation();var emptyTable=empty.Slides[0].Shapes.AddTable(0,0,new double[]{100,100,100},new double[]{30,30});Fill(emptyTable,Read("Customer,Amount,Date\n"));
        bool missing=Example.Throws(()=>Read("Customer,Amount,Date\nAcme,10.00\n"));
        Example.Require(emptyTable.Rows.Count==1 && missing,"Empty/missing-field behavior differs.");
        Example.Result(new{data_rows=rows.Count,quoted_comma_and_unicode_checked=true,invariant_numbers_checked=true,empty_keeps_header=true,missing_field_rejected=missing,header_format_retained=true});
    }

}
```

## Expected result and checks

The program writes its semantic checks to `output/result.json` and throws if a required
result differs. Expected check values are:

```json
{
  "data_rows": 2,
  "quoted_comma_and_unicode_checked": true,
  "invariant_numbers_checked": true,
  "empty_keeps_header": true,
  "missing_field_rejected": true,
  "header_format_retained": true
}
```

CSV parsing uses the .NET TextFieldParser and invariant number/date conversion. An empty dataset keeps only the header. A malformed row with a missing field is rejected. Every cell is assigned after cloning so data does not leak from the previous row.

## Learn more

- [Manage Presentation Tables in .NET](https://docs.aspose.com/slides/net/manage-table/)
- [Manage Rows and Columns in PowerPoint Tables in .NET](https://docs.aspose.com/slides/net/manage-rows-and-columns/)
- [Manage Table Cells in Presentations in .NET](https://docs.aspose.com/slides/net/manage-cells/)
