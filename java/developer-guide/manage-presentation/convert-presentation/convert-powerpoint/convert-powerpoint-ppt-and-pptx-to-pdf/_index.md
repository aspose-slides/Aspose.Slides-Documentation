---
title: Convert PowerPoint PPT(X) to PDF
type: docs
weight: 40
url: /java/convert-powerpoint-ppt-and-pptx-to-pdf/
keywords: "PPT and PPTX to PDF in Java"
description: "Convert PPT to PDF and PPTX to PDF. Convert PowerPoint to PDF document in Java."
---


## **Convert PPT(X) to PDF**
{{% alert color="primary" %}} 

Aspose.Slides for Java directly writes the information about API and Version Number in output documents. For example, upon rendering Document to [PDF](https://wiki.fileformat.com/view/pdf/), Aspose.Slides for Java populates the Application field with value 'Aspose.Slides' and PDF Producer field with value, e.g 'Aspose.Slides v 17.10'.

Please note that you cannot instruct Aspose.Slides for Java to change or remove this information from output Documents.

{{% /alert %}} {{% alert color="primary" %}} 

[PDF](https://wiki.fileformat.com/view/pdf/) documents are widely used as a standard format of exchanging documents between organizations, government sectors and individuals. It's a popular format so developers are often asked to convert Microsoft PowerPoint presentation files to PDF documents. Realizing this possible requirement, Aspose.Slides for Java supports converting presentations to PDF documents without using any other component. This topic illustrates how this conversion can be done.

{{% /alert %}} 

Aspose.Slides for Java offers the 
[Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class that represents a presentation file. The [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class exposes the **Save** method that can be called to convert the whole presentation into a PDF document. The [PdfOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions) class provides options for creating the PDF such as **JpegQuality**, **TextCompression**, **Compliance** and others. These options can be used to get the desired standard of PDF.

## **Convert PPT(X) to PDF using Default Options**
The following example shows how to convert a presentation into a PDF document using the default options. The default options create a PDF document of maximum quality.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToPDFUsingDefaultOptions-ConvertingPresentationToPDFUsingDefaultOptions.java" >}}

## **Convert PPT(X) to PDF using Custom Options**
The following example shows how to convert a presentation into a PDF document with customized options as provided by the [PdfOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions) class. It sets the JPEG quality, saves metafiles to PNG, sets text compression level and PDF standard. You can also include comments in generated PDF by using [PdfOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions)** **class and [**INotesCommentsLayoutingOptions** ](https://apireference.aspose.com/java/slides/com.aspose.slides/INotesCommentsLayoutingOptions) interface.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToPDFUsingCustomOptions-ConvertingPresentationToPDFUsingCustomOptions.java" >}}

## **Convert PPT(X) to PDF with Hidden Slides**
The following example shows how to convert a presentation into a PDF document with hidden slides included as provided by the [PdfOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions) class. It sets the [setShowHiddenSlides(boolean)](https://apireference.aspose.com/java/slides/com.aspose.slides/IPdfOptions#setShowHiddenSlides-boolean-) method to generate PDF with hidden slides.

Method [setShowHiddenSlides(boolean)](https://apireference.aspose.com/java/slides/com.aspose.slides/IPdfOptions#setShowHiddenSlides-boolean-) has been added to [IHtmlOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/ihtmloptions), [IPdfOption](https://apireference.aspose.com/java/slides/com.aspose.slides/ipdfoptions), [ISwfOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/iswfoptions), [ITiffOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/itiffoptions), [IXpsOption](https://apireference.aspose.com/java/slides/com.aspose.slides/ixpsoptions) interfaces and [HtmlOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/htmloptions), [PdfOption](https://apireference.aspose.com/java/slides/com.aspose.slides/pdfoptions), [SwfOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/swfoptions), [TiffOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/tiffoptions), [XpsOption](https://apireference.aspose.com/java/slides/com.aspose.slides/xpsoptions) classes.

This method specifies whether the exported document should include hidden slides or not. Default value is **false**.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToPDFIncludingHiddenSlides-ConvertingPresentationToPDFIncludingHiddenSlides.java" >}}

## **Convert PPT(X) to Password Protected PDF**
The following example shows how to convert a presentation to a password protected PDF document with customized options as provided by the [PdfOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions) class.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Conversion-ConvertingPresentationToPasswordProtectedPDF-ConvertingPresentationToPasswordProtectedPDF.java" >}}

## **Set PDF Access Permissions**
You can set access permissions to a [**PDF**](https://wiki.fileformat.com/view/pdf/) document using Aspose.Slides 
for Java. For this purpose, 
[**setAccessPermissions()**](https://apireference.aspose.com/java/slides/com.aspose.slides/IPdfOptions#setAccessPermissions-int-) method has been added to a [**PdfOptions**](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfOptions)** **class. 
The possible values which allow you to restrict access rights to a PDF document are defined in the 
[**PdfAccessPermissions**](https://apireference.aspose.com/java/slides/com.aspose.slides/PdfAccessPermissions) class.

The following code demonstrates how you can set access permissions to a PDF document only for printing.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Opening-SetAccessPermissionsToPDF-SetAccessPermissionsToPDF.java" >}}
