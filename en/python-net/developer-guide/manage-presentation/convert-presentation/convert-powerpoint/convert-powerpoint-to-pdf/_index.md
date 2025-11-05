---
title: Convert PPT & PPTX to PDF in Python | Advanced Options
linktitle: PowerPoint to PDF
type: docs
weight: 40
url: /python-net/convert-powerpoint-to-pdf/
keywords:
- convert PowerPoint
- presentation
- PowerPoint to PDF
- PPT to PDF
- PPTX to PDF
- save PowerPoint as PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Step‑by‑step guide to converting PPT, PPTX, and ODP to high‑quality, WCAG‑compliant PDFs in Python with Aspose.Slides—includes password protection, slide selection, and image‑quality control."
showReadingTime: true
---

## **Overview**

Converting PowerPoint presentations (PPT, PPTX, ODP) into PDF format in Python offers several advantages, including ensuring compatibility across different devices and preserving the layout and formatting of your presentation. This guide demonstrates how to convert presentations to PDF documents, utilize various options to control image quality, include hidden slides, password protect PDF documents, detect font substitutions, select specific slides for conversion, and apply compliance standards to output documents.

## **PowerPoint to PDF Conversions**

Using Aspose.Slides, you can convert presentations in these formats to PDF:

* **PPT**
* **PPTX**
* **ODP**

To convert a presentation to PDF in Python, you simply have to pass the file name as an argument in the [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class and then save the presentation as a PDF using a [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods) method. The [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class exposes the  [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods) method that is typically used to convert a presentation to PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python directly writes API information and Version Number in output documents. For example, when it converts a presentation to PDF, Aspose.Slides for Python populates the Application field with the '*Aspose.Slides*' value and the PDF Producer field with a value in '*Aspose.Slides v XX.XX*'  form. **Note** that you cannot instruct Aspose.Slides for Python to change or remove this information from output documents.

{{% /alert %}}

Aspose.Slides allows you to convert:

* Entire presentations to PDF
* Specific slides in a presentation to PDF

Aspose.Slides exports presentations to PDF, ensuring the contents of the resulting PDFs closely match the original presentations. Elements and attributes are rendered accurately in the conversion, including:

* Images
* Text boxes and shapes
* Text formatting
* Paragraph formatting
* Hyperlinks
* Headers and footers
* Bullets
* Tables

## **Convert PowerPoint to PDF**

The standard PowerPoint PDF conversion operation is executed using default options. In this case, Aspose.Slides tries to convert the provided presentation to PDF using optimal settings at the maximum quality levels. This Python code shows you how to convert a PowerPoint to PDF:

_Steps: PowerPoint to PDF Conversions in Python_

The following sample code explains these conversions using Python via .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Steps: Convert PowerPoint to PDF using Python via .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Steps: Convert PPT to PDF using Python via .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Steps: Convert PPTX to PDF using Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Steps: Convert ODP to PDF using Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Steps: Convert PPS to PDF using Python via .NET</a></strong>

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

## **Convert PowerPoint to PDF with Options**

Aspose.Slides provides custom options—properties under the [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) class—that allow you to customize the PDF (resulting from the conversion process), lock the PDF with a password, or even specify how the conversion process should go.

### **Convert PowerPoint to PDF with Custom Options**

Using custom conversion options, you can set your preferred quality setting for raster images, specify how metafiles should be handled, set a compression level for texts, set DPI for images, etc.

The code example below demonstrates an operation in which a PowerPoint presentation is converted to PDF with several custom options:

```python
import aspose.slides as slides

# Instantiates the PdfOptions class
pdf_options = slides.export.PdfOptions()

# Sets the quality for JPG images
pdf_options.jpeg_quality = 90

# Sets DPI for images
pdf_options.sufficient_resolution = 300

# Sets the behavior for metafiles
pdf_options.save_metafiles_as_png = True

# Sets the text compression level for textual content
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Defines the PDF compliance mode
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Instantiates the Presentation class that represents a PowerPoint document
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Saves the presentation as a PDF document
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
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

### **Detect Font Substitutions**

Aspose.Slides provides the `warning_callback` property under the [SaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/) class to allow you to detect font substitutions in a presentation to PDF conversion process. 

This Python code shows you how to detect font substitutions:  

```python
[TODO[SLIDESPYNET-91]: callbacks are not supported for now]
```

{{%  alert color="primary"  %}} 

For more information on font substitution, see the [Font Substitution](https://docs.aspose.com/slides/python-net/font-substitution/) article.

{{% /alert %}} 

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

slide_width = 612
slide_height = 792

# Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Create a new presentation with an adjusted slide size.
    with slides.Presentation() as resized_presentation:

        # Set the custom slide size.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Clone the first slide from the original presentation.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Save the resized presentation to a PDF with notes.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides support for PDF conversion operations extends to allowing you allow convert PDF to the most popular file formats. You can do [PDF to HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), and [PDF to PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) conversions. Other PDF conversion operations to specialized formats—[PDF to SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), and [PDF to XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—are also supported.

{{% /alert %}}

## **FAQ**

**Can Aspose.Slides for Python remove the application information from the PDF?**

No, Aspose.Slides for Python automatically includes API information and the version number in the output PDF. This information cannot be modified or removed.

**How do I include only specific slides in the PDF conversion?**

You can specify the slide indices you want to convert by passing an array of slide positions to the `save` method.

**Is it possible to password-protect the PDF during conversion?**

Yes, you can set a password and define access permissions using the `PdfOptions` class before saving the presentation as a PDF.

**Does Aspose.Slides support converting PDF to other formats?**

Yes, Aspose.Slides supports converting PDFs to formats like HTML, image formats (JPG, PNG), SVG, TIFF, and XML.

**How can I ensure my PDF complies with accessibility standards?**

Set the `compliance` property in `PdfOptions` to standards like `PDF_A1A`, `PDF_A1B`, or `PDF_UA` to ensure compliance with accessibility guidelines.

**Can I include hidden slides in the PDF output?**

Yes, by setting the `show_hidden_slides` property in `PdfOptions` to `True`, hidden slides will be included in the PDF.

**How do I adjust image quality and resolution during conversion?**

Use the `jpeg_quality` and `sufficient_resolution` properties in `PdfOptions` to control image quality and resolution in the resulting PDF.

**Does Aspose.Slides handle font substitutions automatically?**

Aspose.Slides detects font substitutions during conversion, and you can handle them using the `warning_callback` property in `SaveOptions` (currently limited).

## **Additional Resources**

- [Aspose.Slides for .NET Documentation](https://docs.aspose.com/slides/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)
