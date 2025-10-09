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
