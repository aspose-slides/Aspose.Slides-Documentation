---
title: 在 Android 簡報中自訂氣泡圖
linktitle: 氣泡圖
type: docs
url: /zh-hant/androidjava/bubble-chart/
keywords:
- 氣泡圖
- 氣泡大小
- 大小縮放
- 大小表示方式
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，在 PowerPoint 中輕鬆建立並自訂功能強大的氣泡圖，以增強資料可視化。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中使用氣泡圖，涵蓋兩項特定的自訂選項：透過 `setBubbleSizeScale` 方法縮放氣泡大小，以及透過 `setBubbleSizeRepresentation` 方法控制氣泡大小值的表示方式。  
範例示範如何建立氣泡圖、調整其大小縮放，並將氣泡大小的表示方式切換為寬度。本文同時包含簡短的 FAQ，說明「Bubble with 3-D」圖表類型的支援情形、實際圖表限制取決於效能與目標 PowerPoint 版本，以及匯出時如何透過 Aspose.Slides 渲染引擎保留圖表外觀。

## **氣泡圖大小縮放**
Aspose.Slides for Android via Java 為氣泡圖大小縮放提供支援。在 Aspose.Slides for Android via Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--)、[**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) 以及 [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) 方法已新增。以下提供範例程式碼。

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **將資料表示為氣泡圖大小**
已在 [IChartSeries](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartSeries)、[IChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartSeriesGroup) 介面及相關類別中新增方法 [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) 與 [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--)。**BubbleSizeRepresentation** 指定氣泡圖中氣泡大小值的表示方式。可能的值有：[**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) 與 [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width)。因此，已新增列舉 [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/BubbleSizeRepresentationType) 以指定將資料表示為氣泡圖大小的可行方式。以下提供範例程式碼。

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**是否支援「具有 3-D 效果的氣泡圖」，且它與一般氣泡圖有何不同？**  
是。Aspose.Slides 提供獨立的圖表類型「Bubble with 3-D」。此類型會對氣泡套用 3-D 造型，但不會新增額外的坐標軸；資料仍為 X‑Y‑S（大小）。此類型可在 [chart type](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/charttype/) 類別中取得。

**氣泡圖的系列與資料點數量是否有限制？**  
在 API 層面沒有硬性限制；實際的限制取決於效能與目標 PowerPoint 版本。建議將資料點數量維持在合理範圍以確保可讀性與渲染速度。

**匯出（PDF、影像）時會如何影響氣泡圖的外觀？**  
匯出至支援的格式時會保留圖表外觀，渲染由 Aspose.Slides 引擎執行。對於點陣或向量格式，遵循一般圖表渲染規則（解析度、抗鋸齒），因此列印時請選擇足夠的 DPI。