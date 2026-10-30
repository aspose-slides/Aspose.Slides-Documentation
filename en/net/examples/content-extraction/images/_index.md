---
title: Extract Presentation Images
type: docs
weight: 20
url: /net/examples/content-extraction/images/
description: "Extract original embedded picture bytes once per content hash, with references back to the slides and shapes using them."
---

Extract original embedded picture bytes once per content hash, with references back to the slides and shapes using them.

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

    private sealed record ImageRef(int Slide,string Shape,string File,string Sha256);
    private static void Main()
    {
        Example.Setup();byte[] blue=Example.Png(120,80,Color.Blue),orange=Example.Png(80,120,Color.Orange);
        using(var p=new Presentation())
        {var shared=p.Images.AddImage(blue);p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,20,20,120,80,shared).Name="First";p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,160,20,120,80,shared).Name="Duplicate";var other=p.Slides.AddEmptySlide(p.LayoutSlides[0]);other.Shapes.AddPictureFrame(ShapeType.Rectangle,20,20,80,120,p.Images.AddImage(orange)).Name="Second image";
         var linked=other.Shapes.AddPictureFrame(ShapeType.Rectangle,150,20,80,80,shared);linked.Name="External";linked.PictureFormat.Picture.LinkPathLong="https://example.invalid/unfetched.png";p.Save("output/input.pptx",SaveFormat.Pptx);}
        using var input=new Presentation("output/input.pptx");Directory.CreateDirectory("output/images");var seen=new HashSet<string>();var refs=new List<ImageRef>();var links=new List<object>();
        for(int i=0;i<input.Slides.Count;i++)foreach(var shape in Example.Walk(input.Slides[i].Shapes).OfType<IPictureFrame>())
        {
            var picture=shape.PictureFormat.Picture;if(!string.IsNullOrWhiteSpace(picture.LinkPathLong)){links.Add(new{slide=i+1,shape=shape.Name,url=picture.LinkPathLong});continue;}
            byte[] data=picture.Image.BinaryData;string hash=Example.Hash(data),name=hash+".png";if(seen.Add(hash))File.WriteAllBytes(Example.SafeOutput("output/images",name),data);refs.Add(new ImageRef(i+1,shape.Name,"images/"+name,hash));
        }
        Example.Json("output/images.json",new{images=refs,external_links=links});
        Example.Require(seen.SetEquals(new[]{Example.Hash(blue),Example.Hash(orange)}),"Original image bytes differ.");
        Example.Require(refs.Count==3&&seen.Count==2&&links.Count==1,"Deduplication or linked-resource policy differs.");
        foreach(var image in refs)Example.Require(Example.HashFile("output/"+image.File)==image.Sha256,"Saved image hash differs.");
        Example.Result(new{image_references=3,unique_images=2,external_links_reported=1,original_bytes_checked=true,no_network_fetch=true});
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
