---
title: Fill a Presentation Template
type: docs
weight: 10
url: /net/examples/templates-data/fill-placeholders/
description: "Fill required customer markers, including a marker split across text portions, from JSON. The sample keeps surrounding bold formatting and leaves the template unchanged."
---

Fill required customer markers, including a marker split across text portions, from JSON. The sample keeps surrounding bold formatting and leaves the template unchanged.

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

    private static void Bind(ISlide slide,Dictionary<string,string> data)
    {
        if(!data.TryGetValue("Customer",out string? customer)||string.IsNullOrWhiteSpace(customer))throw new InvalidDataException("Customer is required.");
        foreach(var frame in Example.Frames(slide))
        {frame.ReplaceText("{{Customer}}",customer,new TextSearchOptions{CaseSensitive=true},null);
         frame.ReplaceText("{{Optional}}",data.GetValueOrDefault("Optional",""),new TextSearchOptions{CaseSensitive=true},null);
         frame.TextFrameFormat.AutofitType=TextAutofitType.Normal;}
        if(Example.Frames(slide).Any(f=>f.Text.Contains("{{")))throw new InvalidDataException("Unbound template marker.");
    }
    private static void Main()
    {
        Example.Setup();
        var values=JsonSerializer.Deserialize<Dictionary<string,string>>(File.ReadAllText("customer.json"))!;
        using(var template=new Presentation())
        {
            var title=Example.Text(template.Slides[0].Shapes,"Customer","",35,35,600,100);
            var p=title.TextFrame.Paragraphs[0];p.Portions.Clear();
            var prefix=new Portion("Customer: ");prefix.PortionFormat.FontBold=NullableBool.True;p.Portions.Add(prefix);
            p.Portions.Add(new Portion("{{Cus"));p.Portions.Add(new Portion("tomer}}"));
            foreach(var portion in p.Portions){portion.PortionFormat.LatinFont=new FontData("Arial");portion.PortionFormat.FontHeight=24;portion.PortionFormat.FillFormat.FillType=FillType.Solid;portion.PortionFormat.FillFormat.SolidFillColor.Color=Color.FromArgb(35,65,100);}
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
        Example.Require(shape.TextFrame.Text=="Customer: "+values["Customer"],"Run-spanning marker was not replaced.");
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
