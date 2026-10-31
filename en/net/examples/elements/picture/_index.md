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

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add a Picture**

This code loads the small authored PNG into a memory stream, and inserts it as a picture frame on the first slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Load the small authored PNG into memory without platform-specific drawing.
        using var imageStream = new MemoryStream(File.ReadAllBytes(Context.Input("Picture.png")));

        // Add the image to the presentation.
        var image = presentation.Images.AddImage(imageStream);

        // Insert a picture frame showing the image on the first slide.
        slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
            x: 50, y: 50, width: 40, height: 40, image);

        presentation.Save("picture.pptx", SaveFormat.Pptx);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IPictureFrame>().Single().PictureFormat.Picture.Image.BinaryData.SequenceEqual(File.ReadAllBytes(Context.Input("Picture.png"))), "AddPicture: semantic check 1 failed.");
        });
        Context.Pass("elements/picture/block-001", "AddPicture", "save-reopen-structure");
    }
}
```

## **Access a Picture**

This example ensures a slide contains a picture frame and then accesses the first one it finds.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // A valid packaged PNG supplies a deterministic editable picture.
        using var imageStream = new MemoryStream(File.ReadAllBytes(Context.Input("Picture.png")));

        // Add the image to the presentation.
        var image = presentation.Images.AddImage(imageStream);
        slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

        // Access the first picture frame on the slide.
        var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IPictureFrame>().Single().Width == 40 && p.Slides[0].Shapes.OfType<IPictureFrame>().Single().Height == 40, "AccessPicture: semantic check 1 failed.");
        });
        Context.Pass("elements/picture/block-002", "AccessPicture", "save-reopen-structure");
    }
}
```
