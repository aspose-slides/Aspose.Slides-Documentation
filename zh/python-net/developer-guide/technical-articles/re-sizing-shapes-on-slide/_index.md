---
title: 用 Python 对演示文稿中的形状进行大小调整
linktitle: 调整形状大小
type: docs
weight: 130
url: /zh/python-net/re-sizing-shapes-on-slide/
keywords:
- 调整形状大小
- 更改形状尺寸
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "通过 Aspose.Slides for Python via .NET，轻松调整 PowerPoint 和 OpenDocument 幻灯片中的形状大小——自动化幻灯片布局调整，提高工作效率。"
---

## **概述**

Aspose.Slides for Python 用户最常提出的问题之一是如何调整形状大小，以便在幻灯片尺寸变化时，数据不会被裁剪。本文简短的技术文章展示了实现方法。

## **调整形状大小**

为防止幻灯片尺寸变化后形状错位，需要更新每个形状的位置和尺寸，使其符合新的幻灯片布局。
```py
import aspose.slides as slides

# 加载演示文稿文件。
with slides.Presentation("sample.pptx") as presentation:
    # 获取原始幻灯片尺寸。
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # 在不缩放现有形状的情况下更改幻灯片尺寸。
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # 获取新的幻灯片尺寸。
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # 在每张幻灯片上调整形状大小并重新定位。
    for slide in presentation.slides:
        for shape in slide.shapes:
            # 按比例缩放形状尺寸。
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # 按比例缩放形状位置。
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" %}} 
如果幻灯片包含表格，上述代码将无法正常工作。在这种情况下，需要对表格中的每个单元格进行大小调整。
{{% /alert %}} 

在您的代码中使用以下示例来调整包含表格的幻灯片大小。对于表格而言，设置宽度或高度是特殊情况：必须调整各行的高度和各列的宽度，以改变表格的整体尺寸。
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # 获取原始幻灯片尺寸。
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # 在不缩放现有形状的情况下更改幻灯片尺寸。
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # 获取新的幻灯片尺寸。
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # 缩放形状尺寸。
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # 缩放形状位置。
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # 缩放形状尺寸。
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # 缩放形状位置。
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # 缩放形状尺寸。
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # 缩放形状位置。
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**为什么在调整幻灯片大小后形状会失真或被裁剪？**

在调整幻灯片大小时，形状会保持原来的位置和尺寸，除非显式更改比例。这可能导致内容被裁剪或形状错位。

**提供的代码适用于所有形状类型吗？**

基本示例适用于大多数形状类型（文本框、图像、图表等）。但是，对于表格，需要单独处理行和列，因为表格的高度和宽度由各单元格的尺寸决定。

**在调整幻灯片大小时，如何调整表格？**

需要遍历表格的所有行和列，并按比例调整它们的高度和宽度，正如第二个代码示例所示。

**此调整是否适用于母版幻灯片和版式幻灯片？**

是的，但是您还应遍历 [Masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) 和 [Layout slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/)，并对它们的形状应用相同的缩放逻辑，以确保整个演示文稿的一致性。

**我可以在调整大小的同时更改幻灯片的方向（纵向/横向）吗？**

可以。您可以使用 [presentation.slide_size.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/islidesize/orientation/) 更改方向。请确保相应地设置缩放逻辑，以保持布局。

**我可以设置的幻灯片尺寸是否有限制？**

Aspose.Slides 支持自定义尺寸，但过大的尺寸可能会影响性能或与某些版本的 PowerPoint 的兼容性。

**如何防止固定宽高比的形状被拉伸变形？**

可以在缩放前检查形状的 `aspect_ratio_locked` 属性。如果该属性被锁定，则应按比例调整宽度或高度，而不是单独缩放它们。