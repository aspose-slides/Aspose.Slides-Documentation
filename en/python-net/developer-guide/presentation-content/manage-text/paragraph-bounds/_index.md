---
title: Get Paragraph Bounds from Presentations in Python
linktitle: Paragraph Bounds
type: docs
weight: 43
url: /python-net/paragraph-bounds/
keywords:
- paragraph bounds
- paragraph coordinate
- paragraph size
- text frame
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to retrieve paragraph bounds in Aspose.Slides for Python via .NET to optimize text positioning in PowerPoint and OpenDocument presentations."
---

## **Overview**

This article explains how to get the bounds, size, and coordinates of paragraphs in Aspose.Slides. It shows how to retrieve a paragraph rectangle from a [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) by using [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/), how to get paragraph coordinates inside a table cell text frame, and highlights important details such as measurement units, the effect of text wrapping on bounds, pixel conversion, and effective paragraph formatting values.

## **Get Rectangular Coordinates of a Paragraph**

Use [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) to get the bounding rectangle of a paragraph.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **Get the Size of a Paragraph Inside a Table Cell TextFrame**

To get the size and coordinates of a [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) in a table cell text frame, use [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/). The returned rectangle is relative to the table cell text frame, so add the table position and cell offset when you need slide-level coordinates.

The following example gets paragraph bounds inside a table cell and draws rectangles on the slide to visualize those bounds:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**In what units are paragraph coordinates measured?**

They are measured in points, where 1 inch equals 72 points. This applies to all coordinates and dimensions on the slide.

**Does word wrapping affect a paragraph's bounds?**

Yes. If [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) is enabled for the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), the text breaks to fit the area width, which changes the paragraph's actual bounds.

**Can paragraph coordinates be reliably mapped to pixels in the exported image?**

Yes. Convert points to pixels using this formula: pixels = points x (DPI / 72). The result depends on the DPI chosen for rendering or export.

**How do I get the "effective" paragraph formatting parameters, taking style inheritance into account?**

Use the [effective paragraph formatting data structure](/slides/python-net/shape-effective-properties/); it returns the final consolidated values for indents, spacing, wrapping, RTL, and more.
