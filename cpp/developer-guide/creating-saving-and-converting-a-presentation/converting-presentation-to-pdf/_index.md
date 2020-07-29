---
title: Converting Presentation to PDF
type: docs
weight: 30
url: /cpp/converting-presentation-to-pdf/
---

{{% alert color="primary" %}} 

Aspose.Slides for C++ directly writes the information about API and Version Number in output documents. For example, upon rendering Document to PDF, Aspose.Slides for C++ populates Application field with value 'Aspose.Slides' and PDF Producer field with value, e.g 'Aspose.Slides v 17.10'.

Please note that you cannot instruct Aspose.Slides for C++ to change or remove this information from output Documents.

{{% /alert %}} 
## **Converting Presentation to PDF**
To convert a Presentation to PDF in C++ simply pass the file name and save format to the [Save](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/#a8e91317bad4f6f5c8a999686260a9162) method. The [Presentation](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/) class exposes the [Save](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/#a8e91317bad4f6f5c8a999686260a9162) method that can be called to convert the whole presentation into a PDF document. The [PdfOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.pdf_options/) class provides options for creating the PDF such as **JpegQuality**, **TextCompression**, **Compliance** and others. These options can be used to get the desired standard of PDF.
### **Converting using Default Options**
The following example shows how to convert a presentation into a PDF document using the default options. The default options create a PDF document of maximum quality.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConvertToPDF-ConvertToPDF.cpp" >}}


### **Converting using Custom Options**
The following example shows how to convert a presentation into a PDF document with customized options as provided by the [PdfOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.pdf_options/) class. It sets the JPEG quality, saves metafiles to PNG, sets text [compression level](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.pdf_options/#ad9e252dcb09f75e2b9847e4d575571e9) and PDF standard.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomOptionsPDFConversion-CustomOptionsPDFConversion.cpp" >}}


### **Converting with Hidden Slides Included**
The following example shows how to convert a presentation into a PDF document with hidden slides included as provided by the [PdfOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.pdf_options/) class. You can also include comments in generated PDF by using [PdfOptions](http://www.aspose.com/api/net/slides/aspose.slides.export/pdfoptions) class. It sets the ShowHiddenSlides property to generated PDF with hidden slides. Property **ShowHiddenSlides** has been added to **IHtmlOptions**, **IPdfOption**, **ISwfOptions**, **ITiffOptions**, **IXpsOption** interfaces and **HtmlOptions**, **PdfOption**, **SwfOptions**, **TiffOptions, XpsOption** classes. This property specifies whether the exported document should include hidden slides or not. Default value is **"false"**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConvertToPDFWithHiddenSlides-ConvertToPDFWithHiddenSlides.cpp" >}}


### **Converting to Password Protected PDF**
The following example shows how to convert a presentation to a password protected PDF document with customized options as provided by the [PdfOptions](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.pdf_options/) class.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ConvertPresentationToPasswordProtectedPDF-ConvertPresentationToPasswordProtectedPDF.cpp" >}}


### **Converting Specific Slide**
The following example shows how to convert a specific presentation slide to a PDF document with custom options.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Presentations-Conversion-ConvertSpecificSlideToPDF-ConvertSpecificSlideToPDF.cs" >}}


### **Converting the custom slide size**
The following example shows how to convert a presentation to a PDF notes document with custom slide size. Where each inch equals 72.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetSlideSizeScale-SetSlideSizeScale.cpp" >}}


### **Converting the Notes Slide View**
The [Save](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/#a8e91317bad4f6f5c8a999686260a9162) method exposed by [Presentation](https://apireference.aspose.com/cpp/slides/class/aspose.slides.presentation/) class can be used to convert the whole presentation in Notes Slide view to PDF. Saving a Microsoft PowerPoint presentation to PDF notes with Aspose.Slides for C++ is a two-line process. You simply open the presentation and save it out to PDF notes. The code snippets below update the sample presentation to PDF in Notes Slide view.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ConvertNotesSlideViewToPDF-ConvertNotesSlideViewToPDF.cpp" >}}
## **Set PDF Access Permissions**
You can set access permissions to a [**PDF**](https://wiki.fileformat.com/view/pdf/) document using Aspose.Slides for C++. For this purpose, [**set_AccessPermissions()**](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.i_pdf_options/#ac2b89307d944084a00853ff3dfa070e3) method has been added to a [**PdfOptions**](https://apireference.aspose.com/cpp/slides/class/aspose.slides.export.pdf_options/)** **class. The possible values which allow you to restrict access rights to a PDF document are defined in the [**PdfAccessPermissions**](https://apireference.aspose.com/cpp/slides/namespace/aspose.slides.export/#a8a80eed4177a9fe0cefe91999e4ec353) class.

The following code demonstrates how you can set access permissions to a PDF document only for printing.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetAccessPermissionsToPDF-SetAccessPermissionsToPDF.cpp" >}}
