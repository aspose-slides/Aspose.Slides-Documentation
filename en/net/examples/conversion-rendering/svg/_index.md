---
title: "Export Slides to SVG"
type: docs
weight: 70
url: /net/examples/conversion-rendering/svg/
description: "Runnable C# example for export slides to svg using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

Write one slide to a scalable SVG. Text appearance still depends on the output representation and fonts; SVG does not imply that each PowerPoint object becomes an editable browser element. Inspect the SVG in a browser and check any resource references before embedding it elsewhere.

## Run the example

[Download the complete project](example.zip). It includes the solution, source, SDK settings, package configuration and required fixtures. The code creates its own four-slide input with a hidden slide, speaker notes, a table, chart and picture.

This download uses Aspose.Slides.NET6.CrossPlatform 26.10.0, bundled Noto Sans fonts and original portable PNG fixtures. Open the supplied solution with a compatible stable SDK; the current .NET 10 LTS is recommended. Evaluation runs without a license; unrestricted assertions use your authorized license. See [setup and prerequisites](/slides/net/examples/getting-started/) for native dependencies and tool selection.

```text
dotnet run --project Example.csproj --configuration Release
```

## Complete C# example

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

```csharp
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;
using Aspose.Slides;

internal static class Program
{
    private static Task<int> Main() => RunChecked();

    private static void ExportSvg(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        using (var stream = File.Create("slide.svg"))
        {
            source.Slides[0].WriteAsSvg(stream);
        }
        Report(new { svg_created = File.Exists("slide.svg"), source_slide = 1 });
    }

    private static Presentation CreateSource(bool licensed)
    {
        var deck = new Presentation();
        deck.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
        var layout = deck.LayoutSlides.GetByType(SlideLayoutType.Blank);
        string[] labels = licensed ? new[] { "Alpha", "Bravo", "Charlie", "Hidden" } : new[] { "Alpha", "Bravo", "C", "Hide" };
        for (int i = 0; i < labels.Length; i++)
        {
            var slide = i == 0 ? deck.Slides[0] : deck.Slides.AddEmptySlide(layout);
            var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 580, 55);
            shape.Name = "RecipeTitle";
            shape.TextFrame.Text = labels[i];
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Noto Sans");
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 26;
            slide.NotesSlideManager.AddNotesSlide().NotesTextFrame.Text = licensed ? "Speaker note " + labels[i] : labels[i];
            slide.Hidden = i == 3;
        }
        var table = deck.Slides[0].Shapes.AddTable(30, 100, new double[] { 140, 100 }, new double[] { 35, 35 });
        table[0, 0].TextFrame.Text = "Product";
        table[1, 0].TextFrame.Text = "Units";
        table[0, 1].TextFrame.Text = "Pens";
        table[1, 1].TextFrame.Text = "12";
        deck.Slides[1].Shapes.AddChart(ChartType.ClusteredColumn, 30, 100, 400, 220);
        var image = deck.Images.AddImage(PortableImage.Png(100,60,Color.CornflowerBlue));
        deck.Slides[2].Shapes.AddPictureFrame(ShapeType.Rectangle,50,120,200,120,image);
        deck.Slides[0].Timeline.MainSequence.AddEffect(deck.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name == "RecipeTitle"), EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
        deck.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
        return deck;
    }

    private static Task<int> RunChecked() => ExampleBootstrap.RunAsync(ctx =>
    {
        ExportSvg(ctx.IsLicensed);
        return Task.CompletedTask;
    });

    private static void Report(object values)
    {
        string json = JsonSerializer.Serialize(values, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json);
        Console.WriteLine(json);
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

## Expected result

The program writes "slide.svg" in the printed output directory, plus the synthetic source.pptx and a result.json summary. Inspect the rendered/exported files with the viewer appropriate to the format. Input generation is visible in CreateSource; replace it with opening your own presentation when adapting the example.

Continue with the [detailed guide](/slides/net/render-a-slide-as-an-svg-image/).


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
