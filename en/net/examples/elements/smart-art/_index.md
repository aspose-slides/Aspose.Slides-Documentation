---
title: SmartArt
type: docs
weight: 140
url: /net/examples/elements/smart-art/
keywords:
- SmartArt
- add SmartArt
- access SmartArt
- remove SmartArt
- SmartArt layout
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Work with SmartArt in Aspose.Slides for .NET: create, edit, convert, and style diagrams with C# for PowerPoint and OpenDocument presentations."
---

This article demonstrates how to add SmartArt graphics, access them, remove them, and change layouts using **Aspose.Slides for .NET**.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add SmartArt**

Insert a SmartArt graphic using one of the built-in layouts.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

presentation.Save("smart-art-01.pptx", SaveFormat.Pptx);
```

## **Access SmartArt**

Retrieve the first SmartArt object on a slide.

```csharp
using System;
using Aspose.Slides.Export;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
Console.WriteLine(firstSmartArt.AllNodes.Count);

presentation.Save("smart-art-02.pptx", SaveFormat.Pptx);
```

## **Remove SmartArt**

Delete a SmartArt shape from the slide.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

slide.Shapes.Remove(smartArt);

presentation.Save("smart-art-03.pptx", SaveFormat.Pptx);
```

## **Change SmartArt Layout**

Update the layout type of an existing SmartArt graphic.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

smartArt.Layout = SmartArtLayoutType.VerticalPictureList;

presentation.Save("smart-art-04.pptx", SaveFormat.Pptx);
```
