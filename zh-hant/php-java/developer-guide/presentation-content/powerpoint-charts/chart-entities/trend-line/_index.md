---
title: 在 PHP 中為簡報圖表新增趨勢線
linktitle: 趨勢線
type: docs
url: /zh-hant/php-java/trend-line/
keywords:
- 圖表
- 趨勢線
- 指數趨勢線
- 線性趨勢線
- 對數趨勢線
- 移動平均趨勢線
- 多項式趨勢線
- 次方趨勢線
- 自訂趨勢線
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 快速在 PowerPoint 圖表中新增與自訂趨勢線 —— 一份實用指南，幫助您吸引觀眾。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 為簡報圖表新增趨勢線。它展示了如何建立圖表、為圖表系列新增趨勢線，並處理多種趨勢線類型，包括指數、線性、對數、移動平均、多項式與次方。

此外，本文還說明如何透過插入線狀圖形為圖表新增自訂線，並包含關於前向與後向趨勢線延伸值，以及在匯出為 PDF 或 SVG 或將圖表渲染為影像時趨勢線是否會保留的簡短 FAQ。

## **新增趨勢線**
Aspose.Slides for PHP via Java 提供了簡易的 API，以管理不同圖表的趨勢線：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 依索引取得投影片的參考。
1. 新增具有預設資料的圖表，並指定任意所需類型（本範例使用 ChartType::ClusteredColumn）。
1. 為圖表系列 1 新增指數趨勢線。
1. 為圖表系列 1 新增線性趨勢線。
1. 為圖表系列 2 新增對數趨勢線。
1. 為圖表系列 2 新增移動平均趨勢線。
1. 為圖表系列 3 新增多項式趨勢線。
1. 為圖表系列 3 新增次方趨勢線。
1. 將修改後的簡報寫入 PPTX 檔案。

以下程式碼用於建立帶有趨勢線的圖表。

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    # 建立叢集柱狀圖表
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # 為圖表系列 1 新增指數趨勢線
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # 為圖表系列 1 新增線性趨勢線
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # 為圖表系列 2 新增對數趨勢線
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # 為圖表系列 2 新增移動平均趨勢線
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # 為圖表系列 3 新增多項式趨勢線
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # 為圖表系列 3 新增次方趨勢線
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # 儲存簡報
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **新增自訂線**
Aspose.Slides for PHP via Java 提供了簡易的 API，以在圖表中新增自訂線。若要在簡報的選擇投影片上新增簡單的純線，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例
- 使用其 Index 取得投影片的參考
- 使用 Shapes 物件提供的 AddChart 方法建立新圖表
- 使用 Shapes 物件提供的 AddAutoShape 方法加入線條類型的 AutoShape
- 設定形狀線條的顏色。
- 將修改後的簡報寫入 PPTX 檔案

以下程式碼用於建立帶有自訂線的圖表。

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**趨勢線的“前向”和“後向”是什麼意思？**

它們是趨勢線向前或向後延伸的長度：對於散佈 (XY) 圖表，以座標軸單位表示；對於非散佈圖表，以類別數表示。只允許非負值。

**在將簡報匯出為 PDF 或 SVG，或在將投影片渲染為影像時，趨勢線會被保留嗎？**

會。Aspose.Slides 會將簡報轉換為 [PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/zh-hant/php-java/render-a-slide-as-an-svg-image/)，並將圖表渲染為影像；作為圖表一部分的趨勢線在這些操作中會被保留。此外，也提供方法可直接 [export an image of the chart](/slides/zh-hant/php-java/create-shape-thumbnails/) 本身。