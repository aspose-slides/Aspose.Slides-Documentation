---
title: 使用 Python 在簡報中自訂圖表座標軸
linktitle: 圖表座標軸
type: docs
url: /zh-hant/python-net/chart-axis/
keywords:
- 圖表座標軸
- 垂直座標軸
- 水平座標軸
- 自訂座標軸
- 操作座標軸
- 管理座標軸
- 座標軸屬性
- 最大值
- 最小值
- 座標軸線
- 日期格式
- 座標軸標題
- 座標軸位置
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 簡報中自訂圖表座標軸，以用於報告與視覺化。"
---
## **概述**

本文說明如何在 Aspose.Slides 中自訂圖表座標軸。內容包括取得實際座標軸值、在座標軸之間交換資料、隱藏折線圖的垂直或水平座標軸、變更類別座標軸類型、設定類別座標軸值的日期格式、旋轉座標軸標題、設定座標軸位置，以及在數值座標軸上顯示單位標籤。

## **取得圖表垂直座標軸的最大值**
Aspose.Slides for Python via .NET 讓您可以取得垂直座標軸的最小值與最大值。請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
1. 取得第一張投影片。  
1. 新增一個帶有預設資料的圖表。  
1. 取得座標軸的實際最大值。  
1. 取得座標軸的實際最小值。  
1. 取得座標軸的實際主要單位。  
1. 取得座標軸的實際次要單位。  
1. 取得座標軸的實際主要單位比例。  
1. 取得座標軸的實際次要單位比例。

以下範例程式碼—即上述步驟的實作—示範了如何在 Python 中取得所需的值：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# 儲存簡報
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **交換座標軸之間的資料**
Aspose.Slides 讓您可以快速交換座標軸之間的資料——原本位於垂直座標軸 (y 軸) 的資料會移至水平座標軸 (x 軸)，反之亦然。

以下 Python 程式碼示範了如何在圖表上執行座標軸資料交換：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 建立空白簡報
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #切換列與行
    chart.chart_data.switch_row_column()
            
    # 儲存簡報
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **停用折線圖的垂直座標軸**

以下 Python 程式碼示範了如何隱藏折線圖的垂直座標軸：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **停用折線圖的水平座標軸**

以下程式碼示範了如何隱藏折線圖的水平座標軸：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **變更類別座標軸**

使用 **CategoryAxisType** 屬性，您可以指定偏好的類別座標軸類型（**date** 或 **text**）。以下 Python 程式碼展示了此操作：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **設定類別座標軸值的日期格式**
Aspose.Slides for Python via .NET 允許您為類別座標軸值設定日期格式。此操作在下列 Python 程式碼中示範：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **設定圖表座標軸標題的旋轉角度**
Aspose.Slides for Python via .NET 允許您設定圖表座標軸標題的旋轉角度。以下 Python 程式碼示範了此操作：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **在類別或數值座標軸中設定座標軸位置**
Aspose.Slides for Python via .NET 允許您在類別或數值座標軸中設定座標軸位置。此 Python 程式碼顯示如何執行此任務：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **在圖表數值座標軸上啟用顯示單位標籤**
Aspose.Slides for Python via .NET 允許您將圖表設定為在其數值座標軸上顯示單位標籤。以下 Python 程式碼示範了此操作：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**如何設定一個座標軸與另一個座標軸交叉的位置（座標軸交叉）？**

座標軸提供了 [crossing setting](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/axis/cross_type/)：您可以選擇在零點、在最大類別/數值，或在特定的數值上交叉。此功能可用於將 X 軸上移或下移，或強調基線。

**如何相對於座標軸定位刻度標籤（旁側、外側、內側）？**

將 [label position](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/axis/major_tick_mark/) 設為 "cross"、"outside" 或 "inside"。此設定影響可讀性，並有助於在小型圖表上節省空間。