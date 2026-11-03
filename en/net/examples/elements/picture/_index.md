---
title: Picture
type: docs
weight: 50
url: /net/examples/elements/picture/
keywords:
- picture
- picture frame
- add picture
- access picture
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Work with pictures in Aspose.Slides for .NET: insert, crop, compress, recolor, and export images with C# examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates how to insert and access pictures from in-memory images using **Aspose.Slides for .NET**. The examples below create an image in memory, place it on a slide, and then retrieve it.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks. The copied code runs in evaluation mode. For licensed output, apply your license before creating a presentation, as described in the [licensing guide](/slides/net/licensing/).

## **Download and run**

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add a Picture**

This code decodes the small authored PNG into a byte array and inserts it as a picture frame on the first slide.

```csharp
using System;
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Load the small authored PNG into memory without platform-specific drawing.
var pngData = Convert.FromBase64String(
    "iVBORw0KGgoAAAANSUhEUgAAACgAAAAoCAIAAAADnC86AAAAMElEQVR4nO3NQQkAAAgEsItoJiOa" +
    "yBKCn8H+S02/iFgsFovFYrFYLBaLxWKxWHxnAfyWQZeVYs/3AAAAAElFTkSuQmCC");

// Add the image to the presentation.
var image = presentation.Images.AddImage(pngData);

// Insert a picture frame showing the image on the first slide.
slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
    x: 50, y: 50, width: 40, height: 40, image);

presentation.Save("picture.pptx", SaveFormat.Pptx);
```

## **Access a Picture**

This example ensures a slide contains a picture frame and then accesses the first one it finds.

```csharp
using System;
using Aspose.Slides.Export;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Use a small PNG as the example image.
var pngData = Convert.FromBase64String(
    "iVBORw0KGgoAAAANSUhEUgAAACgAAAAoCAIAAAADnC86AAAAMElEQVR4nO3NQQkAAAgEsItoJiOa" +
    "yBKCn8H+S02/iFgsFovFYrFYLBaLxWKxWHxnAfyWQZeVYs/3AAAAAElFTkSuQmCC");

// Add the image to the presentation.
var image = presentation.Images.AddImage(pngData);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

// Access the first picture frame on the slide.
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().First();
Console.WriteLine(pictureFrame.Width);

presentation.Save("picture-02.pptx", SaveFormat.Pptx);
```
