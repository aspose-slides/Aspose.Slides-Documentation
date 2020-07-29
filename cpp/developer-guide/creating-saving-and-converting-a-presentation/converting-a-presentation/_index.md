---
title: Converting a Presentation
type: docs
weight: 10
url: /cpp/converting-a-presentation/
---

## **Converting PPT to PPTX**
To convert a PPT Presentation to PPTX simply pass the file name and save format to the [Save](http://www.aspose.com/api/net/slides/aspose.slides/presentation/methods/save/index) method of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class. The code sample below converts a Presentation from PPT to PPTX using default options. For more information please proceed to this documentation [link](/slides/cpp/different-file-formats-and-conversions/#differentfileformatsandconversions-ppttopptxconversion).



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-PPTtoPPTX-PPTtoPPTX.cpp" >}}


## **Support of SVG Responsive Property**
New get_SvgResponsiveLayout() and set_SvgResponsiveLayout() methods have been added to IHtmlOptions and HtmlOptions classes. The code sample below shows how to export a presentation to HTML with the responsive layout:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ExportToHTMLWithResponsiveLayout-ExportToHTMLWithResponsiveLayout.cpp" >}}
## **Converting Presentation with Notes**
Aspose.Slides for C++ provides Conversion to TIFF and Conversion to PDF in order to convert slides with notes.

- Conversion to TIFF
- Conversion to PDF
### **Converting the Notes Slide View to TIFF**
TIFF is one of several widely used image formats that Aspose.Slides for C++ supports for converting a presentation with notes to images. You can also generate slide thumbnails in the Notes Slide view. The [Save](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/#a18df81989014383671668617295f4297) method exposed by Presentation class can be used to convert the whole presentation in Notes Slide view to TIFF. Saving a Microsoft PowerPoint presentation to TIFF notes with Aspose.Slides for C++ is a two-line process. You simply open the presentation and save it out to TIFF notes. You can also generate a slide thumbnail in Notes Slide view for individual slides. The code snippets below update the sample presentation to TIFF images in Notes Slide view, as shown below:



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ConversionToTIFFNotes-ConversionToTIFFNotes.cpp" >}}


### **Converting the Notes Slide View to PDF**
The Save method exposed by Presentation class can be used to convert the whole presentation in Notes Slide view to PDF. Saving a Microsoft PowerPoint presentation to PDF notes with Aspose.Slides for C++ is a two-line process. You simply open the presentation and save it out to PDF notes. The code snippets below update the sample presentation to PDF in Notes Slide view:



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Presentations-Conversion-ConvertSlidesToPdfNotes-ConvertSlidesToPdfNotes.cs" >}}


## **Converting Presentation to XPS**
The [Save](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/#a18df81989014383671668617295f4297) method exposed by Presentation class can be used to convert the whole presentation into XPS document. Further, [XPSOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.xps_options/) class exposes [SaveMetafileAsPng](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.xps_options/#ae31b0910bb95d56b4d85691573e05433) property that can be set to true or false as per requirement.
### **Converting without XpsOptions**
The following example shows how to convert a presentation into XPS document without using options provided by [XPSOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.xps_options/).

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConvertWithoutXpsOptions-ConvertWithoutXpsOptions.cpp" >}}


### **Converting with XpsOptions**
The following example shows how to convert a presentation into XPS document using options provided by [XPSOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.xps_options/).

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConvertWithXpsOptions-ConvertWithXpsOptions.cpp" >}}


## **Converting ODP PPT to PPTX**
Aspose.Slides for C++ offers Presentation class that represents a presentation file. Presentation class can now also access ODP through Presentation constructor when the object is instantiated. The following example shows how to convert a ODP Presentation into PPTX Presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessOpenDoc-AccessOpenDoc.cpp" >}}


## **Converting Presentation to SWF**
The [Save](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/#a18df81989014383671668617295f4297) method exposed by Presentation class can be used to convert the whole presentation into SWF document.  You can also include comments in generated SWF by using [SWFOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.swf_options/) class. The following example shows how to convert a presentation into SWF document by using options provided by [SWFOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.swf_options/) class.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConvertToSWF-ConvertToSWF.cpp" >}}
