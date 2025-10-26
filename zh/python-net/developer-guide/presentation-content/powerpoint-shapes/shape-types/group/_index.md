---
title: 使用 Python 对演示文稿形状进行分组
linktitle: 形状组
type: docs
weight: 40
url: /zh/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/group/
keywords:
- 分组形状
- 形状组
- 添加组
- 替代文本
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for Python 对 PowerPoint 和 OpenDocument 演示文稿中的形状进行分组和取消分组——快速、分步指南，附带免费代码。"
---

## **概览**

对形状进行分组可以将多个绘图对象视为一个单元，从而可以一起移动、调整大小、设置格式和转换。使用 Aspose.Slides for Python，您可以创建一个 [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)，在其中添加和排列子形状，并将结果保存为 PPTX。本文演示了如何在幻灯片上添加组形状，以及如何从组内形状访问诸如 Alt Text 等可访问性元数据，从而实现更清晰的结构和更丰富、更易维护的演示文稿。

## **添加组形状**

Aspose.Slides 支持在幻灯片上使用组形状。此功能通过将多个形状视为单个对象，使您能够创建更丰富的演示文稿。您可以添加新的组形状、访问现有组形状、向其中填充子形状，并读取或修改其任何属性。要在幻灯片上添加组形状：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个 [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)。
4. 向新组形状中添加形状。
5. 将修改后的演示文稿保存为 PPTX 文件。

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add a group shape to the slide.
    group_shape = slide.shapes.add_group_shape()

    # Add shapes inside the group shape.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Write the PPTX file to disk.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **访问 Alt Text 属性**

本节介绍如何使用 Aspose.Slides 读取幻灯片上组形状中包含的形状的 Alt Text。要访问这些形状的 Alt Text：

1. 实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类以表示 PPTX 文件。
2. 通过索引获取幻灯片的引用。
3. 访问幻灯片的 shapes 集合。
4. 访问 [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)。
5. 读取 Alt Text 属性。

```py
import aspose.slides as slides

# Instantiate the Presentation class to open the PPTX file.
with slides.Presentation("group_shape.pptx") as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Access the group shape.
            for child_shape in shape.shapes:
                # Access the Alt Text property.
                print(child_shape.alternative_text)
```

## **常见问题**

**是否支持嵌套分组（组内再有组）？**

是的。 [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) 具有 [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/) 属性，直接表明支持层级结构（一个组可以是另一个组的子组）。

**如何控制组相对于幻灯片上其他对象的 Z 顺序？**

使用 [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) 的 [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) 属性来检查或更改其在显示堆栈中的位置。

**我能阻止移动/编辑/取消分组吗？**

是的。组的锁定部分通过 [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/) 暴露，您可以限制对该对象的操作。