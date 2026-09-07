---
title: Convert PowerPoint Presentations in Handout Mode Using Python
linktitle: Handout Mode
type: docs
weight: 150
url: /python-java/convert-powerpoint-in-handout-mode/
keywords:
- convert PowerPoint
- convert presentation
- handout mode
- handout
- PPT
- PPTX
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Convert PowerPoint presentations to handouts in Python via Java. Arrange multiple slides per page and export to PDF with Aspose.Slides."
---

## **Introduction**

Aspose.Slides for Python via Java allows you to export presentations in handout mode, arranging multiple slides on a single page. This is useful for printing presentation materials for conferences, seminars, and similar events.

Configure the layout through the [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) method. Handout layouts are supported by [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/python-java/aspose.slides/htmloptions/), and [TiffOptions](https://reference.aspose.com/slides/python-java/aspose.slides/tiffoptions/). Use a [HandoutLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/handoutlayoutingoptions/) object to specify the layout and display settings.

## **Handout Mode Export**

To export a presentation in handout mode, create a [HandoutLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/handoutlayoutingoptions/) instance and assign it to the target export options using [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

The following example loads `sample.pptx` and exports it to PDF with four slides per page in horizontal order. It includes slide numbers and frames around the slides, and excludes comments.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Load a presentation.
presentation = Presentation("sample.pptx")
try:
    # Configure the handout layout.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Export the presentation to PDF with the chosen layout.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}

Handout layout settings apply to supported output formats, such as PDF, HTML, TIFF, and rendered images. They do not rearrange slides in the source presentation.

{{% /alert %}}

## **FAQ**

**What is the maximum number of slide thumbnails per page in handout mode?**

Aspose.Slides supports up to nine thumbnails per page. The [HandoutType](https://reference.aspose.com/slides/python-java/aspose.slides/handouttype/) presets provide one, two, three, four, six, or nine slides per page. The four-, six-, and nine-slide presets offer horizontal and vertical ordering.

**Can I define a custom grid, such as five or eight slides per page?**

No. The number and ordering of thumbnails are controlled by the predefined [HandoutType](https://reference.aspose.com/slides/python-java/aspose.slides/handouttype/) values. Arbitrary grids are not supported by these handout layout settings.

**Can I include hidden slides in the handout output?**

Yes. Enable hidden slides in the export settings for the target format. For PDF, call [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) with `True` before saving the presentation.
