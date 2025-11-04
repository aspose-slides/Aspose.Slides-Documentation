---
title: Convert Presentations in Handout Mode with Python
linktitle: Handout Mode
type: docs
weight: 150
url: /python-net/convert-powerpoint-in-Handout-mode/
keywords:
- convert PowerPoint
- convert presentation
- handout mode
- handout
- PowerPoint
- presentation
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Convert presentations to handouts in Python. Set slides per page, keep notes, export to PDF or images with Aspose.Slides, with sample code. Try it free."
---

## **Handout Mode Export**

Aspose.Slides provides the ability to convert presentations into various formats, including creating handouts for printing in Handout mode. This mode allows you to configure how multiple slides appear on a single page, making it useful for conferences, seminars, and other events. You can enable this mode by setting the `slides_layout_options` property in the [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/), and [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) classes.

To configure Handout mode, use the [HandoutLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/handoutlayoutingoptions/) object, which determines how many slides are placed on a single page and other display parameters.

Below is a code example showing how to convert a presentation to PDF in Handout mode.

```py
# Load a presentation.
with slides.Presentation("sample.pptx") as presentation:

    # Set the export options.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 slides on one page horizontally
    slides_layout_options.print_slide_numbers = True                                 # print slide numbers
    slides_layout_options.print_frame_slide = True                                   # print a frame around slides
    slides_layout_options.print_comments = False                                     # no comments

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Export the presentation to PDF with the chosen layout.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 

Keep in mind that the `slides_layout_options` property is available only for certain output formats, such as PDF, HTML, TIFF, and when rendering as images.

{{% /alert %}} 

## **FAQ**

**What is the maximum number of slide thumbnails per page in Handout mode?**

Aspose.Slides supports [presets](https://reference.aspose.com/slides/python-net/aspose.slides.export/handouttype/) up to 9 thumbnails per page with horizontal or vertical ordering: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical), and 9 (horizontal/vertical).

**Can I define a custom grid, such as 5 or 8 slides per page?**

No. The number and ordering of thumbnails are controlled strictly by the [HandoutType](https://reference.aspose.com/slides/python-net/aspose.slides.export/handouttype/) enumeration; arbitrary layouts are not supported.

**Can I include hidden slides in the Handout output?**

Yes. Enable the `show_hidden_slides` option in the export settings for the target format, such as [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/), or [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/).
