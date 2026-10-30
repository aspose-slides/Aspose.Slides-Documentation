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

    private sealed record SeriesData(string Name,double?[] Values);
    private sealed record ChartData(int Slide,string Shape,string Source,string? ExternalWorkbook,string[] Categories,SeriesData[] Series);
    private static void Main()
    {
        Example.Setup();using(var p=new Presentation())
        {var chart=Example.Chart(p.Slides[0],"Internal chart");Example.ChartData(chart,new[]{"Jan","Feb"},new[]{"North","South"},new[]{new[]{125.5,80.0},new[]{50.0,75.25}});
         var external=p.Slides.AddEmptySlide(p.LayoutSlides[0]);var linked=Example.Chart(external,"External chart");Example.ChartData(linked,new[]{"Cached"},new[]{"Cached"},new[]{new[]{10.0}});linked.ChartData.SetExternalWorkbook("https://example.invalid/unfetched.xlsx",false);p.Save("output/input.pptx",SaveFormat.Pptx);}
        using var input=new Presentation("output/input.pptx");var rows=new List<ChartData>();int workbooks=0;
        for(int i=0;i<input.Slides.Count;i++)foreach(var chart in Example.Walk(input.Slides[i].Shapes).OfType<IChart>())
        {var data=chart.ChartData;bool external=data.DataSourceType==ChartDataSourceType.ExternalWorkbook;
         // Do not read linked category/series cells: doing so can open the external workbook.
         var categories=external?Array.Empty<string>():data.Categories.Select(c=>c.Value?.ToString()??"").ToArray();
         var series=external?Array.Empty<SeriesData>():data.Series.Select(s=>new SeriesData(s.Name.ToString(),s.DataPoints.Select(point=>point.Value.Data==null?(double?)null:Convert.ToDouble(point.Value.Data,CultureInfo.InvariantCulture)).ToArray())).ToArray();
         rows.Add(new(i+1,chart.Name,external?"external_not_read":"embedded",external?data.ExternalWorkbookPath:null,categories,series));
         if(!external){using var stream=data.ReadWorkbookStream();using var file=File.Create("output/workbook-"+(i+1)+".xlsx");stream.CopyTo(file);workbooks++;}}
        Example.Json("output/chart-data.json",rows);
        var first=rows[0];Example.Require(first.Categories.SequenceEqual(new[]{"Jan","Feb"}),"Categories differ.");
        Example.Require(first.Series[0].Name=="North"&&first.Series[1].Name=="South","Series names differ.");
        Example.Require(first.Series[0].Values.SequenceEqual(new double?[]{125.5,80})&&first.Series[1].Values.SequenceEqual(new double?[]{50,75.25}),"Numeric data differs.");
        Example.Require(rows[1].ExternalWorkbook=="https://example.invalid/unfetched.xlsx"&&workbooks==1,"External workbook policy differs.");
        using(var zip=ZipFile.OpenRead("output/workbook-1.xlsx"))Example.Require(zip.GetEntry("xl/workbook.xml")!=null,"Missing workbook package.");
        Example.Result(new{charts=2,embedded_workbooks=1,external_links=1,all_numeric_values_checked=true,external_data_not_refreshed=true});
    }

}
