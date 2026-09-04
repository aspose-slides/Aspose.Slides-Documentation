---
title: 圖表
type: docs
weight: 60
url: /zh-hant/python-java/examples/elements/chart/
keywords:
- 圖表
- 新增圖表
- 存取圖表
- 移除圖表
- 更新圖表
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 和 OpenDocument 簡報中建立、存取、移除與更新圖表。"
---
本篇文章示範如何在簡報中使用 **Aspose.Slides for Python via Java** 來新增、存取、移除和更新圖表。

如同[Installation](/slides/zh-hant/python-java/installation/)中所述安裝套件。每個範例在啟動 JVM 之前先匯入 `asposeslides`，然後在 JVM 運行後匯入 API。請先執行新增範例以建立 `chart.pptx`，供其餘範例使用。

## **新增圖表**

在第一張投影片新增區域圖表，並儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 在第一張投影片新增區域圖表。
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **存取圖表**

在第一張投影片的形狀集合中找到第一個圖表。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # 存取投影片上的第一個圖表。
    first_chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            first_chart = shape
            break

    if first_chart is None:
        print("The first slide contains no charts.")
finally:
    presentation.dispose()
```

## **移除圖表**

從投影片中移除第一個圖表，並儲存已修改的簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # 在投影片上搜尋並移除第一個圖表。
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        slide.getShapes().remove(chart)
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **更新圖表資料**

顯示圖表標題，變更其文字，並儲存更新後的簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # 在投影片上尋找第一個圖表。
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # 顯示圖表標題並變更其文字。
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```