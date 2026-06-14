---
title: 在 .NET 中自訂簡報的氣泡圖表
linktitle: 氣泡圖表
type: docs
url: /zh-hant/net/bubble-chart/
keywords:
- 氣泡圖表
- 氣泡大小
- 大小縮放
- 大小表示
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 中輕鬆建立並自訂功能強大的氣泡圖表，以提升資料可視化。"
---
## **概觀**

本文章說明如何在 Aspose.Slides 中使用氣泡圖表。它涵蓋兩個特定的自訂選項：透過 `BubbleSizeScale` 屬性調整氣泡大小的縮放，以及透過 `BubbleSizeRepresentation` 屬性控制氣泡大小值的表示方式。

範例示範如何建立氣泡圖表、調整其大小縮放，並切換氣泡大小表示方式為使用寬度。文章亦包含簡短的 FAQ 區段，說明對「Bubble with 3-D」圖表類型的支援、指出實際圖表限制取決於效能與目標 PowerPoint 版本，以及解釋匯出時如何透過 Aspose.Slides 渲染引擎保留圖表外觀。

## **氣泡圖表大小縮放**
Aspose.Slides for .NET 提供對氣泡圖表大小縮放的支援。 在 Aspose.Slides for .NET 中已加入 **IChartSeries.BubbleSizeScale** 與 **IChartSeriesGroup.BubbleSizeScale** 屬性。以下提供範例。

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **將資料表示為氣泡圖表大小**
已在 IChartSeries、IChartSeriesGroup 介面及相關類別中加入屬性 **BubbleSizeRepresentation**。**BubbleSizeRepresentation** 指定氣泡圖表中氣泡大小值的表示方式。可能的值有：**BubbleSizeRepresentationType.Area** 和 **BubbleSizeRepresentationType.Width**。因此也新增 **BubbleSizeRepresentationType** 列舉，以指定將資料表示為氣泡圖表大小的可能方式。以下提供範例程式碼。

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**是否支援「具 3-D 效果的氣泡圖表」，且它與一般圖表有何不同？**

是的。 有一個獨立的圖表類型，「Bubble with 3-D」。它會對氣泡套用 3-D 樣式，但不會新增額外的坐標軸；資料仍為 X‑Y‑S（大小）。該類型可在[chart type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/charttype/) 列舉中取得。

**氣泡圖表的系列與資料點數量是否有限制？**

在 API 層面沒有硬性限制；限制取決於效能與目標 PowerPoint 版本。建議將資料點數量維持在合理範圍，以確保可讀性與渲染速度。

**匯出會如何影響氣泡圖表的外觀（PDF、影像）？**

匯出至支援的格式會保留圖表的外觀；渲染由 Aspose.Slides 引擎執行。對於點陣或向量格式，會套用一般圖表圖形渲染規則（解析度、抗鋸齒），因此請選擇足夠的 DPI 以供列印。