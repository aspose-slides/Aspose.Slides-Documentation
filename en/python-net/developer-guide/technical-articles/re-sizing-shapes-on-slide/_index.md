---
title: Resize Shapes on Presentation Slides in Python
type: docs
weight: 130
url: /python-net/resizing-shapes-on-slide/
aliases:
  /python-net/re-sizing-shapes-on-slide/
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

When you change a presentation's slide size, you may also need to resize and reposition its shapes to fit the new dimensions. This article shows how to scale shapes manually and how to handle tables on slides, masters, and layouts.

## **Resize Shapes**

To preserve each shape's relative position and size, multiply its horizontal coordinates and width by the ratio of the new slide width to the original width. Apply the corresponding height ratio to its vertical coordinates and height.

The first example loads a presentation whose slides contain no tables, changes the slide size to A4, and saves the result. It uses [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) with [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) so that the subsequent loop controls the scaling. The ratios are unitless; shape positions and dimensions are measured in points. Different width and height ratios can distort shapes, and changing a shape's dimensions does not scale its font sizes.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Calculate independent horizontal and vertical scale factors.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}

Tables require separate handling: scale their column widths and row heights instead of assigning the table's overall width and height. Row heights may remain larger than requested if the cell content requires more space.

{{% /alert %}}

The second example supports tables and processes shapes on masters and layouts as well as individual slides before saving the resized presentation. Its helper handles each [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) by scaling [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) and [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/). It then scales the table's position without separately scaling its overall dimensions.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # Table dimensions are controlled by column widths and row heights.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # Calculate independent horizontal and vertical scale factors.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Resize shapes defined on masters and layouts as well as individual slides.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Why are shapes distorted or cut off after resizing a slide?**

If you change the slide size without scaling the shapes, they keep their original positions and dimensions and may extend beyond the slide. Scaling width and height by different ratios can also distort shapes.

**Does the provided code work for all shape types?**

The first example changes shape bounds directly and is intended for slides without tables. The second example handles tables separately. Check the resulting layout, particularly text and tables, because these examples do not scale font sizes and table content can constrain row heights.

**How do I resize tables when resizing a slide?**

Scale column widths by the width ratio and minimum row heights by the height ratio, then scale the table's position, as shown in the second example.

**Will this resizing work for master slides and layout slides?**

Yes. The second example iterates through [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) and each master's [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) and applies the same resizing logic to their shapes.

**Can I change the orientation of a slide (portrait/landscape) along with the resizing?**

Yes. Set [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) after changing the slide size and before reading the target dimensions, so the scale factors reflect the final orientation.

**Is there a limit to the slide size I can set?**

You can specify custom slide dimensions with [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/). The supported dimensions also depend on the presentation format and the application used to open the file.

**How can I prevent shapes with a fixed aspect ratio from becoming distorted?**

Use the same scale factor for width and height. To fit the original layout within the new slide dimensions, use the smaller of the width and height ratios for both dimensions and positions. This preserves proportions but may leave unused space along one edge.
