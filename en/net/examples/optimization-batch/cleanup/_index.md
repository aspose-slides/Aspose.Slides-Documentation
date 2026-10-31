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
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;
using Aspose.Slides.Warnings;

internal static class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, async ctx =>
    {
        Context = ctx;
        Example.Context = ctx;
        ctx.BeginAction("optimization-batch/cleanup/block-001");
        RunExample();
        string path=File.Exists("output/result.json")?"output/result.json":"result.json";
        using var result=JsonDocument.Parse(File.ReadAllText(path));
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        if(ctx.IsLicensed)
        {
            using var expected=JsonDocument.Parse("{\"checks.unused_structures_removed\":true,\"checks.referenced_content_preserved\":true,\"checks.nominated_unreferenced_image_removed\":true,\"checks.referenced_image_deletion_rejected\":true,\"checks.render_identical\":true}");
            foreach(var field in expected.RootElement.EnumerateObject())
            {
                var actual=result.RootElement;foreach(string part in field.Name.Split('.'))actual=actual.GetProperty(part);
                ctx.Require(actual.ToString()==field.Value.ToString(),"Licensed assertion differs: "+field.Name);
                checks["licensed-"+field.Name.Replace('.','-')]=true;
            }
        }
        else
        {
            var values=result.RootElement.TryGetProperty("checks",out var nested)?nested:result.RootElement;
            foreach(var field in values.EnumerateObject())if(field.Value.ValueKind==JsonValueKind.False)throw new InvalidOperationException("Evaluation assertion failed: "+field.Name);
            checks["evaluation-semantic-effect"]=true;checks["evaluation-valid-output"]=true;
        }
        foreach(string pdf in Directory.GetFiles(".","*.pdf",SearchOption.AllDirectories))ctx.Require(File.ReadAllBytes(pdf).AsSpan(0,5).SequenceEqual(System.Text.Encoding.ASCII.GetBytes("%PDF-")),"Invalid PDF output.");
        foreach(string png in Directory.GetFiles(".","*.png",SearchOption.AllDirectories)){var image=PortableImage.Decode(File.ReadAllBytes(png));ctx.Require(image.Width>0&&image.Height>0,"Empty PNG output.");}
        ctx.Pass("optimization-batch/cleanup/block-001",checks);
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
    private static void RunExample()
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

}
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
