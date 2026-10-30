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
