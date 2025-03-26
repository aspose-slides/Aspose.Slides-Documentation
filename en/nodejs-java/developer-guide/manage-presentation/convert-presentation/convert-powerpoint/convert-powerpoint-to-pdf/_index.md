---
title: Convert PPT and PPTX to PDF in JavaScript [Advanced Features Included]
linktitle: Convert PPT and PPTX to PDF
type: docs
weight: 40
url: /nodejs-java/convert-powerpoint-to-pdf/
keywords:
- convert PowerPoint
- convert presentation
- PowerPoint to PDF
- presentation to PDF
- PPT to PDF
- convert PPT to PDF
- PPTX to PDF
- convert PPTX to PDF
- ODP to PDF
- convert ODP to PDF
- save PowerPoint as PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- JavaScript
- Node.js
- Aspose.Slides for Node.js via Java
description: "Learn how to convert PPT, PPTX, and ODP presentations to PDF in JavaScript using Aspose.Slides. Implement advanced features like password protection, compliance standards, and custom options for high-quality, accessible PDF documents."
---

## **Overview**

Converting PowerPoint and OpenDocument presentations (PPT, PPTX, ODP, etc.) into PDF format in JavaScript offers several advantages, including compatibility across different devices and preserving the layout and formatting of your presentation. This guide demonstrates how to convert presentations to PDF documents, use various options to control image quality, include hidden slides, password-protect PDF files, detect font substitutions, select specific slides for conversion, and apply compliance standards to output documents.

## **PowerPoint to PDF Conversions**

Using Aspose.Slides, you can convert presentations in the following formats to PDF:

* **PPT**
* **PPTX**
* **ODP**

To convert a presentation to PDF, pass the file name as an argument to the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class and then save the presentation as a PDF using a `save` method. The [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class exposes the `save` method that is typically used to convert a presentation to PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Node.js via Java inserts its API information and version number into output documents. For example, when converting a presentation to PDF, Aspose.Slides populates the Application field with "*Aspose.Slides*" and the PDF Producer field with a value in "*Aspose.Slides v XX.XX*" form. **Note** that you cannot instruct Aspose.Slides to change or remove this information from output documents.

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

This code shows you how to convert a presentation (PPT, PPTX, ODP, etc.) to PDF:

```js
// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Save the presentation as a PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose offers a free online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) that demonstrates the presentation-to-PDF conversion process. You can run a test with this converter for a live implementation of the procedure described here.

{{% /alert %}}

## **Convert PowerPoint to PDF with Options**

Aspose.Slides provides custom options—properties under the [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) class—that allow you to customize the resulting PDF, lock the PDF with a password, or specify how the conversion process should proceed.

### **Convert PowerPoint to PDF with Custom Options**

Using custom conversion options, you can define your preferred quality setting for raster images, specify how metafiles should be handled, set a compression level for text, configure DPI for images, and more.

The code example below demonstrates how to convert a PowerPoint presentation to PDF with several custom options.

```js
// Instantiate the PdfOptions class.
let pdfOptions = new aspose.slides.PdfOptions();

// Set the quality for JPG images.
pdfOptions.setJpegQuality(java.newByte(90));

// Set DPI for images.
pdfOptions.setSufficientResolution(300);

// Set the behavior for metafiles.
pdfOptions.setSaveMetafilesAsPng(true);

// Set the text compression level for textual content.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Define the PDF compliance mode.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Save the presentation as a PDF document.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convert PowerPoint to PDF with Hidden Slides**

If a presentation contains hidden slides, you can use the [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) method from the [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) class to include the hidden slides as pages in the resulting PDF.

This JavaScript code shows how to convert a PowerPoint presentation to PDF with hidden slides included:

```js
// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instantiate the PdfOptions class.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Add hidden slides.
    pdfOptions.setShowHiddenSlides(true);

    // Save the presentation as a PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convert PowerPoint to Password Protected PDF**

This JavaScript code demonstrates how to convert a PowerPoint presentation into a password-protected PDF using the protection parameters from the [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) class:

```js
// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instantiate the PdfOptions class.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Set a PDF password and access permissions.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Save the presentation as a PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detect Font Substitutions**

Aspose.Slides provides the [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) method under the [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) class, enabling you to detect font substitutions during the presentation-to-PDF conversion process.

This JavaScript code shows how to detect font substitutions:

```js
// Set the warning callback in PDF options.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Save the presentation as a PDF.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```
```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```

{{%  alert color="primary"  %}} 

For more information on receiving callbacks for font substitutions during the rendering process, see [Getting Warning Callbacks for Fonts Substitution](/slides/nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

For more information on font substitution, see the [Font Substitution](/slides/nodejs-java/font-substitution/) article.

{{% /alert %}} 

## **Convert Selected Slides in PowerPoint to PDF**

This JavaScript code demonstrates how to convert only specific slides from a PowerPoint presentation to PDF:

```js
// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Set array of slide numbers.
    let slides = java.newArray("int", [1, 3]);

    // Save the presentation as a PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Convert PowerPoint to PDF with Custom Slide Size**

This JavaScript code demonstrates how to convert a PowerPoint presentation to PDF with a specified slide size:

```js
const slideWidth = 612;
const slideHeight = 792;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Set the custom slide size.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Clone the first slide from the original presentation.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Save the resized presentation to a PDF with notes.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Convert PowerPoint to PDF in Notes Slide View**

This JavaScript code demonstrates how to convert a PowerPoint presentation to a PDF that includes notes:

```js
// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Configure the PDF options with Notes Layout.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Save the presentation to a PDF with notes.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Accessibility and Compliance Standards for PDF**

Aspose.Slides allows you to use a conversion procedure that complies with [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). You can export a PowerPoint document to PDF using any of these compliance standards: **PDF/A1a**, **PDF/A1b**, and **PDF/UA**.

This JavaScript code demonstrates a PowerPoint-to-PDF conversion process that produces multiple PDFs based on different compliance standards:

```js
let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides supports PDF conversion operations, allowing you to convert PDF files to popular file formats. You can perform [PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), and [PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) conversions. Other PDF conversion operations to specialized formats—[PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)—are also supported.

{{% /alert %}}

## **Frequently Asked Questions**

1. **Can I convert multiple PowerPoint files to PDF in bulk?**

Yes, Aspose.Slides supports batch conversion of multiple PPT or PPTX files to PDF. You can iterate through your files and apply the conversion process programmatically.

2. **Is it possible to password-protect the converted PDF?**

Absolutely. Use the [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) class to set a password and define access permissions during the conversion process.

3. **How do I include hidden slides in the PDF?**

Use the `setShowHiddenSlides` method in the [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) class to include hidden slides in the resulting PDF.

4. **Can Aspose.Slides maintain high image quality in the PDF?**

Yes, you can control image quality by using methods such as `setJpegQuality` and `setSufficientResolution` in the [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) class to ensure high-quality images in your PDF.

5. **Does Aspose.Slides support PDF/A compliance standards?**

Yes, Aspose.Slides allows you to export PDFs that comply with various standards, including PDF/A1a, PDF/A1b, and PDF/UA, ensuring your documents meet accessibility and archival requirements.

## **Additional Resources**

- [Aspose.Slides for Node.js via Java Documentation](/slides/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Reference](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)
