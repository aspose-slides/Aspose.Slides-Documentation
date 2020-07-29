---
title: Converting Presentation to TIFF
type: docs
weight: 40
url: /cpp/converting-presentation-to-tiff/
---

## **Converting Presentation to TIFF**
TIFF format is known by its flexibility to accommodate multipage images and data. Keeping in view the importance and popularity of TIFF format, Aspose.Slides for C++ provides the support for converting presentations into TIFF document.
### **Converting with default size**
The [Save](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/#a8e91317bad4f6f5c8a999686260a9162) method exposed by [Presentation](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/) class class can be called by developers to convert the whole presentation into TIFF document. Further, [TiffOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.tiff_options/) class exposes **ImageSize** property enabling the developer to define the size of the image if required. The following example shows how to convert a presentation into TIFF document with default options.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-PresentationToTIFFWithDefaultSize-PresentationToTIFFWithDefaultSize.cpp" >}}


### **Converting with custom size**
The following example shows how to convert a presentation into TIFF document with customized image size using [TiffOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.tiff_options/) class. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Presentations-Conversion-ConvertWithCustomSize-ConvertWithCustomSize.cs" >}}


### **Converting with custom Image Pixel Format**
The following example shows how to convert a presentation into TIFF document with customized Image Pixel Format using [TiffOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.tiff_options/) class. You can also include comments in generated TIFF by using [TiffOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.tiff_options/) class.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-PresentationToTIFFWithCustomImagePixelFormat-PresentationToTIFFWithCustomImagePixelFormat.cpp" >}}
