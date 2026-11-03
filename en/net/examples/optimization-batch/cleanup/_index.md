---
title: Remove Unused Presentation Resources
type: docs
weight: 20
url: /net/examples/optimization-batch/cleanup/
description: "Remove unused layouts and masters, then remove a nominated unreferenced image part while preserving the retained slide content."
---

Remove unused layouts and masters, then remove a nominated unreferenced image part while preserving the retained slide content.

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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;
using Aspose.Slides.Warnings;
using Aspose.Slides;
using Microsoft.VisualBasic.FileIO;

internal static class Program
{
    private static Task<int> Main() => RunChecked();

    private static void CleanPresentation()
    {
        Example.Setup();using(var p=new Presentation())using(var unusedMasterSource=new Presentation())
        {Example.Text(p.Slides[0].Shapes,"Content",Example.Choice("Keep referenced content","Keep"));p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,50,150,150,100,p.Images.AddImage(Example.Png(150,100,Color.Teal))).Name="Required image";
         p.Masters.AddClone(unusedMasterSource.Masters[0]);p.Save("output/input.pptx",SaveFormat.Pptx);Example.Render(p,"output/before.png");}
        // Add an explicitly unreferenced package part to the synthetic fixture.
        using(var zip=ZipFile.Open("output/input.pptx",ZipArchiveMode.Update)){var entry=zip.CreateEntry("ppt/media/orphan.png");using var stream=entry.Open();stream.Write(Example.Png(30,30,Color.Orange));}
        int mastersBefore,layoutsBefore;
        using(var p=new Presentation("output/input.pptx"))
        {mastersBefore=p.Masters.Count;layoutsBefore=p.LayoutSlides.Count;Example.Render(p,"output/before.png");Compress.RemoveUnusedLayoutSlides(p);Compress.RemoveUnusedMasterSlides(p);
         p.Save("output/cleaned.pptx",SaveFormat.Pptx);Example.Render(p,"output/after.png");}
        RemoveKnownUnreferencedImage("output/cleaned.pptx","ppt/media/orphan.png");
        using var result=new Presentation("output/cleaned.pptx");
        Example.Require(result.Masters.Count<mastersBefore&&result.LayoutSlides.Count<layoutsBefore,"Unused structures were not removed.");
        Example.Require(Example.Named<IAutoShape>(result.Slides[0],"Content").TextFrame.Text==Example.Choice("Keep referenced content","Keep"),"Referenced text changed.");
        Example.Require(Example.Named<IPictureFrame>(result.Slides[0],"Required image").PictureFormat.Picture.Image.BinaryData.Length>0,"Referenced media removed.");
        Example.Require(MediaParts("output/input.pptx")==2&&MediaParts("output/cleaned.pptx")==1,"The nominated unreferenced media part was not removed.");
        string referencedPart;using(var zip=ZipFile.OpenRead("output/cleaned.pptx"))referencedPart=zip.Entries.Single(e=>e.FullName.StartsWith("ppt/media/",StringComparison.Ordinal)).FullName;
        bool protectedImage=Example.Throws(()=>RemoveKnownUnreferencedImage("output/cleaned.pptx",referencedPart));Example.Require(protectedImage,"Referenced image was not protected.");
        Example.Require(Example.HashFile("output/before.png")==Example.HashFile("output/after.png"),"Rendered content changed.");
        Example.Json("output/counts.json",new{masters_before=mastersBefore,masters_after=result.Masters.Count,layouts_before=layoutsBefore,layouts_after=result.LayoutSlides.Count,media_before=2,media_after=1});
        Example.Result(new{unused_structures_removed=true,referenced_content_preserved=true,nominated_unreferenced_image_removed=true,referenced_image_deletion_rejected=protectedImage,render_identical=true});
    }

    private static ExampleContext Context = null!;

    private static Task<int> RunChecked() => ExampleBootstrap.RunAsync(async ctx =>
    {
        Context = ctx;
        Example.Context = ctx;
        CleanPresentation();
        await Task.CompletedTask;
    });

    private static int MediaParts(string path)
    {using var zip=ZipFile.OpenRead(path);return zip.Entries.Count(e=>e.FullName.StartsWith("ppt/media/",StringComparison.Ordinal));}

    private static void RemoveKnownUnreferencedImage(string package,string part)
    {
        if(!part.StartsWith("ppt/media/",StringComparison.Ordinal)||!part.EndsWith(".png",StringComparison.Ordinal))throw new InvalidDataException("Only a nominated PNG media part is supported.");
        using var zip=ZipFile.Open(package,ZipArchiveMode.Update);
        foreach(var relationPart in zip.Entries.Where(e=>e.FullName.EndsWith(".rels",StringComparison.Ordinal)).ToArray())
        {
            string name=relationPart.FullName;int split=name.LastIndexOf("/_rels/",StringComparison.Ordinal);
            string owner=name=="_rels/.rels"?"":name[..split]+"/"+name[(split+7)..^5];
            using var stream=relationPart.Open();var xml=System.Xml.Linq.XDocument.Load(stream);
            foreach(var relationship in xml.Root!.Elements())
            {
                if((string?)relationship.Attribute("TargetMode")=="External")continue;
                string? target=(string?)relationship.Attribute("Target");if(target==null)continue;
                var absolute=new Uri(new Uri("https://package.invalid/"+owner),target);
                if(absolute.Host=="package.invalid"&&Uri.UnescapeDataString(absolute.AbsolutePath.TrimStart('/'))==part)throw new InvalidDataException("Refusing to remove referenced image part.");
            }
        }
        var entry=zip.GetEntry(part);if(entry==null)throw new InvalidDataException("Nominated image part is absent.");entry.Delete();
    }
}

internal static class Example
{
    public static ExampleContext Context = null!;

    public static void Setup() { Directory.CreateDirectory("output"); }

    public static string Choice(string licensed,string evaluation) => Context.IsLicensed ? licensed : evaluation;

    public static void Require(bool value,string message) { if(!value) throw new InvalidOperationException(message); }

    public static string Hash(byte[] data)=>System.Convert.ToHexString(SHA256.HashData(data)).ToLowerInvariant();

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
  "unused_structures_removed": true,
  "referenced_content_preserved": true,
  "nominated_unreferenced_image_removed": true,
  "referenced_image_deletion_rejected": true,
  "render_identical": true
}
```

The sample removes unused layouts before unused masters using Aspose.Slides. Media cleanup is explicit application-side OOXML code: it scans package relationships and removes only a nominated PNG part that has no relationship reference. A negative check refuses deletion of the referenced picture. It does not discover every kind of unused media and does not claim that Aspose resaving removes orphan parts automatically. Keep the original if unused designs may be needed later.

## Learn more

- [Manage Presentation Slide Masters in .NET](https://docs.aspose.com/slides/net/slide-master/)
- [Apply or Change Slide Layouts in .NET](https://docs.aspose.com/slides/net/slide-layout/)
- [Save Presentations in .NET](https://docs.aspose.com/slides/net/save-presentation/)


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
