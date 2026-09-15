---
title: 在 Python via Java 中调整演示文稿幻灯片的形状大小
type: docs
weight: 110
url: /zh/python-java/re-sizing-shapes-on-slide/
keywords:
- 调整形状
- 更改形状大小
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，轻松调整 PowerPoint 和 OpenDocument 幻灯片上的形状大小——自动化幻灯片布局调整，提高工作效率。"
---
## **概述**

Aspose.Slides for Python via Java 用户最常提的一个问题是如何在更改幻灯片尺寸时调整形状大小，以免数据被截断。本文简要技术文档展示了实现方法。

## **调整形状大小**

为防止幻灯片尺寸变化后形状错位，需要更新每个形状的位置和尺寸，使其符合新的幻灯片布局。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# 加载演示文稿文件。
presentation = Presentation("sample.ppt")
try:
    # 获取原始幻灯片尺寸。
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # 在不缩放现有形状的情况下更改幻灯片尺寸。
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # 获取新的幻灯片尺寸。
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # 调整每张幻灯片上形状的大小和位置。
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # 缩放形状尺寸。
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # 缩放形状位置。
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
表格无需特殊处理：设置表格的宽度和高度会按比例重新缩放其列和行，因此再次缩放行高和列宽会导致比例叠加两次。 
{{% /alert %}} 

上述代码仅更改了幻灯片上的形状。母版幻灯片和布局幻灯片拥有各自的形状，需要在希望整个演示文稿遵循新幻灯片尺寸时同样对它们进行缩放：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # 获取原始幻灯片尺寸。
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # 在不缩放现有形状的情况下更改幻灯片尺寸。
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # 获取新的幻灯片尺寸。
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # 缩放形状尺寸。
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # 缩放形状位置。
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # 缩放形状尺寸。
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # 缩放形状位置。
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # 缩放形状尺寸。
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # 缩放形状位置。
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**调整幻灯片后，形状为何会失真或被截断？**

在调整幻灯片尺寸时，形状会保持原始位置和大小，除非显式更改缩放比例。这可能导致内容被裁剪或形状错位。

**提供的代码适用于所有形状类型吗？**

是的。设置高度和宽度同样适用于文本框、图像、图表和表格等。

**调整幻灯片时，如何调整表格大小？**

直接缩放表格形状本身，方式与其他形状相同。其行列会按比例自动跟随缩放，后续无需再次单独缩放行高或列宽。

**此缩放方法适用于母版幻灯片和布局幻灯片吗？**

是的，但还应遍历[Presentation.getMasters]({{link_placeholder}})和[Presentation.getLayoutSlides]({{link_placeholder}})并对它们的形状应用相同的缩放逻辑，以确保整个演示文稿的一致性。

**可以在缩放的同时更改幻灯片的方向（纵向/横向）吗？**

可以。可使用[SlideSize.setOrientation]({{link_placeholder}})更改方向。请相应调整缩放逻辑以保持布局不变。

**设置的幻灯片尺寸是否有上限？**

Aspose.Slides 支持自定义尺寸，但过大的尺寸可能影响性能或与某些 PowerPoint 版本的兼容性。

**如何防止固定宽高比的形状被扭曲？**

在缩放前可检查形状锁的[getAspectRatioLocked]({{link_placeholder}})方法。如果已锁定宽高比，应按比例同时调整宽度和高度，而不是单独缩放。