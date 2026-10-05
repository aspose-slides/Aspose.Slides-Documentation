---
title: Convert PPT and PPTX to PDF in C++ [Advanced Features Included]
linktitle: PowerPoint to PDF
type: docs
weight: 40
url: /cpp/convert-powerpoint-to-pdf/
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
- C++
- Aspose.Slides
description: "Convert PowerPoint PPT/PPTX to high-quality, searchable PDFs in C++ using Aspose.Slides, with fast code examples and advanced conversion options."
---

## **Overview**

Converting PowerPoint presentations (PPT, PPTX, ODP, etc.) into PDF format in C++ offers several advantages, including compatibility across different devices and preserving the layout and formatting of your presentation. This guide demonstrates how to convert presentations to PDF documents, use various options to control image quality, include hidden slides, password-protect PDF files, detect font substitutions, select specific slides for conversion, and apply compliance standards to output documents.

## **PowerPoint to PDF Conversions**

Using Aspose.Slides, you can convert presentations in the following formats to PDF:

* **PPT**
* **PPTX**
* **ODP**

To convert a presentation to PDF, pass the file name as an argument to the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class and then save the presentation as a PDF using a [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) method. The [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class exposes the [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) method that is typically used to convert a presentation to PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for C++ inserts its API information and version number into output documents. For example, when converting a presentation to PDF, Aspose.Slides populates the Application field with "*Aspose.Slides*" and the PDF Producer field with a value in "*Aspose.Slides v XX.XX*" form. **Note** that you cannot instruct Aspose.Slides to change or remove this information from output documents.

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

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Aspose offers a free online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) that demonstrates the presentation-to-PDF conversion process. You can run a test with this converter for a live implementation of the procedure described here.

{{% /alert %}}

## **Convert PowerPoint to PDF with Options**

Aspose.Slides provides custom options—properties under the [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) class—that allow you to customize the resulting PDF, lock the PDF with a password, or specify how the conversion process should proceed.

### **Convert PowerPoint to PDF with Custom Options**

Using custom conversion options, you can define your preferred quality setting for raster images, specify how metafiles should be handled, set a compression level for text, configure DPI for images, and more.

The following example exports a presentation to PDF 1.5 with JPEG quality set to 90, image resolution set to 300 DPI, metafiles saved as PNG, and Flate text compression.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Preserve Embedded OLE Files as PDF Attachments**

If a presentation contains an embedded Excel workbook, you may want PDF recipients to access the workbook's data as well as view the slides. Call [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) with `true` to preserve embedded OLE files as attachments in the resulting PDF.

The default value is `false`: the OLE object's preview image or icon is rendered on the PDF page, but its embedded file is not included as an attachment. Setting the option to `true` additionally includes the file data. The preview remains a visual representation; the attachment lets recipients open or save the embedded file separately. The OLE object does not become an interactive Excel worksheet on the PDF page.

The following example loads a presentation that already contains an embedded Excel workbook and exports it to PDF with the workbook attached.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

To check the result:

1. Open the exported PDF in a viewer that supports file attachments, such as Adobe Acrobat Reader.
2. Open the viewer's **Attachments** panel and locate the embedded workbook.
3. Save the attachment and open it in Excel to inspect its data, or open it directly if the viewer permits it. The preview on the PDF page is separate from the attachment.

{{% alert color="info" title="Note" %}}

The PDF/A standards impose restrictions on attachments: PDF/A-1 prohibits embedded files, PDF/A-2 permits only PDF/A attachments, and PDF/A-3 permits other file types, including Excel workbooks. These are requirements of the standards, not restrictions specific to Aspose.Slides. This example uses the default PDF compliance setting and does not demonstrate PDF/A export.

{{% /alert %}}

### **Convert PowerPoint to PDF with Hidden Slides**

If a presentation contains hidden slides, you can use the [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) method from the [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) class to include the hidden slides as pages in the resulting PDF.

The following example exports a presentation to PDF, including any hidden slides.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Convert PowerPoint to a Password-Protected PDF**

The following example exports a presentation to a PDF that requires the password `password` to open. The access permissions allow printing, including high-quality printing.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Detect Font Substitutions**

Aspose.Slides provides the [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) method under the [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) class, enabling you to detect font substitutions during the presentation-to-PDF conversion process.

The following example exports a presentation to PDF and prints font substitution warnings to the console. A warning is printed only when an unavailable font is substituted during export.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

For more information on font substitution, see the [Font Substitution](/slides/cpp/font-substitution/) article.

{{% /alert %}} 

## **Convert Selected Slides from PowerPoint to PDF**

The following example exports slides 1 and 3 from a presentation to PDF. Slide numbers in this array are one-based, and the input presentation must contain at least three slides.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **Convert PowerPoint to PDF with Custom Slide Size**

The following example copies the first slide from a presentation into a new presentation with a slide size of 612 × 792 points (8.5 × 11 inches). It scales the slide content to fit and exports the single slide to PDF.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Convert PowerPoint to PDF in Notes Slide View**

The following example exports a presentation to PDF, placing each slide's speaker notes below the slide. Use a presentation containing speaker notes to see the result.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **Accessibility and Compliance Standards for PDF**

Aspose.Slides allows you to use a conversion procedure that complies with [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). You can export a PowerPoint document to PDF using any of these compliance standards: **PDF/A1a**, **PDF/A1b**, and **PDF/UA**.

This C++ code demonstrates a PowerPoint-to-PDF conversion process that produces multiple PDFs based on different compliance standards:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Aspose.Slides supports PDF conversion operations, allowing you to convert PDF files to popular file formats. You can perform [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), and [PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) conversions. Other PDF conversion operations to specialized formats—[PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), and [PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—are also supported.

{{% /alert %}}

> **Note:** When exporting to PDF/UA, Aspose.Slides treats complex graphics such as SmartArt, charts, and formulas as a single figure. Individual path elements are not preserved as separate content and may be marked as artifacts; alternative text is provided only for the whole figure.

## **FAQ**

**Can I convert multiple PowerPoint files to PDF in bulk?**

Yes, Aspose.Slides supports batch conversion of multiple PPT or PPTX files to PDF. You can iterate through your files and apply the conversion process programmatically.

**Is it possible to password-protect the converted PDF?**

Yes. Use the [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) class to set a password and define access permissions during the conversion process.

**How do I include hidden slides in the PDF?**

Use the [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) method in the [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) class to include hidden slides in the resulting PDF.

**Can Aspose.Slides maintain high image quality in the PDF?**

Yes, you can control image quality by using methods such as [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) and [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) in the [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) class to ensure high-quality images in your PDF.

**Does Aspose.Slides support PDF/A compliance standards?**

Yes, Aspose.Slides allows you to export PDFs that comply with various standards, including PDF/A1a, PDF/A1b, and PDF/UA, ensuring your documents meet accessibility and archival requirements.

## **Additional Resources**

- [Aspose.Slides for C++ Documentation](/slides/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)
