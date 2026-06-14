---
title: 使用 PHP 客製化簡報中的圓餅圖
linktitle: 圓餅圖
type: docs
url: /zh-hant/php-java/pie-chart/
keywords:
- 圓餅圖
- 管理圖表
- 自訂圖表
- 圖表選項
- 圖表設定
- 繪圖選項
- 切片顏色
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 建立並客製化圓餅圖，匯出至 PowerPoint，讓您的資料敘事在數秒內提升。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圓餅圖。它示範了如何為「Pie of Pie」與「Bar of Pie」圖表設定次要繪圖選項，以及如何為標準圓餅圖啟用自動切片著色。

範例著重於實務圖表自訂步驟，例如將圖表加入投影片、調整系列與標籤設定、以自訂類別與數值取代預設圖表資料，並儲存更新後的簡報。

## **次要繪圖選項 – Pie of Pie 與 Bar of Pie 圖表**
Aspose.Slides for PHP via Java 現已支援 Pie of Pie 或 Bar of Pie 圖表的次要繪圖選項。於本主題中，我們將示範如何使用 Aspose.Slides 指定這些選項。設定屬性請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別物件。
1. 在投影片上加入圖表。
1. 指定圖表的次要繪圖選項。
1. 將簡報寫入磁碟。

以下範例示範了我們為 Pie of Pie 圖表設定的各項屬性。

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    # 在投影片上新增圖表
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # 設定不同的屬性
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # 將簡報寫入磁碟
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **設定自動圓餅圖切片顏色**
Aspose.Slides for PHP via Java 提供簡易 API 以設定自動圓餅圖切片顏色。範例程式碼示範了上述屬性的設定方式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 取得第一張投影片。
1. 使用預設資料新增圖表。
1. 設定圖表標題。
1. 將第一個系列設定為「顯示值」。
1. 設定圖表資料工作表的索引。
1. 取得圖表資料工作表。
1. 刪除預設產生的系列與類別。
1. 新增類別。
1. 新增系列。

將已修改的簡報寫入 PPTX 檔案。

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    # 以預設資料新增圖表
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # 設定圖表標題
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # 設定第一個系列以顯示值
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # 設定圖表資料工作表的索引
    $defaultWorksheetIndex = 0;
    # 取得圖表資料工作表
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # 刪除預設產生的系列與類別
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # 新增類別
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # 新增系列
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # 現在填入系列資料
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**是否支援「Pie of Pie」與「Bar of Pie」變體？**

是的，程式庫[支援](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/charttype/)圓餅圖的次要繪圖，包括「Pie of Pie」與「Bar of Pie」類型。

**我可以只將圖表匯出為圖像（例如 PNG）嗎？**

可以，您可以[將圖表本身匯出為圖像](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getImage)（例如 PNG），而不需要匯出整份簡報。