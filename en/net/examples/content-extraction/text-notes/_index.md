---
title: Extract Slide Text and Notes
type: docs
weight: 10
url: /net/examples/content-extraction/text-notes/
description: "Extract slide text and speaker notes to JSON with a presentation hash and one-based slide numbers."
---

Extract slide text and speaker notes to JSON with a presentation hash and one-based slide numbers.

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

    private sealed record TextItem(string Shape,string Text);
    private sealed record SlideText(int Number,bool Hidden,TextItem[] Text,string Notes);
    private static SlideText[] Extract(Presentation p,bool includeHidden)
    {return p.Slides.Cast<ISlide>().Select((s,i)=>(s,i)).Where(x=>includeHidden||!x.s.Hidden).Select(x=>new SlideText(x.i+1,x.s.Hidden,Example.Walk(x.s.Shapes).OfType<IAutoShape>().Select(s=>new TextItem(s.Name,s.TextFrame.Text)).ToArray(),x.s.NotesSlideManager.NotesSlide?.NotesTextFrame.Text??"")).ToArray();}
    private static void Main()
    {
        Example.Setup();using(var p=new Presentation())
        {var slide=p.Slides[0];Example.Text(slide.Shapes,"Title","Résumé – 東京");var group=slide.Shapes.AddGroupShape();Example.Text(group.Shapes,"Group text","Grouped α");var nested=group.Shapes.AddGroupShape();Example.Text(nested.Shapes,"Nested text","Nested β");Example.Text(slide.Shapes,"Empty","");slide.NotesSlideManager.AddNotesSlide().NotesTextFrame.Text="Speaker notes ✓";
         var hidden=p.Slides.AddEmptySlide(p.LayoutSlides[0]);hidden.Hidden=true;Example.Text(hidden.Shapes,"Hidden text","Hidden slide");p.Save("output/input.pptx",SaveFormat.Pptx);}
        using var input=new Presentation("output/input.pptx");var all=Extract(input,true);var visible=Extract(input,false);
        Example.Json("output/text.json",new{presentation=Example.HashFile("output/input.pptx"),include_hidden=true,slides=all});
        Example.Require(all.Length==2 && visible.Length==1 && all[1].Number==2,"Slide number/hidden policy differs.");
        Example.Require(all[0].Text.Any(x=>x.Text=="Résumé – 東京")&&all[0].Text.Any(x=>x.Text=="Nested β")&&all[0].Text.Any(x=>x.Text==""),"Unicode/group/empty text lost.");
        Example.Require(all[0].Notes.Contains("Speaker notes ✓"),"Notes lost.");Example.Result(new{slides_including_hidden=2,visible_slides=1,unicode_groups_empty_and_notes_checked=true,one_based_numbering=true});
    }

}
```

## Expected result and checks

The program writes its semantic checks to `output/result.json` and throws if a required
result differs. Expected check values are:

```json
{
  "slides_including_hidden": 2,
  "visible_slides": 1,
  "unicode_groups_empty_and_notes_checked": true,
  "one_based_numbering": true
}
```

The includeHidden argument controls whether hidden slides appear. Traversal includes nested groups and preserves empty text frames. Shape order is a storage/traversal order, not a promise of human reading order. This is text extraction, not OCR; images are not converted into text.

## Learn more

- [Advanced Text Extraction from Presentations in .NET](https://docs.aspose.com/slides/net/extract-text-from-presentation/)
- [Manage Presentation Notes in .NET](https://docs.aspose.com/slides/net/presentation-notes/)
