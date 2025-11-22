---
title: Convert PowerPoint Presentations to TIFF in C++
titlelink: PowerPoint to TIFF
type: docs
weight: 90
url: /cpp/convert-powerpoint-to-tiff/
keywords:
- convert PowerPoint
- convert OpenDocument
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to TIFF
- presentation to TIFF
- slide to TIFF
- PPT to TIFF
- PPTX to TIFF
- save PPT as TIFF
- save PPTX as TIFF
- export PPT to TIFF
- export PPTX to TIFF
- C++
- Aspose.Slides
description: "Learn how to easily convert PowerPoint (PPT, PPTX) presentations to high-quality TIFF images using Aspose.Slides for C++, with code examples."
---

## **Overview**

TIFF (**Tagged Image File Format**) is a widely-used, lossless raster image format known for its exceptional quality and detailed preservation of graphics. Designers, photographers, and desktop publishers often choose TIFF to maintain layers, color accuracy, and original settings in their images.

Using Aspose.Slides, you can effortlessly convert your PowerPoint slides (PPT, PPTX) and OpenDocument slides (ODP) directly into high-quality TIFF images, ensuring your presentations retain maximum visual fidelity.

## **Convert a Presentation to TIFF**

Using the [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) method provided by the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class, you can quickly convert an entire PowerPoint presentation to TIFF. The resulting TIFF images correspond to the default slide size.

This C++ code demonstrates how to convert a PowerPoint presentation to TIFF:

```cpp
// Instantiate the Presentation class that represents a presentation file (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Save the presentation as TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Convert a Presentation to Black-and-White TIFF**

The method [set_BwConversionMode](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) in the [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/) class allows you to specify the algorithm used when converting a colored slide or image to a black-and-white TIFF. Note that this setting applies only when the [set_CompressionType](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) method is set to `CCITT4` or `CCITT3`.

Let's say we have a "sample.pptx" file with the following slide:

![A presentation slide](slide_black_and_white.png)

This C++ code demonstrates how to convert the colored slide to a black-and-white TIFF:

```cpp
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

The result:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Convert a Presentation to TIFF with Custom Size**

If you require a TIFF image with specific dimensions, you can set your desired values using methods available in [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/). For instance, the [set_ImageSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) method allows you to define the size of the resulting image.

This C++ code demonstrates how to convert a PowerPoint presentation to TIFF images with a custom size:

```cpp
// Instantiate the Presentation class that represents a presentation file (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Set the compression type.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Compression types:
    Default - Specifies the default compression scheme (LZW).
    None - Specifies no compression.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// The depth depends on the compression type and cannot be set manually.

// Set the image DPI.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Set the image size.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation as TIFF with the specified size.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Convert a Presentation to TIFF with Custom Image Pixel Format**

Using the [set_PixelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) method from the [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/) class, you can specify your preferred pixel format for the resulting TIFF image.

This C++ code demonstrates how to convert a PowerPoint presentation to a TIFF image with a custom pixel format:

```cpp
// Instantiate the Presentation class that represents a presentation file (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat contains the following values (as stated in the documentation):
    Format1bppIndexed - 1 bit per pixel, indexed.
    Format4bppIndexed - 4 bits per pixel, indexed.
    Format8bppIndexed - 8 bits per pixel, indexed.
    Format24bppRgb    - 24 bits per pixel, RGB.
    Format32bppArgb   - 32 bits per pixel, ARGB.
*/

// Save the presentation as TIFF with the specified image size.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="primary" %}}

Check out Aspose's [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQs**

**1. Can I convert an individual slide instead of entire PowerPoint presentation to TIFF?**

Yes. Aspose.Slides allows you to convert individual slides from PowerPoint and OpenDocument presentations into TIFF images separately.

**2. Is there any limit to the number of slides when converting a presentation to TIFF?**

No, Aspose.Slides does not impose any restrictions on the number of slides. You can convert presentations of any size into TIFF format.

**3. Are PowerPoint animations and transition effects preserved when converting slides to TIFF?**

No, TIFF is a static image format. Therefore, animations and transition effects are not preserved; only static snapshots of slides are exported.
