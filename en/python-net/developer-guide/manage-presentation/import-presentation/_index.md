---
title: Import Presentations from PDF or HTML in Python
linktitle: Import Presentation
type: docs
weight: 60
url: /python-net/import-presentation/
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
- Aspose.Slides
description: "Learn how to import PDF and HTML content into PowerPoint presentations in Python with Aspose.Slides for Python via .NET and save the results as PPTX files."
---

## **Introduction**

Aspose.Slides for Python via .NET can turn PDF pages or HTML content into PowerPoint slides without Microsoft PowerPoint. The [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) class provides [add_from_pdf](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_pdf/) and [add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_html/) for appending imported content to a presentation.

For more control over HTML placement, [SlideCollection.insert_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_from_html/) can insert generated slides at a collection index or begin filling available space on an existing slide. Long HTML is paginated across additional slides automatically, the source can be supplied as a string or stream, and external assets can be loaded through [IExternalResourceResolver](https://reference.aspose.com/slides/python-net/aspose.slides.importing/iexternalresourceresolver/) with a base URI. The returned [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) array identifies the affected and newly created slides.

## **Import from PDF**

To convert a PDF document to a PowerPoint presentation, import its content into the slide collection and save the result as a PPTX file.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Create a new [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object.
2. Call [add_from_pdf](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_pdf/) with the path to the PDF file.
3. Call [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) with [SaveFormat.PPTX](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveformat/) to write the presentation to a PPTX file.

The following Python example imports a PDF document and saves the generated slides as a PowerPoint presentation:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.add_from_pdf("document.pdf")
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

The [add_from_pdf](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_pdf/) method returns the slides it adds, which is useful when you need to process only the imported slides.

{{% alert title="Tip" color="success" %}}

Try the free [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) web app to see this conversion workflow in action.

{{% /alert %}}

## **Import from HTML**

Aspose.Slides can also create slides from an HTML document. The source can be supplied as HTML text or a stream. The following steps use a file stream:

1. Create a new [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object.
2. Open the HTML file for reading and pass the stream to [add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_html/).
3. Call [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) with [SaveFormat.PPTX](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveformat/) to write the result to a PPTX file.

The following Python example imports an HTML document and saves the generated slides as a PowerPoint presentation:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Insert HTML Content**

Use [SlideCollection.insert_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_from_html/) when HTML-generated slides must be placed at a specific position instead of appended. The index is zero-based and identifies the position at which the import starts. The method is also available through [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).

The `use_slide_with_index_as_start` argument controls how the importer uses that position:

- When it is `False`, the importer creates new slides at the specified index and shifts the slides that follow them.
- When it is `True`, the importer starts placing content in the available space on the existing slide at that index. If the HTML does not fit, Aspose.Slides paginates it automatically and inserts additional slides immediately after the starting slide.

[SlideCollection.insert_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_from_html/) returns an array of [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) objects. When insertion starts on new slides, every returned item is newly created. When an existing slide is used as the start, the array includes that affected slide followed by any new overflow slides. You can inspect this array instead of calculating the affected range from the presentation's slide count.

### **Insert HTML as New Slides**

The following example supplies HTML as a string and inserts the generated slides at collection index `1`. Passing `False` leaves the existing slides unchanged except for shifting them to make room.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.slides.insert_from_html(insert_index, html, False)

    for slide in inserted_slides:
        print(f"Inserted slide index: {presentation.slides.index_of(slide)}")

    presentation.save("presentation-with-inserted-html.pptx", slides.export.SaveFormat.PPTX)
```

### **Start on an Existing Slide**

The next example supplies the HTML through a stream. It keeps a header shape on the existing template slide, starts importing below the occupied area, and lets the long body continue onto new slides.

The HTML also contains a relative image URL. An [IExternalResourceResolver](https://reference.aspose.com/slides/python-net/aspose.slides.importing/iexternalresourceresolver/) obtains the resource, while the base URI tells the importer how to resolve `images/logo.png`. In this example, that file is expected at `html-assets/images/logo.png`.

```python
from io import BytesIO
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    template_slide = presentation.slides[0]
    header = template_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 680, 60)
    header.text_frame.text = "Product roadmap"

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_stream = BytesIO(html.encode("utf-8"))
    resolver = slides.importing.ExternalResourceResolver()
    base_uri = Path("html-assets").resolve().as_uri() + "/"
    affected_slides = presentation.slides.insert_from_html(0, html_stream, resolver, base_uri, True)

    for slide in affected_slides:
        print(f"Affected slide index: {presentation.slides.index_of(slide)}")

    presentation.save("presentation-with-html-overflow.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Warning" color="warning" %}}

An unrestricted external resource resolver can read local or network resources referenced by the HTML. For untrusted input, implement [IExternalResourceResolver](https://reference.aspose.com/slides/python-net/aspose.slides.importing/iexternalresourceresolver/) with an allowlist for permitted schemes, directories, and hosts, and reject all other URIs.

{{% /alert %}}

## **FAQ**

**Can Aspose.Slides detect tables when importing a PDF?**

Yes. Create a [PdfImportOptions](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/) object, set its [detect_tables](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) property to `True`, and pass the options to [add_from_pdf](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_pdf/). The quality of table recognition depends on the structure and complexity of the source PDF.

{{% alert title="Note" color="info" %}}

You can also use Aspose.Slides to convert HTML content to other formats:

- [HTML to image](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
- [HTML to JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
- [HTML to XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
- [HTML to TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}
