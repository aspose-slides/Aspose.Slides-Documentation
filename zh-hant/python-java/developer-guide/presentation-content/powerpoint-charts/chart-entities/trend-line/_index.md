---
title: 在 Python 中為簡報圖表新增趨勢線
linktitle: 趨勢線
type: docs
url: /zh-hant/python-java/trend-line/
keywords:
- 圖表
- 趨勢線
- 指數趨勢線
- 線性趨勢線
- 對數趨勢線
- 移動平均趨勢線
- 多項式趨勢線
- 次方趨勢線
- 自訂趨勢線
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 快速在 PowerPoint 圖表中新增與自訂趨勢線 — 實用指南，助您吸引觀眾。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 為簡報圖表加入趨勢線。內容包括建立圖表、為圖表系列新增趨勢線，以及使用多種趨勢線類型（指數、線性、對數、移動平均、多項式與次方）。

同時說明如何透過插入直線圖形的方式為圖表新增自訂線，並提供有關「前向」與「後向」趨勢線投射值，以及趨勢線在匯出為 PDF 或 SVG、或將圖表呈現為影像時是否會保留的簡短 FAQ。

## **新增趨勢線**

Aspose.Slides for Python via Java 提供簡易 API 來管理不同的圖表趨勢線：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。  
1. 依索引取得投影片的參照。  
1. 使用預設資料與指定類型新增圖表（本範例使用 [ChartType.ClusteredColumn](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/charttype/#ClusteredColumn)）。  
1. 為圖表系列 1 新增指數趨勢線。  
1. 為圖表系列 1 新增線性趨勢線。  
1. 為圖表系列 2 新增對數趨勢線。  
1. 為圖表系列 2 新增移動平均趨勢線。  
1. 為圖表系列 3 新增多項式趨勢線。  
1. 為圖表系列 3 新增次方趨勢線。  
1. 將修改後的簡報寫入 PPTX 檔案。

以下程式碼建立帶有趨勢線的圖表。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# 建立 Presentation 類別的實例。
presentation = Presentation()
try:
    # 建立叢集柱狀圖。
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # 為圖表系列 1 新增指數趨勢線。
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # 為圖表系列 1 新增線性趨勢線。
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # 為圖表系列 2 新增對數趨勢線。
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # 為圖表系列 2 新增移動平均趨勢線。
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # 為圖表系列 3 新增多項式趨勢線。
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # 為圖表系列 3 新增次方趨勢線。
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # 保存簡報。
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **新增自訂線**

Aspose.Slides for Python via Java 提供簡易 API 以在圖表中加入自訂線。若要在選定的投影片上於圖表中加入一般直線，請依下列步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。  
- 依索引取得投影片的參照。  
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/) 類別的 [addChart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addChart) 方法建立新圖表。  
- 以 [addAutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addAutoShape) 方法，並搭配 [ShapeType.Line](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#Line) 新增直線圖形。  
- 設定圖形線條的顏色。  
- 將修改後的簡報寫入 PPTX 檔案。

以下程式碼建立帶有自訂線的圖表。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# 建立 Presentation 類別的實例。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**「前向」與「後向」在趨勢線中代表什麼意思？**

它們是趨勢線向前或向後投射的長度：對於散佈圖（XY）而言，以坐標軸單位測量；對於非散佈圖，則以類別數量測量。僅允許非負值。

**匯出簡報為 PDF 或 SVG，或將投影片渲染為影像時，趨勢線會被保留嗎？**

會。Aspose.Slides 可將簡報轉換為 [PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/zh-hant/python-java/render-a-slide-as-an-svg-image/)，並將圖表渲染為影像；作為圖表一部份的趨勢線在這些操作中會被保留。亦提供方法可 [匯出圖表影像](/slides/zh-hant/python-java/create-shape-thumbnails/)。