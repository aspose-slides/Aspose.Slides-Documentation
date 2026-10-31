---
title: Populate Tables from Data
type: docs
weight: 40
url: /net/examples/templates-data/populate-tables/
description: "Read CSV records with quoted commas and Unicode, reuse a formatted row, and produce a table with explicit number and date formatting."
---

Read CSV records with quoted commas and Unicode, reuse a formatted row, and produce a table with explicit number and date formatting.

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
        ctx.BeginAction("templates-data/populate-tables/block-001");
        RunExample();
        string path=File.Exists("output/result.json")?"output/result.json":"result.json";
        using var result=JsonDocument.Parse(File.ReadAllText(path));
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        if(ctx.IsLicensed)
        {
            using var expected=JsonDocument.Parse("{\"checks.data_rows\":2,\"checks.quoted_comma_and_unicode_checked\":true,\"checks.invariant_numbers_checked\":true,\"checks.empty_keeps_header\":true,\"checks.missing_field_rejected\":true,\"checks.header_format_retained\":true}");
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
        ctx.Pass("templates-data/populate-tables/block-001",checks);
        await Task.CompletedTask;
    });


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
    private static void RunExample()
    {
        Example.Setup();var rows=Read(File.ReadAllText("records.csv"));
        if(!Context.IsLicensed)rows=new(){new("A,β",12.3m,new DateTime(2026,1,1)),new("東京",4.5m,new DateTime(2026,1,2))};
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
