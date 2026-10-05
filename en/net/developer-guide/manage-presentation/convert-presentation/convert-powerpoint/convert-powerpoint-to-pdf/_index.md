---
title: Convert PPT and PPTX to PDF in .NET [Advanced Features Included]
linktitle: PowerPoint to PDF
type: docs
weight: 40
url: /net/convert-powerpoint-to-pdf/
keywords:
- convert PowerPoint
- convert presentation
- PowerPoint to PDF
- presentation to PDF
- PPT to PDF
- convert PPT to PDF
- PPTX to PDF
- convert PPTX to PDF
- save PowerPoint as PDF
- save PPT as PDF
- save PPTX as PDF
- export PPT to PDF
- export PPTX to PDF
- attachment
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Convert PowerPoint PPT/PPTX to high-quality, searchable PDFs in .NET using Aspose.Slides, with fast C# code examples and advanced conversion options."
---

## **Overview**

Converting PowerPoint presentations (PPT, PPTX, ODP, etc.) into PDF format in C# offers several advantages, including compatibility across different devices and preserving the layout and formatting of your presentation. This guide demonstrates how to convert presentations to PDF documents, use various options to control image quality, include hidden slides, password-protect PDF files, detect font substitutions, select specific slides for conversion, and apply compliance standards to output documents.

## **PowerPoint to PDF Conversions**

Using Aspose.Slides, you can convert presentations in the following formats to PDF:

* **PPT**
* **PPTX**
* **ODP**

To convert a presentation to PDF, pass the file name as an argument to the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class and then save the presentation as a PDF using a [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) method. The [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class exposes the [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) method that is typically used to convert a presentation to PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for .NET inserts its API information and version number into output documents. For example, when converting a presentation to PDF, Aspose.Slides populates the Application field with "*Aspose.Slides*" and the PDF Producer field with a value in "*Aspose.Slides v XX.XX*" form. **Note** that you cannot instruct Aspose.Slides to change or remove this information from output documents.

{{% /alert %}}

Aspose.Slides allows you to convert:

* Entire presentations to PDF
* Specific slides from a presentation to PDF

Aspose.Slides exports presentations to PDF, ensuring the resulting PDFs closely match the original presentations. Elements and attributes are rendered accurately in the conversion, including:

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

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}

Aspose offers a free online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) that demonstrates the presentation-to-PDF conversion process. You can run a test with this converter for a live implementation of the procedure described here.

{{% /alert %}}

## **Convert PowerPoint to PDF with Options**

Aspose.Slides provides custom options—properties under the [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) class—that allow you to customize the resulting PDF, lock the PDF with a password, or specify how the conversion process should proceed.

### **Convert PowerPoint to PDF with Custom Options**

Using custom conversion options, you can define your preferred quality setting for raster images, specify how metafiles should be handled, set a compression level for text, configure DPI for images, and more.

The following example exports a presentation to PDF 1.5 with JPEG quality set to 90, image resolution set to 300 DPI, metafiles saved as PNG, and Flate text compression.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Preserve Embedded OLE Files as PDF Attachments**

If a presentation contains an embedded Excel workbook, you may want PDF recipients to access the workbook's data as well as view the slides. Set [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) to `true` to preserve embedded OLE files as attachments in the resulting PDF.

The default value is `false`: the OLE object's preview image or icon is rendered on the PDF page, but its embedded file is not included as an attachment. Setting the option to `true` additionally includes the file data. The preview remains a visual representation; the attachment lets recipients open or save the embedded file separately. The OLE object does not become an interactive Excel worksheet on the PDF page.

The following example loads a presentation that already contains an embedded Excel workbook and exports it to PDF with the workbook attached.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

To check the result:

1. Open the exported PDF in a viewer that supports file attachments, such as Adobe Acrobat Reader.
2. Open the viewer's **Attachments** panel and locate the embedded workbook.
3. Save the attachment and open it in Excel to inspect its data, or open it directly if the viewer permits it. The preview on the PDF page is separate from the attachment.

{{% alert color="info" title="Note" %}}

The PDF/A standards impose restrictions on attachments: PDF/A-1 prohibits embedded files, PDF/A-2 permits only PDF/A attachments, and PDF/A-3 permits other file types, including Excel workbooks. These are requirements of the standards, not restrictions specific to Aspose.Slides. This example uses the default PDF compliance setting and does not demonstrate PDF/A export.

{{% /alert %}}

### **Convert PowerPoint to PDF with Hidden Slides**

If a presentation contains hidden slides, you can use the [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) property from the [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) class to include the hidden slides as pages in the resulting PDF.

The following example exports a presentation to PDF, including any hidden slides.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Convert PowerPoint to a Password-Protected PDF**

The following example exports a presentation to a PDF that requires the password `password` to open. The access permissions allow printing, including high-quality printing.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Detect Font Substitutions**

Aspose.Slides provides the [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) property under the [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) class, enabling you to detect font substitutions during the presentation-to-PDF conversion process.

The following example exports a presentation to PDF and prints font substitution warnings to the console. A warning is printed only when an unavailable font is substituted during export.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}

For more information on font substitution, see the [Font Substitution](/slides/net/font-substitution/) article.

{{% /alert %}} 

## **Convert Selected Slides from PowerPoint to PDF**

The following example exports slides 1 and 3 from a presentation to PDF. Slide numbers in this array are one-based, and the input presentation must contain at least three slides.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Convert PowerPoint to PDF with Custom Slide Size**

The following example copies the first slide from a presentation into a new presentation with a slide size of 612 × 792 points (8.5 × 11 inches). It scales the slide content to fit and exports the single slide to PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Convert PowerPoint to PDF in Notes Slide View**

The following example exports a presentation to PDF, placing each slide's speaker notes below the slide. Use a presentation containing speaker notes to see the result.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Accessibility and Compliance Standards for PDF**

Aspose.Slides allows you to use a conversion procedure that complies with [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). You can export a PowerPoint document to PDF using any of these compliance standards: **PDF/A1a**, **PDF/A1b**, and **PDF/UA**.

This C# code demonstrates a PowerPoint-to-PDF conversion process that produces multiple PDFs based on different compliance standards:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert color="info" title="Note" %}}

Aspose.Slides supports PDF conversion operations, allowing you to convert PDF files to popular file formats. You can perform [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), and [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) conversions. Other PDF conversion operations to specialized formats—[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), and [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—are also supported.

{{% /alert %}}

> **Note:** When exporting to PDF/UA, Aspose.Slides treats complex graphics such as SmartArt, charts, and formulas as a single figure. Individual path elements are not preserved as separate content and may be marked as artifacts; alternative text is provided only for the whole figure.

## **FAQ**

**Can I convert multiple PowerPoint files to PDF in bulk?**

Yes, Aspose.Slides supports batch conversion of multiple PPT or PPTX files to PDF. You can iterate through your files and apply the conversion process programmatically.

**Is it possible to password-protect the converted PDF?**

Yes. Use the [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) class to set a password and define access permissions during the conversion process.

**How do I include hidden slides in the PDF?**

Set the [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) property in the [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) class to `true` to include hidden slides in the resulting PDF.

**Can Aspose.Slides maintain high image quality in the PDF?**

Yes, you can control image quality by setting properties such as [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) and [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) in the [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) class to ensure high-quality images in your PDF.

**Does Aspose.Slides support PDF/A compliance standards?**

Yes, Aspose.Slides allows you to export PDFs that comply with various standards, including PDF/A1a, PDF/A1b, and PDF/UA, ensuring your documents meet accessibility and archival requirements.

## **Additional Resources**

- [Aspose.Slides for .NET Documentation](/slides/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)
