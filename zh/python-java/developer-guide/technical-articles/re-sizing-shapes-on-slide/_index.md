---
title: 使用 Java 的 Python 调整演示文稿幻灯片上的形状大小
type: docs
weight: 110
url: /zh/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/re-sizing-shapes-on-slide/
  - /zh/python-java/re-sizing-shapes-on-slide/
keywords:
- 调整形状
- 更改形状大小
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "轻松使用 Aspose.Slides for Python via Java 在 PowerPoint 和 OpenDocument 幻灯片上调整形状大小——自动化幻灯片布局调整，提高生产力。"
---
## **概述**

当您更改演示文稿的幻灯片大小时，可能还需要调整形状的大小并重新定位，以适应新的尺寸。本文介绍了如何手动缩放形状以及如何处理幻灯片、母版和布局中的表格。

## **调整形状大小**

为了保留每个形状的相对位置和大小，需要将其水平坐标和宽度乘以新幻灯片宽度与原始宽度的比例。将相应的高度比例应用于其垂直坐标和高度。

第一个示例加载一个幻灯片中不包含表格的演示文稿，将幻灯片大小更改为 A4，并保存结果。它使用[SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize)与[SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale)以便后续循环控制缩放。比例是无单位的；形状的位置和尺寸以点为单位。不同的宽度和高度比例会导致形状失真，并且更改形状的尺寸不会缩放其字体大小。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # 计算独立的水平和垂直缩放因子。
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
表格需要单独处理：通过缩放列宽和行高来代替为表格设置整体宽度和高度。如果单元格内容需要更多空间，行高可能会大于请求的大小。
{{% /alert %}}

第二个示例支持表格，并在保存已调整大小的演示文稿之前处理母版、布局以及单个幻灯片上的形状。它的辅助方法通过使用[Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth)缩放列宽以及使用[Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight)设置最小行高来处理每个[Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/)。随后，它在不单独缩放整体尺寸的情况下缩放表格的位置。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # 表格尺寸由列宽和行高控制。
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # 计算独立的水平和垂直缩放因子。
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # 调整在母版和布局以及单个幻灯片上定义的形状大小。
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**调整幻灯片大小后，形状为何会失真或被截断？**

如果在更改幻灯片大小时未对形状进行缩放，它们会保持原始位置和尺寸，可能超出幻灯片范围。使用不同的宽度和高度比例进行缩放也会导致形状失真。

**提供的代码是否适用于所有形状类型？**

第一个示例直接更改形状边界，适用于没有表格的幻灯片。第二个示例单独处理表格。请检查生成的布局，尤其是文本和表格，因为这些示例不会缩放字体大小，且表格内容可能限制行高。

**在调整幻灯片大小时如何调整表格？**

按宽度比例缩放列宽，按高度比例缩放最小行高，然后如第二个示例所示缩放表格的位置。

**此调整大小操作是否适用于母版幻灯片和布局幻灯片？**

是的。第二个示例遍历[Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters)以及每个母版的[MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides)，并对它们的形状应用相同的调大小逻辑。

**我可以在调整大小的同时更改幻灯片的方向（纵向/横向）吗？**

可以。在更改幻灯片大小后、读取目标尺寸前调用[SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation)，以便缩放因子反映最终的方向。

**我可以设置的幻灯片尺寸是否有上限？**

可以使用[SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize)指定自定义幻灯片尺寸。支持的尺寸还取决于演示文稿格式以及打开文件的应用程序。

**如何防止具有固定宽高比的形状被拉伸变形？**

对宽度和高度使用相同的缩放因子。若要在新幻灯片尺寸内保持原始布局，可对两者均使用宽度比和高度比中较小的那个进行缩放。这样可以保留比例，但可能在某一边留下未使用的空间。