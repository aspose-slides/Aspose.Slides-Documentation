---
title: Picture
type: docs
weight: 50
url: /net/examples/elements/picture/
keywords:
- code example
- picture
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Work with pictures in Aspose.Slides for .NET: insert, crop, compress, recolor, and export images with C# examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates how to insert and access pictures from in-memory images using **Aspose.Slides for .NET**. The examples below create an image in memory, place it on a slide, and then retrieve it.

## **Add a Picture**

This code generates a small bitmap, converts it to a stream, and inserts it as a picture frame on the first slide.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Create a simple in-memory image.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // Convert the bitmap to MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Add the image to the presentation.
    var image = presentation.Images.AddImage(imageStream);

    // Insert a picture frame showing the image on the first slide.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Access a Picture**

This example ensures a slide contains a picture frame and then accesses the first one it finds.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Ensure there is at least one picture frame to work with.
    using var bitmap = new Bitmap(40, 40);

    // Convert the bitmap to MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Add the image to the presentation.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // Access the first picture frame on the slide.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```
