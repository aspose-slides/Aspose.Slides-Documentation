---
title: 表格
type: docs
weight: 120
url: /zh-hant/python-java/examples/elements/table/
keywords:
- 程式碼範例
- 表格
- 新增表格
- 存取表格
- 刪除表格
- 合併儲存格
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中操作表格：在 PowerPoint 與 OpenDocument 簡報中新增、存取、刪除及合併儲存格。"
---
使用 **Aspose.Slides for Python via Java** 新增表格、存取表格、刪除表格，以及合併儲存格的範例。

依照 [Installation](/slides/zh-hant/python-java/installation/) 中的說明安裝套件。每個範例會在啟動 JVM 之前匯入 `asposeslides`，然後在 JVM 執行中匯入 API。

## **新增表格**

建立一個包含兩列兩欄的簡易表格。

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

## **存取表格**

取得投影片上的第一個表格形狀。

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

    # 存取投影片上的第一個表格。
    first_table = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Table):
            first_table = shape
            break
finally:
    presentation.dispose()
```

## **刪除表格**

從投影片中刪除表格。

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

## **合併表格儲存格**

將相鄰的表格儲存格合併為單一儲存格。

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

    # 合併儲存格。
    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), False)
finally:
    presentation.dispose()
```