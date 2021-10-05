---
title: Convert PowerPoint to TIFF
type: docs
weight: 90
url: /net/convert-powerpoint-to-tiff
keywords: "Convert PowerPoint Presentation, PowerPoint to TIFF, PPT to TIFF, PPTX to TIFF, C#, Csharp, .NET, Aspose.Slides"
description: "Convert PowerPoint presentation to TIFF in C# or .NET."
---



TIFF format is known by its flexibility to accommodate multipage images and data. Keeping in view the importance and popularity of TIFF format, Aspose.Slides for .NET provides the support for converting presentations into TIFF document.

{{% alert  title="Tip" color="primary" %}} 

You may want to check out Aspose [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}} 

## **Convert PowerPoint to TIFF with default size**
The [Save](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method exposed by [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class can be called by developers to convert the whole presentation into TIFF document. Further, [TiffOptions](https://apireference.aspose.com/net/slides/aspose.slides.export/tiffoptions) class exposes **ImageSize** property enabling the developer to define the size of the image if required. The following example shows how to convert a presentation into TIFF document with default options.

```c#
// Instantiate a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    // Saving the presentation to TIFF document
    presentation.Save("Tiffoutput_out.tiff", SaveFormat.Tiff);
}
```



## **Convert PowerPoint to TIFF with custom size**

The following example shows how to convert a presentation into TIFF document with customized image size using [TiffOptions](https://apireference.aspose.com/net/slides/aspose.slides.export/tiffoptions) class. 

```c#
// Instantiate a Presentation object that represents a Presentation file
using (Presentation pres = new Presentation("Convert_Tiff_Custom.pptx"))
{
    // Instantiate the TiffOptions class
    TiffOptions opts = new TiffOptions();

    // Setting compression type
    opts.CompressionType = TiffCompressionTypes.Default;

    INotesCommentsLayoutingOptions notesOptions = opts.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;
    // Compression Types

    // Default - Specifies the default compression scheme (LZW).
    // None - Specifies no compression.
    // CCITT3
    // CCITT4
    // LZW
    // RLE

    // Depth depends on the compression type and cannot be set manually.
    // Resolution unit  is always equal to “2” (dots per inch)

    // Setting image DPI
    opts.DpiX = 200;
    opts.DpiY = 100;

    // Set Image Size
    opts.ImageSize = new Size(1728, 1078);

    // Save the presentation to TIFF with specified image size
    pres.Save("TiffWithCustomSize_out.tiff", SaveFormat.Tiff, opts);
}
```




## **Convert PowerPoint to TIFF with custom Image Pixel Format**
The following example shows how to convert a presentation into TIFF document with customized Image Pixel Format using [TiffOptions](https://apireference.aspose.com/net/slides/aspose.slides.export/tiffoptions) class. You can also include comments in generated HTML by using [TiffOptions](https://apireference.aspose.com/net/slides/aspose.slides.export/tiffoptions) class and **INotesCommentsLayoutingOptions** interface.

```c#
// Instantiate a Presentation object that represents a Presentation file
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    TiffOptions options = new TiffOptions();
   
    options.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat contains the following values (as could be seen from documentation):
    Format1bppIndexed; // 1 bits per pixel, indexed.
    Format4bppIndexed; // 4 bits per pixel, indexed.
    Format8bppIndexed; // 8 bits per pixel, indexed.
    Format24bppRgb; // 24 bits per pixel, RGB.
    Format32bppArgb; // 32 bits per pixel, ARGB.
    */

    // Save the presentation to TIFF with specified image size
    presentation.Save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat.Tiff, options);
}
```

