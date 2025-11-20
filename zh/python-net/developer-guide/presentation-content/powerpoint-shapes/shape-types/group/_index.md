---
title: Python 中的组演示形状
linktitle: 形状组
type: docs
weight: 40
url: /zh/python-net/group/
keywords:
- 组形状
- 形状组
- 添加组
- 替代文字
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for Python 对 PowerPoint 和 OpenDocument 演示文稿进行形状的分组和取消分组——快速、一步步的指南，提供免费代码。"
---

## **概述**

分组形状允许您将多个绘图对象视为一个单元，从而能够一起移动、调整大小、格式化和变换。使用 Aspose.Slides for Python，您可以创建一个 [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)，在其内部添加和排列子形状，并将结果保存为 PPTX。本文演示如何在幻灯片上添加组形状以及如何从组内形状访问可访问性元数据（例如 Alt Text），从而实现更清晰的结构和更丰富、更易维护的演示文稿。

## **添加组形状**

Aspose.Slides 支持在幻灯片上使用组形状。此功能通过将多个形状视为单个对象，使您能够构建更丰富的演示文稿。您可以添加新的组形状、访问现有组形状、向其中填充子形状，并读取或修改其任何属性。要向幻灯片添加组形状：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个 [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)。
4. 向新组形状添加形状。
5. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例展示了如何向幻灯片添加组形状。
```py
import aspose.slides as slides

# 实例化 Presentation 类。
with slides.Presentation() as presentation:
    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 向幻灯片添加组形状。
    group_shape = slide.shapes.add_group_shape()

    # 在组形状内添加形状。
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # 将 PPTX 文件写入磁盘。
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```


## **访问 Alt Text 属性**

本节说明如何使用 Aspose.Slides 读取幻灯片上组形状中包含的形状的 Alt Text。要访问这些形状的 Alt Text：

1. 实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类以表示 PPTX 文件。
2. 通过索引获取幻灯片的引用。
3. 访问幻灯片的 shapes 集合。
4. 访问 [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)。
5. 读取 Alt Text 属性。

下面的示例检索组形状中包含的形状的 Alt Text。
```py
import aspose.slides as slides

# 实例化 Presentation 类以打开 PPTX 文件。
with slides.Presentation("group_shape.pptx") as presentation:
    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # 访问组形状。
            for child_shape in shape.shapes:
                # 访问 Alt Text 属性。
                print(child_shape.alternative_text)
```


## **常见问题**

**是否支持嵌套分组（组内再包含组）？**

是的。 [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) 具有 [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/) 属性，直接表明支持层级（一个组可以是另一个组的子组）。

**如何控制组相对于幻灯片上其他对象的 Z 顺序？**

使用 [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) 的 [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) 属性来检查或更改其在显示堆栈中的位置。

**我可以阻止移动/编辑/取消分组吗？**

是的。组的锁定部分通过 [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/) 公开，您可以限制对该对象的操作。