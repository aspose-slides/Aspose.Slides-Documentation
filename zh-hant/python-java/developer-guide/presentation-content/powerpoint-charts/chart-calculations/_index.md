---
title: 在 Python via Java 中優化簡報的圖表計算
linktitle: 圖表計算
type: docs
weight: 50
url: /zh-hant/python-java/chart-calculations/
keywords:
- 圖表計算
- 圖表元素
- 元素位置
- 實際位置
- 子元素
- 父元素
- 圖表值
- 實際值
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解在 Aspose.Slides for Python via Java 中的圖表計算、資料更新與精度控制，適用於 PPT 與 PPTX，並提供實用的 Python 程式碼範例。"
---
## **概述**

Aspose.Slides 提供用於在簡報中處理圖表計算和版面配置資料的 API。本文說明如何取得圖表元素的實際值，包括圖表元素的真實位置和大小以及圖表座標軸的實際值。也說明這些值會在圖表版面配置驗證之後填入。

此外，本文示範如何取得父圖表元素的實際位置，以及如何隱藏圖表元件，例如標題、座標軸、圖例和格線。這些範例可協助您以程式方式檢查圖表版面資訊並控制 PowerPoint 簡報中圖表元素的可見性。

## **計算圖表元素的實際值**
Aspose.Slides for Python via Java 提供簡單的 API 以取得這些屬性。[Axis](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/axis/) 類別的方法提供圖表座標軸實際值的資訊（[getActualMaxValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/axis/#getActualMaxValue)、[getActualMinValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/axis/#getActualMinValue)、[getActualMajorUnit](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/axis/#getActualMajorUnit)、[getActualMinorUnit](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/axis/#getActualMinorUnit)、[getActualMajorUnitScale](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/axis/#getActualMajorUnitScale)、[getActualMinorUnitScale](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/axis/#getActualMinorUnitScale)）。請先呼叫[Chart.validateChartLayout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#validateChartLayout)方法，以使用實際值填入這些屬性。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **計算父圖表元素的實際位置**
Aspose.Slides for Python via Java 提供簡單的 API 以取得這些屬性。[ChartPlotArea](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartplotarea/) 類別的方法提供圖表繪圖區的實際位置和大小資訊（[getActualX](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartplotarea/#getActualX)、[getActualY](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartplotarea/#getActualY)、[getActualWidth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartplotarea/#getActualWidth)、[getActualHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartplotarea/#getActualHeight)）。請先呼叫[Chart.validateChartLayout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#validateChartLayout)方法，以使用實際值填入這些屬性。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **隱藏圖表元素**
本節說明如何隱藏圖表中的資訊。使用 Aspose.Slides for Python via Java，您可以隱藏**標題、垂直座標軸、水平座標軸**以及**格線**。以下程式碼範例示範如何使用這些屬性。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # 隱藏圖表標題。
    chart.setTitle(False)

    # 隱藏數值軸。
    chart.getAxes().getVerticalAxis().setVisible(False)

    # 隱藏類別軸。
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # 隱藏圖例。
    chart.setLegend(False)

    # 隱藏主要格線。
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # 僅保留第一個系列。從末端移除可保持剩餘索引有效。
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # 設定系列線條顏色。
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**外部 Excel 活頁簿能作為資料來源嗎？這會如何影響重新計算？**

是。圖表可以參照外部活頁簿：當您連接或重新整理外部來源時，公式與值會取自該活頁簿，圖表會在開啟/編輯時反映這些更新。API 讓您[specify the external workbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#setExternalWorkbook)路徑並管理已連結的資料。

**我可以在不自行實作回歸分析的情況下計算並顯示趨勢線嗎？**

是。[Trendlines](/slides/zh-hant/python-java/trend-line/)（線性、指數等）由 Aspose.Slides 自動新增與更新；其參數會根據系列資料自動重新計算，因此您無需自行實作計算。

**如果簡報包含多個具有外部連結的圖表，我能控制每個圖表使用哪個活頁簿來計算值嗎？**

是。每個圖表都可以指向自己的[external workbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#setExternalWorkbook)，或您可為各圖表獨立建立/取代外部活頁簿，而不受其他圖表影響。