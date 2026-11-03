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

```csharp
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);

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
