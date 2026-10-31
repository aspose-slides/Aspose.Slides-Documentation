---
title: Fill a Presentation Template
type: docs
weight: 10
url: /net/examples/templates-data/fill-placeholders/
description: "Fill required customer markers, including a marker split across text portions, from JSON. The sample keeps surrounding bold formatting and leaves the template unchanged."
---

Fill required customer markers, including a marker split across text portions, from JSON. The sample keeps surrounding bold formatting and leaves the template unchanged.

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

internal static class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, async ctx =>
    {
        Context = ctx;
        Example.Context = ctx;
        ctx.BeginAction("templates-data/fill-placeholders/block-001");
        RunExample();
        string path=File.Exists("output/result.json")?"output/result.json":"result.json";
        using var result=JsonDocument.Parse(File.ReadAllText(path));
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        if(ctx.IsLicensed)
        {
            using var expected=JsonDocument.Parse("{\"checks.marker_replaced\":true,\"checks.format_retained\":true,\"checks.missing_required_rejected\":true,\"checks.long_text_checked\":true,\"checks.input_unchanged\":true}");
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
        ctx.Pass("templates-data/fill-placeholders/block-001",checks);
        await Task.CompletedTask;
    });


    private static void Bind(ISlide slide,Dictionary<string,string> data)
    {
        if(!data.TryGetValue("Customer",out string? customer)||string.IsNullOrWhiteSpace(customer))throw new InvalidDataException("Customer is required.");
        foreach(var frame in Example.Frames(slide))
        {frame.ReplaceText("{{Customer}}",customer,new TextSearchOptions{CaseSensitive=true},null);
         frame.ReplaceText("{{Optional}}",data.GetValueOrDefault("Optional",""),new TextSearchOptions{CaseSensitive=true},null);
         frame.TextFrameFormat.AutofitType=TextAutofitType.Normal;}
        if(Example.Frames(slide).Any(f=>f.Text.Contains("{{")))throw new InvalidDataException("Unbound template marker.");
    }
    private static void RunExample()
    {
        Example.Setup();
        var values=JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText("customer.json"))!;
        using(var template=new Presentation())
        {
            var title=Example.Text(template.Slides[0].Shapes,"Customer","",35,35,600,100);
            var p=title.TextFrame.Paragraphs[0];p.Portions.Clear();
            var prefix=new Portion("Customer: ");prefix.PortionFormat.FontBold=NullableBool.True;p.Portions.Add(prefix);
            p.Portions.Add(new Portion("{{Cus"));p.Portions.Add(new Portion("tomer}}"));
            foreach(var portion in p.Portions){portion.PortionFormat.LatinFont=new FontData("Noto Sans");portion.PortionFormat.FontHeight=24;portion.PortionFormat.FillFormat.FillType=FillType.Solid;portion.PortionFormat.FillFormat.SolidFillColor.Color=Color.FromArgb(35,65,100);}
            Example.Text(template.Slides[0].Shapes,"Optional","{{Optional}}",35,180,600,60);
            template.Save("output/template.pptx",SaveFormat.Pptx);
        }
        string before=Example.HashFile("output/template.pptx");
        using(var p=new Presentation("output/template.pptx"))
        {
            Bind(p.Slides[0],values);p.Save("output/filled.pptx",SaveFormat.Pptx);Example.Render(p,"output/preview.png");
        }
        using var check=new Presentation("output/filled.pptx");
        var shape=Example.Named<IAutoShape>(check.Slides[0],"Customer");
        Example.Require(shape.TextFrame.Text==Example.ExpectedText("Customer: "+values["Customer"]),"Run-spanning marker was not replaced.");
        Example.VerifySavedText("output/filled.pptx","Customer","Customer: "+values["Customer"]);
        Example.Require(shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold==NullableBool.True,"Prefix style changed.");
        bool missing=Example.Throws(()=>Bind(check.Slides[0],new Dictionary<string,string>()));
        using var longDeck=new Presentation("output/template.pptx");Bind(longDeck.Slides[0],new(){{"Customer",string.Join(" ",Enumerable.Repeat("Long customer name",8))}});
        var longShape=Example.Named<IAutoShape>(longDeck.Slides[0],"Customer");
        // Bounded application-side fitting keeps the text measurable before saving.
        longShape.TextFrame.TextFrameFormat.AutofitType=TextAutofitType.None;
        for(float size=24;size>=10;size--)
        {foreach(var paragraph in longShape.TextFrame.Paragraphs)foreach(var portion in paragraph.Portions)portion.PortionFormat.FontHeight=size;
         if(longShape.TextFrame.Paragraphs.Sum(p=>p.GetRect().Height)<=longShape.Height-12)break;}
        bool overflow=longShape.TextFrame.Paragraphs.Sum(p=>p.GetRect().Height)>longShape.Height-12;
        Example.Render(longDeck,"output/long-preview.png");Example.Require(!overflow,"Long text overflows the checked frame height.");
        Example.Require(Example.HashFile("output/template.pptx")==before,"Input changed.");
        Example.Result(new{marker_replaced=true,format_retained=true,missing_required_rejected=missing,long_text_checked=!overflow,input_unchanged=true});
    }

}
```

## Expected result and checks

The program writes its semantic checks to `output/result.json` and throws if a required
result differs. Expected check values are:

```json
{
  "marker_replaced": true,
  "format_retained": true,
  "missing_required_rejected": true,
  "long_text_checked": true,
  "input_unchanged": true
}
```

Required values are checked before replacement. Optional values default to empty strings. The long-name case applies a bounded font-size reduction, checks paragraph height and creates a separate preview for visual review. Mixed styles within a replaced marker need their own design decision; this example preserves the surrounding prefix.

## Learn more

- [Manage Presentation Placeholders in .NET](https://docs.aspose.com/slides/net/manage-placeholder/)
- [Search and Replace Text in PowerPoint Presentations in .NET](https://docs.aspose.com/slides/net/search-and-replace-text/)
- [Enhance Your Presentations with AutoFit in .NET](https://docs.aspose.com/slides/net/manage-autofit-settings/)


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
