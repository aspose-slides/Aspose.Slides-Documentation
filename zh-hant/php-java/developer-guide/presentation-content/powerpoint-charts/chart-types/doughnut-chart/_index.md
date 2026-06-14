---
title: 使用 PHP 自訂簡報中的環狀圖表
linktitle: 環狀圖表
type: docs
weight: 30
url: /zh-hant/php-java/doughnut-chart/
keywords:
- 環狀圖表
- 中心間隙
- 孔徑
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "探索如何在 Aspose.Slides for PHP（透過 Java）中建立與自訂環狀圖表，支援 PowerPoint 格式的動態簡報。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用環狀圖，透過將圖表新增至投影片、設定中心孔的大小，並儲存簡報。內容聚焦於 `setDoughnutHoleSize` 方法，並示範在程式碼中自訂此圖表類型的基本步驟。

此外，還提供簡短的 FAQ，涵蓋相關的環狀圖情境，例如使用多個系列建立多層環、處理爆炸式環狀圖，以及將圖表匯出為點陣圖或 SVG。

## **指定環狀圖的中心間隙**

若要指定環狀圖中心孔的大小，請依照下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 物件。
1. 在投影片上新增環狀圖。
1. 指定環狀圖中心孔的大小。
1. 將簡報寫入磁碟。

以下範例示範了如何設定環狀圖中心孔的大小。

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # 將簡報寫入磁碟
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**我可以建立具有多層環的多層環狀圖嗎？**

可以。將多個系列新增至同一個環狀圖——每個系列會成為獨立的環。環的順序由系列在集合中的順序決定。

**是否支援「爆炸」環狀圖（切片分離）？**

可以。Aspose.Slides 提供 Exploded Doughnut [chart type](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/charttype/) 以及資料點的爆炸屬性；您可以將單個切片分離。

**如何取得環狀圖的影像（PNG/SVG）以用於報告？**

圖表本身是一個形狀；您可以將其呈現為 [raster image](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getImage) 或將圖表匯出為 [SVG image](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#writeAsSvg)。