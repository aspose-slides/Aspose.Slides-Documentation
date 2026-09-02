---
title: Import Presentations from PDF or HTML in C++
linktitle: Import Presentation
type: docs
weight: 60
url: /cpp/import-presentation/
keywords:
- import presentation
- import slide
- import PDF
- import HTML
- PDF to presentation
- PDF to PPT
- PDF to PPTX
- PDF to ODP
- HTML to presentation
- HTML to PPT
- HTML to PPTX
- HTML to ODP
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Learn how to import PDF and HTML content into PowerPoint presentations in C++ with Aspose.Slides and save the results as PPTX files."
---

## **Introduction**

Aspose.Slides for C++ can turn PDF pages or HTML content into PowerPoint slides without Microsoft PowerPoint. The [SlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/) class provides [AddFromPdf](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/addfrompdf/) and [AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/addfromhtml/) for appending imported content to a presentation.

For more control over HTML placement, [SlideCollection::InsertFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/insertfromhtml/) can insert generated slides at a collection index or begin filling available space on an existing slide. Long HTML is paginated across additional slides automatically, the source can be supplied as a string, text reader, or stream, and external assets can be loaded through [IExternalResourceResolver](https://reference.aspose.com/slides/cpp/aspose.slides.import/iexternalresourceresolver/) with a base URI. The returned array of [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) objects identifies the affected and newly created slides.

## **Import from PDF**

To convert a PDF document to a PowerPoint presentation, import its content into the slide collection and save the result as a PPTX file.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Create a new [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) object.
2. Call [AddFromPdf](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/addfrompdf/) with the path to the PDF file.
3. Call [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) with [SaveFormat::Pptx](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveformat/) to write the presentation to a PPTX file.

The following C++ example imports a PDF document and saves the generated slides as a PowerPoint presentation:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->AddFromPdf(u"document.pdf");
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

The [AddFromPdf](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/addfrompdf/) method returns the slides it adds, which is useful when you need to process only the imported slides.

{{% alert title="Tip" color="success" %}}

Try the free [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) web app to see this conversion workflow in action.

{{% /alert %}}

## **Import from HTML**

Aspose.Slides can also create slides from an HTML document. The source can be supplied as HTML text, a text reader, or a stream. The following steps use a file stream:

1. Create a new [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) object.
2. Open the HTML file for reading and pass the stream to [AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/addfromhtml/).
3. Call [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) with [SaveFormat::Pptx](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveformat/) to write the result to a PPTX file.

The following C++ example imports an HTML document and saves the generated slides as a PowerPoint presentation:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace System;
using namespace System::IO;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto htmlStream = File::OpenRead(u"page.html");
presentation->get_Slides()->AddFromHtml(htmlStream);
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Insert HTML Content**

Use [SlideCollection::InsertFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/insertfromhtml/) when HTML-generated slides must be placed at a specific position instead of appended. The index is zero-based and identifies the position at which the import starts. The method is also available through [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/).

The `useSlideWithIndexAsStart` argument controls how the importer uses that position:

- When it is `false`, the importer creates new slides at the specified index and shifts the slides that follow them.
- When it is `true`, the importer starts placing content in the available space on the existing slide at that index. If the HTML does not fit, Aspose.Slides paginates it automatically and inserts additional slides immediately after the starting slide.

[SlideCollection::InsertFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/insertfromhtml/) returns an array of [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) objects. When insertion starts on new slides, every returned item is newly created. When an existing slide is used as the start, the array includes that affected slide followed by any new overflow slides. You can inspect this array instead of calculating the affected range from the presentation's slide count.

### **Insert HTML as New Slides**

The following example supplies HTML as a string and inserts the generated slides at collection index `1`. Passing `false` leaves the existing slides unchanged except for shifting them to make room.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto insertIndex = 1;
String html = u"<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>";
auto insertedSlides = presentation->get_Slides()->InsertFromHtml(insertIndex, html, false);

for (const auto& slide : insertedSlides)
{
    auto slideIndex = presentation->get_Slides()->IndexOf(slide);
    Console::WriteLine(String::Format(u"Inserted slide index: {0}", slideIndex));
}

presentation->Save(u"presentation-with-inserted-html.pptx", SaveFormat::Pptx);
```

### **Start on an Existing Slide**

The next example supplies the HTML through a stream. It keeps a header shape on the existing template slide, starts importing below the occupied area, and lets the long body continue onto new slides.

The HTML also contains a relative image URL. An [IExternalResourceResolver](https://reference.aspose.com/slides/cpp/aspose.slides.import/iexternalresourceresolver/) obtains the resource, while the base URI tells the importer how to resolve `images/logo.png`. In this example, that file is expected at `html-assets/images/logo.png`.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Import/ExternalResourceResolver.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/text/encoding.h>
#include <system/uri.h>

using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;

auto presentation = MakeObject<Presentation>();
auto templateSlide = presentation->get_Slide(0);
auto header = templateSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 680, 60);
header->get_TextFrame()->set_Text(u"Product roadmap");

String html = u"<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>";
for (auto itemIndex = 1; itemIndex <= 60; itemIndex++)
{
    html += String::Format(u"<p style='font-size:24pt'>Roadmap item {0}: detailed implementation notes.</p>", itemIndex);
}
html += u"</body></html>";

auto htmlData = Encoding::get_UTF8()->GetBytes(html);
auto htmlStream = MakeObject<MemoryStream>(htmlData);
auto resolver = MakeObject<ExternalResourceResolver>();
String basePath = Path::GetFullPath(u"html-assets") + Path::DirectorySeparatorChar;
String baseUri = MakeObject<Uri>(basePath)->get_AbsoluteUri();
auto affectedSlides = presentation->get_Slides()->InsertFromHtml(0, htmlStream, resolver, baseUri, true);

for (const auto& slide : affectedSlides)
{
    auto slideIndex = presentation->get_Slides()->IndexOf(slide);
    Console::WriteLine(String::Format(u"Affected slide index: {0}", slideIndex));
}

presentation->Save(u"presentation-with-html-overflow.pptx", SaveFormat::Pptx);
```

{{% alert title="Warning" color="warning" %}}

An unrestricted external resource resolver can read local or network resources referenced by the HTML. For untrusted input, implement [IExternalResourceResolver](https://reference.aspose.com/slides/cpp/aspose.slides.import/iexternalresourceresolver/) with an allowlist for permitted schemes, directories, and hosts, and reject all other URIs.

{{% /alert %}}

## **FAQ**

**Can Aspose.Slides detect tables when importing a PDF?**

Yes. Create a [PdfImportOptions](https://reference.aspose.com/slides/cpp/aspose.slides.import/pdfimportoptions/) object, call [PdfImportOptions::set_DetectTables](https://reference.aspose.com/slides/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) with `true`, and pass the options to [AddFromPdf](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/addfrompdf/). The quality of table recognition depends on the structure and complexity of the source PDF.

{{% alert title="Note" color="info" %}}

You can also use Aspose.Slides to convert HTML content to other formats:

- [HTML to image](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
- [HTML to JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
- [HTML to XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
- [HTML to TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}
