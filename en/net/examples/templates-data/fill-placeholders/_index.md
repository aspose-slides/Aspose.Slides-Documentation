---
title: Fill a Presentation Template
type: docs
weight: 10
url: /net/examples/templates-data/fill-placeholders/
description: "Fill required customer markers, including a marker split across text portions, from JSON. The sample keeps surrounding bold formatting and leaves the template unchanged."
---

Fill required customer markers, including a marker split across text portions, from JSON. The sample keeps surrounding bold formatting and leaves the template unchanged.

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
    private static void Bind(ISlide slide, Dictionary<string, string> data)
    {
        if (!data.TryGetValue("Customer", out string? customer) || string.IsNullOrWhiteSpace(customer))
            throw new InvalidDataException("Customer is required.");

        string optional = data.GetValueOrDefault("Optional", "");
        var search = new TextSearchOptions { CaseSensitive = true };
        foreach (var frame in Example.Frames(slide))
        {
            frame.ReplaceText("{{Customer}}", customer, search, null);
            frame.ReplaceText("{{Optional}}", optional, search, null);
            frame.TextFrameFormat.AutofitType = TextAutofitType.Normal;
        }

        if (Example.Frames(slide).Any(frame => frame.Text.Contains("{{")))
            throw new InvalidDataException("Unbound template marker.");
    }

    private static void RunExample()
    {
        Example.Setup();
        var values=JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText("customer.json"))!;
        using(var template=new Presentation())
        {
            var title=Example.Text(template.Slides[0].Shapes,"Customer","",35,35,600,100);
            var p=title.TextFrame.Paragraphs[0];p.Portions.Clear();
            var prefix=new Portion("Customer: ");prefix.PortionFormat.FontBold=NullableBool.True;p.Portions.Add(prefix);
            p.Portions.Add(new Portion("{{Cus"));p.Portions.Add(new Portion("tomer}}"));
            foreach(var portion in p.Portions){portion.PortionFormat.LatinFont=new FontData("Noto Sans");portion.PortionFormat.FontHeight=24;portion.PortionFormat.FillFormat.FillType=FillType.Solid;portion.PortionFormat.FillFormat.SolidFillColor.Color=Color.FromArgb(35,65,100);}
            Example.Text(template.Slides[0].Shapes,"Optional","{{Optional}}",35,180,600,60);
            template.Save("output/template.pptx",SaveFormat.Pptx);
        }
        string before=Example.HashFile("output/template.pptx");
        using(var p=new Presentation("output/template.pptx"))
        {
            Bind(p.Slides[0],values);p.Save("output/filled.pptx",SaveFormat.Pptx);Example.Render(p,"output/preview.png");
        }
        using var check=new Presentation("output/filled.pptx");
        var shape=Example.Named<IAutoShape>(check.Slides[0],"Customer");
        Example.Require(shape.TextFrame.Text==Example.ExpectedText("Customer: "+values["Customer"]),"Run-spanning marker was not replaced.");
        Example.VerifySavedText("output/filled.pptx","Customer","Customer: "+values["Customer"]);
        Example.Require(shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold==NullableBool.True,"Prefix style changed.");
        bool missing=Example.Throws(()=>Bind(check.Slides[0],new Dictionary<string,string>()));
        using var longDeck=new Presentation("output/template.pptx");Bind(longDeck.Slides[0],new(){{"Customer",string.Join(" ",Enumerable.Repeat("Long customer name",8))}});
        var longShape=Example.Named<IAutoShape>(longDeck.Slides[0],"Customer");
        // Bounded application-side fitting keeps the text measurable before saving.
        longShape.TextFrame.TextFrameFormat.AutofitType=TextAutofitType.None;
        for(float size=24;size>=10;size--)
        {foreach(var paragraph in longShape.TextFrame.Paragraphs)foreach(var portion in paragraph.Portions)portion.PortionFormat.FontHeight=size;
         if(longShape.TextFrame.Paragraphs.Sum(p=>p.GetRect().Height)<=longShape.Height-12)break;}
        bool overflow=longShape.TextFrame.Paragraphs.Sum(p=>p.GetRect().Height)>longShape.Height-12;
        Example.Render(longDeck,"output/long-preview.png");Example.Require(!overflow,"Long text overflows the checked frame height.");
        Example.Require(Example.HashFile("output/template.pptx")==before,"Input changed.");
        Example.Result(new{marker_replaced=true,format_retained=true,missing_required_rejected=missing,long_text_checked=!overflow,input_unchanged=true});
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

    public static string ExpectedText(string value) => Context.IsLicensed || value.Length<=5 ? value : value[..5]+"... text has been truncated due to evaluation version limitation.";

    public static void VerifySavedText(string path,string shapeName,string expected)
    {
        using var zip=System.IO.Compression.ZipFile.OpenRead(path);
        foreach(var entry in zip.Entries.Where(e=>e.FullName.StartsWith("ppt/slides/slide",StringComparison.Ordinal)&&e.FullName.EndsWith(".xml",StringComparison.Ordinal)))
        {
            using var stream=entry.Open();var document=System.Xml.Linq.XDocument.Load(stream);
            foreach(var shape in document.Descendants().Where(e=>e.Name.LocalName=="sp"))
            {
                if(!shape.Descendants().Any(e=>e.Name.LocalName=="cNvPr"&&(string?)e.Attribute("name")==shapeName))continue;
                string stored=string.Concat(shape.Descendants().Where(e=>e.Name.LocalName=="t").Select(e=>e.Value));
                Require(stored==expected,"Saved XML text differs from the intended transformation.");return;
            }
        }
        throw new InvalidDataException("Named saved shape is absent.");
    }

    public static void Require(bool value,string message) { if(!value) throw new InvalidOperationException(message); }

    public static string Hash(byte[] data)=>Convert.ToHexString(SHA256.HashData(data)).ToLowerInvariant();

    public static string HashFile(string path)=>Hash(File.ReadAllBytes(path));

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

    public static byte[] Png(int width,int height,Color color) => PortableImage.Png(width,height,color);

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
            File.WriteAllText(Path.Combine(output, "customer.json"), """
                {
                  "Customer": "Example Northwind Research Ltd",
                  "Optional": ""
                }
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

internal sealed record ExampleContext(string OutputRoot, bool IsLicensed)
{
    public string ExpectedText(string text) => IsLicensed || text.Length <= 5
        ? text
        : text[..5] + "... text has been truncated due to evaluation version limitation.";
}
```

## Expected result and checks

The program writes its semantic checks to `output/result.json` and throws if a required
result differs. Expected check values are:

```json
{
  "marker_replaced": true,
  "format_retained": true,
  "missing_required_rejected": true,
  "long_text_checked": true,
  "input_unchanged": true
}
```

Required values are checked before replacement. Optional values default to empty strings. The long-name case applies a bounded font-size reduction, checks paragraph height and creates a separate preview for visual review. Mixed styles within a replaced marker need their own design decision; this example preserves the surrounding prefix.

## Learn more

- [Manage Presentation Placeholders in .NET](https://docs.aspose.com/slides/net/manage-placeholder/)
- [Search and Replace Text in PowerPoint Presentations in .NET](https://docs.aspose.com/slides/net/search-and-replace-text/)
- [Enhance Your Presentations with AutoFit in .NET](https://docs.aspose.com/slides/net/manage-autofit-settings/)


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
