---
title: 在 Python 中為簡報圖表新增趨勢線
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
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "快速在 PowerPoint 和 OpenDocument 圖表中使用 Aspose.Slides for Python via .NET 新增與自訂趨勢線 — 實用指南與程式碼範例，提升預測精度並吸引觀眾。"
---
## **概述**

本文說明如何使用 Aspose.Slides 為簡報圖表加入趨勢線。它展示了如何建立圖表、為圖表系列加入趨勢線，以及如何使用多種趨勢線類型，包括指數、線性、對數、移動平均、多項式與冪次。

同時也說明如何透過插入線條圖形為圖表加入自訂線，並包含有關趨勢線向前與向後投射值的簡短 FAQ，以及趨勢線在匯出為 PDF 或 SVG、以及將圖表渲染為圖像時是否會被保留的說明。

## **新增趨勢線**
Aspose.Slides for Python via .NET 提供簡易的 API 以管理圖表的不同趨勢線：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依照索引取得投影片的參考。
1. 加入具有預設資料的圖表，並選擇任意所需類型（此範例使用 ChartType.CLUSTERED_COLUMN）。
1. 為圖表系列 1 新增指數趨勢線。
1. 為圖表系列 1 新增線性趨勢線。
1. 為圖表系列 2 新增對數趨勢線。
1. 為圖表系列 2 新增移動平均趨勢線。
1. 為圖表系列 3 新增多項式趨勢線。
1. 為圖表系列 3 新增冪次趨勢線。
1. 將修改後的簡報寫入 PPTX 檔案。

以下程式碼用於建立帶有趨勢線的圖表。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立空白簡報
with slides.Presentation() as pres:

    # 建立群組柱狀圖表
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # 為圖表系列 1 新增指數趨勢線
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # 為圖表系列 1 新增線性趨勢線
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # 為圖表系列 2 新增對數趨勢線
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # 為圖表系列 2 新增移動平均趨勢線
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # 為圖表系列 3 新增多項式趨勢線
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # 為圖表系列 3 新增冪次趨勢線
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # 儲存簡報
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```



## **新增自訂線**
Aspose.Slides for Python via .NET 提供簡易的 API 以在圖表中加入自訂線。若要為簡報中選取的投影片加入一條簡單的直線，請依照以下步驟操作：

- 建立 Presentation 類別的實例
- 使用 Index 取得投影片的參考
- 使用 Shapes 物件提供的 AddChart 方法建立新圖表
- 使用 Shapes 物件提供的 AddAutoShape 方法加入線條類型的 AutoShape
- 設定形狀線條的顏色。
- 將修改後的簡報寫入 PPTX 檔案

以下程式碼用於建立帶有自訂線的圖表。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**趨勢線的「向前」與「向後」是什麼意思？**

它們是趨勢線向前或向後延伸的長度：對於散佈 (XY) 圖表，以座標軸單位表示；對於非散佈圖表，以類別數表示。僅允許非負值。

**匯出簡報為 PDF 或 SVG，或將投影片渲染為影像時，趨勢線會被保留嗎？**

會。Aspose.Slides 可將簡報轉換為 [PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/zh-hant/python-net/render-a-slide-as-an-svg-image/)，並將圖表渲染為影像；作為圖表一部份的趨勢線在這些操作中會被保留。也提供了將圖表本身[匯出為影像](/slides/zh-hant/python-net/create-shape-thumbnails/)的方法。