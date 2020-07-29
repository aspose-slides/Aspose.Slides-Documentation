---
title: Converting Presentation to PDF
type: docs
weight: 90
url: /java/converting-presentation-to-pdf/
---


## **Converting Presentation to PDF**
{{% alert color="primary" %}} 

Aspose.Slides for Java directly writes the information about API and Version Number in output documents. For example, upon rendering Document to [PDF](https://wiki.fileformat.com/view/pdf/), Aspose.Slides for Java populates the Application field with value 'Aspose.Slides' and PDF Producer field with a value, e.g 'Aspose.Slides v 17.10'.

Please note that you cannot instruct Aspose.Slides for Java to change or remove this information from output Documents.

{{% /alert %}} {{% alert color="primary" %}} 

[**PDF**](https://wiki.fileformat.com/view/pdf/) documents are widely used as a standard format of exchanging documents between organizations, government sectors and individuals. It is a popular format so developers are often asked to convert Microsoft PowerPoint presentation files to PDF documents. Realizing this possible requirement, Aspose.Slides for Java supports converting presentations to PDF documents without using any other component. This topic illustrates how this conversion can be done.

{{% /alert %}} 

Aspose.Slides for Java offers the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class that represents a presentation file. The Presentation class exposes the **Save** method that can be called to convert the whole presentation into a PDF document. The [PdfOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions) class provides options for creating the PDF such as [**setJpegQuality**](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions#setJpegQuality-byte-), [**setTextCompression**](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions#setTextCompression-int-), [**setCompliance**](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions#setCompliance-int-) and others. These options can be used to get the desired standard of PDF.
### **Using the Default Options**
The following example shows how to convert a presentation into a [**PDF**](https://wiki.fileformat.com/view/pdf/) document using the default options. The default options create a PDF document of maximum quality.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToPDFUsingDefaultOptions-ConvertingPresentationToPDFUsingDefaultOptions.java" >}}
### **Using Custom Options**
The following example shows how to convert a presentation into a [**PDF**](https://wiki.fileformat.com/view/pdf/) document with customized options as provided by the [**PdfOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions) class. It sets the [JPEG quality](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions#setJpegQuality-byte-), saves metafiles to [PNG](https://wiki.fileformat.com/image/png/), sets text compression level and PDF standard. You can also include comments in generated PDF by using [PdfOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions)** **class and [**INotesCommentsLayoutingOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/INotesCommentsLayoutingOptions) interface.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToPDFUsingCustomOptions-ConvertingPresentationToPDFUsingCustomOptions.java" >}}
### **Including Hidden Slides**
The following example shows how to convert a presentation into a [PDF ](https://wiki.fileformat.com/view/pdf/)document with hidden slides included as provided by the [**PdfOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions) class. It sets the [**setShowHiddenSlides(boolean)**](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions#setShowHiddenSlides-boolean-) method to generate PDF with hidden slides.

Method [**setShowHiddenSlides(boolean)**](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions#setShowHiddenSlides-boolean-) has been added to [**IHtmlOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/IHtmlOptions), [**IPdfOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/IPdfOptions), [**ISwfOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/ISwfOptions), [**ITiffOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/ITiffOptions)**,** [**IXpsOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/IXpsOptions) interfaces and [**HtmlOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/HtmlOptions), [**PdfOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions), [**SwfOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/SwfOptions), [**TiffOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/TiffOptions), [**XpsOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/XpsOptions) classes.

This method specifies whether the exported document should include hidden slides or not. The default value is **false**.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToPDFIncludingHiddenSlides-ConvertingPresentationToPDFIncludingHiddenSlides.java" >}}
### **Password Protected PDF**
The following example shows how to convert a presentation to a password protected [**PDF** ](https://wiki.fileformat.com/view/pdf/)document with customized options as provided by the [PdfOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions) class.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToPasswordProtectedPDF-ConvertingPresentationToPasswordProtectedPDF.java" >}}
### **Converting a Specific Slide to PDF**
The following example shows how to convert a specific slide in a presentation to a [**PDF** ](https://wiki.fileformat.com/view/pdf/)document with custom options.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingASpecificSlideToPDF-ConvertingASpecificSlideToPDF.java" >}}
### **Save to PDF notes with custom slide size**
The following example shows how to convert a presentation to a [**PDF** ](https://wiki.fileformat.com/view/pdf/)notes document with custom slide size. Where each inch equals 72 pixels.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-SaveToPDFNotesWithCustomSlideSize-SaveToPDFNotesWithCustomSlideSize.java" >}}
## **Set PDF Access Permissions**
You can set access permissions to a [**PDF**](https://wiki.fileformat.com/view/pdf/) document using Aspose.Slides for Java. For this purpose, [**setAccessPermissions()**](https://apireference.aspose.com/java/slides/com.aspose.slides/IPdfOptions#setAccessPermissions-int-) method has been added to a [**PdfOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions)** **class. The possible values which allow you to restrict access rights to a PDF document are defined in the [**PdfAccessPermissions**](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfAccessPermissions) class.

The following code demonstrates how you can set access permissions to a PDF document only for printing.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Opening-SetAccessPermissionsToPDF-SetAccessPermissionsToPDF.java" >}}
