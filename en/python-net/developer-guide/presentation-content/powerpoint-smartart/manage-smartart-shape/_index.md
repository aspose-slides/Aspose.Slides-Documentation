---
title: Manage SmartArt Graphics in Presentations Using Python
linktitle: SmartArt Graphics
type: docs
weight: 20
url: /python-net/manage-smartart-shape/
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
description: "Automate PowerPoint SmartArt creation, editing, and styling in Python via .NET using Aspose.Slides, featuring concise code examples and performance-focused guidance."
---

## **Create SmartArt Shapes**

Aspose.Slides for Python via .NET allows you to add custom SmartArt shapes to slides from scratch. The API makes this easy. To add a SmartArt shape to a slide:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get the target slide by its index.
1. Add a SmartArt shape, specifying its layout type.
1. Save the modified presentation as a PPTX file.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Access the presentation slide.
    slide = presentation.slides[0]
    # Add a SmartArt shape.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Save the presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Access SmartArt Shapes on Slides**

The following code demonstrates how to access SmartArt shapes on a slide. The sample iterates through each shape on the slide and checks whether it is a [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) object.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Load a presentation file.
with slides.Presentation("SmartArt.pptx") as presentation:
    # Iterate through every shape on the first slide.
    for shape in presentation.slides[0].shapes:
        # Check whether the shape is a SmartArt shape.
        if isinstance(shape, smartart.SmartArt):
            # Print the shape name.
            print("Shape name:", shape.name)
```

## **Access SmartArt Shapes with a Specified Layout Type**

The following example shows how to access a SmartArt shape with a specified layout type. Note that you cannot change a SmartArt’s layout type—it’s read-only and is set when the shape is created.

1. Create a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) instance and load the presentation that contains the SmartArt shape.
1. Get a reference to the first slide by index.
1. Iterate over every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) object.
1. If the SmartArt shape’s layout type matches the one you need, perform the required actions.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iterate through every shape on the first slide.
    for shape in presentation.slides[0].shapes:
        # Check whether the shape is a SmartArt shape.
        if isinstance(shape, smartart.SmartArt):
            # Check the SmartArt layout type.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```

## **Change the SmartArt Shape Style**

The following example shows how to locate SmartArt shapes and change their style:

1. Create a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) and load the file that contains the SmartArt shape(s).
1. Get a reference to the first slide by index.
1. Iterate over each shape on the first slide.
1. Find the SmartArt shape with the specified style.
1. Assign the new style to the SmartArt shape.
1. Save the presentation.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iterate through every shape on the first slide.
    for shape in presentation.slides[0].shapes:
        # Check whether the shape is a SmartArt shape.
        if isinstance(shape, smartart.SmartArt):
            # Check the SmartArt style.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # Change the SmartArt style.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # Save the presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Change the Color Style of SmartArt Shapes**

This example shows how to change the color style of a SmartArt shape. The sample code locates a SmartArt shape with a specified color style and updates it.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation that contains the SmartArt shape(s).
1. Get a reference to the first slide by index.
1. Iterate over each shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) object.
1. Locate the SmartArt shape with the specified color style.
1. Set the new color style for that SmartArt shape.
1. Save the presentation.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iterate through every shape on the first slide.
    for shape in presentation.slides[0].shapes:
        # Check whether the shape is a SmartArt shape.
        if isinstance(shape, smartart.SmartArt):
            # Check the color type.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Change the color type.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # Save the presentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I animate SmartArt as a single object?**

Yes. SmartArt is a shape, so you can apply [standard animations](/slides/python-net/powerpoint-animation/) via the animations API (entrance, exit, emphasis, motion paths) just like for other shapes.

**How can I find a specific SmartArt on a slide if I don’t know its internal ID?**

Set and use the Alternative Text (AltText) and search for the shape by that value—this is a recommended way to locate the target shape.

**Can I group SmartArt with other shapes?**

Yes. You can group SmartArt with other shapes (pictures, tables, etc.) and then [manipulate the group](/slides/python-net/group/).

**How do I get an image of a specific SmartArt (e.g., for a preview or report)?**

Export a thumbnail/image of the shape; the library can [render individual shapes](/slides/python-net/create-shape-thumbnails/) to raster files (PNG/JPG/TIFF).

**Will the SmartArt appearance be preserved when converting the whole presentation to PDF?**

Yes. The rendering engine targets high fidelity for [PDF export](/slides/python-net/convert-powerpoint-to-pdf/), with a range of quality and compatibility options.
