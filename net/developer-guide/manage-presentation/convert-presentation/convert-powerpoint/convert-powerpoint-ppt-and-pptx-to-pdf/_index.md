---
title: Convert PowerPoint PPT and PPTX to PDF
type: docs
weight: 40
url: /net/convert-powerpoint-ppt-and-pptx-to-pdf/
keywords: "PPT and PPTX to PDF"
description: "Convert PPT to PDF and PPTX to PDF. Convert PowerPoint to PDF document with Aspose.Slides."
---

# **How to convert PPT to PDF online**
You can use our [free PowerPoint Online Converter](https://products.aspose.app/slides/conversion/) to convert PPT or PPTX files to PDF quickly.

Go through these steps:

1. Go to our [PowerPoint Online Converter page](https://products.aspose.app/slides/conversion/). 

2. Click **Drop or upload your files**. 

3. Select the PPT or PPTX file you want to convert on your computer. 

4. Click **Convert**. 

5. Click **DOWNLOAD NOW**. 

   Your browser now saves the converted file. 

## PowerPoint to PDF Conversion in .NET

[**Aspose.Slides** ](https://products.aspose.com/slides/net)allows you to convert files in PowerPoint PPT, PPTX, and OpenOffice ODP formats to PDF. To convert a presentation to PDF, simply pass the file name and save format to the [**Presentation.Save**](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method. The [**Presentation**](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class exposes the [**Save**](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method that can be called to convert the whole PPT, PPTX, or ODP presentation into a PDF document. The [**PdfOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/pdfoptions) class provides options for creating the PDF such as **JpegQuality**, **TextCompression**, **Compliance**, and others. These options can be used to get the desired standard in a PDF.

**Note**: Aspose.Slides for .NET directly writes the information about API and Version Number in output documents. For example, upon rendering Document to PDF, Aspose.Slides for .NET populates the Application field with the value 'Aspose.Slides' and the PDF Producer field with a value, e.g. 'Aspose.Slides v 17.10'. Please note that you cannot instruct Aspose.Slides for .NET to change or remove this information from output Documents.

{{% alert color="primary" %}} 

Try **free online demo apps** to test [**PPT to PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), [**PPTX to PDF**](https://products.aspose.app/slides/conversion/pptx-to-pdf), [**ODP to PDF** ](https://products.aspose.app/slides/conversion/odp-to-pdf)feature by Aspose.

{{% /alert %}} 

Aspose.Slides for .NET exports the presentation documents to PDF and makes it similar to the original presentation document. Aspose.Slides can render most elements in a presentation while converting it to PDF:

- Images, Text Boxes and other Shapes
- Text and Formatting
- Paragraphs and Formatting
- Hyperlinks
- Headers and Footers
- Bullets
- Tables

Furthermore, you can customize the presentation to PDF export with different options explained in this topic.

With Aspose.Slides, you can use these options for PPT(X) to PDF conversion in a flexible way:

- Convert the whole PPT(X) presentation to PDF.
- Convert separate slides of PPT(X) to PDF.
- Convert PPT(X) to PDF with default settings. To help you simplify PPT(X) to PDF conversion process, Aspose.Slides chooses the optimal conversion settings required to define them all.
- Convert PPT(X) to PDF with custom settings. Change PDF file standard, set text compression level, choose the quality of JPEG images inside PDF document.
- Convert PPT(X) to PDF with hidden slides included.
- Set access permissions of the resulting PDF document. For example, you may convert PPT(X) to a password-protected PDF. This way, you can easily protect the resulting PDF document to prevent people from copying and editing it. 
- Convert PPT(X) to PDF with speaker notes included. Additionally, you can define how speaker notes must be rendered into PDF.
- Convert PPT(X) to PDF with comments included. You can also define comments rendering rules.
- Export presentation metafiles to PNGs, while converting PPT(X) to PDF.
- Choose font settings of PPT(X) to PDF conversion process. The API allows you to save the original fonts of the presentation during conversion. Otherwise, you can opt to define substitution fonts and rules. 



Aspose.Slides allows you to convert PPT(X) presentations to PDF document without loss in quality:

|<p>**Input PPT:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-pdf_1.png)**</p><p>** </p><p>** </p>|<p>**Output PDF:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-pdf_2.png)**</p>|
| :- | :- |

## **Convert PowerPoint to PDF with Default Options**
The following example shows you how to convert a PowerPoint PPT, PPTX, and OpenOffice ODP document into a PDF document using the default options. The default options create a PDF document at the maximum quality levels



{{< gist "aspose-com-gists" "d80998365f9fbb69f99b04f642b6caa6" "convert-ppt-to-pdf.cs" >}}


## **Convert PowerPoint to PDF with Custom Options**
The following example shows you how to convert PowerPoint PPT, PPTX and OpenOffice ODP into a PDF document with customized options provided by the [**PdfOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/pdfoptions) class. It sets the JPEG quality, saves metafiles to PNG, sets text compression level with [**PdfTextCompression** ](https://apireference.aspose.com/net/slides/aspose.slides.export/pdftextcompression)enumeration and sets PDF standard.



{{< gist "aspose-com-gists" "d80998365f9fbb69f99b04f642b6caa6" "convert-pptx-to-pdf-custom-options.cs" >}}
## **Convert PowerPoint to PDF with Hidden Slides Included**
The following example shows how to convert a PowerPoint PPT, PPTX and OpenOffice ODP file into a PDF document with hidden slides included as provided by the [**PdfOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/pdfoptions) class. You can also include comments in generated HTML by using [**PdfOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/pdfoptions) class. 
It sets the ShowHiddenSlides property to generate PDF with hidden slides. 
Property **ShowHiddenSlides** has been added to **IHtmlOptions**, **IPdfOption**, **ISwfOptions**, 
**ITiffOptions**, **IXpsOption** interfaces and **HtmlOptions**, 
**PdfOption**, **SwfOptions**, **TiffOptions**, **XpsOption** classes. 
This property specifies whether the exported document should include hidden slides or not. 
Default value is **"false"**.



{{< gist "aspose-com-gists" "d80998365f9fbb69f99b04f642b6caa6" "convert-pptx-to-pdf-hidden-slides.cs" >}}


## **Convert PowerPoint to Password Protected PDF**
The following example shows you how to convert a presentation to a password-protected PDF document with customized options provided by the [**PdfOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/pdfoptions) class.



{{< gist "aspose-com-gists" "d80998365f9fbb69f99b04f642b6caa6" "convert-ppt-to-pdf-password-protected.cs" >}}


## **Convert Selected Slides of PowerPoint to PDF**
The following example shows you how to convert a specific presentation slide to a PDF document with custom options.

{{< gist "aspose-com-gists" "d80998365f9fbb69f99b04f642b6caa6" "convert-pptx-to-pdf-selected-slides.cs" >}}


## **Convert PowerPoint to PDF with Custom Slide Size**
The following example shows you how to convert a presentation to a PDF notes document with custom slide size. Here, each inch equals 72.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Conversion-ConvertSlidesToPdfNotes-ConvertSlidesToPdfNotes.cs" >}}


## **Convert PowerPoint to PDF in Notes Slide View**
The [**Save**](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method exposed by [**Presentation**](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class can be used to convert the whole presentation in Notes Slide view to PDF. Saving a Microsoft PowerPoint presentation to PDF notes with Aspose.Slides for .NET is a two-line process. First, you open the presentation. Second, you save it out to PDF notes. The code snippet below updates the sample presentation to PDF in Notes Slide view.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Conversion-ConvertNotesSlideViewToPDF-ConvertNotesSlideViewToPDF.cs" >}}

