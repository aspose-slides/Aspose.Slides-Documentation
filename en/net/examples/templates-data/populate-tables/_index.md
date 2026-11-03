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

    public static IEnumerable<IShape> Walk(IShapeCollection shapes)
    { foreach(IShape shape in shapes){yield return shape;if(shape is IGroupShape group)foreach(var child in Walk(group.Shapes))yield return child;} }

    public static T Named<T>(ISlide slide,string name) where T:class,IShape
    { var found=Walk(slide.Shapes).Where(s=>s.Name==name).ToArray(); if(found.Length!=1 || found[0] is not T typed)throw new InvalidDataException("Expected one named shape: "+name);return typed; }

    public static void Render(Presentation p,string path)
    { using var image=p.Slides[0].GetImage(new Size(800,450));image.Save(path,Aspose.Slides.ImageFormat.Png); }

    public static byte[] Png(int width,int height,Color color) => PortableImage.Png(width,height,color);

    public static List<string[]> Csv(string text,int columns)
    {
        using var parser=new TextFieldParser(new StringReader(text));parser.SetDelimiters(",");parser.HasFieldsEnclosedInQuotes=true;parser.TrimWhiteSpace=false;
        var rows=new List<string[]>();while(!parser.EndOfData){var row=parser.ReadFields()!;if(row.Length!=columns)throw new InvalidDataException("CSV field count differs.");rows.Add(row);}return rows;
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
            File.WriteAllText(Path.Combine(output, "records.csv"), """
                Customer,Amount,Date
                "Acme, Inc.",125.50,2026-10-01
                東京商事,75.25,2026-10-02
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
