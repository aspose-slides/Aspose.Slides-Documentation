---
title: 在簡報中使用 C++ 自訂氣泡圖
linktitle: 氣泡圖
type: docs
url: /zh-hant/cpp/bubble-chart/
keywords:
- 氣泡圖
- 氣泡大小
- 大小比例縮放
- 大小表示方式
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 中建立並自訂功能強大的氣泡圖，輕鬆提升資料視�視化效果。"
---
## **概述**

本篇文章說明如何在 Aspose.Slides 中使用氣泡圖，重點介紹兩項自訂功能：透過 `set_BubbleSizeScale` 方法調整氣泡大小比例，以及透過 `set_BubbleSizeRepresentation` 方法控制氣泡大小值的表示方式。

範例示範如何建立氣泡圖、調整其大小縮放，並將氣泡大小的表示方式切換為以寬度為基準。文章還包含簡短的 FAQ，說明「具有 3D 效果的氣泡圖」是否受支援、實際圖表上限取決於效能與目標 PowerPoint 版本，以及匯出時如何透過 Aspose.Slides 渲染引擎保留圖表外觀。

## **氣泡圖大小縮放**
Aspose.Slides for C++ 提供氣泡圖大小縮放的支援。已在 Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** 與 **IChartSeriesGroup.BubbleSizeScale** 屬性中加入此功能。以下給予範例程式碼。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **以氣泡圖大小表示資料**
已在 **IChartSeries** 與 **ChartSeries** 類別中加入全新 **get_BubbleSizeRepresentation()** 方法。**BubbleSizeRepresentation** 用來指定氣泡圖中氣泡大小值的表示方式。可能的值包括 **BubbleSizeRepresentationType.Area** 與 **BubbleSizeRepresentationType.Width**。因此也新增了 **BubbleSizeRepresentationType** 列舉，以定義以氣泡圖大小表示資料的可能方式。以下示範程式碼。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **常見問題**

**是否支援「具有 3D 效果的氣泡圖」，且它與一般氣泡圖有何不同？**

是的。此類型為「Bubble with 3-D」的獨立圖表類型。它會對氣泡套用 3D 風格，但不會新增額外座標軸；資料仍維持 X‑Y‑S（大小）三維。此類型可在 [chart type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/charttype/) 列舉中取得。

**氣泡圖的系列數量與資料點數量是否有限制？**

在 API 層面上沒有硬性上限；限制取決於效能與目標 PowerPoint 版本。建議保持資料點數量在合理範圍，以確保可讀性與渲染速度。

**匯出（PDF、影像等）會如何影響氣泡圖的外觀？**

匯出至支援的格式時會保留圖表的外觀，渲染由 Aspose.Slides 引擎負責。對於點陣或向量格式，仍遵循一般圖表圖形渲染規則（解析度、反鋸齒等），因此請選擇足夠的 DPI 以符合列印需求。