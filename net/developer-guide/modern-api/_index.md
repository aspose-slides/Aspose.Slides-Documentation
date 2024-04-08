---
title: Modern API
type: docs
weight: 237
url: /net/modern-api/
keywords: "CrossPlatform Modern API System.Drawing"
description: "Modern API"
---

## Introduction

Historically, Aspose Slides has a dependency on System.Drawing and has in the public API the following classes from there:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

As of version 24.4, this public API is declared deprecated.

Since System.Drawing support in versions .NET6 and above is removed for non-Windows versions ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides has implemented a two library version approach:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - support for .NET6+ for Windows, .NETStandard for Windows/Linux/MacOS, .NETFramework 2+ (Windows).
  - has a dependence on [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - Windows/Linux/MacOS version without dependencies.

The inconvenience of [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) is that it implements its own version of System.Drawing in the same namespace (to support backward compatibility with the public API). Thus, when Aspose.Slides.NET6.CrossPlatform and System.Drawing from .NETFramrwork or System.Drawing.Common package are used at the same time, a name conflict occurs unless alias is used.

In order to get rid of dependencies on System.Drawing in the main Aspose.Slides.NET package, we added the so-called "Modern API" - i.e. the API that should be used instead of the deprecated one, whose signatures contain dependencies on the following types from System.Drawing: Image and Bitmap. PrinterSettings and Graphics are declared deprecated and their support is removed from the public Slides API.

Removal of the deprecated public API with dependencies on System.Drawing will be in release 24.8.

## Modern API

Added the following classes and enums to the public API:

- Aspose.Slides.IImage - represents the raster or vector image.
- Aspose.Slides.ImageFormat - represents the file format of the image.
- Aspose.Slides.Images - methods to instantiate and work with the IImage interface.

Please note that IImage is disposable (it implements the IDisposable interface and its use should be wrapped in using or dispose-it in another convenient way).

A typical scenario of using the new API may look as follows:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // instantiate a disposable instance of IImage from the file on the disk.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // create a PowerPoint image by adding an instance of IImage to the presentation's images.
        ppImage = pres.Images.AddImage(image);
    }

    // add a picture shape on the slide #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // get an instance of the IImage representing slide #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // save the image on the disk.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## Replacing old code with Modern API

For ease of transition, the interface of the new IImage repeats the separate signatures of the Image and Bitmap classes. In general, you will just need to replace the call to the old method using System.Drawing with the new one.

### Getting a slide thumbnail

Code using a deprecated API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

Modern API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### Getting a shape thumbnail

Code using a deprecated API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

Modern API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### Getting a presentation thumbnail

Code using a deprecated API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var bitmaps = pres.GetThumbnails(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < bitmaps.Length; index++)
        {
            Bitmap thumbnail = bitmaps[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (Bitmap bitmap in bitmaps)
        {
            bitmap.Dispose();
        }
    }
}
```

Modern API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var images = pres.GetImages(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < images.Length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (IImage image in images)
        {
            image.Dispose();
        }
    }
}
```

### Adding a picture to a presentation

Code using a deprecated API:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (Image image = Image.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

Modern API:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (IImage image = Aspose.Slides.Images.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

## Support for Aspose.Slides.NET6.CrossPlatform will be discontinued

Following the release of [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) version 24.8, support for [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) will be discontinued.

## API support for Graphics and PrinterSettings will be discontinued

The [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) class is not supported for cross-platform versions of .NET6 and higher. In Aspose Slides, the part of the API that uses it will be removed:
[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Also, the part of the API that is related to printing will be removed:

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)