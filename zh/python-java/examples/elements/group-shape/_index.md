---
title: 组形状
type: docs
weight: 170
url: /zh/python-java/examples/elements/group-shape/
keywords:
- 代码示例
- 组形状
- 添加组形状
- 访问组形状
- 删除组形状
- 取消分组形状
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在演示文稿中管理组形状：在 PowerPoint 和 OpenDocument 文件中添加、访问、删除和取消分组形状。"
---
本文演示了如何使用 **Aspose.Slides for Python via Java** 创建形状组、访问形状组、删除形状组以及取消分组其内容。

按照[Installation](/slides/zh/python-java/installation/)中描述的方式安装该软件包。每个示例在启动 JVM 之前导入 `asposeslides`，随后在 JVM 运行后导入 API。

## **添加组形状**

创建一个包含两个基本形状的组。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50)
finally:
    presentation.dispose()
```

## **访问组形状**

从幻灯片中检索第一个组形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    first_group = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, GroupShape):
            first_group = shape
            break
finally:
    presentation.dispose()
```

## **删除组形状**

从幻灯片中删除组形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()

    slide.getShapes().remove(group)
finally:
    presentation.dispose()
```

## **取消分组形状**

将形状从组容器中移出。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    rectangle = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    # 将形状移出组。
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```