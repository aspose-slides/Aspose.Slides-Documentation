---
title: 使用 PHP 在簡報中自訂氣泡圖
linktitle: 氣泡圖
type: docs
url: /zh-hant/php-java/bubble-chart/
keywords:
- 氣泡圖
- 氣泡大小
- 大小縮放
- 大小表示
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 中建立並自訂強大的氣泡圖，輕鬆提升資料視覺化效果。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中使用氣泡圖。它涵蓋兩種特定的自訂選項：透過 `setBubbleSizeScale` 方法縮放氣泡大小，以及透過 `setBubbleSizeRepresentation` 方法控制氣泡大小值的表示方式。  
範例示範如何建立氣泡圖、調整其大小縮放，並將氣泡大小的表示方式切換為使用寬度。本文還包含簡短的 FAQ 區段，說明對「Bubble with 3-D」圖表類型的支援、指出實際圖表限制取決於效能與目標 PowerPoint 版本，並解釋匯出會透過 Aspose.Slides 渲染引擎保留圖表外觀。

## **氣泡圖大小縮放**
Aspose.Slides for PHP via Java 提供了對氣泡圖大小縮放的支援。在 Aspose.Slides for PHP via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/getbubblesizescale/)、[**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) 以及 [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) 方法已新增。以下提供範例程式碼。  

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **將資料以氣泡圖大小表示**
已在 [ChartSeries](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/)、[ChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseriesgroup/) 類別及相關類別中新增了方法 [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) 與 [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/)。**BubbleSizeRepresentation** 指定氣泡圖中氣泡大小值的表示方式。可能的值有：[**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/BubbleSizeRepresentationType#Area) 與 [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/BubbleSizeRepresentationType#Width)。因此，已新增列舉 [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/BubbleSizeRepresentationType) 以指定將資料以氣泡圖大小表示的可能方式。以下提供範例程式碼。  

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**是否支援「Bubble with 3-D 效果」的氣泡圖，且它與一般氣泡圖有何不同？**  
是的。此圖表類型為「Bubble with 3-D」，屬於單獨的圖表類型。它會對氣泡套用 3-D 樣式，但不會新增座標軸；資料仍為 X‑Y‑S（大小）。該類型可於 [圖表類型](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/charttype/) 類別中取得。

**氣泡圖的系列與資料點數量有沒有上限？**  
在 API 級別沒有硬性上限；限制取決於效能與目標 PowerPoint 版本。建議將資料點數維持在合理範圍，以確保可讀性與渲染速度。

**匯出會如何影響氣泡圖的外觀（PDF、影像）？**  
匯出至支援的格式會保留圖表的外觀；渲染由 Aspose.Slides 引擎執行。對於點陣或向量格式，皆遵循一般圖表渲染規則（解析度、抗鋸齒），因此列印時請選擇足夠的 DPI。