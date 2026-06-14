---
title: 使用 Python 自訂投影片中的氣泡圖
linktitle: 氣泡圖
type: docs
url: /zh-hant/python-net/bubble-chart/
keywords:
- 氣泡圖
- 氣泡大小
- 大小縮放
- 大小表示
- PowerPoint
- OpenDocument
- 投影片
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 中輕鬆建立並自訂功能強大的氣泡圖，以增強資料視覺化。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用氣泡圖。它涵蓋兩個特定的自訂選項：透過 `bubble_size_scale` 屬性縮放氣泡大小，以及透過 `bubble_size_representation` 屬性控制氣泡大小值的表示方式。  
範例展示了如何建立氣泡圖、調整其大小縮放，並將氣泡大小的表示方式切換為使用寬度。本文還包含簡短的 FAQ 部分，說明對「Bubble with 3-D」圖表類型的支援、指出實際圖表限制取決於效能與目標 PowerPoint 版本，並解釋匯出時會透過 Aspose.Slides 渲染引擎保留圖表的外觀。

## **氣泡圖大小縮放**
Aspose.Slides for Python via .NET 提供對氣泡圖大小縮放的支援。在 Aspose.Slides for Python via .NET 中已新增 **ChartSeries.bubble_size_scale** 與 **ChartSeriesGroup.bubble_size_scale** 屬性。以下提供範例。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **以氣泡圖大小表示資料**
已在 ChartSeries、ChartSeriesGroup 類別中加入屬性 **bubble_size_representation**。**bubble_size_representation** 指定氣泡圖中氣泡大小值的表示方式。可能的值為 **BubbleSizeRepresentationType.AREA** 與 **BubbleSizeRepresentationType.WIDTH**。因此亦新增 **BubbleSizeRepresentationType** 列舉，以指定以氣泡圖大小表示資料的可能方式。以下提供範例程式碼。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**是否支援「具有 3-D 效果的氣泡圖」，且它與一般氣泡圖有何不同？**

是的。有一個獨立的圖表類型「Bubble with 3-D」。它對氣泡套用 3-D 樣式，但不會新增額外的坐標軸；資料仍為 X‑Y‑S（大小）。此類型可在[chart type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/charttype/) 列舉中取得。

**氣泡圖的系列數量與資料點數量是否有限制？**

在 API 層面上沒有硬性限制；限制取決於效能與目標 PowerPoint 版本。建議保持資料點數量在合理範圍內，以確保可讀性與渲染速度。

**匯出會如何影響氣泡圖的外觀（PDF、圖片）？**

匯出為支援的格式時會保留圖表的外觀；渲染由 Aspose.Slides 引擎執行。對於點陣或向量格式，會遵循一般圖表圖形渲染規則（解析度、抗鋸齒），因此請選擇足夠的 DPI 以供列印。