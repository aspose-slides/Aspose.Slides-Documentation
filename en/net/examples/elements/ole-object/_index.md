---
title: OLE Object
type: docs
weight: 210
url: /net/examples/elements/ole-object/
keywords:
- OLE object
- add OLE object
- access OLE object
- remove OLE object
- update OLE object
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Handle OLE objects in Aspose.Slides for .NET: insert, link, update, and extract embedded content with C# in PPT, PPTX, and ODP presentations."
---

This article demonstrates embedding a file as an OLE object and updating its data using **Aspose.Slides for .NET**.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add an OLE Object**

Embed a PDF file into the presentation.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var pdfData = File.ReadAllBytes(Context.Input("doc.pdf"));
        var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IOleObjectFrame>().Single().EmbeddedData.EmbeddedFileData.SequenceEqual(File.ReadAllBytes(Context.Input("doc.pdf"))), "AddOleObject: semantic check 1 failed.");
        });
        Context.Pass("elements/ole-object/block-001", "AddOleObject", "save-reopen-structure");
    }
}
```

## **Access an OLE Object**

Retrieve the first OLE object frame on a slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var pdfData = File.ReadAllBytes(Context.Input("doc.pdf"));
        var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

        var firstOleFrame = slide.Shapes.OfType<IOleObjectFrame>().First();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IOleObjectFrame>().Single().EmbeddedData.EmbeddedFileExtension.TrimStart('.') == "pdf", "AccessOleObject: semantic check 1 failed.");
        });
        Context.Pass("elements/ole-object/block-002", "AccessOleObject", "save-reopen-structure");
    }
}
```

## **Remove an OLE Object**

Delete an embedded OLE object from the slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var pdfData = File.ReadAllBytes(Context.Input("doc.pdf"));
        var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

        slide.Shapes.Remove(oleFrame);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IOleObjectFrame>().Any(), "RemoveOleObject: semantic check 1 failed.");
        });
        Context.Pass("elements/ole-object/block-003", "RemoveOleObject", "save-reopen-structure");
    }
}
```

## **Update OLE Object Data**

Replace the data embedded in an existing OLE object.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var pdfData = File.ReadAllBytes(Context.Input("doc.pdf"));
        var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

        var newData = File.ReadAllBytes(Context.Input("Picture.png"));
        var newDataInfo = new OleEmbeddedDataInfo(newData, "png");
        oleFrame.SetEmbeddedData(newDataInfo);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IOleObjectFrame>().Single().EmbeddedData.EmbeddedFileData.SequenceEqual(File.ReadAllBytes(Context.Input("Picture.png"))), "UpdateOleObjectData: semantic check 1 failed.");
        });
        Context.Pass("elements/ole-object/block-004", "UpdateOleObjectData", "save-reopen-structure");
    }
}
```
