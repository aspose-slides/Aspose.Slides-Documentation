---
title: 群組形狀
type: docs
weight: 170
url: /zh-hant/python-java/examples/elements/group-shape/
keywords:
- 程式碼範例
- 群組形狀
- 新增群組形狀
- 存取群組形狀
- 移除群組形狀
- 解除群組形狀
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在簡報中管理群組形狀：新增、存取、移除以及解除群組形狀，支援 PowerPoint 與 OpenDocument 檔案。"
---
本文示範如何使用 **Aspose.Slides for Python via Java** 建立形狀群組、存取它們、刪除它們，以及解除群組內容。

請依照 [Installation](/slides/zh-hant/python-java/installation/) 中的說明安裝套件。每個範例會在啟動 JVM 之前匯入 `asposeslides`，然後在 JVM 執行後匯入 API。

## **新增群組形狀**

建立一個包含兩個基本形狀的群組。

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

## **存取群組形狀**

從投影片中取得第一個群組形狀。

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

## **移除群組形狀**

從投影片中刪除群組形狀。

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

## **解除群組形狀**

將形狀從群組容器中移出。

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

    # 將形狀從群組中移出。
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```