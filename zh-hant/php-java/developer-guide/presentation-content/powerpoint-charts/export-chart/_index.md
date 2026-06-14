---
title: 在 PHP 中匯出簡報圖表
linktitle: 匯出圖表
type: docs
weight: 90
url: /zh-hant/php-java/export-chart/
keywords:
- 圖表
- 圖表轉影像
- 圖表作為影像
- 擷取圖表影像
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 匯出簡報圖表，支援 PPT 與 PPTX 格式，並將報表流程順暢整合至任何工作流程。"
---
## **概述**

Aspose.Slides 允許您將簡報中的圖表匯出為影像。本文示範如何從圖表取得影像並將其儲存，當您需要在 PowerPoint 簡報之外重新使用圖表視覺時，這非常有用。

## **取得圖表影像**

Aspose.Slides for PHP via Java 提供了擷取特定圖表影像的支援。以下範例說明。

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**我可以將圖表匯出為向量 (SVG) 而非點陣圖嗎？**

可以。圖表是一個形狀，其內容可使用[shape-to-SVG 儲存方法](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/writeassvg/)另存為 SVG。

**如何設定匯出圖表的精確像素尺寸？**

使用允許指定尺寸或比例的影像渲染覆寫方法——函式庫支援以給定的尺寸/比例來渲染物件。

**如果匯出後標籤和圖例的字型顯示不正確，我該怎麼辦？**

[載入所需的字型](/slides/zh-hant/php-java/custom-font/) 透過[FontsLoader](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/)，以確保圖表渲染保留度量和文字外觀。

**匯出時是否遵循 PowerPoint 主題、樣式與效果？**

是。Aspose.Slides 的渲染器遵循簡報的格式設定（主題、樣式、填色、效果），因此圖表的外觀得以保留。

**在哪裡可以找到圖表影像以外的可用渲染/匯出功能？**

請參閱[API](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/)/[文件](/slides/zh-hant/php-java/convert-powerpoint/)了解輸出目標（[PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)、[SVG](/slides/zh-hant/php-java/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh-hant/php-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/php-java/convert-powerpoint-to-html/)等）以及相關的渲染選項。