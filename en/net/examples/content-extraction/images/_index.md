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
}
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
