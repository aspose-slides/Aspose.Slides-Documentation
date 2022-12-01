---
title: Convert PowerPoint to PDF in C++
linktitle: Convert PowerPoint to PDF
type: docs
weight: 40
url: /cpp/convert-powerpoint-to-pdf/
keywords: "C++ PowerPoint to PDF Conversions, Convert PowerPoint, Presentation, PowerPoint to PDF, PPT to PDF, PPTX to PDF, Save PowerPoint as PDF, PDF/A1a, PDF/A1b, PDF/UA, CPP, C++"
description: "Convert PowerPoint Presentation to PDF in C++. Save PowerPoint as PDF with compliance or accessibility standards"
---
## **Overview**

This article explains how you can convert PowerPoint file formats into PDF using C++. It covers wide range of topics e.g.

- [Convert PPT to PDF in C++](#cpp-ppt-to-pdf)
- [Convert PPTX to PDF in C++](#cpp-pptx-to-pdf)
- [Convert ODP to PDF in C++](#cpp-odp-to-pdf)
- [Convert PowerPoint to PDF in C++](#cpp-powerpoint-to-pdf)

## **C++ PowerPoint to PDF Conversions**

Using Aspose.Slides, you can convert presentations in these formats to PDF:

* PPT
* PPTX
* ODP

To convert a presentation to PDF, you simply have to pass the file name as an argument in the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) class and then save the presentation as a PDF using a [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) method. The [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) class exposes the [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) method that is typically used to convert a presentation to PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ directly writes API information and Version Number in output documents. For example, when it converts a presentation to PDF, Aspose.Slides for C++ populates the Application field with the '*Aspose.Slides*' value and the PDF Producer field with a value in '*Aspose.Slides v XX.XX*'  form. **Note** that you cannot instruct Aspose.Slides for C++ to change or remove this information from output documents.

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

<a name="cpp-powerpoint-to-pdf" id="cpp-powerpoint-to-pdf"><strong>Steps: Convert PowerPoint to PDF in C++</strong></a> |
<a name="cpp-ppt-to-pdf" id="cpp-ppt-to-pdf"><strong>Steps: Convert PPT to PDF in C++</strong></a> |
<a name="cpp-pptx-to-pdf" id="cpp-pptx-to-pdf"><strong>Steps: Convert PPTX to PDF in C++</strong></a> |
<a name="cpp-odp-to-pdf" id="cpp-odp-to-pdf"><strong>Steps: Convert ODP to PDF in C++</strong></a>

This C++ code shows you how to convert a PowerPoint to PDF:

```c++
// Instantiates a Presentation class that represents a PowerPoint file
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.ppt");

// Saves the presentation as a PDF
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose provides a free online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) that demonstrates the presentation to PDF conversion process. For a live implementation of the procedure described here, you can do a test with the converter.

{{% /alert %}}

## **Convert PowerPoint to PDF with Options**

Aspose.Slides provides custom options—properties under the [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/) class—that allow you to customize the PDF (resulting from the conversion process), lock the PDF with a password, or even specify how the conversion process should go.

### **Convert PowerPoint to PDF with Custom Options**

Using custom conversion options, you can set your preferred quality setting for JPG images, specify how metafiles should be handled, set a compression level for texts, etc.

This C++ code demonstrates an operation in which a PowerPoint is converted to PDF with several custom options:

```c++
// Instantiates a Presentation class that represents a PowerPoint file
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// Instantiates the PdfOptions class
auto pdfOptions = System::MakeObject<PdfOptions>();

// Sets the Jpeg quality
pdfOptions->set_JpegQuality(90);

// Sets the behavior for metafiles
pdfOptions->set_SaveMetafilesAsPng(true);

// Sets the text compression level
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Defines the PDF standard
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Saves the presentation as a PDF
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
```

### **Convert PowerPoint to PDF with Hidden Slides**

If a presentation contains hidden slides, you can use a custom option—the [ShowHiddenSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options#ad11e5a17110d70456df91cc1a5dade23) property from the [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/) class—to instruct Aspose.Slides to include the hidden slides as pages in the resulting PDF.

This C++ code shows you how to convert a PowerPoint presentation to PDF with hidden slides included:

```c++
// Instantiates a Presentation class that represents a PowerPoint file
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// Instantiates the PdfOptions class
auto pdfOptions = System::MakeObject<PdfOptions>();

// Adds hidden slides
pdfOptions->set_ShowHiddenSlides(true);

// Saves the presentation as a PDF
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
```

### **Convert PowerPoint to Password Protected PDF**


This C++ code shows you how to convert a PowerPoint to a password-protected PDF (using protection parameters from the [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/) class):

```c++
// Instantiates a Presentation object that represents a PowerPoint file
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

/// Instantiates the PdfOptions class
auto pdfOptions = System::MakeObject<PdfOptions>();

// Sets PDF password and access permissions
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Saves the presentation as a PDF
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
```

## **Convert Selected Slides in PowerPoint to PDF**

This C++ code shows you how to convert specific slides in a PowerPoint presentation to PDF:

```C++
// Instantiates a Presentation object that represents a PowerPoint file
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// Sets an array of slides positions
auto slides = System::MakeArray<int32_t>({1, 3});

// Saves the presentation as a PDF
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
```

## **Convert PowerPoint to PDF with Custom Slide Size**

This C++ code shows you how to convert a PowerPoint when its slide size is specified to a PDF:

```C++
// The path to the documents directory.
String dataDir = GetDataPath()

// Instantiates a Presentation object that represents a PowerPoint file 
auto presentation = System::MakeObject<Presentation>(dataDir + u"SelectedSlides.pptx");
auto auxPresentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auxPresentation->get_Slides()->InsertClone(0, slide);

// Sets the slide type and size 
auxPresentation->get_SlideSize()->SetSize(612.F, 792.F, SlideSizeScaleType::EnsureFit);

auto pdfOptions = System::MakeObject<PdfOptions>();
auto options = pdfOptions->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

auxPresentation->Save(dataDir + u"PDFnotes_out.pdf", SaveFormat::Pdf, pdfOptions);
```

## **Convert PowerPoint to PDF in Notes Slide View**

This C++ code shows you how to convert a PowerPoint to PDF notes:

```C++
// The path to the documents directory.
System::String dataDir = u"";

// Instantiates a Presentation class that represents a PowerPoint file
auto presentation = System::MakeObject<Presentation>(dataDir + u"NotesFile.pptx");

auto pdfOptions = System::MakeObject<PdfOptions>();
auto options = pdfOptions->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Saves the presentation to PDF notes
presentation->Save(dataDir + u"Pdf_Notes_out.tiff", SaveFormat::Pdf, pdfOptions);
```

## **Accessibility and Compliance Standards for PDF**

Aspose.Slides allows you to use a conversion procedure that complies with [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). You can export a PowerPoint document to PDF using any of these compliance standards: **PDF/A1a**, **PDF/A1b**, and **PDF/UA**.

This C++ code demonstrates a PowerPoint to PDF conversion operation in which multiple PDFs based on different compliance standards are obtained:

```C++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = System::MakeObject<PdfOptions>();
pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
pres->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = System::MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
pres->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = System::MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);
pres->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);
```
