---
title: 在 Python 中優化簡報的圖表計算
linktitle: 圖表計算
type: docs
weight: 50
url: /zh-hant/python-net/chart-calculations/
keywords:
- 圖表計算
- 圖表元素
- 元素位置
- 真實位置
- 子元素
- 父元素
- 圖表值
- 真實值
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 在 PPT、PPTX 與 ODP 中的圖表計算、資料更新與精度控制，並提供實作範例程式碼。"
---
## **概覽**

Aspose.Slides 提供用於在簡報中處理圖表計算和版面配置資料的 API。本文說明如何取得圖表元素的實際值，包括實作 `ActualLayout` 的元素的真實位置與大小，以及圖表座標軸的實際值。亦說明這些值會在圖表版面配置驗證之後填入。

此外，本文示範如何取得父圖表元素的實際位置，以及如何隱藏圖表元件（如標題、座標軸、圖例與格線）。這些範例可協助您程式化檢視圖表版面資訊，並控制 PowerPoint 簡報中圖表元素的可見性。

## **計算圖表元素的實際值**
Aspose.Slides for Python via .NET 提供簡易的 API 以取得這些屬性。這可協助您計算圖表元素的實際值。實際值包含繼承自 [IActualLayout](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/iactuallayout/) 類別的元素位置（IActualLayout.ActualX、IActualLayout.ActualY、IActualLayout.ActualWidth、IActualLayout.ActualHeight）以及座標軸的實際值（IAxis.ActualMaxValue、IAxis.ActualMinValue、IAxis.ActualMajorUnit、IAxis.ActualMinorUnit、IAxis.ActualMajorUnitScale、IAxis.ActualMinorUnitScale）。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```

## **計算父圖表元素的實際位置**
Aspose.Slides for Python via .NET 提供簡易的 API 以取得這些屬性。IActualLayout 的屬性提供父圖表元素的實際位置資訊。必須先呼叫 IChart.ValidateChartLayout() 方法，以將屬性填入實際值。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```

## **隱藏圖表資訊**
本主題說明如何隱藏圖表資訊。使用 Aspose.Slides for Python via .NET，您可以隱藏圖表的 **Title、Vertical Axis、Horizontal Axis** 以及 **Grid Lines**。以下程式碼範例示範如何使用這些屬性。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # 隱藏圖表標題
    chart.has_title = False

    # 隱藏值軸
    chart.axes.vertical_axis.is_visible = False

    # 類別軸可見性
    chart.axes.horizontal_axis.is_visible = False

    # 隱藏圖例
    chart.has_legend = False

    # 隱藏主要格線
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # 設定系列線條顏色
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**外部 Excel 活頁簿能作為資料來源嗎？這會如何影響重新計算？**

是的。圖表可以引用外部活頁簿：當您連接或重新整理外部來源時，公式與數值會從該活頁簿取得，圖表會在開啟/編輯操作期間反映更新。API 讓您[指定外部活頁簿](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/set_external_workbook/)路徑並管理已連結的資料。

**我可以在不自行實作迴歸的情況下計算並顯示趨勢線嗎？**

可以。[趨勢線](/slides/zh-hant/python-net/trend-line/)（線性、指數等）會由 Aspose.Slides 自動加入並更新；其參數會根據系列資料自動重新計算，您無需自行實作計算。

**如果簡報中有多個圖表連結到外部檔案，我能控制每個圖表使用哪個活頁簿的計算值嗎？**

可以。每個圖表都可以指向各自的[外部活頁簿](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/set_external_workbook/)，或是為每個圖表獨立建立/取代外部活頁簿，與其他圖表互不影響。