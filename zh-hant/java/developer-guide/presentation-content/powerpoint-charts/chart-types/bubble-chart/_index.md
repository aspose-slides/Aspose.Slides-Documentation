---
title: 使用 Java 在簡報中自訂氣泡圖
linktitle: 氣泡圖
type: docs
url: /zh-hant/java/bubble-chart/
keywords:
- 氣泡圖
- 氣泡大小
- 大小比例調整
- 大小表示方式
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 中輕鬆建立並自訂功能強大的氣泡圖，以提升資料視覺化效果。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用氣泡圖。內容涵蓋兩個特定的自訂選項：透過 `setBubbleSizeScale` 方法調整氣泡大小比例，以及透過 `setBubbleSizeRepresentation` 方法控制氣泡大小值的表示方式。

範例示範如何建立氣泡圖、調整其大小比例，並將氣泡大小表示方式切換為使用寬度。文章亦包含簡短的 FAQ，說明「具 3D 效果的氣泡圖」類型是否受支援、實際圖表限制取決於效能與目標 PowerPoint 版本，並解釋匯出時圖表外觀會透過 Aspose.Slides 渲染引擎得以保留。

## **氣泡圖大小比例**
Aspose.Slides for Java 提供對氣泡圖大小比例的支援。已在 Aspose.Slides for Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--)、[**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) 以及 [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) 方法中加入此功能。以下為範例程式碼。

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
已在 [IChartSeries](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartSeries) 與 [IChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartSeriesGroup) 介面及相關類別中加入方法 [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) 與 [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--)。**BubbleSizeRepresentation** 指定氣泡圖中氣泡大小值的表示方式。可能的值有：[**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/BubbleSizeRepresentationType#Area) 與 [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/BubbleSizeRepresentationType#Width)。因此已新增 [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/BubbleSizeRepresentationType) 列舉，以指定將資料表示為氣泡圖大小的可能方式。以下為範例程式碼。

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

**是否支援「具 3‑D 效果的氣泡圖」，且它與一般氣泡圖有何不同？**

是的。此類圖表為獨立的「Bubble with 3-D」類型，會對氣泡套用 3‑D 樣式，但不會額外增加坐標軸；資料仍為 X‑Y‑S（大小）。此類型可於 [chart type](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/charttype/) 類別中取得。

**氣泡圖的系列數量與資料點數是否有限制？**

在 API 層面沒有硬性限制；限制受效能與目標 PowerPoint 版本所左右。建議將資料點數控制在合理範圍，以確保可讀性與渲染速度。

**匯出（PDF、影像）時會如何影響氣泡圖的外觀？**

匯出至受支援的格式時會保留圖表的外觀，渲染工作由 Aspose.Slides 引擎執行。對於點陣或向量格式，遵循一般圖表渲染規則（解析度、抗鋸齒等），因此請選擇足夠的 DPI 以符合列印需求。