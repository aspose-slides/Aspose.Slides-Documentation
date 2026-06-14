---
title: 使用 PHP 在簡報中自訂圖表資料表
linktitle: 資料表
type: docs
url: /zh-hant/php-java/chart-data-table/
keywords:
- 圖表資料
- 資料表
- 字型屬性
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 為 PPT 與 PPTX 自訂圖表資料表，提升簡報的效率與吸引力。"
---
## **概述**

本文說明如何在 Aspose.Slides 中操作圖表資料表。它展示如何為圖表顯示資料表，並透過設定字型屬性（例如粗體樣式和字型高度）自訂文字格式。範例示範載入簡報、加入圖表、啟用圖表資料表、套用字型設定，最後儲存更新後的簡報。

同時也提供了常見問題的簡要解答，內容包括在圖表資料表中顯示圖例鍵、匯出時是否保留資料表、從現有簡報或範本載入的圖表是否支援資料表，以及如何快速找出已啟用資料表的圖表。

## **設定圖表資料表的字型屬性**
Aspose.Slides for PHP via Java 提供變更系列顏色中類別色彩的支援。

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別物件。
1. 在投影片上新增圖表。
1. 設定圖表資料表。
1. 設定字型高度。
1. 儲存已修改的簡報。

以下提供範例程式碼。

```php
  # 建立空白簡報
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**我可以在圖表資料表的值旁顯示小圖例鍵嗎？**

是。資料表支援[legend keys](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/datatable/setshowlegendkey/)，且您可以開啟或關閉它們。

**匯出簡報為 PDF、HTML 或影像時，資料表會被保留嗎？**

是。Aspose.Slides 將圖表渲染為投影片的一部分，所以匯出的[PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/zh-hant/php-java/convert-powerpoint-to-html/)/[image](/slides/zh-hant/php-java/convert-powerpoint-to-png/) 皆包含資料表的圖表。

**從範本檔案產生的圖表是否支援資料表？**

是。對於從現有簡報或範本載入的任何圖表，您可以使用圖表屬性檢查並變更資料表是否[顯示](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/hasdatatable/)。

**我要如何快速找出檔案中哪些圖表已啟用資料表？**

檢查每個圖表的屬性，以判斷資料表是否[顯示](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/hasdatatable/)，並遍歷投影片以找出已啟用的圖表。