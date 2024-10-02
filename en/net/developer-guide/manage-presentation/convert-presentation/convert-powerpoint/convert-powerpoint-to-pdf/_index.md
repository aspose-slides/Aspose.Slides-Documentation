---
title: Convert PowerPoint to PDF in C#
linktitle: Convert PowerPoint to PDF
type: docs
weight: 40
url: /net/convert-powerpoint-to-pdf/
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
- C#
- Csharp
- .NET
- Aspose.Slides for .NET
description: "Convert PowerPoint presentations to PDF in C# or .NET. Save PowerPoint as PDF with compliance or accessibility standards."
---

## **Overview**

Converting PowerPoint documents into PDF format offers several advantages, including ensuring compatibility across different devices and preserving the layout and formatting of your presentation. This article shows you how to convert presentations to PDF documents, use various options to control image quality, include hidden slides, password protect PDF documents, detect font substitutions, select slides for conversion, and apply compliance standards to output documents.

## **PowerPoint to PDF Conversions**

Using Aspose.Slides, you can convert presentations in these formats to PDF:

* PPT
* PPTX
* ODP

To convert a presentation to PDF, you simply have to pass the file name as an argument in the [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class and then save the presentation as a PDF using a [`Save`](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) method. The [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class exposes the [`Save`](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/#presentationsave-method-5-of-9) method that is typically used to convert a presentation to PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET directly writes API information and Version Number in output documents. For example, when it converts a presentation to PDF, Aspose.Slides for .NET populates the Application field with the '*Aspose.Slides*' value and the PDF Producer field with a value in '*Aspose.Slides v XX.XX*'  form. **Note** that you cannot instruct Aspose.Slides for .NET to change or remove this information from output documents.

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

This C# code shows you how to convert a PowerPoint (PPT, PPTX, ODP) to PDF:

```c#
// Instantiates a Presentation class that represents a PowerPoint file, it could be PPT, PPTX, ODP etc.
Presentation presentation = new Presentation("PowerPoint.ppt");

// Saves the presentation as a PDF
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose provides a free online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) that demonstrates the presentation to PDF conversion process. For a live implementation of the procedure described here, you can do a test with the converter.

{{% /alert %}}

## **Convert PowerPoint to PDF with Options**

Aspose.Slides provides custom options—properties under the [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) class—that allow you to customize the PDF (resulting from the conversion process), lock the PDF with a password, or even specify how the conversion process should go.

### **Convert PowerPoint to PDF with Custom Options**

Using custom conversion options, you can set your preferred quality setting for raster images, specify how metafiles should be handled, set a compression level for texts, set DPI for images, etc.

The code example below demonstrates an operation in which a PowerPoint presentation is converted to PDF with several custom options:

```c#
// Instantiates the PdfOptions class
PdfOptions pdfOptions = new PdfOptions
{
    // Sets the quality for JPG images
    JpegQuality = 90,

    // Sets DPI for images
    SufficientResolution = 300,

    // Sets the behavior for metafiles
    SaveMetafilesAsPng = true,

    // Sets the text compression level for textual content
    TextCompression = PdfTextCompression.Flate,

    // Defines the PDF compliance mode
    Compliance = PdfCompliance.Pdf15
};

// Instantiates the Presentation class that represents a PowerPoint document
using (Presentation presentation = new Presentation("PowerPoint.pptx"))
{
    // Saves the presentation as a PDF document
    presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
}
```

### **Convert PowerPoint to PDF with Hidden Slides**

If a presentation contains hidden slides, you can use a custom option—the [`ShowHiddenSlides`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) property from the [`PdfOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) class—to instruct Aspose.Slides to include the hidden slides as pages in the resulting PDF.

This C# code shows you how to convert a PowerPoint presentation to PDF with hidden slides included:

```c#
// Instantiates a Presentation class that represents a PowerPoint file
Presentation presentation = new Presentation("PowerPoint.pptx");

// Instantiates the PdfOptions class
PdfOptions pdfOptions = new PdfOptions();

// Adds hidden slides
pdfOptions.ShowHiddenSlides = true;

// Saves the presentation as a PDF
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Convert PowerPoint to Password Protected PDF**

This C# code shows you how to convert a PowerPoint to a password-protected PDF (using protection parameters from the [`PdfOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) class):

```c#
// Instantiates a Presentation object that represents a PowerPoint file
Presentation presentation = new Presentation("PowerPoint.pptx");

/// Instantiates the PdfOptions class
PdfOptions pdfOptions = new PdfOptions();

// Sets PDF password and access permissions
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Saves the presentation as a PDF
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Detect Font Substitutions**

Aspose.Slides provides the [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) property under the [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) class to allow you to detect font substitutions in a presentation to PDF conversion process. 

This C# code shows you how to detect font substitutions: xxx 

```c#
public static void Main()
{
    LoadOptions loadOptions = new LoadOptions();
    FontSubstSendsWarningCallback warningCallback = new FontSubstSendsWarningCallback();
    loadOptions.WarningCallback = warningCallback;

    using (Presentation pres = new Presentation("pres.pptx", loadOptions))
    {
    }
}

private class FontSubstSendsWarningCallback : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.CompatibilityIssue)
            return ReturnAction.Continue;

        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

For more information on getting callbacks for font substitutions in a rendering process, see [Getting Warning Callbacks for Fonts Substitution](https://docs.aspose.com/slides/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

For more information on font substitution, see the [Font Substitution](https://docs.aspose.com/slides/net/font-substitution/) article.

{{% /alert %}} 

## **Convert Selected Slides in PowerPoint to PDF**

This C# code shows you how to convert specific slides in a PowerPoint presentation to PDF:

```c#
// Instantiates a Presentation object that represents a PowerPoint file
Presentation presentation = new Presentation("PowerPoint.pptx");

// Sets an array of slides positions
int[] slides = { 1, 3 };

// Saves the presentation as a PDF
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Convert PowerPoint to PDF with Custom Slide Size**

This C# code shows you how to convert a PowerPoint when its slide size is specified to a PDF:

```c#
// Instantiates a Presentation object that represents a PowerPoint file 
Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];
auxPresentation.Slides.InsertClone(0, slide);

// Sets the slide type and size 
// auxPresentation.SlideSize.SetSize(presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height,SlideSizeScaleType.EnsureFit);
auxPresentation.SlideSize.SetSize(612F, 792F,SlideSizeScaleType.EnsureFit);

PdfOptions pdfOptions = new PdfOptions();
INotesCommentsLayoutingOptions options = pdfOptions.NotesCommentsLayouting;
options.NotesPosition = NotesPositions.BottomFull;

auxPresentation.Save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Convert PowerPoint to PDF in Notes Slide View**

This C# code shows you how to convert a PowerPoint to PDF notes:

```c#
// Instantiates a Presentation class that represents a PowerPoint file
using (Presentation presentation = new Presentation("NotesFile.pptx"))
{
	PdfOptions pdfOptions = new PdfOptions();
	INotesCommentsLayoutingOptions options = pdfOptions.NotesCommentsLayouting;
	options.NotesPosition = NotesPositions.BottomFull;

	// Saves the presentation to PDF notes
	presentation.Save("Pdf_Notes_out.tiff", SaveFormat.Pdf, pdfOptions);
}
```

## **Accessibility and Compliance Standards for PDF**

Aspose.Slides allows you to use a conversion procedure that complies with [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). You can export a PowerPoint document to PDF using any of these compliance standards: **PDF/A1a**, **PDF/A1b**, and **PDF/UA**.

This C# code demonstrates a PowerPoint to PDF conversion operation in which multiple PDFs based on different compliance standards are obtained:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
    {
        Compliance = PdfCompliance.PdfA1a
    });
   
    pres.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
    {
        Compliance = PdfCompliance.PdfA1b
    });
   
    pres.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
   {
        Compliance = PdfCompliance.PdfUa
    });
}
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides support for PDF conversion operations extends to allowing you allow convert PDF to the most popular file formats. You can do [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), and [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) conversions. Other PDF conversion operations to specialized formats—[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), and [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—are also supported.

{{% /alert %}}
