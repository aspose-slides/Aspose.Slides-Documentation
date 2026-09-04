---
title: 連接線
type: docs
weight: 190
url: /zh-hant/python-java/examples/elements/connector/
keywords:
- 程式碼範例
- 連接線
- 新增連接線
- 存取連接線
- 移除連接線
- 重新連接形狀
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何在 PPT、PPTX 與 ODP 簡報中，使用 Aspose.Slides for Python via Java 透過連接線新增、存取、移除與重新連接形狀。"
---
本文示範如何使用 **Aspose.Slides for Python via Java** 連接形狀與連接線，並變更其目標。

如同在 [Installation](/slides/zh-hant/python-java/installation/) 中所述，安裝套件。每個範例在啟動 JVM 之前先匯入 `asposeslides`，然後在 JVM 執行後匯入 API。

## **新增連接線**

在投影片的兩個點之間插入一個連接線形狀。

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

## **存取連接線**

取得已新增至投影片的第一個連接線形狀。

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

    # 取得投影片上的第一個連接線。
    connector = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Connector):
            connector = shape
            break
finally:
    presentation.dispose()
```

## **移除連接線**

從投影片中刪除連接線。

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

    slide.getShapes().remove(connector)
finally:
    presentation.dispose()
```

## **重新連接形狀**

透過指派起始與結束目標，將連接線附加到兩個形狀上。

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