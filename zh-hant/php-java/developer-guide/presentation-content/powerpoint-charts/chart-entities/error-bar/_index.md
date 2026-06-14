---
title: 使用 PHP 自訂簡報圖表中的誤差棒
linktitle: 誤差棒
type: docs
url: /zh-hant/php-java/error-bar/
keywords:
- 誤差棒
- 自訂值
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何在 Aspose.Slides for PHP via Java 中為圖表新增與自訂誤差棒 — 在 PowerPoint 簡報中優化資料視覺效果。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 在簡報圖表中使用誤差棒。它展示了如何將誤差棒新增至圖表系列、設定 X 與 Y 誤差棒，並套用固定值、百分比及自訂值等不同的值類型。

它也示範了如何使用相應的資料點集合，為系列中的各個資料點指定自訂誤差棒值。此外，本文還簡要說明了誤差棒在匯出時的行為、與標記和資料標籤的相容性，以及在何處可以找到相關的 API 參考類別與列舉。

## **新增誤差棒**
Aspose.Slides for PHP via Java 提供了簡易的 API 來管理誤差棒值。當使用自訂值類型時，可套用範例程式碼。若要指定值，請使用系列中 [**資料點**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseriescollection/) 集合內特定資料點的 **ErrorBarCustomValues** 屬性：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 在目標投影片上新增氣泡圖表。
1. 取得第一個圖表系列，並設定誤差棒 X 格式。
1. 取得第一個圖表系列，並設定誤差棒 Y 格式。
1. 設定棒的數值與格式。
1. 將修改後的簡報寫入 PPTX 檔案。

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    # 建立氣泡圖表
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # 新增誤差棒並設定其格式
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # 儲存簡報
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **新增自訂誤差棒值**
Aspose.Slides for PHP via Java 提供了簡易的 API 來管理自訂誤差棒值。當 [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/errorbarsformat/#getValueType) 方法傳回 **Custom** 時，套用範例程式碼。若要指定值，請使用系列中 [**資料點**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseriescollection/) 集合內特定資料點的 **ErrorBarCustomValues** 屬性：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 在目標投影片上新增氣泡圖表。
1. 取得第一個圖表系列，並設定誤差棒 X 格式。
1. 取得第一個圖表系列，並設定誤差棒 Y 格式。
1. 存取圖表系列的個別資料點，並為每個資料點設定誤差棒值。
1. 設定棒的數值與格式。
1. 將修改後的簡報寫入 PPTX 檔案。

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    # 建立氣泡圖表
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # 新增自訂誤差棒並設定其格式
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # 存取圖表系列資料點並設定誤差棒值給
    # 個別資料點
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # 設定圖表系列資料點的誤差棒
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # 儲存簡報
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**當將簡報匯出為 PDF 或影像時，誤差棒會發生什麼情形？**

它們會作為圖表的一部分被繪製，並在轉換過程中與其他圖表格式一起保留，前提是使用相容的版本或渲染器。

**誤差棒可以與標記和資料標籤結合使用嗎？**

可以。誤差棒是獨立的元素，且與標記和資料標籤相容；若元素重疊，可能需要調整格式。

**在 API 中，哪裡可以找到用於操作誤差棒的屬性與類別清單？**

在 API 參考中：[ErrorBarsFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/errorbarsformat/) 類別以及相關的 [ErrorBarType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/errorbartype/) 和 [ErrorBarValueType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/errorbarvaluetype/) 類別。