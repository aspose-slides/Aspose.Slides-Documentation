---
title: Extract Presentation Images
type: docs
weight: 20
url: /net/examples/content-extraction/images/
description: "Extract original embedded picture bytes once per content hash, with references back to the slides and shapes using them."
---

Extract original embedded picture bytes once per content hash, with references back to the slides and shapes using them.

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
    private static Task<int> Main() => RunChecked();

    private sealed record ImageRef(int Slide,string Shape,string File,string Sha256);

    private static void ExtractImages()
    {
        var (blue, orange) = CreateInput();
        using var input=new Presentation("output/input.pptx");Directory.CreateDirectory("output/images");var seen=new HashSet<string>();var refs=new List<ImageRef>();var links=new List<object>();
        for(int i=0;i<input.Slides.Count;i++)foreach(var shape in Example.Walk(input.Slides[i].Shapes).OfType<IPictureFrame>())
        {
            var picture=shape.PictureFormat.Picture;if(!string.IsNullOrWhiteSpace(picture.LinkPathLong)){links.Add(new{slide=i+1,shape=shape.Name,url=picture.LinkPathLong});continue;}
            byte[] data=picture.Image.BinaryData;string hash=Example.Hash(data),name=hash+".png";if(seen.Add(hash))File.WriteAllBytes(Example.SafeOutput("output/images",name),data);refs.Add(new ImageRef(i+1,shape.Name,"images/"+name,hash));
        }
        Example.Json("output/images.json",new{images=refs,external_links=links});
        VerifyExtraction(blue, orange, seen, refs, links);
    }

    private static (byte[] Blue, byte[] Orange) CreateInput()
    {
        Example.Setup();byte[] blue=Example.Png(120,80,Color.Blue),orange=Example.Png(80,120,Color.Orange);
        using(var p=new Presentation())
        {var shared=p.Images.AddImage(blue);p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,20,20,120,80,shared).Name="First";p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,160,20,120,80,shared).Name="Duplicate";var other=p.Slides.AddEmptySlide(p.LayoutSlides[0]);other.Shapes.AddPictureFrame(ShapeType.Rectangle,20,20,80,120,p.Images.AddImage(orange)).Name="Second image";
         var linked=other.Shapes.AddPictureFrame(ShapeType.Rectangle,150,20,80,80,shared);linked.Name="External";linked.PictureFormat.Picture.LinkPathLong="https://example.invalid/unfetched.png";p.Save("output/input.pptx",SaveFormat.Pptx);}
        return (blue, orange);
    }

    private static ExampleContext Context = null!;

    private static Task<int> RunChecked() => ExampleBootstrap.RunAsync(async ctx =>
    {
        Context = ctx;
        Example.Context = ctx;
        ExtractImages();
        await Task.CompletedTask;
    });

    private static void VerifyExtraction(byte[] blue, byte[] orange, HashSet<string> seen, List<ImageRef> refs, List<object> links)
    {
        Example.Require(seen.SetEquals(new[]{Example.Hash(blue),Example.Hash(orange)}),"Original image bytes differ.");
        Example.Require(refs.Count==3&&seen.Count==2&&links.Count==1,"Deduplication or linked-resource policy differs.");
        foreach(var image in refs)Example.Require(Example.HashFile("output/"+image.File)==image.Sha256,"Saved image hash differs.");
        Example.Result(new{image_references=3,unique_images=2,external_links_reported=1,original_bytes_checked=true,no_network_fetch=true});
    }
}

internal static class Example
{
    public static ExampleContext Context = null!;

    public static void Setup() { Directory.CreateDirectory("output"); }

    public static void Require(bool value,string message) { if(!value) throw new InvalidOperationException(message); }

    public static string Hash(byte[] data)=>Convert.ToHexString(SHA256.HashData(data)).ToLowerInvariant();

    public static string HashFile(string path)=>Hash(File.ReadAllBytes(path));

    public static void Result(object checks)
    { File.WriteAllText("output/result.json",JsonSerializer.Serialize(new {checks},new JsonSerializerOptions{WriteIndented=true}),new UTF8Encoding(false)); }

    public static void Json(string path,object value)
    { File.WriteAllText(path,JsonSerializer.Serialize(value,new JsonSerializerOptions{WriteIndented=true}),new UTF8Encoding(false)); }

    public static IEnumerable<IShape> Walk(IShapeCollection shapes)
    { foreach(IShape shape in shapes){yield return shape;if(shape is IGroupShape group)foreach(var child in Walk(group.Shapes))yield return child;} }

    public static byte[] Png(int width,int height,Color color) => PortableImage.Png(width,height,color);

    public static string SafeOutput(string folder,string filename)
    {
        string root=Path.GetFullPath(folder)+Path.DirectorySeparatorChar;
        string path=Path.GetFullPath(Path.Combine(folder,filename));
        if(!path.StartsWith(root,StringComparison.OrdinalIgnoreCase))throw new InvalidDataException("Output escapes its directory.");return path;
    }
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
  "image_references": 3,
  "unique_images": 2,
  "external_links_reported": 1,
  "original_bytes_checked": true,
  "no_network_fetch": true
}
```

The sample deduplicates bytes rather than filenames. External picture links are reported and are never fetched. This extracts picture-frame resources; rendering a slide is a different operation, and other image uses such as background fills require extending the traversal.

## Learn more

- [Extract Images from Presentation Shapes in .NET](https://docs.aspose.com/slides/net/extracting-images-from-presentation-shapes/)
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
