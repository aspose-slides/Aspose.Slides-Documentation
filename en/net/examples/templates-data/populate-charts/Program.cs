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
        ctx.BeginAction("templates-data/populate-charts/block-001");
        RunExample();
        string path=File.Exists("output/result.json")?"output/result.json":"result.json";
        using var result=JsonDocument.Parse(File.ReadAllText(path));
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        if(ctx.IsLicensed)
        {
            using var expected=JsonDocument.Parse("{\"checks.series_count\":2,\"checks.category_count\":2,\"checks.all_values_checked\":true,\"checks.embedded_workbook_checked\":true}");
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
        ctx.Pass("templates-data/populate-charts/block-001",checks);
        await Task.CompletedTask;
    });


    private sealed record Data(string[] Categories,string[] Series,double[][] Values);
    private static void RunExample()
    {
        Example.Setup();var data=JsonSerializer.Deserialize<Data>(File.ReadAllText("sales.json"))!;
        using(var p=new Presentation()){Example.Chart(p.Slides[0],"Sales");p.Save("output/template.pptx",SaveFormat.Pptx);}
        using(var p=new Presentation("output/template.pptx"))
        {var chart=Example.Named<IChart>(p.Slides[0],"Sales");Example.ChartData(chart,data.Categories,data.Series,data.Values);p.Save("output/report.pptx",SaveFormat.Pptx);Example.Render(p,"output/preview.png");}
        using var result=new Presentation("output/report.pptx");var saved=Example.Named<IChart>(result.Slides[0],"Sales");
        Example.Require(saved.ChartData.Categories.Count==data.Categories.Length,"Category count differs.");
        for(int c=0;c<data.Series.Length;c++)
        {Example.Require(saved.ChartData.Series[c].Name.ToString()==data.Series[c],"Series name differs.");
         for(int r=0;r<data.Categories.Length;r++)
         {Example.Require(saved.ChartData.Categories[r].Value.ToString()==data.Categories[r],"Category differs.");
          Example.Require(Convert.ToDouble(saved.ChartData.Series[c].DataPoints[r].Value.Data,CultureInfo.InvariantCulture)==data.Values[c][r],"Chart value differs.");
          Example.Require(Convert.ToDouble(saved.ChartData.ChartDataWorkbook.GetCell(0,r+1,c+1).Value,CultureInfo.InvariantCulture)==data.Values[c][r],"Workbook value differs.");}}
        using(var stream=saved.ChartData.ReadWorkbookStream())using(var file=File.Create("output/workbook.xlsx"))stream.CopyTo(file);
        Example.Result(new{series_count=data.Series.Length,category_count=data.Categories.Length,all_values_checked=true,embedded_workbook_checked=true});
    }

}
