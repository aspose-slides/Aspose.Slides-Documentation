---
title: 连接器
type: docs
weight: 190
url: /zh/python-java/examples/elements/connector/
keywords:
- 代码示例
- 连接器
- 添加连接器
- 访问连接器
- 删除连接器
- 重新连接形状
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在 PPT、PPTX 和 ODP 演示文稿中添加、访问、删除和重新连接形状及其连接线。"
---
本文演示了如何使用 **Aspose.Slides for Python via Java** 通过连接线连接形状并更改其目标。

按照[Installation](/slides/zh/python-java/installation/)中描述的方式安装软件包。每个示例在启动 JVM 之前导入 `asposeslides`，随后在 JVM 运行后导入 API。

## **添加连接线**
在幻灯片的两个点之间插入一个连接线形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)
finally:
    presentation.dispose()
```

## **访问连接线**
检索添加到幻灯片的第一个连接线形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Connector, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    # 访问幻灯片上的第一个连接器。
    connector = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Connector):
            connector = shape
            break
finally:
    presentation.dispose()
```

## **移除连接线**
从幻灯片中删除连接线。

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    slide.getShapes().remove(connector)
finally:
    presentation.dispose()
```

## **重新连接形状**
通过分配起始和结束目标，将连接线连接到两个形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    connector.setStartShapeConnectedTo(shape1)
    connector.setEndShapeConnectedTo(shape2)
finally:
    presentation.dispose()
```