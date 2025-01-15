---
title: Convert PowerPoint to TIFF
type: docs
weight: 90
url: /net/convert-powerpoint-to-tiff/
keywords: "Convert PowerPoint Presentation, PowerPoint to TIFF, PPT to TIFF, PPTX to TIFF, C#, Csharp, .NET, Aspose.Slides"
description: "Convert PowerPoint presentation to TIFF in C# or .NET."

---

TIFF (**Tagged Image File Format**) is a lossless raster and high-quality image format. Professionals use TIFF for their design, photography, and desktop publishing purposes. For example, if you want to preserve layers and settings in your design or image, you may want to save your work as a TIFF image file. 

Aspose.Slides allows you to convert the slides in PowerPoint directly to TIFF. 

{{% alert title="Tip" color="primary" %}}

You may want to check out Aspose's [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Convert PowerPoint to TIFF**

Using the [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) method exposed by the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class, you can quickly convert an entire PowerPoint presentation to TIFF. The resulting TIFF images correspond to the slides' default size. 

This C# code shows you how to convert PowerPoint to TIFF:

```c#
// Instantiates a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    // Saves the presentation as TIFF
    presentation.Save("Tiffoutput_out.tiff", SaveFormat.Tiff);
}
```

## **Convert PowerPoint to Black-and-White TIFF**

In Aspose.Slides 23.10, Aspose.Slides added a new property ([BwConversionMode](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/bwconversionmode/)) to the [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) class to allow you to specify the algorithm that is followed when a colored slide or image is converted to a black-and-white TIFF. Note that this setting is applied only when the [CompressionType](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) property is set to `CCITT4` or `CCITT3`.

This C# code shows you how to convert a colored slide or image to black-and-white TIFF:

```c#
var tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
```

## **Convert PowerPoint to TIFF with Custom Size**

If you require a TIFF image with defined dimensions, you can define your preferred figures through the properties provided under [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/). Using the [ImageSize](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) property, for example, you can set a size for the resulting image. 

This C# code shows you how to convert PowerPoint to TIFF images with custom size:

```c#
// Instantiates a Presentation object that represents a Presentation file
using (Presentation pres = new Presentation("Convert_Tiff_Custom.pptx"))
{
    // Instantiates the TiffOptions class
    TiffOptions opts = new TiffOptions();

    // Sets the compression type
    opts.CompressionType = TiffCompressionTypes.Default;

    opts.SlidesLayoutOptions = new NotesCommentsLayoutingOptions() { NotesPosition = NotesPositions.BottomFull };

    // Compression Types

    // Default - Specifies the default compression scheme (LZW).
    // None - Specifies no compression.
    // CCITT3
    // CCITT4
    // LZW
    // RLE

    // Depth depends on the compression type and cannot be set manually.
    // Resolution unit  is always equal to “2” (dots per inch)

    // Sets the image DPI
    opts.DpiX = 200;
    opts.DpiY = 100;

    // Sets the Image Size
    opts.ImageSize = new Size(1728, 1078);

    // Saves the presentation to TIFF with specified size
    pres.Save("TiffWithCustomSize_out.tiff", SaveFormat.Tiff, opts);
}
```


## **Convert PowerPoint to TIFF with Custom Image Pixel Format**

Using the [PixelFormat](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) property under the [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions) class, you can specify your preferred pixel format for the resulting TIFF image. 

This C# code shows you how to convert PowerPoint to TIFF image with custom pixel format:

```c#
// Instantiates a Presentation object that represents a Presentation file
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    TiffOptions options = new TiffOptions();
   
    options.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat contains the following values (as stated in the documentation):
    Format1bppIndexed; // 1 bits per pixel, indexed.
    Format4bppIndexed; // 4 bits per pixel, indexed.
    Format8bppIndexed; // 8 bits per pixel, indexed.
    Format24bppRgb; // 24 bits per pixel, RGB.
    Format32bppArgb; // 32 bits per pixel, ARGB.
    */

    // Saves the presentation to TIFF with specified image size
    presentation.Save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat.Tiff, options);
}
```

