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
    private static ExampleContext Context = null!;

    private static Task<int> RunChecked(string[] args) => ExampleBootstrap.RunAsync(args, async ctx =>
    {
        Context = ctx;
        Example.Context = ctx;
        ctx.BeginAction("content-extraction/tables/block-001");
        ExtractTables();
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

    private static void VerifyExtraction(List<TableData> tables, StringBuilder csv)
    {
        var rows=Example.Csv(csv.ToString(),5);var extracted=tables.Single().Cells;
        Example.Require(extracted.Single(c=>c.Row==1&&c.Column==0).Text==Example.Choice("Acme, Inc.","A,β")&&extracted.Single(c=>c.Row==1&&c.Column==1).Text=="東京","Values/Unicode lost.");
        Example.Require(extracted.Single(c=>c.Row==0&&c.Column==2).Text==null&&extracted.Single(c=>c.Row==0&&c.Column==1).ColumnSpan==2,"Merged-cell representation differs.");
        Example.Require(rows.Any(r=>r[4]==Example.Choice("\"Quoted\"","\"Q\""))&&rows.Count==10,"CSV quoting or grid size differs.");
        Example.Result(new{tables=1,grid_cells=9,merged_coverage_explicit=true,unicode_and_csv_quoting_checked=true,group_traversal_checked=true});
    }
}
