---
title: 在 Python 中為簡報圖表添加趨勢線
linktitle: 趨勢線
type: docs
url: /zh-hant/python-net/trend-line/
keywords:
- 圖表
- 趨勢線
- 指數趨勢線
- 線性趨勢線
- 對數趨勢線
- 移動平均趨勢線
- 多項式趨勢線
- 冪次趨勢線
- 自訂趨勢線
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "透過 .NET 的 Aspose.Slides for Python，快速在 PowerPoint 圖表中加入並自訂趨勢線──實用指南，助您吸引觀眾。"
---
## **概述**

本文說明如何使用 Aspose.Slides 向簡報圖表加入趨勢線。它展示了如何建立圖表、將趨勢線加入圖表系列，以及使用多種趨勢線類型，包括指數、線性、對數、移動平均、多項式和冪次。

它還說明了如何透過插入線形狀向圖表加入自訂線，並包含關於 forward 與 backward 趨勢線投射值的簡短 FAQ，以及趨勢線在匯出為 PDF 或 SVG、以及將圖表渲染為影像時是否會被保留的說明。

## **加入趨勢線**

使用[TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/)將趨勢線加入圖表系列，並以[TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/)選擇其類型。此範例建立一個具預設資料的分群柱狀圖，並為其三個系列的每個系列加入兩條趨勢線。

指數趨勢線透過[display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/)和[display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/)隱藏其方程式與 R 平方值，而線性趨勢線則為紅色。對數趨勢線使用[add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/)設定自訂標籤。移動平均使用[period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/)為三個資料點，並使用自訂[trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/)。

多項式趨勢線的[order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/)為三，並透過[forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/)向前延伸一個類別。冪次趨勢線則透過[backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/)向後延伸一個類別。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```

## **設定趨勢線截距**

使用[intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/)可將趨勢線的 Y 值固定於 X = 0。此設定支援線性、指數與多項式趨勢線。

例如，生產成本模型可能需要從已知的固定成本 100 開始，即使在非零產量的測量顯示不同的基線。對於線性趨勢線，固定截距會將方程式 `y = ax + b` 約束為 `b = 100`；斜率在此約束下依資料擬合。這並非僅僅將已擬合的線移動。座標軸交叉設定控制圖表座標軸相交位置，而非已擬合趨勢線的係數。

以下範例建立一個散佈圖 (XY) ，產量從 1 到 4，成本分別為 170、200、230 與 260。它先以預設自動截距儲存圖表，然後將截距設定為 100 並儲存第二個 PPTX。兩個檔案僅在截距設定上不同。趨勢線會顯示其方程式並向後延伸至 X = 0。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

使用自動計算時，這些資料會產生 `y = 30x + 140`。將截距設定為 100 時，則約為 `y = 43.33x + 100`：零點的擬合值符合已知的基線，而線條不再通過每個資料點。

| 自動截距 | 固定截距 100 |
| --- | --- |
| ![線性趨勢線，自動計算的截距為 140](intercept-automatic.png) | ![線性趨勢線，固定截距為 100](intercept-fixed.png) |

兩張影像使用相同的資料與座標軸比例。趨勢線向後延伸至 X = 0 以顯示其截距。

預設情況下，屬性包含 `float("nan")`，表示未指定的截距而非零。然後截距會自資料自動計算。

## **加入自訂線**

自訂線是繪製於圖表之上的形狀，而非根據系列資料計算的趨勢線。此範例使用[ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/)在投影片上方的圖表中加入水平線。線條位置以投影片座標（點數）指定，因而從圖表左邊緣開始，位於圖表中間高度。其寬度與圖表寬度相同。[line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) 為線條設定實心紅色。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**趨勢線的 'forward' 與 'backward' 是什麼意思？**

它們是趨勢線向前或向後投射的長度：對於散佈圖 (XY) 為座標軸單位；對於非散佈圖則為類別數。僅允許非負值。

**匯出簡報為 PDF 或 SVG，或將投影片渲染為影像時，趨勢線會被保留嗎？**

是。Aspose.Slides 會將簡報轉換為[PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)或[SVG](/slides/zh-hant/python-net/render-a-slide-as-an-svg-image/)，並將圖表渲染為影像；作為圖表一部分的趨勢線在這些操作中會被保留。亦提供方法可[匯出圖表的影像](/slides/zh-hant/python-net/create-shape-thumbnails/)。