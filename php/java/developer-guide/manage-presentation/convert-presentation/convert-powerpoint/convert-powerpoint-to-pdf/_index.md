---
title: Convert PowerPoint to PDF in Java
linktitle: Convert PowerPoint to PDF
type: docs
weight: 40
url: /java/convert-powerpoint-to-pdf/
keywords: "Convert PowerPoint, Presentation, PowerPoint to PDF, PPT to PDF, PPTX to PDF, Save PowerPoint as PDF, PDF/A1a, PDF/A1b, PDF/UA, Java"
description: "Convert PowerPoint Presentation to PDF in Java. Save PowerPoint as PDF with compliance or accessibility standards"

---
## **Overview**

This article explains how you can convert PowerPoint file formats into PDF using Java. It covers wide range of topics e.g.

- Convert PPT to PDF in Java
- Convert PPTX to PDF in Java
- Convert ODP to PDF in Java
- Convert PowerPoint to PDF in Java

## **Java PowerPoint to PDF Conversions**

Using Aspose.Slides, you can convert presentations in these formats to PDF:

* PPT
* PPTX
* ODP

To convert a presentation to PDF, you simply have to pass the file name as an argument in the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class and then save the presentation as a PDF using a [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) method. The [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class exposes the [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) method that is typically used to convert a presentation to PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Java directly writes API information and Version Number in output documents. For example, when it converts a presentation to PDF, Aspose.Slides for Java populates the Application field with the '*Aspose.Slides*' value and the PDF Producer field with a value in '*Aspose.Slides v XX.XX*'  form. **Note** that you cannot instruct Aspose.Slides for Java to change or remove this information from output documents.

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

This Java code shows you how to convert a PowerPoint to PDF:

```java
// Instantiates a Presentation class that represents a PowerPoint file
Presentation pres = new Presentation("PowerPoint.ppt");
try {
    // Saves the presentation as a PDF
    pres.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose provides a free online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) that demonstrates the presentation to PDF conversion process. For a live implementation of the procedure described here, you can do a test with the converter.

{{% /alert %}}

## **Convert PowerPoint to PDF with Options**

Aspose.Slides provides custom options—properties under the [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions) class—that allow you to customize the PDF (resulting from the conversion process), lock the PDF with a password, or even specify how the conversion process should go.

### **Convert PowerPoint to PDF with Custom Options**

Using custom conversion options, you can set your preferred quality setting for JPG images, specify how metafiles should be handled, set a compression level for texts, etc.

This Java code demonstrates an operation in which a PowerPoint is converted to PDF with several custom options:

```java
// Instantiates a Presentation class that represents a PowerPoint file
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Instantiates the PdfOptions class
    PdfOptions pdfOptions = new PdfOptions();
    
    // Sets the Jpeg quality
    pdfOptions.setJpegQuality((byte)90);
    
    // Sets the behavior for metafiles
    pdfOptions.setSaveMetafilesAsPng(true);
    
    // Sets the text compression level
    pdfOptions.setTextCompression(PdfTextCompression.Flate);
    
    // Defines the PDF standard
    pdfOptions.setCompliance(PdfCompliance.Pdf15);
    
    // Saves the presentation as a PDF
    pres.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Convert PowerPoint to PDF with Hidden Slides**

If a presentation contains hidden slides, you can use a custom option—the [ShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IPdfOptions#getShowHiddenSlides--) property from the [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions) class—to instruct Aspose.Slides to include the hidden slides as pages in the resulting PDF.

This Java code shows you how to convert a PowerPoint presentation to PDF with hidden slides included:

```java
// Instantiates a Presentation class that represents a PowerPoint file
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Instantiates the PdfOptions class
    PdfOptions pdfOptions = new PdfOptions();
    
    // Adds hidden slides
    pdfOptions.setShowHiddenSlides(true);
    
    // Saves the presentation as a PDF
    pres.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Convert PowerPoint to Password Protected PDF**

This Java code shows you how to convert a PowerPoint to a password-protected PDF (using protection parameters from the [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions) class):

```java
// Instantiates a Presentation object that represents a PowerPoint file
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    /// Instantiates the PdfOptions class
    PdfOptions pdfOptions = new PdfOptions();
    
    // Sets PDF password and access permissions
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);
    
    // Saves the presentation as a PDF
    pres.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### Detect Font Substitutions**

Aspose.Slides provides the [getWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#getWarningCallback--) method under the [SaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/) class to allow you to detect font substitutions in a presentation to PDF conversion process. 

This Java code shows you how to detect font substitutions: 

```java
public void main(String[] args)
{
    LoadOptions loadOptions = new LoadOptions();
    FontSubstSendsWarningCallback warningCallback = new FontSubstSendsWarningCallback();
    loadOptions.setWarningCallback(warningCallback);

    Presentation pres = new Presentation("pres.pptx", loadOptions);
    try {
        
    } finally {
        if (pres != null) pres.dispose();
    }
}

private class FontSubstSendsWarningCallback implements IWarningCallback
{
    public int warning(IWarningInfo warning)
    {
        if (warning.getWarningType() == WarningType.CompatibilityIssue)
            return ReturnAction.Continue;

        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted"))
        {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

For more information on getting callbacks for font substitutions in a rendering process, see [Getting Warning Callbacks for Fonts Substitution](https://docs.aspose.com/slides/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

For more information on font substitution, see the [Font Substitution](https://docs.aspose.com/slides/java/font-substitution/) article.

{{% /alert %}} 

## **Convert Selected Slides in PowerPoint to PDF**

This Java code shows you how to convert specific slides in a PowerPoint presentation to PDF:

```java
// Instantiates a Presentation object that represents a PowerPoint file
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Sets an array of slides positions
    int[] slides = { 1, 3 };
    
    // Saves the presentation as a PDF
    pres.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convert PowerPoint to PDF with Custom Slide Size**

This Java code shows you how to convert a PowerPoint when its slide size is specified to a PDF:

```java
// Instantiates a Presentation object that represents a PowerPoint file 
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    Presentation outPres = new Presentation();
    try {
        ISlide slide = pres.getSlides().get_Item(0);

        outPres.getSlides().insertClone(0, slide);
        
        // Sets the slide type and size 
        outPres.getSlideSize().setSize(612F, 792F, SlideSizeScaleType.EnsureFit);
        
        PdfOptions pdfOptions = new PdfOptions();
        INotesCommentsLayoutingOptions options = pdfOptions.getNotesCommentsLayouting();
        options.setNotesPosition(NotesPositions.BottomFull);

        outPres.save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        if (pres != null) pres.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convert PowerPoint to PDF in Notes Slide View**

This Java code shows you how to convert a PowerPoint to PDF notes:

```java
// Instantiates a Presentation class that represents a PowerPoint file
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    INotesCommentsLayoutingOptions options = pdfOptions.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    pres.save("Pdf_With_Notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accessibility and Compliance Standards for PDF**

Aspose.Slides allows you to use a conversion procedure that complies with [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). You can export a PowerPoint document to PDF using any of these compliance standards: **PDF/A1a**, **PDF/A1b**, and **PDF/UA**.

This Java code demonstrates a PowerPoint to PDF conversion operation in which multiple PDFs based on different compliance standards are obtained:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    
    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    pres.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    pres.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    pres.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides support for PDF conversion operations extends to allowing you allow convert PDF to the most popular file formats. You can do [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), and [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) conversions. Other PDF conversion operations to specialized formats—[PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), and [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—are also supported.

{{% /alert %}}

