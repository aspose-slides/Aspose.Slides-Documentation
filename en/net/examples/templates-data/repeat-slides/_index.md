---
title: Repeat a Template Slide for Each Record
type: docs
weight: 50
url: /net/examples/templates-data/repeat-slides/
description: "Clone one template slide per customer, then fill its text, chart and picture from JSON records."
---

Clone one template slide per customer, then fill its text, chart and picture from JSON records.

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

    private sealed record Customer(string Name,double Amount,string Color);
    private static string[] Generate(Customer[] customers,string path)
    {
        using var p=new Presentation();var template=p.Slides[0];
        Example.Text(template.Shapes,"Customer","{{Customer}}",35,20,600,70);Example.Chart(template,"Sales");
        template.Shapes.AddPictureFrame(ShapeType.Rectangle,600,15,60,60,p.Images.AddImage(Example.Png(60,60,Color.Gray))).Name="Logo";
        foreach(var customer in customers)
        {var slide=p.Slides.AddClone(template);Example.Named<IAutoShape>(slide,"Customer").TextFrame.ReplaceText("{{Customer}}",customer.Name,new TextSearchOptions(),null);
         Example.ChartData(Example.Named<IChart>(slide,"Sales"),new[]{"Sales"},new[]{customer.Name},new[]{new[]{customer.Amount}});
         Example.Named<IPictureFrame>(slide,"Logo").PictureFormat.Picture.Image=p.Images.AddImage(Example.Png(60,60,Color.FromName(customer.Color)));}
        p.Slides.Remove(template);Example.Require(p.Slides.Count==customers.Length,"Default/template slide leaked.");
        if(customers.Length==0)return Array.Empty<string>();
        p.Save(path,SaveFormat.Pptx);Example.Render(p,path+".png");using var reopened=new Presentation(path);
        var values=reopened.Slides.Cast<ISlide>().Select(s=>Example.Named<IAutoShape>(s,"Customer").TextFrame.Text).ToArray();
        for(int i=0;i<customers.Length;i++)Example.Require(Convert.ToDouble(Example.Named<IChart>(reopened.Slides[i],"Sales").ChartData.Series[0].DataPoints[0].Value.Data)==customers[i].Amount,"Record state leaked.");return values;
    }
    private static void Main()
    {
        Example.Setup();var data=JsonSerializer.Deserialize<Customer[]>(File.ReadAllText("customers.json"))!;
        var first=Generate(data,"output/report.pptx");var second=Generate(data,"output/repeated.pptx");
        Example.Require(first.SequenceEqual(data.Select(c=>c.Name))&&first.SequenceEqual(second),"Order or repeatability differs.");
        Example.Require(Generate(Array.Empty<Customer>(),"output/empty.pptx").Length==0,"Empty data not handled.");
        using var duplicate=new Presentation();Example.Text(duplicate.Slides[0].Shapes,"Duplicate","A");Example.Text(duplicate.Slides[0].Shapes,"Duplicate","B");
        bool rejected=Example.Throws(()=>Example.Named<IAutoShape>(duplicate.Slides[0],"Duplicate"));Example.Require(rejected,"Duplicate name accepted.");
        Example.Result(new{slide_count=data.Length,order_preserved=true,no_template_slide=true,no_state_leak=true,semantic_repeatability=true,duplicate_name_rejected=rejected});
    }

}
```

## Expected result and checks

The program writes its semantic checks to `output/result.json` and throws if a required
result differs. Expected check values are:

```json
{
  "slide_count": 2,
  "order_preserved": true,
  "no_template_slide": true,
  "no_state_leak": true,
  "semantic_repeatability": true,
  "duplicate_name_rejected": true
}
```

The original template slide is removed deliberately. Output order matches the data order. The checks compare repeatable content, not identical ZIP bytes or timestamps. Shape names must be unique within the relevant slide; duplicate names are rejected. An empty dataset returns no report slides.

## Learn more

- [Clone Presentation Slides in .NET](https://docs.aspose.com/slides/net/clone-slides/)
- [Manage Presentation Placeholders in .NET](https://docs.aspose.com/slides/net/manage-placeholder/)
