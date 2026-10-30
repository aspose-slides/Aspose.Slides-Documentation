---
title: Reduce Presentation Size
type: docs
weight: 10
url: /net/examples/optimization-batch/compression/
description: "Compress an intentionally oversized picture at 96 DPI, save a new presentation and compare file size and representative renders."
---

Compress an intentionally oversized picture at 96 DPI, save a new presentation and compare file size and representative renders.

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
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
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
using Aspose.Slides.LowCode;
using Aspose.Slides.Warnings;

[SupportedOSPlatform("windows")]
internal static class Program
{

    private static double MeanDifference(string first,string second)
    {
        using var a=new Bitmap(first);using var b=new Bitmap(second);double total=0;
        Example.Require(a.Size==b.Size,"Render dimensions differ.");
        for(int y=0;y<a.Height;y+=3)for(int x=0;x<a.Width;x+=3){var c=a.GetPixel(x,y);var d=b.GetPixel(x,y);total+=Math.Abs(c.R-d.R)+Math.Abs(c.G-d.G)+Math.Abs(c.B-d.B);}
        return total/(Math.Ceiling(a.Width/3.0)*Math.Ceiling(a.Height/3.0)*3);
    }
    private static void Main()
    {
        Example.Setup();using(var p=new Presentation())
        {Example.Text(p.Slides[0].Shapes,"Title","Reduce an oversized raster image",30,20,620,60);
         p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,80,110,500,300,p.Images.AddImage(Example.Png(4000,2400,Color.Teal))).Name="Oversized image";
         p.Save("output/input.pptx",SaveFormat.Pptx);Example.Render(p,"output/before.png");}
        long before=new FileInfo("output/input.pptx").Length;
        bool compressed;
        using(var p=new Presentation("output/input.pptx"))
        {var frame=Example.Named<IPictureFrame>(p.Slides[0],"Oversized image");compressed=frame.PictureFormat.CompressImage(true,PicturesCompression.Dpi96);p.Save("output/compressed.pptx",SaveFormat.Pptx);Example.Render(p,"output/after.png");}
        long after=new FileInfo("output/compressed.pptx").Length;
        using var reopened=new Presentation("output/compressed.pptx");var picture=Example.Named<IPictureFrame>(reopened.Slides[0],"Oversized image");
        double difference=MeanDifference("output/before.png","output/after.png");
        Example.Require(compressed&&after<before,"The deliberately oversized fixture did not shrink.");
        Example.Require(picture.Width==500&&picture.Height==300&&reopened.Slides.Count==1,"Frame or slides changed.");
        Example.Require(difference<3,"Representative render changed too much.");
        Example.Json("output/measurements.json",new{before_bytes=before,after_bytes=after,mean_rgb_difference=difference,resolution="96 DPI"});
        Example.Result(new{fixture_shrank=true,geometry_preserved=true,render_difference_within_limit=true,reopened=true});
    }

}
```

## Expected result and checks

The program writes its semantic checks to `output/result.json` and throws if a required
result differs. Expected check values are:

```json
{
  "fixture_shrank": true,
  "geometry_preserved": true,
  "render_difference_within_limit": true,
  "reopened": true
}
```

Compression is a quality choice: this fixture is deliberately much larger than its display frame. The result must shrink while its measured mean RGB render difference remains small. Real files may shrink less or not at all. Keep the original when quality requirements may change; the sample reports actual byte counts rather than a universal savings claim.

## Learn more

- [Optimize Image Management in Presentations in .NET](https://docs.aspose.com/slides/net/image/)
- [Save Presentations in .NET](https://docs.aspose.com/slides/net/save-presentation/)
