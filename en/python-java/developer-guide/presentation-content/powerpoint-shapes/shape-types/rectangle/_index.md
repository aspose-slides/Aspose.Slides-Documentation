---
title: Add Rectangles to Presentations in Python via Java
linktitle: Rectangle
type: docs
weight: 80
url: /python-java/rectangle/
keywords:
- add rectangle
- create rectangle
- rectangle shape
- simple rectangle
- formatted rectangle
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Boost your PowerPoint presentations by adding rectangles with Aspose.Slides for Python via Java—easily design and modify shapes programmatically."
---

## **Overview**

This article shows how to add rectangle shapes to PowerPoint slides by using Aspose.Slides. It covers creating a simple rectangle, creating a formatted rectangle, and saving the updated presentation as a PPTX file.

You will also see how to apply basic rectangle formatting, such as a solid fill color, line color, and line width. In addition, the article’s FAQ points to related rectangle tasks, including rounded corners, picture fills, visual effects, hyperlinks, shape locks, export options, and effective properties.

## **Add a Rectangle to a Slide**

To add a simple rectangle to a selected slide of the presentation, follow the steps below:

- Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
- Get a reference to a slide by its index.
- Add an [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) of rectangle type using the [addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) method exposed by the [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a simple rectangle to the first slide of the presentation.

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

    # Add a rectangle shape.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Write the PPTX file to disk.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Add a Formatted Rectangle to a Slide**

To add a formatted rectangle to a slide, follow the steps below:

- Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
- Get a reference to a slide by its index.
- Add an [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) of rectangle type using the [addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) method exposed by the [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) object.
- Set the [fill type](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) of the rectangle to solid.
- Set the rectangle's color using the [setColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setColor) method on the solid fill color of the [FillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/) object associated with the [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) object.
- Set the color of the rectangle's outline.
- Set the width of the rectangle's outline.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instantiate the Presentation class that represents the PPTX file.
presentation = Presentation()
try:
    # Get the first slide.
    slide = presentation.getSlides().get_Item(0)

    # Add a rectangle shape.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Format the rectangle's fill.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # Format the rectangle's outline.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # Write the PPTX file to disk.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**How do I add a rectangle with rounded corners?**

Use the rounded-corner [shape type](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/) and adjust the corner radius in the shape’s properties; rounding can also be applied per corner via geometry adjustments.

**How do I fill a rectangle with an image (texture)?**

Select the picture [fill type](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), provide the image source, and configure [stretching/tiling modes](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/).

**Can a rectangle have shadow and glow?**

Yes. [Outer/inner shadow, glow, and soft edges](/slides/python-java/shape-effect/) are available with adjustable parameters.

**Can I turn a rectangle into a button with a hyperlink?**

Yes. [Assign a hyperlink](/slides/python-java/manage-hyperlinks/) to the shape click (jump to a slide, file, web address, or e-mail).

**How can I protect a rectangle from moving and changes?**

[Use shape locks](/slides/python-java/applying-protection-to-presentation/): you can forbid moving, resizing, selection, or text editing to preserve the layout.

**Can I convert a rectangle to a raster image or SVG?**

Yes. You can [render the shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) to an image with a specified size/scale or [export it as SVG](/slides/python-java/create-shape-thumbnails/) for vector use.

**How do I quickly get the actual (effective) properties of a rectangle considering theme and inheritance?**

[Use the shape’s effective properties](/slides/python-java/shape-effective-properties/): the API returns computed values that account for theme styles, layout, and local settings, simplifying formatting analysis.
