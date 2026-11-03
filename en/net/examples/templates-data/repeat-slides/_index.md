---
title: Repeat a Template Slide for Each Record
type: docs
weight: 50
url: /net/examples/templates-data/repeat-slides/
description: "Clone one template slide per customer, then fill its text, chart and picture from JSON records."
---

Clone one template slide per customer, then fill its text, chart and picture from JSON records.

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

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

```csharp
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;
using Aspose.Slides;
using Microsoft.VisualBasic.FileIO;

internal static class Program
{
    private sealed record Customer(string Name,double Amount,string Color);

    private static string[] Generate(Customer[] customers,string path)
    {
        using var p=new Presentation();var template=p.Slides[0];
        Example.Text(template.Shapes,"Customer","{{Customer}}",35,20,600,70);Example.Chart(template,"Sales");
        template.Shapes.AddPictureFrame(ShapeType.Rectangle,600,15,60,60,p.Images.AddImage(Example.Png(60,60,Color.Gray))).Name="Logo";
        foreach(var customer in customers)
        {var slide=p.Slides.AddClone(template);Example.Named<IAutoShape>(slide,"Customer").TextFrame.ReplaceText("{{Customer}}",customer.Name,new TextSearchOptions(),null);
         Example.ChartData(Example.Named<IChart>(slide,"Sales"),new[]{"Sales"},new[]{customer.Name},new[]{new[]{customer.Amount}});
         Example.Named<IPictureFrame>(slide,"Logo").PictureFormat.Picture.Image=p.Images.AddImage(Example.Png(60,60,Color.FromName(customer.Color)));}
        p.Slides.Remove(template);Example.Require(p.Slides.Count==customers.Length,"Default/template slide leaked.");
        if(customers.Length==0)return Array.Empty<string>();
        p.Save(path,SaveFormat.Pptx);Example.Render(p,path+".png");using var reopened=new Presentation(path);
        var values=reopened.Slides.Cast<ISlide>().Select(s=>Example.Named<IAutoShape>(s,"Customer").TextFrame.Text).ToArray();
        for(int i=0;i<customers.Length;i++)Example.Require(Convert.ToDouble(Example.Named<IChart>(reopened.Slides[i],"Sales").ChartData.Series[0].DataPoints[0].Value.Data)==customers[i].Amount,"Record state leaked.");return values;
    }

    private static void RunExample()
    {
        Example.Setup();var data=JsonSerializer.Deserialize<Customer[]>(File.ReadAllText("customers.json"))!;
        if(!Context.IsLicensed)data=data.Select((c,i)=>c with{Name=i==0?"Acme":"東京"}).ToArray();
        var first=Generate(data,"output/report.pptx");var second=Generate(data,"output/repeated.pptx");
        Example.Require(first.SequenceEqual(data.Select(c=>c.Name))&&first.SequenceEqual(second),"Order or repeatability differs.");
        Example.Require(Generate(Array.Empty<Customer>(),"output/empty.pptx").Length==0,"Empty data not handled.");
        using var duplicate=new Presentation();Example.Text(duplicate.Slides[0].Shapes,"Duplicate","A");Example.Text(duplicate.Slides[0].Shapes,"Duplicate","B");
        bool rejected=Example.Throws(()=>Example.Named<IAutoShape>(duplicate.Slides[0],"Duplicate"));Example.Require(rejected,"Duplicate name accepted.");
        Example.Result(new{slide_count=data.Length,order_preserved=true,no_template_slide=true,no_state_leak=true,semantic_repeatability=true,duplicate_name_rejected=rejected});
    }

    private static ExampleContext Context = null!;

    private static Task<int> Main() => ExampleBootstrap.RunAsync(async ctx =>
    {
        Context = ctx;
        Example.Context = ctx;
        RunExample();
        await Task.CompletedTask;
    });
}

internal static class Example
{
    public static ExampleContext Context = null!;

    public static void Setup() { Directory.CreateDirectory("output"); }

    public static void Require(bool value,string message) { if(!value) throw new InvalidOperationException(message); }

    public static void Result(object checks)
    { File.WriteAllText("output/result.json",JsonSerializer.Serialize(new {checks},new JsonSerializerOptions{WriteIndented=true}),new UTF8Encoding(false)); }

    public static IAutoShape Text(IShapeCollection shapes,string name,string value,float x=35,float y=35,float width=600,float height=70)
    {
        var shape=shapes.AddAutoShape(ShapeType.Rectangle,x,y,width,height);
        shape.Name=name; shape.TextFrame.Text=value;
        shape.FillFormat.FillType=FillType.Solid; shape.FillFormat.SolidFillColor.Color=Color.White;
        foreach(var para in shape.TextFrame.Paragraphs) foreach(var portion in para.Portions)
        { portion.PortionFormat.LatinFont=new FontData("Noto Sans"); portion.PortionFormat.FontHeight=20; portion.PortionFormat.FillFormat.FillType=FillType.Solid; portion.PortionFormat.FillFormat.SolidFillColor.Color=Color.FromArgb(35,65,100); }
        return shape;
    }

    public static IEnumerable<IShape> Walk(IShapeCollection shapes)
    { foreach(IShape shape in shapes){yield return shape;if(shape is IGroupShape group)foreach(var child in Walk(group.Shapes))yield return child;} }

    public static T Named<T>(ISlide slide,string name) where T:class,IShape
    { var found=Walk(slide.Shapes).Where(s=>s.Name==name).ToArray(); if(found.Length!=1 || found[0] is not T typed)throw new InvalidDataException("Expected one named shape: "+name);return typed; }

    public static void Render(Presentation p,string path)
    { using var image=p.Slides[0].GetImage(new Size(800,450));image.Save(path,Aspose.Slides.ImageFormat.Png); }

    public static byte[] Png(int width,int height,Color color) => PortableImage.Png(width,height,color);

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

// Original deterministic fixture pixels and a small portable 8-bit PNG codec.
// No operating-system bitmap engine or external image/font download is used.
internal static class PortableImage
{
    public sealed record Pixels(int Width, int Height, byte[] Rgba);

    public static byte[] Png(int width, int height, Color color)
    {
        byte[] pixels = new byte[checked(width * height * 4)];
        for (int y=0;y<height;y++) for(int x=0;x<width;x++)
        {
            double dx=(x-width/2.0)/(width/4.0),dy=(y-height/2.0)/(height/4.0);
            Color c=dx*dx+dy*dy<=1?Color.White:color; int i=(y*width+x)*4;
            pixels[i]=c.R;pixels[i+1]=c.G;pixels[i+2]=c.B;pixels[i+3]=255;
        }
        return Encode(new Pixels(width,height,pixels));
    }

    public static byte[] Encode(Pixels image)
    {
        using var output=new MemoryStream();output.Write(new byte[]{137,80,78,71,13,10,26,10});
        byte[] header=new byte[13];BinaryPrimitives.WriteInt32BigEndian(header.AsSpan(0,4),image.Width);BinaryPrimitives.WriteInt32BigEndian(header.AsSpan(4,4),image.Height);header[8]=8;header[9]=6;Chunk(output,"IHDR",header);
        using var compressed=new MemoryStream();using(var z=new ZLibStream(compressed,System.IO.Compression.CompressionLevel.Optimal,true))for(int y=0;y<image.Height;y++){z.WriteByte(0);z.Write(image.Rgba,y*image.Width*4,image.Width*4);}
        Chunk(output,"IDAT",compressed.ToArray());Chunk(output,"IEND",Array.Empty<byte>());return output.ToArray();
    }

    private static void Chunk(Stream stream,string type,byte[] data)
    {
        byte[] name=Encoding.ASCII.GetBytes(type),size=new byte[4];BinaryPrimitives.WriteInt32BigEndian(size,data.Length);stream.Write(size);stream.Write(name);stream.Write(data);
        uint crc=0xffffffff;foreach(byte value in name)crc=Crc(crc,value);foreach(byte value in data)crc=Crc(crc,value);BinaryPrimitives.WriteUInt32BigEndian(size,crc^0xffffffff);stream.Write(size);
    }

    private static uint Crc(uint crc,byte value){crc^=value;for(int i=0;i<8;i++)crc=(crc&1)!=0?0xedb88320^(crc>>1):crc>>1;return crc;}
}

internal static class ExampleBootstrap
{
    public static async Task<int> RunAsync(Func<ExampleContext, Task> run)
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        string start = Environment.CurrentDirectory;
        string output = Directory.CreateDirectory(Path.Combine(start, "example-output")).FullName;
        try
        {
            File.WriteAllText(Path.Combine(output, "customers.json"), """
                [
                  {
                    "Name": "Acme Customer",
                    "Amount": 125.5,
                    "Color": "Teal"
                  },
                  {
                    "Name": "東京 Customer",
                    "Amount": 75.25,
                    "Color": "Orange"
                  }
                ]
                """ + "\n");
            Environment.CurrentDirectory = output;
            await run(new ExampleContext(output, !string.IsNullOrWhiteSpace(licensePath)));
            Console.WriteLine("Output: " + output);
            return 0;
        }
        finally
        {
            Environment.CurrentDirectory = start;
        }
    }
}

internal sealed record ExampleContext(string OutputRoot, bool IsLicensed);
```

## Expected result and checks

The program writes its semantic checks to `output/result.json` and throws if a required
result differs. Expected check values are:

```json
{
  "slide_count": 2,
  "order_preserved": true,
  "no_template_slide": true,
  "no_state_leak": true,
  "semantic_repeatability": true,
  "duplicate_name_rejected": true
}
```

The original template slide is removed deliberately. Output order matches the data order. The checks compare repeatable content, not identical ZIP bytes or timestamps. Shape names must be unique within the relevant slide; duplicate names are rejected. An empty dataset returns no report slides.

## Learn more

- [Clone Presentation Slides in .NET](https://docs.aspose.com/slides/net/clone-slides/)
- [Manage Presentation Placeholders in .NET](https://docs.aspose.com/slides/net/manage-placeholder/)


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
