---
title: Convert PowerPoint PPT(X) to PDF
type: docs
weight: 40
url: /java/convert-powerpoint-ppt-and-pptx-to-pdf/
keywords: "PPT and PPTX to PDF in Java"
description: "Convert PPT to PDF and PPTX to PDF. Convert PowerPoint to PDF document in Java."
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
   
   

## PowerPoint to PDF Conversion in Java

[**Aspose.Slides**](https://products.aspose.com/slides/java) allows you to convert files in PowerPoint PPT, PPTX, and OpenOffice ODP formats to PDF. 

To convert a presentation to PDF, simply pass the file name and save format to the [**Presentation.save**](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.io.OutputStream-int-) method. The [**Presentation**](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class exposes the [**save**](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.io.OutputStream-int-) method that can be called to convert the whole PPT, PPTX, or ODP presentation into a PDF document. The [**PdfOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.io.OutputStream-int-) class provides options for creating the PDF such as **JpegQuality**, **TextCompression**, **Compliance**, and others. These options can be used to get the desired standard in a PDF.

**Note**: Aspose.Slides for Java directly writes the information about API and Version Number in output documents. For example, when rendering Document to PDF, Aspose.Slides for Java populates the Application field with the value 'Aspose.Slides' and the PDF Producer field with a value, e.g. 'Aspose.Slides v 17.10'. Please note that you cannot instruct Aspose.Slides for Java to change or remove this information from output Documents.

{{% alert color="primary" %}} 

You can try our **free online demo apps** to test the [**PPT to PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), [**PPTX to PDF**](https://products.aspose.app/slides/conversion/pptx-to-pdf), [**ODP to PDF**](https://products.aspose.app/slides/conversion/odp-to-pdf) features by Aspose.

{{% /alert %}} 

## Accessibility and Compliance Standards for PDF

With Aspose.Slides, you can use a conversion procedure that complies with [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html).

When converting a PPT document to PDF, Aspose.Slides allows you to export a PPT document to the PDF format using any of these compliance standards: [**PDF/A1a**](https://apireference.aspose.com/slides/java/com.aspose.slides/PdfCompliance#PdfA1a), [**PDF/A1b**](https://apireference.aspose.com/slides/java/com.aspose.slides/PdfCompliance#PdfA1b), and [**PDF/UA**](https://apireference.aspose.com/slides/java/com.aspose.slides/PdfCompliance#PdfUa). 

This sample code shows you how to specify your preferred PDF compliance standard when converting PPT to PDF:

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

Aspose.Slides for Java typically exports the presentation documents to PDF and makes it as similar as possible to the original presentation document. Aspose.Slides renders most elements in a presentation when converting it to PDF:

- Images, Text Boxes, and other Shapes
- Text and Formatting
- Paragraphs and Formatting
- Hyperlinks
- Headers and Footers
- Bullets
- Tables

## **PPT to PDF Conversion Process Options**

Aspose.Slides for Java allows you to customize the presentation to PDF export with different options explained in this topic.

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

```java
// Instantiate a Presentation object that represents a PPT file
Presentation pres = new Presentation("PowerPoint.ppt");
try {
    // Save the presentation as PDF
    pres.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

## Convert PowerPoint to PDF with Custom Options
The following example shows you how to convert PowerPoint PPT, PPTX and OpenOffice ODP into a PDF document with customized options provided by the [**PdfOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/PdfOptions) class. It sets the JPEG quality, saves metafiles to PNG, sets text compression level with [**PdfTextCompression**](https://apireference.aspose.com/slides/java/com.aspose.slides/PdfTextCompression) enumeration and sets PDF standard.

```java
// Instantiate a Presentation object that represents a PPTX file
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Instantiate the PdfOptions class
    PdfOptions pdfOptions = new PdfOptions();
    
    // Set Jpeg quality
    pdfOptions.setJpegQuality((byte)90);
    
    // Set behavior for metafiles
    pdfOptions.setSaveMetafilesAsPng(true);
    
    // Set text compression level
    pdfOptions.setTextCompression(PdfTextCompression.Flate);
    
    // Define the PDF standard
    pdfOptions.setCompliance(PdfCompliance.Pdf15);
    
    // Save the presentation as PDF
    pres.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convert PowerPoint to PDF with Hidden Slides Included**
The following example shows how to convert a PowerPoint PPT, PPTX and OpenOffice ODP file into a PDF document with hidden slides included as provided by the [**PdfOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/PdfOptions) class. You can also include comments in generated HTML by using [**PdfOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/PdfOptions) class. 
It sets the ShowHiddenSlides property to generate PDF with hidden slides. 
Methods [**getShowHiddenSlides**](https://apireference.aspose.com/slides/java/com.aspose.slides/PdfOptions#getShowHiddenSlides--) and [**setShowHiddenSlides**](https://apireference.aspose.com/slides/java/com.aspose.slides/PdfOptions#setShowHiddenSlides-boolean-) have been added to [**IHtmlOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/IHtmlOptions), [**IPdfOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/IPdfOptions), [**ISwfOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISwfOptions), 
[**ITiffOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/ITiffOptions), [**IXpsOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/IXpsOptions) interfaces and [**HtmlOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/HtmlOptions), 
[**PdfOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/PdfOptions), [**SwfOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/SwfOptions), [**TiffOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/TiffOptions), [**XpsOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/XpsOptions) classes. 
This property specifies whether the exported document should include hidden slides or not. 
Default value is **"false"**.

```java
// Instantiate a Presentation object that represents a PPTX file
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Instantiate the PdfOptions class
    PdfOptions pdfOptions = new PdfOptions();
    
    // Include hidden slides
    pdfOptions.setShowHiddenSlides(true);
    
    // Save the presentation as PDF
    pres.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convert PowerPoint to Password Protected PDF**
The following example shows you how to convert a presentation to a password-protected PDF document with customized options provided by the [**PdfOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/PdfOptions) class.

```java
// Instantiate a Presentation object that represents a PPTX file
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    /// Instantiate the PdfOptions class
    PdfOptions pdfOptions = new PdfOptions();
    
    // Setting PDF password and access permissions
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);
    
    // Save the presentation as PDF
    pres.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convert Selected Slides of PowerPoint to PDF**
The following example shows you how to convert a specific presentation slide to a PDF document with custom options.

```java
// Instantiate a Presentation object that represents a PPTX file
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Setting array of slides positions
    int[] slides = { 1, 3 };
    
    // Save the presentation as PDF
    pres.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convert PowerPoint to PDF with Custom Slide Size**
The following example shows you how to convert a presentation to a PDF notes document with custom slide size. Here, each inch equals 72.

```java
// Instantiate a Presentation object that represents a presentation file 
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    Presentation outPres = new Presentation();
    try {
        ISlide slide = pres.getSlides().get_Item(0);

        outPres.getSlides().insertClone(0, slide);
        
        // Setting Slide Type and Size
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
The following example shows you how to convert a presentation to a PDF notes document:

```java
// Instantiate a Presentation object that represents a presentation file
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

