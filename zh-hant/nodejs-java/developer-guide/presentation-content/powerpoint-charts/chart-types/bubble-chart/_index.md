---
title: 使用 JavaScript 自訂簡報中的氣泡圖
linktitle: 氣泡圖
type: docs
url: /zh-hant/nodejs-java/bubble-chart/
keywords:
- 氣泡圖
- 氣泡大小
- 大小縮放
- 大小表示
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 與 Aspose.Slides for Node.js via Java 在 PowerPoint 中建立並自訂強大的氣泡圖，輕鬆提升資料視�顯化效果。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用氣泡圖，並介紹兩項特定的自訂功能：透過 `setBubbleSizeScale` 方法調整氣泡大小縮放，以及透過 `setBubbleSizeRepresentation` 方法控制氣泡大小值的表示方式。

範例示範如何建立氣泡圖、調整其大小縮放，並將氣泡大小的表示方式切換為使用寬度。文章同時包含簡短的 FAQ，說明「具有 3D 效果的氣泡圖」類型是否受支援、實際圖表限制取決於效能與目標 PowerPoint 版本，並解釋匯出時會透過 Aspose.Slides 渲染引擎保留圖表外觀。

## **氣泡圖大小縮放**
Aspose.Slides for Node.js via Java 提供對氣泡圖大小縮放的支援。已新增 Aspose.Slides for Node.js via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--)、[**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) 以及 [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) 方法。以下提供範例程式碼。

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **將資料表示為氣泡圖大小**
已在 [ChartSeries](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartSeries)、[ChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartSeriesGroup) 類別及相關類別中加入 [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) 和 [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) 方法。**BubbleSizeRepresentation** 指定氣泡圖中氣泡大小值的表示方式。可能的值包括： [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) 和 [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width)。因此，已新增 [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/BubbleSizeRepresentationType) 列舉以說明可用的資料表示方式。以下提供範例程式碼。

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**是否支援「具 3D 效果的氣泡圖」，且它與一般氣泡圖有何不同？**

是的。有一個獨立的圖表類型「Bubble with 3-D」。它會對氣泡套用 3D 樣式，但不會增加額外的座標軸；資料仍保留為 X‑Y‑S（大小）。此類型可在 [chart type](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/charttype/) 列舉中找到。

**氣泡圖的系列與資料點數量是否有限制？**

在 API 層面沒有硬性限制；限制取決於效能與目標 PowerPoint 版本。建議將資料點數量控制在合理範圍，以確保可讀性與渲染速度。

**匯出（PDF、圖像）會如何影響氣泡圖的外觀？**

匯出至支援的格式時會保留圖表外觀，渲染由 Aspose.Slides 引擎執行。對於點陣或向量格式，遵循一般圖表渲染規則（解析度、抗鋸齒），因此請選擇足夠的 DPI 以符合列印需求。