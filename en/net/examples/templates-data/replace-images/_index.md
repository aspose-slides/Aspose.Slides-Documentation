---
title: Replace Template Images
type: docs
weight: 20
url: /net/examples/templates-data/replace-images/
description: "Replace two named pictures using contain and crop choices while retaining the original picture frames. Both portrait and landscape replacements are tested."
---

Replace two named pictures using contain and crop choices while retaining the original picture frames. Both portrait and landscape replacements are tested.

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
    private static void RunExample()
    {
        Example.Setup();byte[] portrait=Example.Png(100,240,Color.DarkOrange),landscape=Example.Png(260,100,Color.Teal);
        File.WriteAllBytes("output/portrait.png",portrait);File.WriteAllBytes("output/landscape.png",landscape);
        using(var p=new Presentation())
        {
            var image=p.Images.AddImage(Example.Png(100,100,Color.SlateGray));
            p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,40,80,250,200,image).Name="Contain";
            p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,350,80,250,200,image).Name="Crop";
            p.Save("output/template.pptx",SaveFormat.Pptx);
        }
        bool preserved=true;
        foreach(var fixture in new[] { (Name: "portrait", Bytes: portrait), (Name: "landscape", Bytes: landscape) })
        {
            using var p=new Presentation("output/template.pptx");
            foreach(string name in new[]{"Contain","Crop"})
            {var frame=Example.Named<IPictureFrame>(p.Slides[0],name);var position=(frame.X,frame.Y,frame.Width,frame.Height);
             frame.PictureFormat.Picture.Image=p.Images.AddImage(PortableImage.Fit(fixture.Bytes, 500, 400, crop: name == "Crop"));
             preserved&=position==(frame.X,frame.Y,frame.Width,frame.Height);}
            p.Save("output/"+fixture.Name+".pptx",SaveFormat.Pptx);Example.Render(p,"output/"+fixture.Name+"-preview.png");
            using var reopened=new Presentation("output/"+fixture.Name+".pptx");
            Example.Require(Example.Named<IPictureFrame>(reopened.Slides[0],"Contain").Width==250,"Frame size changed.");
        }
        Example.Require(preserved,"Frame geometry changed.");Example.Result(new{frame_geometry_preserved=true,portrait_and_landscape_checked=true});
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

    public static byte[] Fit(byte[] data,int width,int height,bool crop)
    {
        var input=Decode(data);byte[] pixels=new byte[checked(width*height*4)];Array.Fill(pixels,(byte)255);
        double scale=crop?Math.Max((double)width/input.Width,(double)height/input.Height):Math.Min((double)width/input.Width,(double)height/input.Height);
        double left=(width-input.Width*scale)/2,top=(height-input.Height*scale)/2;
        for(int y=0;y<height;y++)for(int x=0;x<width;x++)
        {int sx=(int)Math.Floor((x-left)/scale),sy=(int)Math.Floor((y-top)/scale);if(sx>=0&&sy>=0&&sx<input.Width&&sy<input.Height)Array.Copy(input.Rgba,(sy*input.Width+sx)*4,pixels,(y*width+x)*4,4);}
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

    public static Pixels Decode(byte[] png)
    {
        if(png.Length<33||!png.AsSpan(0,8).SequenceEqual(new byte[]{137,80,78,71,13,10,26,10}))throw new InvalidDataException("Invalid PNG fixture.");
        int width=BinaryPrimitives.ReadInt32BigEndian(png.AsSpan(16,4)),height=BinaryPrimitives.ReadInt32BigEndian(png.AsSpan(20,4));int type=png[25];
        if(png[24]!=8||png[28]!=0)throw new InvalidDataException("This fixture helper requires noninterlaced 8-bit PNG.");
        int channels=type switch{0=>1,2=>3,3=>1,4=>2,6=>4,_=>throw new InvalidDataException("Unsupported PNG color type.")};
        using var idat=new MemoryStream();byte[] palette=Array.Empty<byte>(),alpha=Array.Empty<byte>();
        for(int p=8;p+12<=png.Length;){int n=BinaryPrimitives.ReadInt32BigEndian(png.AsSpan(p,4));string name=Encoding.ASCII.GetString(png,p+4,4);if(n<0||p+12L+n>png.Length)throw new InvalidDataException("Invalid PNG chunk.");if(name=="IDAT")idat.Write(png,p+8,n);if(name=="PLTE")palette=png.AsSpan(p+8,n).ToArray();if(name=="tRNS")alpha=png.AsSpan(p+8,n).ToArray();p+=12+n;}
        idat.Position=0;using var z=new ZLibStream(idat,CompressionMode.Decompress);int stride=checked(width*channels);byte[] previous=new byte[stride],row=new byte[stride],pixels=new byte[checked(width*height*4)];
        for(int y=0;y<height;y++)
        {
            int filter=z.ReadByte();z.ReadExactly(row);for(int i=0;i<stride;i++){int a=i>=channels?row[i-channels]:0,b=previous[i],c=i>=channels?previous[i-channels]:0;row[i]=unchecked((byte)(row[i]+(filter switch{0=>0,1=>a,2=>b,3=>(a+b)/2,4=>Paeth(a,b,c),_=>throw new InvalidDataException("Invalid PNG filter.")})));}
            for(int x=0;x<width;x++){int s=x*channels,d=(y*width+x)*4;if(type==3){int k=row[s];pixels[d]=palette[k*3];pixels[d+1]=palette[k*3+1];pixels[d+2]=palette[k*3+2];pixels[d+3]=k<alpha.Length?alpha[k]:(byte)255;}else{pixels[d]=row[s];pixels[d+1]=type is 0 or 4?row[s]:row[s+1];pixels[d+2]=type is 0 or 4?row[s]:row[s+2];pixels[d+3]=type==6?row[s+3]:type==4?row[s+1]:(byte)255;}}
            (previous,row)=(row,previous);
        }
        return new Pixels(width,height,pixels);
    }

    private static int Paeth(int a,int b,int c){int p=a+b-c,pa=Math.Abs(p-a),pb=Math.Abs(p-b),pc=Math.Abs(p-c);return pa<=pb&&pa<=pc?a:pb<=pc?b:c;}
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
  "frame_geometry_preserved": true,
  "portrait_and_landscape_checked": true
}
```

Contain/crop preprocessing uses the included portable PNG helper on original synthetic pixel data. It creates a raster image matching the existing frame aspect ratio; the Aspose operation replaces Picture.Image without changing the frame. The helper handles the 8-bit PNG fixtures supplied by this project without a Windows bitmap dependency.

## Learn more

- [Manage Picture Frames in Presentations in .NET](https://docs.aspose.com/slides/net/picture-frame/)
- [Optimize Image Management in Presentations in .NET](https://docs.aspose.com/slides/net/image/)


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
