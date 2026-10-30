---
title: Extract Media and Embedded Files
type: docs
weight: 30
url: /net/examples/content-extraction/media-embedded-files/
description: "Extract embedded audio, video and OLE file data, record SHA-256 hashes, and list external media links without opening them."
---

Extract embedded audio, video and OLE file data, record SHA-256 hashes, and list external media links without opening them.

## Run the example

Download the [complete project](sample.zip), extract it, and run it with the .NET 8 SDK.
The project pins Aspose.Slides.NET 26.10.0. The example was tested on Windows x64.
For the complete data assertions, set `ASPOSE_LICENSE_PATH` to your own valid license;
the visible helper loads it when supplied. Evaluation mode may truncate text or add watermarks.

```text
dotnet restore Example.csproj --locked-mode
dotnet run --project Example.csproj --configuration Release --no-restore
```

The download contains [Program.cs](Program.cs), [Example.cs](Example.cs), the project,
dependency lock, and any JSON/CSV input. The helper source contains fixture generation,
license loading, serialization and assertions; it is part of the runnable project.
All presentation inputs are generated from original synthetic data. Results go to `output/`.

## Example

```csharp
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

    private sealed record Payload(int Slide,string Shape,string Kind,string File,string Sha256);
    private static string Extension(string contentType)=>contentType.ToLowerInvariant() switch
    {"audio/wav" or "audio/x-wav"=>"wav","audio/mpeg"=>"mp3","video/avi" or "video/x-msvideo" or "video/msvideo"=>"avi","video/mp4"=>"mp4",_=>"bin"};
    private static string SafeExtension(string extension)
    {string clean=extension.TrimStart('.');return clean.Length>0&&clean.Length<=12&&clean.All(char.IsLetterOrDigit)?clean.ToLowerInvariant():"bin";}
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
    private static void Main()
    {
        Example.Setup();byte[] audio=Wav(),video=Avi(),ole=Encoding.UTF8.GetBytes("Original embedded note – no executable content.\n");
        using(var p=new Presentation())
        {using var stream=new MemoryStream(audio);p.Slides[0].Shapes.AddAudioFrameEmbedded(20,20,60,60,stream).Name="../audio";
         p.Slides[0].Shapes.AddVideoFrame(100,20,100,80,p.Videos.AddVideo(video)).Name="Video";
         p.Slides[0].Shapes.AddOleObjectFrame(220,20,80,80,new OleEmbeddedDataInfo(ole,"txt")).Name="../note";
         p.Slides[0].Shapes.AddVideoFrame(320,20,100,80,"https://example.invalid/unfetched.mp4").Name="Linked video";
         p.Slides[0].Shapes.AddAudioFrameLinked(430,20,60,60,"https://example.invalid/unfetched.wav").Name="Linked audio";
         p.Save("output/input.pptx",SaveFormat.Pptx);}
        using var input=new Presentation("output/input.pptx");Directory.CreateDirectory("output/extracted");var rows=new List<Payload>();var links=new List<object>();
        void Save(int slide,IShape shape,string kind,string extension,byte[] data)
        {string name=kind+"-"+Example.Hash(data)+"."+extension;File.WriteAllBytes(Example.SafeOutput("output/extracted",name),data);rows.Add(new(slide,shape.Name,kind,"extracted/"+name,Example.Hash(data)));}
        for(int i=0;i<input.Slides.Count;i++)foreach(var shape in Example.Walk(input.Slides[i].Shapes))
        {if(shape is IAudioFrame a){if(a.EmbeddedAudio!=null)Save(i+1,shape,"audio",Extension(a.EmbeddedAudio.ContentType),a.EmbeddedAudio.BinaryData);else links.Add(new{slide=i+1,shape=shape.Name,url=a.LinkPathLong});}
         else if(shape is IVideoFrame v){if(v.EmbeddedVideo!=null)Save(i+1,shape,"video",Extension(v.EmbeddedVideo.ContentType),v.EmbeddedVideo.BinaryData);else links.Add(new{slide=i+1,shape=shape.Name,url=v.LinkPathLong});}
         else if(shape is IOleObjectFrame o){if(o.IsObjectLink)links.Add(new{slide=i+1,shape=shape.Name,url=o.LinkPathLong});else Save(i+1,shape,"ole",SafeExtension(o.EmbeddedData.EmbeddedFileExtension),o.EmbeddedData.EmbeddedFileData);}}
        Example.Json("output/manifest.json",new{payloads=rows,external_links=links});
        Example.Require(rows.Count==3&&links.Count==2,"Unexpected embedded/external resource counts.");
        Example.Require(rows.Select(x=>x.Sha256).ToHashSet().SetEquals(new[]{Example.Hash(audio),Example.Hash(video),Example.Hash(ole)}),"Payload bytes changed.");
        bool escaped=Example.Throws(()=>Example.SafeOutput("output/extracted","../escape.txt"));Example.Require(escaped,"Unsafe path accepted.");
        foreach(var row in rows)Example.Require(Example.HashFile("output/"+row.File)==row.Sha256,"Extracted bytes differ.");
        Example.Result(new{embedded_payloads=3,external_links=2,payload_hashes_checked=true,path_escape_rejected=escaped,no_external_fetch=true,no_payload_execution=true});
    }

}
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
