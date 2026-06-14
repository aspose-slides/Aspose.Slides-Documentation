---
title: 使用 PHP 在簡報中管理圖表資料系列
linktitle: 資料系列
type: docs
url: /zh-hant/php-java/chart-series/
keywords:
- 圖表系列
- 系列重疊
- 系列顏色
- 類別顏色
- 系列名稱
- 資料點
- 系列間距
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何在 PHP 中管理 PowerPoint (PPT/PPTX) 的圖表資料系列，並透過實作範例與最佳實踐提升您的資料簡報效果。"
---
## **概覽**

本文說明了 Aspose.Slides 中 [ChartSeries](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/) 的角色，重點在於資料在簡報內的結構與呈現方式。這些物件提供了定義圖表中個別資料點、類別與外觀參數的基本元素。透過操作 [ChartSeries](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/)，開發人員可無縫整合底層資料來源，並完全控制資訊的顯示方式，從而製作出動態、以資料為驅動的簡報，清晰傳達洞見與分析。

系列是圖表中繪製的數字列或欄。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

使用 [getParentSeriesGroup](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartseries/#getParentSeriesGroup) 方法，可指定 2D 圖表中長條與柱狀的重疊程度（範圍：-100 到 100）。此屬性會套用至父系列群組的所有系列：屬於對應群組屬性的投影。因此，此屬性為唯讀。

使用 `ChartSeriesGroup::setOverlap` 方法設定 `Overlap` 的偏好值。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 在投影片上加入聚合柱狀圖。  
3. 取得第一個圖表系列。  
4. 取得圖表系列的 `ParentSeriesGroup`，並為系列設定偏好的重疊值。  
5. 將修改後的簡報寫入 PPTX 檔案。

以下 PHP 程式碼示範如何為圖表系列設定重疊：

```php
  $pres = new Presentation();
  try {
    # 新增圖表
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # 設定系列重疊
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # 將簡報檔寫入磁碟
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **變更系列顏色**

Aspose.Slides for PHP via Java 可透過以下方式變更系列的顏色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 在投影片上加入圖表。  
3. 取得欲變更顏色的系列。  
4. 設定偏好的填色類型與填色顏色。  
5. 儲存已修改的簡報。

以下 PHP 程式碼示範如何變更系列的顏色：

```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **變更系列類別顏色**

Aspose.Slides for PHP via Java 可透過以下方式變更系列類別的顏色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 在投影片上加入圖表。  
3. 取得欲變更顏色的系列類別。  
4. 設定偏好的填色類型與填色顏色。  
5. 儲存已修改的簡報。

以下程式碼示範如何變更系列類別的顏色：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **變更系列名稱**

預設情況下，圖表的圖例名稱為每個資料欄或列上方儲存格的內容。

在本範例（示意圖）中，

* 欄位分別為 *Series 1、Series 2* 與 *Series 3*；  
* 列分別為 *Category 1、Category 2、Category 3* 與 *Category 4*。

Aspose.Slides for PHP via Java 允許您在圖表資料與圖例中更新或變更系列名稱。

以下 PHP 程式碼示範如何在圖表資料 `ChartDataWorkbook` 中變更系列名稱：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

以下 PHP 程式碼示範如何透過 `Series` 在圖例中變更系列名稱：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **設定圖表系列填充顏色**

Aspose.Slides for PHP via Java 可透過以下方式為圖表區域內的系列設定自動填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 以您偏好的類型（以下範例使用 `ChartType::ClusteredColumn`）加入預設資料的圖表。  
4. 取得圖表系列，將填充顏色設為 Automatic。  
5. 將簡報儲存為 PPTX 檔案。

以下 PHP 程式碼示範如何為圖表系列設定自動填充顏色：

```php
  $pres = new Presentation();
  try {
    # 建立聚合柱狀圖
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # 設定系列填充格式為自動
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # 將簡報檔寫入磁碟
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **為圖表系列設定反轉填充顏色**

Aspose.Slides 可透過以下方式為圖表區域內的系列設定反轉填充顏色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 以您偏好的類型（以下範例使用 `ChartType::ClusteredColumn`）加入預設資料的圖表。  
4. 取得圖表系列，將填充顏色設為 invert。  
5. 將簡報儲存為 PPTX 檔案。

以下 PHP 程式碼示範此操作：

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # 新增系列和類別
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # 取得第一個圖表系列並填入其系列資料。
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **設定系列在值為負時反轉**

Aspose.Slides 可透過 `IChartDataPoint.InvertIfNegative` 與 `ChartDataPoint.InvertIfNegative` 屬性設定反轉。當透過這些屬性設定反轉時，資料點在取得負值時會自動反轉顏色。

以下 PHP 程式碼示範此操作：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **清除特定點資料**

Aspose.Slides for PHP via Java 可透過以下方式清除特定圖表系列的 `DataPoints` 資料：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 依索引取得圖表的參考。  
4. 迭代所有圖表的 `DataPoints`，將 `XValue` 與 `YValue` 設為 null。  
5. 為特定圖表系列清除所有 `DataPoints`。  
6. 將修改後的簡報寫入 PPTX 檔案。

以下 PHP 程式碼示範此操作：

```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **設定系列間距寬度**

Aspose.Slides for PHP via Java 可透過 **`GapWidth`** 屬性為系列設定間距寬度：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 取得第一張投影片。  
3. 加入含預設資料的圖表。  
4. 取得任意圖表系列。  
5. 設定 `GapWidth` 屬性。  
6. 將修改後的簡報寫入 PPTX 檔案。

以下程式碼示範如何設定系列的間距寬度：

```php
  # 建立空白簡報
  $pres = new Presentation();
  try {
    # 取得簡報的第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 新增帶預設資料的圖表
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # 設定圖表資料工作表的索引
    $defaultWorksheetIndex = 0;
    # 取得圖表資料工作表
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # 新增系列
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # 新增類別
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # 取得第二個圖表系列
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # 填入系列資料
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # 設定 GapWidth 值
    $series->getParentSeriesGroup()->setGapWidth(50);
    # 將簡報儲存至磁碟
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**單一圖表能容納的系列數量是否有限制？**

Aspose.Slides 沒有對您新增的系列數量設置固定上限。實際上限取決於圖表的可讀性以及應用程式可用的記憶體。

**如果叢集內的柱狀過於靠近或過於分離，該怎麼辦？**

調整該系列（或其父系列群組）的 `GapWidth` 設定。增加數值會擴大柱狀之間的間距，減少數值則會讓柱狀更靠近。