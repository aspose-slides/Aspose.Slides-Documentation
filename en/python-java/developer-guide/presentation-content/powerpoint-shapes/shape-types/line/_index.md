---
title: Add Line Shapes to Presentations in Python via Java
linktitle: Line
type: docs
weight: 50
url: /python-java/line/
keywords:
- line
- create line
- add line
- plain line
- configure line
- customize line
- dash style
- arrow head
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Learn to manipulate line formatting in PowerPoint presentations with Aspose.Slides for Python via Java. Discover properties, methods, and examples."
---

## **Overview**

Aspose.Slides allows you to add line shapes to PowerPoint slides programmatically. This article shows how to create a simple line and how to customize a line so it appears as an arrow.

You will learn how to add a line shape to a slide, adjust its visual appearance, and save the updated presentation. The examples focus on practical line formatting settings such as style, width, dash pattern, arrowhead options, and fill color.

## **Create a Plain Line**

To add a simple line to a selected slide of the presentation, follow the steps below:

- Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
- Get a reference to a slide by its index.
- Add a line shape using the [addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) method of the [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) object.
- Write the modified presentation as a PPTX file.

The following example adds a line to the first slide of the presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instantiate the Presentation class that represents the PPTX file.
presentation = Presentation()
try:
    # Get the first slide.
    slide = presentation.getSlides().get_Item(0)

    # Add a line shape.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Write the PPTX file to disk.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Create an Arrow-Shaped Line**

Aspose.Slides for Python via Java also allows developers to configure line properties to make a line look more appealing. To configure a line to look like an arrow, follow the steps below:

- Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
- Get a reference to a slide by its index.
- Add a line shape using the [addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) method of the [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) object.
- Set the [line style](https://reference.aspose.com/slides/python-java/aspose.slides/linestyle/) to one of the styles offered by Aspose.Slides for Python via Java.
- Set the width of the line.
- Set the [dash style](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) to one of the styles offered by Aspose.Slides for Python via Java.
- Set the [arrowhead style](https://reference.aspose.com/slides/python-java/aspose.slides/linearrowheadstyle/) and [length](https://reference.aspose.com/slides/python-java/aspose.slides/linearrowheadlength/) at the start of the line.
- Set the [arrowhead style](https://reference.aspose.com/slides/python-java/aspose.slides/linearrowheadstyle/) and [length](https://reference.aspose.com/slides/python-java/aspose.slides/linearrowheadlength/) at the end of the line.
- Write the modified presentation as a PPTX file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# Instantiate the Presentation class that represents the PPTX file.
presentation = Presentation()
try:
    # Get the first slide.
    slide = presentation.getSlides().get_Item(0)

    # Add a line shape.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Apply formatting to the line.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # Write the PPTX file to disk.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

No. A regular line (an [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) of type [Line](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/)) does not automatically become a connector. To make it snap to shapes, use the dedicated [Connector](https://reference.aspose.com/slides/python-java/aspose.slides/connector/) type and the [corresponding APIs](/slides/python-java/connector/) for connections.

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Read the effective properties](/slides/python-java/shape-effective-properties/) of the line and its fill—these already account for inheritance and theme styles.

**Can I lock a line against editing (moving, resizing)?**

Yes. Shapes provide [lock objects](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getAutoShapeLock) that let you [disallow editing operations](/slides/python-java/applying-protection-to-presentation/).
