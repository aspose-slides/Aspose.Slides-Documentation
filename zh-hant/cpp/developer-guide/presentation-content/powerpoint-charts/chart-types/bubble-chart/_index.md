---
title: 使用 С++ 自訂簡報中的氣泡圖
linktitle: 氣泡圖
type: docs
url: /zh-hant/cpp/bubble-chart/
keywords:
- 氣泡圖
- 氣泡大小
- 大小縮放
- 大小表示
- PowerPoint
- 簡報
- С++
- Aspose.Slides
description: "使用 Aspose.Slides for С++ 在 PowerPoint 中建立並自訂強大的氣泡圖，輕鬆提升資料可視化效果。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用氣泡圖。它涵蓋兩項特定的自訂選項：透過 `set_BubbleSizeScale` 方法調整氣泡大小的縮放，及透過 `set_BubbleSizeRepresentation` 方法控制氣泡大小值的呈現方式。

這些範例示範如何建立氣泡圖、調整其大小縮放，並將氣泡大小的呈現方式切換為使用寬度。本文亦包含簡短的 FAQ 章節，說明「Bubble with 3-D」圖表類型的支援情況、指出實際圖表的限制取決於效能與目標 PowerPoint 版本，並解釋匯出時會透過 Aspose.Slides 渲染引擎保留圖表外觀。

## **氣泡圖大小縮放**
Aspose.Slides for C++ 提供對氣泡圖大小縮放的支援。已在 Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** 與 **IChartSeriesGroup.BubbleSizeScale** 屬性中加入此功能。以下提供範例程式碼。 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **將資料表示為氣泡圖大小**
已在 **IChartSeries** 與 **ChartSeries** 類別中新增 **get_BubbleSizeRepresentation()** 方法。**BubbleSizeRepresentation** 指定氣泡圖中氣泡大小值的呈現方式。可能的值有：**BubbleSizeRepresentationType.Area** 與 **BubbleSizeRepresentationType.Width**。因此亦新增 **BubbleSizeRepresentationType** 列舉，以定義將資料表示為氣泡圖大小的可能方式。以下提供範例程式碼。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **常見問題**

**是否支援「具有 3-D 效果的氣泡圖」，且它與一般氣泡圖有何不同？**

是的。有一個獨立的圖表類型「Bubble with 3-D」。它會對氣泡套用 3-D 風格，但不會新增額外的座標軸；資料仍為 X‑Y‑S（大小）。此類型可在[chart type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/charttype/) 列舉中取得。

**氣泡圖的系列與資料點數量是否有限制？**

在 API 層面沒有硬性限制；限制由效能與目標 PowerPoint 版本決定。建議將資料點數量保持在合理範圍，以確保可讀性與渲染速度。

**匯出會如何影響氣泡圖的外觀（PDF、圖像）？**

匯出至支援的格式時會保留圖表外觀；渲染由 Aspose.Slides 引擎負責。對於點陣或向量格式，會套用一般圖表渲染規則（解析度、抗鋸齒），因此請選擇足夠的 DPI 以適合列印。