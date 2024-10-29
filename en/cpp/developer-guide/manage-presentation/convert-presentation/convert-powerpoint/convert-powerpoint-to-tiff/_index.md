---
title: Convert PowerPoint to TIFF
type: docs
weight: 90
url: /cpp/convert-powerpoint-to-tiff/
keywords: "Convert PowerPoint Presentation, PowerPoint to TIFF, PPT to TIFF, PPTX to TIFF, C++, CPP, Aspose.Slides"
description: "Convert PowerPoint presentation to TIFF in C++"
---

**TIFF** (Tagged Image File Format) is a lossless raster and high-quality image format. Professionals use TIFF for their design, photography, and desktop publishing purposes. For example, if you want to preserve layers and settings in your design or image, you may want to save your work as a TIFF image file. 

Aspose.Slides allows you to convert the slides in PowerPoint directly to TIFF. 

{{% alert title="Tip" color="primary" %}}

You may want to check out Aspose's [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Convert PowerPoint to TIFF**

Using the [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) method exposed by the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class, you can quickly convert an entire PowerPoint presentation to TIFF. The resulting TIFF images correspond to the slides' default size. 

This C++ code shows you how to convert PowerPoint to TIFF:

```c++
// The path to the documents directory.
String dataDir = GetDataPath();

// Instantiates a Presentation object that represents a presentation file
auto presentation = System::MakeObject<Presentation>(dataDir + u"DemoFile.pptx");

// Saves the presentation as TIFF
presentation->Save(dataDir + u"Tiffoutput_out.tiff", SaveFormat::Tiff);
```

## **Convert PowerPoint to Black-and-White TIFF**

In Aspose.Slides 23.10, Aspose.Slides added a new property ([BwConversionMode](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/)) to the [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options) class to allow you to specify the algorithm that is followed when a colored slide or image is converted to a black-and-white TIFF. Note that this setting is applied only when the [CompressionType](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) property is set to `CCITT4` or `CCITT3`.

This C++ code shows you how to convert a colored slide or image to black-and-white TIFF:

```c++
System::SharedPtr<TiffOptions> tiffOptions = System::MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);
```

## **Convert PowerPoint to TIFF with Custom Size**

If you require a TIFF image with defined dimensions, you can define your preferred figures through the properties provided under [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options). Using the [ImageSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) property, for example, you can set a size for the resulting image. 

This C++ code shows you how to convert PowerPoint to TIFF images with custom size:

```c++
// The path to the documents directory.
System::String dataDir = GetDataPath();

// Instantiates a Presentation object that represents a Presentation file
auto pres = System::MakeObject<Presentation>(dataDir + u"Convert_Tiff_Custom.pptx");
    
// Instantiates the TiffOptions class
auto opts = System::MakeObject<TiffOptions>();

// Sets the compression type
opts->set_CompressionType(TiffCompressionTypes::Default);

auto notesOptions = opts->get_NotesCommentsLayouting();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
// Compression Types

// Default - Specifies the default compression scheme (LZW).
// None - Specifies no compression.
// CCITT3
// CCITT4
// LZW
// RLE

// Depth depends on the compression type and cannot be set manually.
// Resolution unit  is always equal to �2� (dots per inch)

// Sets the image DPI
opts->set_DpiX(200);
opts->set_DpiY(100);

// Sets the Image Size
opts->set_ImageSize(System::Drawing::Size(1728, 1078));

// Saves the presentation to TIFF with specified size
pres->Save(dataDir + u"TiffWithCustomSize_out.tiff", SaveFormat::Tiff, opts);
```


## **Convert PowerPoint to TIFF with Custom Image Pixel Format**

Using the [PixelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) property under the [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options) class, you can specify your preferred pixel format for the resulting TIFF image. 

This C++ code shows you how to convert PowerPoint to TIFF image with custom pixel format:

```c++
// The path to the documents directory.
System::String dataDir = GetDataPath();

// Instantiates a Presentation object that represents a Presentation file
auto presentation = System::MakeObject<Presentation>(dataDir + u"DemoFile.pptx");

auto options = System::MakeObject<TiffOptions>();
options->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat contains the following values (as could be seen from documentation):
Format1bppIndexed; // 1 bits per pixel, indexed.
Format4bppIndexed; // 4 bits per pixel, indexed.
Format8bppIndexed; // 8 bits per pixel, indexed.
Format24bppRgb; // 24 bits per pixel, RGB.
Format32bppArgb; // 32 bits per pixel, ARGB.
*/

// Saves the presentation to TIFF with specified size
presentation->Save(dataDir + u"Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat::Tiff, options);
```


