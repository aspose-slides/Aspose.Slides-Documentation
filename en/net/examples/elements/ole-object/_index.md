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

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add an OLE Object**

Embed a PDF file into the presentation.

```csharp
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var pdfStream = new MemoryStream();
presentation.Save(pdfStream, SaveFormat.Pdf);
byte[] pdfData = pdfStream.ToArray();
var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

presentation.Save("ole-object-01.pptx", SaveFormat.Pptx);
```

## **Access an OLE Object**

Retrieve the first OLE object frame on a slide.

```csharp
using System;
using System.IO;
using Aspose.Slides.Export;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var pdfStream = new MemoryStream();
presentation.Save(pdfStream, SaveFormat.Pdf);
byte[] pdfData = pdfStream.ToArray();
var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

var firstOleFrame = slide.Shapes.OfType<IOleObjectFrame>().First();
Console.WriteLine(firstOleFrame.EmbeddedData.EmbeddedFileExtension);

presentation.Save("ole-object-02.pptx", SaveFormat.Pptx);
```

## **Remove an OLE Object**

Delete an embedded OLE object from the slide.

```csharp
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var pdfStream = new MemoryStream();
presentation.Save(pdfStream, SaveFormat.Pdf);
byte[] pdfData = pdfStream.ToArray();
var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

slide.Shapes.Remove(oleFrame);

presentation.Save("ole-object-03.pptx", SaveFormat.Pptx);
```

## **Update OLE Object Data**

Replace the data embedded in an existing OLE object.

```csharp
using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var pdfStream = new MemoryStream();
presentation.Save(pdfStream, SaveFormat.Pdf);
byte[] pdfData = pdfStream.ToArray();
var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

var newData = Convert.FromBase64String(
    "iVBORw0KGgoAAAANSUhEUgAAACgAAAAoCAIAAAADnC86AAAAMElEQVR4nO3NQQkAAAgEsItoJiOa" +
    "yBKCn8H+S02/iFgsFovFYrFYLBaLxWKxWHxnAfyWQZeVYs/3AAAAAElFTkSuQmCC");
var newDataInfo = new OleEmbeddedDataInfo(newData, "png");
oleFrame.SetEmbeddedData(newDataInfo);

presentation.Save("ole-object-04.pptx", SaveFormat.Pptx);
```
