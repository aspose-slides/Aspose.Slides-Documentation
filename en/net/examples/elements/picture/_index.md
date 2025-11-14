---
title: Picture
type: docs
weight: 50
url: /net/examples/elements/picture/
keywords:
- picture example
- picture frame
- add picture
- access picture
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Work with pictures in C# using Aspose.Slides: insert, replace, crop, compress, adjust transparency and effects, fill shapes, and export for PPT, PPTX and ODP."
---

Shows how to insert and access pictures from in-memory images using **Aspose.Slides for .NET**. The examples below create an image in memory, place it on a slide, and then retrieve it.

## Add a Picture

This code generates a small bitmap, converts it to a stream, and inserts it as a picture frame on the first slide.

```csharp
public static void Add_Picture()
{
    using var pres = new Presentation();

    // Create a simple in-memory image
    using var bmp = new Bitmap(width: 100, height: 100);
    using (var g = Graphics.FromImage(bmp))
    {
        g.Clear(Color.LightGreen);
    }

    // Convert Bitmap to MemoryStream
    using var imageStream = new MemoryStream();
    bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Add the image to the presentation
    var ppImage = pres.Images.AddImage(imageStream);

    // Insert a picture frame showing the image on the first slide
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bmp.Width, height: bmp.Height, ppImage);

    pres.Save(@"c:\_tmp\xxx.pptx", SaveFormat.Pptx);
}
```

## Access a Picture

This example ensures a slide contains a picture frame and then accesses the first one it finds.

```csharp
public static void Access_Picture()
{
    using var pres = new Presentation();

    // Ensure there is at least one picture frame to work with
    using var bmp = new Bitmap(40, 40);

    // Convert Bitmap to MemoryStream
    using var imageStream = new MemoryStream();
    bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Add the image to the presentation
    var ppImage = pres.Images.AddImage(imageStream);
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, ppImage);

    // Access the first picture frame on the slide
    var pictureFrame = pres.Slides[0].Shapes.OfType<PictureFrame>().First();
}
```
