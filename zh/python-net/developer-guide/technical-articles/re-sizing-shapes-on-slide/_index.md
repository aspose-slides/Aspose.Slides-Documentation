---
title: 在 Python 中调整演示文稿幻灯片上的形状大小
type: docs
weight: 130
url: /zh/python-net/resizing-shapes-on-slide/
aliases:
  - /zh/python-net/re-sizing-shapes-on-slide/
keywords:
- 调整形状大小
- 更改形状尺寸
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "轻松使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 幻灯片上调整形状大小——自动化幻灯片布局调整，提高工作效率。"
---
## **概述**

当您更改演示文稿的幻灯片大小时，可能还需要调整形状的大小和位置以适应新尺寸。本文展示了如何手动缩放形状以及如何处理幻灯片、母版和布局上的表格。

## **调整形状大小**

为了保持每个形状的相对位置和大小，将其水平坐标和宽度乘以新幻灯片宽度与原始宽度的比例。将相应的高度比例应用于其垂直坐标和高度。

第一个示例加载一个幻灯片中没有表格的演示文稿，将幻灯片大小更改为 A4 并保存结果。它使用[SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/)与[SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/)，以便后续循环控制缩放。比例是无单位的；形状位置和尺寸以点为单位。不同的宽度和高度比例会导致形状失真，并且更改形状的尺寸不会缩放其字体大小。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # 计算独立的水平和垂直比例因子。
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
表格需要单独处理：按列宽和行高进行缩放，而不是直接设置表格的整体宽度和高度。如果单元格内容需要更多空间，行高可能会保持大于请求的值。
{{% /alert %}}

第二个示例支持表格，并在保存调整大小的演示文稿之前处理母版、布局以及各个幻灯片上的形状。它的辅助方法通过缩放[Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/)和[Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/)来处理每个[Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)。然后它在不单独缩放整体尺寸的情况下缩放表格的位置。

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # 表格尺寸由列宽和行高控制。
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
    # 计算独立的水平和垂直比例因子。
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # 调整在母版、布局以及单个幻灯片上定义的形状大小。
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**为何在调整幻灯片大小后形状会失真或被截断？**

如果在不对形状进行缩放的情况下更改幻灯片大小，它们会保持原始位置和尺寸，可能会超出幻灯片范围。使用不同的宽高比例进行缩放也会导致形状失真。

**提供的代码是否适用于所有形状类型？**

第一个示例直接更改形状边界，适用于没有表格的幻灯片。第二个示例单独处理表格。请检查生成的布局，尤其是文本和表格，因为这些示例不会缩放字体大小，且表格内容可能限制行高。

**在调整幻灯片大小时如何调整表格大小？**

如第二个示例所示，按宽度比例缩放列宽，按高度比例缩放最小行高，然后缩放表格的位置。

**此调整大小是否适用于母版幻灯片和布局幻灯片？**

是的。第二个示例遍历[Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/)以及每个母版的[MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/)，并对它们的形状应用相同的调整大小逻辑。

**我可以在调整大小的同时更改幻灯片的方向（纵向/横向）吗？**

是的。在更改幻灯片大小后、读取目标尺寸之前设置[SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/)，以便比例因子反映最终方向。

**我可以设置的幻灯片尺寸是否有上限？**

您可以使用[SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/)指定自定义幻灯片尺寸。支持的尺寸还取决于演示文稿格式以及用于打开文件的应用程序。

**如何防止具有固定纵横比的形状被扭曲？**

对宽度和高度使用相同的比例因子。为了在新幻灯片尺寸内保持原始布局，请对宽高两者均使用宽度比例和高度比例中的较小值来进行缩放。这可以保持比例，但可能在某一边留下未使用的空间。