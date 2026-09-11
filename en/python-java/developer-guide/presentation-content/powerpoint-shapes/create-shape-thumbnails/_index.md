---
title: Create Thumbnails of Presentation Shapes in Python via Java
linktitle: Shape Thumbnails
type: docs
weight: 70
url: /python-java/create-shape-thumbnails/
keywords:
- shape thumbnail
- shape image
- render shape
- shape rendering
- visual bounds
- shape bounds
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Generate high-quality shape thumbnails from PowerPoint slides with Aspose.Slides for Python via Java – easily create and export presentation thumbnails."
---

## **Introduction**

Aspose.Slides for Python via Java can be used to create presentation files in which each page corresponds to a slide. The slides can be viewed by opening the presentation files using Microsoft PowerPoint. However, developers sometimes need to view the images of the shapes separately in an image viewer. In such cases, Aspose.Slides for Python via Java helps them generate thumbnail images of the slide shapes.

This article explains how to generate shape thumbnails in different ways:

- Generating a shape thumbnail inside a slide.
- Generating a shape thumbnail for a slide shape with user-defined dimensions.
- Generating a shape thumbnail in the bounds of a shape's appearance.

## **Generate a Shape Thumbnail from a Slide**
To generate a shape thumbnail from any slide using Aspose.Slides for Python via Java, do this:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Obtain a reference to a slide using its ID or index.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) of a shape on the referenced slide at the default scale.
1. Save the thumbnail image in your preferred image format.

This sample code shows you how to generate a shape thumbnail from a slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# Instantiate a Presentation class that represents the presentation file.
presentation = Presentation("Thumbnail.pptx")
try:
    # Create a full-scale image.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # Save the image to disk in PNG format.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Generate a Thumbnail with a User-Defined Scaling Factor**
To generate the shape thumbnail of a slide using Aspose.Slides for Python via Java, do this:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Obtain a reference to a slide using its ID or index.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) of a shape on the referenced slide with user-defined dimensions.
1. Save the thumbnail image in your preferred image format.

This sample code shows you how to generate a shape thumbnail based on a defined scaling factor:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Instantiate a Presentation class that represents the presentation file.
presentation = Presentation("Thumbnail.pptx")
try:
    # Create an image scaled by a factor of 2 in both directions.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # Save the image to disk in PNG format.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Create a Bounds-Based Shape Appearance Thumbnail**
This method of creating thumbnails of shapes allows developers to generate a thumbnail in the bounds of the shape's appearance. It takes into account all the shape effects. The generated shape thumbnail is restricted by the slide bounds. To generate a thumbnail of a slide shape within the bounds of its appearance, do this:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Obtain a reference to a slide using its ID or index.
1. Get the thumbnail image of a shape on the referenced slide using its appearance bounds.
1. Save the thumbnail image in your preferred image format.

This sample code is based on the steps above:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Instantiate a Presentation class that represents the presentation file.
presentation = Presentation("Thumbnail.pptx")
try:
    # Create a full-scale image.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # Save the image to disk in PNG format.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Get the Actual Visual Bounds of a Shape**

The frame properties of [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)—its [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getWidth), and [getHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHeight) methods—describe the rectangle stored in the presentation model. The content that is actually rendered can extend beyond that frame or occupy a different axis-aligned rectangle. Rotation, outlines, arrowheads, text layout and overflow, generated SmartArt geometry, and other rendering effects can all change the occupied area.

Use [Shape.getVisualBounds](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getVisualBounds) to calculate that occupied area without creating an image. The method returns a [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) in slide coordinates. The returned rectangle is not clipped to the slide, so its coordinates can be negative when content extends beyond the slide origin.

The following example gets and compares the frame and visual bounds:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

The same [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) can be used to align nearby shapes to its left, right, top, or bottom edge; reserve enough space in a generated layout; or detect content outside a permitted region. Visual bounds are especially useful for SmartArt, text boxes, arrows, pictures, rotated shapes, and group shapes, where the stored frame may not represent the full rendered result.

Use [Shape.getVisualBounds](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getVisualBounds) when you need coordinates for layout or validation and do not need a bitmap. Use [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) when you need to render the shape. With [ShapeThumbnailBounds](https://reference.aspose.com/slides/python-java/aspose.slides/shapethumbnailbounds/), [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shapethumbnailbounds/#Shape) sizes the image from the shape bounds, including outline settings, while [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/python-java/aspose.slides/shapethumbnailbounds/#Appearance) sizes it from the shape's appearance and restricts the result to the slide bounds. In contrast, [Shape.getVisualBounds](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getVisualBounds) returns only the calculated rectangle and does not clip it to the slide.

## **FAQ**

**What image formats can be used when saving shape thumbnails?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/), and others. Shapes can also be [exported as vector SVG](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#writeAsSvgToBytes) by saving the shape’s content as SVG.

**What is the difference between Shape and Appearance bounds when rendering a thumbnail?**

`Shape` uses the shape’s geometry; `Appearance` takes [visual effects](/slides/python-java/shape-effect/) (shadows, glows, etc.) into account.

**What happens if a shape is marked as hidden? Will it still render as a thumbnail?**

A hidden shape remains part of the model and can be rendered; the hidden flag affects slideshow display but does not prevent generating the shape’s image.

**Are group shapes, charts, SmartArt, and other complex objects supported?**

Yes. Any object represented as [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) (including [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/), and [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/)) can be saved as a thumbnail or as SVG.

**Do system-installed fonts affect the quality of thumbnails for text shapes?**

Yes. You should [provide the required fonts](/slides/python-java/custom-font/) (or [configure font substitutions](/slides/python-java/font-substitution/)) to avoid unwanted fallbacks and text reflow.
