---
title: 自訂 Python 簡報圖表的繪圖區域
linktitle: 繪圖區域
type: docs
url: /zh-hant/python-net/chart-plot-area/
keywords:
- 圖表
- 繪圖區域
- 繪圖區域寬度
- 繪圖區域高度
- 繪圖區域大小
- 佈局模式
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 簡報中自訂圖表繪圖區域，輕鬆提升投影片視覺效果。"
---
## **概述**

本文說明如何在 Aspose.Slides 中處理圖表的繪圖區域。它說明如何透過驗證圖表佈局，然後讀取其 X、Y、寬度和高度值，以取得繪圖區域的實際位置與尺寸。

它亦示範在手動設定佈局時，如何配置繪圖區域的佈局模式，使用 `LayoutTargetType` 定義繪圖區域是依其內部區域計算，還是與坐標軸及坐標軸標籤一起的外部區域計算。

## **取得圖表繪圖區域的寬度與高度**
Aspose.Slides for Python via .NET 提供簡易的 API 用於  

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 取得第一張投影片。
3. 新增具有預設資料的圖表。
4. 在取得實際值之前呼叫 IChart.ValidateChartLayout() 方法。
5. 取得圖表元素相對於圖表左上角的實際 X 位置（左側）。
6. 取得圖表元素相對於圖表左上角的實際 Y 位置（上側）。
7. 取得圖表元素的實際寬度。
8. 取得圖表元素的實際高度。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# 保存包含圖表的簡報
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **設定圖表繪圖區域的佈局模式**
Aspose.Slides for Python via .NET 提供簡易的 API 以設定圖表繪圖區域的佈局模式。已在 **ChartPlotArea** 與 **IChartPlotArea** 類別中加入屬性 **LayoutTargetType**。如果繪圖區域的佈局是手動定義，此屬性指定是根據內部（不包含坐標軸與坐標軸標籤）或外部（包含坐標軸與坐標軸標籤）來佈局繪圖區域。**LayoutTargetType** 列舉定義了兩個可能的值。

- **LayoutTargetType.Inner** - 指定繪圖區域的大小僅決定繪圖區域本身的尺寸，不包括刻度線與坐標軸標籤。
- **LayoutTargetType.Outer** - 指定繪圖區域的大小決定繪圖區域、本身的刻度線以及坐標軸標籤的尺寸。

以下提供樣本程式碼。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**實際的 actual_x、actual_y、actual_width 與 actual_height 以何種單位回傳？**  
以點 (point) 為單位；1 吋 = 72 點。這是 Aspose.Slides 的座標單位。

**繪圖區域在內容上與圖表區域有何差異？**  
繪圖區域是資料繪製區域（系列、格線、趨勢線等）；圖表區域則包括周圍的元素（標題、圖例等）。在 3D 圖表中，繪圖區域亦包含牆面/底面以及坐標軸。

**當佈局為手動時，繪圖區域的 X、Y、寬度與高度如何解讀？**  
它們是相對於圖表整體尺寸的比例（0–1）；在此模式下，會停用自動定位，使用您設定的比例值。

**為何在新增/移動圖例後，繪圖區域的位置會改變？**  
圖例位於圖表區域（繪圖區域之外），但會影響佈局與可用空間，因而在啟用自動定位時會導致繪圖區域移動。（這是 PowerPoint 圖表的標準行為。）