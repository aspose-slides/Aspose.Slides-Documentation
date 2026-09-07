---
title: 表格
type: docs
weight: 120
url: /zh/python-java/examples/elements/table/
keywords:
- 代码示例
- 表格
- 添加表格
- 访问表格
- 删除表格
- 合并单元格
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中操作表格：在 PowerPoint 和 OpenDocument 演示文稿中添加、访问、删除和合并单元格。"
---
使用 **Aspose.Slides for Python via Java** 添加表格、访问表格、删除表格以及合并单元格的示例。

按照[Installation](/slides/zh/python-java/installation/)中描述的方式安装包。每个示例在启动 JVM 之前导入 `asposeslides`，随后在 JVM 运行后导入 API。

## **添加表格**

创建一个包含两行两列的简单表格。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)
finally:
    presentation.dispose()
```

## **访问表格**

获取幻灯片上的第一个表格形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # 访问幻灯片上的第一个表格。
    first_table = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Table):
            first_table = shape
            break
finally:
    presentation.dispose()
```

## **删除表格**

从幻灯片中删除表格。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    slide.getShapes().remove(table)
finally:
    presentation.dispose()
```

## **合并表格单元格**

将表格的相邻单元格合并为一个单元格。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpime.JArray(jpime.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # 合并单元格。
    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), False)
finally:
    presentation.dispose()
```