---
title: 使用 Python 在簡報中自訂圖表坐標軸
linktitle: 圖表坐標軸
type: docs
url: /zh-hant/python-java/chart-axis/
keywords:
- 圖表坐標軸
- 垂直坐標軸
- 水平坐標軸
- 自訂坐標軸
- 操作坐標軸
- 管理坐標軸
- 坐標軸屬性
- 最大值
- 最小值
- 坐標軸線
- 日期格式
- 坐標軸標題
- 坐標軸位置
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在 PowerPoint 簡報中自訂圖表坐標軸，以製作報告和視覺化。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中自訂圖表坐標軸。它展示了如何取得實際坐標軸值、在坐標軸之間交換資料、隱藏折線圖的垂直或水平坐標軸、更改類別坐標軸類型、設定類別坐標軸值的日期格式、旋轉坐標軸標題、設定坐標軸位置，以及設定值坐標軸的顯示單位。

## **取得圖表垂直坐標軸的最大值**

Aspose.Slides for Python via Java 允許您取得垂直坐標軸的最小值和最大值。請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 存取第一張投影片。
1. 新增一個具有預設資料的圖表。
1. 取得坐標軸上的實際最大值。
1. 取得坐標軸上的實際最小值。
1. 取得坐標軸的實際主要單位。
1. 取得坐標軸的實際次要單位。
1. 取得坐標軸的實際主要單位比例。
1. 取得坐標軸的實際次要單位比例。

以下範例程式碼（上述步驟的實作）示範如何在 Python 中取得所需的值：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    # 儲存簡報
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在坐標軸之間交換資料**

Aspose.Slides 允許您快速交換坐標軸之間的資料──垂直坐標軸 (y 軸) 上的資料會移至水平坐標軸 (x 軸)，反之亦然。

以下 Python 程式碼示範如何在圖表上執行坐標軸資料交換的操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # 將圖表的預設資料載入工作簿 — switchRowColumn 會轉置工作簿，因此必須先填入資料
    # 
    workbook = chart.getChartData().getChartDataWorkbook()

    # 切換列和欄
    chart.getChartData().switchRowColumn()

    # 儲存簡報
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **停用折線圖的垂直坐標軸**

以下 Python 程式碼示範如何隱藏折線圖的垂直坐標軸：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **停用折線圖的水平坐標軸**

以下程式碼示範如何隱藏折線圖的水平坐標軸：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **變更類別坐標軸**

使用 [setCategoryAxisType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/axis/#setCategoryAxisType) 方法，您可以指定偏好的類別坐標軸類型（**date** 或 **text**）。以下 Python 程式碼示範此操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        if isinstance(chart, Chart):
            chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
            chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
            chart.getAxes().getHorizontalAxis().setMajorUnit(1)
            chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)
            presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
        else:
            print("The first shape is not a chart.")
    else:
        print("The presentation has no first shape to update.")
finally:
    presentation.dispose()
```

## **設定類別坐標軸值的日期格式**

Aspose.Slides for Python via Java 允許您設定類別坐標軸值的日期格式。以下 Python 程式碼示範此操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

from datetime import datetime

def convert_to_oa_date(date):
    base_date = datetime(1899, 12, 30)
    return (date - base_date).total_seconds() / 86400


presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()
    category_date = datetime(2015, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A2", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2016, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A3", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2017, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A4", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2018, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A5", category_value)
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    value_cell = workbook.getCell(0, "B2", 1.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 2.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 3.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 4.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定圖表坐標軸標題的旋轉角度**

Aspose.Slides for Python via Java 允許您設定圖表坐標軸標題的旋轉角度。以下 Python 程式碼示範此操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定類別或值坐標軸上的坐標軸位置**

Aspose.Slides for Python via Java 允許您設定類別或值坐標軸上的坐標軸位置。以下 Python 程式碼示範如何執行此任務：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定圖表值坐標軸的顯示單位**

Aspose.Slides for Python via Java 允許您設定圖表值坐標軸的顯示單位。坐標軸會根據該單位縮放刻度標籤：以 [DisplayUnitType.Millions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/displayunittype/#Millions) 為例，走至 60,000,000 的坐標軸會標示為 0 至 60。以下 Python 程式碼示範此操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**如何設定一個坐標軸與另一個坐標軸相交的值（坐標軸交叉）？**

坐標軸提供 [crossing setting](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/axis/#setCrossType)：您可以選擇在零點、在最大類別/值或在特定數值處相交。這有助於將 X 軸上下移動或強調基線。

**如何相對於坐標軸定位刻度標記（交叉、外側、內側）？**

將 [tick mark position](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/axis/#setMajorTickMark) 設為「cross」(交叉)、「outside」(外側) 或「inside」(內側)。這會影響可讀性，並有助於節省空間，尤其是在小型圖表上。