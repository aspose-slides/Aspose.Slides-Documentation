using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Json;
using Microsoft.VisualBasic.FileIO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

[SupportedOSPlatform("windows")]
internal static class Example
{
    public static void Setup()
    {
        string? path=Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(path)) { var license=new License(); license.SetLicense(path); }
        else Console.WriteLine("Evaluation mode can truncate text; use a valid license for the full data checks.");
        Directory.CreateDirectory("output");
    }
    public static void Require(bool value,string message) { if(!value) throw new InvalidOperationException(message); }
    public static string Hash(byte[] data)=>Convert.ToHexString(SHA256.HashData(data)).ToLowerInvariant();
    public static string HashFile(string path)=>Hash(File.ReadAllBytes(path));
    public static void Result(object checks)
    { File.WriteAllText("output/result.json",JsonSerializer.Serialize(new {checks},new JsonSerializerOptions{WriteIndented=true}),new UTF8Encoding(false)); }
    public static void Json(string path,object value)
    { File.WriteAllText(path,JsonSerializer.Serialize(value,new JsonSerializerOptions{WriteIndented=true}),new UTF8Encoding(false)); }
    public static IAutoShape Text(IShapeCollection shapes,string name,string value,float x=35,float y=35,float width=600,float height=70)
    {
        var shape=shapes.AddAutoShape(ShapeType.Rectangle,x,y,width,height);
        shape.Name=name; shape.TextFrame.Text=value;
        shape.FillFormat.FillType=FillType.Solid; shape.FillFormat.SolidFillColor.Color=Color.White;
        foreach(var para in shape.TextFrame.Paragraphs) foreach(var portion in para.Portions)
        { portion.PortionFormat.LatinFont=new FontData("Arial"); portion.PortionFormat.FontHeight=20; portion.PortionFormat.FillFormat.FillType=FillType.Solid; portion.PortionFormat.FillFormat.SolidFillColor.Color=Color.FromArgb(35,65,100); }
        return shape;
    }
    public static IEnumerable<IShape> Walk(IShapeCollection shapes)
    { foreach(IShape shape in shapes){yield return shape;if(shape is IGroupShape group)foreach(var child in Walk(group.Shapes))yield return child;} }
    public static IEnumerable<ITextFrame> Frames(ISlide slide)
    {
        foreach(var shape in Walk(slide.Shapes))
        { if(shape is IAutoShape auto)yield return auto.TextFrame;
          if(shape is ITable table)for(int r=0;r<table.Rows.Count;r++)for(int c=0;c<table.Columns.Count;c++)yield return table[c,r].TextFrame; }
    }
    public static T Named<T>(ISlide slide,string name) where T:class,IShape
    { var found=Walk(slide.Shapes).Where(s=>s.Name==name).ToArray(); if(found.Length!=1 || found[0] is not T typed)throw new InvalidDataException("Expected one named shape: "+name);return typed; }
    public static void Render(Presentation p,string path)
    { using var image=p.Slides[0].GetImage(new Size(800,450));image.Save(path,Aspose.Slides.ImageFormat.Png); }
    public static byte[] Png(int width,int height,Color color)
    {
        using var bitmap=new Bitmap(width,height);using var g=Graphics.FromImage(bitmap);g.Clear(color);
        using var brush=new SolidBrush(Color.White);g.FillEllipse(brush,width/4,height/4,width/2,height/2);
        using var stream=new MemoryStream();bitmap.Save(stream,System.Drawing.Imaging.ImageFormat.Png);return stream.ToArray();
    }
    public static List<string[]> Csv(string text,int columns)
    {
        using var parser=new TextFieldParser(new StringReader(text));parser.SetDelimiters(",");parser.HasFieldsEnclosedInQuotes=true;parser.TrimWhiteSpace=false;
        var rows=new List<string[]>();while(!parser.EndOfData){var row=parser.ReadFields()!;if(row.Length!=columns)throw new InvalidDataException("CSV field count differs.");rows.Add(row);}return rows;
    }
    public static string CsvCell(string text)=>"\""+text.Replace("\"","\"\"")+"\"";
    public static string SafeOutput(string folder,string filename)
    {
        string root=Path.GetFullPath(folder)+Path.DirectorySeparatorChar;
        string path=Path.GetFullPath(Path.Combine(folder,filename));
        if(!path.StartsWith(root,StringComparison.OrdinalIgnoreCase))throw new InvalidDataException("Output escapes its directory.");return path;
    }
    public static IChart Chart(ISlide slide,string name)
    { var chart=slide.Shapes.AddChart(ChartType.ClusteredColumn,40,130,620,290);chart.Name=name;return chart; }
    public static void ChartData(IChart chart,string[] categories,string[] series,double[][] values)
    {
        var data=chart.ChartData;var book=data.ChartDataWorkbook;data.Series.Clear();data.Categories.Clear();book.Clear(0);
        for(int r=0;r<categories.Length;r++)data.Categories.Add(book.GetCell(0,r+1,0,categories[r]));
        for(int c=0;c<series.Length;c++)
        {var item=data.Series.Add(book.GetCell(0,0,c+1,series[c]),ChartType.ClusteredColumn);
         for(int r=0;r<categories.Length;r++)item.DataPoints.AddDataPointForBarSeries(book.GetCell(0,r+1,c+1,values[c][r]));}
    }
    public static bool Throws(Action action)
    {try{action();return false;}catch(InvalidDataException){return true;}}
}
