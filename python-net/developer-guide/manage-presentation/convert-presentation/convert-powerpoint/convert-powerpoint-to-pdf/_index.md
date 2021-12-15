---
title: Convert PowerPoint to PDF
type: docs
weight: 40
url: /python-net/convert-powerpoint-to-pdf/
keywords: "Convert PowerPoint, Presentation, PowerPoint to PDF, PPT to PDF, PPTX to PDF, Save PowerPoint as PDF, PDF/A1a, PDF/A1b, PDF/UA, Python"
description: "Convert PowerPoint Presentation to PDF in Python. Save PowerPoint as PDF with compliance or accessibility standards"
---

## How to Convert PPT to PDF Online
You can use our [free PowerPoint Online Converter](https://products.aspose.app/slides/conversion/) to convert PPT or PPTX files to PDF quickly.

Go through these steps:

1. Go to our [PowerPoint Online Converter page](https://products.aspose.app/slides/conversion/). 

2. Click **Drop or upload your files**. 

3. Select the PPT or PPTX file you want to convert on your computer. 

4. Click **Convert**. 

5. Click **DOWNLOAD NOW**. 

   Your browser now saves the converted file. 
   
   

## PowerPoint to PDF Conversion in Python

[**Aspose.Slides** ](https://products.aspose.com/slides/python-net/)allows you to convert files in PowerPoint PPT, PPTX, and OpenOffice ODP formats to PDF. 

To convert a presentation to PDF, simply pass the file name and save format to the [**Presentation.Save**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) method. The [**Presentation**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class exposes the [**Save**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) method that can be called to convert the whole PPT, PPTX, or ODP presentation into a PDF document. The [**PdfOptions**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) class provides options for creating the PDF such as **JpegQuality**, **TextCompression**, **Compliance**, and others. These options can be used to get the desired standard in a PDF.

**Note**: Aspose.Slides for Python via .NET directly writes the information about API and Version Number in output documents. For example, when rendering Document to PDF, Aspose.Slides for Python via .NET populates the Application field with the value 'Aspose.Slides' and the PDF Producer field with a value, e.g. 'Aspose.Slides v 17.10'. Please note that you cannot instruct Aspose.Slides for Python via .NET to change or remove this information from output Documents.

{{% alert color="primary" %}} 

You can try our **free online demo apps** to test the [**PPT to PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), [**PPTX to PDF**](https://products.aspose.app/slides/conversion/pptx-to-pdf), [**ODP to PDF** ](https://products.aspose.app/slides/conversion/odp-to-pdf)features by Aspose.

{{% /alert %}} 

## Accessibility and Compliance Standards for PDF

With Aspose.Slides, you can use a conversion procedure that complies with [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html).

When converting a PPT document to PDF, Aspose.Slides allows you to export a PPT document to the PDF format using any of these compliance standards: **PDF/A1a**, **PDF/A1b**, and **PDF/UA**. 

This sample code shows you how to specify your preferred PDF compliance standard when converting PPT to PDF:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

Aspose.Slides for Python via .NET typically exports the presentation documents to PDF and makes it as similar as possible to the original presentation document. Aspose.Slides renders most elements in a presentation when converting it to PDF:

- Images, Text Boxes, and other Shapes
- Text and Formatting
- Paragraphs and Formatting
- Hyperlinks
- Headers and Footers
- Bullets
- Tables

## **PPT to PDF Conversion Process Options**

Aspose.Slides for Python via .NET allows you to customize the presentation to PDF export with different options explained in this topic.

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

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPT file
presentation = slides.Presentation("PowerPoint.ppt")

# Save the presentation as PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```




## Convert PowerPoint to PDF with Custom Options
The following example shows you how to convert PowerPoint PPT, PPTX and OpenOffice ODP into a PDF document with customized options provided by the [**PdfOptions**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) class. It sets the JPEG quality, saves metafiles to PNG, sets text compression level with [**PdfTextCompression** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdftextcompression/)enumeration and sets PDF standard.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPTX file
presentation = slides.Presentation("PowerPoint.pptx")

# Instantiate the PdfOptions class
pdfOptions = slides.export.PdfOptions()

# Set Jpeg quality
pdfOptions.jpeg_quality = 90

# Set behavior for metafiles
pdfOptions.save_metafiles_as_png = True

# Set text compression level
pdfOptions.text_compression = slides.export.PdfTextCompression.FLATE

# Define the PDF standard
pdfOptions.compliance = slides.export.PdfCompliance.PDF15

# Save the presentation as PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```



## **Convert PowerPoint to PDF with Hidden Slides Included**
The following example shows how to convert a PowerPoint PPT, PPTX and OpenOffice ODP file into a PDF document with hidden slides included as provided by the [**PdfOptions**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) class. You can also include comments in generated HTML by using [**PdfOptions**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) class. 
It sets the ShowHiddenSlides property to generate PDF with hidden slides. 
Property **ShowHiddenSlides** has been added to **IHtmlOptions**, **IPdfOption**, **ISwfOptions**, 
**ITiffOptions**, **IXpsOption** interfaces and **HtmlOptions**, 
**PdfOption**, **SwfOptions**, **TiffOptions**, **XpsOption** classes. 
This property specifies whether the exported document should include hidden slides or not. 
Default value is **"false"**.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPTX file
presentation = slides.Presentation("PowerPoint.pptx")

# Instantiate the PdfOptions class
pdfOptions = slides.export.PdfOptions()

# Include hidden slides
pdfOptions.show_hidden_slides = True

# Save the presentation as PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```




## **Convert PowerPoint to Password Protected PDF**
The following example shows you how to convert a presentation to a password-protected PDF document with customized options provided by the [**PdfOptions**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) class.



```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPTX file
presentation = slides.Presentation("PowerPoint.pptx")

# Instantiate the PdfOptions class
pdfOptions = slides.export.PdfOptions()

# Setting PDF password and access permissions
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Save the presentation as PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```




## **Convert Selected Slides of PowerPoint to PDF**
The following example shows you how to convert a specific presentation slide to a PDF document with custom options.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPTX file
presentation = slides.Presentation("PowerPoint.pptx")

# Setting array of slides positions
slides_array = [ 1, 3 ]

# Save the presentation as PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```




## **Convert PowerPoint to PDF with Custom Slide Size**
The following example shows you how to convert a presentation to a PDF notes document with custom slide size. Here, each inch equals 72.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
presentation = slides.Presentation("SelectedSlides.pptx")
auxPresentation = slides.Presentation()

slide = presentation.slides[0]

auxPresentation.slides.insert_clone(0, slide)

# Setting Slide Type and Size 
auxPresentation.slide_size.set_size(612, 792, slides.SlideSizeScaleType.ENSURE_FIT)

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

auxPresentation.save("PDFnotes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```




## **Convert PowerPoint to PDF in Notes Slide View**
The [**Save**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) method exposed by [**Presentation**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class can be used to convert the whole presentation in Notes Slide view to PDF. Saving a Microsoft PowerPoint presentation to PDF notes with Aspose.Slides for Python via .NET is a two-line process. First, you open the presentation. Second, you save it out to PDF notes. The code snippet below updates the sample presentation to PDF in Notes Slide view.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Save the presentation to PDF notes
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```