---
title: Manage SmartArt Graphics in Presentations Using Python
linktitle: SmartArt Graphics
type: docs
weight: 20
url: /python-java/manage-smartart-shape/
keywords:
- SmartArt object
- SmartArt graphic
- SmartArt style
- SmartArt color
- create SmartArt
- add SmartArt
- edit SmartArt
- change SmartArt
- access SmartArt
- SmartArt layout type
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Automate PowerPoint SmartArt creation, editing, and styling in Python using Aspose.Slides, featuring concise code examples and performance-focused guidance."
---

## **Overview**

Aspose.Slides allows you to create and manage SmartArt graphics in PowerPoint presentations programmatically. This article explains how to add a SmartArt shape to a slide, access existing SmartArt shapes, find SmartArt by a specific layout type, and update its visual appearance by changing the SmartArt style or color style.

The examples show how to work with SmartArt shapes through the presentation slide’s shape collection, check whether a shape is SmartArt and then modify or inspect its properties.

## **Create a SmartArt Shape**
Aspose.Slides for Python via Java provides an API to create SmartArt shapes. To create a SmartArt shape in a slide, please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Get a slide by its index.
1. [Add a SmartArt shape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) by specifying a [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/).
1. Save the modified presentation as a PPTX file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # Get the first slide.
    slide = presentation.getSlides().get_Item(0)

    # Add a SmartArt shape.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # Save the presentation.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: SmartArt shape added to the slide**|

## **Access a SmartArt Shape on a Slide**
The following example accesses SmartArt shapes on a presentation slide. It iterates through every shape on the slide and checks whether the shape is a [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) instance.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Iterate through every shape on the first slide.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **Access a SmartArt Shape with a Particular Layout Type**
The following example accesses a [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) shape with a particular layout type, returned by [SmartArt.getLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getLayout).

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) instance.
1. Check whether the SmartArt shape has the specified layout type and perform the required operation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Iterate through every shape on the first slide.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Check the SmartArt layout.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **Change a SmartArt Shape Style**
This example shows how to change the quick style of a SmartArt shape.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) instance.
1. Find the SmartArt shape with the specified style.
1. Set the new style for the SmartArt shape.
1. Save the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Iterate through every shape on the first slide.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Check and change the SmartArt style.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: SmartArt shape with changed style**|

## **Change a SmartArt Shape Color Style**
This example accesses a SmartArt shape with a particular color style and changes that style.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) instance.
1. Find the SmartArt shape with the specified color style.
1. Set the new color style for the SmartArt shape.
1. Save the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Iterate through every shape on the first slide.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Check and change the SmartArt style.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure: SmartArt shape with changed color style**|

## **FAQ**

**Can I animate SmartArt as a single object?**

Yes. SmartArt is a shape, so you can apply [standard animations](/slides/python-java/powerpoint-animation/) via the animations API (entrance, exit, emphasis, motion paths) just like for other shapes.

**How can I find a specific SmartArt on a slide if I don’t know its internal ID?**

Set and use the [alternative text](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) and search for the shape by that value—this is a recommended way to locate the target shape.

**Can I group SmartArt with other shapes?**

Yes. You can group SmartArt with other shapes (pictures, tables, etc.) and then [manipulate the group](/slides/python-java/group/).

**How do I get an image of a specific SmartArt (e.g., for a preview or report)?**

Export a thumbnail/image of the shape; the library can [render individual shapes](/slides/python-java/create-shape-thumbnails/) to raster files (PNG/JPG/TIFF).

**Will the SmartArt appearance be preserved when converting the whole presentation to PDF?**

Yes. The rendering engine targets high fidelity for [PDF export](/slides/python-java/convert-powerpoint-to-pdf/), with a range of quality and compatibility options.
