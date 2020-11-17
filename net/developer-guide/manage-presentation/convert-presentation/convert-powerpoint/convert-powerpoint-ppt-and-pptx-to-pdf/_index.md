---
title: Convert PowerPoint PPT and PPTX to PDF
type: docs
weight: 40
url: /net/convert-powerpoint-ppt-and-pptx-to-pdf/
keywords: "PPT and PPTX to PDF"
description: "Convert PPT to PDF and PPTX to PDF. Convert PowerPoint to PDF document with Aspose.Slides."
---

## **About PowerPoint to PDF Conversion**
[**Aspose.Slides** ](https://products.aspose.com/slides/net)allows converting PowerPoint PPT, PPTX and OpenOffice ODP formats to PDF. To convert the presentation to PDF simply pass the file name and save format to the [**Presentation.Save**](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method. The [**Presentation**](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class exposes the [**Save**](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method that can be called to convert the whole PPT, PPTX or ODP presentation into a PDF document. The [**PdfOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/pdfoptions) class provides options for creating the PDF such as **JpegQuality**, **TextCompression**, **Compliance** and others. These options can be used to get the desired standard of PDF.

**Note**: Aspose.Slides for .NET directly writes the information about API and Version Number in output documents. For example, upon rendering Document to PDF, Aspose.Slides for .NET populates Application field with value 'Aspose.Slides' and PDF Producer field with a value, e.g 'Aspose.Slides v 17.10'. Please note that you cannot instruct Aspose.Slides for .NET to change or remove this information from output Documents.

{{% alert color="primary" %}} 

Try **free online demo apps** to test [**PPT to PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), [**PPTX to PDF**](https://products.aspose.app/slides/conversion/pptx-to-pdf), [**ODP to PDF** ](https://products.aspose.app/slides/conversion/odp-to-pdf)feature by Aspose.

{{% /alert %}} 

Aspose.Slides for .NET exports the presentation documents to PDF and make it looking similar to the original presentation document. Aspose.Slides supports to render any elements of presentation document while converting to PDF:

- Images, Text Boxes and other Shapes
- Text and Formatting
- Paragraphs and Formatting
- Hyperlinks
- Headers and Footers
- Bullets
- Tables

Furthermore, you can customize the presentation to PDF export with different options explained in this topic.

With Aspose.Slides you are able to set the options of PPT(X) to PDF conversion and change it in a flexible way:

- Convert the whole PPT(X) presentation to PDF.
- Convert separate slides of PPT(X) to PDF.
- Convert PPT(X) to PDF with default settings. To simplify PPT(X) to PDF conversion process for you, Aspose.Slides choose the optimal conversion settings that you are to required to define them all.
- Convert PPT(X) to PDF with custom settings. Change PDF file standard, set text compression level, choose the quality of JPEG images inside PDF document.
- Convert PPT(X) to PDF with hidden slides included.
- Set access permissions of the resulting PDF document. For example, you may convert PPT(X) to a password protected PDF. This way it's easy to protect the resulting PDF document from copying and editing.
- Convert PPT(X) to PDF with speaker notes included. Additionally, it's possible to define how speaker notes should be rendered into PDF.
- Convert PPT(X) to PDF with comments included. It's also possible to define comments rendering rules.
- Export presentation metafiles to PNGs, while converting PPT(X) to PDF.
- Choose font settings of PPT(X) to PDF conversion process. The API allows to save the original fonts of the presentation during conversion. Otherwise, it's possible to define the substitution fonts and rules. 



Aspose.Slides allows to convert PPT(X) presentation to PDF document with a maximum quality:

|<p>**Input PPT:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-pdf_1.png)**</p><p>** </p><p>** </p>|<p>**Output PDF:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-pdf_2.png)**</p>|
| :- | :- |

## **Convert PowerPoint to PDF with Default Options**
The following example shows how to convert PowerPoint PPT, PPTX and OpenOffice ODP document into a PDF document using the default options. The default options create a PDF document of maximum quality.



{{< gist "aspose-com-gists" "d80998365f9fbb69f99b04f642b6caa6" "convert-ppt-to-pdf.cs" >}}


## **Convert PowerPoint to PDF with Custom Options**
The following example shows how to convert PowerPoint PPT, PPTX and OpenOffice ODP into a PDF document with customized options as provided by the [**PdfOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/pdfoptions) class. It sets the JPEG quality, saves metafiles to PNG, sets text compression level with [**PdfTextCompression** ](https://apireference.aspose.com/net/slides/aspose.slides.export/pdftextcompression)enumeration and sets PDF standard.



{{< gist "aspose-com-gists" "d80998365f9fbb69f99b04f642b6caa6" "convert-pptx-to-pdf-custom-options.cs" >}}
## **Convert PowerPoint to PDF with Hidden Slides Included**
The following example shows how to convert PowerPoint PPT, PPTX and OpenOffice ODP into a PDF document with hidden slides included as provided by the [**PdfOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/pdfoptions) class. You can also include comments in generated HTML by using [**PdfOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/pdfoptions) class. 
It sets the ShowHiddenSlides property to generated PDF with hidden slides. 
Property **ShowHiddenSlides** has been added to **IHtmlOptions**, **IPdfOption**, **ISwfOptions**, 
**ITiffOptions**, **IXpsOption** interfaces and **HtmlOptions**, 
**PdfOption**, **SwfOptions**, **TiffOptions**, **XpsOption** classes. 
This property specifies whether the exported document should include hidden slides or not. 
Default value is **"false"**.



{{< gist "aspose-com-gists" "d80998365f9fbb69f99b04f642b6caa6" "convert-pptx-to-pdf-hidden-slides.cs" >}}


## **Convert PowerPoint to Password Protected PDF**
The following example shows how to convert a presentation to a password protected PDF document with customized options as provided by the [**PdfOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/pdfoptions) class.



{{< gist "aspose-com-gists" "d80998365f9fbb69f99b04f642b6caa6" "convert-ppt-to-pdf-password-protected.cs" >}}


## **Convert Selected Slides of PowerPoint to PDF**
The following example shows how to convert a specific presentation slide to a PDF document with custom options.

{{< gist "aspose-com-gists" "d80998365f9fbb69f99b04f642b6caa6" "convert-pptx-to-pdf-selected-slides.cs" >}}


## **Convert PowerPoint to PDF with Custom Slide Size**
The following example shows how to convert a presentation to a PDF notes document with custom slide size. Where each inch equals 72.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Conversion-ConvertSlidesToPdfNotes-ConvertSlidesToPdfNotes.cs" >}}


## **Convert PowerPoint to PDF in Notes Slide View**
The [**Save**](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method exposed by [**Presentation**](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class can be used to convert the whole presentation in Notes Slide view to PDF. Saving a Microsoft PowerPoint presentation to PDF notes with Aspose.Slides for .NET is a two-line process. You simply open the presentation and save it out to PDF notes. The code snippets below update the sample presentation to PDF in Notes Slide view.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Conversion-ConvertNotesSlideViewToPDF-ConvertNotesSlideViewToPDF.cs" >}}
