---
title: Create Thumbnails of Presentation Shapes in Python
linktitle: Shape Thumbnails
type: docs
weight: 70
url: /python-net/create-shape-thumbnails/
keywords:
- shape thumbnail
- shape image
- render shape
- shape rendering
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Generate high-quality shape thumbnails from PowerPoint and OpenDocument slides with Aspose.Slides for Python via .NET – easily create and export presentation thumbnails."
---

## **Introduction**

Aspose.Slides for Python via .NET is used to create presentation files in which each page is a slide. You can view these slides in Microsoft PowerPoint by opening the presentation file. However, developers may sometimes need to view images of shapes separately in an image viewer. In such cases, Aspose.Slides can generate thumbnail images for slide shapes. This article explains how to use this feature.

## **Generate Shape Thumbnails from Slides**

When you need a preview of a specific object rather than the entire slide, you can render a thumbnail for an individual shape. Aspose.Slides lets you export any shape to an image, making it easy to create lightweight previews, icons, or assets for downstream processing.

To generate a thumbnail from any shape:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to a slide by its ID or index.
1. Get a reference to a shape on that slide.
1. Render the shape’s thumbnail image.
1. Save the thumbnail image in the desired format.

The example below generates a shape thumbnail.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open the presentation file.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Create a image with the default scale.
    with shape.get_image() as thumbnail:
        # Save the image to disk in PNG format.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Generate Thumbnails with a Custom Scaling Factor**

This section shows how to generate shape thumbnails with a user-defined scaling factor in Aspose.Slides. By controlling the scale, you can fine-tune thumbnail size to suit previews, exports, or high-DPI displays.

To generate a thumbnail for any shape on a slide:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a slide by its ID or index.
1. Get the target shape on that slide.
1. Render the thumbnail image of the shape with the specified scale.
1. Save the thumbnail image in the desired format.

The example below generates a thumbnail with a user-defined scaling factor.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Instantiate the Presentation class to open the presentation file.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Create an image with the defined scale.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Save the image to disk in PNG format.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Generate Thumbnails Using a Shape’s Appearance Bounds**

This section shows how to generate a thumbnail within a shape’s appearance bounds. It accounts for all shape effects. The generated thumbnail is restricted by the slide bounds. 

To generate a thumbnail of any slide shape within the bounds of its appearance:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a slide by its ID or index.
1. Get the target shape on that slide.
1. Render the thumbnail image of the shape with the specified bounds.
1. Save the thumbnail image in the desired image format.

The example below creates a thumbnail with user-defined bounds.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instantiate the Presentation class to open the presentation file.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Create an appearance-bounds shape image.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Save the image to disk in PNG format.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**What image formats can be used when saving shape thumbnails?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), and others. Shapes can also be [exported as vector SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) by saving the shape’s content as SVG.

**What is the difference between SHAPE and APPEARANCE bounds when rendering a thumbnail?**

`SHAPE` uses the shape’s geometry; `APPEARANCE` takes [visual effects](/slides/python-net/shape-effect/) (shadows, glows, etc.) into account.

**What happens if a shape is marked as hidden? Will it still render as a thumbnail?**

A hidden shape remains part of the model and can be rendered; the hidden flag affects slideshow display but does not prevent generating the shape’s image.

**Are group shapes, charts, SmartArt, and other complex objects supported?**

Yes. Any object represented as [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) (including [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), and [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) can be saved as a thumbnail or as SVG.

**Do system-installed fonts affect the quality of thumbnails for text shapes?**

Yes. You should [provide the required fonts](/slides/python-net/custom-font/) (or [configure font substitutions](/slides/python-net/font-substitution/)) to avoid unwanted fallbacks and text reflow.
