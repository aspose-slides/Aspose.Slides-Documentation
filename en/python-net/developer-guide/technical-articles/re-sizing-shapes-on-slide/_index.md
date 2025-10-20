---
title: Resize Shapes in Presentations with Python
linktitle: Resizing Shapes
type: docs
weight: 130
url: /python-net/re-sizing-shapes-on-slide/
keywords:
- resize shape
- change shape size
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Easily resize shapes on PowerPoint and OpenDocument slides with Aspose.Slides for Python via .NET—automate slide layout adjustments and boost productivity."
---

## **Overview**

One of the most common questions from Aspose.Slides for Python customers is how to resize shapes so that, when the slide size changes, the data isn’t cut off. This short technical article shows how to do that.

## **Resize Shapes**

To prevent shapes from becoming misaligned when the slide size changes, update each shape’s position and dimensions so they conform to the new slide layout.

```py
import aspose.slides as slides

# Load the presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get the original slide size.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Change the slide size without scaling existing shapes.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Get the new slide size.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Resize and reposition shapes on every slide.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # Scale the shape size.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Scale the shape position.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

If a slide contains a table, the code above will not work correctly. In that case, each cell in the table must be resized.

{{% /alert %}} 

Use the following code on your end to resize slides that contain tables. For tables, setting the width or height is a special case: you must adjust individual row heights and column widths to change the table’s overall size.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Get the original slide size.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Change the slide size without scaling existing shapes.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Get the new slide size.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # Scale the shape size.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Scale the shape position.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # Scale the shape size.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # Scale the shape position.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Scale the shape size.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Scale the shape position.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Why are shapes distorted or cut off after resizing a slide?**

When resizing a slide, shapes retain their original position and size unless the scale is explicitly changed. This can result in content being cropped or shapes being misaligned.

**Does the provided code work for all shape types?**

The basic example works for most shape types (text boxes, images, charts, etc.). However, for tables, you need to handle rows and columns separately, since the height and width of a table are determined by the dimensions of individual cells.

**How do I resize tables when resizing a slide?**

You need to loop through all the rows and columns of the table and resize their height and width proportionally, as shown in the second code example.

**Will this resizing work for master slides and layout slides?**

Yes, but you should also loop through [Masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) and [Layout slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) and apply the same scaling logic to their shapes to ensure consistency across the presentation.

**Can I change the orientation of a slide (portrait/landscape) along with the resizing?**

Yes. You can use [presentation.slide_size.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/islidesize/orientation/) to change the orientation. Make sure you set the scaling logic accordingly to preserve the layout.

**Is there a limit to the slide size I can set?**

Aspose.Slides supports custom sizes, but very large sizes may affect performance or compatibility with some versions of PowerPoint.

**How can I prevent fixed aspect ratio shapes from becoming distorted?**

You can check the `aspect_ratio_locked` property of the shape before scaling. If it is locked, adjust the width or height proportionally rather than scaling them individually.
