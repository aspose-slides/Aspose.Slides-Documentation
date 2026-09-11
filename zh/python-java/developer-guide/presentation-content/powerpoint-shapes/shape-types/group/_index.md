---
title: "在 Python via Java 中的组演示形状"
linktitle: "形状组"
type: docs
weight: 40
url: /zh/python-java/group/
keywords:
- 组形状
- 形状组
- 添加组
- 备用文本
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中对形状进行分组和取消分组——提供免费 Python 代码的分步指南。"
---
## **概述**

本文说明了如何在 Aspose.Slides 中使用组形状。它展示了如何向幻灯片添加组形状、在组内放置形状以及保存更新后的演示文稿。文章还演示了如何访问存储在组中的形状并使用[getAlternativeText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getAlternativeText)读取它们的备用文本。此外，本文还简要介绍了相关的组形状功能，例如嵌套组、Z 顺序和锁定选项。

## **添加组形状**

Aspose.Slides 支持在幻灯片上使用组形状。此功能帮助开发者创建更丰富的演示文稿。Aspose.Slides for Python via Java 支持添加和访问组形状。您可以向组形状中填充形状或访问其属性。要使用 Aspose.Slides for Python via Java 将组形状添加到幻灯片：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加组形状。
1. 向组形状中添加形状。
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例向幻灯片添加了一个组形状：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# 实例化 Presentation 类。
presentation = Presentation()
try:
    # 获取第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 访问幻灯片的形状集合。
    slide_shapes = slide.getShapes()

    # 向幻灯片添加组形状。
    group_shape = slide_shapes.addGroupShape()

    # 在组形状内部添加形状。
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # 设置组形状的帧。
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # 将 PPTX 文件写入磁盘。
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **访问备用文本**

本节展示了如何访问幻灯片上组内形状的备用文本。要使用 Aspose.Slides for Python via Java 访问此文本：

1. 实例化表示 PPTX 文件的 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类。
1. 按索引获取幻灯片的引用。
1. 访问幻灯片的形状集合。
1. 访问组形状。
1. 使用[getAlternativeText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getAlternativeText)读取其形状的备用文本。

下面的示例访问组内形状的备用文本：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# 实例化表示 PPTX 文件的 Presentation 类。
presentation = Presentation("AltText.pptx")
try:
    # 获取第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # 访问幻灯片的形状集合中的形状。
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # 访问组内的形状。
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # 读取备用文本。
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **常见问题**

**是否支持嵌套分组（组内的组）？**

是的。[GroupShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/groupshape/) 具有 [getParentGroup](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getParentGroup) 方法，表明支持层级结构：一个组可以是另一个组的子组。

**如何控制组相对于幻灯片上其他对象的 Z 顺序？**

使用 [GroupShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/groupshape/) 对象的 [getZOrderPosition](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getZOrderPosition) 方法检查其在显示堆栈中的位置。

**我可以阻止移动、编辑或取消分组吗？**

可以。组的锁定通过 [getGroupShapeLock](https://reference.aspose.com/slides/zh/python-java/aspose.slides/groupshape/#getGroupShapeLock) 暴露，您可以限制对该对象的操作。