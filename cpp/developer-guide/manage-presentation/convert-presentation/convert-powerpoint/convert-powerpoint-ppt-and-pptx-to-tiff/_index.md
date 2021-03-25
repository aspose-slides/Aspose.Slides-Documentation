---
title: Convert PowerPoint PPT(X) to TIFF
type: docs
weight: 90
url: /cpp/convert-powerpoint-ppt-and-pptx-to-tiff/
keywords: "PowerPoint PPT and PPTX to TIFF"
description: "Convert PowerPoint PPT and PPTX to TIFF in C++"
---

## **Convert PPT(X) to TIFF**
TIFF format is known by its flexibility to accommodate multipage images and data. Keeping in view the importance and popularity of TIFF format, Aspose.Slides for C++ provides the support for converting presentations into TIFF document.

## **Convert PPT(X) with Default Size**
The [Save](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/#a8e91317bad4f6f5c8a999686260a9162) method exposed by [Presentation](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/) class class can be called by developers to convert the whole presentation into TIFF document. Further, [TiffOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.tiff_options/) class exposes **ImageSize** property enabling the developer to define the size of the image if required. The following example shows how to convert a presentation into TIFF document with default options.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-PresentationToTIFFWithDefaultSize-PresentationToTIFFWithDefaultSize.cpp" >}}


## **Convert PPT(X) to TIFF with Custom Size**
The following example shows how to convert a presentation into TIFF document with customized image size using [TiffOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.tiff_options/) class. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Presentations-Conversion-ConvertWithCustomSize-ConvertWithCustomSize.cs" >}}


## **Convert PPT(X) to TIFF with Custom Image Pixel Format**
The following example shows how to convert a presentation into TIFF document with customized Image Pixel Format using [TiffOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.tiff_options/) class. You can also include comments in generated TIFF by using [TiffOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.tiff_options/) class.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-PresentationToTIFFWithCustomImagePixelFormat-PresentationToTIFFWithCustomImagePixelFormat.cpp" >}}

## **Convert PPT(X) to TIFF with Notes Slide View**
TIFF is one of several widely used image formats that Aspose.Slides for C++ supports for converting a presentation with notes to images. You can also generate slide thumbnails in the Notes Slide view. The [Save](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/#a18df81989014383671668617295f4297) method exposed by Presentation class can be used to convert the whole presentation in Notes Slide view to TIFF. Saving a Microsoft PowerPoint presentation to TIFF notes with Aspose.Slides for C++ is a two-line process. You simply open the presentation and save it out to TIFF notes. You can also generate a slide thumbnail in Notes Slide view for individual slides. The code snippets below update the sample presentation to TIFF images in Notes Slide view, as shown below:



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ConversionToTIFFNotes-ConversionToTIFFNotes.cpp" >}}

