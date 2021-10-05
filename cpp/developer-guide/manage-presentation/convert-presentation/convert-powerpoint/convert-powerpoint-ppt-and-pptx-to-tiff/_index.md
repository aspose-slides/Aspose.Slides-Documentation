---
title: Convert PowerPoint PPT and PPTX to TIFF
type: docs
weight: 90
url: /cpp/convert-powerpoint-ppt-and-pptx-to-tiff/
keywords: "PowerPoint PPT and PPTX to TIFF"
description: "Convert PowerPoint PPT and PPTX to TIFF with Aspose.Slides API."
---

TIFF format is known by its flexibility to accommodate multipage images and data. Keeping in view the importance and popularity of TIFF format, Aspose.Slides for C++ provides the support for converting presentations into TIFF document.

{{% alert  title="Tip" color="primary" %}} 

You may want to check out Aspose [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}} 

## **Convert Powerpoint to TIFF with default size**
The [Save](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) method exposed by [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class can be called by developers to convert the whole presentation into TIFF document. Further, [TiffOptions](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options) class exposes **set_ImageSize()** method enabling the developer to define the size of the image if required. The following example shows how to convert a presentation into TIFF document with default options.

``` cpp
// The path to the documents directory.
String dataDir = GetDataPath();

// Instantiate a Presentation object that represents a presentation file
auto presentation = System::MakeObject<Presentation>(dataDir + u"DemoFile.pptx");

// Saving the presentation to TIFF document
presentation->Save(dataDir + u"Tiffoutput_out.tiff", SaveFormat::Tiff);
```



## **Convert Powerpoint to TIFF with custom size**

The following example shows how to convert a presentation into TIFF document with customized image size using [TiffOptions](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options) class. 

``` cpp
// The path to the documents directory.
System::String dataDir = GetDataPath();

// Instantiate a Presentation object that represents a Presentation file
auto pres = System::MakeObject<Presentation>(dataDir + u"Convert_Tiff_Custom.pptx");
    
// Instantiate the TiffOptions class
auto opts = System::MakeObject<TiffOptions>();

// Setting compression type
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

// Setting image DPI
opts->set_DpiX(200);
opts->set_DpiY(100);

// Set Image Size
opts->set_ImageSize(System::Drawing::Size(1728, 1078));

// Save the presentation to TIFF with specified image size
pres->Save(dataDir + u"TiffWithCustomSize_out.tiff", SaveFormat::Tiff, opts);
```




## **Convert Powerpoint to TIFF with custom Image Pixel Format**
The following example shows how to convert a presentation into TIFF document with customized Image Pixel Format using [TiffOptions](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options) class. You can also include comments in generated HTML by using [TiffOptions](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options) class and **INotesCommentsLayoutingOptions** interface.

``` cpp
// The path to the documents directory.
System::String dataDir = GetDataPath();

// Instantiate a Presentation object that represents a Presentation file
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

// Save the presentation to TIFF with specified image size
presentation->Save(dataDir + u"Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat::Tiff, options);
```