---
title: Replace Template Images
type: docs
weight: 20
url: /net/examples/templates-data/replace-images/
description: "Replace two named pictures using contain and crop choices while retaining the original picture frames. Both portrait and landscape replacements are tested."
---

Replace two named pictures using contain and crop choices while retaining the original picture frames. Both portrait and landscape replacements are tested.

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

    private static byte[] Fit(byte[] bytes,int width,int height,bool crop)
    {
        using var sourceStream=new MemoryStream(bytes);using var source=System.Drawing.Image.FromStream(sourceStream);
        using var canvas=new Bitmap(width,height);using var g=Graphics.FromImage(canvas);g.Clear(Color.White);
        float scale=crop?Math.Max((float)width/source.Width,(float)height/source.Height):Math.Min((float)width/source.Width,(float)height/source.Height);
        float w=source.Width*scale,h=source.Height*scale;g.DrawImage(source,(width-w)/2,(height-h)/2,w,h);
        using var output=new MemoryStream();canvas.Save(output,System.Drawing.Imaging.ImageFormat.Png);return output.ToArray();
    }
    private static void Main()
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
        foreach(var fixture in new[]{("portrait",portrait),("landscape",landscape)})
        {
            using var p=new Presentation("output/template.pptx");
            foreach(string name in new[]{"Contain","Crop"})
            {var frame=Example.Named<IPictureFrame>(p.Slides[0],name);var position=(frame.X,frame.Y,frame.Width,frame.Height);
             frame.PictureFormat.Picture.Image=p.Images.AddImage(Fit(fixture.Item2,500,400,name=="Crop"));
             preserved&=position==(frame.X,frame.Y,frame.Width,frame.Height);}
            p.Save("output/"+fixture.Item1+".pptx",SaveFormat.Pptx);Example.Render(p,"output/"+fixture.Item1+"-preview.png");
            using var reopened=new Presentation("output/"+fixture.Item1+".pptx");
            Example.Require(Example.Named<IPictureFrame>(reopened.Slides[0],"Contain").Width==250,"Frame size changed.");
        }
        Example.Require(preserved,"Frame geometry changed.");Example.Result(new{frame_geometry_preserved=true,portrait_and_landscape_checked=true});
    }

}
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

Contain/crop preprocessing is application code using System.Drawing on Windows. It creates a raster image matching the existing frame aspect ratio; the Aspose operation replaces Picture.Image without changing the frame. This example is Windows-specific; it does not claim this drawing dependency works in Linux containers.

## Learn more

- [Manage Picture Frames in Presentations in .NET](https://docs.aspose.com/slides/net/picture-frame/)
- [Optimize Image Management in Presentations in .NET](https://docs.aspose.com/slides/net/image/)
