---
title: Convert PPT & PPTX to PDF in Python | Advanced Options
linktitle: PowerPoint to PDF
type: docs
weight: 40
url: /python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- convert PowerPoint
- presentation
- PowerPoint to PDF
- PPT to PDF
- PPTX to PDF
- save PowerPoint as PDF
- attachment
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

To convert a presentation to PDF in Python, you simply have to pass the file name as an argument to the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and then save the presentation as a PDF using a [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) method. The [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class exposes the [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) method that is typically used to convert a presentation to PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python inserts its API information and version number into output documents. For example, when it converts a presentation to PDF, Aspose.Slides for Python populates the Application field with the '*Aspose.Slides*' value and the PDF Producer field with a value in '*Aspose.Slides v XX.XX*' form. **Note** that you cannot instruct Aspose.Slides for Python to change or remove this information from output documents.

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

The standard PowerPoint-to-PDF conversion process uses default options. In this case, Aspose.Slides tries to convert the provided presentation to PDF using optimal settings at the maximum quality levels.

The following example loads a presentation and saves all visible slides to PDF using the default export settings.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}

Aspose provides a free online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) that demonstrates the presentation to PDF conversion process. For a live implementation of the procedure described here, you can do a test with the converter.

{{% /alert %}}

## **Convert PowerPoint to PDF with Options**

Aspose.Slides provides custom options—properties under the [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) class—that allow you to customize the PDF (resulting from the conversion process), lock the PDF with a password, or even specify how the conversion process should go.

### **Convert PowerPoint to PDF with Custom Options**

Using custom conversion options, you can set your preferred quality setting for raster images, specify how metafiles should be handled, set a compression level for text, set DPI for images, etc.

The following example exports a presentation to PDF 1.5 with JPEG quality set to 90, image resolution set to 300 DPI, metafiles saved as PNG, and Flate text compression.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Preserve Embedded OLE Files as PDF Attachments**

If a presentation contains an embedded Excel workbook, you may want PDF recipients to access the workbook's data as well as view the slides. Set [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) to `True` to preserve embedded OLE files as attachments in the resulting PDF.

The default value is `False`: the OLE object's preview image or icon is rendered on the PDF page, but its embedded file is not included as an attachment. Setting the option to `True` additionally includes the file data. The preview remains a visual representation; the attachment lets recipients open or save the embedded file separately. The OLE object does not become an interactive Excel worksheet on the PDF page.

The following example loads a presentation that already contains an embedded Excel workbook and exports it to PDF with the workbook attached.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

To check the result:

1. Open the exported PDF in a viewer that supports file attachments, such as Adobe Acrobat Reader.
2. Open the viewer's **Attachments** panel and locate the embedded workbook.
3. Save the attachment and open it in Excel to inspect its data, or open it directly if the viewer permits it. The preview on the PDF page is separate from the attachment.

{{% alert color="info" title="Note" %}}

The PDF/A standards impose restrictions on attachments: PDF/A-1 prohibits embedded files, PDF/A-2 permits only PDF/A attachments, and PDF/A-3 permits other file types, including Excel workbooks. These are requirements of the standards, not restrictions specific to Aspose.Slides. This example uses the default PDF compliance setting and does not demonstrate PDF/A export.

{{% /alert %}}

### **Convert PowerPoint to PDF with Hidden Slides**

If a presentation contains hidden slides, you can use a custom option—the [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) property from the [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) class—to instruct Aspose.Slides to include the hidden slides as pages in the resulting PDF.

The following example exports a presentation to PDF, including any hidden slides.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Convert PowerPoint to a Password-Protected PDF**

The following example exports a presentation to a PDF that requires the password `password` to open. The access permissions allow printing, including high-quality printing.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Handle Fonts Without a Dedicated Bold Typeface**

A presentation can apply bold formatting to text even when its font has no dedicated bold typeface. The text can still appear bold through synthetic bolding, which artificially thickens the regular glyphs. When that text looks too heavy or otherwise differs from the intended appearance in PDF, try setting [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) to `True`. This option renders the affected text as a bitmap during PDF export and can improve its appearance for certain fonts. Its default value is `False`.

The sample presentation contains two text boxes: one with regular text and one with bold formatting applied to the same font, which has no dedicated bold typeface. The following example loads the presentation, enables rasterization of unsupported font styles, and exports it to PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

The following previews show the disabled output and the enabled output. In this example, the bold text has heavier strokes with the option disabled. With the option enabled, its strokes are lighter; the regular text is unchanged. Compare the results before choosing the setting for your presentation.

| Option disabled (`False`, the default) | Option enabled (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In this example, enabling the option turns only the bold text into a bitmap: it cannot be selected, copied, or searched as text without OCR, and its edges appear softer at 800% zoom. The regular text remains searchable. With the option disabled, both strings remain text.

This option rasterizes text formatted as bold when its font has no dedicated bold typeface. [Font substitution](/slides/python-net/font-substitution/) instead selects another font when the original is unavailable.

## **Convert Selected Slides in PowerPoint to PDF**

The following example exports slides 1 and 3 from a presentation to PDF. Slide numbers in this array are one-based, and the input presentation must contain at least three slides.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Convert PowerPoint to PDF with Custom Slide Size**

The following example copies the first slide from a presentation into a new presentation with a slide size of 612 × 792 points (8.5 × 11 inches). It scales the slide content to fit and exports the single slide to PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Remove the blank slide that the new presentation was created with.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Convert PowerPoint to PDF in Notes Slide View**

The following example exports a presentation to PDF, placing each slide's speaker notes below the slide. Use a presentation containing speaker notes to see the result.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
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

{{% alert color="info" title="Note" %}}

Aspose.Slides support for PDF conversion operations allows you to convert PDF to the most popular file formats. You can do [PDF to HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), and [PDF to PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) conversions. Other PDF conversion operations to specialized formats—[PDF to SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), and [PDF to XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—are also supported.

{{% /alert %}}

> **Note:** When exporting to PDF/UA, Aspose.Slides treats complex graphics such as SmartArt, charts, and formulas as a single figure. Individual path elements are not preserved as separate content and may be marked as artifacts; alternative text is provided only for the whole figure.

## **FAQ**

**Can Aspose.Slides for Python remove the application information from the PDF?**

No, Aspose.Slides for Python automatically includes API information and the version number in the output PDF. This information cannot be modified or removed.

**How do I include only specific slides in the PDF conversion?**

You can specify the slide indices you want to convert by passing an array of slide positions to the [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) method.

**Is it possible to password-protect the PDF during conversion?**

Yes, you can set a password and define access permissions using the [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) class before saving the presentation as a PDF.

**Does Aspose.Slides support converting PDF to other formats?**

Yes, Aspose.Slides supports converting PDFs to formats like HTML, image formats (JPG, PNG), SVG, TIFF, and XML.

**How can I ensure my PDF complies with accessibility standards?**

Set the [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) property in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) to standards like `PDF_A1A`, `PDF_A1B`, or `PDF_UA` to ensure compliance with accessibility guidelines.

**Can I include hidden slides in the PDF output?**

Yes, by setting the [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) property in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) to `True`, hidden slides will be included in the PDF.

**How do I adjust image quality and resolution during conversion?**

Use the [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) and [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) properties in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) to control image quality and resolution in the resulting PDF.

**Does Aspose.Slides handle font substitutions automatically?**

Aspose.Slides detects font substitutions during conversion, and you can handle them using the `warning_callback` property in `SaveOptions` (currently limited).

## **Additional Resources**

- [Aspose.Slides for Python via .NET Documentation](/slides/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)
