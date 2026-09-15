---
title: Resize Shapes on Presentation Slides in Python via Java
type: docs
weight: 110
url: /python-java/re-sizing-shapes-on-slide/
keywords:
- resize shape
- change shape size
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Easily resize shapes on PowerPoint and OpenDocument slides with Aspose.Slides for Python via Java—automate slide layout adjustments and boost productivity."
---

## **Overview**

One of the most common questions from Aspose.Slides for Python via Java customers is how to resize shapes so that, when the slide size changes, the data isn’t cut off. This short technical article shows how to do that.

## **Resize Shapes**

To prevent shapes from becoming misaligned when the slide size changes, update each shape’s position and dimensions so they conform to the new slide layout.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# Load the presentation file.
presentation = Presentation("sample.ppt")
try:
    # Get the original slide size.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Change the slide size without scaling existing shapes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # Get the new slide size.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Resize and reposition shapes on every slide.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # Scale the shape size.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Scale the shape position.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Tables need no special treatment: setting a table's width and height rescales its columns and rows proportionally, so scaling the row heights and column widths again would apply the ratio twice.

{{% /alert %}} 

The code above changes only the shapes on the slides. Master slides and layout slides keep their own shapes, so scale them as well when you want the whole presentation to follow the new slide size:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # Get the original slide size.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Change the slide size without scaling existing shapes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # Get the new slide size.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # Scale the shape size.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Scale the shape position.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # Scale the shape size.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # Scale the shape position.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # Scale the shape size.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Scale the shape position.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Why are shapes distorted or cut off after resizing a slide?**

When resizing a slide, shapes retain their original position and size unless the scale is explicitly changed. This can result in content being cropped or shapes being misaligned.

**Does the provided code work for all shape types?**

Yes. Setting the height and width works for text boxes, images, charts, and tables alike.

**How do I resize tables when resizing a slide?**

Scale the table shape itself, exactly like any other shape. Its rows and columns follow proportionally, so do not scale them again afterwards.

**Will this resizing work for master slides and layout slides?**

Yes, but you should also loop through [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) and [Presentation.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getLayoutSlides) and apply the same scaling logic to their shapes to ensure consistency across the presentation.

**Can I change the orientation of a slide (portrait/landscape) along with the resizing?**

Yes. You can use [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) to change the orientation. Make sure you set the scaling logic accordingly to preserve the layout.

**Is there a limit to the slide size I can set?**

Aspose.Slides supports custom sizes, but very large sizes may affect performance or compatibility with some versions of PowerPoint.

**How can I prevent fixed aspect ratio shapes from becoming distorted?**

You can check the [getAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) method of the shape lock before scaling. If it is locked, adjust the width or height proportionally rather than scaling them individually.
