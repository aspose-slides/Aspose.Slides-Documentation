---
title: Get Paragraph Bounds from Presentations in Python via Java
linktitle: Paragraph Bounds
type: docs
weight: 43
url: /python-java/paragraph-bounds/
keywords:
- paragraph bounds
- paragraph coordinate
- paragraph size
- text frame
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Learn how to retrieve paragraph bounds in Aspose.Slides for Python via Java to optimize text positioning in PowerPoint presentations."
---

## **Overview**

This article explains how to get the bounds, size, and coordinates of paragraphs in Aspose.Slides. It shows how to retrieve a paragraph rectangle from a [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) by using [Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect), how to get paragraph coordinates inside a table cell text frame, and highlights important details such as measurement units, the effect of text wrapping on bounds, pixel conversion, and effective paragraph formatting values.

## **Get Rectangular Coordinates of a Paragraph**

Use [Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect) to get the bounding rectangle of a paragraph.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **Get the Size of a Paragraph Inside a Table Cell Text Frame**

To get the size and coordinates of a [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) in a table cell text frame, use [Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect). The returned rectangle is relative to the table cell text frame, so add the table position and cell offset when you need slide-level coordinates.

The following example gets paragraph bounds inside a table cell and draws rectangles on the slide to visualize those bounds:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**In what units are paragraph coordinates measured?**

They are measured in points, where 1 inch equals 72 points. This applies to all coordinates and dimensions on the slide.

**Does word wrapping affect a paragraph's bounds?**

Yes. If [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) is enabled for the [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/), the text breaks to fit the area width, which changes the paragraph's actual bounds.

**Can paragraph coordinates be reliably mapped to pixels in the exported image?**

Yes. Convert points to pixels using this formula: pixels = points x (DPI / 72). The result depends on the DPI chosen for rendering or export.

**How do I get the "effective" paragraph formatting parameters, taking style inheritance into account?**

Use the [effective paragraph formatting data structure](/slides/python-java/shape-effective-properties/); it returns the final consolidated values for indents, spacing, wrapping, RTL, and more.
