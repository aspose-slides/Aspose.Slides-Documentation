---
title: Convert PowerPoint PPTX or PPT to PDF in Python
linktitle: Convert PowerPoint to PDF
type: docs
weight: 40
url: /python-net/convert-powerpoint-to-pdf/
keywords: "Convert PowerPoint, Presentation, PowerPoint to PDF, PPT to PDF, PPTX to PDF, Save PowerPoint as PDF, PDF/A1a, PDF/A1b, PDF/UA, Python"
description: "Convert PowerPoint Presentation to PDF in Python. Save PowerPoint as PDF with compliance or accessibility standards"
---

## **Overview**

This article explains how you can convert PowerPoint file formats into PDF in Python. It covers wide range of topics e.g.

- Convert PPT to PDF in Python
- Convert PPTX to PDF in Python
- Convert ODP to PDF in Python
- Convert PowerPoint to PDF in Python

## **Python PowerPoint to PDF Conversions**

Using Aspose.Slides, you can convert presentations in these formats to PDF:

* PPT
* PPTX
* ODP

To convert a presentation to PDF in Python, you simply have to pass the file name as an argument in the [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class and then save the presentation as a PDF using a [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods) method. The [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class exposes the  [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods) method that is typically used to convert a presentation to PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python directly writes API information and Version Number in output documents. For example, when it converts a presentation to PDF, Aspose.Slides for Python populates the Application field with the '*Aspose.Slides*' value and the PDF Producer field with a value in '*Aspose.Slides v XX.XX*'  form. **Note** that you cannot instruct Aspose.Slides for Python to change or remove this information from output documents.

{{% /alert %}}

Aspose.Slides allows you to convert:

* an entire presentation to PDF
* specific slides in a presentation to PDF
* a presentation 

Aspose.Slides exports presentations to PDF in a way that makes the contents of the resulting PDFs very similar to those in the original presentations. These known elements and attributes are often rendered properly in presentation to PDF conversions:

* images
* text boxes and other shapes
* texts and their formatting
* paragraphs and their formatting
* hyperlinks
* headers and footers
* bullets
* tables

## **Convert PowerPoint to PDF**

The standard PowerPoint PDF conversion operation is executed using default options. In this case, Aspose.Slides tries to convert the provided presentation to PDF using optimal settings at the maximum quality levels.

This Python code shows you how to convert a PowerPoint to PDF:

_Steps: PowerPoint to PDF Conversions_

The following sample code explains these conversions using Python via .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Steps: _Convert PowerPoint to PDF using Python via .NET_</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Steps: _Convert PPT to PDF using Python via .NET_</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Steps: _Convert PPTX to PDF using Python via .NET_</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Steps: _Convert ODP to PDF using Python via .NET_</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Steps: _Convert PPS to PDF using Python via .NET_</a></strong>

_Code Steps:_

- Create instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and provide it the PowerPoint file.
  * _.ppt_ extension to load **PPT** file inside _Presentation_ class.
  * _.pptx_ extension to load **PPTX** file inside _Presentation_ class.
  * _.odp_ extension to load **ODP** file inside _Presentation_ class.
  * _.pps_ extension to load **PPS** file inside _Presentation_ class.
- Save the _Presentation_ to **PDF** format by calling **Save** method and using **SaveFormat.PDF** enumeration.
  

```python
import aspose.slides as slides

# Instantiates a Presentation class that represents a PowerPoint file
presentation = slides.Presentation("PowerPoint.ppt")

# Saves the presentation as a PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose provides a free online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) that demonstrates the presentation to PDF conversion process. For a live implementation of the procedure described here, you can do a test with the converter.

{{% /alert %}}

## Convert PowerPoint to PDF with Options

Aspose.Slides provides custom options—properties under the [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) class—that allow you to customize the PDF (resulting from the conversion process), lock the PDF with a password, or even specify how the conversion process should go.

### **Convert PowerPoint to PDF with Custom Options**

Using custom conversion options, you can set your preferred quality setting for JPG images, specify how metafiles should be handled, set a compression level for texts, etc.

This Python code demonstrates an operation in which a PowerPoint is converted to PDF with several custom options:

```python
import aspose.slides as slides

# Instantiates a Presentation class that represents a PowerPoint file
presentation = slides.Presentation("PowerPoint.pptx")

# Instantiates the PdfOptions class
pdfOptions = slides.export.PdfOptions()

# Sets the Jpeg quality
pdfOptions.jpeg_quality = 90

# Sets the behavior for metafiles
pdfOptions.save_metafiles_as_png = True

# Sets the text compression level
pdfOptions.text_compression = slides.export.PdfTextCompression.FLATE

# Defines the PDF standard
pdfOptions.compliance = slides.export.PdfCompliance.PDF15

# Saves the presentation as a PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Convert PowerPoint to PDF with Hidden Slides**

If a presentation contains hidden slides, you can use a custom option—the `show_hidden_slides` property from the [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) class—to instruct Aspose.Slides to include the hidden slides as pages in the resulting PDF.

This Python code shows you how to convert a PowerPoint presentation to PDF with hidden slides included:

```python
import aspose.slides as slides

# Instantiates a Presentation class that represents a PowerPoint file
presentation = slides.Presentation("PowerPoint.pptx")

# Instantiates the the PdfOptions class
pdfOptions = slides.export.PdfOptions()

# Adds hidden slides
pdfOptions.show_hidden_slides = True

# Saves the presentation as a PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Convert PowerPoint to Password Protected PDF**

This Python code shows you how to convert a PowerPoint to a password-protected PDF (using protection parameters from the [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) class):

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a PowerPoint file
presentation = slides.Presentation("PowerPoint.pptx")

# Instantiates the PdfOptions class
pdfOptions = slides.export.PdfOptions()

# Sets PDF password and access permissions
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Saves the presentation as a PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Convert Selected Slides in PowerPoint to PDF**

This Python code shows you how to convert specific slides in a PowerPoint presentation to PDF:

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a PowerPoint file
presentation = slides.Presentation("PowerPoint.pptx")

# Sets an array of slides positions
slides_array = [ 1, 3 ]

# Saves the presentation as a PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Convert PowerPoint to PDF with Custom Slide Size**

This Python code shows you how to convert a PowerPoint when its slide size is specified to a PDF:

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a PowerPoint file 
presentation = slides.Presentation("SelectedSlides.pptx")
auxPresentation = slides.Presentation()

slide = presentation.slides[0]

auxPresentation.slides.insert_clone(0, slide)

# Sets the slide type and size 
auxPresentation.slide_size.set_size(612, 792, slides.SlideSizeScaleType.ENSURE_FIT)

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

auxPresentation.save("PDFnotes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Convert PowerPoint to PDF in Notes Slide View**

This Python code shows you how to convert a PowerPoint to PDF notes:

```python
import aspose.slides as slides

# Instantiates a Presentation class that represents a PowerPoint file
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Saves the presentation to PDF notes
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Accessibility and Compliance Standards for PDF**

Aspose.Slides allows you to use a conversion procedure that complies with [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). You can export a PowerPoint document to PDF using any of these compliance standards: **PDF/A1a**, **PDF/A1b**, and **PDF/UA**.

This Python code demonstrates a PowerPoint to PDF conversion operation in which multiple PDFs based on different compliance standards are obtained:

```python
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
