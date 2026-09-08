---
title: Import Presentations from PDF or HTML in Python via Java
linktitle: Import Presentation
type: docs
weight: 60
url: /python-java/import-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Learn how to import PDF and HTML content into PowerPoint presentations in Python via Java with Aspose.Slides and save the results as PPTX files."
---

## **Introduction**

Aspose.Slides for Python via Java can turn PDF pages or HTML content into PowerPoint slides without Microsoft PowerPoint. The [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) class provides [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) and [addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromHtml) for appending imported content to a presentation.

For more control over HTML placement, [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml) can insert generated slides at a collection index or begin filling available space on an existing slide. Long HTML is paginated across additional slides automatically, the source can be supplied as a string or stream, and external assets can be loaded through [ExternalResourceResolver](https://reference.aspose.com/slides/python-java/aspose.slides/externalresourceresolver/) with a base URI. The returned [Slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) array identifies the affected and newly created slides.

## **Import from PDF**

To convert a PDF document to a PowerPoint presentation, import its content into the slide collection and save the result as a PPTX file.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Create a new [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) object.
2. Call [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) with the path to the PDF file.
3. Call [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) with [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) to write the presentation to a PPTX file.

The following Python example imports a PDF document and saves the generated slides as a PowerPoint presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The default blank slide remains in the presentation because the import appends slides. To keep only imported pages, clear the slide collection with [SlideCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#clear) before importing.

The [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) method returns the slides it adds, which is useful when you need to process only the imported slides.

{{% alert title="Tip" color="success" %}}

Try the free [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) web app to see this conversion workflow in action.

{{% /alert %}}

## **Import from HTML**

Aspose.Slides can also create slides from an HTML document. The source can be supplied as HTML text or a stream. The following steps use a file stream:

1. Create a new [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) object.
2. Open the HTML file for reading and pass the stream to [addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromHtml).
3. Call [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) with [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) to write the result to a PPTX file.

The following Python example imports an HTML document and saves the generated slides as a PowerPoint presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Insert HTML Content**

Use [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml) when HTML-generated slides must be placed at a specific position instead of appended. The index is zero-based and identifies the position at which the import starts.

The `useSlideWithIndexAsStart` argument controls how the importer uses that position:

- When it is `False`, the importer creates new slides at the specified index and shifts the slides that follow them.
- When it is `True`, the importer starts placing content in the available space on the existing slide at that index. If the HTML does not fit, Aspose.Slides paginates it automatically and inserts additional slides immediately after the starting slide.

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml) returns an array of [Slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) objects. When insertion starts on new slides, every returned item is newly created. When an existing slide is used as the start, the array includes that affected slide followed by any new overflow slides. You can inspect this array instead of calculating the affected range from the presentation's slide count.

### **Insert HTML as New Slides**

The following example supplies HTML as a string and inserts the generated slides at collection index `1`. Passing `False` leaves the existing slides unchanged except for shifting them to make room.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Start on an Existing Slide**

The next example supplies the HTML through a stream. It keeps a header shape on the existing template slide, starts importing below the occupied area, and lets the long body continue onto new slides.

The HTML also contains a relative image URL. An [ExternalResourceResolver](https://reference.aspose.com/slides/python-java/aspose.slides/externalresourceresolver/) obtains the resource, while the base URI tells the importer how to resolve `images/logo.png`. In this example, that file is expected at `html-assets/images/logo.png`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}

An unrestricted external resource resolver can read local or network resources referenced by the HTML. For untrusted input, validate and sanitize resource URLs against an allowlist of permitted schemes, directories, and hosts before importing the HTML.

{{% /alert %}}

## **FAQ**

**Can Aspose.Slides detect tables when importing a PDF?**

Yes. Create a [PdfImportOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfimportoptions/) object, call [setDetectTables](https://reference.aspose.com/slides/python-java/aspose.slides/pdfimportoptions/#setDetectTables) with `True`, and pass the options to [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf). The quality of table recognition depends on the structure and complexity of the source PDF.

{{% alert title="Note" color="info" %}}

After importing HTML, you can also export the slides to [images](/slides/python-java/convert-powerpoint-to-png/), [TIFF](/slides/python-java/convert-powerpoint-to-tiff/), or [SVG](/slides/python-java/render-slide-as-svg/).

{{% /alert %}}
