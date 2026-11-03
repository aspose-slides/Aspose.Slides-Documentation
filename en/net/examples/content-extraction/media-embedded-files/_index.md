---
title: Extract Media and Embedded Files
type: docs
weight: 30
url: /net/examples/content-extraction/media-embedded-files/
description: "Extract embedded audio, video and OLE file data, record SHA-256 hashes, and list external media links without opening them."
---

Extract embedded audio, video and OLE file data, record SHA-256 hashes, and list external media links without opening them.

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

    private sealed record Payload(int Slide,string Shape,string Kind,string File,string Sha256);

    private static string Extension(string contentType)=>contentType.ToLowerInvariant() switch
    {"audio/wav" or "audio/x-wav"=>"wav","audio/mpeg"=>"mp3","video/avi" or "video/x-msvideo" or "video/msvideo"=>"avi","video/mp4"=>"mp4",_=>"bin"};

    private static string SafeExtension(string extension)
    {string clean=extension.TrimStart('.');return clean.Length>0&&clean.Length<=12&&clean.All(char.IsLetterOrDigit)?clean.ToLowerInvariant():"bin";}

    private static void ExtractMedia()
    {
        var (audio, video, ole) = CreateInput();
        using var input=new Presentation("output/input.pptx");Directory.CreateDirectory("output/extracted");var rows=new List<Payload>();var links=new List<object>();
        void Save(int slide,IShape shape,string kind,string extension,byte[] data)
        {
            string hash = Example.Hash(data);
            string name = $"{kind}-{hash}.{extension}";
            File.WriteAllBytes(Example.SafeOutput("output/extracted", name), data);
            rows.Add(new(slide, shape.Name, kind, "extracted/" + name, hash));
        }
        for(int i=0;i<input.Slides.Count;i++)foreach(var shape in Example.Walk(input.Slides[i].Shapes))
        {if(shape is IAudioFrame a){if(a.EmbeddedAudio!=null)Save(i+1,shape,"audio",Extension(a.EmbeddedAudio.ContentType),a.EmbeddedAudio.BinaryData);else links.Add(new{slide=i+1,shape=shape.Name,url=a.LinkPathLong});}
         else if(shape is IVideoFrame v){if(v.EmbeddedVideo!=null)Save(i+1,shape,"video",Extension(v.EmbeddedVideo.ContentType),v.EmbeddedVideo.BinaryData);else links.Add(new{slide=i+1,shape=shape.Name,url=v.LinkPathLong});}
         else if(shape is IOleObjectFrame o){if(o.IsObjectLink)links.Add(new{slide=i+1,shape=shape.Name,url=o.LinkPathLong});else Save(i+1,shape,"ole",SafeExtension(o.EmbeddedData.EmbeddedFileExtension),o.EmbeddedData.EmbeddedFileData);}}
        Example.Json("output/manifest.json",new{payloads=rows,external_links=links});
        VerifyExtraction(audio, video, ole, rows, links);
    }

    private static byte[] Wav()
    {using var m=new MemoryStream();using var w=new BinaryWriter(m);w.Write(Encoding.ASCII.GetBytes("RIFF"));w.Write(36+1600);w.Write(Encoding.ASCII.GetBytes("WAVEfmt "));w.Write(16);w.Write((short)1);w.Write((short)1);w.Write(8000);w.Write(16000);w.Write((short)2);w.Write((short)16);w.Write(Encoding.ASCII.GetBytes("data"));w.Write(1600);w.Write(new byte[1600]);return m.ToArray();}

    private static byte[] Chunk(string name,byte[] data)
    {using var m=new MemoryStream();using var w=new BinaryWriter(m);w.Write(Encoding.ASCII.GetBytes(name));w.Write(data.Length);w.Write(data);if(data.Length%2!=0)w.Write((byte)0);return m.ToArray();}

    private static byte[] Bytes(Action<BinaryWriter> fill){using var m=new MemoryStream();using(var w=new BinaryWriter(m,Encoding.UTF8,true))fill(w);return m.ToArray();}

    private static byte[] Avi()
    {
        // One original 8x8 RGB frame in an uncompressed AVI container.
        byte[] frame=Enumerable.Repeat((byte)80,8*8*3).ToArray();
        byte[] avih=Bytes(w=>{w.Write(1000000);w.Write(frame.Length);w.Write(0);w.Write(0x10);w.Write(1);w.Write(0);w.Write(1);w.Write(frame.Length);w.Write(8);w.Write(8);w.Write(new byte[16]);});
        byte[] strh=Bytes(w=>{w.Write(Encoding.ASCII.GetBytes("vidsDIB "));w.Write(0);w.Write((short)0);w.Write((short)0);w.Write(0);w.Write(1);w.Write(1);w.Write(0);w.Write(1);w.Write(frame.Length);w.Write(-1);w.Write(0);w.Write((short)0);w.Write((short)0);w.Write((short)8);w.Write((short)8);});
        byte[] strf=Bytes(w=>{w.Write(40);w.Write(8);w.Write(8);w.Write((short)1);w.Write((short)24);w.Write(0);w.Write(frame.Length);w.Write(new byte[16]);});
        byte[] strl=Chunk("LIST",Encoding.ASCII.GetBytes("strl").Concat(Chunk("strh",strh)).Concat(Chunk("strf",strf)).ToArray());
        byte[] hdrl=Chunk("LIST",Encoding.ASCII.GetBytes("hdrl").Concat(Chunk("avih",avih)).Concat(strl).ToArray());
        byte[] movi=Chunk("LIST",Encoding.ASCII.GetBytes("movi").Concat(Chunk("00db",frame)).ToArray());
        return Chunk("RIFF",Encoding.ASCII.GetBytes("AVI ").Concat(hdrl).Concat(movi).ToArray());
    }

    private static (byte[] Audio, byte[] Video, byte[] Ole) CreateInput()
    {
        Example.Setup();byte[] audio=Wav(),video=Avi(),ole=Encoding.UTF8.GetBytes("Original embedded note – no executable content.\n");
        using(var p=new Presentation())
        {using var stream=new MemoryStream(audio);p.Slides[0].Shapes.AddAudioFrameEmbedded(20,20,60,60,stream).Name="../audio";
         p.Slides[0].Shapes.AddVideoFrame(100,20,100,80,p.Videos.AddVideo(video)).Name="Video";
         p.Slides[0].Shapes.AddOleObjectFrame(220,20,80,80,new OleEmbeddedDataInfo(ole,"txt")).Name="../note";
         p.Slides[0].Shapes.AddVideoFrame(320,20,100,80,"https://example.invalid/unfetched.mp4").Name="Linked video";
         p.Slides[0].Shapes.AddAudioFrameLinked(430,20,60,60,"https://example.invalid/unfetched.wav").Name="Linked audio";
         p.Save("output/input.pptx",SaveFormat.Pptx);}
        return (audio, video, ole);
    }

    private static ExampleContext Context = null!;

    private static Task<int> RunChecked() => ExampleBootstrap.RunAsync(async ctx =>
    {
        Context = ctx;
        Example.Context = ctx;
        ExtractMedia();
        await Task.CompletedTask;
    });

    private static void VerifyExtraction(byte[] audio, byte[] video, byte[] ole, List<Payload> rows, List<object> links)
    {
        Example.Require(rows.Count==3&&links.Count==2,"Unexpected embedded/external resource counts.");
        Example.Require(rows.Select(x=>x.Sha256).ToHashSet().SetEquals(new[]{Example.Hash(audio),Example.Hash(video),Example.Hash(ole)}),"Payload bytes changed.");
        bool escaped=Example.Throws(()=>Example.SafeOutput("output/extracted","../escape.txt"));Example.Require(escaped,"Unsafe path accepted.");
        foreach(var row in rows)Example.Require(Example.HashFile("output/"+row.File)==row.Sha256,"Extracted bytes differ.");
        Example.Result(new{embedded_payloads=3,external_links=2,payload_hashes_checked=true,path_escape_rejected=escaped,no_external_fetch=true,no_payload_execution=true});
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

    public static string SafeOutput(string folder,string filename)
    {
        string root=Path.GetFullPath(folder)+Path.DirectorySeparatorChar;
        string path=Path.GetFullPath(Path.Combine(folder,filename));
        if(!path.StartsWith(root,StringComparison.OrdinalIgnoreCase))throw new InvalidDataException("Output escapes its directory.");return path;
    }

    public static bool Throws(Action action)
    {try{action();return false;}catch(InvalidDataException){return true;}}
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
  "embedded_payloads": 3,
  "external_links": 2,
  "payload_hashes_checked": true,
  "path_escape_rejected": true,
  "no_external_fetch": true,
  "no_payload_execution": true
}
```

The sample creates original synthetic WAV, uncompressed AVI and text payloads. It uses generated content-based filenames inside a checked output directory. It never executes extracted files or downloads external links. Shape names are metadata only, even when they contain path separators. Codec playback is outside this extraction example.

## Learn more

- [Manage Audio Frames in Presentations in .NET](https://docs.aspose.com/slides/net/audio-frame/)
- [Manage Video Frames in Presentations in .NET](https://docs.aspose.com/slides/net/video-frame/)
- [Manage OLE Objects in Presentations in .NET](https://docs.aspose.com/slides/net/manage-ole/)


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
