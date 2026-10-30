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

    private sealed record Data(string[] Categories,string[] Series,double[][] Values);
    private static void Main()
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
