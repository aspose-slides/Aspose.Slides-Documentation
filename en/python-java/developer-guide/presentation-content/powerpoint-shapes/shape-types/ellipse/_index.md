---
title: Add Ellipses to Presentations in Python via Java
linktitle: Ellipse
type: docs
weight: 30
url: /python-java/ellipse/
keywords:
- ellipse
- shape
- add ellipse
- create ellipse
- draw ellipse
- formatted ellipse
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Learn how to create, format, and manipulate ellipse shapes in Aspose.Slides for Python via Java across PPT and PPTX presentations—Python code examples included."
---

## **Overview**

This article shows how to add ellipse shapes to PowerPoint slides by using Aspose.Slides. It covers creating a simple ellipse, creating a formatted ellipse, and saving the updated presentation as a PPTX file. It also touches on related questions such as working with ellipse position and size, controlling stacking order, and applying animation effects.

## **Create an Ellipse**

To add a simple ellipse to a selected slide of the presentation, follow the steps below:

- Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
- Get a reference to a slide by its index.
- Add an ellipse using the [addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) method of the [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) object.
- Write the modified presentation as a PPTX file.

The following example adds an ellipse to the first slide:

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

    # Add an ellipse shape.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Write the PPTX file to disk.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Create a Formatted Ellipse**

To add a formatted ellipse to a slide, follow the steps below:

- Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
- Get a reference to a slide by its index.
- Add an ellipse using the [addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) method of the [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) object.
- Set the ellipse's fill type to solid.
- Set the ellipse's fill color through [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) on the [FillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/) object associated with the [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) object.
- Set the color of the ellipse's outline.
- Set the width of the ellipse's outline.
- Write the modified presentation as a PPTX file.

The following example adds a formatted ellipse to the first slide of the presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Instantiate the Presentation class that represents the PPTX file.
presentation = Presentation()
try:
    # Get the first slide.
    slide = presentation.getSlides().get_Item(0)

    # Add an ellipse shape.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Format the ellipse's fill.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # Format the ellipse's outline.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # Write the PPTX file to disk.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**How do I set the exact position and size of an ellipse with respect to the slide's units?**

Coordinates and sizes are typically specified **in points**. For predictable results, base your calculations on the slide size and convert required millimeters or inches to points before assigning values.

**How can I place an ellipse above or below other objects (control stacking order)?**

Adjust the drawing order of the object by bringing it to the front or sending it to the back. This lets the ellipse overlap other objects or reveal those beneath it.

**How do I animate the appearance or emphasis of an ellipse?**

[Apply](/slides/python-java/shape-animation/) entrance, emphasis, or exit effects to the shape, and configure triggers and timing to orchestrate when and how the animation plays.
